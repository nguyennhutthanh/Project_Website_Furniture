using App.Share.Attributes;
using App.Share.Consts;
using App.Web.WebConfig.Consts;

namespace App.Web.Areas.Admin.ViewModels.ProductCategory
{
	public class AddOrUpdateProductCategoryVM
	{
		public int Id { get; set; }
		[AppRequired]
		[AppStringLength(VM.ProductCategoryVM.MIN_LENGTH, DB.AppProductCategory.LENGTH_CATEGORY)]
		public string Name { get; set; }
		public string? Content { get; set; }
		public string? CoverImgPath { get; set; }
		public string? StampPath { get; set; }
		public int? ParentCateId { get; set; }

	}
}
