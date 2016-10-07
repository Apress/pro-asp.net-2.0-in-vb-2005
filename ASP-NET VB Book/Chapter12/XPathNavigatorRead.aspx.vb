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
Imports System.Xml.XPath
Imports System.Text

Public partial Class XPathNavigatorRead : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim xmlFile As String = Server.MapPath("DvdList.xml")

		' Load the XML file in an XmlDocument.
		Dim doc As XmlDocument = New XmlDocument()
		doc.Load(xmlFile)

		' Create the navigator.
		Dim xnav As XPathNavigator = doc.CreateNavigator()

		XmlText.Text = GetXNavDescr(xnav, 0)
	End Sub

	Private Function GetXNavDescr(ByVal xnav As XPathNavigator, ByVal level As Integer) As String
		Dim indent As String = ""
		Dim i As Integer = 0
'ORIGINAL LINE: for (int i = 0; i < level; i += 1)
        Do While i < level
            indent &= "&nbsp; &nbsp; &nbsp;"
            i += 1
        Loop

		Dim str As StringBuilder = New StringBuilder("")

		Select Case xnav.NodeType
			Case XPathNodeType.Root
				str.Append("<b>ROOT</b>")
				str.Append("<br>")

			Case XPathNodeType.Element
				str.Append(indent)
				str.Append("Element: <b>")
				str.Append(xnav.Name)
				str.Append("</b><br>")

			Case XPathNodeType.Text
				str.Append(indent)
				str.Append(" - Value: <b>")
				str.Append(xnav.Value)
				str.Append("</b><br>")

			Case XPathNodeType.Comment
				str.Append(indent)
				str.Append("Comment: <b>")
				str.Append(xnav.Value)
				str.Append("</b><br>")
		End Select

		If xnav.HasAttributes Then
			xnav.MoveToFirstAttribute()
			Do
				str.Append(indent)
				str.Append(" - Attribute: <b>")
				str.Append(xnav.Name)
				str.Append("</b> Value: <b>")
				str.Append(xnav.Value)
				str.Append("</b><br>")
			Loop While xnav.MoveToNextAttribute()

			' Return to the parent.
			xnav.MoveToParent()
		End If

		If xnav.HasChildren Then
			xnav.MoveToFirstChild()

			Do
				str.Append(GetXNavDescr(xnav, level + 1))
			Loop While xnav.MoveToNext()

			' Return to the parent.
			xnav.MoveToParent()
		End If

		Return str.ToString()
	End Function
End Class
