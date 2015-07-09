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
												"<td><a href=\"Location?id=" + loc.ID.ToString() + "&returnUrl=locations\">Select</a></td>" +
												"<td>" + loc.Name + "</td>" +
												"<td>" + loc.LattitudeDirection + "</td>" +
												"<td>" + loc.Lattitude + "</td>" +
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
												"<td><a href=\"Location?id=" + loc.ID.ToString() + "&returnUrl=locations\">Select</a></td>" +
												"<td>" + loc.Name + "</td>" +
												"<td>" + loc.LattitudeDirection + "</td>" +
												"<td>" + loc.Lattitude + "</td>" +
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
			}
		}

		#endregion Private Methods
	}
}