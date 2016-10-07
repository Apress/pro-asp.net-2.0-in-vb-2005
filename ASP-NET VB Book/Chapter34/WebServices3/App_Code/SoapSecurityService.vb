Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Security
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security
Imports System.Web.Configuration


''' <summary>
''' Summary description for SoapSecurityService
''' </summary>
<WebService(Namespace := "http://tempuri.org/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class SoapSecurityService : Inherits System.Web.Services.WebService
	' Store the SOAP header object.
	Public Ticket As TicketHeader

	<WebMethod()> _
	Public Sub CreateTestUser(ByVal username As String, ByVal password As String)
		Try
			If Not Membership.GetUser(username) Is Nothing Then
				Membership.DeleteUser(username)
			End If

			Membership.CreateUser(username, password)

			' Make this user an administrator.
			Dim role As String = "Administrator"
			If (Not Roles.RoleExists(role)) Then
				Roles.CreateRole(role)
			End If
			Roles.AddUserToRole(username, role)
		Catch err As Exception
			' Set a breakpoint here if needed for debugging.
			Throw err
		End Try
	End Sub

	<WebMethod(), SoapHeader("Ticket", Direction := SoapHeaderDirection.Out)> _
	Public Sub Login(ByVal username As String, ByVal password As String)
		If Membership.ValidateUser(username, password) Then
			' Create a new ticket.
            '
            Dim MyTicket As TicketIdentity = New TicketIdentity(username)

            ' Add this ticket to Application state.
            Application(MyTicket.Ticket) = MyTicket

            ' Create the SOAP header.
            Ticket = New TicketHeader(MyTicket.Ticket)
		Else
			Throw New SecurityException("Invalid credentials.")
		End If
	End Sub

	<WebMethod(Description := "Returns the full list of employees."), SoapHeader("Ticket", Direction := SoapHeaderDirection.In)> _
	Public Function GetEmployees() As DataSet
		AuthorizeUser(Ticket.Ticket, "Administrator")

		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
		' Create the command and the connection.
		Dim sql As String = "SELECT EmployeeID, LastName, FirstName, Title, " & "TitleOfCourtesy, HomePhone FROM Employees"
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
		Dim ds As DataSet = New DataSet()

		' Fill the DataSet.
		da.Fill(ds, "Employees")
		Return ds
	End Function

    '
    Private Function AuthorizeUser(ByVal MyTicket As String) As TicketIdentity
        Dim ticketIdentity As TicketIdentity = CType(Application(MyTicket), TicketIdentity)
        If Not MyTicket Is Nothing Then
            Return ticketIdentity
        Else
            Throw New SecurityException("Invalid ticket.")
        End If
    End Function


    Private Function AuthorizeUser(ByVal MyTicket As String, ByVal role As String) As TicketIdentity
        Dim ticketIdentity As TicketIdentity = AuthorizeUser(MyTicket)
        If Roles.IsUserInRole(ticketIdentity.UserName, role) Then
            Return ticketIdentity
        Else
            Throw New SecurityException("Insufficient permissions.")
        End If
    End Function


End Class

Public Class TicketIdentity
    Private theUser As String
    Public ReadOnly Property UserName() As String
        Get
            Return theUser
        End Get
    End Property

    Private MyTicket As String
    Public ReadOnly Property Ticket() As String
        Get
            Return MyTicket
        End Get
    End Property


    Public Sub New(ByVal theUser As String)
        Me.theUser = theUser

        ' Create the ticket GUID.
        Me.MyTicket = Guid.NewGuid().ToString()
    End Sub
End Class

Public Class TicketHeader : Inherits SoapHeader
	Public Ticket As String


    Public Sub New(ByVal MyTicket As String)
        Ticket = MyTicket
    End Sub

	Public Sub New()
	End Sub
End Class

