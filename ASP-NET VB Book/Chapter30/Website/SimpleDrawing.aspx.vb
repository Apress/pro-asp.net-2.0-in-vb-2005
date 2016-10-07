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

Public partial Class SimpleDrawing : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create the in-memory bitmap where you will draw the image. 
		' This bitmap is 300 pixels wide and 50 pixels high.
        Dim theImage As Bitmap = New Bitmap(300, 50)
        Dim g As Graphics = Graphics.FromImage(theImage)

		' Draw a solid white rectangle..
		' Start from point (1, 1).
		' Make it 298 pixels wide and 48 pixels high.
        g.FillRectangle(Brushes.Black, 0, 0, 300, 50)
		g.DrawRectangle(Pens.Green, 0, 0, 299, 49)

		' Draw some text using a fancy font.
        Dim theFont As Font = New Font("Impact", 20, FontStyle.Regular)
        g.DrawString("This is a test.", theFont, Brushes.Blue, 10, 5)

        ' Render the image to the HTML output stream.
        theImage.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)

	End Sub

End Class