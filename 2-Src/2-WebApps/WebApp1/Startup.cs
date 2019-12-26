using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;

using Owin;
using Shared.Databases.DB2;
using Shared.Databases.DB2.AppContext;

[assembly: OwinStartup(typeof(WebApp1.Startup))]

namespace WebApp1
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
