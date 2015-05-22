using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using Common;

public partial class Login : Page
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
	/// Method when the Sign In button is clicked.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected void SignInButtonClick(object sender, EventArgs e)
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
			if (UserActions.DoesLoginExist(emailInput.Value.Trim(), passwordInput.Value.Trim()))
			{
				Session.Add("Email", emailInput.Value.Trim());
				Response.Redirect("Dashboard.aspx");
			}

			formValidationErrors.Add("The information entered does not match a user in our system. Please try again.");
			formErrors.CssClass = formErrors.CssClass + " has-error";
			formErrors.ForeColor = Color.Red;
			formErrors.DataSource = formValidationErrors;
			formErrors.DataBind();
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

		if (!FieldValidationMethods.ValidateEmail(emailInput.Value))
		{
			formValidationErrors.Add("The Email address you entered is invalid.");
		}

		if (!FieldValidationMethods.ValidatePassword(passwordInput.Value))
		{
			formValidationErrors.Add("The Password you entered is invalid.");
		}

		return formValidationErrors;
	}

	#endregion Private Methods
}