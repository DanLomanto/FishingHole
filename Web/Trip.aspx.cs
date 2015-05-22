using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

public partial class Trip : Page
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
			PopulateLocationsDropDown();

			string queryStringId = Request.QueryString["id"];
			if (!string.IsNullOrWhiteSpace(queryStringId))
			{
				int id = Convert.ToInt32(queryStringId);
				if (id > 0)
				{
					TripObject trip = TripObject.GetTripById(id);
					TripTitle.Value = trip.Title;
					Description.Value = trip.Description;
					TargetedSpecies.Value = trip.TargetedSpecies;
					WaterConditions.Value = trip.WaterConditions;
					WeatherConditions.Value = trip.WeatherConditions;
					TripDate.Value = trip.TripDate;
					CatchOfTheDay.Value = trip.CatchOfTheDay;
					FliesLuresUsed.Value = trip.FliesLuresUsed;
					OtherNotes.Value = trip.OtherNotes;

					int associatedLocationId = LocationObject.GetAssociatedLocationForTrip(id);
					if (associatedLocationId > 0)
					{
						AssociatedLocation.SelectedIndex = AssociatedLocation.Items.IndexOf(AssociatedLocation.Items.FindByValue(associatedLocationId.ToString()));
					}
					else
					{
						AssociatedLocation.SelectedIndex = 0;
					}
				}
			}
		}
	}

	/// <summary>
	/// Handles the Click event of the SaveButton control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void SaveButton_Click(object sender, EventArgs e)
	{
		TripObject trip = new TripObject();
		trip.Title = TripTitle.Value.Trim();
		trip.Description = Description.Value.Trim();
		trip.TargetedSpecies = TargetedSpecies.Value.Trim();
		trip.WaterConditions = WaterConditions.Value.Trim();
		trip.WeatherConditions = WeatherConditions.Value.Trim();
		trip.TripDate = TripDate.Value;
		trip.CatchOfTheDay = CatchOfTheDay.Value.Trim();
		trip.FliesLuresUsed = FliesLuresUsed.Value.Trim();
		trip.OtherNotes = OtherNotes.Value.Trim();

		#region Field Validation

		formValidationErrors = new List<string>();

		if (string.IsNullOrWhiteSpace(trip.Title))
		{
			formErrors.CssClass = formErrors.CssClass + " has-error";
			formErrors.ForeColor = Color.Red;
			formErrors.DataSource = new List<string> { "You must enter a value for the Title." };
			formErrors.DataBind();
			return;
		}

		#endregion Field Validation

		//Save to DB and get ID.  Then reload with Query string
		string queryStringId = Request.QueryString["id"];
		int id = 0;
		if (!string.IsNullOrWhiteSpace(queryStringId))
		{
			id = Convert.ToInt32(queryStringId);
			if (id > 0)
			{
				trip.ID = id;
				trip.UpdateTrip(trip.ID);
			}
			else
			{
				id = trip.CreateTrip(Master.UsersInfo.ID);
			}
		}

		if (AssociatedLocation.Value == "-1")
		{
			TripObject.DeleteLocationForTrip(trip.ID);
		}
		else
		{
			TripObject.CreateUpdateLocationForTrip(trip.ID, Convert.ToInt32(AssociatedLocation.Value));
		}

		performProperRedirect(Request.QueryString["returnUrl"]);
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

	#region Private Methods

	/// <summary>
	/// Performs the proper redirect.
	/// </summary>
	/// <param name="returnUrlParameter">The return URL parameter.</param>
	private void performProperRedirect(string returnUrlParameter)
	{
		if (!string.IsNullOrWhiteSpace(returnUrlParameter) && returnUrlParameter.ToUpper() == "TRIPS")
		{
			Response.Redirect("Trips.aspx");
		}

		Response.Redirect("Dashboard.aspx");
	}

	/// <summary>
	/// Populates the locations drop down.
	/// </summary>
	private void PopulateLocationsDropDown()
	{
		AssociatedLocation.Items.Add(new ListItem("Please select a Location...", "-1"));

		foreach (DataRow row in LocationObject.GetLocationsForUser(Master.UsersInfo.ID).Rows)
		{
			AssociatedLocation.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
		}

		AssociatedLocation.DataBind();
	}

	#endregion Private Methods
}