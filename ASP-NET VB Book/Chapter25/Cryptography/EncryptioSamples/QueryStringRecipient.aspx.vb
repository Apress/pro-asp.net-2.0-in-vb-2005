Imports Microsoft.VisualBasic
Imports System
Imports System.Text
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
		' Deserialize the encrypted query string
		Dim QueryString As EncryptedQueryString = New EncryptedQueryString(Request.QueryString("data"))

		' Write information to the screen
		Dim Info As StringBuilder = New StringBuilder()
		For Each key As String In QueryString.Keys
			Info.AppendFormat("{0} = {1}<br>", key, QueryString(key))
		Next key
		QueryStringLabel.Text = Info.ToString()
	End Sub
End Class
