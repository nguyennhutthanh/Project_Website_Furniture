using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
	public class AppSlider : AppEntityBase
	{
		public string ImagePath { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public string Link { get; set; }
	}
}
