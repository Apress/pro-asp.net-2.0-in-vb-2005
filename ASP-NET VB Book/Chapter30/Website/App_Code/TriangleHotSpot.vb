Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace CustomHotSpots
	Public Class TriangleHotSpot : Inherits HotSpot
		Public Sub New()
			Width = 0
			Height = 0
			X = 0
			Y = 0
		End Sub

		Public Property Width() As Integer
			Get
				Return CInt(ViewState("Width"))
			End Get
			Set
				ViewState("Width") = Value
			End Set
		End Property
		Public Property Height() As Integer
			Get
				Return CInt(ViewState("Height"))
			End Get
			Set
				ViewState("Height") = Value
			End Set
		End Property
		Public Property X() As Integer
			Get
				Return CInt(ViewState("X"))
			End Get
			Set
				ViewState("X") = Value
			End Set
		End Property
		Public Property Y() As Integer
			Get
				Return CInt(ViewState("Y"))
			End Get
			Set
				ViewState("Y") = Value
			End Set
		End Property

		Protected Overrides ReadOnly Property MarkupName() As String
			Get
				Return "poly"
			End Get
		End Property

		Public Overrides Function GetCoordinates() As String
			' Note that this triangle doesn't support rotation.

			' Top coordinate.
			Dim topX As Integer = X
			Dim topY As Integer = Y - Height / 2

			' Bottom-left coordinate.
			Dim btmLeftX As Integer = X - Width / 2
			Dim btmLeftY As Integer = Y + Height / 2

			' Bottom-right coordinate.
			Dim btmRightX As Integer = X + Width / 2
			Dim btmRightY As Integer = Y + Height / 2

			Return topX.ToString() & "," & topY.ToString() & "," & btmLeftX.ToString() & "," & btmLeftY.ToString() & "," & btmRightX.ToString() & "," & btmRightY.ToString()
		End Function
	End Class
End Namespace