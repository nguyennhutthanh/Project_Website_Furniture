using App.Share.Attributes;
using App.Web.WebConfig.Consts;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Areas.Admin.ViewModels.Account
{
    public class ForgotPassword
	{
		[DataType(DataType.Password)]
		[AppRequired]
		[AppMinLength(VM.UserVM.PWD_MINLEN)]
		public string NewPwd { get; set; }

		[DataType(DataType.Password)]
		[AppConfirmPwd("NewPwd")]
		public string ConfirmPassword { get; set; }
	}
}
