using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Common
{
	/// <summary>
	/// The Trip object.
	/// </summary>
	public class TripObject
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
		/// The Trip Title.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The Trip Date.
		/// </summary>
		public string TripDate { get; set; }

		/// <summary>
		/// The date the Trip record was created.
		/// </summary>
		public DateTime CreateDate { get; set; }

		/// <summary>
		/// The Trip Description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the targeted species.
		/// </summary>
		/// <value>
		/// The targeted species.
		/// </value>
		public string TargetedSpecies { get; set; }

		/// <summary>
		/// Gets or sets the weather conditions.
		/// </summary>
		/// <value>
		/// The weather conditions.
		/// </value>
		public string WeatherConditions { get; set; }

		/// <summary>
		/// Gets or sets the catch of the day.
		/// </summary>
		/// <value>
		/// The catch of the day.
		/// </value>
		public string CatchOfTheDay { get; set; }

		/// <summary>
		/// Gets or sets the other notes.
		/// </summary>
		/// <value>
		/// The other notes.
		/// </value>
		public string OtherNotes { get; set; }

		/// <summary>
		/// Gets or sets the location.
		/// </summary>
		/// <value>
		/// The location.
		/// </value>
		public LocationObject Location { get; set; }

		/// <summary>
		/// Gets or sets the flies lures used.
		/// </summary>
		/// <value>
		/// The flies lures used.
		/// </value>
		public string FliesLuresUsed { get; set; }

		/// <summary>
		/// Gets or sets the water conditions.
		/// </summary>
		/// <value>
		/// The water conditions.
		/// </value>
		public string WaterConditions { get; set; }

		#endregion Properties

		/// <summary>
		/// Gets the list of trips for the specified user id.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public static List<TripObject> GetTripsForUser(int userId)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetAllTripsForUser(userId);

			List<TripObject> trips = new List<TripObject>();

			foreach (GetAllTripsForUser_Result trip in result)
			{
				TripObject newTrip = new TripObject
				{
					ID = trip.ID,
					Title = trip.Title,
					CatchOfTheDay = trip.CatchOfTheDay,
					CreateDate = trip.CreateDate,
					TripDate = trip.DateOfTrip,
					Description = trip.Description,
					FliesLuresUsed = trip.FliesLuresUsed,
					OtherNotes = trip.OtherNotes,
					TargetedSpecies = trip.TargetedSpecies,
					WaterConditions = trip.WaterConditions,
					WeatherConditions = trip.WeatherConditions
				};
				trips.Add(newTrip);
			}

			return trips;
		}

		/// <summary>
		/// Gets the top five trips for user.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public static List<TripObject> GetTopFiveTripsForUser(int userId)
		{
			List<TripObject> allTrips = GetTripsForUser(userId);
			if (allTrips.Count > 5)
			{
				return allTrips.GetRange(0, 5);
			}

			return allTrips;
		}

		/// <summary>
		/// Gets the trip.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <param name="title">The title.</param>
		/// <returns></returns>
		public static TripObject GetTrip(int userId, string title)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetTrip(userId, title).FirstOrDefault();

			if (result == null)
			{ return null; }

			TripObject trip = new TripObject();
			trip.Title = result.Title;
			trip.Description = result.Description;
			trip.TripDate = result.DateOfTrip;
			trip.TargetedSpecies = result.TargetedSpecies;
			trip.CreateDate = result.CreateDate;
			trip.WeatherConditions = result.WeatherConditions;
			trip.CatchOfTheDay = result.CatchOfTheDay;
			trip.OtherNotes = result.OtherNotes;
			trip.FliesLuresUsed = result.FliesLuresUsed;
			trip.WaterConditions = result.WaterConditions;

			return trip;
		}

		/// <summary>
		/// Gets the trip by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public static TripObject GetTripById(int id)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetTripById(id).FirstOrDefault();

			if (result == null)
			{ return null; }

			TripObject trip = new TripObject();
			trip.Title = result.Title;
			trip.Description = result.Description;
			trip.TripDate = result.DateOfTrip;
			trip.CreateDate = result.CreateDate;
			trip.TargetedSpecies = result.TargetedSpecies;
			trip.WeatherConditions = result.WeatherConditions;
			trip.CatchOfTheDay = result.CatchOfTheDay;
			trip.OtherNotes = result.OtherNotes;
			trip.FliesLuresUsed = result.FliesLuresUsed;
			trip.WaterConditions = result.WaterConditions;

			return trip;
		}

		/// <summary>
		/// Updates the trip.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public bool UpdateTrip(int id)
		{
			FishEntities fishDb = new FishEntities();
			int returnValue = fishDb.UpdateTrip(id, Title, Description, TargetedSpecies, WaterConditions,
				WeatherConditions, TripDate, FliesLuresUsed, CatchOfTheDay, OtherNotes);

			if (returnValue != 1)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Creates the trip.
		/// </summary>
		/// <param name="userID">The user identifier.</param>
		/// <returns></returns>
		public int CreateTrip(int userID)
		{
			FishEntities fishDb = new FishEntities();
			ObjectParameter Output = new ObjectParameter("Output_Result", typeof(Int32));
			int response = fishDb.CreateTrip(userID, Title, Description, TargetedSpecies, WaterConditions,
				WeatherConditions, TripDate, FliesLuresUsed, CatchOfTheDay, OtherNotes, Output);

			return Convert.ToInt32(Output.Value);
		}

		/// <summary>
		/// Creates the update location for trip.
		/// </summary>
		/// <param name="tripId">The trip identifier.</param>
		/// <param name="locationId">The location identifier.</param>
		/// <returns></returns>
		public static bool CreateUpdateLocationForTrip(int tripId, int locationId)
		{
			FishEntities fishDb = new FishEntities();
			int returnValue = fishDb.CreateUpdateLocationToTrip(tripId, locationId);

			if (returnValue != 1)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Gets the trip identifier for location.
		/// </summary>
		/// <param name="locationId">The location identifier.</param>
		/// <returns></returns>
		public static int GetTripIdForLocation(int locationId)
		{
			FishEntities fishDb = new FishEntities();
			var associatedTripId = fishDb.GetAssociatedTripForLocation(locationId).FirstOrDefault(); ;

			if (associatedTripId == null)
			{
				return -1;
			}

			return Convert.ToInt32(associatedTripId);
		}

		/// <summary>
		/// Deletes the location for trip.
		/// </summary>
		/// <param name="tripId">The trip identifier.</param>
		public static void DeleteLocationForTrip(int tripId)
		{
			FishEntities fishDb = new FishEntities();
			fishDb.DeleteLocationForTrip(tripId);
		}

		/// <summary>
		/// Deletes the trip.
		/// </summary>
		/// <param name="tripId">The trip identifier.</param>
		public static void DeleteTrip(int tripId)
		{
			FishEntities fishDb = new FishEntities();
			fishDb.DeleteTrip(tripId);
		}
	}
}