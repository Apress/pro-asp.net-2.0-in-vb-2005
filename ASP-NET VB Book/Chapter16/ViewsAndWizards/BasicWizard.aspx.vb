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
Imports System.Text

Public partial Class BasicWizard : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
		Dim sb As StringBuilder = New StringBuilder()
		sb.Append("<b>You chose: <br />")
		sb.Append("Programming Language: ")
		sb.Append(lstLanguage.Text)
		sb.Append("<br />Total Employees: ")
		sb.Append(txtEmpCount.Text)
		sb.Append("<br />Total Locations: ")
		sb.Append(txtLocCount.Text)
		sb.Append("<br />Licenses Required: ")
		For Each item As ListItem In lstTools.Items
			If item.Selected Then
				sb.Append(item.Text)
				sb.Append(" ")
			End If
		Next item
		sb.Append("</b>")
		lblSummary.Text = sb.ToString()
	End Sub
End Class
