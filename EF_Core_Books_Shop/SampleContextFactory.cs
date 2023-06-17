using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop
{
	internal class SampleContextFactory : IDesignTimeDbContextFactory<DbApplicationContext>
	{
		public DbApplicationContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<DbApplicationContext>();
			var Configuration = new ConfigurationBuilder().AddUserSecrets<DbApplicationContext>().Build();
			var GetConnection = Configuration.GetConnectionString("EFConnection");
			var options = optionsBuilder.UseSqlServer(GetConnection).Options;
			return new DbApplicationContext(optionsBuilder.Options);
		}
	}
}
