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
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.ToTable("Contacts");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.FullName).IsRequired().HasMaxLength(20);
			builder.Property(x => x.Message).IsRequired().HasMaxLength(120);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(30);
		}
	}
}
