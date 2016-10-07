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

Public partial Class HolmesQuote : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim quotes As SherlockLib.SherlockQuotes = New SherlockLib.SherlockQuotes(Server.MapPath("./sherlock-holmes.xml"))
		Dim quote As SherlockLib.Quotation = quotes.GetRandomQuote()
		Response.Write("<b>" & quote.Source & "</b> (<i>" & quote.Date & "</i>)")
		Response.Write("<blockquote>" & quote.QuotationText & "</blockquote>")


	End Sub
End Class
