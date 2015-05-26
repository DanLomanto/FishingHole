using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Common;

public partial class PhotoGallery : Page
{
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

	/// <summary>
	/// Handles the Load event of the Page control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void Page_Load(object sender, EventArgs e)
	{
		LoadPhotoGalleryImages();

		LoadPhotosInChecklist();
	}

	/// <summary>
	/// Loads the photo gallery images.
	/// </summary>
	private void LoadPhotoGalleryImages()
	{
		List<string> usersPhotoGallery = UserActions.GetImagesForUser(Master.UsersInfo.ID);

		List<string> twentyImagesToDisplay = new List<string>();

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
		foreach (string imagePath in twentyImagesToDisplay)
		{
			HtmlGenericControl li = new HtmlGenericControl("li");
			li.Attributes.Add("class", "col-md-3 text-center");
			li.InnerHtml = "<img src='" + imagePath + "' height='100px' width='100px' data-target=\"#lightbox\" data-toggle=\"modal\" />";

			photoGallery.Controls.Add(li);
		}
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

	protected void photoGalleryChecklist_DataBound(object sender, EventArgs e)
	{
		LoadPhotosInChecklist();
		
	}

	private void LoadPhotosInChecklist()
	{
		List<string> usersPhotoGallery = UserActions.GetImagesForUser(Master.UsersInfo.ID);

		List<string> twentyImagesToDisplay = new List<string>();

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
		foreach (string imagePath in twentyImagesToDisplay)
		{
			HtmlGenericControl li = new HtmlGenericControl("li");
			li.Attributes.Add("class", "col-md-3 text-center");
			li.InnerHtml = "<input type=\"checkbox\" style=\"vertical-align: top; margin-right:5px\" value=\"" + imagePath + "\" /><img src='" + imagePath + "' height='100px' width='100px' data-target=\"#lightbox\" data-toggle=\"modal\" />";

			photoGallery.Controls.Add(li);
		}
	}
}