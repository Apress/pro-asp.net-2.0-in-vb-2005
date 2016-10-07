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

Public partial Class ViewStateTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Save the current text.
		SaveAllText(Page.Controls, True)
	End Sub

	Private Sub SaveAllText(ByVal controls As ControlCollection, ByVal saveNested As Boolean)
		For Each control As Control In controls
			If TypeOf control Is TextBox Then
				' Store the text using the unique control ID.
				ViewState(control.ID) = (CType(control, TextBox)).Text
			End If

			If (Not control.Controls Is Nothing) AndAlso saveNested Then
				SaveAllText(control.Controls, True)
			End If
		Next control
	End Sub

	Private Sub RestoreAllText(ByVal controls As ControlCollection, ByVal saveNested As Boolean)
		For Each control As Control In controls
			If TypeOf control Is TextBox Then
				If Not ViewState(control.ID) Is Nothing Then
					CType(control, TextBox).Text = CStr(ViewState(control.ID))
				End If
			End If

			If (Not control.Controls Is Nothing) AndAlso saveNested Then
				RestoreAllText(control.Controls, True)
			End If
		Next control
	End Sub
	Protected Sub cmdRestore_Click(ByVal sender As Object, ByVal e As EventArgs)

		' Retrieve the last saved text.
		RestoreAllText(Page.Controls, True)
	End Sub
End Class
