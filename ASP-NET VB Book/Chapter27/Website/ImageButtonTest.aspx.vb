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

Public partial Class ImageButtonTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub CustomImageButton1_ImageClicked(ByVal sender As Object, ByVal e As EventArgs)
		Dim count As Integer = 0
		If Not ViewState("count") Is Nothing Then
		count = CInt(ViewState("count"))
		End If
		count += 1
		Response.Write("Clicked " & count.ToString())
		ViewState("count") = count
	End Sub
End Class
