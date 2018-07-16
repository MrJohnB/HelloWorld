using HelloWorld.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using HelloWorld.Repositories;
using HelloWorld.Common;
using HelloWorld.Repositories.Sql;
using HelloWorld.Repositories.Csv;

namespace HelloWorld.Services
{
	/// <summary>
	/// Service that gets the merchant account transactions for an event no matter what the Payment Gateway Provider Type
	/// </summary>
    public class FindHelloWorldService
	{
		public FindHelloWorldService()
		{
		}

		/// <summary>
		/// Find a fully populated list of HelloWorldDisplayData by record id
		/// </summary>
		/// <param name="record">HelloWorldRecord entity</param>
		/// <returns>HelloWorldDisplayData collection, or error</returns>
		public ResultFunctionResponse<IEnumerable<HelloWorldDisplayData>> Find(HelloWorldRecord record)
		{
			// Get the appropriate repository
			var getHelloWorldRepositoryResponse = GetHelloWorldDataRepository(record);

			// Check for error
			if (!getHelloWorldRepositoryResponse.Success)
				return new ResultFunctionResponse<IEnumerable<HelloWorldDisplayData>>(false, getHelloWorldRepositoryResponse.ErrorMessage);

			// Get the respository
			IFindHelloWorldDataRepository findHelloWorldDataRepository = getHelloWorldRepositoryResponse.Result;

			var id = record.Id;

			// Get the data
			var result = findHelloWorldDataRepository.Find(id);
			
			return new ResultFunctionResponse<IEnumerable<HelloWorldDisplayData>>(result);
		}

		/// <summary>
		/// Gets the appropriate Find Hello World Data repository (Factory pattern)
		/// </summary>
		/// <param name="record">HelloWorldRecord entity</param>
		/// <returns>Instance of a Find Hello World Data repository</returns>
		private ResultFunctionResponse<IFindHelloWorldDataRepository> GetHelloWorldDataRepository(HelloWorldRecord record)
		{
			switch (record.RepositoryType)
			{
				case RepositoryType.CsvFile:
				{
						// Check the full path for the Csv file
						var fileNamePath = record.FileNameAndPath;

						// If file name path is blank, return error
						if (string.IsNullOrWhiteSpace(fileNamePath))
							return new ResultFunctionResponse<IFindHelloWorldDataRepository>(false, "File name and path to CSV file for Hello World Display data is blank");

						// If file doesn't exist, return error
						if (!File.Exists(fileNamePath))
							return new ResultFunctionResponse<IFindHelloWorldDataRepository>(false, "File name and path to CSV file for Hello World Display data doesn't exist");

						// Instantiate the repository
						var helloWorldDisplayDataCsvRepository = new HelloWorldDisplayDataCsvRepository(fileNamePath);

						// Return the created repository
						return new ResultFunctionResponse<IFindHelloWorldDataRepository>(helloWorldDisplayDataCsvRepository);
				}

				case RepositoryType.SqlDatabase:
					{
						// Check the connection string for the database
						var connectionString = record.ConnectionString;

						// If connection string is blank, return error
						if (string.IsNullOrWhiteSpace(connectionString))
							return new ResultFunctionResponse<IFindHelloWorldDataRepository>(false, "Connection string to database for Hello World Display data is blank");

						// Instantiate the repository
						var helloWorldDisplayDataSqlRepository = new HelloWorldDisplayDataSqlRepository(connectionString);

						// Return the created repository
						return new ResultFunctionResponse<IFindHelloWorldDataRepository>(helloWorldDisplayDataSqlRepository);
					}

				default:
					throw new NotSupportedException("Invalid Repository Type");
			}
		}
	}
}
