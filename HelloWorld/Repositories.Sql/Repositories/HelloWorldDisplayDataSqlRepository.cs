using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using HelloWorld.Domain;

namespace HelloWorld.Repositories.Sql
{
	/// <summary>
	/// Defines the structure of a HelloWorldDisplayData Find repository
	/// </summary>
	public class HelloWorldDisplayDataSqlRepository : IFindHelloWorldDataRepository
	{
		private readonly string _connectionString;
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">Database connection string</param>
		public HelloWorldDisplayDataSqlRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		/// <summary>
		/// Find a fully populated list of HelloWorldDisplayData by id
		/// </summary>
		/// <param name="id">record id</param>
		/// <returns>HelloWorldDisplayData collection, or error</returns>
		public IEnumerable<HelloWorldDisplayData> Find(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand(StoredProcedures.select_hello_world_records, connection))
				{
					command.Parameters.Clear();
					command.Parameters.Add(new SqlParameter(SqlTokens.id, id));

					using (SqlDataReader dr = command.ExecuteReader())
					{
						if (!dr.HasRows)
						{
							// Return empty list
							return Enumerable.Empty<HelloWorldDisplayData>();
						}

						var mapper = new HelloWorldDisplayDataSqlMapper();
						var displayDataList = new List<HelloWorldDisplayData>();

						while (dr.Read())
						{
							var displayData = mapper.Map(dr);
							displayDataList.Add(displayData);
						}

						return displayDataList;
					}
				}
			}
		}
	}
}
