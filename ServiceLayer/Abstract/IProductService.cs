using ServiceLayer.Models;
using System.Threading.Tasks;

namespace ServiceLayer.Abstract
{
	public interface IProductService
	{
		Task<bool> AddCapterraProductsAsync(string filePath);

		Task<bool> AddSoftwareAdviceProductsAsync(string filePath);
	}
}
