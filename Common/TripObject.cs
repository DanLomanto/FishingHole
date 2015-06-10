using System;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Common
{
	/// <summary>
	/// The Trip object.
	/// </summary>
	public class TripObject : TripGridViewModel
	{
		#region Properties

		/// <summary>
		/// The Trip Description.
		/// </summary>
		public string Description { get; set; }

		public string TargetedSpecies { get; set; }

		public string WeatherConditions { get; set; }

		public string CatchOfTheDay { get; set; }

		public string OtherNotes { get; set; }

		public LocationObject Location { get; set; }

		public string FliesLuresUsed { get; set; }

		public string WaterConditions { get; set; }

		#endregion Properties

		/// <summary>
		/// Gets the list of trips for the specified user id.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public static DataTable GetTripsForUser(int userId)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetAllTripsForUser(userId);

			DataTable table = DataActions.ConvertToDataTable(result);

			if (table == null || table.Rows.Count == 0)
			{
				return null;
			}

			table.DefaultView.Sort = "ID DESC";
			table = table.DefaultView.ToTable();

			return table;
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
	}
}