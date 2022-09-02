using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
	public class AppContact : AppEntityBase
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string? Content { get; set; }
	}
}
