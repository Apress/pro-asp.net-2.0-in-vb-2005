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

Public partial Class SingleValueBinding : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Me.DataBind()
	End Sub
	Protected Function GetFilePath() As String
		Return "apress.gif"
	End Function

	Protected ReadOnly Property FilePath() As String
		Get
			Return "apress.gif"
		End Get
	End Property
End Class
