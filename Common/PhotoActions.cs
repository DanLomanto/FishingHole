using System.Collections.Generic;

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
	}
}