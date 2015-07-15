using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Common;

namespace FishingHole
{
	public class Global : HttpApplication
	{
		private void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		private void Application_Error(object sender, EventArgs e)
		{
			try
			{
				Exception ex = Server.GetLastError().GetBaseException();

				ErrorHandling error = new ErrorHandling();
				error.ReferringPage = ex.Source;
				error.ErrorText = ex.Message;

				error.LogErrorInDb();
			}
			finally
			{
				Response.Redirect("Error.aspx");
			}
		}
	}
}