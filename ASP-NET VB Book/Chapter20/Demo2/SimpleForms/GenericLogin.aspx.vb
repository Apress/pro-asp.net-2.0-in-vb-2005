Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public partial Class GenericLogin : Inherits System.Web.UI.Page
	Private Function CreateStore() As ICredentialStore
		' Read the configuration string of the format
		' assemblyname, namespace.classname
		Dim ConfigEntry As String = WebConfigurationManager.AppSettings("CredentialStoreClass")
		Dim ConfigParts As String() = ConfigEntry.Split(New Char() {","c})

		' Load the assembly with the implementations
		Dim CurrentAsm As System.Reflection.Assembly = System.Reflection.Assembly.Load(ConfigParts(0).Trim())
		Dim Store As ICredentialStore = CType(CurrentAsm.CreateInstance(ConfigParts(1).Trim()), ICredentialStore)

		If Store Is Nothing Then
			Throw New Exception("Invalid credential store configuration!")
		Else
			Return Store
		End If
	End Function

	Protected Sub LoginAction_Click(ByVal sender As Object, ByVal e As EventArgs)
		Page.Validate()
		If (Not Page.IsValid) Then
		Return
		End If

		Dim CredStore As ICredentialStore = Me.CreateStore()

		Dim UserEmail As String
		If CredStore.Authenticate(UsernameText.Text, PasswordText.Text, UserEmail) Then
			Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, "MyTicketName", DateTime.Now, DateTime.Now.AddDays(2), False, UserEmail) ' Additional information

			' Encrypt the authentication ticket
			Dim EncryptedTicket As String = FormsAuthentication.Encrypt(ticket)

			' Create a cookie and add the ticket
			Dim AuthCookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, EncryptedTicket)
			Response.Cookies.Add(AuthCookie)

			' Redirect from the login page
			Response.Redirect(FormsAuthentication.GetRedirectUrl(UsernameText.Text, False))
		Else
			LegendStatus.Text = "Invalid username or password!"
		End If
	End Sub

	Protected Sub RegisterAction_Click(ByVal sender As Object, ByVal e As EventArgs)
		Page.Validate()
		If (Not Page.IsValid) Then
		Return
		End If

		Dim CredStore As ICredentialStore = Me.CreateStore()
		CredStore.CreateUser(UsernameText.Text, PasswordText.Text, UserEmailText.Text)
		LegendStatus.Text = "User created successfully, you can log in now!"
	End Sub
End Class
