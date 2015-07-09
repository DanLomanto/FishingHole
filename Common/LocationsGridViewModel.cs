using System;
using System.Collections.Generic;

namespace Common
{
	public class LocationsGridViewModel
	{
		/// <summary>
		/// The location's Name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The location's lattitude coordinates
		/// </summary>
		public decimal? Lattitude { get; set; }

		/// <summary>
		/// Gets or sets the lattitude direction.
		/// </summary>
		/// <value>
		/// The lattitude direction.
		/// </value>
		public string LattitudeDirection { get; set; }

		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>
		/// The longitude.
		/// </value>
		public decimal? Longitude { get; set; }

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
					LattitudeDirection = location.LattitudeDirection,
					Lattitude = location.Lattitude,
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
					LattitudeDirection = location.LattitudeDirection,
					Lattitude = location.Lattitude,
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

			if (allLocations.Count < 5)
			{
				return allLocations.GetRange(0, allLocations.Count);
			}

			return allLocations.GetRange(0, 5);
		}
	}
}