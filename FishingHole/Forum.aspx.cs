using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Common;

namespace FishingHole
{
	public partial class Forum : Page
	{
		#region Properties

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
			LoadDiscussionTopics();

			LoadRecentlyUpdateThreads();

			ClearOutErrorList();
		}

		/// <summary>
		/// Handles the Click event of the CreateNewThread control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void CreateNewThread_Click(object sender, EventArgs e)
		{
			#region Field Validation

			ClearOutErrorList();

			hiddenShowModal.Value = "false";

			if (string.IsNullOrWhiteSpace(ThreadTitle.Value))
			{
				formValidationErrors.Add("You must enter a Title for the Thread.");
			}

			if (string.IsNullOrWhiteSpace(ThreadMessage.Value))
			{
				formValidationErrors.Add("You must enter a Message for the Thread.");
			}

			if (formValidationErrors.Count > 0)
			{
				formErrors.CssClass = formErrors.CssClass + " has-error";
				formErrors.ForeColor = Color.Red;
				formErrors.DataSource = formValidationErrors;
				formErrors.DataBind();

				hiddenShowModal.Value = "true";
				return;
			}

			#endregion Field Validation

			ForumThread newThread = new ForumThread
			{
				Title = ThreadTitle.Value.Trim(),
				Message = ThreadMessage.Value.Trim(),
				Category = AddThreadCategories.SelectedValue.Trim()
			};
			newThread.CreateThread(Master.UsersInfo.ID);
		}

		#region Private Methods

		/// <summary>
		/// Loads the discussion topics.
		/// </summary>
		private void LoadDiscussionTopics()
		{
			List<string> topics = ForumActions.GetListOfThreadTopics();

			foreach (string topic in topics)
			{
				HtmlGenericControl div = new HtmlGenericControl("div");
				div.InnerHtml = "<i class=\"glyphicon glyphicon-book\"></i>&nbsp;" + topic;

				ThreadTopics.Controls.Add(div);

				if (topics.Last() != topic)
				{ ThreadTopics.Controls.Add(new HtmlGenericControl("hr")); }

				// Populate the drop down in the Add New Thread modal.
				AddThreadCategories.Items.Add(topic);
			}
		}

		/// <summary>
		/// Loads the recently update threads.
		/// </summary>
		private void LoadRecentlyUpdateThreads()
		{
			List<ForumThread> threads = ForumActions.GetAllThreads();

			foreach (ForumThread thread in threads)
			{
				HtmlGenericControl div = new HtmlGenericControl("div");
				div.Attributes.Add("class", "row");

				string lastCommentDate = "N/A";
				if (thread.CommentCount > 0)
				{
					lastCommentDate = thread.LastModifiedDate.ToString("MM/dd/yyyy");
				}

				div.InnerHtml = "<div class=\"col-xs-10\">" +
									"<div class=\"row\">" +
										"<a href=\"Thread.aspx?id=" + thread.ID + "\">" +
											"<h4 class=\"col-xs-8\" style=\"color: #477bb7\"><i class=\"glyphicon glyphicon-comment\"></i>&nbsp;" + thread.Title + "</h4>" +
										"</a>" +
									"</div>" +
									"<div class=\"row\">" +
										"<div class=\"col-xs-3 col-sm-3 col-md-3\"><i class=\"glyphicon glyphicon-calendar\"></i>&nbsp;Last Comment: " + lastCommentDate + "</div>" +
										"<div class=\"col-xs-6 col-sm-6 col-md-6\"><i class=\"glyphicon glyphicon-user\"></i>&nbsp;Created by " + thread.UserFirstLastNames.Key + " " + thread.UserFirstLastNames.Value + "</div>" +
									"</div>" +
								"</div>" +
								"<div class=\"col-xs-2 col-sm-2 col-md-2 text-center\">" +
									"<a href=\"Thread.aspx?id=" + thread.ID + "\" style=\"color: #000000\">" +
										"<div class=\"col-xs-7 well well-md\" style=\"min-width: 100px\">" +
											"<span>Comments <strong>" + thread.CommentCount.ToString() + "</strong></span>" +
										"</div>" +
									"</a>" +
								"</div><br /><br /><br /><br /><hr />";

				RecentlyUpdatedThreads.Controls.Add(div);
			}
		}

		/// <summary>
		/// Clears the out error list.
		/// </summary>
		private void ClearOutErrorList()
		{
			int numberOfErrors = formErrors.Controls.Count;

			if (formErrors.HasControls())
			{
				for (int counter = 0; counter <= numberOfErrors; counter++)
				{
					formErrors.Controls.RemoveAt(0);
					numberOfErrors = formErrors.Controls.Count;
				}
			}

			formValidationErrors = new List<string>();
			formErrors.DataBind();
		}

		#endregion Private Methods
	}
}