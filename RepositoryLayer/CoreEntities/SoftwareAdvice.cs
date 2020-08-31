using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.CoreEntities
{
	public class SoftwareAdvice
	{
		[Key]
		public int Id { get; set; }
		public CategoryInfo Products { get; set; }

		[ForeignKey("Products")]
		public int CategoryKey { get; set; }
	}

	public class CategoryInfo
	{
		[Key]
		public int Id { get; set; }
		public string Categories { get; set; }

		public string Twitter { get; set; }

		public string Title { get; set; }
	}
}
