<%@ Application Language="vb" %>

<script runat="server">

	Sub Profile_ProfileAutoSaving(ByVal sender As Object, ByVal e As ProfileAutoSaveEventArgs)
		If (Not e.Context.Items("AddressDirtyFlag") Is Nothing) AndAlso (CBool(e.Context.Items("AddressDirtyFlag")) = False) Then
			e.ContinueWithProfileAutoSave = False
		End If
	End Sub

	Sub Profile_MigrateAnonymous(ByVal sender As Object, ByVal pe As ProfileMigrateEventArgs)
		' Get the anonymous profile.
		Dim anonProfile As ProfileCommon = Profile.GetProfile(pe.AnonymousID)

		' Copy information to the authenticated profile.
		Profile.Address = anonProfile.Address

		' Delete the anonymous profile from the database.
		' (You could decide to skip this step to increase performance
		'  if you have a dedicated job scheduled on the database server
		'  to remove old anonymous profiles.)
		System.Web.Profile.ProfileManager.DeleteProfile(pe.AnonymousID)

		' Remove the anonymous identifier.
		AnonymousIdentificationModule.ClearAnonymousIdentifier()
	End Sub

</script>
