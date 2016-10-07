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
Imports System.IO

Public partial Class XmlLabelTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim r As StreamReader = File.OpenText(Server.MapPath("DvdList.xml"))
		Dim text As String = r.ReadToEnd()
		r.Close()

		RichLabel1.Text = text
	End Sub
End Class
