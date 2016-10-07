Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public partial Class DynamicChart : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create the in-memory bitmap where you will draw the image. 
		Dim image As Bitmap = New Bitmap(300, 200)
		Dim g As Graphics = Graphics.FromImage(image)

		g.FillRectangle(Brushes.White, 0, 0, 300, 200)
		g.SmoothingMode = SmoothingMode.AntiAlias

		If Not Session("ChartData") Is Nothing Then
			' Retrieve the chart data.
			Dim chartData As ArrayList = CType(Session("ChartData"), ArrayList)

			' Write some text to the image.
			g.DrawString("Sample Chart", New Font("Verdana", 18, FontStyle.Bold), Brushes.Black, New PointF(5, 5))

			' Calculate the total of all data values.
			Dim total As Single = 0
			For Each item As PieSlice In chartData
				total += item.DataValue
			Next item

			' Draw the pie slices.
			Dim currentAngle As Single = 0, totalAngle As Single = 0
			Dim i As Integer = 0
			For Each item As PieSlice In chartData
				currentAngle = item.DataValue / total * 360
				g.FillPie(New SolidBrush(GetColor(i)), 10, 40, 150, 150, CSng(Math.Round(totalAngle)), CSng(Math.Round(currentAngle)))
				totalAngle += currentAngle
				i += 1
			Next item

			' Create a legend for the chart.
			Dim colorBoxPoint As PointF = New PointF(200, 83)
			Dim textPoint As PointF = New PointF(222, 80)

			i = 0
			For Each item As PieSlice In chartData
				g.FillRectangle(New SolidBrush(GetColor(i)), colorBoxPoint.X, colorBoxPoint.Y, 20, 10)
				g.DrawString(item.Caption, New Font("Tahoma", 10), Brushes.Black, textPoint)
				colorBoxPoint.Y += 15
				textPoint.Y += 15
				i += 1
			Next item

			' Render the image to the HTML output stream.
			image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)
		End If
	End Sub

	Private Function GetColor(ByVal index As Integer) As Color
		' Support six different colors. This could be enhanced.
		If index > 5 Then
			index = index Mod 5
		End If

		Select Case index
			Case 0
				Return Color.Red
			Case 1
				Return Color.Blue
			Case 2
				Return Color.Yellow
			Case 3
				Return Color.Green
			Case 4
				Return Color.Orange
			Case 5
				Return Color.Purple
			Case Else
				Return Color.Black
		End Select
	End Function
End Class

Public Class PieSlice
    Private sngDataValue As Single
    Private strCaption As String

	Public Property DataValue() As Single
		Get
            Return sngDataValue
        End Get
        Set(ByVal value As Single)
            sngDataValue = Value
        End Set
	End Property

	Public Property Caption() As String
		Get
            Return strCaption
        End Get
        Set(ByVal value As String)
            strCaption = Value
        End Set
	End Property
    Public Sub New(ByVal strCaption As String, ByVal sngDataValue As Single)
        Caption = strCaption
        DataValue = sngDataValue
    End Sub

	Public Overrides Function ToString() As String
		Return Caption & " (" & DataValue.ToString() & ")"
	End Function

End Class
