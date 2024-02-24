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
	public class ReturnConfiguration : IEntityTypeConfiguration<Return>
	{
		public void Configure(EntityTypeBuilder<Return> builder)
		{
			builder.ToTable("Returns");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

		
		}
	}
}
