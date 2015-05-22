using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

public partial class Locations : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		LocationsGrid.Columns[0].Visible = true;
		LocationsGrid.DataSource = LocationObject.GetLocationsForUser(Master.UsersInfo.ID);
		LocationsGrid.DataBind();
		LocationsGrid.Columns[0].Visible = false;
		Session["LocationsData"] = LocationsGrid.DataSource;

		if (LocationsGrid.Rows.Count > 0)
		{
			NoLocationsMessage.Visible = false;
		}
	}

	protected void LocationsGrid_Sorting(object sender, GridViewSortEventArgs e)
	{
		//Retrieve the table from the session object.
		DataTable dt = Session["LocationsData"] as DataTable;

		if (dt != null)
		{
			//Sort the data.
			dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
			LocationsGrid.DataSource = dt;
			LocationsGrid.DataBind();
		}
	}

	protected void OnLocationsRowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LocationsGrid, "Select$" + e.Row.RowIndex);
			e.Row.Attributes["style"] = "cursor:pointer";
		}
	}

	protected void OnLocationsSelectedIndexChanged(object sender, EventArgs e)
	{
		string id = LocationsGrid.SelectedRow.Cells[0].Text;

		Response.Redirect("Location?id=" + id + "&returnUrl=locations");
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