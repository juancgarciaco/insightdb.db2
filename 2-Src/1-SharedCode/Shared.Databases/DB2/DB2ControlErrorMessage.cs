using Shared.Webapi.Models;
using IBM.Data.DB2;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Shared.Databases.DB2
{
	#region Database_Errors
	public static class DB2ControlErrorMessage
	{
		public static GenericMessageErrorModel GetErrorBaseMessage(Exception ex)
		{
			var baseEX = ex.GetBaseException();
			var baseEXType = ex.GetBaseException().GetType();
			int errorNativoBaseDatos = new int();

			GenericMessageErrorModel mensaje = new GenericMessageErrorModel("Error General", baseEX.Message, EstadosRetornoEnum.ERROR, baseEX.Source);

			if (baseEXType.Equals(typeof(SqlException)))
			{
				SqlException dbEx;
				dbEx = (baseEX as SqlException);

				mensaje.MessageTitle = "Error en base de datos";
				mensaje = GetErrorBaseMessage(dbEx);

				if (dbEx.Errors.Count >= 1)
				{
					//errorNativoBaseDatos = dbEx.ErrorCode; //INFORMIX
					errorNativoBaseDatos = dbEx.Number; // T-SQL
				}
				mensaje.ErrorNativoBaseDatos = errorNativoBaseDatos;
			}
			else if (baseEXType.Equals(typeof(DB2Exception)))
			{
				DB2Exception dbEx;
				dbEx = (baseEX as DB2Exception);

				mensaje.MessageTitle = "Error en base de datos";
				mensaje = GetErrorBaseMessage(dbEx);

				if (dbEx.Errors.Count >= 1)
				{
					errorNativoBaseDatos = dbEx.ErrorCode; //INFORMIX
														   //errorNativoBaseDatos = err0.Number; // T-SQL
				}
				mensaje.ErrorNativoBaseDatos = errorNativoBaseDatos;
			}
			else if (baseEXType.Equals(typeof(ApplicationException)))
			{
				mensaje.MessageTitle = "Error de aplicación controlado";
			}
			return mensaje;
		}

		internal static GenericMessageErrorModel GetErrorBaseMessage(SqlException exception)
		{
			var _messageResult = string.Empty;
			_messageResult = GetErrorBaseMessage(exception.Message);
			return new GenericMessageErrorModel("Repositorio de datos", _messageResult, EstadosRetornoEnum.ERROR, exception.ErrorCode.ToString());
		}

		internal static GenericMessageErrorModel GetErrorBaseMessage(DB2Exception exception)
		{
			var _messageResult = string.Empty;
			_messageResult = GetErrorBaseMessage(exception.Message);
			return new GenericMessageErrorModel("Repositorio de datos", _messageResult, EstadosRetornoEnum.ERRORBD, exception.ErrorCode.ToString());
		}

		internal static string GetErrorBaseMessage(string exceptionMessage)
		{
			string input = exceptionMessage;
			string _return = input;
			string pattern1 = @"(CLI(\d+)E)\s*";
			string pattern2 = @"ERROR\s*(\[?(\w+)?(\d+)\])\s*\[IBM\]\s*";
			string pattern3 = @"(\[IDS/?(\w+)?\])";
			string pattern4 = @"(SQLSTATE=(\d+))\s*";
			string pattern5 = @"(SQL(\d+)N)\s*";
			Regex rgx1 = new Regex(pattern1);
			Regex rgx2 = new Regex(pattern2);
			Regex rgx3 = new Regex(pattern3);
			Regex rgx4 = new Regex(pattern4);
			Regex rgx5 = new Regex(pattern5);

			_return = rgx5.Replace(
				rgx4.Replace(
					rgx3.Replace(
						rgx2.Replace(
							rgx1.Replace(input, "")
						, "")
					, "")
				, "")
			, "")
			.Split('\n')[0]
			//.Replace("[IDS/UNIX]", null)
			//.Replace("[IBM]", null)
			.Replace(System.Environment.NewLine, null)
			.Replace("\\n", "\n")
			.Trim()
			;
			return _return;
		}
	}
	#endregion
}
