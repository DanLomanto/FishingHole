using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using Common;

namespace FishingHole
{
	public partial class NewUser : Page
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
		}

		/// <summary>
		/// Creates the account button click.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected void CreateAccountButtonClick(object sender, EventArgs e)
		{
			ValidateFields();

			if (formValidationErrors.Count > 0)
			{
				formErrors.CssClass = formErrors.CssClass + " has-error";
				formErrors.ForeColor = Color.Red;
				formErrors.DataSource = formValidationErrors;
				formErrors.DataBind();
			}
			else
			{
				bool wasUserCreated = UserActions.CreateNewUser(emailInput.Value.Trim(), firstNameInput.Value.Trim(), lastNameInput.Value.Trim(), passwordInput.Value.Trim());
				if (!wasUserCreated)
				{
					formValidationErrors.Add("A user with this email already exists.");
					formErrors.CssClass = formErrors.CssClass + " has-error";
					formErrors.ForeColor = Color.Red;
					formErrors.DataSource = formValidationErrors;
					formErrors.DataBind();
				}
				else
				{
					Session.Add("Email", emailInput.Value.Trim());
					Response.Redirect("Dashboard.aspx");
				}
			}
		}

		#region Private Methods

		/// <summary>
		/// Validates the fields.
		/// </summary>
		/// <returns></returns>
		private List<string> ValidateFields()
		{
			formValidationErrors = new List<string>();

			if (!FieldValidationMethods.ValidateTextField(firstNameInput.Value.Trim()))
			{
				formValidationErrors.Add("The First Name you entered is invalid.");
			}

			if (!FieldValidationMethods.ValidateTextField(lastNameInput.Value.Trim()))
			{
				formValidationErrors.Add("The Last Name you entered is invalid.");
			}

			if (!FieldValidationMethods.ValidateEmail(emailInput.Value))
			{
				formValidationErrors.Add("The Email address you entered is invalid.");
			}

			if (!FieldValidationMethods.ValidatePassword(passwordInput.Value))
			{
				formValidationErrors.Add("The Password you entered is invalid.");
			}

			if (passwordInput.Value != confirmPasswordInput.Value)
			{
				formValidationErrors.Add("The Passwords entered did not match.");
			}

			return formValidationErrors;
		}

		#endregion Private Methods
	}
}