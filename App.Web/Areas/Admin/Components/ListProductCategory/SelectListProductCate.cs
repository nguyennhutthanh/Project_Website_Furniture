using App.Data.Entities;
using App.Data.Repositories;
using App.Web.Areas.Admin.ViewModels.ProductCategory;
using App.Web.WebConfig;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace App.Web.Areas.Admin.Components.ListProductCategory
{
	public class SelectListProductCate : ViewComponent
	{
		readonly GenericRepository repository;
		public SelectListProductCate(GenericRepository _db)
		{
			repository = _db;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var getdata = repository.DbContext.AppProductCategories
				.Include(s => s.ProductCategoryNavigation)
				.ThenInclude(s => s.ProductCategoryNavigation)
				.Where(s => s.DeletedDate == null)
				.ToList();
			var listCate = getdata
				.Where(s => s.CateLevel.Equals(1))
				.ToList();
			return View(listCate);
		}
	}
}
