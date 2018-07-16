using HelloWorld.Domain;
using System.Collections.Generic;

namespace HelloWorld.Repositories
{
	/// <summary>
	/// Defines the structure of a Find Hello World Data repository
	/// </summary>
	public interface IFindHelloWorldDataRepository
	{
		/// <summary>
		/// Find a fully populated list of HelloWorldDisplayData by id
		/// </summary>
		/// <param name="id">record id</param>
		/// <returns>HelloWorldDisplayData collection, or error</returns>
		IEnumerable<HelloWorldDisplayData> Find(int id);
	}
}
