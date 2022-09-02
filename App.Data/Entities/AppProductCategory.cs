using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
	public class AppProductCategory : AppEntityBase
	{
		public AppProductCategory()
		{
			ProductCategoryNavigation = new HashSet<AppProductCategory>();
		}
		public string Name { get; set; }
		public int CateLevel { get; set; }
		public bool HasChild { get; set; }
		public string? Content { get; set; }
		public string? CoverImgPath { get; set; }
		public string? StampPath { get; set; }
		public int? ParentCateId { get; set; }
		public AppProductCategory ProductCategory { get; set; }
		public ICollection<AppProductCategory> ProductCategoryNavigation { get; set; }
	}
}
