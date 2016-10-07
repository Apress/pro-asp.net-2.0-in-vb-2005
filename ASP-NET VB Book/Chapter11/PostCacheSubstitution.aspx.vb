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

Public partial Class PostCacheSubstitution : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Response.Write("This date is cached: ")
		Response.Write(DateTime.Now.ToString() & "<br />")
		Response.Write("This date is not: ")
		Response.WriteSubstitution(New HttpResponseSubstitutionCallback(AddressOf GetDate))
	End Sub

	Private Shared Function GetDate(ByVal context As HttpContext) As String
		Return "<b>" & DateTime.Now.ToString() & "</b>"
	End Function

End Class
