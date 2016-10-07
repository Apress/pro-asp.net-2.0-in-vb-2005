<%@ Application Language="vb" %>

<script RunAt="server">

	Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs on application startup

	End Sub

	Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
		'  Code that runs on application shutdown

	End Sub

	Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when an unhandled error occurs

	End Sub

	Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
		If Not User Is Nothing Then
			If User.Identity.IsAuthenticated AndAlso Roles.Enabled Then
				Dim EveryoneRoleName As String = ConfigurationManager.AppSettings("EveryoneRoleName")

				If User.IsInRole(EveryoneRoleName) Then
					Return
				End If

				If (Not Roles.IsUserInRole(EveryoneRoleName)) AndAlso Roles.RoleExists(EveryoneRoleName) Then
					Roles.AddUserToRole(User.Identity.Name, EveryoneRoleName)
				End If
			End If
		End If
	End Sub

	Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when a new session is started

	End Sub

	Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when a session ends. 
		' Note: The Session_End event is raised only when the sessionstate mode
		' is set to InProc in the Web.config file. If session mode is set to StateServer 
		' or SQLServer, the event is not raised.

	End Sub

</script>

