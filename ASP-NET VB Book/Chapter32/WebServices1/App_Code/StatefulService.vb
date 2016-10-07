Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols


''' <summary>
''' Summary description for StatefulService
''' </summary>
<WebService(Namespace := "http://tempuri.org/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class StatefulService : Inherits System.Web.Services.WebService
	<WebMethod(EnableSession := True)> _
	Public Sub StoreName(ByVal name As String)
		Session("Name") = name
	End Sub

	<WebMethod(EnableSession := True)> _
	Public Function GetName() As String
		If Session("Name") Is Nothing Then
			Return ""
		Else
			Return CStr(Session("Name"))
		End If
	End Function
End Class

