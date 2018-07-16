using HelloWorld.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HelloWorld.Repositories.Csv
{
	/// <summary>
	/// Defines the structure of a Hello World Display Data entity Find repository
	/// </summary>
	public class HelloWorldDisplayDataCsvRepository : IFindHelloWorldDataRepository
	{
		private readonly string _fileNamePath;
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="fileNamePath">File name full path string</param>
		public HelloWorldDisplayDataCsvRepository(string fileNamePath)
		{
			_fileNamePath = fileNamePath;
		}

		/// <summary>
		/// Find a fully populated list of HelloWorldDisplayData by id
		/// </summary>
		/// <param name="id">record id</param>
		/// <returns>HelloWorldDisplayData collection, or error</returns>
		public IEnumerable<HelloWorldDisplayData> Find(int id)
		{
			// If file name path is blank, return empty list
			if (string.IsNullOrWhiteSpace(_fileNamePath))
				return Enumerable.Empty<HelloWorldDisplayData>();

			// If file doesn't exist, return empty list
			if (!File.Exists(_fileNamePath))
				return Enumerable.Empty<HelloWorldDisplayData>();

			var result = new List<HelloWorldDisplayData>();

			using (var reader = new StreamReader(_fileNamePath))
			{
				var isHeaderRow = true;

				var columns = new Dictionary<string, int>();

				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');

					if (isHeaderRow)
					{
						columns = GetColumnIndexes(values);
						isHeaderRow = false;
					}
					else
					{
						// Map result
						var mapper = new HelloWorldDisplayDataCsvMapper();
						result.Add(mapper.Map(values, columns));
					}
				}
			}

			// Return the result
			return result;
		}

		/// <summary>
		/// Builds dictionary of column indexes from column names
		/// </summary>
		/// <param name="columnNames">Header column names in Csv file</param>
		/// <returns>Dictionary of column names and indexes</returns>
		private Dictionary<string, int> GetColumnIndexes(IEnumerable<string> columnNames)
		{
			var columns = new Dictionary<string, int>();

			var columnIndex = 0;

			foreach (var columnName in columnNames)
			{
				switch (columnName)
				{
					case CsvTokens.id:
						columns.Add(CsvTokens.id, columnIndex);
						break;
					case CsvTokens.contents:
						columns.Add(CsvTokens.contents, columnIndex);
						break;
				}

				columnIndex++;
			}

			return columns;
		}
	}
}
