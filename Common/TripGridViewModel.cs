using System;
using System.Data;
using System.Linq;

namespace Common
{
	public class TripGridViewModel
	{
		#region Properties

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

		public int ID { get; set; }

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

			if (table.Rows.Count == 0)
			{
				return new DataTable();
			}

			table.DefaultView.Sort = "ID DESC";
			table = table.DefaultView.ToTable();
			return table;
		}

		public static DataTable GetTopFiveTripsForUser(int userId)
		{
			DataTable table = GetTripsForUser(userId);
			if (table != null)
			{
				table.AsEnumerable().Take(5);
			}

			return table;
		}
	}
}