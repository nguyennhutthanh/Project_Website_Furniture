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
	public class AppContactConfig : IEntityTypeConfiguration<AppContact>
	{
		public void Configure(EntityTypeBuilder<AppContact> builder)
		{
			builder.ToTable(DB.AppContact.TABLE_NAME);

			builder.HasKey(s => s.Id);

			builder.Property(s => s.Id)
				.UseIdentityColumn();

			builder.Property(s => s.FullName)
				.HasMaxLength(DB.AppContact.MAX_LENGTH)
				.IsRequired();

			builder.Property(s => s.Email)
				.HasMaxLength(DB.AppContact.MAX_LENGTH)
				.IsRequired();

			builder.Property(s => s.PhoneNumber)
				.HasMaxLength(DB.AppContact.PHONE_LENGTH)
				.IsRequired();

			builder.Property(s => s.Content)
			.HasMaxLength(DB.AppContact.MAX_LENGTH)
			.IsRequired();
		}
	}
}
