using System;
using System.Data;
using System.Web;

namespace Shared.Databases.DB2.AppContext
{
	[Obsolete("ApplicationDb2Context is deprecated, please use ApplicationDbContext instead.")]
	public class ApplicationDb2Context : DB2Context
	{
		public IDbConnection DbConx
		{
			get
			{
				return this.DbConn;
			}
		}

		public ApplicationDb2Context() : base("DefaultConnection")
		{
		}

		public ApplicationDb2Context(string connectionName) : base(connectionName)
		{
		}

		
		public static ApplicationDb2Context Create()
		{
			string settingConn = string.Format("{0}", HttpContext.Current.Application["AppConnectionString"]);
			var dbContext = new ApplicationDb2Context(settingConn.GetValueOrDefault("DefaultConnection"));
			HttpContext.Current.Application["AppConnectionDB"] = dbContext;
			return dbContext;
		}

		public static ApplicationDb2Context Create(string connectionName, string applicationVar)
		{
			var dbContext = new ApplicationDb2Context(connectionName.GetValueOrDefault("DefaultConnection"));
			HttpContext.Current.Application[applicationVar] = dbContext;
			return dbContext;
		}
	}
}