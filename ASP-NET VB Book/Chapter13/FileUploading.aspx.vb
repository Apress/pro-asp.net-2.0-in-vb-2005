Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Public partial Class FileUploading : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Check if a file was submitted.
		If Uploader.PostedFile.ContentLength <> 0 Then
			Try
				If Uploader.PostedFile.ContentLength > 1064 Then
					' This exceeds the size limit you want to allow,.
					' You should check the size to prevent a denial of
					' service attack that attempts to fill up your
					' web server's hard drive.
					' You might also want to check the amount of 
					' remaining free space.
					lblStatus.Text = "Too large. This file is not allowed"
				Else
					' Retrieve the physical directory path for the Upload
					' subdirectory.
					Dim destDir As String = Server.MapPath("./Upload")

					' Extract the file name part from the full path of the
					' original file.
					Dim fileName As String = System.IO.Path.GetFileName(Uploader.PostedFile.FileName)

					' Combine the destination directory with the file name.
					Dim destPath As String = System.IO.Path.Combine(destDir, fileName)

					' Save the file on the server.
					Uploader.PostedFile.SaveAs(destPath)
					lblStatus.Text = "Thanks for submitting your file"

					' Display the whole file content.
					'StreamReader r = new StreamReader(Uploader.PostedFile.InputStream);
					'lblStatus.Text = r.ReadToEnd();
					'r.Close();
				End If
			Catch err As Exception
				lblStatus.Text = err.Message
			End Try
		End If

	End Sub
End Class
