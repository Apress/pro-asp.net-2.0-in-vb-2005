Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Namespace CustomServerControlsLibrary
	<Designer(GetType(TitledTextBoxDesigner))> _
	Public Class TitledTextBox : Inherits CompositeControl
		Public Sub New()
			MyBase.New()
			Title = ""
			Text = ""
		End Sub

		' Track the constituent controls with member variables
		' so they are accessible in all methods.
		Protected label As Label
		Protected textBox As TextBox

		Public Property Title() As String
			Get
				Return CStr(ViewState("Title"))
			End Get
			Set
				ViewState("Title") = Value
			End Set
		End Property

		Public Property Text() As String
			Get
				Return CStr(ViewState("Text"))
			End Get
			Set
				ViewState("Text") = Value
			End Set
		End Property

		Protected Overrides Sub CreateChildControls()
			' Add the label.
			label = New Label()
			label.EnableViewState = False
			label.Text = Title
			Controls.Add(label)

			' Add a space.
			Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

			' Add the text box.
			textBox = New TextBox()
			textBox.EnableViewState = False
			textBox.Text = Text
			AddHandler textBox.TextChanged, AddressOf OnTextChanged
			Controls.Add(textBox)
		End Sub

		Public Event TextChanged As EventHandler

		Protected Overridable Sub OnTextChanged(ByVal sender As Object, ByVal e As EventArgs)
			If Not TextChangedEvent Is Nothing Then
				RaiseEvent TextChanged(Me, e)
			End If
		End Sub
	End Class
End Namespace
