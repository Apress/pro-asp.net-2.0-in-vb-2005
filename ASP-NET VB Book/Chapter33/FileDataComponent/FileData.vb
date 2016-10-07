Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema

Namespace FileDataComponent
	<XmlRoot(Namespace := "http://www.apress.com/ProASP.NET/FileData"), XmlSchemaProvider("GetSchemaDocument")> _
	Public Class FileData : Implements IXmlSerializable
		Private Const ns As String = "http://www.apress.com/ProASP.NET/FileData"

		' The server-side path.
		Private serverFilePath As String


		Public Sub New(ByVal serverFilePath As String)
			If (Not File.Exists(serverFilePath)) Then
				Throw New InvalidOperationException("Source file not found.")
			End If
			Me.serverFilePath = serverFilePath
		End Sub

		Private Sub WriteXml(ByVal writer As System.Xml.XmlWriter) Implements IXmlSerializable.WriteXml
			' Open the file.
			Dim fs As FileStream = New FileStream(serverFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
			Dim length As Long = fs.Length

			' Write file name.
			writer.WriteElementString("fileName", ns, Path.GetFileName(serverFilePath))

			' Write file size (useful for determining progress.)
			writer.WriteElementString("size", ns, length.ToString())

			' Start the file content.
			writer.WriteStartElement("content", ns)

			' Read 4 KB chunks and write that (Base64 encoded).
			Dim bufferSize As Integer = 4096
			Dim fileBytes As Byte() = New Byte(bufferSize - 1){}
			Dim readBytes As Integer = bufferSize

			Do While readBytes > 0
				readBytes = fs.Read(fileBytes, 0, bufferSize)
				writer.WriteStartElement("chunk", ns)
				writer.WriteBase64(fileBytes, 0, readBytes)
				writer.WriteEndElement()
				writer.Flush()

			Loop

			fs.Close()

			' End the XML.
			writer.WriteEndElement()
			writer.Flush()

		End Sub

		' The location to place the downloaded file.
		' Must be set before the download begins.
		Public Shared ClientFolder As String

		Public Sub New()
		End Sub



		Private Function GetSchema() As System.Xml.Schema.XmlSchema Implements IXmlSerializable.GetSchema
			Return Nothing
		End Function

		Private Sub ReadXml(ByVal reader As System.Xml.XmlReader) Implements IXmlSerializable.ReadXml
			If FileData.ClientFolder Is Nothing OrElse FileData.ClientFolder = "" Then
				Throw New InvalidOperationException("No target folder specified.")
			End If
			reader.ReadStartElement()

			' Get the original file name (not currently used).
			Dim fileName As String = reader.ReadElementString("fileName", ns)

			' Get the size (not currently used).
			Dim size As Double = Convert.ToDouble(reader.ReadElementString("size", ns))

			' Create the file.
			Dim fs As FileStream = New FileStream(Path.Combine(ClientFolder, fileName), FileMode.Create, FileAccess.Write)

			' Read the XML and write the file one block at a time.
			Dim fileBytes As Byte()
			reader.ReadStartElement("content", ns)
			Dim totalRead As Double = 0

			Do While True
				If reader.IsStartElement("chunk", ns) Then
					Dim bytesBase64 As String = reader.ReadElementString()
					totalRead += bytesBase64.Length
					fileBytes = Convert.FromBase64String(bytesBase64)
					fs.Write(fileBytes, 0, fileBytes.Length)
					fs.Flush()

					' You could report progress by raising an event here.
					Console.WriteLine("Received chunk.")
				Else
					Exit Do
				End If
			Loop
			fs.Close()
			reader.ReadEndElement()
			reader.ReadEndElement()
		End Sub


		Public Shared Function GetSchemaDocument(ByVal xs As XmlSchemaSet) As XmlQualifiedName
			' In the client, don't return the schema.
			If HttpContext.Current Is Nothing Then
			Return Nothing
			End If

			' Get the path to the schema file.
			Dim schemaPath As String = HttpContext.Current.Server.MapPath("FileData.xsd")

			' Retrieve the schema from the file.
			Dim schemaSerializer As XmlSerializer = New XmlSerializer(GetType(XmlSchema))
            'Dim s As XmlSchema = CType(schemaSerializer.Deserialize(New XmlTextReader(schemaPath), Nothing), XmlSchema)
            Dim s As XmlSchema = CType(schemaSerializer.Deserialize(New XmlTextReader(schemaPath)), XmlSchema)
			xs.XmlResolver = New XmlUrlResolver()
			xs.Add(s)

			Return New XmlQualifiedName("FileData", ns)
		End Function

	End Class
End Namespace