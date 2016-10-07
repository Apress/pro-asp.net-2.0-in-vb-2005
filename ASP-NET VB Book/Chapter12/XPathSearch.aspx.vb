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
Imports System.Xml
Imports System.Text

Public partial Class XPathSearch : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' Load the XML file.
		Dim xmlFile As String = Server.MapPath("DvdList.xml")
		Dim doc As XmlDocument = New XmlDocument()
		doc.Load(xmlFile)

		' Retrieve the title of every science fiction move.
		Dim nodes As XmlNodeList = doc.SelectNodes("/DvdList/DVD/Title[../@Category='Science Fiction']")

		' Display the titles.
		Dim str As StringBuilder = New StringBuilder()
		For Each node As XmlNode In nodes
			str.Append("Found: <b>")

			' Show the text contained in this <Title> element.
			str.Append(node.ChildNodes(0).Value)
			str.Append("</b><br>")
		Next node
		XmlText.Text = str.ToString()
	End Sub
End Class
