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
	Public Class LinkWebControl : Inherits WebControl
		Public Sub New()
			MyBase.New(HtmlTextWriterTag.A)

		End Sub




		Public Property Text() As String
			Get
				Return CStr(ViewState("Text"))
			End Get

			Set
				ViewState("Text") = Value
			End Set
		End Property

		Public Property HyperLink() As String
			Get
				Return CStr(ViewState("HyperLink"))
			End Get
			Set
				If Value.IndexOf("http://") = -1 Then
					Throw New ApplicationException("Specify HTTP as the protocol.")
				Else
					ViewState("HyperLink") = Value
				End If
			End Set
		End Property

		Protected Overrides Sub OnInit(ByVal e As EventArgs)
			Page.RegisterRequiresViewStateEncryption()
			MyBase.OnInit(e)
			If ViewState("HyperLink") Is Nothing Then
				ViewState("HyperLink") = "http://www.apress.com"
			End If

			If ViewState("Text") Is Nothing Then
				ViewState("Text") = "Click here to visit Apress"
			End If
		End Sub

		Protected Overrides Sub AddAttributesToRender(ByVal output As HtmlTextWriter)
			output.AddAttribute(HtmlTextWriterAttribute.Href, HyperLink)
			MyBase.AddAttributesToRender(output)
		End Sub

		Protected Overrides Sub RenderContents(ByVal output As HtmlTextWriter)
			output.Write(Text)
			MyBase.RenderContents(output) ' Calls RenderChildren()
		End Sub
	End Class

End Namespace
