using App.Data.Entities;
using App.Data.Repositories;
using App.Web.Areas.Admin.ViewModels.News;
using App.Web.WebConfig;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Components.SelecteListNews
{
	public class SelecteListNewsHot : ViewComponent
	{
		readonly GenericRepository _repository;
		public SelecteListNewsHot(GenericRepository _db)
		{
			_repository = _db;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var news = _repository.GetAll<AppNews>()
						.OrderByDescending(s => s.CreatedDate)
						.ProjectTo<ListItemNewsVM>(AutoMapperProfile.NewsConf)
						.ToList();
			return View(news);
		}
	}
}
