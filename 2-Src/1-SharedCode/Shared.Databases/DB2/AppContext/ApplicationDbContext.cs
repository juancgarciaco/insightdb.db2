using System;
using System.Web;

namespace Shared.Databases.DB2.AppContext
{
	public class ApplicationDbContext<TDbContext>
		where TDbContext : class
	{
		public static TDbContext Create()
		{
			string connectionName = $"{HttpContext.Current.Application["AppConnectionString"]}";
			return Create(connectionName, "AppConnectionDB");
		}

		public static TDbContext Create(string connectionName, string applicationVar)
		{
			var dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), connectionName.GetValueOrDefault("DefaultConnection"));
			HttpContext.Current.Application[applicationVar] = dbContext;
			return dbContext;
		}
	}
}