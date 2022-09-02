using App.Data.Entities;
using App.Data.Repositories;
using App.Web.Common.Mailer;
using App.Web.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Controllers
{
	public class ContactController : Controller
	{
		private readonly INotyfService _notyf;
		private readonly GenericRepository _repository;
		private readonly AppMailConfiguration _mailConfig;
		private readonly IMapper _mapper;
		public ContactController(IMapper mapper, INotyfService notyf, GenericRepository repository, AppMailConfiguration mailConfig)
		{
			_notyf = notyf;
			_repository = repository;
			_mailConfig = mailConfig;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(ContactVM contact)
		{
			if (!ModelState.IsValid)
			{
				_notyf.Error("Dữ liệu không hợp lệ vui lòng kiểm tra lại !");
				return View(contact);
			}
			try
			{
				var contac = _mapper.Map<AppContact>(contact);
				await _repository.AddAsync(contac);
				_notyf.Custom("Gữi lời nhắn thành công !", 10, "#f1f1f1", "fa-check-circle");
				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{
				return View(contact);
			}
		}
		[HttpPost]
		public async Task<IActionResult> SubcriberUser(string emailregister)
		{
			var dataEmailSubcriber = _repository.GetAll<AppEmailSubscriber>().ToList();
			if (dataEmailSubcriber.Count() > 0)
			{
				if (dataEmailSubcriber.Any().Equals(emailregister))
				{
					_notyf.Custom("Email này đã được đăng ký với cửa hàng trước đó !", 10, "#f1f1f1", "fa-check-circle");
					return RedirectToAction(nameof(Index), "Home");
				}
			}
			AppEmailSubscriber dataSubcriber = new AppEmailSubscriber()
			{
				Email = emailregister
			};
			await _repository.AddAsync<AppEmailSubscriber>(dataSubcriber);
			_notyf.Custom("Đăng ký thành công !", 10, "#f1f1f1", "fa-check-circle");
			return RedirectToAction(nameof(Index), "Home");
		}
	}
}
