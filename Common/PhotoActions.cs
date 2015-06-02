using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Web;

namespace Common
{
	public class PhotoActions
	{
		/// <summary>
		/// Creates the photo to trip association.
		/// </summary>
		/// <param name="TripId">The trip identifier.</param>
		/// <param name="PhotoId">The photo identifier.</param>
		public static void CreatePhotoToTripAssociation(int TripId, int PhotoId)
		{
			FishEntities fishDb = new FishEntities();
			fishDb.CreateTripToPhoto(TripId, PhotoId);
		}

		/// <summary>
		/// Gets the photos for trip.
		/// </summary>
		/// <param name="TripId">The trip identifier.</param>
		/// <returns></returns>
		public static List<KeyValuePair<int, string>> GetPhotosForTrip(int TripId)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetPhotosForTrip(TripId);

			List<KeyValuePair<int, string>> listOfImages = new List<KeyValuePair<int, string>>();
			foreach (GetPhotosForTrip_Result item in result)
			{
				listOfImages.Add(new KeyValuePair<int, string>(item.PhotoID, item.ImagePath));
			}

			return listOfImages;
		}

		/// <summary>
		/// Uploads the photos.
		/// </summary>
		/// <param name="uploadedImages">The uploaded images.</param>
		/// <param name="partialUrlToImage">The partial URL to image.</param>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public static KeyValuePair<string, string> UploadPhotos(IList<HttpPostedFile> uploadedImages, string localPathForSaving, string partialUrlToImage, int userId)
		{
			KeyValuePair<string, string> returnMessage = new KeyValuePair<string, string>();
			returnMessage = UploadPhotosForTrip(uploadedImages, localPathForSaving, partialUrlToImage, userId, 0);

			return returnMessage;
		}

		/// <summary>
		/// Uploads the photos for trip.
		/// </summary>
		/// <param name="uploadedImages">The uploaded images.</param>
		/// <param name="localPathForSaving">The local path for saving.</param>
		/// <param name="partialUrlToImage">The partial URL to image.</param>
		/// <param name="userId">The user identifier.</param>
		/// <param name="tripId">The trip identifier.</param>
		/// <returns></returns>
		public static KeyValuePair<string, string> UploadPhotosForTrip(IList<HttpPostedFile> uploadedImages, string localPathForSaving, string partialUrlToImage, int userId, int tripId)
		{
			bool fileOK = false;
			KeyValuePair<string, string> returnMessage = new KeyValuePair<string, string>();

			foreach (HttpPostedFile uploadedImage in uploadedImages)
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
						string fullPathToUploadedFile = localPathForSaving + Path.GetFileName(uploadedImage.FileName);
						// Overwrite file if it already exists...
						if (File.Exists(fullPathToUploadedFile))
						{
							File.Delete(fullPathToUploadedFile);
						}
						uploadedImage.SaveAs(fullPathToUploadedFile);
						returnMessage = new KeyValuePair<string, string>("File uploaded!", "text-success");

						int imageId = PhotoActions.InsertImageForUser(userId, partialUrlToImage + Path.GetFileName(uploadedImage.FileName));
						if (tripId > 0)
						{
							CreatePhotoToTripAssociation(tripId, imageId);
						}
					}
					catch (Exception ex)
					{
						returnMessage = new KeyValuePair<string, string>("File could not be uploaded.", "text-danger");
					}
				}
				else
				{
					returnMessage = new KeyValuePair<string, string>("Cannot accept files of this type.", "text-danger");
				}
			}

			return returnMessage;
		}

		/// <summary>
		/// Inserts the image for user.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <param name="imagePath">The image path.</param>
		/// <returns></returns>
		public static int InsertImageForUser(int userId, string imagePath)
		{
			FishEntities fishDB = new FishEntities();
			ObjectParameter Output = new ObjectParameter("Output_Result", typeof(Int32));
			fishDB.InsertImagePath(userId, imagePath, Output);

			return Convert.ToInt32(Output.Value);
		}

		/// <summary>
		/// Gets the images for user.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public static List<KeyValuePair<int, string>> GetImagesForUser(int userId)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetImagesForUser(userId);

			List<KeyValuePair<int, string>> listOfImages = new List<KeyValuePair<int, string>>();
			foreach (GetImagesForUser_Result item in result)
			{
				listOfImages.Add(new KeyValuePair<int, string>(item.ID, item.ImagePath));
			}

			return listOfImages;
		}
	}
}