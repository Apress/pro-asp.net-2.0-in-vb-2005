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
Imports System.Web.Profile
Imports System.Data.SqlClient
Imports System.Collections.Specialized


Public Class FactoredProfileProvider : Inherits ProfileProvider
    Private m_Name As String
    Public Overrides ReadOnly Property Name() As String
        Get
            Return m_Name
        End Get
    End Property

    Private m_ConnectionString As String
	Public ReadOnly Property ConnectionString() As String
		Get
            Return m_ConnectionString
		End Get
	End Property

	Private updateProcedure As String
	Public ReadOnly Property UpdateUserProcedure() As String
		Get
			Return updateProcedure
		End Get
	End Property

	Private getProcedure As String
	Public ReadOnly Property GetUserProcedure() As String
		Get
			Return getProcedure
		End Get
	End Property

	' System.Configuration.Provider.ProviderBase.Initialize Method
    Public Overrides Sub Initialize(ByVal strName As String, ByVal config As NameValueCollection)
        ' Initialize values from web.config.
        Me.m_Name = strName

        Dim cString As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(config("connectionStringName"))
        If cString Is Nothing OrElse cString.ConnectionString.Trim() = "" Then
            Throw New HttpException("You must supply a connection string.")
        Else
            m_ConnectionString = cString.ConnectionString
        End If

        updateProcedure = config("updateUserProcedure")
        If updateProcedure.Trim() = "" Then
            Throw New HttpException("You must specify a stored procedure to use for updates.")
        End If

        getProcedure = config("getUserProcedure")
        If getProcedure.Trim() = "" Then
            Throw New HttpException("You must specify a stored procedure to use for retrieving individual user records.")
        End If
    End Sub

	Public Overrides Overloads Function DeleteProfiles(ByVal usernames As String()) As Integer
		Throw New Exception("The method or operation is not implemented.")
	End Function

	Public Overrides Overloads Function DeleteProfiles(ByVal profiles As ProfileInfoCollection) As Integer
		Throw New Exception("The method or operation is not implemented.")
	End Function

	Public Overrides Function DeleteInactiveProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal userInactiveSinceDate As DateTime) As Integer
		Throw New Exception("The method or operation is not implemented.")
	End Function

	Public Overrides Function FindInactiveProfilesByUserName(ByVal authenticationOption As ProfileAuthenticationOption, ByVal usernameToMatch As String, ByVal userInactiveSinceDate As DateTime, ByVal pageIndex As Integer, ByVal pageSize As Integer, <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer) As ProfileInfoCollection
		Throw New Exception("The method or operation is not implemented.")
	End Function

	Public Overrides Function FindProfilesByUserName(ByVal authenticationOption As ProfileAuthenticationOption, ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer) As ProfileInfoCollection
		Throw New Exception("The method or operation is not implemented.")
	End Function

	Public Overrides Function GetAllInactiveProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal userInactiveSinceDate As DateTime, ByVal pageIndex As Integer, ByVal pageSize As Integer, <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer) As ProfileInfoCollection
		Throw New Exception("The method or operation is not implemented.")
	End Function

	Public Overrides Function GetAllProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal pageIndex As Integer, ByVal pageSize As Integer, <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer) As ProfileInfoCollection
		Throw New Exception("The method or operation is not implemented.")
	End Function

	Public Overrides Function GetNumberOfInactiveProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal userInactiveSinceDate As DateTime) As Integer
		Throw New Exception("The method or operation is not implemented.")
	End Function

	Public Overrides Property ApplicationName() As String
		Get
			Throw New Exception("The method or operation is not implemented.")
		End Get
		Set
			Throw New Exception("The method or operation is not implemented.")
		End Set
	End Property

	Public Overrides Function GetPropertyValues(ByVal context As SettingsContext, ByVal properties As SettingsPropertyCollection) As SettingsPropertyValueCollection
		' If you want to mimic the behavior of the SqlProfileProvider,
		' you should also update the database with the last activity time
		' whenever this method is called.

		' This collection will store the retrieved values.
		Dim values As SettingsPropertyValueCollection = New SettingsPropertyValueCollection()

		' Prepare the command.
		' The only non-configurable assumption in this code is
		' that the stored procedure accepts a parameter named
		' @UserName. You could add additional configuration attributes
		' to make this detail configurable.
        Dim con As SqlConnection = New SqlConnection(m_ConnectionString)
		Dim cmd As SqlCommand = New SqlCommand(getProcedure, con)
		cmd.CommandType = CommandType.StoredProcedure
		cmd.Parameters.Add(New SqlParameter("@UserName", CStr(context("UserName"))))

		Try
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

			' Get the first row.
			reader.Read()

			' Look for every requested value.

            For Each propSettings As SettingsProperty In properties
                Dim value As SettingsPropertyValue = New SettingsPropertyValue(propSettings)

                ' Non-matching users are allowed
                ' (properties are kept, but no values are added).
                If reader.HasRows Then
                    value.PropertyValue = reader(propSettings.Name)
                End If
                values.Add(value)
            Next
			reader.Close()
		Finally
			con.Close()
		End Try

		Return values
	End Function

	Public Overrides Sub SetPropertyValues(ByVal context As SettingsContext, ByVal values As SettingsPropertyValueCollection)
		' If you want to mimic the behavior of the SqlProfileProvider,
		' you should also update the database with the last update time
		' whenever this method is called.

		' Prepare the command.
        Dim con As SqlConnection = New SqlConnection(m_ConnectionString)
		Dim cmd As SqlCommand = New SqlCommand(updateProcedure, con)
		cmd.CommandType = CommandType.StoredProcedure

		' Add the parameters.
		' The assumption is that every property maps exactly
		' to a single stored procedure parameter name.
		For Each value As SettingsPropertyValue In values
			cmd.Parameters.Add(New SqlParameter(value.Name, value.PropertyValue))
		Next value
		' Again, this code assumes the stored procedure accepts a parameter named
		' @UserName.
		cmd.Parameters.Add(New SqlParameter("@UserName", CStr(context("UserName"))))


		' Execute the command.
		Try
			con.Open()
			cmd.ExecuteNonQuery()
		Finally
			con.Close()
		End Try
	End Sub
End Class
