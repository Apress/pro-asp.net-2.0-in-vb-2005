Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols


''' <summary>
''' Summary description for SecureService
''' </summary>
<WebService(Namespace := "http://tempuri.org/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class SecureService : Inherits System.Web.Services.WebService

	<WebMethod()> _
	Public Function TestAuthenticated() As String
		If (Not User.Identity.IsAuthenticated) Then
			Return "Not authenticated."
		Else
			Return "Authenticated as: " & User.Identity.Name
        End If

	End Function

End Class

