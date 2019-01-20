using System.Text;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HelperLib.Extensions
{
	public static class ObjectExtensions
	{
		/// <summary>
		/// Returns a string with generic information about the object.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="nameof">Leave null for CallerMemberNameAttribute</param>
		/// <param name="seperator">Seperator used after each field</param>
		/// <returns>obj Information</returns>
		public static string GetGenericIdentifier(this object obj, [CallerMemberName]string nameof = null, string seperator = "\n")
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("[").Append($"NameOf:{nameof}").Append(seperator)
				.Append($"ToString:'{obj}'").Append(seperator)
				.Append($"Type:{obj.GetType().Name}");

			foreach (FieldInfo runtimeField in obj.GetType().GetRuntimeFields())
			{
				if (runtimeField.IsPublic)
				{
					sb.Append(seperator).Append($"{runtimeField.Name}:{runtimeField.GetValue(obj)}");
				}
			}

			foreach (PropertyInfo runtimeProperty in obj.GetType().GetRuntimeProperties())
			{
				if (runtimeProperty.CanRead && runtimeProperty.GetMethod.GetParameters().Length == 0 && runtimeProperty.GetMethod.IsPublic)
				{
					sb.Append(seperator).Append($"{runtimeProperty.Name}:{runtimeProperty.GetValue(obj)}");
				}
			}

			sb.Append("]");
			return sb.ToString();
		}

		/// <summary>
		/// Generate a HashCode from GetGenericIdentifier
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="nameof">Leave null for CallerMemberNameAttribute</param>
		/// <returns>HashCode</returns>
		public static int GetGenericHashCode(this object obj, [CallerMemberName]string nameof = null)
		{
			return obj.GetGenericIdentifier(nameof).GetHashCode();
		}
	}
}
