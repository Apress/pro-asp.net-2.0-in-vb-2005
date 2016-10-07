Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text

Namespace CustomServerControlsLibrary
	Public Class CustomTextBox : Inherits WebControl : Implements IPostBackDataHandler
		Protected Overrides Sub OnInit(ByVal e As EventArgs)
			Page.RegisterRequiresPostBack(Me)
		End Sub
		Public Sub New()
			MyBase.New(HtmlTextWriterTag.Input)
			Text = ""
		End Sub

		Public Property Text() As String
			Get
				Return CStr(ViewState("Text"))
			End Get
			Set
				ViewState("Text") = Value
			End Set
		End Property

		Protected Overrides Sub AddAttributesToRender(ByVal output As HtmlTextWriter)
			output.AddAttribute("name", Me.UniqueID)
			output.AddAttribute(HtmlTextWriterAttribute.Type, "text")
			output.AddAttribute(HtmlTextWriterAttribute.Value, Text)
			MyBase.AddAttributesToRender(output)
		End Sub

		' The method of IPostBackDataHandler that gets called to allow you 
		' to review the data posted to the page.
		Public Function LoadPostData(ByVal postDataKey As String, ByVal postData As NameValueCollection) As Boolean Implements IPostBackDataHandler.LoadPostData
			' Get the value posted and the past value.
			Dim postedValue As String = postData(postDataKey)
			Dim val As String = Text

			' If the value changed, then reset the value of the text property
			' and return true so the RaisePostDataChangedEvent will be fired.
			If val <> postedValue Then
				Text = postedValue
				Return True
			Else
				Return False
			End If
		End Function

		' Called if the LoadPostData() method returns true.
		Public Sub RaisePostDataChangedEvent() Implements IPostBackDataHandler.RaisePostDataChangedEvent
			' Call the method to raise the change event.
			OnTextChanged(New EventArgs())
		End Sub

		Public Event TextChanged As EventHandler

		Protected Overridable Sub OnTextChanged(ByVal e As EventArgs)
			' Check for at least one listener and then raise the event.
			If Not TextChangedEvent Is Nothing Then
				RaiseEvent TextChanged(Me, e)
			End If
		End Sub

	End Class
End Namespace

