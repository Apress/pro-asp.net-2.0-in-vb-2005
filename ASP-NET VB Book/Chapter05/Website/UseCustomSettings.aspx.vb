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
Imports System.Text

Public partial Class UseCustomSettings_aspx : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim builder As StringBuilder = New StringBuilder()
		Dim config As Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)

		Dim custSection As OrderService = CType(config.GetSection("orderService"), OrderService)

		lblInfo.Text &= "Retrieved service information...<br />" & "<b>Location:</b> " & custSection.Location & "<br /><b>Available:</b> " & custSection.Available.ToString() & "<br /><b>Timeout:</b> " & custSection.PollTimeout.ToString() & "<br /><br />"

	End Sub
End Class
