using System.Collections.Generic;

namespace Common
{
	public class ForumActions
	{
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
	}
}