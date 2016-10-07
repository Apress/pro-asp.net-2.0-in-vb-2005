Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data



<WebService(Namespace := "http://tempuri.org/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class EmployeesServiceCached : Inherits System.Web.Services.WebService

	Private connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=SSPI"


	<WebMethod(Description := "Returns the full list of employees.")> _
	Public Function GetEmployees() As DataSet
		Return GetEmployeesDataSet()
	End Function

	<WebMethod(Description := "Returns the full list of employees by city.")> _
	Public Function GetEmployeesByCity(ByVal city As String) As DataSet
		' Copy the DataSet.
		Dim dsFiltered As DataSet = GetEmployeesDataSet().Copy()

		' Remove the rows manually.
		' This is a good approach (rather than using the
		' DataTable.Select() method) because it is impervious
		' to SQL injection attacks.
		For Each row As DataRow In dsFiltered.Tables(0).Rows
			' Perform a case-insensitive compare.
			If String.Compare(row("City").ToString(), city.ToUpper(), True) <> 0 Then
				row.Delete()
			End If
		Next row

		' Remove these rows permanently.
		dsFiltered.AcceptChanges()

		Return dsFiltered
	End Function

	Private Function GetEmployeesDataSet() As DataSet
		Dim ds As DataSet

		If Not Context.Cache("EmployeesDataSet") Is Nothing Then
			' Retrieve it from the cache
			ds = CType(Context.Cache("EmployeesDataSet"), DataSet)
		Else
			' Retrieve it from the database.
			Dim sql As String = "SELECT EmployeeID, LastName, FirstName, Title, " & "TitleOfCourtesy, HomePhone, City FROM Employees"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
			ds = New DataSet()
			da.Fill(ds, "Employees")

			' Track when the DataSet was created. You can
			' retrieve this information in your client to test
			' that caching is working.
			ds.ExtendedProperties.Add("CreatedDate", DateTime.Now)

			' Store it in the cache for ten minutes.
			Context.Cache.Insert("EmployeesDataSet", ds, Nothing, DateTime.Now.AddMinutes(10), TimeSpan.Zero)
		End If
		Return ds
	End Function
End Class

