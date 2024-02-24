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
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable("Customer");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.FullName).IsRequired().HasMaxLength(20);
			builder.Property(x => x.City).IsRequired().HasMaxLength(20);
		}
	}
}
