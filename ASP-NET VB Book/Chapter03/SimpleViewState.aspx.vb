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

Public partial Class SimpleViewState : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Label1.Text = "Hello World!"
	End Sub
	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim viewStateString As String = "/wEPDwUKLTE2MjY5MTY1NQ9kFgICAw9kFgICAQ8PFgIeBFRleHQFDEhlbGxvIFdvcmxkIWRkZPsbiNOyNAufEt7OvNIbVYcGWHqf"
		' viewStateString contains the view state information.
		' Convert the Base64 string to an ordinary array of bytes
		' representing ASCII characters.
		Dim stringBytes As Byte() = Convert.FromBase64String(viewStateString)

		' Deserialize and display the string.
		Dim decodedViewState As String = System.Text.Encoding.ASCII.GetString(stringBytes)
		Label1.Text = decodedViewState
	End Sub
End Class
