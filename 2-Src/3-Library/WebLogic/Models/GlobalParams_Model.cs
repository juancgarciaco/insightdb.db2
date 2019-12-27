using Insight.Database;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
	public class GlobalParams_Model
	{

		public class GlobalParamsModelView_In
		{

			[Column("agpv_id")]
			public int ParamId { get; set; }

			[Column("agpv_paramname")]
			public string ParamName { get; set; }

		}

		public class GlobalParamsModelProc_In
		{

			[Required]
			[Column("p_paramname")]
			public string ParamName { get; set; }

		}

		public class GlobalParamsModel_Out
		{
			[Required]
			[Column("agpv_id")]
			public int Id { get; set; }

			[Required]
			[Column("agpv_paramname")]
			public string ParamName { get; set; }

			[Required]
			[Column("agpv_paramvalue")]
			public string ParamValue { get; set; }

			[Required]
			[Column("agpv_description")]
			public string Description { get; set; }
		}
	}
}