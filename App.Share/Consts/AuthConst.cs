using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Share.Consts
{
	public static class AuthConst
	{
		public const int NO_PERMISSION					= -1;
		public static class AppUser
		{
			public const int VIEW_LIST					= 1001;
			public const int VIEW_DETAIL				= 1002;
			public const int CREATE						= 1003;
			public const int UPDATE						= 1004;
			public const int UPDATE_PWD					= 1005;
			public const int BLOCK						= 1006;
			public const int UNBLOCK					= 1007;
			public const int DELETE						= 1008;
		}

		public static class AppRole
		{
			public const int VIEW_LIST					= 1101;
			public const int VIEW_DETAIL				= 1102;
			public const int CREATE						= 1103;
			public const int UPDATE						= 1104;
			public const int DELETE						= 1105;
		}

		public static class FileManager
		{
			public const int MANAGE_ALL_USER_FILES		= 1205;
		}
		public static class AppNews
        {
			public const int VIEW_LIST = 1301;
			public const int CREATE = 1302;
			public const int UPDATE = 1303;
			public const int DELETE = 1304;
			public const int PUBLIC = 1305;
			public const int UNPUBLIC = 1306;
			public const int SENDMAILREGISTER = 1307;
		}
		public static class AppCategoryNews
		{
			public const int VIEW_LIST = 1401;
			public const int CREATE = 1402;
			public const int UPDATE = 1403;
			public const int DELETE = 1404;
		}
		public static class AppPolicy
		{
			public const int VIEW_LIST = 1501;
			public const int CREATE = 1502;
			public const int UPDATE = 1503;
			public const int DELETE = 1504;
			public const int DETAILS = 1505;
		}
		public static class AppContact
		{
			public const int VIEW_LIST = 1601;
			public const int DELETE = 1602;
		}
		public static class AppProductCategory
		{
			public const int VIEW_LIST = 1701;
			public const int CREATE = 1702;
			public const int UPDATE = 1703;
			public const int DELETE = 1704;
		}
		public static class AppSlider
		{
			public const int MANAGE_SLIDER = 1801;
		}
	}
}
