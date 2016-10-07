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

Public partial Class PageFlowTracing : Inherits System.Web.UI.Page
	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		lblInfo.Text &= "Page.Load event handled.<br/>"
		If Page.IsPostBack Then
			lblInfo.Text &= "<b>This is the second time you've seen this page.</b><br/>"
		End If
	End Sub

	Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs)
		lblInfo.Text &= "Page.Init event handled.<br/>"
	End Sub

	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		' You can supply just a message, or include a category label,
		' as shown here.
		Trace.Write("Button1_Click", "About to update the label.")
		lblInfo.Text &= "Button1.Click event handled.<br />"
		Trace.Write("Button1_Click", "Label updated.")
	End Sub

	Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
		lblInfo.Text &= "Page.PreRender event handled.<br/>"
	End Sub

	Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs)
		' This text never appears because the HTML is already
		' rendered for the page at this point.
		lblInfo.Text &= "Page.Unload event handled.<br/>"
	End Sub

End Class
