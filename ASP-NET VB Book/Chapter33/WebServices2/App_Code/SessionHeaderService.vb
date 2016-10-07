Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data


''' <summary>
''' Summary description for SessionHeaderService
''' </summary>
<WebService(Namespace := "http://tempuri.org/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class SessionHeaderService : Inherits System.Web.Services.WebService
	Public CurrentSessionHeader As SessionHeader

	<WebMethod(), SoapHeader("CurrentSessionHeader", Direction := SoapHeaderDirection.Out)> _
	Public Sub CreateSession()
		' Create the header.
		CurrentSessionHeader = New SessionHeader(Guid.NewGuid().ToString())

		' From now on, all session data will be indexed under that key.
		Application(CurrentSessionHeader.SessionID) = New Hashtable()
	End Sub

	<WebMethod(), SoapHeader("CurrentSessionHeader", Direction := SoapHeaderDirection.In)> _
	Public Sub SetSessionData(ByVal ds As DataSet)
		' Locking is not required, because no two clients
		' could share the same session ID.
		Dim session As Hashtable = CType(Application(CurrentSessionHeader.SessionID), Hashtable)
		session.Add("DataSet", ds)
	End Sub

	<WebMethod(), SoapHeader("CurrentSessionHeader", Direction := SoapHeaderDirection.In)> _
	Public Function GetSessionData() As DataSet
		Dim session As Hashtable = CType(Application(CurrentSessionHeader.SessionID), Hashtable)
		Return CType(session("DataSet"), DataSet)
	End Function

End Class

Public Class SessionHeader : Inherits SoapHeader
	Public SessionID As String

    Public Sub New(ByVal strSessionID As String)
        SessionID = strSessionID
    End Sub
    ' Default constructor is required for serialization.
    Public Sub New()
    End Sub
End Class