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
Imports System.Drawing.Drawing2D


Public partial Class PenExamples : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create the in-memory bitmap where you will draw the image. 
		' This bitmap is 300 pixels wide and 50 pixels high.
		Dim image As Bitmap = New Bitmap(500, 400)
		Dim g As Graphics = Graphics.FromImage(image)

		' Paint the background.
		g.FillRectangle(Brushes.White, 0, 0, 500, 400)

		' Create a pen to use for all the examples.
		Dim myPen As Pen = New Pen(Color.Blue, 10)

		' The y variable tracks the current y (up/down) position
		' in the image.
		Dim y As Integer = 60

		' Draw an example of each LineCap style in the first column (left).
		g.DrawString("LineCap Choices", New Font("Tahoma", 15, FontStyle.Bold), Brushes.Blue, 0, 10)
		For Each cap As LineCap In System.Enum.GetValues(GetType(LineCap))
			myPen.StartCap = cap
			myPen.EndCap = cap
			g.DrawLine(myPen, 20, y, 100, y)
			g.DrawString(cap.ToString(), New Font("Tahoma", 8), Brushes.Black, 120, y - 10)
			y += 30
		Next cap


		' Draw an example of each DashStyle in the second column (right).
		y = 60
		g.DrawString("DashStyle Choices", New Font("Tahoma", 15, FontStyle.Bold), Brushes.Blue, 200, 10)
		For Each dash As DashStyle In System.Enum.GetValues(GetType(DashStyle))
			myPen.DashStyle = dash
			g.DrawLine(myPen, 220, y, 300, y)
			g.DrawString(dash.ToString(), New Font("Tahoma", 8), Brushes.Black, 320, y - 10)
			y += 30
		Next dash
		' Render the image to the HTML output stream.
		image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)

		g.Dispose()
		image.Dispose()
	End Sub

End Class
