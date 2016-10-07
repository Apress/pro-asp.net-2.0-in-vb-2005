Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text

Namespace CustomServerControlsLibrary
	''' <summary>
	''' Summary description for PopUp.
	''' </summary>
	Public Class PopUp : Inherits Control
		Public Sub New()
			PopUnder = True
			Resizable = False
			Scrollbars = False
			Url = "about:blank"
			WindowHeight = 300
			WindowWidth = 300
		End Sub

		Public Property PopUnder() As Boolean
			Get
				Return CBool(ViewState("PopUnder"))
			End Get
			Set
				ViewState("PopUnder") = Value
			End Set
		End Property

		Public Property Url() As String
			Get
				Return CStr(ViewState("Url"))
			End Get
			Set
				ViewState("Url") = Value
			End Set
		End Property

		Public Property WindowHeight() As Integer
			Get
				Return CInt(ViewState("WindowHeight"))
			End Get
			Set
				If Value < 1 Then
					Throw New ArgumentException("WindowHeight must be greater than 0")
				End If
				ViewState("WindowHeight") = Value
			End Set
		End Property

		Public Property WindowWidth() As Integer
			Get
				Return CInt(ViewState("WindowWidth"))
			End Get
			Set
				If Value < 1 Then
					Throw New ArgumentException("WindowWidth must be greater than 0")
				End If
				ViewState("WindowWidth") = Value
			End Set
		End Property

		Public Property Resizable() As Boolean
			Get
				Return CBool(ViewState("Resizable"))
			End Get
			Set
				ViewState("Resizable") = Value
			End Set
		End Property

		Public Property Scrollbars() As Boolean
			Get
				Return CBool(ViewState("Scrollbars"))
			End Get
			Set
				ViewState("Scrollbars") = Value
			End Set
		End Property

		Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
			If Page.Request Is Nothing OrElse Page.Request.Browser.EcmaScriptVersion.Major >= 1 Then
				Dim javaScriptString As StringBuilder = New StringBuilder()
				javaScriptString.Append("<script language='JavaScript'>")
				javaScriptString.Append(Constants.vbLf & "<!-- ")
				javaScriptString.Append(Constants.vbLf & "window.open('")
				javaScriptString.Append(Url & "', '" & ID)
				javaScriptString.Append("','toolbar=0,")
				javaScriptString.Append("height=" & (WindowHeight & ","))
				javaScriptString.Append("width=" & (WindowWidth & ","))
				javaScriptString.Append("resizable=" & Convert.ToInt16(Resizable).ToString() & ",")
				javaScriptString.Append("scrollbars=" & Convert.ToInt16(Scrollbars).ToString())
				javaScriptString.Append("');" & Constants.vbLf)
				If PopUnder Then
				javaScriptString.Append("window.focus();")
				End If
				javaScriptString.Append(Constants.vbLf & "-->" & Constants.vbLf)
				javaScriptString.Append("</script>" & Constants.vbLf)
				writer.Write(javaScriptString.ToString())
			Else
				writer.Write("<!-- This browser does not support JavaScript -->")
			End If
		End Sub

	End Class
End Namespace
