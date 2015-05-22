using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Configuration;
using Common;

public partial class UploadPhotos : System.Web.UI.Page
{
	#region Properties

	/// <summary>
	/// The partial URL to image
	/// </summary>
	private string partialUrlToImage;

	/// <summary>
	/// The local path for saving
	/// </summary>
	private string localPathForSaving;

	/// <summary>
	/// The full path to uploaded file
	/// </summary>
	private string fullPathToUploadedFile;

	#endregion Properties

	/// <summary>
	/// Handles the Load event of the Page control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void Page_Load(object sender, EventArgs e)
	{
		// Get the local path to save the image to.
		partialUrlToImage = "/Uploads/" + WebConfigurationManager.AppSettings["PhotoUploadDir"];
		partialUrlToImage = partialUrlToImage.Replace("#USERID#", Master.UsersInfo.ID.ToString());
		localPathForSaving = Server.MapPath(partialUrlToImage);

		if (!Directory.Exists(localPathForSaving))
		{
			Directory.CreateDirectory(localPathForSaving);
		}
	}

	/// <summary>
	/// Uploads the photo.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void UploadPhoto(object sender, EventArgs e)
	{
		Boolean fileOK = false;

		foreach (HttpPostedFile uploadedImage in photoUploader.PostedFiles)
		{
			if (!string.IsNullOrEmpty(uploadedImage.FileName))
			{
				string fileExtension = Path.GetExtension(uploadedImage.FileName).ToLower();
				List<string> allowedExtensions = new List<string> { ".gif", ".png", ".jpeg", ".jpg" };
				foreach (string extension in allowedExtensions)
				{
					if (fileExtension == extension)
					{
						fileOK = true;
						break;
					}
				}
			}

			if (fileOK)
			{
				try
				{
					fullPathToUploadedFile = localPathForSaving + Path.GetFileName(uploadedImage.FileName);
					// Overwrite file if it already exists...
					if (File.Exists(fullPathToUploadedFile))
					{
						File.Delete(fullPathToUploadedFile);
					}
					photoUploader.PostedFile.SaveAs(fullPathToUploadedFile);
					returnMessage.InnerText = "File uploaded!";
					returnMessage.Attributes["class"] = "text-success";
					UserActions.InsertImageForUser(Master.UsersInfo.ID, partialUrlToImage + Path.GetFileName(uploadedImage.FileName));
				}
				catch (Exception ex)
				{
					returnMessage.InnerText = "File could not be uploaded.";
					returnMessage.Attributes["class"] = "text-danger";
				}
			}
			else
			{
				returnMessage.InnerText = "Cannot accept files of this type.";
				returnMessage.Attributes["class"] = "text-danger";
			}
		}
	}

	/// <summary>
	/// Handles the Click event of the SaveButton control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void GoBackButton_Click(object sender, EventArgs e)
	{
		string returnUrlParameter = Request.QueryString["returnUrl"];

		if (!string.IsNullOrWhiteSpace(returnUrlParameter) && returnUrlParameter.ToUpper() == "PHOTOGALLERY")
		{
			Response.Redirect("PhotoGallery.aspx");
		}

		Response.Redirect("Dashboard.aspx");
	}
}