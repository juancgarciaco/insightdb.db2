using Shared.Databases.DB2;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using WebApp1.Context;
using WebApp1.Models;

namespace WebApp1.Logic
{
	public class GlobalParams_Logic
	{
		#region Privates

		private DB2Context dbContext;

		//private DB2Context dbContext2;
		private GlobalParams_Ctx globalParamsCtx;

		//private BearingCtx bearingCtx2;

		#endregion Privates

		#region Constructors

		public GlobalParams_Logic()
		{
			dbContext = HttpContext.Current.Application["AppConnectionDB"] as DB2Context;
			//dbContext2 = HttpContext.Current.Application["AppConnectionDB2"] as DB2Context;
			Init();
		}

		public GlobalParams_Logic(DB2Context appConnection)
		{
			dbContext = appConnection;
			Init();
		}

		internal void Init()
		{
			globalParamsCtx = new GlobalParams_Ctx(dbContext);
			//bearingCtx2 = new BearingCtx(dbContext2);
		}

		#endregion Constructors

		#region Public Methods

		public async Task<IEnumerable<GlobalParams_Model.GlobalParamsModel_Out>> GetGlobalParamsAsync()
		{

			return await globalParamsCtx.GetGlobalParamsAsync<GlobalParams_Model.GlobalParamsModelView_In, GlobalParams_Model.GlobalParamsModel_Out>();

		}

		public async Task<GlobalParams_Model.GlobalParamsModel_Out> GetGlobalParamsByIdAsync(int Id)
		{
			if (Id == (default(int)))
			{
				return null;
			}
			var modelDataIn = new GlobalParams_Model.GlobalParamsModelView_In() { ParamId = Id };

			return await globalParamsCtx.GetGlobalParamsByIdAsync<GlobalParams_Model.GlobalParamsModelView_In, GlobalParams_Model.GlobalParamsModel_Out>(modelDataIn);

		}

		public async Task<GlobalParams_Model.GlobalParamsModel_Out> GetGlobalParamsByNameViewAsync(string Name)
		{
			if (string.IsNullOrEmpty(Name))
			{
				return null;
			}
			var modelDataIn = new GlobalParams_Model.GlobalParamsModelView_In() { ParamName = Name };

			return await globalParamsCtx.GetGlobalParamsByNameViewAsync<GlobalParams_Model.GlobalParamsModelView_In, GlobalParams_Model.GlobalParamsModel_Out>(modelDataIn);

		}

		public async Task<GlobalParams_Model.GlobalParamsModel_Out> GetGlobalParamsByNameProcAsync(string Name)
		{
			if (string.IsNullOrEmpty(Name))
			{
				return null;
			}
			var modelDataIn = new GlobalParams_Model.GlobalParamsModelProc_In() { ParamName = Name };

			return await globalParamsCtx.GetGlobalParamsByNameProcAsync<GlobalParams_Model.GlobalParamsModelProc_In, GlobalParams_Model.GlobalParamsModel_Out>(modelDataIn);

		}
		#endregion Public Methods

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					dbContext.Dispose();
					globalParamsCtx.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~BearingLogic() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		#endregion IDisposable Support

	}
}