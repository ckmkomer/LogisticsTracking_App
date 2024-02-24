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
	public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
	{
		public void Configure(EntityTypeBuilder<Vehicle> builder)
		{
			builder.ToTable("Vehicles");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.Model).IsRequired().HasMaxLength(30);
			builder.Property(x => x.Brand).IsRequired().HasMaxLength(30);
		}
	}
}
