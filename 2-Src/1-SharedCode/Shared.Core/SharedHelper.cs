using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Shared
{

	public static partial class SharedHelper
	{
		public enum ConsoleActions
		{
			EmptyLine,

		}
		#region Helpers-Console
		public static void ConsoleWrite(string title)
		{
			Console.WriteLine(title);
		}

		public static void ConsoleWrite(ConsoleActions action)
		{
			switch (action)
			{
				case ConsoleActions.EmptyLine:
					Console.WriteLine();
					break;
				default:
					break;
			}
		}
		public static void LogDebug()
		{
			Debug.WriteLine("------------------------------------------");
		}

		public static void LogDebug(string text)
		{
			#region Assertion

			string param1AssertFalse = "El parametro text no puede ser null";
			Debug.Assert(text!= null, param1AssertFalse);
			if (text== null)
			{
				LogDebug(param1AssertFalse);
				return;
			}

			#endregion

			string messageText = @"Log: [General]	{1}{0}	Message	=>	{2}";
			string messageFormat = string.Format(
				messageText,
				Environment.NewLine,
				DateTime.Now.ToIsoDateTimeString(),
				text.Replace(Environment.NewLine, " _ ").Trim()
			);
			//Console.WriteLine(messageFormat);
			Debug.WriteLine(messageFormat);
			LogDebug();
		}

		public static void LogDebug(Exception exception, bool exceptionMannaged)
		{
			#region Assertion

			string param1AssertFalse = "El parametro text no puede ser null";
			Debug.Assert(exception!= null, param1AssertFalse);
			if (exception== null)
			{
				LogDebug(param1AssertFalse);
				return;
			}

			#endregion

			var excBase = exception.GetFirstException();

			string messageText = @"Log: [Exception],mannaged: [{2}]	{1}{0}	ExcBase: [{3}]	=> {4}{0}	exc: [{5}]	=> {6}{0}";

			string messageFormat = string.Format(
				messageText,
				Environment.NewLine,
				DateTime.Now.ToIsoDateTimeString(),
				exceptionMannaged,
				excBase.GetType().FullName,
				excBase.Message.Replace(Environment.NewLine, " _ ").Trim(),
				exception.GetType().FullName,
				exception.Message.Replace(Environment.NewLine, " _ ").Trim()
			);
			//Console.WriteLine(messageFormat);
			Debug.WriteLine(messageFormat);
			LogDebug();
		}
		#endregion

		#region Helpers-AppSettings
		public static bool AppConfigurationKeyValidate(string keyName)
		{
			return ConfigurationManager.AppSettings.AllKeys.Contains(keyName);
		}

		public static T AppConfigurationKeyGetValue<T>(string keyName) where T : class, new()
		{
			if (AppConfigurationKeyValidate(keyName))
			{
				return ConfigurationManager.AppSettings.Get(keyName) as T;
			}
			else
			{
				throw new ApplicationException(string.Format("No existe clave {0}", keyName));
			}
		}

		public static string AppConfigurationKeyGetValue(string keyName)
		{
			if (AppConfigurationKeyValidate(keyName))
			{
				return ConfigurationManager.AppSettings.Get(keyName);
			}
			else
			{
				throw new ApplicationException(string.Format("No existe clave {0}", keyName));
			}
		}
		#endregion
	}
}
