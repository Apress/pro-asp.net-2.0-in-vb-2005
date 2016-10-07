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
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap

Public partial Class UserLogger : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			Log("Page loaded for the first time.")
		Else
			Log("Page posted back.")
		End If
	End Sub
	Protected Sub cmdRead_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Not ViewState("LogFile") Is Nothing Then
			Dim fileName As String = CStr(ViewState("LogFile"))
			Using fs As FileStream = New FileStream(fileName, FileMode.Open)
				Dim r As StreamReader = New StreamReader(fs)

				' Read line by line (allows you to add
				' line breaks to the web page).
				Dim line As String
				Do
					line = r.ReadLine()
					If Not line Is Nothing Then
						lblInfo.Text += line & "<br>"
					End If
				Loop While Not line Is Nothing

				r.Close()
			End Using
		End If
	End Sub
	Protected Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Not ViewState("LogFile") Is Nothing Then
			File.Delete(CStr(ViewState("LogFile")))
		End If
	End Sub

	Private Sub Log(ByVal message As String)
		' Check for the file.	
		Dim mode As FileMode
		If ViewState("LogFile") Is Nothing Then
			' First, create a unique user-specific file name.
			ViewState("LogFile") = GetFileName()

			' The log file must be created.
			mode = FileMode.Create
		Else
			' Add to the existing file.
			mode = FileMode.Append
		End If

		' Write the message.
		' A using block ensures the file is automatically closed,
		' even in the case of error.
		Dim fileName As String = CStr(ViewState("LogFile"))
		Using fs As FileStream = New FileStream(fileName, mode)
			Dim w As StreamWriter = New StreamWriter(fs)
			w.WriteLine(DateTime.Now)
			w.WriteLine(message)
			w.Close()
		End Using
	End Sub

	Private Function GetFileName() As String
		' Create a unique filename.
		Dim fileName As String = "user." & Guid.NewGuid().ToString()

		' Put the file in the current web application path.
		Return Path.Combine(Request.PhysicalApplicationPath, fileName)
	End Function
End Class
