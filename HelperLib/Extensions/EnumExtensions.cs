using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLib.Extensions
{
	public static class EnumExtensions
	{
		/// <summary>
		/// Returns a random element.
		/// </summary>
		/// <param name="enum"></param>
		/// <returns></returns>
		public static Enum GetRandom(this Enum @enum)
		{
			var values = Enum.GetValues(@enum.GetType());
			var randValue = (Enum)values.GetValue(Math.Random.NextInt(values.Length));
			return randValue;
		}
	}
}