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

Public partial Class GridViewFormattingEvents : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
		If e.Row.RowType = DataControlRowType.DataRow Then
			' Get the title of courtesy for the item that's being created.
			Dim title As String = CStr(DataBinder.Eval(e.Row.DataItem, "TitleOfCourtesy"))

			' If the title of courtesy is "Ms.", "Mrs.", or "Mr.",
			' change the item's colors.
			If title = "Ms." OrElse title = "Mrs." Then
				e.Row.BackColor = System.Drawing.Color.LightPink
				e.Row.ForeColor = System.Drawing.Color.Maroon
			Else If title = "Mr." Then
				e.Row.BackColor = System.Drawing.Color.LightCyan
				e.Row.ForeColor = System.Drawing.Color.DarkBlue
			End If
		End If

	End Sub
End Class
