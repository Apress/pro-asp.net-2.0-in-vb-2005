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


Public partial Class ThumbnailViewer : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If (Request.QueryString("X") Is Nothing) OrElse (Request.QueryString("Y") Is Nothing) OrElse (Request.QueryString("FilePath") Is Nothing) Then
			' There is missing data, so don't display anything.
			' Other options including choosing reasonable defaults,
			' or returning an image with some static error text.
		Else
			Dim x As Integer = Int32.Parse(Request.QueryString("X"))
			Dim y As Integer = Int32.Parse(Request.QueryString("Y"))
			Dim file As String = Server.UrlDecode(Request.QueryString("FilePath"))

			' Create the in-memory bitmap where you will draw the image. 
			Dim image As Bitmap = New Bitmap(x, y)
			Dim g As Graphics = Graphics.FromImage(image)

			' Load the file data.
			Dim thumbnail As System.Drawing.Image = System.Drawing.Image.FromFile(file)

			' Draw the thumbnail.
			g.DrawImage(thumbnail, 0, 0, x, y)

			' Render the image.
			image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)
			g.Dispose()
			image.Dispose()
		End If
	End Sub
End Class