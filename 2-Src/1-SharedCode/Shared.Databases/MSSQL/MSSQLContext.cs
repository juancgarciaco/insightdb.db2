using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Insight.Database;

namespace Shared.Databases.MSSQL
{
	#region Database_Conexiones
	public class MSSQLContext : IDisposable
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

		public MSSQLContext() : this("DefaultConnection")
		{
		}

		public MSSQLContext(string ConnectionName)
		{
			ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings[ConnectionName];
			if (connectionString== null)
			{
				throw new ApplicationException("Conexión no existente.");
			}
			_connection = connectionString.ConnectionString;

			SqlInsightDbProvider.RegisterProvider();
			
			DbConn = new SqlConnection(_connection);
		}

		public MSSQLContext(MSSQLContext appConnection)
		{
			DbConn = appConnection.DbConn;
		}

		#region Dispose
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~MSSQLContext()
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
