using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiyushCLI.Utils
{
	public static class CommandValidator
	{
		public static bool IsCommandValid(string[] command)
		{
			List<string> commands = command == null && command.Count() < 1 ? null : command.ToList();
			int commandCount = command == null && command.Count() < 1 ? 0 : command.Count();

			if (commands == null) 
			{
				Console.WriteLine("Please enter a valid command to proceed.");		
				return false;
			}
			
			if (commandCount == 1 && commands[0].ToLower() != "import")
			{
				Console.WriteLine($"{commands[0]} is not recognized as a valid command, please try : import [sitename] [filelocation]");				
				return false;
			}
			else if(commandCount == 1 && commands[0].ToLower() == "import")
			{
				Console.WriteLine("Welcome to Import CLI by Piyush, you can import data of different sites in this by using this CLI");
				Console.WriteLine("To know how to use it please use: import --help");
				return true;				
			}

			if (commandCount == 2 && commands[0].ToLower() == "import" && commands[1].ToLower() == "--help")
			{
				Console.WriteLine("import capterra [filepath] : To import data of Capterra");
				Console.WriteLine("import softwareadvice [filepath] : To import data of Softwareadvice");

				return true;
			}

			if(commandCount == 3 && (commands[1].ToLower() != "capterra" || commands[1].ToLower() != "capterra"))
			{
				Console.WriteLine($"{commands[1]} is not recognized as a valid command, please try : import --help for more details");
				return false;
			}

			if (commandCount == 3 && (commands[1].ToLower() == "capterra" || commands[1].ToLower() == "capterra") &&  string.IsNullOrEmpty(commands[2]))
			{
				Console.WriteLine("Please provide a valid file path");
				return false;
			}


			return true;
		}
	}
}
