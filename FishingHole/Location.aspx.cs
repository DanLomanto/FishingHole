using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace FishingHole
{
	public partial class Location : Page
	{
		#region Properties

		/// <summary>
		/// The form validation errors
		/// </summary>
		private List<string> formValidationErrors;

		#endregion Properties

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				PopulateTripsDropDown();

				PopulateLocationInfo();

				SetAssociatedTrip();
			}
		}

		/// <summary>
		/// Handles the Click event of the CancelButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void CancelButton_Click(object sender, EventArgs e)
		{
			performProperRedirect(Request.QueryString["returnUrl"]);
		}

		/// <summary>
		/// Handles the Click event of the SaveButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void SaveButton_Click(object sender, EventArgs e)
		{
			LocationObject location = new LocationObject();
			location.Name = LocationName.Value.Trim();
			location.Description = Description.Value.Trim();

			#region Field Validation

			formValidationErrors = new List<string>();

			if (string.IsNullOrWhiteSpace(location.Name))
			{
				formValidationErrors.Add("You must enter a value for the Name.");
			}

			if (locationType.Value == "SelectOption")
			{
				formValidationErrors.Add("You must specify a way to enter your location info.");
			}
			else if (locationType.Value == "StreetAddress")
			{
				if (string.IsNullOrWhiteSpace(StreetAddress.Value.Trim()) ||
					string.IsNullOrWhiteSpace(CityTown.Value.Trim()) ||
					string.IsNullOrWhiteSpace(States.Value.Trim()) ||
					string.IsNullOrWhiteSpace(ZipCode.Value.Trim()))
				{
					formValidationErrors.Add("You must enter all information for the location's address.");
				}
			}
			else if (locationType.Value == "Coordinates")
			{
				if (string.IsNullOrWhiteSpace(Lattitude.Value.Trim()) ||
					string.IsNullOrWhiteSpace(LattitudeDropDown.Value.Trim()) ||
					string.IsNullOrWhiteSpace(Longitude.Value.Trim()) ||
					string.IsNullOrWhiteSpace(LongitudeDropDown.Value.Trim()))
				{
					formValidationErrors.Add("You must enter all information for the location's coordinates.");
				}
			}

			if (formValidationErrors.Count > 0)
			{
				formErrors.CssClass = formErrors.CssClass + " has-error";
				formErrors.ForeColor = Color.Red;
				formErrors.DataSource = formValidationErrors;
				formErrors.DataBind();
				return;
			}

			#endregion Field Validation

			if (locationType.SelectedIndex == 1)
			{
				location.StreetAddress = StreetAddress.Value;
				location.CityTown = CityTown.Value;
				location.State = States.Value;
				location.Zipcode = Convert.ToInt32(ZipCode.Value);

				location.Lattitude = null;
				location.LattitudeDirection = null;
				location.Longitude = null;
				location.LongitudeDirection = null;
			}
			else if (locationType.SelectedIndex == 2)
			{
				location.StreetAddress = null;
				location.CityTown = null;
				location.State = null;
				location.Zipcode = null;

				location.Lattitude = Convert.ToDecimal(Lattitude.Value);
				location.LattitudeDirection = LattitudeDropDown.Value;
				location.Longitude = Convert.ToDecimal(Longitude.Value);
				location.LongitudeDirection = LongitudeDropDown.Value;
			}

			string queryStringId = Request.QueryString["id"];
			if (!string.IsNullOrWhiteSpace(queryStringId))
			{
				int id = Convert.ToInt32(queryStringId);
				if (id > 0)
				{
					location.ID = id;
					location.UpdateLocation();
				}
				else
				{
					location.ID = location.CreateLocation(Master.UsersInfo.ID);
				}
			}
			else
			{
				location.ID = location.CreateLocation(Master.UsersInfo.ID);
			}

			if (AssociatedTrip.Value == "-1")
			{
				LocationObject.DeleteTripForLocation(location.ID);
			}
			else
			{
				TripObject.CreateUpdateLocationForTrip(Convert.ToInt32(AssociatedTrip.Value), location.ID);
			}

			performProperRedirect(Request.QueryString["returnUrl"]);
		}

		#region Private Methods

		/// <summary>
		/// Sets the google maps URL.
		/// </summary>
		/// <param name="locationToAppendOnLink">The location to append on link.</param>
		private void SetGoogleMapsUrl(LocationObject location)
		{
			GoogleMap.Src = location.GetGoogleMapsUrl();
			OpenLocationInGoogleMaps.HRef = "https://www.google.com/maps/place/" + location.FormatGoogleMapsLocationInfo();
			LocationMapInfo.Visible = true;
		}

		/// <summary>
		/// Performs the proper redirect.
		/// </summary>
		/// <param name="returnUrlParameter">The return URL parameter.</param>
		private void performProperRedirect(string returnUrlParameter)
		{
			if (!string.IsNullOrWhiteSpace(returnUrlParameter) && returnUrlParameter.ToUpper() == "LOCATIONS")
			{
				Response.Redirect("Locations.aspx");
			}

			Response.Redirect("Dashboard.aspx");
		}

		/// <summary>
		/// Populates the trips drop down.
		/// </summary>
		private void PopulateTripsDropDown()
		{
			AssociatedTrip.Items.Add(new ListItem("Please select a Trip...", "-1"));

			foreach (TripObject trip in TripObject.GetTripsForUser(Master.UsersInfo.ID))
			{
				AssociatedTrip.Items.Add(new ListItem(trip.Title, trip.ID.ToString()));
			}

			AssociatedTrip.DataBind();
		}

		/// <summary>
		/// Populates the trip information.
		/// </summary>
		private void PopulateLocationInfo()
		{
			string queryStringId = Request.QueryString["id"];
			if (!string.IsNullOrWhiteSpace(queryStringId))
			{
				int locationId = Convert.ToInt32(queryStringId);
				if (locationId > 0)
				{
					LocationObject location = LocationObject.GetLocationById(locationId);
					LocationName.Value = location.Name;
					Description.Value = location.Description;
					StreetAddress.Value = location.StreetAddress;
					CityTown.Value = location.CityTown;
					States.SelectedIndex = States.Items.IndexOf(States.Items.FindByValue(location.State));
					ZipCode.Value = location.Zipcode.ToString();
					Lattitude.Value = location.Lattitude.ToString();
					LattitudeDropDown.SelectedIndex = LattitudeDropDown.Items.IndexOf(LattitudeDropDown.Items.FindByValue(location.LattitudeDirection));
					Longitude.Value = location.Longitude.ToString();
					LongitudeDropDown.SelectedIndex = LongitudeDropDown.Items.IndexOf(LongitudeDropDown.Items.FindByValue(location.LongitudeDirection));

					int associatedLocationId = TripObject.GetTripIdForLocation(locationId);
					if (associatedLocationId > 0)
					{
						AssociatedTrip.SelectedIndex = AssociatedTrip.Items.IndexOf(AssociatedTrip.Items.FindByValue(associatedLocationId.ToString()));
					}
					else
					{
						AssociatedTrip.SelectedIndex = 0;
					}

					if (!string.IsNullOrWhiteSpace(location.StreetAddress))
					{
						locationType.SelectedIndex = 1;
						Lattitude.Value = string.Empty;
						LattitudeDropDown.SelectedIndex = 0;
						Longitude.Value = string.Empty;
						LongitudeDropDown.SelectedIndex = 0;

						SetGoogleMapsUrl(location);
					}
					else if (location.Lattitude != null || location.Lattitude > 0)
					{
						locationType.SelectedIndex = 2;
						StreetAddress.Value = string.Empty;
						CityTown.Value = string.Empty;
						States.SelectedIndex = 0;
						ZipCode.Value = string.Empty;

						SetGoogleMapsUrl(location);
					}
					else
					{
						locationType.SelectedIndex = 0;
						Lattitude.Value = string.Empty;
						LattitudeDropDown.SelectedIndex = 0;
						Longitude.Value = string.Empty;
						LongitudeDropDown.SelectedIndex = 0;
						StreetAddress.Value = string.Empty;
						CityTown.Value = string.Empty;
						States.SelectedIndex = 0;
						ZipCode.Value = string.Empty;
					}

					location.MarkLocationAsViewed();
				}
			}
		}

		/// <summary>
		/// Sets the associated trip.
		/// </summary>
		private void SetAssociatedTrip()
		{
			string tripId = Request.QueryString["tripId"];
			if (!string.IsNullOrWhiteSpace(tripId))
			{
				AssociatedTrip.SelectedIndex = AssociatedTrip.Items.IndexOf(AssociatedTrip.Items.FindByValue(tripId));
			}
		}

		#endregion Private Methods
	}
}