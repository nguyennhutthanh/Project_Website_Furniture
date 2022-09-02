using System;

namespace App.Web.Areas.Admin.ViewModels.News
{
	public class ListItemNewsVM : SEOEntityBaseVM
	{
		public string Title { get; set; }
		public string Slug { get; set; }
		public string? Summary { get; set; }
		public string? Content { get; set; }
		public long Views { get; set; }
		public float Votes { get; set; }
		public bool Published { get; set; }
		public DateTime? PublishedAt { get; set; }
		public string? CoverImgPath { get; set; }
		public string? CoverImgThumbnailPath { get; set; }
		public string? StampPath { get; set; }
	}
}
