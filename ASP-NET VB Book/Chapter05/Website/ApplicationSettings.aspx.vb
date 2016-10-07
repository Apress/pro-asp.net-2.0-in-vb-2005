Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Configuration

Public partial Class Welcome_aspx : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)

		lblSiteName.Text = config.AppSettings.Settings("websiteName").Value
		lblWelcome.Text = config.AppSettings.Settings("welcomeMessage").Value

		If config.AppSettings.Settings("welcomeMessage").Value.Length > 15 Then
			config.AppSettings.Settings("welcomeMessage").Value = "Welcome, again."
		Else
			config.AppSettings.Settings("welcomeMessage").Value = "Welcome, friend."
		End If
		config.Save()

	End Sub

End Class
