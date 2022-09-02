using System;

namespace App.Web.Areas.Admin.ViewModels.Slider
{
	public class AddOrUpdateSliderVM
	{
		public int Id { get; set; }
		public string ImagePath { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public string Link { get; set; }
	}
}
