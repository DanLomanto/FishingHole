using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Common;

namespace FishingHole
{
	public partial class Thread : System.Web.UI.Page
	{
		#region Properties

		/// <summary>
		/// Gets or sets the thread identifier.
		/// </summary>
		/// <value>
		/// The thread identifier.
		/// </value>
		private int threadId
		{
			get { return Convert.ToInt32(Request.QueryString["id"]); }
			set { }
		}

		/// <summary>
		/// The form validation errors
		/// </summary>
		private List<string> formValidationErrors;

		#endregion Properties

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			LoadOriginalThreadMessage();

			LoadThreadComments();

			if (!Page.IsPostBack)
			{
				PopulateLocationsDropDown();
			}

			if (Page.IsPostBack)
			{
				EnableOrDisableLocationsDropDown();
			}
		}

		/// <summary>
		/// Handles the Click event of the PostReply control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void PostReply_Click(object sender, EventArgs e)
		{
			#region Field Validation

			formValidationErrors = new List<string>();

			if (string.IsNullOrWhiteSpace(ThreadReply.Value.Trim()))
			{
				formValidationErrors.Add("You must enter a reply message.");
			}

			if (ShareLocationsRadioBtn.Checked && Locations.SelectedIndex == 0)
			{
				formValidationErrors.Add("You must select a location to share.");
			}

			if (formValidationErrors.Count > 0)
			{
				formErrors.CssClass = formErrors.CssClass + " has-error";
				formErrors.ForeColor = Color.Red;
				formErrors.DataSource = formValidationErrors;
				formErrors.DataBind();
				return;
			}

			#endregion Field Validation

			ThreadComment comment = new ThreadComment();
			comment.Message = ThreadReply.Value.Trim();
			comment.ThreadId = threadId;

			if (Convert.ToInt32(Locations.SelectedValue) > 0)
			{
				comment.LocationId = Convert.ToInt32(Locations.SelectedValue);
			}
			else { comment.LocationId = 0; }

			comment.CreateThreadComment(Master.UsersInfo.ID);

			LoadThreadComments();

			// Clear out the Reply field
			ThreadReply.Value = string.Empty;
		}

		#region Private Methods

		/// <summary>
		/// Loads the original thread message.
		/// </summary>
		private void LoadOriginalThreadMessage()
		{
			// Remove any existing comments from the thread so we can add only the ones we want to display.
			int numberOfComments = OriginalThreadMessage.Controls.Count;
			for (int i = 0; i < numberOfComments; i++)
			{
				if (OriginalThreadMessage.HasControls())
				{
					OriginalThreadMessage.Controls.RemoveAt(0);
				}
				else
				{ break; }
			}

			ForumThread thread = ForumThread.GetThreadById(threadId);

			HtmlGenericControl div = new HtmlGenericControl("div");
			div.Attributes.Add("class", "panel panel-default");

			div.InnerHtml = "<div class=\"panel-heading\">" +
								"<h4><i class=\"fa fa-comment\"></i>&nbsp;Original Post By: " + thread.FirstName + " " + thread.LastName + "</h4>" +
							"</div>" +
							"<div class=\"panel-body\">" +
								"<span>" + thread.Message + "</span>" +
							"</div>" +
							"<div class=\"panel-footer\">" +
								"<i class=\"glyphicon glyphicon-calendar\"></i>&nbsp;Create Date: " + thread.CreateDate.ToString("MM/dd/yyyy hh:ss tt") +
							"</div>";

			OriginalThreadMessage.Controls.AddAt(0, div);
		}

		/// <summary>
		/// Loads the thread comments.
		/// </summary>
		private void LoadThreadComments()
		{
			List<ThreadComment> comments = ForumActions.GetCommentsForThread(threadId);

			// Remove any existing comments from the thread so we can add only the ones we want to display.
			int numberOfComments = ThreadBody.Controls.Count;
			for (int i = 0; i < numberOfComments; i++)
			{
				if (ThreadBody.HasControls())
				{
					ThreadBody.Controls.RemoveAt(0);
				}
				else
				{ break; }
			}

			int commentIndex = 0;
			foreach (ThreadComment comment in comments)
			{
				HtmlGenericControl div = new HtmlGenericControl("div");
				div.Attributes.Add("class", "panel panel-default");

				div.InnerHtml = "<div class=\"panel-heading\">" +
									"<h4><i class=\"fa fa-reply\"></i>&nbsp;Reply From: " + comment.FirstName + " " + comment.LastName + "</h4>" +
								"</div>" +
								"<div class=\"panel-body\">" +
									"<span>" + comment.Message + "</span>";

				if (comment.LocationId > 0)
				{
					LocationObject assoclocation = LocationObject.GetLocationById(comment.LocationId);

					div.InnerHtml = div.InnerHtml +
						"<div class=\"row text-center\">" +
							"<a href=\"https://www.google.com/maps/place/" + assoclocation.FormatGoogleMapsLocationInfo() + "\" target=\"_blank\" class=\"btn btn-primary\"><i class=\"fa fa-map-marker\">&nbsp;Open location in Google Maps</i></a>" +
						"</div>" +
						"<div class=\"row text-center top-buffer\">" +
							  "<iframe class=\"col-md-12 col-xs-12\" height=\"450\" frameborder=\"0\" style=\"border: 0\" src=\"" + assoclocation.GetGoogleMapsUrl() + "\" />" +
						"</div>";
				}

				div.InnerHtml = div.InnerHtml +
						"</div>" +
						"<div class=\"panel-footer\">" +
							"<i class=\"glyphicon glyphicon-calendar\"></i>&nbsp;Reply Date: " + comment.CreateDate.ToString("MM/dd/yyyy hh:ss tt") +
						"</div>";

				ThreadBody.Controls.AddAt(commentIndex, div);
				commentIndex = commentIndex + 1;
			}
		}

		/// <summary>
		/// Enables the or disable locations drop down.
		/// </summary>
		private void EnableOrDisableLocationsDropDown()
		{
			if (ShareLocationsRadioBtn.Checked)
			{
				Locations.Enabled = true;
			}
			else
			{
				Locations.Enabled = false;
			}
		}

		/// <summary>
		/// Populates the locations drop down.
		/// </summary>
		private void PopulateLocationsDropDown()
		{
			Locations.Items.Add(new ListItem("Select Location...", "-1"));

			foreach (DataRow row in LocationObject.GetLocationsForUser(Master.UsersInfo.ID).Rows)
			{
				Locations.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
			}

			Locations.DataBind();
		}

		#endregion Private Methods
	}
}