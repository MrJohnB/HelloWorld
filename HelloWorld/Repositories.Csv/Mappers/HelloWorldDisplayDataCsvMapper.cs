using HelloWorld.Domain;
using System.Collections.Generic;

namespace HelloWorld.Repositories.Csv
{
	/// <summary>
	/// Mapper for Hello World Display Data entity (from CSV file)
	/// </summary>
	public class HelloWorldDisplayDataCsvMapper
	{
		/// <summary>
		/// Maps the Csv file fields to the properties in a HelloWorldDisplayData instance
		/// </summary>
		/// <param name="fields">Cells in the Csv file</param>
		/// <param name="columns">Dictionary of column names and indexes</param>
		/// <returns>HelloWorldDisplayData entity</returns>
		public HelloWorldDisplayData Map(string[] fields, Dictionary<string, int> columns)
		{
			// Define result
			var result = new HelloWorldDisplayData();

			var idValue = int.MinValue;
			if (int.TryParse(fields[columns[CsvTokens.id]], out idValue))
			{
				result.Id = idValue;
			}

			result.Contents = fields[columns[CsvTokens.contents]];

			return result;
		}
	}
}