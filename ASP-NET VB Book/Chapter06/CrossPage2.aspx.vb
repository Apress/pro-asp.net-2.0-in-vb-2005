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

Public partial Class CrossPage2 : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Not PreviousPage Is Nothing Then
			If (Not PreviousPage.IsValid) Then
				Response.Redirect(Request.UrlReferrer.AbsolutePath & "?err=true")
			Else
				Response.Write("You came from a page titled " & PreviousPage.Header.Title & "<br /")
				Dim prevPage As CrossPage1 = TryCast(PreviousPage, CrossPage1)

				If Not prevPage Is Nothing Then
					Response.Write("You typed in this: " & prevPage.TextBox1.Text & "<br />")
				End If

				If PreviousPage.IsCrossPagePostBack Then
					Response.Write("The page was posted directly")
				Else
					Response.Write("You used Server.Transfer()")
				End If
			End If
		End If
	End Sub
End Class