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

Public partial Class CrossPage1 : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Not Request.QueryString("err") Is Nothing Then
			Page.Validate()
		End If
	End Sub
	Public ReadOnly Property TextBox1() As TextBox
		Get
			Return txt1
		End Get
	End Property

	Protected Sub cmdTransfer_Click(ByVal sender As Object, ByVal e As EventArgs)
		Server.Transfer("CrossPage2.aspx", True)
	End Sub
End Class
