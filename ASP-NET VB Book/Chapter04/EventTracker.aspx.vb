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

Public partial Class EventTracker : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	End Sub

	Protected Sub CtrlChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim ctrlName As String = (CType(sender, Control)).ID
		lstEvents.Items.Add(ctrlName & " Changed")

		' Select the last item to scroll the list so the most recent
		' entries are visible.
		lstEvents.SelectedIndex = lstEvents.Items.Count - 1
	End Sub

End Class
