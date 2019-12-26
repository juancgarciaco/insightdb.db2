using System;
using System.Security.Cryptography;
using System.Text;

namespace Shared
{
	public static partial class Extensions
	{
		/// <summary>
		/// Convierte el primer caractér de una cadena de texto a Mayuscula
		/// </summary>
		/// <param name="value"></param>
		/// <returns>string</returns>
		public static string ToUpperFirstLetter(this string value)
		{
			char[] array = value.ToCharArray();
			// handle the first letter in the string
			if (array.Length >= 1)
			{
				if (char.IsLower(array[0]))
				{
					array[0] = char.ToUpper(array[0]);
				}
			}

			// scan through the letters, checking for spaces
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i - 1] == ' ')
				{
					if (char.IsLower(array[i]))
					{
						array[i] = char.ToUpper(array[i]);
					}
				}
			}

			return new string(array);
		}

		/// <summary>
		/// Convierte el primer caractér de una cadena de texto a Minuscula
		/// </summary>
		/// <param name="value"></param>
		/// <returns>string</returns>
		public static string ToLowerFirstLetter(this string value)
		{
			char[] array = value.ToCharArray();
			// handle the first letter in the string
			if (array.Length >= 1)
			{
				if (char.IsUpper(array[0]))
				{
					array[0] = char.ToLower(array[0]);
				}
			}

			// scan through the letters, checking for spaces
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i - 1] == ' ')
				{
					if (char.IsUpper(array[i]))
					{
						array[i] = char.ToLower(array[i]);
					}
				}
			}

			return new string(array);
		}

		public static string GetValueOrDefault(this string value, string defaultValue)
		{
			string strReturn = value;
			if (value != null)
			{
				value = value.Trim();
			}
			if (string.IsNullOrEmpty(value))
			{
				strReturn = defaultValue;
			}
			return strReturn;
		}

		public static string ToBase64Encode(this string plainText)
		{
			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(plainTextBytes);
		}

		public static string ToBase64Decode(this string base64EncodedData)
		{
			var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(base64EncodedBytes);
		}

		public static bool IsBase64(this string base64String)
		{
			// Credit: oybek https://stackoverflow.com/users/794764/oybek
			if (
				base64String == null
				|| base64String.Length == 0
				|| base64String.Length % 4 != 0
				|| base64String.Contains(" ")
				|| base64String.Contains("\t")
				|| base64String.Contains("\r")
				|| base64String.Contains("\n")
			)
			{
				return false;
			}

			try
			{
				Convert.FromBase64String(base64String);
				return true;
			}
			//catch (Exception exception)
			catch
			{
				// Handle the exception
			}
			return false;
		}

		public static string ToMD5Encrypt(this string plainText, bool upperCase = false)
		{
			using (var algorithm = MD5.Create())
			{
				var saltedPasswordAsBytes = Encoding.UTF8.GetBytes(plainText);
				byte[] hash = algorithm.ComputeHash(saltedPasswordAsBytes);
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hash.Length; i++)
				{
					sb.Append(hash[i].ToString(upperCase ? "X2" : "x2"));
				}
				return sb.ToString();
			}
		}

		public static string PreserveDoubleQuotes(this string plainText)
		{
			return plainText.Replace("\"", "\\\"");
		}

		/// <summary>
		/// Acortar un nombre
		/// </summary>
		/// <param name="Names"></param>
		/// <param name="LastNames"></param>
		/// <param name="ToUpper"></param>
		/// <returns></returns>
		public static string ShortenName(string Names, string LastNames, bool ToUpper = false)
		{
			Names = Names.Trim();
			LastNames = LastNames.Trim();

			string SimplyFullName = "";

			var split = Names.Split(' ');

			//RESOLVE NAMES
			if (split.Length == 1)
			{
				SimplyFullName = Names + " ";
			}
			else if (split.Length == 2)
			{
				SimplyFullName = split[0].Trim();
				SimplyFullName += $" {(split[1].Trim()[0])}. ";
			}
			else
			{
				if (split[0].Trim().Length < 4)
				{
					SimplyFullName = $"{split[0].Trim()} {split[1].Trim()} ";
				}
				else
				{
					SimplyFullName = Names + " ";
				}
			}

			split = LastNames.Split(' ');

			//RESOLVE LASTNAMES
			if (split.Length == 1)
			{
				SimplyFullName += LastNames;
			}
			else if (split.Length == 2)
			{
				SimplyFullName += split[0].Trim();
				SimplyFullName += $" {(split[1].Trim()[0])}. ";
			}
			else
			{
				if (split[0].Trim().Length < 4)
				{
					SimplyFullName = $"{split[0].Trim()} {split[1].Trim()}";
				}
				else
				{
					SimplyFullName = LastNames;
				}
			}

			if (ToUpper)
			{
				return SimplyFullName.ToUpper();
			}
			else
			{
				return SimplyFullName.ToLowerFirstLetter();
			}
		}
	}
}