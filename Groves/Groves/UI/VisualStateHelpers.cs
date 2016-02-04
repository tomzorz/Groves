using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Groves.UI
{
	/// <summary>
	/// Tools to help with VisualStates
	/// </summary>
	public static class VisualStateHelpers
	{
		/// <summary>
		/// Create a new VisualState with the preferred name at runtime
		/// </summary>
		/// <param name="name">name of the new VisualState</param>
		/// <returns>Named VisualState</returns>
		public static VisualState CreateNewVisualState(string name)
		{
			var vs = (VisualState)XamlReader.Load($"<VisualState x:Name=\"{name}\"" +
														   " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"" +
														   " xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" />");
			return vs;
		}

		/// <summary>
		/// Create a new VisualStateGroup with the preferred name at runtime
		/// </summary>
		/// <param name="name">name of the new VisualStateGroup</param>
		/// <returns>Named VisualStateGroup</returns>
		public static VisualStateGroup CreateNewVisualStateGroup(string name)
		{
			var vsg = (VisualStateGroup)XamlReader.Load($"<VisualStateGroup x:Name=\"{name}\"" +
														   " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"" +
														   " xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" />");
			return vsg;
		}

		static VisualStateHelpers()
		{
			_loggerDict = new Dictionary<VisualStateGroup, Action<string>>();
		}

		private static Dictionary<VisualStateGroup, Action<string>> _loggerDict;

		/// <summary>
		/// Log state changes in a VisualStateGroup
		/// </summary>
		/// <param name="vsg">VisualStateGroup</param>
		/// <param name="logOutput">Output logger action (eg.: Debug.WriteLine)</param>
		public static void LogVisualStateChanges(VisualStateGroup vsg, Action<string> logOutput)
		{
			_loggerDict.Add(vsg, logOutput);
			vsg.CurrentStateChanged += Vsg_CurrentStateChanged;
		}

		private static void Vsg_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
		{
			var vsg = (VisualStateGroup) sender;
			_loggerDict[vsg].Invoke($"Visual state group '{vsg.Name}' changed to '{e?.NewState?.Name ?? "n/a"}' from '{e?.OldState?.Name ?? "n/a"}'");
		}

		/// <summary>
		/// Removes all or a specific logger from a VisualStateGroup
		/// </summary>
		/// <param name="vsg">specify visual state group to remove logger from that group only</param>
		public static void StopLogging(VisualStateGroup vsg = null)
		{
			if (vsg == null)
			{
				foreach (var key in _loggerDict.Keys)
				{
					key.CurrentStateChanged -= Vsg_CurrentStateChanged;
				}
				_loggerDict.Clear();
			}
			else
			{
				if(!_loggerDict.ContainsKey(vsg)) return;
				vsg.CurrentStateChanged -= Vsg_CurrentStateChanged;
				_loggerDict.Remove(vsg);
			}
		}
	}
}