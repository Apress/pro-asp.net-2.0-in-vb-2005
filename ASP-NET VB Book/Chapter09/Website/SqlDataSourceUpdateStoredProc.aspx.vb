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

Public partial Class SqlDataSourceUpdate2 : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub sourceEmployees_Selected(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)

	End Sub
	Protected Sub sourceEmployees_Updating(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)
		e.Command.Parameters("@First").Value = e.Command.Parameters("@FirstName").Value
		e.Command.Parameters("@Last").Value = e.Command.Parameters("@LastName").Value
		e.Command.Parameters.Remove(e.Command.Parameters("@FirstName"))
		e.Command.Parameters.Remove(e.Command.Parameters("@LastName"))

	End Sub
End Class
