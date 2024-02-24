using LogisticsTrackingApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Data.Context
{
	public class LogisticsDbContext : DbContext
	{
		public LogisticsDbContext(DbContextOptions options) : base(options)
		{
		}

		
		public DbSet<About> Abouts { get; set; }
		public DbSet<Customer> Customers { get; set; }

		public DbSet<Adress> Adresses { get; set; }

		public DbSet<Contact> Contacts { get; set; }

		public DbSet<ContactUs> ContactUs { get; set; }
		public DbSet<Return> Returns { get; set; }

		public DbSet<Shipment> Shipments { get; set; }

		public DbSet<Station> Stations { get; set; }

		public DbSet<Vehicle> Vehicles { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<ShipmentStatus> ShipmentStatuses { get; set; }


	}
}
