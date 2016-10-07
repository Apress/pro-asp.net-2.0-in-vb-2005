Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.Security
Imports System.Configuration.Provider
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Permissions
Imports APress.ProAspNet.Providers.Store

Namespace APress.ProAspNet.Providers
	Public Class XmlRoleProvider : Inherits RoleProvider
		Private _FileName As String
		Private _ApplicationName As String
		Private _CurrentStore As RoleStore = Nothing

		Public Overrides Sub Initialize(ByVal name As String, ByVal config As NameValueCollection)
			If config Is Nothing Then
				Throw New ArgumentNullException("config")
			End If
			If String.IsNullOrEmpty(name) Then
				name = "XmlRoleProvider"
			End If
			If String.IsNullOrEmpty(config("description")) Then
				config.Remove("description")
				config.Add("description", "XML Role Provider")
			End If

			' Base initialization
			MyBase.Initialize(name, config)

			' Initialize properties
			_ApplicationName = "DefaultApp"
			For Each key As String In config.Keys
				If key.ToLower().Equals("applicationname") Then
					ApplicationName = config(key)
				Else If key.ToLower().Equals("filename") Then
					_FileName = config(key)
				End If
			Next key
		End Sub

		Private ReadOnly Property CurrentStore() As RoleStore
			Get
				If _CurrentStore Is Nothing Then
					_CurrentStore = RoleStore.GetStore(_FileName)
				End If
				Return _CurrentStore
			End Get
		End Property

		#Region "Properties"

		Public Overrides Property ApplicationName() As String
			Get
				Return _ApplicationName
			End Get
			Set
				_ApplicationName = Value
				_CurrentStore = Nothing
			End Set
		End Property

		#End Region

		#Region "Methods"

		Public Overrides Sub CreateRole(ByVal roleName As String)
			Try
				Dim NewRole As SimpleRole = New SimpleRole()
				NewRole.RoleName = roleName
				NewRole.AssignedUsers = New StringCollection()

				CurrentStore.Roles.Add(NewRole)
				CurrentStore.Save()
			Catch
				Throw
			End Try
		End Sub

		Public Overrides Function DeleteRole(ByVal roleName As String, ByVal throwOnPopulatedRole As Boolean) As Boolean
			Try
				Dim Role As SimpleRole = CurrentStore.GetRole(roleName)
				If Not Role Is Nothing Then
					CurrentStore.Roles.Remove(Role)
					CurrentStore.Save()
					Return True
				Else
					Return False
				End If
			Catch
				Throw
			End Try
		End Function

		Public Overrides Function RoleExists(ByVal roleName As String) As Boolean
			Try
				If Not CurrentStore.GetRole(roleName) Is Nothing Then
					Return True
				Else
					Return False
				End If
			Catch
				Throw
			End Try
		End Function

		Public Overrides Sub AddUsersToRoles(ByVal usernames As String(), ByVal roleNames As String())
			Try
				' Get the roles to be modified
				For Each roleName As String In roleNames
					Dim Role As SimpleRole = CurrentStore.GetRole(roleName)
					If Not Role Is Nothing Then
						For Each userName As String In usernames
							If (Not Role.AssignedUsers.Contains(userName)) Then
								Role.AssignedUsers.Add(userName)
							End If
						Next userName
					End If
				Next roleName

				CurrentStore.Save()
			Catch
				Throw
			End Try
		End Sub

		Public Overrides Sub RemoveUsersFromRoles(ByVal usernames As String(), ByVal roleNames As String())
			Try
				' Get the roles to be modified
				Dim TargetRoles As List(Of SimpleRole) = New List(Of SimpleRole)()
				For Each roleName As String In roleNames
					Dim Role As SimpleRole = CurrentStore.GetRole(roleName)
					If Not Role Is Nothing Then
						For Each userName As String In usernames
							If Role.AssignedUsers.Contains(userName) Then
								Role.AssignedUsers.Remove(userName)
							End If
						Next userName
					End If
				Next roleName

				CurrentStore.Save()
			Catch
				Throw
			End Try
		End Sub

		Public Overrides Function GetAllRoles() As String()
			Try
				Dim Results As String() = New String(CurrentStore.Roles.Count - 1){}
				Dim i As Integer = 0
                Do While i < Results.Length
                    Results(i) = CurrentStore.Roles(i).RoleName
                    i += 1
                Loop

				Return Results
			Catch
				Throw
			End Try
		End Function

		Public Overrides Function GetRolesForUser(ByVal username As String) As String()
			Try
				Dim RolesForUser As List(Of SimpleRole) = CurrentStore.GetRolesForUser(username)
				Dim Results As String() = New String(RolesForUser.Count - 1){}
				Dim i As Integer = 0
                Do While i < Results.Length
                    Results(i) = RolesForUser(i).RoleName
                    i += 1
                Loop
				Return Results
			Catch
				Throw
			End Try
		End Function

		Public Overrides Function GetUsersInRole(ByVal roleName As String) As String()
			Try
				Return CurrentStore.GetUsersInRole(roleName)
			Catch
				Throw
			End Try
		End Function

		Public Overrides Function IsUserInRole(ByVal username As String, ByVal roleName As String) As Boolean
			Try
				Dim Role As SimpleRole = CurrentStore.GetRole(roleName)
				If Not Role Is Nothing Then
					Return Role.AssignedUsers.Contains(username)
				Else
					Throw New ProviderException("Role does not exist!")
				End If
			Catch
				Throw
			End Try
		End Function

		Public Overrides Function FindUsersInRole(ByVal roleName As String, ByVal usernameToMatch As String) As String()
			Try
				Dim Results As List(Of String) = New List(Of String)()
				Dim Expression As Regex = New Regex(usernameToMatch.Replace("%", "\w*"))
				Dim Role As SimpleRole = CurrentStore.GetRole(roleName)
				If Not Role Is Nothing Then
					For Each userName As String In Role.AssignedUsers
						If Expression.IsMatch(userName) Then
							Results.Add(userName)
						End If
					Next userName
				Else
					Throw New ProviderException("Role does not exist!")
				End If

				Return Results.ToArray()
			Catch
				Throw
			End Try
		End Function

		#End Region
	End Class
End Namespace
