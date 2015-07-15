namespace Common
{
	/// <summary>
	/// Error handling for the application
	/// </summary>
	public class ErrorHandling
	{
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
		/// Gets or sets the referring page.
		/// </summary>
		/// <value>
		/// The referring page.
		/// </value>
		public string ReferringPage { get; set; }

		/// <summary>
		/// Gets or sets the error text.
		/// </summary>
		/// <value>
		/// The error text.
		/// </value>
		public string ErrorText { get; set; }

		/// <summary>
		/// Gets or sets the stack trace.
		/// </summary>
		/// <value>
		/// The stack trace.
		/// </value>
		public string StackTrace { get; set; }

		/// <summary>
		/// Logs the error in database.
		/// </summary>
		public void LogErrorInDb()
		{
			FishEntities fishDB = new FishEntities();
			fishDB.CreateError(this.UserId, this.ReferringPage, this.ErrorText, this.StackTrace);
		}
	}
}