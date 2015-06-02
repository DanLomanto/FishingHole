using System.Linq;

namespace Common
{
	/// <summary>
	/// A User's Information
	/// </summary>
	public class UserActions
	{
		/// <summary>
		/// Creates the new user.
		/// </summary>
		public static bool CreateNewUser(string email, string firstName, string lastName, string password)
		{
			if (DoesUserExist(email))
			{
				return false;
			}

			FishEntities fishDB = new FishEntities();
			int returnValue = fishDB.CreateUser(firstName, lastName, email, password);

			if (returnValue != 1)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Gets the user.
		/// </summary>
		/// <returns></returns>
		public static bool DoesUserExist(string email)
		{
			UserInformation userInfo = GetUserInfo(email);

			if (userInfo == null)
			{
				return false;
			}

			if (userInfo.Email.ToUpper() == email.ToUpper())
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Gets the user information.
		/// </summary>
		/// <param name="email">The email.</param>
		/// <returns></returns>
		public static UserInformation GetUserInfo(string email)
		{
			FishEntities fishDB = new FishEntities();
			var result = fishDB.GetUser(email).FirstOrDefault();

			if (result == null)
			{ return null; }

			UserInformation userInfo = new UserInformation();
			userInfo.ID = result.ID;
			userInfo.Email = result.Email;
			userInfo.FirstName = result.FirstName;
			userInfo.LastName = result.LastName;

			return userInfo;
		}

		/// <summary>
		/// Checks to see if the specified login exists with the password provided.
		/// </summary>
		/// <param name="email">The email.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public static bool DoesLoginExist(string email, string password)
		{
			FishEntities fishDB = new FishEntities();
			var userInfo = fishDB.DoesLoginExist(email, password);

			if (userInfo.FirstOrDefault() == null)
			{
				return false;
			}

			return true;
		}
	}
}