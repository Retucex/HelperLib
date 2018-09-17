using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace HelperLib
{
	public static class Log
	{
		public static void InitializeNLogConfig()
		{
			var exe = Assembly.GetExecutingAssembly();
			string resourceName = exe.GetManifestResourceNames()
									 .FirstOrDefault(s => s.IndexOf("NLog.config", StringComparison.OrdinalIgnoreCase) > -1);
			if (!string.IsNullOrEmpty(resourceName))
			{
				using (var xml = new StreamReader(exe.GetManifestResourceStream(resourceName)))
				{
					string xmlConfig = xml.ReadToEnd();
					if (!File.Exists("NLog.config"))
					{
						File.WriteAllText("NLog.config", xmlConfig);
					}
				}
			}

			LogManager.Configuration = LogManager.Configuration.Reload();
			LogManager.ReconfigExistingLoggers();
		}
	}
}