using HelloWorld.Common;

namespace HelloWorld.Domain
{
	/// <summary>
	/// POCO for the Hello World record (Search metadata)
	/// </summary>
	public class HelloWorldRecord
	{
		/// <summary>
		/// Id of data point
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// File name path of CSV file
		/// </summary>
		public string FileNameAndPath { get; set; }

		/// <summary>
		/// The type of repository for this record (CSV or Database)
		/// </summary>
		public RepositoryType RepositoryType { get; set; }

		/// <summary>
		/// The connection string for an SQL database
		/// </summary>
		public string ConnectionString { get; set; }

		public HelloWorldRecord()
		{
			this.Id = int.MinValue;
			this.FileNameAndPath = string.Empty;
			this.RepositoryType = RepositoryType.Unknown;
			this.ConnectionString = string.Empty;
		}
	}
}
