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

Public partial Class ControlTree : Inherits System.Web.UI.Page
	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Start examining all the controls.
		DisplayControl(Page.Controls, 0)

		' Add the closing horizontal line.
		Response.Write("<hr/>")
	End Sub

	Private Sub DisplayControl(ByVal controls As ControlCollection, ByVal depth As Integer)
		For Each control As Control In controls
			' Use the depth parameter to indent the control tree.
			Response.Write(New String("-"c, depth * 4) & "> ")

			' Display this control.
			Response.Write(control.GetType().ToString() & " - <b>" & control.ID & "</b><br/>")

			If Not control.Controls Is Nothing Then
				DisplayControl(control.Controls, depth + 1)
			End If
		Next control
	End Sub

End Class
