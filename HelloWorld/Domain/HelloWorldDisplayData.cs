
namespace HelloWorld.Domain
{
	/// <summary>
	/// POCO for the Hello World display data structure
	/// </summary>
	public class HelloWorldDisplayData
	{
		/// <summary>
		/// Id of record
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Contents
		/// </summary>
		public string Contents { get; set; }

		public HelloWorldDisplayData()
		{
			this.Id = int.MinValue;
			this.Contents = string.Empty;
		}
	}
}
