Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace RolesDemo.Handlers
	Public Class GenericHandler : Implements IHttpHandler
		#Region "IHttpHandler Members"

		Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
			Get
				Return True
			End Get
		End Property

		Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
			Dim ret As Byte() = Nothing

			' Open the file specified in the context
			Dim PhysicalPath As String = context.Server.MapPath(context.Request.Path)
			Using fs As FileStream = New FileStream(PhysicalPath, FileMode.Open)
				ret = New Byte(fs.Length - 1){}
				fs.Read(ret, 0, CInt(fs.Length))
			End Using

			' If it is not null, return the byte array
			If Not ret Is Nothing Then
				context.Response.BinaryWrite(ret)
			End If
		End Sub

		#End Region
	End Class
End Namespace
