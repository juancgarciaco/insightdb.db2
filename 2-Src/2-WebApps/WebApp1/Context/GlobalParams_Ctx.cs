using Insight.Database;
using Shared.Databases.DB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApp1.Context
{
	internal class GlobalParams_Ctx : DB2Context
	{
		#region Constructors

		internal GlobalParams_Ctx(DB2Context dbContext) : base(dbContext)
		{
		}

		#endregion Constructors
		#region Methods

		internal async Task<IEnumerable<TypeOut>> GetGlobalParamsAsync<TypeIn, TypeOut>(TypeIn modelDataIn)
		{
			string sql = "SELECT * FROM v_adm_globalparams_vertical;";
			return await DbConn.QueryAsync<TypeOut>(sql, modelDataIn, CommandType.StoredProcedure);
		}

		internal async Task<IEnumerable<TypeOut>> GetDriverVehicleAsync<TypeIn, TypeOut>(TypeIn modelDataIn)
		{
			string sql = "informix.proc_globalparams_vertical_byname";
			return await DbConn.QueryAsync<TypeOut>(sql, modelDataIn, CommandType.StoredProcedure);
		}

		#endregion Methods

	}
}