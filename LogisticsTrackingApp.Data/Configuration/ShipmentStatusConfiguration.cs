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
	public class ShipmentStatusConfiguration : IEntityTypeConfiguration<ShipmentStatus>
	{
		public void Configure(EntityTypeBuilder<ShipmentStatus> builder)
		{
			builder.ToTable("ShipmentStatuses");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.Status).IsRequired().HasMaxLength(20);
			
		}
	}
}
