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

Public partial Class AdTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub AdRotator1_AdCreated(ByVal sender As Object, ByVal e As AdCreatedEventArgs)
		' Synchronize the Hyperlink control.
		lnkBanner.NavigateUrl = e.NavigateUrl
		' Synchronize the text of the link.
		lnkBanner.Text = "Click here for information about our sponsor: "
		lnkBanner.Text += e.AlternateText
	End Sub
End Class
