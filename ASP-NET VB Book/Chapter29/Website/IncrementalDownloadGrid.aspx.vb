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

Public partial Class IncrementalDownloadGrid : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			' Get data.
			Dim ds As DataSet = New DataSet()
			ds.ReadXml(Server.MapPath("Books.xml"))
			DataGrid1.DataSource = ds.Tables("Book")
			DataGrid1.DataBind()
		End If
	End Sub
End Class
