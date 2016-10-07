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

Public partial Class PageProcessor : Inherits System.Web.UI.Page
	Protected PageToLoad As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		PageToLoad = Request.QueryString("Page")
	End Sub

End Class
