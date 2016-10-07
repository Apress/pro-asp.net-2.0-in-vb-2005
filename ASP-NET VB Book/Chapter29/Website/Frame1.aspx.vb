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

Public partial Class Frame1 : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)

		Dim url As String = "http://www.google.com"
		Dim frameScript As String = "<script language='javascript'>" & "window.parent.content.location='" & url & "';</script>"
		Page.RegisterStartupScript("FrameScript", frameScript)

	End Sub
End Class
