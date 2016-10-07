Imports Microsoft.VisualBasic
Imports System
Imports System.Xml
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Resources
Imports System.Globalization

Public partial Class Default_aspx : Inherits System.Web.UI.Page
  ' Page events are wired up automatically to methods 
  ' with the following names:
  ' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
  ' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
  ' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
  ' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
  ' Page_SaveStateComplete, Page_Unload

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	' These are simple string resources
	LegendFirstname.Text = Resources.MyResourceStrings.LegendFirstname
	LegendLastname.Text = Resources.MyResourceStrings.LegendLastname
	LegendAge.Text = Resources.MyResourceStrings.LegendAge

	' This is the XML document added to the resources as file
	DocumentXml.DocumentContent = Resources.MyResourceStrings.MyDocument
  End Sub

  Protected Sub GenerateAction_Click(ByVal sender As Object, ByVal e As EventArgs)
	Dim doc As XmlDocument = New XmlDocument()
	doc.LoadXml(Resources.MyResourceStrings.MyDocument)

	Dim TextNode As XmlNode
	Dim NsMgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
	NsMgr.AddNamespace("ns1", "uri:AspNetPro20/Chapter16/Demo1")
	NsMgr.AddNamespace("w", "http://schemas.microsoft.com/office/word/2003/wordml")

	TextNode = doc.SelectSingleNode("//ns1:Firstname//w:p", NsMgr)
	TextNode.InnerXml = String.Format("<w:r><w:t>{0}</w:t></w:r>", TextFirstname.Text)

	TextNode = doc.SelectSingleNode("//ns1:Lastname//w:p", NsMgr)
	TextNode.InnerXml = String.Format("<w:r><w:t>{0}</w:t></w:r>", TextLastname.Text)

	TextNode = doc.SelectSingleNode("//ns1:Age//w:p", NsMgr)
	TextNode.InnerXml = String.Format("<w:r><w:t>{0}</w:t></w:r>", TextAge.Text)

	' Clear the response
	Response.Clear()
	Response.ContentType = "application/msword"
	Response.Write(doc.OuterXml)
	Response.End()
  End Sub
End Class