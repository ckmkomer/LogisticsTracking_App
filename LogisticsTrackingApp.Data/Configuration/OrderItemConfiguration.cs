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
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable("OrderItems");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.ShipmentName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Price).IsRequired().HasMaxLength(100);
		}
	}
}
