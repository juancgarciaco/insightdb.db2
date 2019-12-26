using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public static partial class ValidatorHelper
	{
		public static IList<ValidationResult> ValidateModel(object obj)
		{
			var resultValidations = new List<ValidationResult>();
			var contexto = new ValidationContext(obj, null, null);
			System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, contexto, resultValidations, true);
			return resultValidations;
		}

	}
	#region Validators

	#endregion Validators

}
