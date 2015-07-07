using System;
using Common;

namespace FishingHole
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
		/// <summary>
		/// The logged in user's information
		/// </summary>
		public UserInformation UsersInfo;

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Email"] != null || UsersInfo != null)
			{
				LoadUserNameDropDown();
			}
		}

		/// <summary>
		/// Handles the Init event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Init(object sender, EventArgs e)
		{
			if (Session["Email"] != null)
			{
				UsersInfo = UserActions.GetUserInfo(Session["Email"].ToString());
			}
		}

		/// <summary>
		/// Handles the Click event of the SignOut control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void SignOut_Click(object sender, EventArgs e)
		{
			try
			{
				UsersInfo = null;
				Session.Clear();
			}
			finally
			{
				Response.Redirect("Login.aspx");
			}
		}

		#region Private Methods

		/// <summary>
		/// Loads the pending friend requests label.
		/// </summary>
		public void LoadUserNameDropDown()
		{
			int numberOfFriendRequests = FriendActions.GetFriendRequestsForUser(UsersInfo.ID).Count;

			if (numberOfFriendRequests > 0)
			{
				UsernameDropDown.InnerHtml = UsersInfo.FirstName + " " + UsersInfo.LastName + "&nbsp;<span class=\"label label-primary\">" + numberOfFriendRequests.ToString() + "</span>&nbsp;<span class=\"caret\"></span>";
				mobileFriendRequestNumber.InnerHtml = numberOfFriendRequests.ToString();
				friendRequestNumber.InnerHtml = numberOfFriendRequests.ToString();
			}
			else
			{
				UsernameDropDown.InnerHtml = UsersInfo.FirstName + " " + UsersInfo.LastName + "<span class=\"caret\"></span>";
				mobileFriendRequestNumber.InnerHtml = string.Empty;
				friendRequestNumber.InnerHtml = string.Empty;
			}
		}

		#endregion Private Methods
	}
}