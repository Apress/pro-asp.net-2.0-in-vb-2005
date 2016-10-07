Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Imports System.Web.Configuration

Public partial Class _Default : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim htmlString As StringBuilder = New StringBuilder()

		' Has the request been authenticated?
		If Request.IsAuthenticated Then
			' Display generic identity information.
			' This is always available, regardless of the type of
			' authentication.
			htmlString.Append("<h3>Generic User Information</h3>")
			htmlString.Append("<b>Name: </b>")
			htmlString.Append(User.Identity.Name)
			htmlString.Append("<br><b>Authenticated With: </b>")
			htmlString.Append(User.Identity.AuthenticationType)
			htmlString.Append("<br><br>")

			' Was forms authentication used?
			If TypeOf User.Identity Is FormsIdentity Then
				' Get the ticket.
				Dim ticket As FormsAuthenticationTicket = (CType(User.Identity, FormsIdentity)).Ticket

				htmlString.Append("<h3>Ticket User Information</h3>")
				htmlString.Append("<b>Name: </b>")
				htmlString.Append(ticket.Name)
				htmlString.Append("<br><b>Issued at: </b>")
				htmlString.Append(ticket.IssueDate)
				htmlString.Append("<br><b>Expires at: </b>")
				htmlString.Append(ticket.Expiration)
				htmlString.Append("<br><b>Cookie version: </b>")
				htmlString.Append(ticket.Version)

				' Get additional user information
				Dim UserEmail As String = ticket.UserData
				htmlString.Append("<br><br><b>Additional information: </b>")
				htmlString.Append(UserEmail)
			End If
			' Display the information.
			LegendInfo.Text = htmlString.ToString()
		End If
	End Sub

	Protected Sub SignOutAction_Click(ByVal sender As Object, ByVal e As EventArgs)
		FormsAuthentication.SignOut()
		FormsAuthentication.RedirectToLoginPage()
	End Sub
End Class