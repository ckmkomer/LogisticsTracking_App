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
	public class StationConfiguration : IEntityTypeConfiguration<Station>
	{
		public void Configure(EntityTypeBuilder<Station> builder)
		{
			builder.ToTable("Stations");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.Location).IsRequired().HasMaxLength(20);
			builder.Property(x => x.Destination).IsRequired().HasMaxLength(100);
		}
	}
}
