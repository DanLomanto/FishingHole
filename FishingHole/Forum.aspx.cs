using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Common;

namespace FishingHole
{
	public partial class Forum : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LoadDiscussionTopics();

			LoadRecentlyUpdateThreads();
		}

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
			}
		}

		private void LoadRecentlyUpdateThreads()
		{ }
	}
}