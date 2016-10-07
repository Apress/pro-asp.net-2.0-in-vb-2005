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
Imports System.Data.Common
Imports System.Text
Imports System.Web.Configuration

Public partial Class ProviderAgnosticCode : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' Get the factory.
		Dim factory As String = WebConfigurationManager.AppSettings("factory")
		Dim provider As DbProviderFactory = DbProviderFactories.GetFactory(factory)

		' Use this factory to create a connection.
		Dim con As DbConnection = provider.CreateConnection()
		con.ConnectionString = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString

		' Create the command.
		Dim cmd As DbCommand = provider.CreateCommand()
		cmd.CommandText = WebConfigurationManager.AppSettings("employeeQuery")
		cmd.Connection = con

		' Open the Connection and get the DataReader.
		con.Open()
		Dim reader As DbDataReader = cmd.ExecuteReader()

		' Cycle through the records, and build the HTML string.
		Dim htmlStr As StringBuilder = New StringBuilder("")
		Do While reader.Read()
			htmlStr.Append("<li>")
			htmlStr.Append(reader("TitleOfCourtesy"))
			htmlStr.Append(" <b>")
			htmlStr.Append(reader.GetString(1))
			htmlStr.Append("</b>, ")
			htmlStr.Append(reader.GetString(2))
			htmlStr.Append(" - employee from ")
			htmlStr.Append(reader.GetDateTime(6).ToString("d"))
			htmlStr.Append("</li>")
		Loop

		' Close the DataReader and the Connection.
		reader.Close()
		con.Close()

		' Show the generated HTML code on the page.
		HtmlContent.Text = htmlStr.ToString()
	End Sub
End Class
