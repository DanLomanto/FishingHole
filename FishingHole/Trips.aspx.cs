using System;
using System.Collections.Generic;
using System.Web.UI;
using Common;

namespace FishingHole
{
	public partial class Trips : Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			LoadTripsGrid();
		}

		/// <summary>
		/// Deletes the trip.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void DeleteTrip(object sender, EventArgs e)
		{
			int tripToDeleteId = Convert.ToInt32(tripToDelete.Value);

			TripObject.DeleteTrip(tripToDeleteId);
		}

		#region Private Methods

		/// <summary>
		/// Loads the trips grid.
		/// </summary>
		private void LoadTripsGrid()
		{
			yourTripsTableBody.InnerHtml = string.Empty;

			List<TripObject> trips = TripObject.GetTripsForUser(Master.UsersInfo.ID);

			foreach (TripObject trip in trips)
			{
				yourTripsTableBody.InnerHtml = yourTripsTableBody.InnerHtml + "<tr>" +
												"<td class=\"text-center\">" +
													"<a class=\"btn-sm btn-primary\" href=\"Trip.aspx?id=" + trip.ID.ToString() + "&returnUrl=Trips\" style=\"text-decoration:none; margin-right:10px;\"><span><i class=\"fa fa-pencil-square-o\"></i>&nbsp;Select</span></a>" +
													"<a class=\"btn-sm btn-default\" style=\"text-decoration:none;\" href=\"#\" data-toggle=\"modal\" data-target=\"#confirmTripDeletion\" onclick=\"document.getElementById('MainContent_tripToDelete').value = '" + trip.ID.ToString() + "';\"><span><i class=\"fa fa-trash-o\"></i>&nbsp;Delete</span></a>" +
												"</td>" +
												"<td>" + trip.Title + "</td>" +
												"<td>" + trip.Description + "</td>" +
												"<td>" + trip.TargetedSpecies + "</td>" +
												"<td>" + trip.WaterConditions + "</td>" +
												"<td>" + trip.WeatherConditions + "</td>" +
												"<td>" + trip.TripDate + "</td>" +
												"<td>" + trip.FliesLuresUsed + "</td>" +
												"<td>" + trip.CatchOfTheDay + "</td>" +
												"<td>" + trip.CreateDate.ToString("MM/dd/yyyy") + "</td>" +
											"</tr>";
			}

			if (trips.Count > 0)
			{
				NoTripsMessage.Visible = false;
			}
			else
			{
				NoTripsMessage.Visible = true;
				yourTripsTableBody.Visible = false;
			}
		}

		#endregion Private Methods
	}
}