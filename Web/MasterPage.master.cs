using System;
using Common;

public partial class MasterPage : System.Web.UI.MasterPage
{
	public UserInformation UsersInfo;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["Email"] != null || UsersInfo != null)
		{
			//UsernameDropDown.InnerText = UsersInfo.FirstName + " " + UsersInfo.LastName + "";
			UsernameDropDown.InnerHtml = UsersInfo.FirstName + " " + UsersInfo.LastName + "<span class=\"caret\"></span>";
		}
	}

	protected void Page_Init(object sender, EventArgs e)
	{
		if (Session["Email"] != null)
		{
			UsersInfo = UserActions.GetUserInfo(Session["Email"].ToString());
		}
	}

	protected void SignOut_Click(object sender, EventArgs e)
	{
		UsersInfo = null;
		Session.Clear();
		Response.Redirect("Login.aspx");
	}
}