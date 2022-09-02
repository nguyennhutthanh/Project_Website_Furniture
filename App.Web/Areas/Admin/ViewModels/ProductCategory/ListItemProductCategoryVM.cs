using App.Data.Entities;
using System.Collections.Generic;

namespace App.Web.Areas.Admin.ViewModels.ProductCategory
{
	public class ListItemProductCategoryVM : ListItemBaseVM
	{
		public string Name { get; set; }
		public int CateLevel { get; set; }
		public bool HasChild { get; set; }
		public string? CoverImgPath { get; set; }
		public string? StampPath { get; set; }
		public int? ParentCateId { get; set; }
		public ICollection<ListItemProductCategoryVM> ProductCategoryNavigation { get; set; }
	}
}
