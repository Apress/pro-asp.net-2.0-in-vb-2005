Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports localhost

Public partial Class BindToXmlObjects : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	End Sub

	Protected Sub cmdGetData_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Create the proxy.
		Dim proxy As EmployeesService = New EmployeesService()

		' Call the web service and get the results.
		GridView1.DataSource = proxy.GetEmployees()
		GridView1.DataBind()
	End Sub
End Class