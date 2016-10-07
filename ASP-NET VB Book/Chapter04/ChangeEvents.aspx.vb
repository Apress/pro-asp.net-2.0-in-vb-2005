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

Public partial Class ChangeEvents : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If (Not Page.IsPostBack) Then
			List1.Items.Add("Option 3")
			List1.Items.Add("Option 4")
			List1.Items.Add("Option 5")
		End If
	End Sub

	Protected Sub Ctrl_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs)
		Response.Write("<li>ServerChange detected for " & (CType(sender, Control)).ID & "</li>")
	End Sub

	Protected Sub List1_ServerChange(ByVal sender As Object, ByVal e As EventArgs)
		Response.Write("<li>ServerChange detected for List1. " & "The selected items are:</li><br/>")
		For Each li As ListItem In List1.Items
			If li.Selected Then
				Response.Write("&nbsp;&nbsp;- " & li.Value & "<br/>")
			End If
		Next li

	End Sub
	Protected Sub Submit1_ServerClick(ByVal sender As Object, ByVal e As EventArgs)
		Response.Write("<li>ServerClick detected for Submit1.</li>")
	End Sub
End Class
