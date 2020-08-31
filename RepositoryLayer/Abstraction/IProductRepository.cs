using RepositoryLayer.CoreEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Abstraction
{
	public interface IProductRepository
	{
		Task<bool> AddProductsAsync(List<Product> products);

		Task<bool> AddProductsAsync(Product product);
	}
}
