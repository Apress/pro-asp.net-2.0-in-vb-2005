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

Public partial Class DynamicPanelTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Panel1_Refreshing(ByVal sender As Object, ByVal e As EventArgs)
		Label1.Text = "This was refreshed without a postback at " & DateTime.Now.ToString()
	End Sub
End Class
