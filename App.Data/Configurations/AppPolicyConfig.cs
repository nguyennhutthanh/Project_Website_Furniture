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
	public class AppPolicyConfig : IEntityTypeConfiguration<AppPolicy>
	{
		public void Configure(EntityTypeBuilder<AppPolicy> builder)
		{
			builder.ToTable(DB.AppPolicy.TABLE_NAME);

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.UseIdentityColumn();

			builder.Property(x => x.Title)
				.HasMaxLength(DB.AppPolicy.MAX_LENGTH)
				.IsRequired();

			builder.Property(x => x.Like)
				.HasDefaultValue(DB.AppPolicy.LIKE_DEFAULT_VALUE);

			builder.Property(x => x.Slug)
				.IsRequired();

			builder.HasOne(x => x.Users)
				.WithMany(x => x.AppPolicyNavigation)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
