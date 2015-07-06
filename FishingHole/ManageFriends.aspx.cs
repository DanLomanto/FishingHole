using System;
using System.Collections.Generic;
using System.Linq;

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
			LoadFriends();
		}

		/// <summary>
		/// Deletes the friend.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void DeleteFriend(object sender, EventArgs e)
		{
			int idOfFriendToDelete = Convert.ToInt32(selectedFriendId.Value);
		}

		private void LoadFriends()
		{
			#region data setup

			Friend person1 = new Friend
			{
				ID = 1,
				FirstName = "Dan",
				LastName = "Lomanto",
				Email = "something@gmail.com"
			};
			Friend person2 = new Friend
			{
				ID = 2,
				FirstName = "Dan",
				LastName = "Lomanto",
				Email = "something@gmail.com"
			};
			Friend person3 = new Friend
			{
				ID = 3,
				FirstName = "Dan",
				LastName = "Lomanto",
				Email = "something@gmail.com"
			};
			Friend person4 = new Friend
			{
				ID = 4,
				FirstName = "Dan",
				LastName = "Lomanto",
				Email = "something@gmail.com"
			};

			Friend person5 = new Friend
			{
				ID = 5,
				FirstName = "Dan",
				LastName = "Lomanto",
				Email = "something@gmail.com"
			};
			Friend person6 = new Friend
			{
				ID = 6,
				FirstName = "Dan",
				LastName = "Lomanto",
				Email = "something@gmail.com"
			};
			Friend person7 = new Friend
			{
				ID = 7,
				FirstName = "Dan",
				LastName = "Lomanto",
				Email = "something@gmail.com"
			};
			Friend person8 = new Friend
			{
				ID = 8,
				FirstName = "Dan",
				LastName = "Lomanto",
				Email = "something@gmail.com"
			};

			List<Friend> Friends = new List<Friend>();
			Friends.Add(person1);
			Friends.Add(person2);
			Friends.Add(person3);
			Friends.Add(person4);
			Friends.Add(person5);
			Friends.Add(person6);
			Friends.Add(person7);
			Friends.Add(person8);

			#endregion data setup

			int numberOfThreads = FriendsList.Controls.Count;
			for (int i = 0; i < numberOfThreads; i++)
			{
				if (FriendsList.HasControls())
				{
					FriendsList.Controls.RemoveAt(0);
				}
				else
				{ break; }
			}

			int friendCounter = 0;
			foreach (Friend friend in Friends)
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

				if (friendCounter % 4 == 3 || Friends.Last() == friend)
				{
					FriendsList.InnerHtml = FriendsList.InnerHtml + "</div></div>";
				}

				friendCounter++;
			}
		}
	}

	public class Friend
	{
		public int ID;
		public string FirstName;
		public string LastName;
		public string Email;
	}
}