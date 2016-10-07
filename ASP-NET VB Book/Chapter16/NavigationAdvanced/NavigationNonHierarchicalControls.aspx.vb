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

Public partial Class NavigationNonHierarchicalControls : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			lstChild.DataSource = SiteMap.CurrentNode.ParentNode.ChildNodes
			lstParent.DataSource = SiteMap.CurrentNode.ParentNode.ParentNode.ChildNodes
			lstChild.DataTextField = "Title"
			lstChild.DataValueField = "Url"
			lstParent.DataTextField = "Title"
			lstParent.DataValueField = "Url"
			Me.DataBind()
		End If

	End Sub
	Protected Sub Nav_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim ctrl As ListControl = CType(sender, ListControl)
		Dim node As SiteMapNode = SiteMap.Provider.FindSiteMapNode(ctrl.SelectedValue)
		Response.Redirect(node.Url)
	End Sub


End Class
