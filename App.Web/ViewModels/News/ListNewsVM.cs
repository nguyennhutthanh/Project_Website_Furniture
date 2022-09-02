using App.Web.Areas.Admin.ViewModels;
using System;

namespace App.Web.ViewModels.News
{
	public class ListNewsVM : SeoBaseVM
	{
		public string Title { get; set; }
		public string Slug { get; set; }
		public string? Summary { get; set; }
		public string? Content { get; set; }
		public long Views { get; set; }
		public float Votes { get; set; }
		public bool Published { get; set; }
		public DateTime? PublishedAt { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string? CoverImgPath { get; set; }
	}
}
