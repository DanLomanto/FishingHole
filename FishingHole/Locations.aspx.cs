using System;
using System.Collections.Generic;
using System.Web.UI;
using Common;

namespace FishingHole
{
	public partial class Locations : Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			LoadPersonalLocationsGrid();

			LoadSharedLocationsGrid();
		}

		/// <summary>
		/// Deletes the location.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void DeleteLocation(object sender, EventArgs e)
		{
			int locationToDeleteId = Convert.ToInt32(locationToDelete.Value);

			LocationObject.DeleteLocation(locationToDeleteId);
		}

		#region Private Methods

		/// <summary>
		/// Loads the personal locations grid.
		/// </summary>
		private void LoadPersonalLocationsGrid()
		{
			yourLocationsTableBody.InnerHtml = string.Empty;

			List<LocationObject> YourLocations = LocationObject.GetLocationsForUser(Master.UsersInfo.ID);

			foreach (LocationObject loc in YourLocations)
			{
				yourLocationsTableBody.InnerHtml = yourLocationsTableBody.InnerHtml + "<tr>" +
												"<td class=\"text-center\">" +
													"<a class=\"btn-sm btn-primary\" href=\"Location?id=" + loc.ID.ToString() + "&returnUrl=locations\" style=\"text-decoration:none; margin-right:10px;\"><span><i class=\"fa fa-pencil-square-o\"></i>&nbsp;Select</span></a>" +
													"<a class=\"btn-sm btn-default\" style=\"text-decoration:none;\" href=\"#\" data-toggle=\"modal\" data-target=\"#confirmLocationDeletion\" onclick=\"document.getElementById('MainContent_locationToDelete').value = '" + loc.ID.ToString() + "';\"><span><i class=\"fa fa-trash-o\"></i>&nbsp;Delete</span></a>" +
												"</td>" +
												"<td>" + loc.Name + "</td>" +
												"<td>" + loc.LatitudeDirection + "</td>" +
												"<td>" + loc.Latitude + "</td>" +
												"<td>" + loc.LongitudeDirection + "</td>" +
												"<td>" + loc.Longitude + "</td>" +
												"<td>" + loc.StreetAddress + "</td>" +
												"<td>" + loc.CityTown + "</td>" +
											"</tr>";
			}

			if (YourLocations.Count > 0)
			{
				NoLocationsMessage.Visible = false;
			}
			else
			{
				NoLocationsMessage.Visible = true;
				yourLocationsTableContainer.Visible = false;
			}
		}

		/// <summary>
		/// Loads the shared locations grid.
		/// </summary>
		private void LoadSharedLocationsGrid()
		{
			sharedLocationsTableBody.InnerHtml = string.Empty;

			List<LocationObject> SharedLocations = LocationObject.GetSharedLocationsForUser(Master.UsersInfo.ID);

			foreach (LocationObject loc in SharedLocations)
			{
				sharedLocationsTableBody.InnerHtml = sharedLocationsTableBody.InnerHtml + "<tr>" +
												"<td class=\"text-center\">" +
													"<a class=\"btn-sm btn-primary\" href=\"Location?id=" + loc.ID.ToString() + "&returnUrl=locations\" style=\"text-decoration:none; margin-right:10px;\"><span><i class=\"fa fa-pencil-square-o\"></i>&nbsp;Select</span></a>" +
													"<a class=\"btn-sm btn-default\" style=\"text-decoration:none;\" href=\"#\" data-toggle=\"modal\" data-target=\"#confirmLocationDeletion\" onclick=\"document.getElementById('MainContent_locationToDelete').value = '" + loc.ID.ToString() + "';\"><span><i class=\"fa fa-trash-o\"></i>&nbsp;Delete</span></a>" +
												"</td>";

				if (loc.HasLocationBeenViewed())
				{
					sharedLocationsTableBody.InnerHtml = sharedLocationsTableBody.InnerHtml + "<td>" + loc.Name + "</td>";
				}
				else
				{
					sharedLocationsTableBody.InnerHtml = sharedLocationsTableBody.InnerHtml + "<td>" + loc.Name + "&nbsp;<span class=\"label label-primary\"><i class=\"fa fa-star\"></i>&nbsp;New&nbsp;<i class=\"fa fa-star\"></i></span></td>";
				}

				sharedLocationsTableBody.InnerHtml = sharedLocationsTableBody.InnerHtml + "<td>" + loc.LatitudeDirection + "</td>" +
												"<td>" + loc.Latitude + "</td>" +
												"<td>" + loc.LongitudeDirection + "</td>" +
												"<td>" + loc.Longitude + "</td>" +
												"<td>" + loc.StreetAddress + "</td>" +
												"<td>" + loc.CityTown + "</td>" +
											"</tr>";
			}

			if (SharedLocations.Count > 0)
			{
				NoSharedLocationsText.Visible = false;
			}
			else
			{
				NoSharedLocationsText.Visible = true;
				sharedLocationsTableContainer.Visible = false;
			}
		}

		#endregion Private Methods
	}
}