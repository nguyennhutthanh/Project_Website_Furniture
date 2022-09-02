using App.Data.Entities;
using App.Data.Repositories;
using App.Share.Consts;
using App.Share.Extensions;
using App.Web.Areas.Admin.ViewModels.Policy;
using App.Web.Common;
using App.Web.WebConfig;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace App.Web.Areas.Admin.Controllers
{
	public class PolicyController : AppControllerBase
	{
		readonly GenericRepository _repository;
		public PolicyController(GenericRepository repository, IMapper mapper) : base(mapper)
		{
			_repository = repository;
		}

		[AppAuthorize()]
		public async Task<IActionResult> Index(int page = 1, int size = DEFAULT_PAGE_SIZE)
		{
			var data = (await _repository
			.GetAll<AppPolicy>()
			.ProjectTo<ListItemPolicyVM>(AutoMapperProfile.PolicyConf)
			.ToPagedListAsync(page, size))
			.GenRowIndex();
			return View(data);
		}
		[AppAuthorize(AuthConst.AppPolicy.CREATE)]
		public IActionResult Create() => View();
		[AppAuthorize(AuthConst.AppPolicy.CREATE)]
		[HttpPost]
		public async Task<IActionResult> Create(AddOrUpdatePolicyVM model)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}
			if (await _repository.AnyAsync<AppPolicy>(u => u.Title.Equals(model.Title)))
			{
				SetErrorMesg("Chính sách này đã tồn tại");
				return View(model);
			}

			try
			{
				var policy = _mapper.Map<AppPolicy>(model);
				policy.CreatedBy = CurrentUserId;
				policy.UserId = CurrentUserId;
				policy.Slug = policy.Title.Slugify();
				await _repository.AddAsync(policy);
				SetSuccessMesg($"Thêm chính sách '{policy.Title}' thành công");
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				LogException(ex);
				return View(model);
			}
		}
		[AppAuthorize(AuthConst.AppPolicy.UPDATE)]
		public async Task<IActionResult> Edit(int id)
		{
			var policy = await _repository.FindAsync<AppPolicy>(id);
			if (policy == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			var policyVM = _mapper.Map<AddOrUpdatePolicyVM>(policy);
			return View(policyVM);
		}
		[AppAuthorize(AuthConst.AppPolicy.UPDATE)]
		[HttpPost]
		public async Task<IActionResult> Edit(AddOrUpdatePolicyVM model)
		{
			var policy = await _repository.FindAsync<AppPolicy>(model.Id);

			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}
			if (policy == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			if (await _repository.AnyAsync<AppNews>(u => u.Title.Equals(model.Title) && u.Title != policy.Title))
			{
				SetErrorMesg("Chính sách này đã tồn tại !");
				return View(model);
			}
			try
			{
				_mapper.Map<AddOrUpdatePolicyVM, AppPolicy>(model, policy);
				policy.UpdatedDate = DateTime.Now;
				policy.Slug = model.Title.Slugify();
				await _repository.UpdateAsync(policy);
				SetSuccessMesg($"Cập nhật chính sách [{policy.Title}] thành công");
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				LogException(ex);
				return View(model);
			}
		}
		[AppAuthorize(AuthConst.AppPolicy.DELETE)]
		public async Task<IActionResult> Delete(int id)
		{
			var policy = await _repository.FindAsync<AppPolicy>(id);
			if (policy == null)
			{
				SetErrorMesg("Chính sách này không tồn tại hoặc đã được xóa trước đó");
				return RedirectToAction(nameof(Index));
			}
			await _repository.DeleteAsync(policy);
			SetSuccessMesg($"Chính sách '{policy.Title}' được xóa thành công");
			return RedirectToAction(nameof(Index));
		}
		[AppAuthorize(AuthConst.AppPolicy.DETAILS)]
		public async Task<IActionResult> Details(int id)
		{
			var policy = await _repository.FindAsync<AppPolicy>(id);
			if (policy == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			var policyVM = _mapper.Map<ListItemPolicyVM>(policy);
			return View(policyVM);
		}
	}
}
