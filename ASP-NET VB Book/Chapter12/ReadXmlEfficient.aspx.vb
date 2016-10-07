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
Imports System.Xml

Public partial Class ReadXmlEfficient : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ReadXML()
	End Sub

	Private Sub ReadXML()
		Dim xmlFile As String = Server.MapPath("DvdList.xml")

		' Create the reader.
		Dim reader As XmlTextReader = New XmlTextReader(xmlFile)

		Dim str As StringBuilder = New StringBuilder()
		reader.ReadStartElement("DvdList")

		' Read all the <DVD> elements.
		Do While reader.Read()
			If (reader.Name = "DVD") AndAlso (reader.NodeType = XmlNodeType.Element) Then
				reader.ReadStartElement("DVD")
				str.Append("<ul><b>")
				str.Append(reader.ReadElementString("Title"))
				str.Append("</b><li>")
				str.Append(reader.ReadElementString("Director"))
				str.Append("</li><li>")
				str.Append(String.Format("{0:C}", Decimal.Parse(reader.ReadElementString("Price"))))
				str.Append("</li></ul>")
			End If
		Loop
		' Close the reader and show the text.
		reader.Close()
		XmlText.Text = str.ToString()
	End Sub

End Class
