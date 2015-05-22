using System;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Common
{
	/// <summary>
	/// The Location Object
	/// </summary>
	public class LocationObject : LocationsGridViewModel
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

		#endregion Properties

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
			location.Name = result.Name;
			location.Description = result.Description;
			location.StreetAddress = result.StreetAddress;
			location.CityTown = result.CityTown;
			location.State = result.State;
			location.Zipcode = result.Zipcode;
			location.LattitudeDirection = result.LattitudeDirection;
			location.Lattitude = result.Lattitude;
			location.LongitudeDirection = result.LongitudeDirection;
			location.Longitude = result.Longitude;

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
			location.LattitudeDirection = result.LattitudeDirection;
			location.Lattitude = result.Lattitude;
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
				LattitudeDirection,
				Convert.ToDecimal(Lattitude),
				LongitudeDirection,
				Convert.ToDecimal(Longitude),
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
				State, Zipcode, LattitudeDirection, Lattitude, LongitudeDirection, Longitude);

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
		public static int GetAssociatedLocationForTrip(int tripId)
		{
			FishEntities fishDb = new FishEntities();
			var associatedLocationId = fishDb.GetAssociatedLocationForTrip(tripId).FirstOrDefault(); ;

			if (associatedLocationId == null)
			{
				return -1;
			}

			return Convert.ToInt32(associatedLocationId);
		}
	}
}