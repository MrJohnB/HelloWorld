
namespace HelloWorld.Domain
{
	/// <summary>
	/// So you can have a response that tells caller whether there was an error or not
	/// </summary>
	/// <typeparam name="T">Response entity type</typeparam>
    public class ResultFunctionResponse<T>
    {
		public bool Success { get; }
		public string ErrorMessage { get; }
		public T Result { get; }

		/// <summary>
		/// Creates a Result Function Response (for errors)
		/// </summary>
		/// <param name="success">Flag for whether successful</param>
		/// <param name="errorMessage">String for error message</param>
		public ResultFunctionResponse(bool success, string errorMessage)
		{
			Success = success;
			ErrorMessage = errorMessage;
			Result = default(T);
		}

		/// <summary>
		/// Creates a Result Function Response (for success)
		/// </summary>
		/// <param name="result">Value or object to return (Generic)</param>
		public ResultFunctionResponse(T result)
		{
			Success = true;
			ErrorMessage = string.Empty;
			Result = result;
		}
	}
}
