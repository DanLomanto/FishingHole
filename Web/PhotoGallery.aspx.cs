using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;

//using System.Web.UI.WebControls;
using Common;

public partial class PhotoGallery : Page
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
	private const int numberOfImagesDisplayedInGallery = 20;

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
			PopulateFilterByTripDropDown();

			PopulateTripsDropDown();
		}

		string queryStringTripId = Request.QueryString["tripId"];
		if (!string.IsNullOrWhiteSpace(queryStringTripId))
		{
			int id = Convert.ToInt32(queryStringTripId);
			if (id > 0)
			{
				FilterByTripDropDown.SelectedIndex = FilterByTripDropDown.Items.IndexOf(FilterByTripDropDown.Items.FindByValue(queryStringTripId.ToString()));
			}
		}

		LoadPhotoGalleryImages();
	}

	/// <summary>
	/// The Click action for the Next button in the Photo Gallery.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void nextTwentyImages_Click(object sender, EventArgs e)
	{
		photoGalleryIndex = photoGalleryIndex + numberOfImagesDisplayedInGallery;
		prevTwentyImages.Visible = true;
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
		nextTwentyImages.Visible = true;
		LoadPhotoGalleryImages();
	}

	/// <summary>
	/// Handles the DataBound event of the photoGalleryChecklist control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void photoGalleryChecklist_DataBound(object sender, EventArgs e)
	{
		LoadPhotoGalleryImages();
	}

	/// <summary>
	/// Handles the Click event of the ApplyTripAssociation control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void ApplyTripAssociation_Click(object sender, EventArgs e)
	{
		if (TripAssociationDropDown.SelectedValue != "-1")
		{
			List<int> selectedImages = GetIdsOfSelectedImages();
			foreach (int imageId in selectedImages)
			{
				PhotoActions.CreatePhotoToTripAssociation(Convert.ToInt32(TripAssociationDropDown.SelectedValue), imageId);
			}
		}
	}

	/// <summary>
	/// Handles the Click event of the FilterPhotosBtn control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void FilterPhotosBtn_Click(object sender, EventArgs e)
	{
		// Just cause a post back
	}

	#region Private Methods


	/// <summary>
	/// Loads the photo gallery images.
	/// </summary>
	/// <param name="assocTripId">The assoc trip identifier.</param>
	private void LoadPhotoGalleryImages()
	{
		List<KeyValuePair<int, string>> usersPhotoGallery = null;
		int assocTripId = Convert.ToInt32(FilterByTripDropDown.SelectedValue);
		if (assocTripId > 0)
		{
			usersPhotoGallery = PhotoActions.GetPhotosForTrip(assocTripId);
		}
		else
		{
			usersPhotoGallery = UserActions.GetImagesForUser(Master.UsersInfo.ID);
		}

		List<KeyValuePair<int, string>> twentyImagesToDisplay = new List<KeyValuePair<int, string>>();

		if (usersPhotoGallery.Count < numberOfImagesDisplayedInGallery)
		{
			twentyImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, usersPhotoGallery.Count);

			nextTwentyImages.Visible = false;
			prevTwentyImages.Visible = false;
		}
		else
		{
			if (photoGalleryIndex == 0)
			{
				prevTwentyImages.Visible = false;
			}

			if ((usersPhotoGallery.Count / (numberOfImagesDisplayedInGallery + photoGalleryIndex)) >= 1)
			{
				twentyImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, numberOfImagesDisplayedInGallery);
			}
			else
			{
				twentyImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, usersPhotoGallery.Count % numberOfImagesDisplayedInGallery);
				nextTwentyImages.Visible = false;
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
		foreach (KeyValuePair<int, string> imageInfo in twentyImagesToDisplay)
		{
			HtmlGenericControl li = new HtmlGenericControl("li");
			li.Attributes.Add("class", "col-md-3 text-center");
			li.Attributes.Add("style", "list-style-type: none;");

			HtmlInputCheckBox checkbox = new HtmlInputCheckBox();
			checkbox.Value = imageInfo.Key.ToString();
			checkbox.Attributes.Add("style", "vertical-align: top; margin-right:5px");

			HtmlImage image = new HtmlImage();
			image.Src = imageInfo.Value;
			image.Height = 100;
			image.Width = 100;
			image.Attributes.Add("data-target", "#lightbox");
			image.Attributes.Add("data-toggle", "modal");

			li.Controls.Add(checkbox);
			li.Controls.Add(image);
			photoGallery.Controls.Add(li);
		}
	}

	/// <summary>
	/// Gets the ids of selected images.
	/// </summary>
	/// <returns></returns>
	private List<int> GetIdsOfSelectedImages()
	{
		List<int> selectedImages = new List<int>();

		foreach (Control listItem in photoGallery.Controls)
		{
			foreach (Control possibleCheckbox in listItem.Controls)
			{
				if (possibleCheckbox is System.Web.UI.HtmlControls.HtmlInputCheckBox)
				{
					System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox = (System.Web.UI.HtmlControls.HtmlInputCheckBox)possibleCheckbox;
					if (checkbox.Checked)
					{
						selectedImages.Add(Convert.ToInt32(checkbox.Value));
					}
				}
			}
		}

		return selectedImages;
	}

	/// <summary>
	/// Populates the trips drop down.
	/// </summary>
	private void PopulateTripsDropDown()
	{
		TripAssociationDropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select a Trip...", "-1"));

		foreach (DataRow row in TripObject.GetTripsForUser(Master.UsersInfo.ID).Rows)
		{
			TripAssociationDropDown.Items.Add(new System.Web.UI.WebControls.ListItem(row["Title"].ToString(), row["ID"].ToString()));
		}

		TripAssociationDropDown.DataBind();
	}

	/// <summary>
	/// Populates the filter by trip drop down.
	/// </summary>
	private void PopulateFilterByTripDropDown()
	{
		FilterByTripDropDown.Items.Add(new System.Web.UI.WebControls.ListItem("All", "-1"));

		foreach (DataRow row in TripObject.GetTripsForUser(Master.UsersInfo.ID).Rows)
		{
			FilterByTripDropDown.Items.Add(new System.Web.UI.WebControls.ListItem(row["Title"].ToString(), row["ID"].ToString()));
		}

		FilterByTripDropDown.DataBind();
	}

	#endregion Private Methods
}