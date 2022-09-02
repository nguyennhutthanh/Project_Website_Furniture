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
	public class AppProductCategoryConfig : IEntityTypeConfiguration<AppProductCategory>
	{
		public void Configure(EntityTypeBuilder<AppProductCategory> builder)
		{
			builder.ToTable(DB.AppProductCategory.TABLE_NAME);

			builder.HasKey(s => s.Id);

			builder.Property(s => s.Id)
				.UseIdentityColumn();

			builder.Property(s => s.Name)
				.HasMaxLength(DB.AppProductCategory.LENGTH_CATEGORY)
				.IsRequired();

			builder.Property(s => s.CateLevel)
				.HasMaxLength(DB.AppProductCategory.LENGTH_LEVEL)
				.HasDefaultValue(1);

			builder.Property(s => s.HasChild)
				.HasDefaultValue(DB.AppProductCategory.DEFAULT_VALUE);

			builder.HasOne(s => s.ProductCategory)
				.WithMany(s => s.ProductCategoryNavigation)
				.HasForeignKey(s => s.ParentCateId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Property(s => s.Content)
				.HasMaxLength(DB.AppProductCategory.DEFAULT_CONTENT);
		}
	}
}
