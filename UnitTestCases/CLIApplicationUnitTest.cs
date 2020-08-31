using Moq;
using PiyushCLI;
using ServiceLayer.Abstract;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestCases
{
	public class CLIApplicationUnitTest
	{
		private readonly Mock<IProductService> _mockProductService;
		private readonly CLIApplication _cLIApplication;
		
		public CLIApplicationUnitTest()
		{
			_mockProductService = new Mock<IProductService>();
			_cLIApplication = new CLIApplication(_mockProductService.Object);
		}

		[Fact]
		public async Task CLIApplicationTest_for_capterra_success()
		{
			//Arrange
			string[] args = new string[] { "import", "capterra", "adc.csv" };

			//Act
			var response = await _cLIApplication.Run(args);

			//Assert
			Assert.True(response);
		}


		[Fact]
		public async Task CLIApplicationTest_for_softwareadvice_success()
		{
			//Arrange
			string[] args = new string[] { "import", "softwareadvice", "adc.json" };

			//Act
			var response = await _cLIApplication.Run(args);

			//Assert
			Assert.True(response);
		}
	}
}
