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

Public partial Class StyleAttributes : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Only perform the initialization the first time the page is requested.
		' After that, this information is tracked in view state.
		If (Not Page.IsPostBack) Then
			' Set the style attributes to configure appearance.
			TextBox1.Style("font-size") = "20px"
			TextBox1.Style("color") = "red"

			' Use a slightly different but equivalent syntax
			' for setting a style attribute.
			TextBox1.Style.Add("background-color", "lightyellow")

			' Set the default text.
			TextBox1.Value = "<Enter e-mail address here>"

			' Set other nonstandard attributes.
			TextBox1.Attributes("onfocus") = "alert(TextBox1.value)"
		End If
	End Sub

End Class
