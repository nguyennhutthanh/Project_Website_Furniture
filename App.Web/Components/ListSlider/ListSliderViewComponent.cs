using App.Data.Entities;
using App.Data.Repositories;
using App.Web.Areas.Admin.ViewModels.Slider;
using App.Web.WebConfig;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using App.Web.Common;

namespace App.Web.Components.ListSlider
{
	public class ListSliderViewComponent : ViewComponent
	{
		readonly GenericRepository repository;
		public ListSliderViewComponent(GenericRepository repo)
		{
			repository = repo;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var data = await repository
				.GetAll<AppSlider>(x => DateTime.Now >= x.FromDate && DateTime.Now <= x.ToDate)
				.Take(10)
				.OrderByDescending(x => x.DisplayOrder)
				.ProjectTo<ListItemSliderVM>(AutoMapperProfile.SliderConf)
				.ToListAsync();
			return View(data);
		}
	}
}
