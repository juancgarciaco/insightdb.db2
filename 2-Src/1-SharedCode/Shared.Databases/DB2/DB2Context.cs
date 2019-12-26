using IBM.Data.DB2;
using Insight.Database.Providers;
using Insight.Database.Providers.DB2;
using System;
using System.Configuration;
using System.Data;

namespace Shared.Databases.DB2
{
	#region Database_Conexiones
	public class DB2Context : IDisposable
	{
		private string _connection;

		public IDbConnection DbConn { get; internal set; }

		public string ConnectioString
		{
			get
			{
				return _connection;
			}
		}

		public DB2Context() : this("DefaultConnection")
		{
		}

		public DB2Context(string ConnectionName)
		{
			ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings[ConnectionName];
			if (connectionString == null)
			{
				throw new ApplicationException("Conexión no existente.");
			}
			_connection = connectionString.ConnectionString;

			InsightDbProvider.RegisterProvider(new DB2InsightDbProvider());
			DbConn = new DB2Connection(_connection);
		}

		public DB2Context(DB2Context appConnection)
		{
			DbConn = appConnection.DbConn;
		}

		#region Dispose
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~DB2Context()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (DbConn != null)
				{
					DbConn.Dispose();
					DbConn = null;
				}
			}
		}
		#endregion
	}
	#endregion
}
