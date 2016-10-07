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

Public partial Class UserLoggerSerialization : Inherits System.Web.UI.Page
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
				' Create a formatter.
				Dim formatter As BinaryFormatter = New BinaryFormatter()

				' Get all the serialized objects.
				Do While fs.Position < fs.Length
					' Deserialize the object from the file.
					Dim entry As LogEntry = CType(formatter.Deserialize(fs), LogEntry)

					' Display its information.
                    lblInfo.Text += entry.MyDate.ToString() & "<br>"
                    lblInfo.Text += entry.MyMessage & "<br>"
				Loop
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
			' Create a LogEntry object.
			Dim entry As LogEntry = New LogEntry(message)

			' Create a formatter.
			Dim formatter As BinaryFormatter = New BinaryFormatter()
			'SoapFormatter formatter = new SoapFormatter();

			' Serialize the object to a file.
			formatter.Serialize(fs, entry)

			' Serialize to a memory stream so you can display it.
			Dim ms As MemoryStream = New MemoryStream()
			formatter.Serialize(ms, entry)

			' Read it back and write it to the Debug window.
			Dim r As StreamReader = New StreamReader(ms, System.Text.Encoding.ASCII)
			ms.Position = 0
			Dim x As String = r.ReadToEnd()
			r.Close()
			ms.Close()
		End Using
	End Sub

	Private Function GetFileName() As String
		' Create a unique filename.
		Dim fileName As String = "user." & Guid.NewGuid().ToString()

		' Put the file in the current web application path.
		Return Path.Combine(Request.PhysicalApplicationPath, fileName)
	End Function
End Class
<Serializable()> _
Public Class LogEntry
    Private strMessage As String

    Private dteDate As DateTime

    Public Property MyMessage() As String
        Get
            Return strMessage
        End Get
        Set(ByVal value As String)
            strMessage = value
        End Set
    End Property
    Public Property MyDate() As DateTime
        Get
            Return dteDate
        End Get
        Set(ByVal value As DateTime)
            dteDate = value
        End Set
    End Property

    Public Sub New(ByVal pMessage As String)
        Me.MyMessage = pMessage
        Me.MyDate = DateTime.Now
    End Sub
End Class