using Microsoft.EntityFrameworkCore;
using RepositoryLayer.CoreEntities;

namespace RepositoryLayer.DBContext
{
	/// <summary>
	/// DB COntext class for MYSQL
	/// </summary>
	public class CLIDBContext : DbContext
	{
		/// <summary>
		/// DB set properties which will going to be converted into DB tables
		/// </summary>
		public DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//Passing DB connection string in configuration
			//NOTE: We can put the connection string inside appsetting.json also in full fledge  application
			optionsBuilder.UseMySQL("server=localhost;database=CLIDB;user=user;password=password");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			base.OnModelCreating(modelBuilder);
		}
	}
}
