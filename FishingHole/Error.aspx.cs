using System;
using System.Web.UI;

namespace FishingHole
{
	public partial class Error : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Master.FindControl("navMenu").Visible = false;
		}
	}
}