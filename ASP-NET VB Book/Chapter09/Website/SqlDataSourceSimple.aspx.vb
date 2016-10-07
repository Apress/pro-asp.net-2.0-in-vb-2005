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

Public partial Class SqlDataSourceSimple : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub sourceEmployees_Selected(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
		If Not e.Exception Is Nothing Then
			' Mask the error with a generic message (for security purposes.)
			lblError.Text = "An exception occured performing the query."

			' Consider the error handled.
			e.ExceptionHandled = True
		End If
	End Sub
End Class
