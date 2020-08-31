using RepositoryLayer.Abstraction;
using RepositoryLayer.CoreEntities;
using RepositoryLayer.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Implementation
{
	/// <summary>
	/// Product repository class :: Note - We can use generic repository also in case of multiple entities
	/// </summary>
	public class ProductRepository : IProductRepository
	{
		private readonly CLIDBContext _cLIDBContext;
		public ProductRepository(CLIDBContext cLIDBContext)
		{
			_cLIDBContext = cLIDBContext;
		}

		/// <summary>
		/// Add multiple products
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		public async Task<bool> AddProductsAsync(List<Product> products)
		{
			await _cLIDBContext.AddRangeAsync(products);
			await _cLIDBContext.SaveChangesAsync();
			return true;
		}

		/// <summary>
		/// Add single product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public async Task<bool> AddProductsAsync(Product product)
		{
			await _cLIDBContext.AddAsync(product);
			await _cLIDBContext.SaveChangesAsync();
			return true;
		}
	}
}
