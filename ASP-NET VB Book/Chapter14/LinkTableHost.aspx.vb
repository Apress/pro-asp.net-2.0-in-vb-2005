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

Public partial Class LinkTableHost : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Set the title.
		LinkTable1.Title = "A List of Links"

		' Set the hyperlinked item list.
		Dim items As LinkTableItem() = New LinkTableItem(2){}
		items(0) = New LinkTableItem("Test Item 1", "http://www.apress.com")
		items(1) = New LinkTableItem("Test Item 2", "http://www.apress.com")
		items(2) = New LinkTableItem("Test Item 3", "http://www.apress.com")
		LinkTable1.Items = items

	End Sub


	Protected Sub LinkClicked(ByVal sender As Object, ByVal e As LinkTableEventArgs)
		lblInfo.Text = "You clicked '" & e.SelectedItem.Text & "' but this page chose not to direct you to '" & e.SelectedItem.Url & "'."
		e.Cancel = True
	End Sub

End Class
