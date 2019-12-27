using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp1.Logic;
using WebApp1.Models;

namespace WebApp1.Controllers
{
	public class BasicController : ApiController
	{
		#region Privates

		private GlobalParams_Logic globlaParamsLogic;

		#endregion Privates

		#region Constructors


		public BasicController()
		{
			globlaParamsLogic = new GlobalParams_Logic();

		}

		#endregion Constructors


		// GET: api/Basic
		public async Task<IEnumerable<GlobalParams_Model.GlobalParamsModel_Out>> Get()
		{
			return await globlaParamsLogic.GetGlobalParamsAsync();
		}


		// GET: api/Basic/5
		public async Task<GlobalParams_Model.GlobalParamsModel_Out> GetAsync(int id)
		{
			return await globlaParamsLogic.GetGlobalParamsByIdAsync(id);
		}

		// POST: api/Basic
		public void Post([FromBody]string value)
		{
		}

		// PUT: api/Basic/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Basic/5
		public void Delete(int id)
		{
		}
	}
}
