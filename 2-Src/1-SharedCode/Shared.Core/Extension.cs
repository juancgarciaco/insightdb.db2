using System;
using System.Web.Script.Serialization;
//using Newtonsoft.Json;

namespace Shared
{
	public static partial class Extensions
	{
		private static JavaScriptSerializer JsConvert = new JavaScriptSerializer();

		public static T CloneClass<T>(this T source) where T : class, new()
		{
			T returnT;
			// Don't serialize a null object, simply return the default for that object
			if (Object.ReferenceEquals(source, null))
			{
				returnT = default(T);
				if (Object.ReferenceEquals(returnT, null))
				{
					returnT = new T();
				}
				return returnT;
			}
			return source;
		}

		public static T CloneJson<T>(this T source)
		{
			// Don't serialize a null object, simply return the default for that object
			if (Object.ReferenceEquals(source, null))
			{
				return default(T);
			}

			//return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
			return JsConvert.Deserialize<T>(JsConvert.Serialize(source));
		}

		public static T2 CopyTo<T1, T2>(this T1 modelIn, T2 modelOut)
		{
			if (Object.ReferenceEquals(modelIn, null))
			{
				return default(T2);
			}

			//return JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(modelIn));
			return JsConvert.Deserialize<T2>(JsConvert.Serialize(modelIn));

		}

	}
}
