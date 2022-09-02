using App.Data.Entities;
using App.Share.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Configurations
{
	public class AppSliderConfig : IEntityTypeConfiguration<AppSlider>
	{
		public void Configure(EntityTypeBuilder<AppSlider> builder)
		{
			builder.ToTable(DB.AppSlider.TABLE_NAME);

			// Khóa chính
			builder.HasKey(m => m.Id);

			builder.Property(m => m.ImagePath)
				.HasMaxLength(DB.AppSlider.IMAGE_PATH_LENGTH);
			builder.Property(m => m.Link)
				.HasMaxLength(DB.AppSlider.LINK);
		}
	}
}
