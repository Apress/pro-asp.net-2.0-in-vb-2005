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

Public partial Class DynamicButton : Inherits System.Web.UI.Page
	Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' Create a new button object.
		Dim newButton As Button = New Button()

		' Assign some text and an ID so you can retrieve it later.
		newButton.Text = "* Dynamic Button *"
		newButton.ID = "newButton"

		' Attach an event handler to the Button.Click event.
		AddHandler newButton.Click, AddressOf Button_Click

		' Add the putton to a placeholder.
		PlaceHolder1.Controls.Add(newButton)
	End Sub

	Protected Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		Label1.Text = "You clicked the dynamic button."
	End Sub

	Protected Sub cmdReset_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		Label1.Text = "(No value.)"
	End Sub

	Protected Sub cmdRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		' Search for the button, no matter what level it's at.
		Dim foundButton As Button = CType(Page.FindControl("newButton"), Button)

		' Remove the button.
		If Not foundButton Is Nothing Then
			foundButton.Parent.Controls.Remove(foundButton)
		End If
	End Sub

	Protected Sub cmdCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		' (Button is automatically created in postback.)
	End Sub
End Class
