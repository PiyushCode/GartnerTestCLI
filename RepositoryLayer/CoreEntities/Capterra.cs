using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.CoreEntities
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		public string Tags { get; set; }

		public string Name { get; set; }

		public string Twitter { get; set; }

		public string SiteName { get; set; }
	}
}
