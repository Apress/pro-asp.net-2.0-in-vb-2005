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
Imports ASP

Public partial Class StaticApplicationVariables : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim builder As StringBuilder = New StringBuilder()
        For Each file As String In Global.FileList
            builder.Append(file & "<br />")
        Next file
		lblInfo.Text = builder.ToString()
	End Sub
End Class
