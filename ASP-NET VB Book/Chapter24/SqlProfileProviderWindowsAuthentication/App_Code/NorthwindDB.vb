Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Caching


Public Class NorthwindDB
	Private connectionString As String

	Public Sub New()
		' Get connection string from web.config.
		connectionString = ConfigurationManager.ConnectionStrings("Northwind").ConnectionString
	End Sub

	Public Function GetCategoriesProductsDataSet() As DataSet
		Dim cache As Cache = HttpContext.Current.Cache
		Dim ds As DataSet

		' Check the cache.
		If Not cache("Northwind") Is Nothing Then
			ds = CType(cache("Northwind"), DataSet)
		Else
			' Create the DataSet.
			ds = CreateCategoriesProductsDataSet()

			' Cache the DataSet for five minutes.
			cache.Insert("Northwind", ds, Nothing, DateTime.Now.AddMinutes(5), TimeSpan.Zero)
		End If
		Return ds
	End Function

	Private Function CreateCategoriesProductsDataSet() As DataSet
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim ds As DataSet = New DataSet()

		Dim sqlProducts As String = "SELECT * FROM Products"
		Dim sqlCategories As String = "SELECT * FROM Categories"
		Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCategories, con)

		' Fill the DataSet.
		Try
			con.Open()
			da.Fill(ds, "Categories")
			da.SelectCommand.CommandText = sqlProducts
			da.Fill(ds, "Products")
		Catch err As Exception
			Throw New ApplicationException("Data error.")
		Finally
			con.Close()
		End Try
		Return ds
	End Function
End Class

