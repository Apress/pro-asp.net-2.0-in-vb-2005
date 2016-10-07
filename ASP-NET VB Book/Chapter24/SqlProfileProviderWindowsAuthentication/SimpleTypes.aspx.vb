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

Public partial Class SimpleTypes : Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Calendar1.SelectedDate = DateTime.Now
	End Sub
	Protected Sub cmdShow_Click(ByVal sender As Object, ByVal e As EventArgs)
		lbl.Text = "First Name: " & Profile.FirstName & "<br />" & "Last Name: " & Profile.LastName & "<br />" & "Date of Birth: " & Profile.DateOfBirth.ToString()
	End Sub
	Protected Sub cmdSet_Click(ByVal sender As Object, ByVal e As EventArgs)
		Profile.FirstName = txtFirst.Text
		Profile.LastName = txtLast.Text
		Profile.DateOfBirth = Calendar1.SelectedDate
	End Sub
End Class
