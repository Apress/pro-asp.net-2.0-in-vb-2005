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

Public partial Class QueryStringSender : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmd_Click(ByVal sender As Object, ByVal e As EventArgs)
		Response.Redirect("QueryStringRecipient.aspx" & "?Version=" & (CType(sender, Control)).ID)
	End Sub
End Class
