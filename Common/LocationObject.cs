using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Common
{
	/// <summary>
	/// The Location Object
	/// </summary>
	public class LocationObject
	{
		#region Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the user identifier.
		/// </summary>
		/// <value>
		/// The user identifier.
		/// </value>
		public int UserId { get; set; }

		/// <summary>
		/// The location's Description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The location's Name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The location's lattitude coordinates
		/// </summary>
		public double? Latitude { get; set; }

		/// <summary>
		/// Gets or sets the lattitude direction.
		/// </summary>
		/// <value>
		/// The lattitude direction.
		/// </value>
		public string LatitudeDirection { get; set; }

		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>
		/// The longitude.
		/// </value>
		public double? Longitude { get; set; }

		/// <summary>
		/// Gets or sets the longitude direction.
		/// </summary>
		/// <value>
		/// The longitude direction.
		/// </value>
		public string LongitudeDirection { get; set; }

		/// <summary>
		/// The location's address
		/// </summary>
		public string StreetAddress { get; set; }

		/// <summary>
		/// Gets or sets the city town.
		/// </summary>
		/// <value>
		/// The city town.
		/// </value>
		public string CityTown { get; set; }

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		public string State { get; set; }

		/// <summary>
		/// Gets or sets the zipcode.
		/// </summary>
		/// <value>
		/// The zipcode.
		/// </value>
		public int? Zipcode { get; set; }

		/// <summary>
		/// The date the location record was created.
		/// </summary>
		public DateTime CreateDate { get; set; }

		#endregion Properties

		/// <summary>
		/// Gets the list of trips for the specified user id.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public static List<LocationObject> GetLocationsForUser(int userId)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetAllLocationsForUser(userId);

			List<LocationObject> locations = new List<LocationObject>();

			foreach (GetAllLocationsForUser_Result location in result)
			{
				LocationObject newLocation = new LocationObject
				{
					ID = location.ID,
					Name = location.Name,
					StreetAddress = location.StreetAddress,
					CityTown = location.CityTown,
					Zipcode = location.Zipcode,
					State = location.State,
					LatitudeDirection = location.LattitudeDirection,
					Latitude = location.Lattitude,
					LongitudeDirection = location.LongitudeDirection,
					Longitude = location.Longitude,
					CreateDate = location.CreateDate
				};

				locations.Add(newLocation);
			}

			return locations;
		}

		/// <summary>
		/// Gets the shared locations for user.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public static List<LocationObject> GetSharedLocationsForUser(int userId)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetSharedLocationsForUser(userId);

			List<LocationObject> locations = new List<LocationObject>();

			foreach (GetSharedLocationsForUser_Result location in result)
			{
				LocationObject newLocation = new LocationObject
				{
					ID = location.ID,
					Name = location.Name,
					StreetAddress = location.StreetAddress,
					CityTown = location.CityTown,
					Zipcode = location.Zipcode,
					State = location.State,
					LatitudeDirection = location.LattitudeDirection,
					Latitude = location.Lattitude,
					LongitudeDirection = location.LongitudeDirection,
					Longitude = location.Longitude,
					CreateDate = location.CreateDate
				};

				locations.Add(newLocation);
			}

			return locations;
		}

		/// <summary>
		/// Gets the top five locations for user.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public static List<LocationObject> GetTopFiveLocationsForUser(int userId)
		{
			List<LocationObject> allLocations = GetLocationsForUser(userId);

			if (allLocations.Count > 5)
			{
				allLocations.GetRange(0, 5);
			}

			return allLocations;
		}

		/// <summary>
		/// Gets the location by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public static LocationObject GetLocationById(int id)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetLocationById(id).FirstOrDefault();

			if (result == null)
			{ return null; }

			LocationObject location = new LocationObject();
			location.ID = id;
			location.Name = result.Name;
			location.Description = result.Description;
			location.StreetAddress = result.StreetAddress;
			location.CityTown = result.CityTown;
			location.State = result.State;
			location.Zipcode = result.Zipcode;
			location.LatitudeDirection = result.LattitudeDirection;
			location.Latitude = Convert.ToDouble(result.Lattitude);
			location.LongitudeDirection = result.LongitudeDirection;
			location.Longitude = Convert.ToDouble(result.Longitude);

			return location;
		}

		/// <summary>
		/// Gets the location by the user id and name entered.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <param name="Name">The name.</param>
		/// <returns></returns>
		public static LocationObject GetLocation(int userId, string Name)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetLocation(userId, Name).FirstOrDefault();

			if (result == null)
			{ return null; }

			LocationObject location = new LocationObject();
			location.Name = result.Name;
			location.Description = result.Description;
			location.StreetAddress = result.StreetAddress;
			location.CityTown = result.CityTown;
			location.State = result.State;
			location.Zipcode = result.Zipcode;
			location.LatitudeDirection = result.LattitudeDirection;
			location.Latitude = result.Lattitude;
			location.LongitudeDirection = result.LongitudeDirection;
			location.Longitude = result.Longitude;

			return location;

			return null;
		}

		/// <summary>
		/// Creates the location.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public int CreateLocation(int userId)
		{
			FishEntities fishDb = new FishEntities();
			ObjectParameter Output = new ObjectParameter("Output_Result", typeof(Int32));
			int response = fishDb.CreateLocation(
				userId,
				Name,
				Description,
				StreetAddress,
				CityTown, State,
				Zipcode,
				LatitudeDirection,
				Latitude,
				LongitudeDirection,
				Longitude,
				Output);

			return Convert.ToInt32(Output.Value);
		}

		/// <summary>
		/// Updates the location.
		/// </summary>
		public bool UpdateLocation()
		{
			FishEntities fishDb = new FishEntities();
			int returnValue = fishDb.UpdateLocation(ID, Name, Description, StreetAddress, CityTown,
				State, Zipcode, LatitudeDirection, Latitude, LongitudeDirection, Longitude);

			if (returnValue != 1)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Gets the associated location for trip.
		/// </summary>
		/// <param name="tripId">The trip identifier.</param>
		/// <returns></returns>
		public static int GetAttachedLocationForTrip(int tripId)
		{
			FishEntities fishDb = new FishEntities();
			var associatedLocationId = fishDb.GetAssociatedLocationForTrip(tripId).FirstOrDefault(); ;

			if (associatedLocationId == null)
			{
				return -1;
			}

			return Convert.ToInt32(associatedLocationId);
		}

		/// <summary>
		/// Deletes the trip for location.
		/// </summary>
		/// <param name="locationId">The location identifier.</param>
		public static void DeleteTripForLocation(int locationId)
		{
			FishEntities fishDb = new FishEntities();
			fishDb.DeleteTripForLocation(locationId);
		}

		/// <summary>
		/// Shares the location.
		/// </summary>
		/// <param name="userIdToShareTo">The user identifier to share to.</param>
		public static void ShareLocation(int locationId, int userIdToShareTo)
		{
			FishEntities fishDb = new FishEntities();
			fishDb.ShareLocation(locationId, userIdToShareTo);
		}

		/// <summary>
		/// Gets the google maps URL.
		/// </summary>
		/// <returns></returns>
		public string GetGoogleMapsUrl()
		{
			string locationToAppendOnLink = FormatGoogleMapsLocationInfo();
			return "https://www.google.com/maps/embed/v1/place?key=" + ConfigurationManager.AppSettings["GoogleAPIKey"].ToString() + "&q=" + locationToAppendOnLink;
		}

		/// <summary>
		/// Formats the google maps location information.
		/// </summary>
		/// <returns></returns>
		public string FormatGoogleMapsLocationInfo()
		{
			string locationToAppendOnLink = string.Empty;
			if (!string.IsNullOrWhiteSpace(this.StreetAddress))
			{
				// Street Address
				locationToAppendOnLink = this.StreetAddress + " " + this.CityTown + " " + this.State + " " + this.Zipcode.ToString();
			}
			else
			{
				// Lat/Long Coordinates
				locationToAppendOnLink = formatCoordinates(this.LatitudeDirection, this.Latitude, this.LongitudeDirection, this.Longitude);
			}

			return locationToAppendOnLink;
		}

		/// <summary>
		/// Gets the number of unviewed shared locations for user.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public static int GetNumberOfUnviewedSharedLocationsForUser(int userId)
		{
			FishEntities fishDb = new FishEntities();
			var numberOfUnviewedLocations = fishDb.HowManyUnviewedSharedLocationsForUser(userId).FirstOrDefault();

			if (numberOfUnviewedLocations == null)
			{
				return 0;
			}

			return Convert.ToInt32(numberOfUnviewedLocations);
		}

		/// <summary>
		/// Marks the location as viewed.
		/// </summary>
		public void MarkLocationAsViewed()
		{
			FishEntities fishDb = new FishEntities();
			fishDb.MarkLocationAsViewed(this.ID);
		}

		/// <summary>
		/// Determines whether [has location been viewed].
		/// </summary>
		/// <returns></returns>
		public bool HasLocationBeenViewed()
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetViewStatusOfLocation(this.ID).FirstOrDefault();

			if (result == null)
			{
				return false;
			}
			return Convert.ToBoolean(result);
		}

		/// <summary>
		/// Deletes the location.
		/// </summary>
		/// <param name="locationId">The location identifier.</param>
		public static void DeleteLocation(int locationId)
		{
			FishEntities fishDb = new FishEntities();
			fishDb.DeleteLocation(locationId);
		}

		#region Private Methods

		/// <summary>
		/// Formats the coordinates into the text that will be appended onto the Google Maps API link.
		/// </summary>
		/// <param name="latDirection">The lat direction.</param>
		/// <param name="lattitude">The lattitude.</param>
		/// <param name="longDirection">The long direction.</param>
		/// <param name="longitude">The longitude.</param>
		/// <returns></returns>
		private string formatCoordinates(string latDirection, double? lattitude, string longDirection, double? longitude)
		{
			string actualLattitude = lattitude.ToString();
			if (latDirection == "S")
			{
				actualLattitude = "-" + actualLattitude;
			}

			string actualLongitude = longitude.ToString();
			if (longDirection == "W")
			{
				actualLongitude = "-" + actualLongitude;
			}

			return actualLattitude + "," + actualLongitude;
		}

		#endregion Private Methods
	}
}