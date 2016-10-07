<%@ Application Language="vb" %>

<script runat="server">

	Sub Profile_MigrateAnonymous(ByVal sender As Object, ByVal pe As ProfileMigrateEventArgs)
		' Get the anonymous profile.
		Dim anonProfile As ProfileCommon = Profile.GetProfile(pe.AnonymousID)

		' Copy information to the authenticated profile (but only if there's information there).
		If Not anonProfile.Address.Name Is Nothing Then
			Profile.Address = anonProfile.Address
		End If

		' Delete the anonymous profile from the database.
		' (You could decide to skip this step to increase performance
		'  if you have a dedicated job scheduled on the database server
		'  to remove old anonymous profiles.)
		System.Web.Profile.ProfileManager.DeleteProfile(pe.AnonymousID)

		' Remove the anonymous identifier.
		AnonymousIdentificationModule.ClearAnonymousIdentifier()
	End Sub

</script>
