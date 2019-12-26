using Insight.Database;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
	public class GlobalParams_Model
	{
		public class GlobalParamsModel_In
		{

			[Required]
			[Column("p_paramname1")]
			public string ParamName1 { get; set; }

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