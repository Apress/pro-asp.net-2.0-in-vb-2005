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

Public partial Class QueryStringRecipient : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		lblDate.Text = "The time is now:<br>" & DateTime.Now.ToString()
		Select Case Request.QueryString("Version")
			Case "cmdLarge"
				lblDate.Font.Size = FontUnit.XLarge
			Case "cmdNormal"
				lblDate.Font.Size = FontUnit.Large
			Case "cmdSmall"
				lblDate.Font.Size = FontUnit.Small
		End Select
	End Sub
End Class
