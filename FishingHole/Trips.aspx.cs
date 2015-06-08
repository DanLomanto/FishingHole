using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace FishingHole
{
	public partial class Trips : Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			TripsDataGrid.Columns[0].Visible = true;
			TripsDataGrid.DataSource = TripObject.GetTripsForUser(Master.UsersInfo.ID);
			TripsDataGrid.DataBind();
			TripsDataGrid.Columns[0].Visible = false;
			Session["TripsData"] = TripsDataGrid.DataSource;

			if (TripsDataGrid.Rows.Count > 0)
			{
				NoTripsMessage.Visible = false;
			}
		}

		/// <summary>
		/// Handles the Sorting event of the TripsDataGrid control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
		protected void TripsDataGrid_Sorting(object sender, GridViewSortEventArgs e)
		{
			//Retrieve the table from the session object.
			DataTable dt = Session["TripsData"] as DataTable;

			if (dt != null)
			{
				//Sort the data.
				dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
				TripsDataGrid.DataSource = dt;
				TripsDataGrid.DataBind();
			}
		}

		/// <summary>
		/// Called when [trips selected index changed].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void OnTripsSelectedIndexChanged(object sender, EventArgs e)
		{
			string id = TripsDataGrid.SelectedRow.Cells[1].Text;

			Response.Redirect("Trip?id=" + id + "&returnUrl=Trips");
		}

		/// <summary>
		/// Called when [trips row data bound].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
		protected void OnTripsRowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(TripsDataGrid, "Select$" + e.Row.RowIndex);
				e.Row.Attributes["style"] = "cursor:pointer";
			}
		}

		/// <summary>
		/// Gets the sort direction.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns></returns>
		private string GetSortDirection(string column)
		{
			// By default, set the sort direction to ascending.
			string sortDirection = "ASC";

			// Retrieve the last column that was sorted.
			string sortExpression = ViewState["SortExpression"] as string;

			if (sortExpression != null)
			{
				// Check if the same column is being sorted.
				// Otherwise, the default value can be returned.
				if (sortExpression == column)
				{
					string lastDirection = ViewState["SortDirection"] as string;
					if ((lastDirection != null) && (lastDirection == "ASC"))
					{
						sortDirection = "DESC";
					}
				}
			}

			// Save new values in ViewState.
			ViewState["SortDirection"] = sortDirection;
			ViewState["SortExpression"] = column;

			return sortDirection;
		}
	}
}