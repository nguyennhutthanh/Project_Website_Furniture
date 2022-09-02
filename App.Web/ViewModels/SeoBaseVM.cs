using App.Web.Areas.Admin.ViewModels;

namespace App.Web.ViewModels
{
	public class SeoBaseVM : ListItemBaseVM
	{
		public string SEOTitle { get; set; }
		public string SEODescription { get; set; }
		public string SEOKeyword { get; set; }
		public string SEOImagePath { get; set; }
	}
}
