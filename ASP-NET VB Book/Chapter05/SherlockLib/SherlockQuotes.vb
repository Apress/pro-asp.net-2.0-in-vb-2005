Imports Microsoft.VisualBasic
Imports System
Imports System.Xml

Namespace SherlockLib
	''' <summary>
	''' Summary description for SherlockQuotes.
	''' </summary>
	Public Class SherlockQuotes
		Private quoteDoc As XmlDocument
		Private quoteCount As Integer

		Public Sub New(ByVal fileName As String)
			quoteDoc = New XmlDocument()
			quoteDoc.Load(fileName)

			quoteCount = quoteDoc.DocumentElement.ChildNodes.Count
		End Sub

		Public Function GetRandomQuote() As Quotation
			Dim i As Integer
			Dim x As Random = New Random()
			i = x.Next(quoteCount-1)
			Return New Quotation(quoteDoc.DocumentElement.ChildNodes(i))
		End Function

	End Class
End Namespace
