using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Shared.Databases.DB2;
using Shared.Databases.DB2.AppContext;

namespace WebApp1
{
    public partial class Startup
    {

        public void ConfigureAuth(IAppBuilder app)
        {
			app.CreatePerOwinContext(ApplicationDbContext<DB2Context>.Create);

			//app.CreatePerOwinContext(() => ApplicationDbContext<DB2Context>.Create("Ebolenlinea_Connection", "EbolenlineaConnectionDb"));
		}
	}
}
