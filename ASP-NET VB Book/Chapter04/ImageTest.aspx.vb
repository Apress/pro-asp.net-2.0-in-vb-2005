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

Public partial Class ImageTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
		lblResult.Text = "You clicked at (" & e.X.ToString() & ", " & e.Y.ToString() & "). "

		If (e.Y < 100) AndAlso (e.Y > 20) AndAlso (e.X > 20) AndAlso (e.X < 275) Then
			lblResult.Text &= "You clicked on the button surface."
		Else
			lblResult.Text &= "You clicked the button border."
		End If

	End Sub
End Class
