using System.Linq;

namespace PiyushCLI.Utils
{
	public static class FilePathResolver
	{
		public static string ResolveFilePath(string[] args)
		{
			if(args.Count() == 3)
			{
				return args[2];
			}

			if(args.Count() > 3)
			{
				var filePathList = args.Skip(2).ToList();
				string Path = string.Join(" ", filePathList);
				return Path;
			}
			return "";
		}
	}
}
