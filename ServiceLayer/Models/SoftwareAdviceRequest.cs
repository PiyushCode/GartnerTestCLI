using System.Collections.Generic;

namespace ServiceLayer.Models
{

	public class SoftwareAdviceRequest
	{
		public List<CategoryInfo> Products { get; set; }

	}

	public class CategoryInfo
	{
		public List<string> Categories { get; set; } 

		public string Twitter { get; set; }

		public string Title { get; set; }
	}

}
