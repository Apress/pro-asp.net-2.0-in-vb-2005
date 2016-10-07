Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web

Namespace GDI_CustomControls
	Public Class GradientLabel : Inherits Control
		Public Sub New()
			Text = ""
			TextColor = Color.White
			GradientColorA = Color.Blue
			GradientColorB = Color.DarkBlue
			TextSize = 14
		End Sub

		Public Property Text() As String
			Get
				Return CStr(ViewState("Text"))
			End Get
			Set
				ViewState("Text") = Value
			End Set
		End Property

		Public Property TextSize() As Integer
			Get
				Return CInt(ViewState("TextSize"))
			End Get
			Set
				ViewState("TextSize") = Value
			End Set
		End Property

		Public Property GradientColorA() As Color
			Get
				Return CType(ViewState("ColorA"), Color)
			End Get
			Set
				ViewState("ColorA") = Value
			End Set
		End Property

		Public Property GradientColorB() As Color
			Get
				Return CType(ViewState("ColorB"), Color)
			End Get
			Set
				ViewState("ColorB") = Value
			End Set
		End Property

		Public Property TextColor() As Color
			Get
				Return CType(ViewState("TextColor"), Color)
			End Get
			Set
				ViewState("TextColor") = Value
			End Set
		End Property

		Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
			Dim context As HttpContext = HttpContext.Current
			writer.Write("<img src='" & "GradientLabel.aspx?" & "Text=" & context.Server.UrlEncode(Text) & "&TextSize=" & TextSize.ToString() & "&TextColor=" & TextColor.ToArgb() & "&GradientColorA=" & GradientColorA.ToArgb() & "&GradientColorB=" & GradientColorB.ToArgb() & "'>")
		End Sub

	End Class
End Namespace
