Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
Imports System.Xml

''' <summary>
''' Summary description for EmployeesServiceCompatible
''' </summary>
<WebService(Namespace := "http://www.apress.com/ProASP.NET/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class EmployeesServiceCompatible : Inherits System.Web.Services.WebService
    '<WebMethod(Description:="Returns the full list of employees."), SoapDocumentMethod(ResponseElementName:="EmployeeList")> _
    <SoapDocumentMethod(ResponseElementName:="EmployeeList")> _
    <WebMethod(Description:="Returns the full list of employees.")> _
    Public Function GetEmployee() As EmployeeDetails()
        Return New EmployeeDetails() {New EmployeeDetails()}
    End Function

    <WebMethod(Description:="Returns the full list of employees.")> _
    Public Function GetCustomEmployee() As EmployeeDetailsCustom
        Return New EmployeeDetailsCustom(101, "Joe", "Dabiak")
    End Function

    <XmlType("Employee", Namespace:="http://www.apress.com/ProASP.NET/")> _
    Public Class EmployeeDetails
        <XmlElement("EmployeeID")> _
        Public ID As Integer
        Public FirstName As String
        Public LastName As String
        Public TitleOfCourtesy As String
    End Class


    Public Class EmployeeDetailsCustom : Implements IXmlSerializable
        Public ID As Integer
        Public FirstName As String
        Public LastName As String

        Public Sub New(ByVal employeeID As Integer, ByVal strFirstName As String, ByVal strLastName As String)
            Me.ID = employeeID
            Me.FirstName = strFirstName
            Me.LastName = strLastName
        End Sub

        Public Sub New()
        End Sub

        Private ns As String = "http://www.apress.com/ProASP.NET/CustomEmployeeDetails"
        Private Sub WriteXml(ByVal w As XmlWriter) Implements IXmlSerializable.WriteXml
            w.WriteStartElement("Employee", ns)

            w.WriteStartElement("Name", ns)
            w.WriteElementString("First", ns, FirstName)
            w.WriteElementString("Last", ns, LastName)
            w.WriteEndElement()

            w.WriteElementString("ID", ns, ID.ToString())
            w.WriteEndElement()
        End Sub

        Private Sub ReadXml(ByVal r As XmlReader) Implements IXmlSerializable.ReadXml
            r.MoveToContent()
            r.ReadStartElement("Employee")

            r.ReadStartElement("Name")
            FirstName = r.ReadElementString("First", ns)
            LastName = r.ReadElementString("Last", ns)
            r.ReadEndElement()
            r.MoveToContent()
            ID = Int32.Parse(r.ReadElementString("ID", ns))
            r.ReadEndElement()

        End Sub

        Private Function GetSchema() As System.Xml.Schema.XmlSchema Implements IXmlSerializable.GetSchema
            Return Nothing
        End Function
    End Class
End Class

