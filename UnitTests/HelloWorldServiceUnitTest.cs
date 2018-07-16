using HelloWorld.Configuration;
using HelloWorld.Domain;
using HelloWorld.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace HelloWorld.UnitTests
{
	/// <summary>
	/// Test getting HelloWorldDisplayData from data sources
	/// </summary>
	[TestClass]
    public class HelloWorldServiceUnitTest
	{
		// Configuration
		
		private HelloWorldSettings _settings;
		private bool _displayInDebugWindow = true;

		// Data
		private int _id = 2;
		private FindHelloWorldService _findHelloWorldService;

		public HelloWorldServiceUnitTest()
		{
			// Instantiate classes

			// Get app settings from config file
			_settings = HelloWorldConfigurationManager.GetConfigurationSettings();

			_findHelloWorldService = new FindHelloWorldService();
		}

		[TestMethod]
        public void Check_Hello_World_Data_Csv_Access()
        {
			// Build file path
			var fileNamePath = System.IO.Path.Combine(_settings.FilePath, _settings.FileName);

			// Build search metadata
			var helloWorldRecord = new HelloWorldRecord()
			{
				Id = 2,
				RepositoryType = Common.RepositoryType.CsvFile,
				FileNameAndPath = fileNamePath,
			};

			// Get service response
			var findHelloWorldServiceResponse = _findHelloWorldService.Find(helloWorldRecord);

			// Check for error
			if (!findHelloWorldServiceResponse.Success)
				Assert.Fail(findHelloWorldServiceResponse.ErrorMessage);

			// Get first result
			var result = findHelloWorldServiceResponse.Result.First();

			// Get contents
			var contents = result.Contents;

			if (_displayInDebugWindow)
			{
				// Format data for Debug Window or CSV file
				Debug.WriteLine(contents);
			}

			Assert.AreEqual("Hello World Message!", contents);
		}

		[TestMethod]
		public void Check_Hello_World_Data_Sql_Access()
		{
			// Build search metadata
			var helloWorldRecord = new HelloWorldRecord()
			{
				Id = 2,
				RepositoryType = Common.RepositoryType.SqlDatabase,
				ConnectionString = _settings.ConnectionString,
			};

			// Get service response
			var findHelloWorldServiceResponse = _findHelloWorldService.Find(helloWorldRecord);

			// Check for error
			if (!findHelloWorldServiceResponse.Success)
				Assert.Fail(findHelloWorldServiceResponse.ErrorMessage);

			// Get first result
			var result = findHelloWorldServiceResponse.Result.First();

			// Get contents
			var contents = result.Contents;

			if (_displayInDebugWindow)
			{
				// Format data for Debug Window or CSV file
				Debug.WriteLine(contents);
			}

			Assert.AreEqual("Hello World Message!", contents);
		}
	}
}
