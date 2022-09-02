using App.Data.Entities;
using App.Data.Entities.Base;
using App.Web.Areas.Admin.ViewModels.Account;
using App.Web.Areas.Admin.ViewModels.CategoryNews;
using App.Web.Areas.Admin.ViewModels.Contact;
using App.Web.Areas.Admin.ViewModels.News;
using App.Web.Areas.Admin.ViewModels.Policy;
using App.Web.Areas.Admin.ViewModels.ProductCategory;
using App.Web.Areas.Admin.ViewModels.Role;
using App.Web.Areas.Admin.ViewModels.User;
using App.Web.Areas.Admin.ViewModels.Slider;
using App.Web.ViewModels;
using App.Web.ViewModels.News;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.WebConfig
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			// Map dữ liệu từ kiểu UserAddOrEditVM sang AppUser
			CreateMap<UserAddOrEditVM, AppUser>();

			// Map dữ liệu từ kiểu AppUser sang UserAddOrEditVM
			CreateMap<AppUser, UserAddOrEditVM>();

			CreateMap<AppUser, UpdateUserViewModel>().ReverseMap();

			CreateMap<AppUser, UserDataForApp>().ReverseMap();

			CreateMap<AppUser, AcceptUpdateViewModel>().ReverseMap();

			CreateMap<AppCategoryNews, AddOrUpdateCategoryNewsVM>();

			CreateMap<AddOrUpdateCategoryNewsVM, AppCategoryNews>();

			CreateMap<AddOrUpdateNewsVM, AppNews>();

			CreateMap<AppNews, AddOrUpdateNewsVM>();

			CreateMap<AddOrUpdatePolicyVM, AppPolicy>();

			CreateMap<AppPolicy, AddOrUpdatePolicyVM>();

			CreateMap<AppPolicy, ListItemPolicyVM>();

			CreateMap<AppContact, ContactVM>();

			CreateMap<ContactVM, AppContact>();

			CreateMap<AppProductCategory, AddOrUpdateProductCategoryVM>();

			CreateMap<AddOrUpdateProductCategoryVM, AppProductCategory>();

			CreateMap<AddOrUpdateSliderVM, AppSlider>();

			CreateMap<AppSlider, AddOrUpdateSliderVM>();

		}
		public static MapperConfiguration RoleIndexConf = new(mapper =>
		{
			// Map dữ liệu từ kiểu AppRole sang RoleListItemVM
			mapper.CreateMap<AppRole, RoleListItemVM>();
		});

		// Cấu hình mapping cho UserController, action Index
		public static MapperConfiguration UserIndexConf = new(mapper =>
		{
			// Map dữ liệu từ AppUser sang UserListItemVM, map thuộc tính RoleName
			mapper.CreateMap<AppUser, UserListItemVM>()
				.ForMember(uItem => uItem.RoleName, opts => opts.MapFrom(uEntity => uEntity.AppRole.Name));
		});

		// Cấu hình mapping cho AccountController, action Login
		public static MapperConfiguration LoginConf = new(mapper =>
		{
			// Map dữ liệu từ AppUser sang UserListItemVM, map thuộc tính RoleName
			mapper.CreateMap<AppUser, UserDataForApp>()
				.ForMember(uItem => uItem.RoleName, opts => opts.MapFrom(uEntity => uEntity.AppRole == null ? "" : uEntity.AppRole.Name))
				.ForMember(uItem => uItem.Permission, opts => opts.MapFrom
				(
					uEntity => string.Join(',', uEntity.AppRole
														.AppRolePermissions
														.Select(p => p.MstPermissionId))
				)
			);
		});

		public static MapperConfiguration UpdateConf = new(mapper =>
		{
			// Map dữ liệu từ AppUser sang UserListItemVM, map thuộc tính RoleName
			mapper.CreateMap<AppUser, UpdateUserViewModel>()
				.ForMember(uItem => uItem.RoleName, opts => opts.MapFrom(uEntity => uEntity.AppRole == null ? "" : uEntity.AppRole.Name))
				.ForMember(uItem => uItem.Permission, opts => opts.MapFrom
				(
					uEntity => string.Join(',', uEntity.AppRole
														.AppRolePermissions
														.Select(p => p.MstPermissionId))
				)
			);
		});

		// Cấu hình mapping cho RoleController, action Delete
		public static MapperConfiguration RoleDeleteConf = new(mapper =>
		{
			// Map dữ liệu thuộc tính con
			mapper.CreateMap<AppUser, RoleDeleteVM_User>();
			// Map dữ liệu thuộc tính cha
			mapper.CreateMap<AppRole, RoleDeleteVM>();
		});

		public static MapperConfiguration CategoryNewsConf = new(mapper =>
		{
			mapper.CreateMap<AppCategoryNews, ListItemCategoryNewsVM>();
		});

		public static MapperConfiguration NewsConf = new(mapper =>
		{
			mapper.CreateMap<AppNews, ListItemNewsVM>().ReverseMap();

			mapper.CreateMap<AppNews, ListNewsVM>().ReverseMap();
		});

		public static MapperConfiguration PolicyConf = new(mapper =>
		{
			mapper.CreateMap<AppPolicy, ListItemPolicyVM>();
		});

		public static MapperConfiguration ContactConf = new(mapper =>
		{
			mapper.CreateMap<AppContact, ListItemContactVM>();
		});

		public static MapperConfiguration ProductCategoryConf = new(mapper =>
		{
			mapper.CreateMap<AppProductCategory, ListItemProductCategoryVM>().ReverseMap();
		});

		public static MapperConfiguration SliderConf = new(mapper =>
		{
			mapper.CreateMap<AppSlider, ListItemSliderVM>().ReverseMap();
		});
	}
}
