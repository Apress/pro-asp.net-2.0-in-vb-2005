Imports Microsoft.VisualBasic
Imports System
Public Interface ICredentialStore
	Function Authenticate(ByVal userName As String, ByVal userPassword As String) As Boolean
	Sub CreateUser(ByVal userName As String, ByVal userPassword As String)
End Interface
