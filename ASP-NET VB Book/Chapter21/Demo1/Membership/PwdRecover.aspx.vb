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
Imports System.Net.Mail

Public partial Class PwdRecover : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub PasswordRecoveryCtrl_VerifyingAnswer(ByVal sender As Object, ByVal e As LoginCancelEventArgs)

	End Sub
	Protected Sub PasswordRecoveryCtrl_VerifyingUser(ByVal sender As Object, ByVal e As LoginCancelEventArgs)

	End Sub
	Protected Sub PasswordRecoveryCtrl_SendingMail(ByVal sender As Object, ByVal e As MailMessageEventArgs)

	End Sub
End Class
