using App.Share.Consts;
using App.Web.WebConfig.Consts;
using App.Share.Attributes;
using System;

namespace App.Web.Areas.Admin.ViewModels.CategoryNews
{
    public class AddOrUpdateCategoryNewsVM
	{
		public int Id { get; set; }

		[AppRequired]
		[AppStringLength(VM.CategoryNewsVM.MIN_LENGTH, DB.AppCategoryNews.MAX_LENGTH)]
		public string Title { get; set; }
		[AppStringLength(VM.CategoryNewsVM.MIN_LENGTH, DB.AppCategoryNews.MAX_LENGTH)]
		public string? Content { get; set; }
		public string? CoverImgPath { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}
