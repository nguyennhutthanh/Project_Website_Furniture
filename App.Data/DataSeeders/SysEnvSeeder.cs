using App.Data.Entities;
using App.Share.Consts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataSeeders
{
	public static class SysEnvSeeder
	{

		public static void SeedData(this EntityTypeBuilder<SysEnv> builder)
		{
			builder.HasData(
				new SysEnv
				{
					Key = SysEnvConst.LOGO,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.BRAND_NAME,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.BRAND_ADDRESS,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.BRAND_PHONE,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.FACEBOOK,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.ZALO,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.MESSENGER_EMBEDDED_CODE,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.EMBEDDED_MAP,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.ADMIN_RECIVER_MAIL,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.KIOT_VIET_CLIENT_ID,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.KIOT_VIET_CLIENT_SECRET_KEY,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.YOUTUBE,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.PRIMARY_MAIL,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.SECONDARY_MAIL,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.VIDEO_YOUTUBE,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.SEO_TITLE,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.SEO_DESCRIPTION,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.SEO_KEYWORD,
					Value = ""
				},
				new SysEnv
				{
					Key = SysEnvConst.SEO_IMAGEPATH,
					Value = ""
				});
		}
	}
}
