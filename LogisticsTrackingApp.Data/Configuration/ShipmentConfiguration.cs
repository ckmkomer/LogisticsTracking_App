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
	public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
	{
		public void Configure(EntityTypeBuilder<Shipment> builder)
		{
			builder.ToTable("Shipments");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.DeliverDate).IsRequired();
			builder.Property(x => x.TrackingNumber).IsRequired();
			


			builder.HasOne(x => x.Customer).WithMany(x => x.Shipments).HasForeignKey(x => x.CustomerId);
		}
	}
}
