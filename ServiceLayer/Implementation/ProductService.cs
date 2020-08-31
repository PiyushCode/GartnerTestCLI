using Newtonsoft.Json;
using RepositoryLayer.Abstraction;
using RepositoryLayer.CoreEntities;
using ServiceLayer.Abstract;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ServiceLayer.Implementation
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		/// <summary>
		/// Method to add capterra product only from a filepath provided
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public async Task<bool> AddCapterraProductsAsync(string filePath)
		{
			List<Product> products = new List<Product>();
			var deserializer = new DeserializerBuilder()
					 .WithNamingConvention(new CamelCaseNamingConvention())
					 .Build();

			var result = deserializer.Deserialize<List<CapterraRequest>>(File.OpenText(path:filePath));
			foreach (var product in result)
			{
				//Converting the request model into core entities
				//Note: We can also use automapper here
				products.Add(new Product() {
					Name = product.Name,
					Tags = product.Tags,
					SiteName = "capterra",
					Twitter = product.Twitter
				});
				Console.WriteLine($"importing: Name: {product.Name};  Categories: {product.Tags}; Twitter: {product.Twitter}");
			}
			await _productRepository.AddProductsAsync(products);
			return true;
		}

		/// <summary>
		/// Method to add software advice product from a filepath provided
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public async Task<bool> AddSoftwareAdviceProductsAsync(string filePath)
		{
			SoftwareAdviceRequest obj = new SoftwareAdviceRequest();
			List<Product> products = new List<Product>();
			using (StreamReader r = new StreamReader(path:filePath))
			{
				string json = r.ReadToEnd();
				obj = JsonConvert.DeserializeObject<SoftwareAdviceRequest>(json);
			}

			foreach (var product in obj.Products)
			{
				//Converting the request model into core entities
				//Note: We can also use automapper here
				products.Add(new Product() {
					Name = product.Title,
					SiteName = "softwareadvice",
					Twitter = product.Twitter ?? "NA",
					Tags = string.Join(",", product.Categories) 
				});
				Console.WriteLine($"importing: Name: {product.Title};  Categories: {string.Join(",", product.Categories)}; Twitter: {product.Twitter ?? "NA"}");
			}

			await _productRepository.AddProductsAsync(products);

			return true;
		}
	}
}
