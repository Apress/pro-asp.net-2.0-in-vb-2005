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

Public partial Class ObjectDataSourceInsert : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
	End Sub
	Protected Sub sourceEmployees_Updating(ByVal sender As Object, ByVal e As ObjectDataSourceMethodEventArgs)

'set extra params
		'e.InputParameters["FirstName"] = "A";
	End Sub

	Protected Sub sourceEmployees_Inserted(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs)
		If e.Exception Is Nothing Then
			lblConfirmation.Text = "Inserted record " & e.ReturnValue.ToString()
		End If
	End Sub
End Class
