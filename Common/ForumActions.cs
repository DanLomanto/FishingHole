using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
	/// <summary>
	/// Forum Actions
	/// </summary>
	public class ForumActions
	{
		/// <summary>
		/// Gets the list of thread topics.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetListOfThreadTopics()
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetTopicNames();

			List<string> listOfImages = new List<string>();
			foreach (string item in result)
			{
				listOfImages.Add(item);
			}

			return listOfImages;
		}

		/// <summary>
		/// Gets all threads.
		/// </summary>
		/// <returns></returns>
		public static List<ForumThread> GetAllThreads()
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetAllThreads();

			List<ForumThread> allThreads = new List<ForumThread>();
			foreach (GetAllThreads_Result item in result)
			{
				ForumThread thread = new ForumThread
				{
					ID = item.ID,
					Title = item.Title,
					Message = item.Message
				};

				UserInformation userInfo = UserActions.GetUserInfo(item.UserId);
				thread.UserFirstLastNames = new KeyValuePair<string, string>(userInfo.FirstName, userInfo.LastName);
				thread.Category = GetCategory(item.ThreadCategory);
				thread.CommentCount = GetCommentCountForThread(item.ID);

				allThreads.Add(thread);
			}

			return allThreads;
		}

		/// <summary>
		/// Gets the comments for thread.
		/// </summary>
		/// <param name="threadId">The identifier.</param>
		/// <returns></returns>
		public static List<ThreadComment> GetCommentsForThread(int threadId)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetCommentsForThread(threadId);

			List<ThreadComment> comments = new List<ThreadComment>();
			foreach (GetCommentsForThread_Result comment in result)
			{
				ThreadComment tc = new ThreadComment();
				tc.CreateDate = comment.CreateDate;
				tc.Message = comment.Comment;
				UserInformation userInfo = UserActions.GetUserInfo(comment.UserId);
				tc.UserFirstLastNames = new KeyValuePair<string, string>(userInfo.FirstName, userInfo.LastName);

				comments.Add(tc);
			}

			return comments;
		}

		/// <summary>
		/// Gets the comment count for thread.
		/// </summary>
		/// <param name="threadId">The identifier.</param>
		/// <returns></returns>
		public static int GetCommentCountForThread(int threadId)
		{
			List<ThreadComment> commentsForThread = GetCommentsForThread(threadId);
			return commentsForThread.Count;
		}

		/// <summary>
		/// Gets the identifier of category.
		/// </summary>
		/// <param name="category">The category.</param>
		/// <returns></returns>
		public static int GetIdOfCategory(string category)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetIdOfCategory(category).FirstOrDefault();

			return Convert.ToInt32(result);
		}

		#region Private Methods

		/// <summary>
		/// Gets the category.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		private static string GetCategory(int id)
		{
			FishEntities fishDB = new FishEntities();
			string result = fishDB.GetThreadCategoryById(id).FirstOrDefault();

			return result;
		}

		#endregion Private Methods
	}

	/// <summary>
	/// A Forum Thread
	/// </summary>
	public class ForumThread
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
		/// Gets or sets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the user's first and last names.
		/// </summary>
		/// <value>
		/// The user identifier.
		/// </value>
		public KeyValuePair<string, string> UserFirstLastNames { get; set; }

		/// <summary>
		/// Gets or sets the last modified date.
		/// </summary>
		/// <value>
		/// The last modified date.
		/// </value>
		public DateTime LastModifiedDate { get; set; }

		/// <summary>
		/// Gets or sets the comment count.
		/// </summary>
		/// <value>
		/// The comment count.
		/// </value>
		public int CommentCount { get; set; }

		/// <summary>
		/// Gets or sets the category.
		/// </summary>
		/// <value>
		/// The category.
		/// </value>
		public string Category { get; set; }

		#endregion Properties

		public void CreateThread(int userId)
		{
			FishEntities fishDB = new FishEntities();
			fishDB.InsertThread(this.Title, this.Message, userId, ForumActions.GetIdOfCategory(this.Category));
		}
	}

	/// <summary>
	/// The Thread Comment
	/// </summary>
	public class ThreadComment
	{
		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the user's first and last names.
		/// </summary>
		/// <value>
		/// The user identifier.
		/// </value>
		public KeyValuePair<string, string> UserFirstLastNames { get; set; }

		/// <summary>
		/// Gets or sets the create date.
		/// </summary>
		/// <value>
		/// The create date.
		/// </value>
		public DateTime CreateDate { get; set; }
	}
}