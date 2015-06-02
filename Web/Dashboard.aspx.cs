using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Common;

public partial class Dashboard : Page
{
	#region Properties

	/// <summary>
	/// Gets or sets the index of the photo gallery.
	/// </summary>
	/// <value>
	/// The index of the photo gallery.
	/// </value>
	private int photoGalleryIndex
	{
		get
		{
			try
			{
				return Convert.ToInt32(ViewState["photoGalleryIndex"]);
			}
			catch
			{
				return 0;
			}
		}
		set
		{
			ViewState["photoGalleryIndex"] = value;
		}
	}

	/// <summary>
	/// The number of images displayed in the gallery at once.
	/// </summary>
	private const int numberOfImagesDisplayedInGallery = 8;

	#endregion Properties

	/// <summary>
	/// Handles the Load event of the Page control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void Page_Load(object sender, EventArgs e)
	{
		LoadPhotoGalleryImages();

		TripsDataGrid.Columns[0].Visible = true;
		TripsDataGrid.DataSource = TripGridViewModel.GetTopFiveTripsForUser(Master.UsersInfo.ID);
		TripsDataGrid.DataBind();
		TripsDataGrid.Columns[0].Visible = false;
		Session["TripsData"] = TripsDataGrid.DataSource;
		if (TripsDataGrid.Rows.Count > 0)
		{
			RecentlyAddedTripsMessage.Visible = true;
			NoTripsMessage.Visible = false;
		}
		else
		{
			RecentlyAddedTripsMessage.Visible = false;
			NoTripsMessage.Visible = true;
		}

		LocationsGrid.Columns[0].Visible = true;
		LocationsGrid.DataSource = LocationsGridViewModel.GetTopFiveLocationsForUser(Master.UsersInfo.ID);
		LocationsGrid.DataBind();
		LocationsGrid.Columns[0].Visible = false;
		Session["LocationsData"] = LocationsGrid.DataSource;
		if (LocationsGrid.Rows.Count > 0)
		{
			RecentlyAddedLocationsMessage.Visible = true;
			NoLocationsMessage.Visible = false;
		}
		else
		{
			RecentlyAddedLocationsMessage.Visible = false;
			NoLocationsMessage.Visible = true;
		}
	}

	/// <summary>
	/// Hiddens the close upload photo modal click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void HiddenCloseUploadPhotoModalClick(object sender, EventArgs e)
	{ }

	/// <summary>
	/// The Click action for the Next button in the Photo Gallery.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void nextTwentyImages_Click(object sender, EventArgs e)
	{
		photoGalleryIndex = photoGalleryIndex + numberOfImagesDisplayedInGallery;
		LoadPhotoGalleryImages();
	}

	/// <summary>
	/// The Click action for the Previous button in the Photo Gallery.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void prevTwentyImages_Click(object sender, EventArgs e)
	{
		photoGalleryIndex = photoGalleryIndex - numberOfImagesDisplayedInGallery;
		LoadPhotoGalleryImages();
	}

	/// <summary>
	/// Handles the Sorting event of the LocationsGrid control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
	protected void LocationsGrid_Sorting(object sender, GridViewSortEventArgs e)
	{
		//Retrieve the table from the session object.
		DataTable dt = Session["LocationsData"] as DataTable;

		if (dt != null)
		{
			//Sort the data.
			dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
			LocationsGrid.DataSource = dt;
			LocationsGrid.DataBind();
		}
	}

	/// <summary>
	/// Handles the Sorting event of the TripsDataGrid control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
	protected void TripsDataGrid_Sorting(object sender, GridViewSortEventArgs e)
	{
		//Retrieve the table from the session object.
		DataTable dt = Session["TripsData"] as DataTable;

		if (dt != null)
		{
			//Sort the data.
			dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
			TripsDataGrid.DataSource = dt;
			TripsDataGrid.DataBind();
		}
	}

	/// <summary>
	/// Called when [trips row data bound].
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
	protected void OnTripsRowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(TripsDataGrid, "Select$" + e.Row.RowIndex);
			e.Row.Attributes["style"] = "cursor:pointer";
		}
	}

	/// <summary>
	/// Called when [locations row data bound].
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
	protected void OnLocationsRowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LocationsGrid, "Select$" + e.Row.RowIndex);
			e.Row.Attributes["style"] = "cursor:pointer";
		}
	}

	/// <summary>
	/// Called when [locations selected index changed].
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void OnLocationsSelectedIndexChanged(object sender, EventArgs e)
	{
		string id = LocationsGrid.SelectedRow.Cells[0].Text;

		Response.Redirect("Location?id=" + id);
	}

	/// <summary>
	/// Called when [trips selected index changed].
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void OnTripsSelectedIndexChanged(object sender, EventArgs e)
	{
		string id = TripsDataGrid.SelectedRow.Cells[0].Text;

		Response.Redirect("Trip?id=" + id);
	}

	/// <summary>
	/// Handles the Click event of the AddTrip control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void AddTrip_Click(object sender, EventArgs e)
	{
		Response.Redirect("Trip?id=0");
	}

	#region Private Methods

	/// <summary>
	/// Loads the photo gallery images.
	/// </summary>
	private void LoadPhotoGalleryImages()
	{
		List<KeyValuePair<int, string>> usersPhotoGallery = PhotoActions.GetImagesForUser(Master.UsersInfo.ID);

		List<KeyValuePair<int, string>> twentyImagesToDisplay = new List<KeyValuePair<int, string>>();

		if (usersPhotoGallery.Count < numberOfImagesDisplayedInGallery)
		{
			twentyImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, usersPhotoGallery.Count);
		}
		else
		{
			if ((usersPhotoGallery.Count / (numberOfImagesDisplayedInGallery + photoGalleryIndex)) >= 1)
			{
				twentyImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, numberOfImagesDisplayedInGallery);
			}
			else
			{
				twentyImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, usersPhotoGallery.Count % numberOfImagesDisplayedInGallery);
			}
		}

		// Remove any existing images in the photo gallery so we can add only the ones we want to display.
		for (int i = 0; i < numberOfImagesDisplayedInGallery; i++)
		{
			if (photoGallery.HasControls())
			{
				photoGallery.Controls.RemoveAt(0);
			}
			else
			{ break; }
		}

		// Add the images we want to display in the gallery.
		foreach (KeyValuePair<int, string> imagePath in twentyImagesToDisplay)
		{
			HtmlGenericControl li = new HtmlGenericControl("li");
			li.Attributes.Add("class", "col-md-3 text-center");
			li.InnerHtml = "<img src='" + imagePath.Value + "' height='100px' width='100px' data-target=\"#lightbox\" data-toggle=\"modal\" />";

			photoGallery.Controls.Add(li);
		}
	}

	/// <summary>
	/// Gets the sort direction.
	/// </summary>
	/// <param name="column">The column.</param>
	/// <returns></returns>
	private string GetSortDirection(string column)
	{
		// By default, set the sort direction to ascending.
		string sortDirection = "ASC";

		// Retrieve the last column that was sorted.
		string sortExpression = ViewState["SortExpression"] as string;

		if (sortExpression != null)
		{
			// Check if the same column is being sorted.
			// Otherwise, the default value can be returned.
			if (sortExpression == column)
			{
				string lastDirection = ViewState["SortDirection"] as string;
				if ((lastDirection != null) && (lastDirection == "ASC"))
				{
					sortDirection = "DESC";
				}
			}
		}

		// Save new values in ViewState.
		ViewState["SortDirection"] = sortDirection;
		ViewState["SortExpression"] = column;

		return sortDirection;
	}

	#endregion Private Methods
}