using App.Data.Entities;
using App.Data.Repositories;
using App.Web.Areas.Admin.ViewModels.ProductCategory;
using App.Web.WebConfig;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.Admin.Components.ListProductCategory
{
	public class SelectListProductCategoryComponent : ViewComponent
	{
		readonly GenericRepository repository;
		public SelectListProductCategoryComponent(GenericRepository _db)
		{
			repository = _db;
		}
		public async Task<IViewComponentResult> InvokeAsync(AddOrUpdateProductCategoryVM productCate)
		{
			var proCate = repository
				.GetAll<AppProductCategory>(s => s.CateLevel.Equals(1))
				.Include(s => s.ProductCategoryNavigation)
				.ThenInclude(s => s.ProductCategoryNavigation)
				.ProjectTo<ListItemProductCategoryVM>(AutoMapperProfile.ProductCategoryConf)
				.ToList();
			var listCategory = new SelectList(proCate, "Id", "CateLevel", -1);
			if (productCate != null)
			{
				listCategory = new SelectList(proCate, "Id", "CateLevel", productCate.ParentCateId);
			};
			ViewBag.ProductCate = listCategory;
			return View(productCate);
		}
	}
}
