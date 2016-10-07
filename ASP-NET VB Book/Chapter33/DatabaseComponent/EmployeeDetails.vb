Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml.Serialization

Namespace DatabaseComponent
	<XmlType("Employee", Namespace := "http://www.apress.com/ProASP.NET/")> _
	Public Class EmployeeDetails
        Private nEmployee As Integer
        Private strFirstName As String
        Private strLastName As String
        Private strTitleOfCourtesy As String

		Public Property EmployeeID() As Integer
			Get
                Return nEmployee
            End Get
            Set(ByVal value As Integer)
                nEmployee = Value
            End Set
		End Property
		Public Property FirstName() As String
			Get
                Return strFirstName
            End Get
            Set(ByVal value As String)
                strFirstName = Value
            End Set
		End Property
		Public Property LastName() As String
			Get
                Return strLastName
            End Get
            Set(ByVal value As String)
                strLastName = Value
            End Set
		End Property
		Public Property TitleOfCourtesy() As String
			Get
                Return strTitleOfCourtesy
            End Get
            Set(ByVal value As String)
                strTitleOfCourtesy = Value
            End Set
		End Property

        Public Sub New(ByVal nEmployee As Integer, ByVal strFirstName As String, ByVal strLastName As String, ByVal strTitleOfCourtesy As String)
            Me.nEmployee = nEmployee
            Me.strFirstName = strFirstName
            Me.strLastName = strLastName
            Me.strTitleOfCourtesy = strTitleOfCourtesy
        End Sub

		Public Sub New()
		End Sub
	End Class

End Namespace
