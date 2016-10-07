Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace APress.ProAspNet.Providers.Store
	Public Class SimpleUser
		Public UserKey As Guid = Guid.Empty

		Public UserName As String = ""
		Public Password As String = ""
		Public PasswordSalt As String = ""

		Public Email As String = ""
		Public CreationDate As DateTime = DateTime.Now
		Public LastActivityDate As DateTime = DateTime.MinValue
		Public LastLoginDate As DateTime = DateTime.MinValue
		Public LastPasswordChangeDate As DateTime = DateTime.MinValue
		Public PasswordQuestion As String = ""
		Public PasswordAnswer As String = ""
		Public Comment As String
	End Class
End Namespace
