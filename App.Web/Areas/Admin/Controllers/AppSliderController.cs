using App.Data.Entities;
using App.Data.Repositories;
using App.Web.Areas.Admin.ViewModels.Slider;
using App.Web.Common;
using App.Web.WebConfig;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using X.PagedList;

namespace App.Web.Areas.Admin.Controllers
{
	public class AppSliderController : AppControllerBase
	{
		private readonly GenericRepository _repo;
		private const string MESSAGE_COMPARE_DAY = "Ngày hết hạn không thể nhỏ hơn ngày bắt đầu";

		public AppSliderController(IMapper mapper, GenericRepository repo) : base(mapper)
		{
			_repo = repo;
		}
		public async Task<IActionResult> Index(int page = 1, int size = DEFAULT_PAGE_SIZE)
		{
			var data = (await _repo
				.GetAll<AppSlider>()
				.ProjectTo<ListItemSliderVM>(AutoMapperProfile.SliderConf)
				.ToPagedListAsync(page, size))
				.GenRowIndex();
			return View(data);
		}

		public IActionResult Create() => View();

		[HttpPost]
		public async Task<IActionResult> Create(AddOrUpdateSliderVM model)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}

			if(model.ToDate < model.FromDate)
			{
				ModelState.AddModelError("ToDate", MESSAGE_COMPARE_DAY);
				return View(model);
			}

			try
			{
				var user = CurrentUserId;
				var slider = _mapper.Map<AppSlider>(model);
				slider.CreatedBy = user;
				await _repo.AddAsync(slider);
				SetSuccessMesg($"Thêm slider thành công");
				return RedirectToAction(nameof(Index));
			}
			catch(Exception ex)
			{
				LogException(ex);
				return View(model);
			}
		}

		public async Task<IActionResult> Edit(int id)
		{
			var slider = await _repo.FindAsync<AppSlider>(id);
			if(slider == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			var sliderVM = _mapper.Map<AddOrUpdateSliderVM>(slider);
			return View(sliderVM);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AddOrUpdateSliderVM model)
		{
			var slider = await _repo.FindAsync<AppSlider>(model.Id);
			if(!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}
			if(slider == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			if (model.ToDate < model.FromDate)
			{
				ModelState.AddModelError("ToDate", MESSAGE_COMPARE_DAY);
				return View(model);
			}
			try
			{
				_mapper.Map<AddOrUpdateSliderVM, AppSlider>(model, slider);
				slider.UpdatedDate = DateTime.Now;
				await _repo.UpdateAsync(slider);
				SetSuccessMesg($"Cập nhật slider thành công");
				return RedirectToAction(nameof(Index));
			}
			catch(Exception ex)
			{
				LogException(ex);
				return View(model);
			}
		}

		public async Task<IActionResult> Delete(int id)
		{
			var slider = await _repo.FindAsync<AppSlider>(id);
			if(slider == null)
			{
				SetErrorMesg("Ảnh này không tồn tại hoặc đã được xóa trước đó");
				return RedirectToAction(nameof(Index));
			}
			await _repo.DeleteAsync(slider);
			SetSuccessMesg($"Slider được xóa thành công");
			return RedirectToAction(nameof(Index));
		}
	}
}
