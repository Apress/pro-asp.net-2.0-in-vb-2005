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

Public partial Class ProgrammaticOutputCaching : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' Cache this page on the server.
		Response.Cache.SetCacheability(HttpCacheability.Public)

		' Use the cached copy of this page for the next 60 seconds.
		Response.Cache.SetExpires(DateTime.Now.AddSeconds(10))
		'Response.Cache.VaryByParams.IgnoreParams = true;

		' This additional line ensures that the browser can't
		' invalidate the page when the user clicks the Refresh button
		' (which some rogue browsers attempt to do).
		Response.Cache.SetValidUntilExpires(True)

		lblDate.Text = "The time is now:<br>" & DateTime.Now.ToString()

	End Sub
End Class
