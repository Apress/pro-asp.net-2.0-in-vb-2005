Imports Microsoft.VisualBasic
Imports System
Public Interface ICredentialStore
	Function Authenticate(ByVal userName As String, ByVal userPassword As String, <System.Runtime.InteropServices.Out()> ByRef userData As String) As Boolean
	Sub CreateUser(ByVal userName As String, ByVal userPassword As String, ByVal userData As String)
End Interface
