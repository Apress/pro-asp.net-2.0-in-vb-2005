Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports FileDataComponent


<WebService(Namespace := "http://tempuri.org/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class FileService : Inherits System.Web.Services.WebService
	Private folder As String = "c:\temp"

	<WebMethod(BufferResponse := False), SoapDocumentMethod(ParameterStyle := SoapParameterStyle.Bare)> _
	Public Function DownloadFile(ByVal serverFileName As String) As FileData
		' Allow downloading of a named file in a set folder.
		serverFileName = Path.GetFileName(serverFileName)
		Dim serverFilePath As String = Path.Combine(folder, serverFileName)
		Return New FileData(serverFilePath)
	End Function
End Class

