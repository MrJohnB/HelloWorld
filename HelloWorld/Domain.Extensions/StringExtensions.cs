
using HelloWorld.Common;

namespace HelloWorld.Domain.Extensions
{
	/// <summary>
	/// String extension/helper methods
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Formats an error message for display
		/// </summary>
		/// <param name="errorMessage">Contents of the error message</param>
		/// <returns>String of the formatted error message with label</returns>
		public static string FormatErrorMessage(this string errorMessage)
		{
			var formattedErrorMessage = HelloWorldConstants.ErrorMessageLabel + " '" + errorMessage + "'";

			return formattedErrorMessage;
		}
	}
}
