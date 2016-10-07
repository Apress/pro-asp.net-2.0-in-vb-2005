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
Imports System.Xml.Schema
Imports System.Xml
Imports System.IO

Public partial Class XmlValidation : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Private Sub MyValidateHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)
		lblStatus.Text &= "Error: " & e.Message & "<br>"
	End Sub
	Protected Sub cmdValidate_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim filePath As String = ""
		If optValid.Checked Then
			filePath = Server.MapPath("DvdList.xml")
		Else If optInvalidData.Checked Then
			filePath &= Server.MapPath("DvdListInvalid.xml")
		End If

		lblStatus.Text = ""

		' Open the XML file.
		Dim fs As FileStream = New FileStream(filePath, FileMode.Open)
		Dim r As XmlTextReader = New XmlTextReader(fs)

		' Create the validating reader.
		Dim vr As XmlValidatingReader = New XmlValidatingReader(r)
		vr.ValidationType = ValidationType.Schema

		' Add the XSD file to the validator.
		Dim schemas As XmlSchemaCollection = New XmlSchemaCollection()
		schemas.Add("", Server.MapPath("DvdList.xsd"))
		vr.Schemas.Add(schemas)

		' Connect the event handler.
		AddHandler vr.ValidationEventHandler, AddressOf MyValidateHandler

		' Read through the document.
		Do While vr.Read()
			' Process document here.
			' If an error is found, an exception will be thrown.
		Loop

		vr.Close()

		lblStatus.Text &= "<br>Complete."
	End Sub
End Class
