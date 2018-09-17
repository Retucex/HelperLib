using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLib.Types
{
	public static class EnumHelper
	{
		public static Enum GetRandom(this Enum @enum)
		{
			var values = Enum.GetValues(@enum.GetType());
			var randValue = (Enum)values.GetValue(Math.Random.NextInt(values.Length));
			return randValue;
		}
	}
}