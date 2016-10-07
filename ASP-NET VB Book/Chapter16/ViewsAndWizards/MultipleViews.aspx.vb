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

Public partial Class MultipleViews : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			DropDownList1.DataSource = MultiView1.Views
			DropDownList1.DataTextField = "ID"
			DropDownList1.DataBind()
		End If

	End Sub

	Protected Sub cmdShow_Click(ByVal sender As Object, ByVal e As EventArgs)
		MultiView1.ActiveViewIndex = DropDownList1.SelectedIndex
	End Sub
	Protected Sub MultiView1_ActiveViewChanged(ByVal sender As Object, ByVal e As EventArgs)
		DropDownList1.SelectedIndex = MultiView1.ActiveViewIndex
	End Sub
End Class
