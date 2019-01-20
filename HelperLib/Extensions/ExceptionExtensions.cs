using System;
using System.Text;
using System.Collections;

namespace HelperLib.Extensions
{
	public static class ExceptionExtensions
	{
		/// <summary>
		/// Returns a string with all the information regarding the exception.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static string Verbose(this Exception e)
		{
			var sb = new StringBuilder();
			sb.AppendLine($"Type:  {e.GetType()}")
				.AppendLine($"Message:  {e.Message}")
				.AppendLine($"Trace:  {e.StackTrace}")
				.AppendLine($"Source:  {e.Source}")
				.AppendLine($"HResult:  {e.HResult}")
				.AppendLine("Data:");

			foreach (DictionaryEntry data in e.Data)
			{
				sb.AppendLine($"Key:  {data.Key}  |  Value:  {data.Value}");
			}

			if (e.InnerException != null)
			{
				sb.AppendLine("Inner:")
					.AppendLine(Verbose(e.InnerException));
			}

			return sb.ToString();
		}
	}
}
