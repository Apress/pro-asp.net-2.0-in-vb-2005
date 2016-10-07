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
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml

Public partial Class XmlToHtml : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim xslFile As String = Server.MapPath("DvdList.xsl")
        Dim xmlFile As String = Server.MapPath("DvdList.xml")
        Dim htmlFile As String = Server.MapPath("DvdList.htm")

        Dim transf As XslTransform = New XslTransform()
        transf.Load(xslFile)
        transf.Transform(xmlFile, htmlFile)

        ' Create an XPathDocument.
        Dim xdoc As XPathDocument = New XPathDocument(New XmlTextReader(xmlFile))

		' Create an XPathNavigator.

        Dim xnav As XPathNavigator = xdoc.CreateNavigator()

		' Transform the XML
        Dim reader As XmlReader = transf.Transform(xnav, Nothing)

		' Go the the content and write it.
        reader.MoveToContent()
        Response.Write(reader.ReadOuterXml())
        reader.Close()

    End Sub
    Sub new_page_load()
        Dim xslFile As String = Server.MapPath("DvdList.xsl")
        Dim xmlFile As String = Server.MapPath("DvdList.xml")
        Dim htmlFile As String = Server.MapPath("DvdList2.htm")
        Dim transf As XslCompiledTransform = New XslCompiledTransform()
        transf.Load(xslFile)
        transf.Transform(xmlFile, Nothing, Response.OutputStream)
    End Sub
End Class
