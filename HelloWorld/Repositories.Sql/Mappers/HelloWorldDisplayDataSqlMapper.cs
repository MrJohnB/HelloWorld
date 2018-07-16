using System;
using System.Data;
using HelloWorld.Domain;

namespace HelloWorld.Repositories.Sql
{
	/// <summary>
	/// Mapper for HelloWorldDisplayData entity (from the database)
	/// </summary>
	public class HelloWorldDisplayDataSqlMapper
	{
		public HelloWorldDisplayData Map(IDataReader dr)
		{
			var result = new HelloWorldDisplayData();

			if (dr[SqlTokens.id] != DBNull.Value)
				result.Id = int.Parse(dr[SqlTokens.id].ToString());

			if (dr[SqlTokens.contents] != DBNull.Value)
				result.Contents = dr[SqlTokens.contents].ToString();

			return result;
		}
	}
}
