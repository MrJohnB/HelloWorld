using System.IO;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Configuration
{
    public class HelloWorldConfigurationManager
    {
		// Set directory and file names
		private static string _directoryPath = Directory.GetCurrentDirectory();
		private static string _configurationFileName = "appsettings.json";

		public static HelloWorldSettings GetConfigurationSettings()
		{
			// Create configuration builder
			var builder = new ConfigurationBuilder()
								.SetBasePath(_directoryPath)
								.AddJsonFile(_configurationFileName, optional: false, reloadOnChange: true);

			// Builds a configuration object
			IConfigurationRoot configuration = builder.Build();

			// Create the settings object
			var settings = new HelloWorldSettings();

			// Bind the config file to the settings object
			configuration.Bind(settings);

			return settings;
		}
	}
}
