using App.Share.Consts;
using App.Web.WebConfig.Consts;
using App.Share.Attributes;

namespace App.Web.Areas.Admin.ViewModels.Policy
{
    public class AddOrUpdatePolicyVM
	{
		public int Id { get; set; }
		[AppRequired]
		[AppStringLength(VM.PolicyVM.MIN_LENGTH, DB.AppPolicy.MAX_LENGTH)]
		public string Title { get; set; }
		public string? Content { get; set; }
		public string? CoverImgPath { get; set; }
		public string? CoverImgThumbnailPath { get; set; }
	}
}
