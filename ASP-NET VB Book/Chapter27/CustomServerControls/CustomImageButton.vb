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

<Assembly: WebResource("CustomServerControls.button1.jpg", "image/jpeg")>

Namespace CustomServerControlsLibrary
	<DefaultEvent("ImageClicked")> _
	Public Class CustomImageButton : Inherits WebControl : Implements IPostBackEventHandler
		Public Sub New()
			MyBase.New(HtmlTextWriterTag.Img)

		End Sub
		Protected Overrides Sub OnInit(ByVal e As EventArgs)
			ImageUrl = Page.ClientScript.GetWebResourceUrl(GetType(CustomImageButton), "CustomServerControls.button1.jpg")
		End Sub
		Public Property ImageUrl() As String
			Get
				Return CStr(ViewState("ImageUrl"))
			End Get
			Set
				ViewState("ImageUrl") = Value
			End Set
		End Property

		Protected Overrides Sub AddAttributesToRender(ByVal output As HtmlTextWriter)
			output.AddAttribute("name", UniqueID)
			output.AddAttribute("src", ImageUrl)
			output.AddAttribute("onClick", Page.ClientScript.GetPostBackEventReference(Me, ""))
		End Sub

		Public Event ImageClicked As EventHandler

		Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements IPostBackEventHandler.RaisePostBackEvent
			OnImageClicked(New EventArgs())
		End Sub

		Protected Overridable Sub OnImageClicked(ByVal e As EventArgs)
			' Check for at least one listener and then raise the event.
			If Not ImageClickedEvent Is Nothing Then
				RaiseEvent ImageClicked(Me, e)
			End If
		End Sub

	End Class
End Namespace
