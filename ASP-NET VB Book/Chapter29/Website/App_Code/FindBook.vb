Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.IO

Public Class FindBook
	Public Function GetImageUrl(ByVal isbn As String) As String
		Try
			' Find the pointer to the book cover image.
			' Amazon.com has the most cover images,
			' so go there to look for it.
			' Start with the book details page.
			isbn = isbn.Replace("-", "")
			Dim bookUrl As String = "http://www.amazon.com/exec/obidos/ASIN/" & isbn

			' Now retrieve the HTML content of the book details page.
			Dim bookHtml As String = GetWebPageAsString(bookUrl)

			' Search the page for an image tag that has the ISBN
			' we need.
			Dim imgTagPattern As String = "<img src=""(http://images.amazon.com/images/P/" & isbn & "[^""]+)"""

			Dim imgTagMatch As Match = Regex.Match(bookHtml, imgTagPattern)
			Return imgTagMatch.Groups(1).Value
		Catch
			Return ""
		End Try
	End Function

	Public Function GetWebPageAsString(ByVal url As String) As String
		' Create the request.
		Dim requestHtml As WebRequest = WebRequest.Create(url)

		' Get the response.
		Dim responseHtml As WebResponse = requestHtml.GetResponse()

		' Read the response stream.
		Dim r As StreamReader = New StreamReader(responseHtml.GetResponseStream())
		Dim htmlContent As String = r.ReadToEnd()
		r.Close()

		Return htmlContent
	End Function
End Class
