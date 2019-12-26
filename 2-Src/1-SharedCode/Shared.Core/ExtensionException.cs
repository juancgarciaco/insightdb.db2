using System;

namespace Shared
{
	public static partial class ExtensionException
	{
		public static Exception GetFirstException(this Exception value)
		{
			Exception baseEX, firstEX;
			baseEX = firstEX = value.GetBaseException();
			var baseEXType = value.GetBaseException().GetType();

			if (baseEX.InnerException != null)
			{
				firstEX = baseEX.InnerException;
			}

			return firstEX;
		}

	}
}
