using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
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

		/// <summary>
		/// Gets or sets the index of the photo gallery.
		/// </summary>
		/// <value>
		/// The index of the photo gallery.
		/// </value>
		private int pageIndex
		{
			get
			{
				try
				{
					return Convert.ToInt32(ViewState["pageIndex"]);
				}
				catch
				{
					return 0;
				}
			}
			set
			{
				ViewState["pageIndex"] = value;
			}
		}

		/// <summary>
		/// The number of images displayed in the gallery at once.
		/// </summary>
		private const int numberOfImagesDisplayedInGallery = 20;

		#endregion Properties

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			LoadDiscussionTopics();

			LoadThreadsForAllFilterScenarios();

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

			LoadThreadsForAllFilterScenarios();
		}

		/// <summary>
		/// Handles the Click event of the SearchThreadsButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void SearchThreadsButton_Click(object sender, EventArgs e)
		{
			string searchText = SearchThreadsText.Value.Trim();
			List<ForumThread> threads = ForumActions.SearchForThreads(searchText);

			//LoadRecentlyUpdatedThreads(ForumActions.SearchForThreads(searchText));

			DisplayFilterCategoryTag(searchText);

			LoadThreadsForAllFilterScenarios();
		}

		/// <summary>
		/// Handles the Click event of the ResetFilterButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void ResetFilterButton_Click(object sender, EventArgs e)
		{
			SearchThreadsText.Value = string.Empty;
			FilterSearchTextTag.Visible = false;
			FilterCategoryTag.Visible = false;

			LoadThreadsForAllFilterScenarios();
		}

		/// <summary>
		/// Handles the Click event of the ThreadTopic control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void ThreadTopic_Click(object sender, EventArgs e)
		{
			LinkButton topicButton = sender as LinkButton;
			string topicSelected = topicButton.Text.Trim();

			//LoadRecentlyUpdatedThreads(ForumActions.SearchForThreadsByCategory(topicSelected));

			DisplayFilterSearchTextTag(topicSelected);

			LoadThreadsForAllFilterScenarios();

			SearchThreadsText.Value = string.Empty;
		}

		/// <summary>
		/// Handles the Click event of the ViewNewerThreads control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void ViewNewerThreads_Click(object sender, EventArgs e)
		{
			pageIndex = pageIndex - numberOfImagesDisplayedInGallery;
			ViewOlderThreads.Visible = true;
			LoadThreadsForAllFilterScenarios();
		}

		/// <summary>
		/// Handles the Click event of the ViewOlderThreads control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void ViewOlderThreads_Click(object sender, EventArgs e)
		{
			pageIndex = pageIndex + numberOfImagesDisplayedInGallery;
			ViewNewerThreads.Visible = true;
			LoadThreadsForAllFilterScenarios();
		}

		#region Private Methods

		/// <summary>
		/// Loads the discussion topics.
		/// </summary>
		private void LoadDiscussionTopics()
		{
			List<string> topics = ForumActions.GetListOfThreadTopics();

			int counter = 0;
			foreach (string topic in topics)
			{
				HtmlGenericControl div = new HtmlGenericControl("div");
				div.InnerHtml = "<i class=\"glyphicon glyphicon-book\"></i>&nbsp;";

				LinkButton topicLinkButton = new LinkButton();
				topicLinkButton.Text = topic;
				topicLinkButton.ID = "Topic" + counter.ToString();
				topicLinkButton.Attributes.Add("Style", "color: black;");
				topicLinkButton.Click += new EventHandler(ThreadTopic_Click);

				div.Controls.Add(topicLinkButton);

				ThreadTopics.Controls.Add(div);

				if (topics.Last() != topic)
				{ ThreadTopics.Controls.Add(new HtmlGenericControl("hr")); }

				// Populate the drop down in the Add New Thread modal.
				AddThreadCategories.Items.Add(topic);

				counter++;
			}
		}

		/// <summary>
		/// Loads the threads for all filter scenarios.
		/// </summary>
		private void LoadThreadsForAllFilterScenarios()
		{
			List<ForumThread> threads = new List<ForumThread>();
			string filterCategoryText = GetFilterCategoryText();
			string searchText = GetFilterSearchTagText();
			if (!string.IsNullOrEmpty(filterCategoryText))
			{
				threads = ForumActions.SearchForThreadsByCategory(filterCategoryText);
			}
			else if (!string.IsNullOrEmpty(searchText))
			{
				threads = ForumActions.SearchForThreads(searchText);
			}
			else
			{
				threads = ForumActions.GetAllThreads();
			}

			LoadRecentlyUpdatedThreads(threads);
		}

		/// <summary>
		/// Loads the recently update threads.
		/// </summary>
		private void LoadRecentlyUpdatedThreads(List<ForumThread> threads)
		{
			List<ForumThread> twentyThreadsToDisplay = new List<ForumThread>();

			if (threads.Count < numberOfImagesDisplayedInGallery)
			{
				twentyThreadsToDisplay = threads.GetRange(pageIndex, threads.Count);

				ViewOlderThreads.Visible = false;
				ViewNewerThreads.Visible = false;
			}
			else
			{
				if (pageIndex == 0)
				{
					ViewNewerThreads.Visible = false;
				}

				if ((threads.Count / (numberOfImagesDisplayedInGallery + pageIndex)) >= 1)
				{
					twentyThreadsToDisplay = threads.GetRange(pageIndex, numberOfImagesDisplayedInGallery);
					ViewOlderThreads.Visible = true;
				}
				else
				{
					twentyThreadsToDisplay = threads.GetRange(pageIndex, threads.Count % numberOfImagesDisplayedInGallery);
					ViewNewerThreads.Visible = true;
					ViewOlderThreads.Visible = false;
				}
			}

			// -----------------------------

			// Remove any existing threads from the forum so we can add only the ones we want to display.
			int numberOfThreads = RecentlyUpdatedThreads.Controls.Count;
			for (int i = 0; i < numberOfThreads; i++)
			{
				if (RecentlyUpdatedThreads.HasControls())
				{
					RecentlyUpdatedThreads.Controls.RemoveAt(0);
				}
				else
				{ break; }
			}

			int threadIndex = 0;
			foreach (ForumThread thread in twentyThreadsToDisplay)
			{
				HtmlGenericControl div = new HtmlGenericControl("div");
				div.Attributes.Add("class", "row");

				string lastCommentDate = "N/A";
				if (thread.CommentCount > 0)
				{
					lastCommentDate = thread.LastCommentDate.ToString("MM/dd/yyyy");
				}

				div.InnerHtml = "<div class=\"col-xs-12 col-md-9\">" +
									"<div class=\"row\">" +
										"<a href=\"Thread.aspx?id=" + thread.ID + "\">" +
											"<h4 class=\"col-xs-12\" style=\"color: #477bb7\"><i class=\"fa fa-comment\"></i>&nbsp;" + thread.Title + "</h4>" +
										"</a>" +
									"</div>" +
									"<div class=\"row\">" +
										"<div class=\"col-xs-12 col-md-3\"><i class=\"glyphicon glyphicon-calendar\"></i>&nbsp;Create Date: " + thread.CreateDate.ToString("MM/dd/yyyy") + "</div>" +
										"<div class=\"col-xs-12 col-sm-6 col-md-3\"><i class=\"glyphicon glyphicon-user\"></i>&nbsp;Created by " + thread.UserFirstLastNames.Key + " " + thread.UserFirstLastNames.Value + "</div>" +
										"<div class=\"col-xs-12 col-md-3\"><i class=\"glyphicon glyphicon-calendar\"></i>&nbsp;Last Comment: " + lastCommentDate + "</div>" +
									"</div>" +
								"</div>" +
								"<div class=\"col-xs-offset-1 col-xs-10 col-md-2 text-center\">" +
									"<a href=\"Thread.aspx?id=" + thread.ID + "\" style=\"color: #000000\">" +
										"<div class=\"col-xs-7 well well-md\" style=\"min-width: 100px\">" +
											"<span>Comments <strong>" + thread.CommentCount.ToString() + "</strong></span>" +
										"</div>" +
									"</a>" +
								"</div>" +
								"<div class=\"row col-xs-12\">" +
									"<hr />" +
								"</div>";

				RecentlyUpdatedThreads.Controls.AddAt(threadIndex, div);
				threadIndex = threadIndex + 1;
			}
		}

		/// <summary>
		/// Clears the out error list.
		/// </summary>
		private void ClearOutErrorList()
		{
			int numberOfErrors = formErrors.Items.Count;

			if (numberOfErrors > 0)
			{
				for (int counter = 0; counter < numberOfErrors; counter++)
				{
					formErrors.Items.RemoveAt(counter);
					numberOfErrors = formErrors.Controls.Count;
				}
			}

			formValidationErrors = new List<string>();
			formErrors.DataBind();
		}

		/// <summary>
		/// Displays the filter tag.
		/// </summary>
		/// <param name="filterText">The filter text.</param>
		private void DisplayFilterSearchTextTag(string filterText)
		{
			FilterSearchTextTag.Visible = true;
			FilterSearchTagText.InnerText = filterText;
		}

		/// <summary>
		/// Displays the filter category tag.
		/// </summary>
		/// <param name="filterText">The filter text.</param>
		private void DisplayFilterCategoryTag(string filterText)
		{
			FilterCategoryTag.Visible = true;
			FilterCategoryTagText.InnerText = filterText;
		}

		/// <summary>
		/// Gets the filter search tag text.
		/// </summary>
		/// <returns></returns>
		private string GetFilterSearchTagText()
		{
			if (FilterSearchTextTag.Visible)
			{
				return FilterSearchTextTag.InnerText;
			}

			return string.Empty;
		}

		/// <summary>
		/// Gets the filter category text.
		/// </summary>
		/// <returns></returns>
		private string GetFilterCategoryText()
		{
			if (FilterCategoryTag.Visible)
			{
				return FilterCategoryTag.InnerText;
			}

			return string.Empty;
		}

		#endregion Private Methods
	}
}