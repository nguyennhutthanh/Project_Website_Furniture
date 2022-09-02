using App.Share.Consts;
using App.Web.WebConfig.Consts;
using App.Share.Attributes;

namespace App.Web.Areas.Admin.ViewModels.News
{
    public class AddOrUpdateNewsVM : SEOEntityBaseVM
	{
		public int Id { get; set; }
		[AppRequired]
		[AppStringLength(VM.CategoryNewsVM.MIN_LENGTH, DB.AppNews.MAX_LENGTH)]
		public string Title { get; set; }
		[AppStringLength(VM.CategoryNewsVM.MIN_LENGTH, DB.AppNews.MAX_LENGTH)]
		public string? Summary { get; set; }
		public string? Content { get; set; }
		[AppRequired]
		public int CategoryId { get; set; }
		[AppRequired]
		public string? CoverImgPath { get; set; }
		public string? CoverImgThumbnailPath { get; set; }
		public string? StampPath { get; set; }
		public bool SendAllEmail { get; set; }
	}
}
