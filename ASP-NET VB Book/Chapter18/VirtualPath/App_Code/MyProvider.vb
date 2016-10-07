Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

''' <summary>
''' Summary description for MyProvider
''' </summary>
Public Class MyProvider : Inherits System.Web.Hosting.VirtualPathProvider
	Public Shared Sub Appinitialize()
		Dim fileProvider As MyProvider = New MyProvider()
		System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(fileProvider)
	End Sub

	Private Function GetFileFromDB(ByVal virtualPath As String) As String
		Dim contents As String
		Dim fileName As String = virtualPath.Substring(virtualPath.IndexOf("/"c, 1) + 1)

		' Read the file from the database
		Dim conn As SqlConnection = New SqlConnection()
		conn.ConnectionString = "data source=(local);Integrated Security=SSPI;initial catalog=AspContent"
		conn.Open()

		Try
			Dim cmd As SqlCommand = New SqlCommand("SELECT FileContents FROM AspContent " & "WHERE FileName=@fn", conn)
			cmd.Parameters.Add("@fn", fileName)
			contents = TryCast(cmd.ExecuteScalar(), String)
			If contents Is Nothing Then
				contents = String.Empty
			End If
		Catch
			contents = String.Empty
		Finally
			conn.Close()
		End Try

		Return contents
	End Function

	Public Overrides Overloads Function FileExists(ByVal virtualPath As String) As Boolean
		Dim contents As String = Me.GetFileFromDB(virtualPath)
		If contents.Equals(String.Empty) Then
			Return False
		Else
			Return True
		End If
	End Function

	Public Overrides Overloads Function GetFile(ByVal virtualPath As String) As System.Web.Hosting.VirtualFile
		Dim contents As String = Me.GetFileFromDB(virtualPath)
		If contents.Equals(String.Empty) Then
			Return Previous.GetFile(virtualPath)
		Else
			Return New MyVirtualFile(virtualPath, contents)
		End If
	End Function
End Class

Public Class MyVirtualFile : Inherits System.Web.Hosting.VirtualFile
	Private _FileContent As String

	Public Sub New(ByVal virtualPath As String, ByVal fileContent As String)
		MyBase.New(virtualPath)
		_FileContent = fileContent
	End Sub

	Public Overrides Function Open() As Stream
		Dim stream As Stream = New MemoryStream()
		Dim writer As StreamWriter = New StreamWriter(stream, Encoding.Unicode)

		writer.Write(_FileContent)
		writer.Flush()
		stream.Seek(0, SeekOrigin.Begin)
		Return stream
	End Function
End Class
