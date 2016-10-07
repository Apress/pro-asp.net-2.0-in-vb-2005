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
Imports DatabaseComponent
Imports System.Text

Public partial Class ComponentTest : Inherits System.Web.UI.Page

	' Create the database component.
	Private db As EmployeeDB = New EmployeeDB()

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		WriteEmployeesList()

		Dim empID As Integer = db.InsertEmployee(New EmployeeDetails(0, "Mr.", "Bellinaso", "Marco"))
		HtmlContent.Text &= "<br>Inserted 1 employee.<br>"

		WriteEmployeesList()

		db.DeleteEmployee(empID)
		HtmlContent.Text &= "<br>Deleted 1 employee.<br>"

		WriteEmployeesList()
	End Sub


	Private Sub WriteEmployeesList()
		Dim htmlStr As StringBuilder = New StringBuilder("")

		Dim numEmployees As Integer = db.CountEmployees()
		htmlStr.Append("<br>Total employees: <b>")
		htmlStr.Append(numEmployees.ToString())
		htmlStr.Append("</b><br><br>")

		Dim employees As EmployeeDetails() = db.GetEmployees()
		For Each emp As EmployeeDetails In employees
			htmlStr.Append("<li>")
			htmlStr.Append(emp.EmployeeID)
			htmlStr.Append(" ")
			htmlStr.Append(emp.TitleOfCourtesy)
			htmlStr.Append(" <b>")
			htmlStr.Append(emp.FirstName)
			htmlStr.Append("</b>, ")
			htmlStr.Append(emp.LastName)
			htmlStr.Append("</li>")
		Next emp
		htmlStr.Append("<br>")
		HtmlContent.Text += htmlStr.ToString()
	End Sub
End Class
