using System;
using System.Security.AccessControl;
using Microsoft.Win32;

namespace NjuMobileNumbers
{
	public static class WebBrowserEmulation
	{
		private static string CurrentExecutableName
		{
			get { return AppDomain.CurrentDomain.FriendlyName; }
		}

		private static RegistryKey BrowserEmulationKey
		{
			get
			{
				return
					Registry.LocalMachine.OpenSubKey(
						"Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
			}
		}

		private static void Write(string value)
		{
			BrowserEmulationKey.SetValue(CurrentExecutableName, value, RegistryValueKind.DWord);
		}

		public static bool Delete()
		{
			try
			{
				BrowserEmulationKey.DeleteValue(CurrentExecutableName, true);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static void Change(BrowserEmulation emulation)
		{
			switch (emulation)
			{
				case BrowserEmulation.IE10:
					Write("10000");
					break;
				case BrowserEmulation.IE9:
					Write("9000");
					break;
				case BrowserEmulation.IE8:
					Write("8000");
					break;
				case BrowserEmulation.Default:
					Write("7000");
					break;
			}
		}
	}

	public enum BrowserEmulation
	{
		// ReSharper disable InconsistentNaming
		IE10,
		IE9,
		IE8,
		Default
		// ReSharper restore InconsistentNaming
	}
}