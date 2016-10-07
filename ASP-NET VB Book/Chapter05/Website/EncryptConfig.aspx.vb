Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Configuration

Public partial Class EncryptConfig : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
		Dim appSettings As ConfigurationSection = config.GetSection("appSettings")

		If appSettings.SectionInformation.IsProtected Then
			appSettings.SectionInformation.UnprotectSection()
		Else
			appSettings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
		End If
		config.Save()

	End Sub
End Class
