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
	public class AboutConfiguration : IEntityTypeConfiguration<About>
	{
		public void Configure(EntityTypeBuilder<About> builder)
		{
			builder.ToTable("Abouts");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.Title).IsRequired().HasMaxLength(20);
			builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
			
		}
	}
}
