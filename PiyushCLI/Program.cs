using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Abstraction;
using RepositoryLayer.DBContext;
using RepositoryLayer.Implementation;
using ServiceLayer.Abstract;
using ServiceLayer.Implementation;
using System.Threading.Tasks;

namespace PiyushCLI
{

	class Program
	{
		/// <summary>
		/// Application entry point main class
		/// </summary>
		/// <param name="args"></param>
		static async Task Main(string[] args)
		{
			// Create service collection and configure our services
			var services = ConfigureServices();
			// Generate a provider
			var serviceProvider = services.BuildServiceProvider();

			// Kick off our actual code
			await serviceProvider.GetService<CLIApplication>().Run(args);


		}

		/// <summary>
		/// Configuring our service: Dependency Injection
		/// </summary>
		/// <returns></returns>
		private static IServiceCollection ConfigureServices()
		{
			IServiceCollection services = new ServiceCollection();
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<IProductRepository, ProductRepository>();
			
			services.AddDbContext<CLIDBContext>();
			// IMPORTANT! Register our application entry point
			services.AddTransient<CLIApplication>();


			return services;
		}
	}
}
