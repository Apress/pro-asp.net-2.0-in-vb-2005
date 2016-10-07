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

Imports System.Security.Cryptography

Public partial Class RandomNumber : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	End Sub

	Protected Sub RandomNumberCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim RandomValue As Byte() = New Byte(15){}
		Dim RndGen As RandomNumberGenerator = RandomNumberGenerator.Create()
		RndGen.GetBytes(RandomValue)
		ResultLabel.Text = Convert.ToBase64String(RandomValue)
	End Sub
End Class
