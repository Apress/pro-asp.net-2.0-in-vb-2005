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
Imports System.Data.SqlClient

Public partial Class SqlDataSourceLimits : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			lstCities.DataSource = sourceEmployeeCities.Select(DataSourceSelectArguments.Empty)
			lstCities.DataBind()
			lstCities.Items.Insert(0, "(Choose a City)")
			lstCities.Items.Insert(1, "(All Cities)")
			lstCities.SelectedIndex = 0
		End If
	End Sub
	Protected Overrides Sub OnPreRenderComplete(ByVal e As EventArgs)

	End Sub

	Protected Sub sourceEmployees_Selecting(ByVal sender As Object, ByVal e As SqlDataSourceSelectingEventArgs)
		If CStr(e.Command.Parameters("@City").Value) = "(Choose a City)" Then
			' Do nothing.
			e.Cancel = True
		Else If CStr(e.Command.Parameters("@City").Value) = "(All Cities)" Then
			' Manually change the command.
			e.Command.CommandText = "SELECT * FROM Employees"
		End If
	End Sub
End Class
