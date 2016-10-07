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
Imports localhost

Public partial Class SoapLogTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdTest_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim proxy As EmployeesService = New EmployeesService()
		proxy.GetEmployeesLogged()
	End Sub
End Class
