using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp1.Logic;
using WebApp1.Models;

namespace WebApp1.Controllers
{
	[RoutePrefix("V1/GlobalParams")]
	public class PersonalizedController : ApiController
	{
		#region Privates

		private GlobalParams_Logic globlaParamsLogic;

		#endregion Privates

		#region Constructors


		public PersonalizedController()
		{
			globlaParamsLogic = new GlobalParams_Logic();

		}

		#endregion Constructors

		#region Methods-Controllers

		[ActionName("GetAllParams")]
		[Route("GetAllParams")]
		[HttpGet]
		//[SwaggerResponse(System.Net.HttpStatusCode.OK)]
		public async Task<IHttpActionResult> GetGlobalParamsAsync()
		{
			IEnumerable<GlobalParams_Model.GlobalParamsModel_Out> msr = new List<GlobalParams_Model.GlobalParamsModel_Out>();

			if (!ModelState.IsValid)
			{
				return BadRequest("Model Error");
			}

			try
			{
				msr = await globlaParamsLogic.GetGlobalParamsAsync();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.GetBaseException().Message);
			}

			return Ok(msr);
		}

		[ActionName("GetParamById")]
		[Route("GetParamById/{id:int}")]
		[HttpGet]
		//[SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(GlobalParams_Model.GlobalParamsModel_Out)]
		public async Task<IHttpActionResult> GetGlobalParamsByIdAsync(int id)
		{
			GlobalParams_Model.GlobalParamsModel_Out msr = new GlobalParams_Model.GlobalParamsModel_Out();

			if (!ModelState.IsValid)
			{
				return BadRequest("Model Error");
			}

			try
			{
				msr = await globlaParamsLogic.GetGlobalParamsByIdAsync(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.GetBaseException().Message);
			}

			return Ok(msr);
		}

		[ActionName("GetParamByName")]
		[Route("GetParamByName/{Name}")]
		[HttpGet]
		//[SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(GlobalParams_Model.GlobalParamsModel_Out)]
		public async Task<IHttpActionResult> GetGlobalParamsByNameAsync(string Name)
		{
			GlobalParams_Model.GlobalParamsModel_Out msr = new GlobalParams_Model.GlobalParamsModel_Out();

			if (!ModelState.IsValid)
			{
				return BadRequest("Model Error");
			}

			try
			{
				msr = await globlaParamsLogic.GetGlobalParamsByNameViewAsync(Name);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.GetBaseException().Message);
			}

			return Ok(msr);
		}

		[ActionName("GetParamByName2")]
		[Route("GetParamByName2/{Name}")]
		[HttpGet]
		//[SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(GlobalParams_Model.GlobalParamsModel_Out)]
		public async Task<IHttpActionResult> GetGlobalParamsByNameProcAsync(string Name)
		{
			GlobalParams_Model.GlobalParamsModel_Out msr = new GlobalParams_Model.GlobalParamsModel_Out();

			if (!ModelState.IsValid)
			{
				return BadRequest("Model Error");
			}

			try
			{
				msr = await globlaParamsLogic.GetGlobalParamsByNameProcAsync(Name);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.GetBaseException().Message);
			}

			return Ok(msr);
		}
		#endregion Methods-Controllers
	}
}
