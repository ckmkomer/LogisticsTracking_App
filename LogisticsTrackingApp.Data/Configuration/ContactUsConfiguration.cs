using LogisticsTrackingApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Data.Configuration
{
	public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
	{
		public void Configure(EntityTypeBuilder<ContactUs> builder)
		{
			builder.ToTable("ContactUs");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
		}
	}
}
