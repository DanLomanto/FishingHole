using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
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
			formValidationErrors.Add("You must enter a value for the Title.");
		}

		if (TripObject.GetTrip(Master.UsersInfo.ID, trip.Title) != null)
		{
			formValidationErrors.Add("A Trip with this Title already exists.");
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

		//Save to DB and get ID.  Then reload with Query string
		string queryStringId = Request.QueryString["id"];
		int id = 0;
		if (!string.IsNullOrWhiteSpace(queryStringId))
		{
			id = Convert.ToInt32(queryStringId);
			if (id > 0)
			{
				trip.UpdateTrip(id);
			}
			else
			{
				id = trip.CreateTrip(Master.UsersInfo.ID);
			}
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

	private void performProperRedirect(string returnUrlParameter)
	{
		if (!string.IsNullOrWhiteSpace(returnUrlParameter) && returnUrlParameter.ToUpper() == "TRIPS")
		{
			Response.Redirect("Trips.aspx");
		}

		Response.Redirect("Dashboard.aspx");
	}
}