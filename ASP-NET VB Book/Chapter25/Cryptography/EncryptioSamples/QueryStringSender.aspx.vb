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

	Protected Sub SendCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim QueryString As EncryptedQueryString = New EncryptedQueryString()

		QueryString.Add("MyData", MyData.Text)
		QueryString.Add("MyTime", DateTime.Now.ToLongTimeString())
		QueryString.Add("MyDate", DateTime.Now.ToLongDateString())

		Response.Redirect("QueryStringRecipient.aspx?data=" & QueryString.ToString())
	End Sub
End Class
