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

Public partial Class DynamicHeader : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Page.Header.Title = "Dynamically Titled Page"

		' Not supported in beta2.
		'Page.Header.Metadata.Add("Keywords", ".NET, C#, ASP.NET");
		'Page.Header.Metadata.Add("Description", "A great website to learn .NET");

	End Sub
End Class
