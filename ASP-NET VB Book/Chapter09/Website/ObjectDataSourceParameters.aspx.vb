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

Public partial Class ObjectDataSourceParameters : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)

	End Sub


	Protected Sub sourceEmployee_Selecting(ByVal sender As Object, ByVal e As ObjectDataSourceSelectingEventArgs)
		If e.InputParameters("employeeID") Is Nothing Then
		e.Cancel = True
		End If
	End Sub
End Class
