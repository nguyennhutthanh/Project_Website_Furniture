using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities.Base
{
	public abstract class AppSEOBase : AppEntityBase
	{
		public string SEOTitle { get; set; }
		public string SEODescription { get; set; }
		public string SEOKeyword { get; set; }
		public string SEOImagePath { get; set; }
	}
}
