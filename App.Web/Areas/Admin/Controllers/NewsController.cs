using App.Data.Entities;
using App.Data.Repositories;
using App.Share.Consts;
using App.Share.Extensions;
using App.Web.Areas.Admin.ViewModels.News;
using App.Web.Common;
using App.Web.Common.Mailer;
using App.Web.WebConfig;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using X.PagedList;
using RazorEngine;
using RazorEngine.Templating;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using RazorEngine.Configuration;
using System.Text;

namespace App.Web.Areas.Admin.Controllers
{
	public class NewsController : AppControllerBase
	{
		private readonly GenericRepository _repository;
		private readonly AppMailConfiguration _mailConfig;
		private readonly IHostingEnvironment _env;
		private readonly IHttpContextAccessor _contextAccessor;
		public NewsController(IHttpContextAccessor contextAccessor, IHostingEnvironment env, AppMailConfiguration mailConfig, GenericRepository repository, IMapper mapper) : base(mapper)
		{
			_repository = repository;
			_mailConfig = mailConfig;
			_contextAccessor = contextAccessor;
			_env = env;
		}
		[AppAuthorize()]
		public async Task<IActionResult> Index(int page = 1, int size = DEFAULT_PAGE_SIZE)
		{
			var data = (await _repository
			.GetAll<AppNews>()
			.ProjectTo<ListItemNewsVM>(AutoMapperProfile.NewsConf)
			.ToPagedListAsync(page, size))
			.GenRowIndex();
			return View(data);
		}
		[AppAuthorize(AuthConst.AppNews.CREATE)]
		public IActionResult Create() => View();
		[AppAuthorize(AuthConst.AppNews.CREATE)]
		[HttpPost]
		public async Task<IActionResult> Create([FromServices] SystemEnv sysEnv, AddOrUpdateNewsVM model)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}
			if (await _repository.AnyAsync<AppNews>(u => u.Title.Equals(model.Title)))
			{
				SetErrorMesg("Bài viết này đã tồn tại");
				return View(model);
			}
			try
			{
				var user = CurrentUserId;
				var news = _mapper.Map<AppNews>(model);
				news.UserId = user;
				news.CreatedBy = user;
				news.Slug = news.Title.Slugify();
				await _repository.AddAsync(news);

				if (model.SendAllEmail)
				{
					var pathToFile = $"{_env.WebRootPath}" +
					$"{Path.DirectorySeparatorChar}" +
					$"emailTemplate{Path.DirectorySeparatorChar}InfoNewMessager.html";

					var appMailSender = new AppMailSender()
					{
						Name = $"Công ty TNHH SHOWROOM PHÚ CƯỜNG",
						Subject = $"Thông tin tới bạn về cửa hàng"
					};

					using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
					{
						appMailSender.Content = SourceReader.ReadToEnd();
					};

					var listEmailSubscriber = _repository.GetAll<AppEmailSubscriber>().ToList();
					var listMailReciver = new List<AppMailReciver>();
					if (listEmailSubscriber.Count() > 0)
					{
						foreach (var item in listEmailSubscriber)
						{
							AppMailReciver mailReciver = new AppMailReciver()
							{
								Name = item.Email,
								Email = item.Email
							};
							listMailReciver.Add(mailReciver);
						}
					}
					var resultEmail = listMailReciver.AsEnumerable();
					var doamin = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}/News/NewsDetails?slug={news.Slug}";
					var logo = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{sysEnv[SysEnvConst.LOGO]}";

					var contentMessage = Engine.Razor
						.RunCompile(appMailSender.Content, "templateKey",
						null,
						new
						{
							LogoCompany = logo,
							Linknews = doamin,
							Signature = _mailConfig.Signature,
							Year = DateTime.Now.Year,
							CompanyName = appMailSender.Name
						});

					appMailSender.Content = contentMessage.ToString();
					AppMailer.SendToList(appMailSender, resultEmail, _mailConfig);
				}
				SetSuccessMesg($"Thêm bài viết '{news.Title}' thành công");
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				LogException(ex);
				return View(model);
			}
		}
		[AppAuthorize(AuthConst.AppNews.UPDATE)]
		public async Task<IActionResult> Edit(int id)
		{
			var post = await _repository.FindAsync<AppNews>(id);
			if (post == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			var postVM = _mapper.Map<AddOrUpdateNewsVM>(post);
			return View(postVM);
		}
		[AppAuthorize(AuthConst.AppNews.UPDATE)]
		[HttpPost]
		public async Task<IActionResult> Edit(AddOrUpdateNewsVM model)
		{
			var post = await _repository.FindAsync<AppNews>(model.Id);

			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}
			if (post == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			if (await _repository.AnyAsync<AppNews>(u => u.Title.Equals(model.Title) && u.Title != post.Title))
			{
				SetErrorMesg("Bài viết này đã tồn tại !");
				return View(model);
			}
			try
			{
				_mapper.Map<AddOrUpdateNewsVM, AppNews>(model, post);
				post.UpdatedDate = DateTime.Now;
				post.Slug = model.Title.Slugify();
				await _repository.UpdateAsync(post);
				SetSuccessMesg($"Cập nhật bài viết [{post.Title}] thành công");
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				LogException(ex);
				return View(model);
			}
		}
		[AppAuthorize(AuthConst.AppNews.DELETE)]
		public async Task<IActionResult> Delete(int id)
		{
			var news = await _repository.FindAsync<AppNews>(id);
			if (news == null)
			{
				SetErrorMesg("Bài viết này không tồn tại hoặc đã được xóa trước đó");
				return RedirectToAction(nameof(Index));
			}
			await _repository.DeleteAsync(news);
			SetSuccessMesg($"Bài viết '{news.Title}' được xóa thành công");
			return RedirectToAction(nameof(Index));
		}
		[AppAuthorize(AuthConst.AppNews.PUBLIC)]
		public async Task<IActionResult> PublicNews(int id)
		{
			var post = await _repository.FindAsync<AppNews>(id);
			if (post == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			post.Published = true;
			post.PublishedAt = DateTime.Now;
			await _repository.UpdateAsync(post);
			SetSuccessMesg($"Công khai bài viết [{post.Title}] thành công");
			return RedirectToAction(nameof(Index));
		}
		[AppAuthorize(AuthConst.AppNews.UNPUBLIC)]
		public async Task<IActionResult> UnPublicNews(int id)
		{
			var post = await _repository.FindAsync<AppNews>(id);
			if (post == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			post.Published = false;
			post.PublishedAt = DateTime.Now;
			await _repository.UpdateAsync(post);
			SetSuccessMesg($"Gỡ bài viết [{post.Title}] thành công");
			return RedirectToAction(nameof(Index));
		}
	}
}

