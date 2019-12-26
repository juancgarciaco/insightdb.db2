using System;

namespace Shared
{
	public static partial class Extensions
	{

		/// <summary>
		/// Convierte una fecha en formato 'yyyy-MM-ddTHH:mm:ss'
		/// </summary>
		/// <param name="value"></param>
		/// <returns>String</returns>
		public static string ToIsoDateTimeString(this DateTime value)
		{
			return value.ToString("yyyy-MM-ddTHH:mm:ss.ffff");
		}

		/// <summary>
		/// Convierte una fecha en formato 'yyyy-MM-dd'
		/// </summary>
		/// <param name="value"></param>
		/// <returns>String</returns>
		public static string ToIsoDateString(this DateTime value)
		{
			return value.ToString("yyyy-MM-dd");
		}

		/// <summary>
		/// Convierte una fecha en formato 'HH:mm:ss'
		/// </summary>
		/// <param name="value"></param>
		/// <returns>String</returns>
		public static string ToIsoTimeString(this DateTime value)
		{
			return value.ToString("HH:mm:ss.ffff");
		}
	}
}
