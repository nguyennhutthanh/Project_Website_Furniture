using App.Data.Entities;
using App.Data.Repositories;
using App.Web.Areas.Admin.ViewModels.CategoryNews;
using App.Web.WebConfig;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Components.SelecteListNews
{
	public class SelecteListNewsCategory : ViewComponent
	{
		readonly GenericRepository _repository;
		public SelecteListNewsCategory(GenericRepository _db)
		{
			_repository = _db;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var cate = _repository.GetAll<AppCategoryNews>()
						.ProjectTo<ListItemCategoryNewsVM>(AutoMapperProfile.CategoryNewsConf)
						.ToList();
			return View(cate);
		}
	}
}
