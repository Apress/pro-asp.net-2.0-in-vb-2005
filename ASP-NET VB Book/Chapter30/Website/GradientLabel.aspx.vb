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
Imports System.Drawing.Imaging
Imports System.IO


Public partial Class GradientLabel : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim text As String = Server.UrlDecode(Request.QueryString("Text"))
		Dim textSize As Integer = Int32.Parse(Request.QueryString("TextSize"))
		Dim textColor As Color = Color.FromArgb(Int32.Parse(Request.QueryString("TextColor")))
		Dim gradientColorA As Color = Color.FromArgb(Int32.Parse(Request.QueryString("GradientColorA")))
		Dim gradientColorB As Color = Color.FromArgb(Int32.Parse(Request.QueryString("GradientColorB")))

		' Define the font.
		Dim font As Font = New Font("Tahoma", textSize, FontStyle.Bold)

		' Use a test image to measure the text.
		Dim image As Bitmap = New Bitmap(1, 1)
		Dim g As Graphics = Graphics.FromImage(image)
		Dim size As SizeF = g.MeasureString(text, font)
		g.Dispose()
		image.Dispose()

		' Using these measurements, try to choose a reasonable bitmap size.
		' Even if the text is large, cap the size at some maximum to
		' prevent causing a serious server slowdown!
		' (Allow for a 10 pixel buffer on all sides).
		Dim width As Integer = CInt(Math.Min(size.Width + 20, 800))
		Dim height As Integer = CInt(Math.Min(size.Height + 20, 800))
		image = New Bitmap(width, height)
		g = Graphics.FromImage(image)

		Dim brush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(New Point(0, 0), image.Size), gradientColorA, gradientColorB, LinearGradientMode.ForwardDiagonal)

		' Draw the gradient background.
		g.FillRectangle(brush, 0, 0, 300, 300)

		' Draw the label text.
		g.DrawString(text, font, New SolidBrush(textColor), 10, 10)


		' Render the image to the HTML output stream.
		image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)

		g.Dispose()
		image.Dispose()
	End Sub


End Class