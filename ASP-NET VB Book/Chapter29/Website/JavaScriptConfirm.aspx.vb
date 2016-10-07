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

Public partial Class JavaScriptConfirm : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		Dim script As String = "<script type='text/javascript' language='JavaScript'>" & ControlChars.CrLf & "            function confirmSubmit() {" & ControlChars.CrLf & "				var doc = document.forms[0];" & ControlChars.CrLf & "				var msg = 'Are you sure you want to submit this data?';" & ControlChars.CrLf & "				return confirm(msg);" & ControlChars.CrLf & "				" & ControlChars.CrLf & "			}" & ControlChars.CrLf & "			</script>"

		Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Confirm", script)

		form1.Attributes.Add("onSubmit", "return confirmSubmit();")

	End Sub
	Protected Sub cmdSubmit_ServerClick(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
End Class
