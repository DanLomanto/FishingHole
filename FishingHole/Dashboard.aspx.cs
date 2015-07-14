using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Common;

namespace FishingHole
{
	/// <summary>
	///	The Dashboard page.
	/// </summary>
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

			LoadRecentlyAddedTripsGrid();

			LoadRecentlyAddedLocationsGrid();
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

		#region Private Methods

		/// <summary>
		/// Loads the photo gallery images.
		/// </summary>
		private void LoadPhotoGalleryImages()
		{
			List<KeyValuePair<int, string>> usersPhotoGallery = PhotoActions.GetImagesForUser(Master.UsersInfo.ID);

			if (usersPhotoGallery.Count == 0)
			{
				NoPhotosMessage.Visible = true;
				RecentlyAddedPhotosMessage.Visible = false;
				return;
			}

			List<KeyValuePair<int, string>> eightImagesToDisplay = new List<KeyValuePair<int, string>>();

			if (usersPhotoGallery.Count < numberOfImagesDisplayedInGallery)
			{
				eightImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, usersPhotoGallery.Count);
			}
			else
			{
				if ((usersPhotoGallery.Count / (numberOfImagesDisplayedInGallery + photoGalleryIndex)) >= 1)
				{
					eightImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, numberOfImagesDisplayedInGallery);
				}
				else
				{
					eightImagesToDisplay = usersPhotoGallery.GetRange(photoGalleryIndex, usersPhotoGallery.Count % numberOfImagesDisplayedInGallery);
				}
			}

			// Remove any existing images in the photo gallery so we can add only the ones we want to display.
			for (int i = 0; i < numberOfImagesDisplayedInGallery; i++)
			{
				if (photoDiv.HasControls())
				{
					photoDiv.Controls.RemoveAt(0);
				}
				else
				{ break; }
			}

			foreach (KeyValuePair<int, string> imageInfo in eightImagesToDisplay)
			{
				HtmlGenericControl div = new HtmlGenericControl("div");
				div.Attributes.Add("class", "col-md-3 col-sm-4 col-xs-6");

				HtmlImage image = new HtmlImage();
				image.Src = imageInfo.Value;
				image.Attributes.Add("data-target", "#lightbox");
				image.Attributes.Add("data-toggle", "modal");
				image.Attributes.Add("class", "thumbnail col-md-12 col-xs-12");
				image.Attributes.Add("style", "height:100px; width:100px;");

				div.Controls.Add(image);
				photoDiv.Controls.Add(div);
			}
		}

		/// <summary>
		/// Loads the recently added trips grid.
		/// </summary>
		private void LoadRecentlyAddedTripsGrid()
		{
			recentlyAddedTripsBody.InnerHtml = string.Empty;

			List<TripObject> trips = TripObject.GetTopFiveTripsForUser(Master.UsersInfo.ID);

			foreach (TripObject trip in trips)
			{
				recentlyAddedTripsBody.InnerHtml = recentlyAddedTripsBody.InnerHtml + "<tr>" +
												"<td class=\"text-center\"><a href=\"Trip.aspx?id=" + trip.ID.ToString() + "&returnUrl=Trips\" style=\"margin-right:10px;\">Select</a></td>" +
												"<td>" + trip.Title + "</td>" +
												"<td>" + trip.TripDate + "</td>" +
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
				recentlyAddedTripsTableContainer.Visible = false;
			}
		}

		/// <summary>
		/// Loads the recently added locations grid.
		/// </summary>
		private void LoadRecentlyAddedLocationsGrid()
		{
			recentlyAddedLocationsBody.InnerHtml = string.Empty;

			List<LocationObject> YourLocations = LocationObject.GetTopFiveLocationsForUser(Master.UsersInfo.ID);

			foreach (LocationObject loc in YourLocations)
			{
				recentlyAddedLocationsBody.InnerHtml = recentlyAddedLocationsBody.InnerHtml + "<tr>" +
												"<td class=\"text-center\"><a href=\"Location?id=" + loc.ID.ToString() + "&returnUrl=locations\" style=\"margin-right:10px;\">Select</a></td>" +
												"<td>" + loc.Name + "</td>" +
												"<td>" + loc.CreateDate.ToString("MM/dd/yyyy") + "</td>" +
											"</tr>";
			}

			if (YourLocations.Count > 0)
			{
				NoLocationsMessage.Visible = false;
			}
			else
			{
				NoLocationsMessage.Visible = true;
				recentlyAddedLocationsTableContainer.Visible = false;
			}
		}

		#endregion Private Methods
	}
}