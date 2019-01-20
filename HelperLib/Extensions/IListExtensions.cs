using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace HelperLib.Extensions
{
	public static class IListExtensions
	{
		/// <summary>
		/// Swaps 2 elements within IList
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="firstIndex"></param>
		/// <param name="secondIndex"></param>
		public static void Swap<T>(
			this IList<T> list,
			int firstIndex,
			int secondIndex
		)
		{
			Contract.Requires(list != null);
			Contract.Requires(firstIndex >= 0 && firstIndex < list.Count);
			Contract.Requires(secondIndex >= 0 && secondIndex < list.Count);
			if (firstIndex == secondIndex)
			{
				return;
			}
			T temp = list[firstIndex];
			list[firstIndex] = list[secondIndex];
			list[secondIndex] = temp;
		}
	}
}
