﻿using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
	public class AppEmailSubscriber : AppEntityBase
	{
		public string  Email { get; set; }
	}
}
