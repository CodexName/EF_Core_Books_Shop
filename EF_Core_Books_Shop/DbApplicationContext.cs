using EF_Core_Books_Shop.DataObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop
{
	public  class DbApplicationContext : DbContext
	{
		public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options)
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Author> Authors { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var Configuration = new ConfigurationBuilder().AddUserSecrets<DbApplicationContext>().Build();
			var GetConnection = Configuration.GetConnectionString("EFConnection");
			var options = optionsBuilder.UseSqlServer(GetConnection).Options;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().HasMany(x => x.Clients).WithMany(x => x.Books);
			modelBuilder.Entity<Client>().HasMany(x => x.Books).WithMany(x => x.Clients);
			modelBuilder.Entity<Order>().HasMany(x => x.Clients).WithMany(x => x.Orders);
			modelBuilder.Entity<Author>().HasMany(x => x.Books).WithMany(x => x.Authors);
		}
	}
}
