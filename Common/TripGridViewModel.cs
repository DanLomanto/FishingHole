using System;

namespace Common
{
	/// <summary>
	/// The Trip Base Class
	/// </summary>
	public class TripGridViewModel
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

		#endregion Properties
	}
}