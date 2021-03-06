﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using Common;

namespace FishingHole
{
	public partial class ShareLocation : System.Web.UI.Page
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
				PopulateLocationsDropDown();

				PopulateFriendsDropDown();

				IntializePeopleToShareWithInput();
			}

			LocationSharedNotification.Visible = false;
		}

		/// <summary>
		/// Handles the Click event of the ShareLocationWithFriends control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void ShareLocationWithFriends_Click(object sender, EventArgs e)
		{
			List<string> formValidationErrors = new List<string>();

			if (locationsDropDown.SelectedValue == "-1")
			{
				formValidationErrors.Add("You must select a valid Location to share.");
			}

			if (selectedPeople.Value == "|")
			{
				formValidationErrors.Add("You must select a valid friend.");
			}

			formErrors.CssClass = formErrors.CssClass + " has-error";
			formErrors.ForeColor = Color.Red;
			formErrors.DataSource = formValidationErrors;
			formErrors.DataBind();

			if (formValidationErrors.Count > 0)
			{
				return;
			}

			string[] idsOfSelectedPeople = selectedPeople.Value.Split('|');
			idsOfSelectedPeople = idsOfSelectedPeople.Where(w => w != string.Empty).ToArray();

			foreach (string friendId in idsOfSelectedPeople)
			{
				LocationObject.ShareLocation(Convert.ToInt32(locationsDropDown.SelectedValue), Convert.ToInt32(friendId));
			}

			IntializePeopleToShareWithInput();

			LocationSharedNotification.Visible = true;
		}

		#region Private Methods

		/// <summary>
		/// Populates the locations drop down.
		/// </summary>
		private void PopulateLocationsDropDown()
		{
			locationsDropDown.Items.Add(new ListItem("Please select a location...", "-1"));

			foreach (LocationObject location in LocationObject.GetLocationsForUser(Master.UsersInfo.ID))
			{
				locationsDropDown.Items.Add(new ListItem(location.Name, location.ID.ToString()));
			}

			locationsDropDown.DataBind();
		}

		/// <summary>
		/// Populates the friends drop down.
		/// </summary>
		private void PopulateFriendsDropDown()
		{
			friendsDropDown.Items.Add(new ListItem("Please select a friend...", "-1"));

			foreach (UserInformation friend in FriendActions.GetFriendsForUser(Master.UsersInfo.ID))
			{
				friendsDropDown.Items.Add(new ListItem(friend.FirstName + " " + friend.LastName, friend.ID.ToString()));
			}

			friendsDropDown.DataBind();
		}

		/// <summary>
		/// Intializes the people to share with input.
		/// </summary>
		private void IntializePeopleToShareWithInput()
		{
			selectedPeople.Value = "|";
		}

		#endregion Private Methods
	}
}