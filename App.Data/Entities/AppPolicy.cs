using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
	public class AppPolicy : AppEntityBase
	{
		public string Title { get; set; }
		public string Slug { get; set; }
		public string? CoverImgPath { get; set; }
		public string? CoverImgThumbnailPath { get; set; }
		public string Content { get; set; }
		public int Like { get; set; }
		public int UserId { get; set; }
		public AppUser Users { get; set; }
	}

}
