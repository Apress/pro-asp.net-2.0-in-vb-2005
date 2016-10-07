Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Diagnostics


Public Class LogUserModule : Implements IHttpModule
	Public Sub Init(ByVal httpApp As HttpApplication) Implements IHttpModule.Init
		' Attach application event handlers.
		AddHandler httpApp.AuthenticateRequest, AddressOf OnAuthentication
	End Sub

	Private Sub OnAuthentication(ByVal sender As Object, ByVal a As EventArgs)
		' Get the current user identity.
		Dim name As String = HttpContext.Current.User.Identity.Name

		' Log the user name.
		Dim log As EventLog = New EventLog()
		log.Source = "Log User Module"
		log.WriteEntry(name & " was authenticated.")
	End Sub

	Public Sub Dispose() Implements IHttpModule.Dispose
	End Sub
End Class
