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

Public partial Class MasterDetailsSinglePage : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub gridMaster_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
		' Look for GridView items.
		If e.Row.RowType = DataControlRowType.DataRow Then
			' Retrieve the GridView control in the second column.
			Dim gridChild As GridView = CType(e.Row.Cells(1).Controls(1), GridView)

			sourceProducts.SelectParameters(0).DefaultValue = gridMaster.DataKeys(e.Row.DataItemIndex).Value.ToString()
			Dim data As Object = sourceProducts.Select(DataSourceSelectArguments.Empty)

			' Bind the grid.
			gridChild.DataSource = data
			gridChild.DataBind()


		End If
	End Sub
End Class
