using App.Data.Entities;
using App.Data.Repositories;
using App.Share.Consts;
using App.Web.Areas.Admin.ViewModels.ProductCategory;
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
	public class ProductCategoryController : AppControllerBase
	{
		readonly GenericRepository _repository;
		public ProductCategoryController(GenericRepository repository, IMapper mapper) : base(mapper)
		{
			_repository = repository;
		}
		[AppAuthorize()]
		public IActionResult Index()
		{
			return View();
		}
		[AppAuthorize(AuthConst.AppProductCategory.CREATE)]
		[HttpPost]
		public async Task<IActionResult> Index(AddOrUpdateProductCategoryVM productCate)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(productCate);
			}
			if (await _repository.AnyAsync<AppProductCategory>(u => u.Name.Equals(productCate.Name)))
			{
				SetErrorMesg("Danh mục này đã tồn tại");
				return View(productCate);
			}
			try
			{
				var cate = _mapper.Map<AppProductCategory>(productCate);
				cate.CreatedBy = CurrentUserId;
				if (productCate.ParentCateId == -1)
				{
					cate.ParentCateId = null;
					cate.HasChild = false;
					cate.CateLevel = 1;
				}
				else
				{
					var parent = await _repository.FindAsync<AppProductCategory>((int)productCate.ParentCateId);
					cate.CateLevel = parent.CateLevel + 1;
					parent.HasChild = true;
					await _repository.UpdateAsync(parent);
				}
				await _repository.AddAsync(cate);
				SetSuccessMesg($"Thêm danh mục '{cate.Name}' thành công");
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				LogException(ex);
				return View(productCate);
			}
		}

		[AppAuthorize(AuthConst.AppProductCategory.UPDATE)]
		public async Task<IActionResult> Edit(int id)
		{
			var productCate = await _repository.FindAsync<AppProductCategory>(id);
			if (productCate == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			var postVM = _mapper.Map<AddOrUpdateProductCategoryVM>(productCate);
			return View(postVM);
		}
		[AppAuthorize(AuthConst.AppProductCategory.UPDATE)]
		[HttpPost]
		public async Task<IActionResult> Edit(AddOrUpdateProductCategoryVM model)
		{
			var cate = await _repository.FindAsync<AppProductCategory>(model.Id);

			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}
			if (cate == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}
			if (await _repository.AnyAsync<AppProductCategory>(u => u.Name.Equals(model.Name) && u.Name != cate.Name))
			{
				SetErrorMesg("Danh mục này đã tồn tại !");
				return View(model);
			}
			try
			{
				_mapper.Map(model, cate);
				cate.UpdatedDate = DateTime.Now;
				await _repository.UpdateAsync(cate);
				SetSuccessMesg($"Cập nhật danh mục [{cate.Name}] thành công");
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				LogException(ex);
				return View(model);
			}
		}
		[AppAuthorize(AuthConst.AppProductCategory.DELETE)]
		public async Task<IActionResult> Delete(int id)
		{
			var category = await _repository.FindAsync<AppProductCategory>(id);
			if (category == null)
			{
				SetErrorMesg("Danh mục này không tồn tại hoặc đã được xóa trước đó");
				return RedirectToAction(nameof(Index));
			}
			if (category.HasChild)
			{
				SetErrorMesg("Danh mục có chứa danh mục con nên không thể xóa !");
				return RedirectToAction(nameof(Index));
			}
			var parent = await _repository.FindAsync<AppProductCategory>((int)category.ParentCateId);
			if (parent.ProductCategoryNavigation.Count == 1)
			{
				parent.HasChild = false;
				await _repository.UpdateAsync(parent);
			}
			// chưa check điều kiện có sản phẩm hay chưa
			await _repository.DeleteAsync(category);
			SetSuccessMesg($"Danh mục '{category.Name}' được xóa thành công");
			return RedirectToAction(nameof(Index));
		}
	}
}
