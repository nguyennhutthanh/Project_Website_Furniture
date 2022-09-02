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
	public class AppEmailSubscriberConfig : IEntityTypeConfiguration<AppEmailSubscriber>
	{
		public void Configure(EntityTypeBuilder<AppEmailSubscriber> builder)
		{
			builder.ToTable(DB.AppEmailSubcriber.TABLE_NAME);

			builder.HasKey(s => s.Id);

			builder.Property(s => s.Id)
				.UseIdentityColumn();

			builder.Property(s => s.Email)
				.IsRequired();
		}
	}
}
