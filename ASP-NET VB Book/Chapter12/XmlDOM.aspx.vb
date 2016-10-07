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

Public partial Class XmlDOM : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim xmlFile As String = Server.MapPath("DvdList.xml")

		' Load the XML file in an XmlDocument.
		Dim doc As XmlDocument = New XmlDocument()
		doc.Load(xmlFile)

		' Write the description text.
		XmlText.Text = GetChildNodesDescr(doc.ChildNodes, 0)
	End Sub


	Private Function GetChildNodesDescr(ByVal nodeList As XmlNodeList, ByVal level As Integer) As String
		Dim indent As String = ""
		Dim i As Integer = 0
'ORIGINAL LINE: for (int i = 0; i < level; i += 1)
        Do While i < level
            indent &= "&nbsp; &nbsp; &nbsp;"
            i += 1
        Loop

		Dim str As StringBuilder = New StringBuilder("")

		For Each node As XmlNode In nodeList
			Select Case node.NodeType
				Case XmlNodeType.XmlDeclaration
					str.Append("XML Declaration: <b>")
					str.Append(node.Name)
					str.Append(" ")
					str.Append(node.Value)
					str.Append("</b><br>")

				Case XmlNodeType.Element
					str.Append(indent)
					str.Append("Element: <b>")
					str.Append(node.Name)
					str.Append("</b><br>")

				Case XmlNodeType.Text
					str.Append(indent)
					str.Append(" - Value: <b>")
					str.Append(node.Value)
					str.Append("</b><br>")

				Case XmlNodeType.Comment
					str.Append(indent)
					str.Append("Comment: <b>")
					str.Append(node.Value)
					str.Append("</b><br>")
			End Select

			If Not node.Attributes Is Nothing Then
				For Each attrib As XmlAttribute In node.Attributes
					str.Append(indent)
					str.Append(" - Attribute: <b>")
					str.Append(attrib.Name)
					str.Append("</b> Value: <b>")
					str.Append(attrib.Value)
					str.Append("</b><br>")
				Next attrib
			End If

			If node.HasChildNodes Then
				str.Append(GetChildNodesDescr(node.ChildNodes, level + 1))
			End If
		Next node

		Return str.ToString()
	End Function
End Class
