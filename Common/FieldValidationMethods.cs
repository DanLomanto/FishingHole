using System;
using System.Net.Mail;

namespace Common
{
	public static class FieldValidationMethods
	{
		public static bool ValidateEmail(string email)
		{
			try
			{
				var addr = new MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}

		public static bool ValidatePassword(string password)
		{
			const int MIN_LENGTH = 8;
			const int MAX_LENGTH = 15;

			if (password == null) throw new ArgumentNullException();

			bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
			bool hasUpperCaseLetter = false;
			bool hasLowerCaseLetter = false;
			bool hasDecimalDigit = false;

			if (meetsLengthRequirements)
			{
				foreach (char c in password)
				{
					if (char.IsUpper(c)) hasUpperCaseLetter = true;
					else if (char.IsLower(c)) hasLowerCaseLetter = true;
					else if (char.IsDigit(c)) hasDecimalDigit = true;
				}
			}

			bool isValid = meetsLengthRequirements
						&& hasUpperCaseLetter
						&& hasLowerCaseLetter
						&& hasDecimalDigit
						;
			return isValid;
		}

		public static bool ValidateTextField(string textToValidate)
		{
			if (string.IsNullOrWhiteSpace(textToValidate.Trim()))
			{ return false; }

			return true;
		}
	}
}