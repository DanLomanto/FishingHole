using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
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
		}

		/// <summary>
		/// Handles the Click event of the PostReply control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void PostReply_Click(object sender, EventArgs e)
		{
			ThreadComment comment = new ThreadComment();
			comment.Message = ThreadReply.Value.Trim();
			comment.ThreadId = threadId;
			comment.CreateThread(Master.UsersInfo.ID);

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
								"<i class=\"glyphicon glyphicon-calendar\"></i>&nbsp;Create Date: " + thread.CreateDate.ToString("MM/dd/yyyy hh:ss") +
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
									"<span>" + comment.Message + "</span>" +
									"</div>" +
								"<div class=\"panel-footer\">" +
									"<i class=\"glyphicon glyphicon-calendar\"></i>&nbsp;Create Date: " + comment.CreateDate.ToString("MM/dd/yyyy hh:ss") +
								"</div>";

				ThreadBody.Controls.AddAt(commentIndex, div);
				commentIndex = commentIndex + 1;
			}
		}

		#endregion Private Methods
	}
}