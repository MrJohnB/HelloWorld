using System;
using System.Text;
using System.Linq;
using HelloWorld.Services;
using HelloWorld.Domain;
using HelloWorld.Configuration;

namespace HelloWorld
{
	/// <summary>
	/// This is a demo Hello World app
	/// </summary>
	public class Program
	{
		public static void Main(string[] args)
		{
			// Get app settings from config file
			var settings = HelloWorldConfigurationManager.GetConfigurationSettings();
			
			// Start the timer (for the report run-time)
			var timerStart = DateTime.Now;

			// Build file path
			var fileNameAndPath = System.IO.Path.Combine(settings.FilePath, settings.FileName);

			var helloWorldRecord = new HelloWorldRecord()
			{
				Id = 2,
				RepositoryType = Common.RepositoryType.CsvFile,
				FileNameAndPath = fileNameAndPath,
				ConnectionString = settings.ConnectionString
			};

			var findHelloWorldService = new FindHelloWorldService();

			var findHelloWorldServiceResponse = findHelloWorldService.Find(helloWorldRecord);

			var message = new StringBuilder();

			//////////////////////
			// WRITE MESSAGE
			//////////////////////

			// Check for errors
			if (!findHelloWorldServiceResponse.Success)
			{
				message.AppendLine(findHelloWorldServiceResponse.ErrorMessage);
			}
			else
			{
				// Get first result
				var result = findHelloWorldServiceResponse.Result.First();

				// Get contents
				var contents = result.Contents;

				message.AppendLine(contents);
			}

			// Add a blank line
			message.AppendLine();

			// Display run-time
			var timeElapsed = DateTime.Now - timerStart;
			message.AppendLine(string.Format("(Time elapsed: {0:mm} minutes {1:ss} seconds)", timeElapsed, timeElapsed));

			// Display message
			Console.WriteLine(message.ToString());

			Console.ReadLine();
		}
	}
}
