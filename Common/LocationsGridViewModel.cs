using System;
using System.Data;
using System.Linq;

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
		public static DataTable GetLocationsForUser(int userId)
		{
			FishEntities fishDb = new FishEntities();
			var result = fishDb.GetAllLocationsForUser(userId);
			DataTable table = DataActions.ConvertToDataTable(result);

			if (table.Rows.Count == 0)
			{
				return new DataTable();
			}

			table.DefaultView.Sort = "ID DESC";
			table = table.DefaultView.ToTable();

			return table;
		}

		/// <summary>
		/// Gets the top five locations for user.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public static DataTable GetTopFiveLocationsForUser(int userId)
		{
			DataTable table = GetLocationsForUser(userId);
			table.AsEnumerable().Take(5);

			return table;
		}
	}
}