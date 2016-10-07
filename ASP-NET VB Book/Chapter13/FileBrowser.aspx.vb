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
Imports System.Diagnostics

Public partial Class FileBrowser : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			ShowDirectoryContents(Server.MapPath("."))
		End If
	End Sub

	Private Sub ShowDirectoryContents(ByVal path As String)
		' Define the current directory.
		Dim dir As DirectoryInfo = New DirectoryInfo(path)

		' Get the DirectoryInfo and FileInfo objects.
		Dim files As FileInfo() = dir.GetFiles()
		Dim dirs As DirectoryInfo() = dir.GetDirectories()

		' Show the directory listing.
		lblCurrentDir.Text = "Currently showing " & path
		gridFileList.DataSource = files
		gridDirList.DataSource = dirs
		Page.DataBind()

		' Clear any selection.
		gridFileList.SelectedIndex = -1

		' Keep track of the current path.
		ViewState("CurrentPath") = path
	End Sub

	Protected Sub gridFileList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		' Get the selected file.
		Dim file As String = CStr(gridFileList.DataKeys(gridFileList.SelectedIndex).Value)

		' The FormView shows a collection (or list) of items.
		' To accommodate this model, you must add the file object
		' to a collection of some sort.
		Dim files As ArrayList = New ArrayList()
		files.Add(New FileInfo(file))


		' Now show the selected file.
		formFileDetails.DataSource = files
		formFileDetails.DataBind()
	End Sub

	Protected Function GetVersionInfoString(ByVal path As Object) As String
		Dim info As FileVersionInfo = FileVersionInfo.GetVersionInfo(CStr(path))
		Return info.FileName & " " & info.FileVersion & "<br>" & info.ProductName & " " & info.ProductVersion
	End Function
	Protected Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim strPath As String = CStr(ViewState("CurrentPath"))
        strPath = Path.Combine(strPath, "..")
        strPath = Path.GetFullPath(strPath)
        ShowDirectoryContents(strPath)
	End Sub

	Protected Sub gridDirList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		' Get the selected directory.
		Dim dir As String = CStr(gridDirList.DataKeys(gridDirList.SelectedIndex).Value)

		' Now refresh the directory list to
		' show the selected directory.
		ShowDirectoryContents(dir)
	End Sub
End Class
