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

Public partial Class ViewStateObjects : Inherits System.Web.UI.Page

	' This will be created at the beginning of each request.
	Private textToSave As Hashtable = New Hashtable()


	Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Put the text in the Hashtable.
		SaveAllText(Page.Controls, True)

		' Store the entire collection in view state.
		ViewState("TextData") = textToSave
	End Sub

	Private Sub SaveAllText(ByVal controls As ControlCollection, ByVal saveNested As Boolean)
		For Each control As Control In controls
			If TypeOf control Is TextBox Then
				' Add the text to a collection.
				textToSave.Add(control.ID, (CType(control, TextBox)).Text)
			End If
			If (Not control.Controls Is Nothing) AndAlso saveNested Then
				SaveAllText(control.Controls, True)
			End If
		Next control
	End Sub

	Protected Sub cmdRestore_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Not ViewState("TextData") Is Nothing Then
			' Retrieve the hashtable.
			Dim savedText As Hashtable = CType(ViewState("TextData"), Hashtable)

			' Display all the text by looping through the hashtable.
			lblResults.Text = ""
			For Each item As DictionaryEntry In savedText
				lblResults.Text += CStr(item.Key) & " = " & CStr(item.Value) & "<br>"
			Next item
		End If
	End Sub
End Class
