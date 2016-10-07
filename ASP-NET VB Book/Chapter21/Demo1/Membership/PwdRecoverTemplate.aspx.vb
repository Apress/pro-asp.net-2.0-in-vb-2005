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

Public partial Class PwdRecoverTemplate : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub PasswordTemplateCtrl_SendingMail(ByVal sender As Object, ByVal e As MailMessageEventArgs)
		Dim lbl As Label = CType(PasswordTemplateCtrl.SuccessTemplateContainer.FindControl("EmailLabel"), Label)
		lbl.Text = e.Message.To(0).Address
	End Sub
End Class
