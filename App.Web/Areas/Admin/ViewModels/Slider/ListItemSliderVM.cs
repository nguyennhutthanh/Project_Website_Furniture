using System;

namespace App.Web.Areas.Admin.ViewModels.Slider
{
	public class ListItemSliderVM : ListItemBaseVM
	{
		public string ImagePath { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public string Link { get; set; }
	}
}
