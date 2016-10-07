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

Public partial Class ReadWriteConfiguration_aspx : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		For Each connection As ConnectionStringSettings In WebConfigurationManager.ConnectionStrings
			Response.Write("Name: " & connection.Name & "<br />")
			Response.Write("Connection String: " & connection.ConnectionString & "<br /><br />")
		Next connection

		Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)

		Dim compSection As CompilationSection = CType(config.GetSection("system.web/compilation"), CompilationSection)
		For Each assm As AssemblyInfo In compSection.Assemblies
			Response.Write(assm.Assembly & "<br /")
		Next assm
	End Sub
End Class
