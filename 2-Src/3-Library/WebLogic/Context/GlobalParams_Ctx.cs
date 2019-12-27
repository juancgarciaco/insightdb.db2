using Insight.Database;
using Shared.Databases.DB2;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

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

		internal async Task<IEnumerable<TypeOut>> GetGlobalParamsAsync<TypeIn, TypeOut>()
		{
			string sql = "SELECT * FROM v_adm_globalparams_vertical;";

			return await DbConn.QueryAsync<TypeOut>(sql, null, CommandType.Text);
		}

		internal async Task<TypeOut> GetGlobalParamsByIdAsync<TypeIn, TypeOut>(TypeIn modelDataIn)
		{
			StringBuilder sql = new StringBuilder("SELECT * FROM v_adm_globalparams_vertical");
			if (modelDataIn != null)
			{
				sql.AppendLine("	WHERE agpv_id == @agpv_id");
			}
			sql.AppendLine(";");

			return await DbConn.SingleAsync<TypeOut>(sql.ToString(), modelDataIn, CommandType.Text);
		}

		internal async Task<TypeOut> GetGlobalParamsByNameViewAsync<TypeIn, TypeOut>(TypeIn modelDataIn)
		{
			StringBuilder sql = new StringBuilder("SELECT * FROM v_adm_globalparams_vertical");
			if (modelDataIn != null)
			{
				sql.AppendLine("	WHERE UPPER(agpv_paramname) == UPPER(@agpv_paramname)");
			}
			sql.AppendLine(";");

			return await DbConn.SingleAsync<TypeOut>(sql.ToString(), modelDataIn, CommandType.Text);
		}

		internal async Task<TypeOut> GetGlobalParamsByNameProcAsync<TypeIn, TypeOut>(TypeIn modelDataIn)
		{
			string sql = "informix.proc_globalparams_vertical_byname";
			return await DbConn.SingleAsync<TypeOut>(sql, modelDataIn, CommandType.StoredProcedure);
		}

		#endregion Methods

	}
}