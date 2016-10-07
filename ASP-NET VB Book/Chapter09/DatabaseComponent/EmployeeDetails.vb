Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace DatabaseComponent
	Public Class EmployeeDetails
        Private m_EmployeeID As Integer
        Private m_FirstName As String
        Private m_LastName As String
        Private m_TitleOfCourtesy As String

		Public Property EmployeeID() As Integer
			Get
                Return m_EmployeeID
			End Get
			Set
                m_EmployeeID = Value
			End Set
		End Property
		Public Property FirstName() As String
			Get
                Return m_FirstName
			End Get
			Set
                m_FirstName = Value
			End Set
		End Property
		Public Property LastName() As String
			Get
                Return m_LastName
			End Get
			Set
                m_LastName = Value
			End Set
		End Property
		Public Property TitleOfCourtesy() As String
			Get
                Return m_TitleOfCourtesy
			End Get
			Set
                m_TitleOfCourtesy = Value
			End Set
		End Property

        Public Sub New(ByVal pEmployeeID As Integer, ByVal pFirstName As String, ByVal pLastName As String, ByVal pTitleOfCourtesy As String)
            Me.m_EmployeeID = pEmployeeID
            Me.m_FirstName = pFirstName
            Me.m_LastName = pLastName
            Me.m_TitleOfCourtesy = pTitleOfCourtesy
        End Sub

		Public Sub New()
		End Sub
	End Class

End Namespace
