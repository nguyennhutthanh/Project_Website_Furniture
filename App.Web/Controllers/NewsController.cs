using App.Data.Entities;
using App.Data.Repositories;
using App.Web.Areas.Admin.ViewModels.News;
using App.Web.Common;
using App.Web.ViewModels.News;
using App.Web.WebConfig;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace App.Web.Controllers
{
	public class NewsController : Controller
	{
		private readonly INotyfService _notyf;
		private readonly GenericRepository _repository;
		private readonly IMapper _mapper;
		public NewsController(IMapper mapper, INotyfService notyf, GenericRepository repository)
		{
			_notyf = notyf;
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<IActionResult> Index(int page = 1, int size = 5, string slug = "")
		{
			if (slug == "")
			{
				var dataCate = _repository.GetAll<AppCategoryNews>().ToList();
				ViewBag.TitleCate = "Tất cả tin tức";
				var random = new Random();
				ViewBag.ImageCate = dataCate[random.Next(0, dataCate.Count())].CoverImgPath;
				var data = (await _repository
					.GetAll<AppNews>()
					.Where(s => s.Published == true)
					.ProjectTo<ListNewsVM>(AutoMapperProfile.NewsConf)
					.ToPagedListAsync(page, size))
					.GenRowIndex();
				return View(data);
			}
			else
			{
				var cate = await _repository.GetOneAsync<AppCategoryNews>(s => s.Slug.Equals(slug));
				if (cate != null)
				{
					ViewBag.TitleCate = cate.Title;
					ViewBag.ImageCate = cate.CoverImgPath;
					var data = (await _repository
					.GetAll<AppNews>(s => s.CategoryId.Equals(cate.Id))
					.Where(s => s.Published == true)
					.ProjectTo<ListNewsVM>(AutoMapperProfile.NewsConf)
					.ToPagedListAsync(page, size))
					.GenRowIndex();
					return View(data);
				}
				else
				{
					return View();
				}
			}
		}
		public async Task<IActionResult> NewsDetails(string slug = "")
		{
			ViewBag.HasLocalSEO = true;
			var newsData = _repository.GetAll<AppNews>()
				.Include(s => s.CategoryNews).ToList();
			AppNews result = new AppNews();
			if (newsData.Count() > 0)
			{
				result = newsData.SingleOrDefault(s => s.Slug.Equals(slug));
			}
			if (result != null)
			{
				return View(result);
			}
			return View();
		}
	}
}

