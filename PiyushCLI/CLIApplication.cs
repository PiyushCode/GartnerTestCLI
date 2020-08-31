using PiyushCLI.Utils;
using ServiceLayer.Abstract;
using System;
using System.Threading.Tasks;

namespace PiyushCLI
{
	public class CLIApplication
	{
		private readonly IProductService _productService;

		public CLIApplication(IProductService productService)
		{
			_productService = productService;
		}

		/// <summary>
		/// Entry point method
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public async Task<bool> Run(string[] args)
		{
			try
			{
				//Checking for command validation
				var validationCheck = CommandValidator.IsCommandValid(args);
				if (validationCheck)
				{
					//Site type checks
					if (args[1] == Constant.Capterra)
					{
						await _productService.AddCapterraProductsAsync(FilePathResolver.ResolveFilePath(args));
					}

					if (args[1] == Constant.Softwareadvice)
					{
						await _productService.AddSoftwareAdviceProductsAsync(FilePathResolver.ResolveFilePath(args));
					}
				}

				return true;
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid Operation, please try again with valid commands");
				return false;
			}
			

		}
	}
}
