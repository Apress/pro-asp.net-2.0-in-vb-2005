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
Imports System.IO


Public partial Class GradientExamples : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create the in-memory bitmap where you will draw the image. 
		Dim image As Bitmap = New Bitmap(300, 300)
		Dim g As Graphics = Graphics.FromImage(image)

		' Paint the background.
		g.FillRectangle(Brushes.White, 0, 0, 300, 300)

		' Create a brush to use.
		Dim myBrush As LinearGradientBrush

		' Create variable to track the coordinates in the image.
		Dim y As Integer = 20
		Dim x As Integer = 20

		' Show a rectangle with each type of gradient.
		For Each gradientStyle As LinearGradientMode In System.Enum.GetValues(GetType(LinearGradientMode))
			myBrush = New LinearGradientBrush(New Rectangle(x, y, 100, 60), Color.Violet, Color.White, gradientStyle)
			g.FillRectangle(myBrush, x, y, 100, 60)
			g.DrawString(gradientStyle.ToString(), New Font("Tahoma", 8), Brushes.Black, 110 + x, y + 20)
			y += 70
		Next gradientStyle

		' Render the image to the HTML output stream.
		image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)

		g.Dispose()
		image.Dispose()
	End Sub

End Class