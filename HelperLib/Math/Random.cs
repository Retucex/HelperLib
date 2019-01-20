using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace HelperLib.Math
{
	/// <summary>
	/// Static random number generator based on System.Random with added utilities.
	/// </summary>
	public static class Random
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		private static System.Random rand = new System.Random();

		/// <summary>
		/// Returns a random double greater than 0 and less than or equal to 1.
		/// </summary>
		/// <returns></returns>
		public static double Next() => 1.0 - rand.NextDouble();

		/// <summary>
		/// Returns a non-negative integer less than the specified maximum.
		/// </summary>
		/// <param name="max">Non-inclusive maximum value.</param>
		/// <returns></returns>
		public static int NextInt(int max) => rand.Next(max);

		/// <summary>
		/// Returns an integer greater than or equal to the specified minimum and less than the specified maximum.
		/// </summary>
		/// <param name="min">Inclusive minimum bound.</param>
		/// <param name="max">Non-inclusive maximum boung.</param>
		/// <returns></returns>
		public static int NextInt(int min, int max) => rand.Next(min, max);

		/// <summary>
		/// Sets the seed of the random number generator.
		/// </summary>
		/// <param name="seed"></param>
		public static void SetSeed(int seed)
		{
			logger.Trace("Set Random Engine seed: {0}", seed);
			rand = new System.Random(seed);
		}

		/// <summary>
		/// Returns a random gaussian number.
		/// </summary>
		/// <param name="mean">Mean of the gaussian distribution.</param>
		/// <param name="stdDev">Standard deviation of the distribution.</param>
		/// <returns></returns>
		public static double GenerateGaussian(double mean, double stdDev)
		{
			return _GenerateGaussian(mean, stdDev);
		}

		/// <summary>
		/// Returns a strictly positive random gaussian number.
		/// </summary>
		/// <param name="mean">Mean of the gaussian distribution.</param>
		/// <param name="stdDev">Standard deviation of the distribution.</param>
		/// <returns></returns>
		public static double GeneratePositiveGaussian(double mean, double stdDev)
		{
			double pos;
			do
			{
				pos = _GenerateGaussian(mean, stdDev);
			} while (pos < 0);

			return pos;
		}

		private static double _GenerateGaussian(double mean, double stdDev)
		{
			double u1 = Next(); //uniform(0,1] random doubles
			double u2 = Next();
			double randStdNormal = System.Math.Sqrt(-2.0 * System.Math.Log(u1)) *
									System.Math.Sin(2.0 * System.Math.PI * u2); //random normal(0,1)
			double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

			return randNormal;
		}
	}
}