<%@ Application Language="vb" %>

<script runat="server">

	Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs on application startup
	End Sub

	Protected Sub Application_OnEndRequest()
		Response.Write("<hr>This page was served at " & DateTime.Now.ToString())
	End Sub

	Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
		Response.Write("<font face=""Tahoma"" size=""2"" color=""red"">")
		Response.Write("Oops! Looks like an error occurred!!<hr></font>")
		Response.Write("<font face=""Arial"" size=""2"">")
		Response.Write(Server.GetLastError().Message.ToString())
		Response.Write("<hr>" & Server.GetLastError().ToString())
		Server.ClearError()
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
