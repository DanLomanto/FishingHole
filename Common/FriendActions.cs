using System;
using System.Collections.Generic;

namespace Common
{
	/// <summary>
	/// Different actions for maintaining friendship associations.
	/// </summary>
	public static class FriendActions
	{
		/// <summary>
		/// Creates the friend association.
		/// </summary>
		/// <param name="initiatorId">The primary user identifier.</param>
		/// <param name="assocFriendId">The assoc friend identifier.</param>
		public static void CreateFriendAssociation(int initiatorId, int assocFriendId)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.CreateFriendAssociation(initiatorId, assocFriendId);
		}

		/// <summary>
		/// Deletes the friend association.
		/// </summary>
		/// <param name="initiatorId">The primary user identifier.</param>
		/// <param name="assocFriendId">The assoc friend identifier.</param>
		public static void DeleteFriendAssociation(int initiatorId, int assocFriendId)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.DeleteFriendAssociation(initiatorId, assocFriendId);
		}

		/// <summary>
		/// Creates the pending friend request.
		/// </summary>
		/// <param name="requestorId">The primary user identifier. This is the person who's getting the request.</param>
		/// <param name="potentialFriendId">The assoc friend identifier. This is the person who's sending the request.</param>
		public static void CreatePendingFriendRequest(int requestorId, int potentialFriendId)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.CreatePendingFriendRequest(requestorId, potentialFriendId);
		}

		/// <summary>
		/// Deletes the pending friend request.
		/// </summary>
		/// <param name="requestorId">The requestor identifier.</param>
		/// <param name="potentialFriendId">The assoc friend identifier.</param>
		public static void DeletePendingFriendRequest(int requestorId, int potentialFriendId)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.DeletePendingFriendRequest(requestorId, potentialFriendId);
		}

		/// <summary>
		/// Gets the friends for user.
		/// </summary>
		/// <param name="associatedFriend">The primary user identifier.</param>
		/// <returns></returns>
		public static List<UserInformation> GetFriendsForUser(int associatedFriend)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetFriendsForUser(associatedFriend);

			List<UserInformation> friends = new List<UserInformation>();

			foreach (int friendUserId in result)
			{
				UserInformation userInfo = UserActions.GetUserInfo(friendUserId);
				friends.Add(userInfo);
			}

			return friends;
		}

		/// <summary>
		/// Gets the friend requests for user.
		/// </summary>
		/// <param name="primaryUserId">The primary user identifier.</param>
		/// <returns></returns>
		public static List<UserInformation> GetFriendRequestsForUser(int primaryUserId)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetFriendRequestsForUser(primaryUserId);

			List<UserInformation> friendRequests = new List<UserInformation>();

			foreach (int friendUserId in result)
			{
				UserInformation userInfo = UserActions.GetUserInfo(friendUserId);
				friendRequests.Add(userInfo);
			}

			return friendRequests;
		}

		/// <summary>
		/// Makes the pending friend actual friend.
		/// </summary>
		/// <param name="initiatorId">The primary user identifier.</param>
		/// <param name="assocFriendId">The assoc friend identifier.</param>
		public static void MakePendingFriendActualFriend(int initiatorId, int assocFriendId)
		{
			CreateFriendAssociation(initiatorId, assocFriendId);

			DeletePendingFriendRequest(initiatorId, assocFriendId);
		}

		/// <summary>
		/// Searches for users.
		/// </summary>
		/// <param name="searchText">The search text.</param>
		/// <returns></returns>
		public static List<UserInformation> SearchForUsers(int userThatsSearching, string searchText)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.SearchForUsers(userThatsSearching, searchText);

			List<UserInformation> searchResults = new List<UserInformation>();
			foreach (SearchForUsers_Result item in result)
			{
				UserInformation user = new UserInformation
				{
					ID = Convert.ToInt32(item.ID),
					FirstName = item.FirstName,
					LastName = item.LastName,
					Email = item.Email
				};
				searchResults.Add(user);
			}

			return searchResults;
		}
	}
}