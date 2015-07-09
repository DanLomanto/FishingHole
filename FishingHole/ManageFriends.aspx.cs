using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace FishingHole
{
	public partial class ManageFriends : System.Web.UI.Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				LoadDataOnPage();
			}
		}

		/// <summary>
		/// Deletes the friend.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void DeleteFriend(object sender, EventArgs e)
		{
			int idOfFriendToDelete = Convert.ToInt32(selectedFriendId.Value);

			FriendActions.DeleteFriendAssociation(Master.UsersInfo.ID, idOfFriendToDelete);

			LoadDataOnPage();
		}

		/// <summary>
		/// Accepts the friend request.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void AcceptFriendRequest(object sender, EventArgs e)
		{
			int idOfNewFriend = Convert.ToInt32(acceptDenyFriendRequestId.Value);

			FriendActions.MakePendingFriendActualFriend(idOfNewFriend, Master.UsersInfo.ID);

			LoadDataOnPage();

			Master.LoadMenu();
		}

		/// <summary>
		/// Declines the friend request.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void DeclineFriendRequest(object sender, EventArgs e)
		{
			int idOfPersonToDecline = Convert.ToInt32(acceptDenyFriendRequestId.Value);

			FriendActions.DeletePendingFriendRequest(idOfPersonToDecline, Master.UsersInfo.ID);

			LoadDataOnPage();

			Master.LoadMenu();
		}

		/// <summary>
		/// Loads the data on page.
		/// </summary>
		private void LoadDataOnPage()
		{
			LoadFriendRequests();

			LoadFriends();
		}

		/// <summary>
		/// Loads the friends.
		/// </summary>
		private void LoadFriends()
		{
			List<UserInformation> friends = FriendActions.GetFriendsForUser(Master.UsersInfo.ID);
			//Resetting the friends section.
			FriendsList.InnerHtml = string.Empty;

			if (friends.Count > 0)
			{
				int friendCounter = 0;
				foreach (UserInformation friend in friends)
				{
					if (friendCounter % 4 == 0)
					{
						FriendsList.InnerHtml = FriendsList.InnerHtml + "<div class=\"row\"><div class=\"container-fluid\">";
					}

					FriendsList.InnerHtml = FriendsList.InnerHtml + "<div class=\"col-xs-12 col-sm-4 col-md-3\">" +
										"<div class=\"well user-padding\">" +
											"<div class=\"row\">" +
												"<button type=\"button\" data-toggle=\"modal\" data-target=\"#confirmDeletionModal\" class=\"close pull-right\" onclick=\"document.getElementById('MainContent_selectedFriendId').value = '" + friend.ID + "';\">&times;</button>" +
											"</div>" +
											"<div class=\"row text-center\">" +
												"<span><strong>" + friend.FirstName + " " + friend.LastName + "</strong></span>" +
											"</div>" +
											"<div class=\"row text-center\">" +
												"<span>" + friend.Email + "</span>" +
											"</div>" +
										"</div>" +
									"</div>";

					if (friendCounter % 4 == 3 || friends.Last() == friend)
					{
						FriendsList.InnerHtml = FriendsList.InnerHtml + "</div></div>";
					}

					friendCounter++;
				}
			}
			else
			{
				FriendsList.InnerHtml = "<div class=\"row\">" +
											 "<span>You have not added any friends yet...</span>" +
										 "</div>";
			}
		}

		/// <summary>
		/// Loads the friend requests.
		/// </summary>
		private void LoadFriendRequests()
		{
			List<UserInformation> friendRequests = FriendActions.GetFriendRequestsForUser(Master.UsersInfo.ID);

			//Resetting the friend requests section.
			FriendRequestContainer.InnerHtml = string.Empty;

			if (friendRequests.Count > 0)
			{
				FriendRequestPanel.Visible = true;

				int friendCounter = 0;
				foreach (UserInformation friend in friendRequests)
				{
					if (friendCounter % 4 == 0)
					{
						FriendRequestContainer.InnerHtml = FriendRequestContainer.InnerHtml + "<div class=\"row\"><div class=\"container-fluid\">";
					}

					FriendRequestContainer.InnerHtml = FriendRequestContainer.InnerHtml + "<div class=\"col-xs-12 col-sm-4 col-md-3\">" +
										"<div class=\"well user-padding\">" +
											"<div class=\"row text-center\">" +
												"<span><strong>" + friend.FirstName + " " + friend.LastName + "</strong></span>" +
											"</div>" +
											"<div class=\"row text-center\">" +
												"<span>" + friend.Email + "</span>" +
											"</div>" +
											"<div class=\"row text-center top-buffer\">" +
												"<button type=\"button\" data-toggle=\"modal\" data-target=\"#acceptFriendRequestModal\" class=\"btn-sm btn-primary\" onclick=\"document.getElementById('MainContent_acceptDenyFriendRequestId').value = '" + friend.ID + "';\" style=\"margin-right: 5px;\" >Accept</button>" +
												"<button type=\"button\" data-toggle=\"modal\" data-target=\"#declineFriendRequestModal\" class=\"btn-sm btn-primary\" onclick=\"document.getElementById('MainContent_acceptDenyFriendRequestId').value = '" + friend.ID + "';\" style=\"margin-left: 5px;\" >Decline</button>" +
											"</div>" +
						//"<div class=\"row text-center top-buffer\">" +
						//	"<button type=\"button\" data-toggle=\"modal\" data-target=\"#declineFriendRequestModal\" class=\"btn-sm btn-primary\" onclick=\"document.getElementById('MainContent_acceptDeclineFriendRequestId').value = '" + friend.ID + "';\">Decline Request</button>" +
						//"</div>" +
										"</div>" +
									"</div>";

					if (friendCounter % 4 == 3 || friendRequests.Last() == friend)
					{
						FriendRequestContainer.InnerHtml = FriendRequestContainer.InnerHtml + "</div></div>";
					}

					friendCounter++;
				}
			}
			else
			{
				FriendRequestPanel.Visible = false;
			}
		}
	}
}