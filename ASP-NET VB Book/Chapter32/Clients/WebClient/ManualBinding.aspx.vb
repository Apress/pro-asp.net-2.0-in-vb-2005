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
Imports System.Net

Public partial Class ManualBinding : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdGetData_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Create the proxy.
		Dim proxy As EmployeesService = New EmployeesService()

		' This timeout will apply to all web service method calls.
		proxy.Timeout = 3000 ' 3,000 milliseconds is 3 seconds.

		Dim ds As DataSet = Nothing
		Try
			' Call the web service and get the results.
			ds = proxy.GetEmployees()
		Catch err As System.Net.WebException
			If err.Status = WebExceptionStatus.Timeout Then
				lblResult.Text = "Web service timed out after 3 seconds."
			Else
				lblResult.Text = "Another type of problem occurred."
			End If
		End Try
		' Bind the results.
		If Not ds Is Nothing Then
			GridView1.DataSource = ds.Tables(0)
			GridView1.DataBind()
		End If


	End Sub
End Class
