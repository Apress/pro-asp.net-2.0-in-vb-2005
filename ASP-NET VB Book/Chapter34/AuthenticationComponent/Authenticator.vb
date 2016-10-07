Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.Web.Services3.Security.Tokens

Namespace AuthenticationComponent
	Public Class CustomAuthenticator : Inherits UsernameTokenManager
		' This method returns the password for the provided username
		' WSE will determine if they match
		Protected Overrides Function AuthenticateToken(ByVal token As UsernameToken) As String
			Dim username As String = token.Username

			' In real site, would query database or check XML file...
			If username = "dan" Then
				Return "secret"
			Else If username = "jenny" Then
				Return "opensesame"
			Else
				Return ""
			End If
		End Function
	End Class
End Namespace
