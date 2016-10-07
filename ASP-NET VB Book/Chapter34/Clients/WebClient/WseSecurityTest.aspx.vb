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
Imports localhost
Imports Microsoft.Web.Services3.Security.Tokens

Public partial Class WseSecurityTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdCallWithout_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim proxy As EmployeesService = New EmployeesService()
		GridView1.DataSource = proxy.GetEmployeesWseSecured()
		GridView1.DataBind()
	End Sub
	Protected Sub cmdCallWith_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim proxy As EmployeesServiceWse = New EmployeesServiceWse()

		'Uri newUrl = new Uri(proxy.Url);
		'proxy.Url = newUrl.Scheme + "://" + newUrl.Host + ":8080" + newUrl.AbsolutePath;

		' Add the WS-Security token.
		proxy.RequestSoapContext.Security.Tokens.Add(New UsernameToken("dan", "secret", PasswordOption.SendPlainText))

		GridView1.DataSource = proxy.GetEmployeesWseSecured()
		GridView1.DataBind()
	End Sub
End Class
