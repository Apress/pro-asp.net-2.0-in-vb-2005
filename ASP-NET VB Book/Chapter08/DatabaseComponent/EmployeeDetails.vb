Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace DatabaseComponent
	Public Class EmployeeDetails
        Private m_Employee_ID As Integer
        Private m_FirstName As String
        Private m_LastName As String
        Private m_TitleOfCourtesy As String

		Public Property EmployeeID() As Integer
			Get
                Return m_Employee_ID
            End Get
            Set(ByVal value As Integer)
                m_Employee_ID = Value
            End Set
		End Property
		Public Property FirstName() As String
			Get
                Return m_FirstName
            End Get
            Set(ByVal value As String)
                m_FirstName = Value
            End Set
		End Property
		Public Property LastName() As String
			Get
                Return m_LastName
            End Get
            Set(ByVal value As String)
                m_LastName = Value
            End Set
		End Property
		Public Property TitleOfCourtesy() As String
			Get
                Return m_TitleOfCourtesy
            End Get
            Set(ByVal value As String)
                m_TitleOfCourtesy = Value
            End Set
		End Property

        Public Sub New(ByVal p_Employee_ID As Integer, ByVal p_FirstName As String, ByVal p_LastName As String, ByVal p_TitleOfCourtesy As String)
            Me.m_Employee_ID = p_Employee_ID
            Me.m_FirstName = p_FirstName
            Me.m_LastName = p_LastName
            Me.m_TitleOfCourtesy = p_TitleOfCourtesy
        End Sub

		Public Sub New()
		End Sub
	End Class

End Namespace
