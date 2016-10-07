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

Public partial Class SimpleJavaScript : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		TextBox1.Attributes.Add("onMouseOver", "alert('Your mouse is hovering on TextBox1.');")
		TextBox2.Attributes.Add("onMouseOver", "alert('Your mouse is hovering on TextBox2.');")
	End Sub
End Class
