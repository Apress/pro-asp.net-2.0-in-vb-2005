Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Imports System.Net
Imports System.Security.Cryptography.X509Certificates

''' <summary>
''' Summary description for WebRequestCreator
''' </summary>
Public Class WebRequestCreator
	Private Sub New()
	End Sub
	Public Shared Sub ExecuteWebRequest(ByVal url As String)
		Dim Certificate As X509Certificate2 = Nothing

		' Read the certificate from the store
		Dim store As X509Store = New X509Store(StoreName.My, StoreLocation.LocalMachine)
		store.Open(OpenFlags.ReadOnly)
		Try
			' Try to find the certificate
			' based on its common name
			Dim Results As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, "CN=Mario, CN=Szpuszta", False)

			If Results.Count = 0 Then
				Throw New Exception("Unable to find certificate!")
			Else
				Certificate = Results(0)
			End If
		Finally
			store.Close()
		End Try

		' Now create the web request
		Dim Request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
		Request.ClientCertificates.Add(Certificate)
		Dim Response As HttpWebResponse = CType(Request.GetResponse(), HttpWebResponse)
		' ...
	End Sub
End Class
