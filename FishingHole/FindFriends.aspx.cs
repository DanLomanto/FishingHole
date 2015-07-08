using System;
using System.Collections.Generic;
using Common;

namespace FishingHole
{
	public partial class FindFriends : System.Web.UI.Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			requestSentConfirmation.Visible = false;
		}

		/// <summary>
		/// Loads the search results.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void LoadSearchResults(object sender, EventArgs e)
		{
			GenerateSearchResults();
		}

		/// <summary>
		/// Sends the friend request.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void SendFriendRequest(object sender, EventArgs e)
		{
			FriendActions.CreatePendingFriendRequest(Master.UsersInfo.ID, Convert.ToInt32(sendFriendRequestPersonId.Value));

			GenerateSearchResults();

			requestSentConfirmation.Visible = true;
		}

		/// <summary>
		/// Generates the search results.
		/// </summary>
		/// <param name="searchText">The search text.</param>
		private void GenerateSearchResults()
		{
			string searchText = SearchFieldText.Value.Trim();
			searchResultsContainer.Visible = true;

			List<UserInformation> returnedUsers = FriendActions.SearchForUsers(Master.UsersInfo.ID, searchText);

			// Reset search results.
			searchResults.InnerHtml = string.Empty;

			if (returnedUsers.Count > 0)
			{
				int friendCounter = 0;
				foreach (UserInformation person in returnedUsers)
				{
					if (friendCounter % 2 == 0)
					{
						searchResults.InnerHtml = searchResults.InnerHtml + "<div class=\"row well\">";
					}
					else
					{
						searchResults.InnerHtml = searchResults.InnerHtml + "<div class=\"row well\" style=\"background:#ffffff\">";
					}

					searchResults.InnerHtml = searchResults.InnerHtml + "<span class=\"col-xs-12 col-sm-10\"><strong>" + person.LastName + ", " + person.FirstName +
									"</strong>&nbsp;(" + person.Email + ")</span>" +
									"<div class=\"col-xs-12 col-sm-1 text-center\">" +
										"<button type=\"button\" class=\"btn btn-sm btn-default\" data-toggle=\"modal\" data-target=\"#confirmSendRequest\" onclick=\"document.getElementById('MainContent_sendFriendRequestPersonId').value = '" + person.ID + "';\"><i class=\"fa fa-user-plus\"></i>&nbsp;Send Request</button>" +
									"</div>" +
								"</div>";

					friendCounter++;
				}
			}
			else
			{
				searchResults.InnerHtml = "<div class=\"row\">" +
												"<span>Sorry, your search did not return any results...</span>" +
											"</div>";
			}
		}
	}
}