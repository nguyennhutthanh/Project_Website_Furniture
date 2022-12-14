using App.Data.Entities;
using App.Data.Repositories;
using App.Share.Consts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace App.Web.Areas.Admin.Components.MainNavBar
{
	public class MainNavBarViewComponent : ViewComponent
	{
		readonly GenericRepository repository;
		public MainNavBarViewComponent(GenericRepository _repository)
		{
			repository = _repository;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var navBar = new NavBarViewModel();
			navBar.Items.AddRange(new MenuItem[]
			{
				new MenuItem
				{
					Action = "Index",
					Controller = "User",
					DisplayText = "Quản lý tài khoản",
					Icon = "fa-user-cog",
					Permission = AuthConst.AppUser.VIEW_LIST,
				},
				new MenuItem
				{
					Action = "Index",
					Controller = "Role",
					DisplayText = "Quản lý phân quyền",
					Icon = "fa-user-shield",
					Permission = AuthConst.AppRole.VIEW_LIST,
				},
				new MenuItem
				{
					Action = "Index",
					Controller = "FileManager",
					DisplayText = "Quản lý tệp",
					Icon = "fa-folder-open",
				},
				new MenuItem
				{
					Action = "MyProfile",
					Controller = "Account",
					DisplayText = "Tài khoản của tôi",
					Icon = "fa-user",
				},
				new MenuItem
				{
					Action = "Index",
					Controller = "Policy",
					DisplayText = "Quản lý chính sách",
					Icon = "fa-shield-alt",
				},
				new MenuItem
				{
					Action = "Contacts",
					Controller = "ConTacts",
					DisplayText = "Quản lý liên hệ",
					Icon = "fa-envelope",
				},
				new MenuItem
				{
					DisplayText = "Quản lý tin tức",
					Icon = "fa-newspaper",
					ChildrenItems = new MenuItem[]
					{
						new MenuItem
						{
							Action = "Index",
							Controller = "CategoryNews",
							DisplayText = "Quản lý thể loại tin",
							Icon = "fa-th-large"
						},
						new MenuItem
						{
							Action = "Index",
							Controller = "News",
							DisplayText = "Quản lý bài viết",
							Icon = "fa-file-alt"
						}
					}
				},
				new MenuItem
				{
					DisplayText = "Quản lý sản phẩm",
					Icon = "fa-shopping-basket",
					ChildrenItems = new MenuItem[]
					{
						new MenuItem
						{
							Action = "Index",
							Controller = "ProductCategory",
							DisplayText = "Quản lý danh mục",
							Icon = "fa-th-large"
						}
					}
				},
				new MenuItem
				{
					Action = "Index",
					Controller = "AppSlider",
					DisplayText = "Slider",
					Icon = "fa-align-center",
				},
				new MenuItem
				{
					Action = "Index",
					Controller = "SystemEnv",
					DisplayText = "Cấu hình",
					Icon = "fa-wrench",
				},
				//new MenuItem
				//{
				//	DisplayText = "Menu 2 cấp",
				//	Icon = "fa-folder-open",
				//	ChildrenItems = new MenuItem[]
				//	{
				//		new MenuItem
				//		{
				//			Action = "Index",
				//			Controller = "User",
				//			DisplayText = "Quản lý tài khoản",
				//			Icon = "fa-user-cog"
				//		}
				//	}
				//},
			});
			return View(navBar);
		}
	}
}
