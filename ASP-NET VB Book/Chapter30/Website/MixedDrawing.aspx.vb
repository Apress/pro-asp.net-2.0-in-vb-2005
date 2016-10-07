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

Public partial Class MixedDrawing : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create the in-memory bitmap where you will draw the image. 
		' This bitmap is 450 pixels wide and 100 pixels high.
		Dim image As Bitmap = New Bitmap(450, 100)
		Dim g As Graphics = Graphics.FromImage(image)

		' Ensure high-quality curves.
		g.SmoothingMode = SmoothingMode.AntiAlias

		' Paint the background.
		g.FillRectangle(Brushes.White, 0, 0, 450, 100)

		' Add an ellipse.
		g.FillEllipse(Brushes.PaleGoldenrod, 120, 13, 300, 50)
		g.DrawEllipse(Pens.Green, 120, 13, 299, 49)

		' Draw some text using a fancy font.
		Dim font As Font = New Font("Harrington", 20, FontStyle.Bold)
		g.DrawString("Oranges are tasty!", font, Brushes.DarkOrange, 150, 20)

		' Add a graphic from a file.
		Dim orangeImage As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("oranges.gif"))
		g.DrawImageUnscaled(orangeImage, 0, 0)

		' Render the image to the HTML output stream.
		image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)

		g.Dispose()
		image.Dispose()
	End Sub

End Class