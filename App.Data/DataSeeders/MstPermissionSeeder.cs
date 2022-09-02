using App.Data.Entities;
using App.Share.Consts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataSeeders
{
	public static class MstPermissionSeeder
	{
		public static void SeedData(this EntityTypeBuilder<MstPermission> builder)
		{
			var now = new DateTime(year: 2021, month: 11, day: 10);
			var groupName = "";

			#region Data liên quan đến bảng Role
			// Permission liên quan đến bảng AppRole
			groupName = "Quản lý phân quyền";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.AppRole.CREATE,
					Code = "CREATE",
					Table = DB.AppRole.TABLE_NAME,
					GroupName = groupName,
					Desc = "Thêm quyền",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppRole.DELETE,
					Code = "DELETE",
					Table = DB.AppRole.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xóa quyền",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppRole.UPDATE,
					Code = "UPDATE",
					Table = DB.AppRole.TABLE_NAME,
					GroupName = groupName,
					Desc = "Sửa quyền",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppRole.VIEW_DETAIL,
					Code = "VIEW_DETAIL",
					Table = DB.AppRole.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem chi tiết quyền",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppRole.VIEW_LIST,
					Code = "VIEW_LIST",
					Table = DB.AppRole.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem danh sách quyền",
					CreatedDate = now
				}
			);
			#endregion

			#region Data liên quản bảng User
			// Permission liên quan đến bảng AppUser
			groupName = "Quản lý người dùng";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.AppUser.BLOCK,
					Code = "BLOCK",
					Table = DB.AppUser.TABLE_NAME,
					GroupName = groupName,
					Desc = "Khóa người dùng",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppUser.CREATE,
					Code = "CREATE",
					Table = DB.AppUser.TABLE_NAME,
					GroupName = groupName,
					Desc = "Thêm người dùng",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppUser.DELETE,
					Code = "DELETE",
					Table = DB.AppUser.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xóa người dùng",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppUser.UNBLOCK,
					Code = "UNBLOCK",
					Table = DB.AppUser.TABLE_NAME,
					GroupName = groupName,
					Desc = "Mở khóa người dùng",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppUser.UPDATE,
					Code = "UPDATE",
					Table = DB.AppUser.TABLE_NAME,
					GroupName = groupName,
					Desc = "Cập nhật người dùng",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppUser.UPDATE_PWD,
					Code = "UPDATE_PWD",
					Table = DB.AppUser.TABLE_NAME,
					GroupName = groupName,
					Desc = "Đổi mật khẩu",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppUser.VIEW_DETAIL,
					Code = "VIEW_DETAIL",
					Table = DB.AppUser.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem chi tiết người dùng",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppUser.VIEW_LIST,
					Code = "VIEW_LIST",
					Table = DB.AppUser.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem danh sách người dùng",
					CreatedDate = now
				}
			);
			#endregion

			#region Data liên quan đến quản lý file
			// Permission liên quan đến quản lý file
			groupName = "Quản lý file";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.FileManager.MANAGE_ALL_USER_FILES,
					Code = "MANAGER",
					Table = "FileManager",
					GroupName = groupName,
					Desc = "Quản lý file hệ thống",
					CreatedDate = now
				}
			);
			#endregion

			#region Data quản lý tin tức
			groupName = "Quản lý tin tức";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.AppNews.VIEW_LIST,
					Code = "VIEW_LIST",
					Table = DB.AppNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem danh sách bài viết",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppNews.CREATE,
					Code = "CREATE",
					Table = DB.AppNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Thêm bài viết",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppNews.UPDATE,
					Code = "UPDATE",
					Table = DB.AppNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Cập nhật bài viết",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppNews.DELETE,
					Code = "DELETE",
					Table = DB.AppNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xóa bài viết",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppNews.PUBLIC,
					Code = "PUBLIC",
					Table = DB.AppNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Công khai bài viết",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppNews.UNPUBLIC,
					Code = "UNPUBLIC",
					Table = DB.AppNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Gỡ bỏ bài viết",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppNews.SENDMAILREGISTER,
					Code = "SENDMAILREGISTER",
					Table = DB.AppNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Gữi email người đăng ký",
					CreatedDate = now
				}
				);
			#endregion

			#region Data quản lý thể loại tin tức
			groupName = "Quản lý thể loại tin";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.AppCategoryNews.VIEW_LIST,
					Code = "VIEW_LIST",
					Table = DB.AppCategoryNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem danh sách thể loại tin",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppCategoryNews.CREATE,
					Code = "CREATE",
					Table = DB.AppCategoryNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Thêm thể loại bài viết",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppCategoryNews.UPDATE,
					Code = "UPDATE",
					Table = DB.AppCategoryNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Cập nhật thể loại bài viết",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppCategoryNews.DELETE,
					Code = "DELETE",
					Table = DB.AppCategoryNews.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xóa thể loại bài viết",
					CreatedDate = now
				}
				);
			#endregion

			#region Data quản lý chính sách
			groupName = "Quản lý chính sách";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.AppPolicy.VIEW_LIST,
					Code = "VIEW_LIST",
					Table = DB.AppPolicy.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem danh sách các chính sách",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppPolicy.CREATE,
					Code = "CREATE",
					Table = DB.AppPolicy.TABLE_NAME,
					GroupName = groupName,
					Desc = "Thêm chính sách",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppPolicy.UPDATE,
					Code = "UPDATE",
					Table = DB.AppPolicy.TABLE_NAME,
					GroupName = groupName,
					Desc = "Sửa chính sách",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppPolicy.DELETE,
					Code = "DELETE",
					Table = DB.AppPolicy.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xóa chính sách",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppPolicy.DETAILS,
					Code = "DETAILS",
					Table = DB.AppPolicy.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem chi tiết chính sách",
					CreatedDate = now
				}
				);
			#endregion

			#region quản lý liên hệ
			groupName = "Quản lý liên hệ";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.AppContact.VIEW_LIST,
					Code = "VIEW_LIST",
					Table = DB.AppContact.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem danh sách các liên hệ",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppContact.DELETE,
					Code = "DELETE",
					Table = DB.AppContact.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xóa liên hệ",
					CreatedDate = now
				}
				);
			#endregion

			#region quản lý danh mục sản phẩm
			groupName = "Quản lý danh mục sản phẩm";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.AppProductCategory.VIEW_LIST,
					Code = "VIEW_LIST",
					Table = DB.AppProductCategory.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xem danh sách danh mục sản phẩm",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppProductCategory.CREATE,
					Code = "CREATE",
					Table = DB.AppProductCategory.TABLE_NAME,
					GroupName = groupName,
					Desc = "Thêm danh mục sản phẩm",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppProductCategory.UPDATE,
					Code = "UPDATE",
					Table = DB.AppProductCategory.TABLE_NAME,
					GroupName = groupName,
					Desc = "Cập nhật danh mục",
					CreatedDate = now
				},
				new MstPermission
				{
					Id = AuthConst.AppProductCategory.DELETE,
					Code = "DELETE",
					Table = DB.AppProductCategory.TABLE_NAME,
					GroupName = groupName,
					Desc = "Xóa danh mục sản phẩm",
					CreatedDate = now
				}
				);
			#endregion

			#region quản lý slider
			groupName = "Quản lý slider";
			builder.HasData(
				new MstPermission
				{
					Id = AuthConst.AppSlider.MANAGE_SLIDER,
					Code = "MANAGER",
					Table = DB.AppSlider.TABLE_NAME,
					GroupName = groupName,
					Desc = "Quản lý slider",
					CreatedDate= now
				});
			#endregion
		}
	}
}
