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
Imports System.IO


Public partial Class ThumbnailsInDirectory : Inherits System.Web.UI.Page

	Protected Sub cmdShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		' Get a string array with all the image files.
		Dim dir As DirectoryInfo = New DirectoryInfo(txtDir.Text)
		gridThumbs.DataSource = dir.GetFiles("*.bmp")

		' Bind the string array.
		gridThumbs.DataBind()
	End Sub

	Protected Function GetImageUrl(ByVal path As Object) As String
		Return "ThumbnailViewer.aspx?x=50&y=50&FilePath=" & Server.UrlEncode(CStr(path))
	End Function

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

	End Sub

End Class