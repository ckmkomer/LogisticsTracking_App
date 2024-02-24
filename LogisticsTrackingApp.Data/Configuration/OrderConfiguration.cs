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
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(20);
			builder.Property(x => x.OrderNumber).IsRequired().HasMaxLength(100);
		}
	}
}
