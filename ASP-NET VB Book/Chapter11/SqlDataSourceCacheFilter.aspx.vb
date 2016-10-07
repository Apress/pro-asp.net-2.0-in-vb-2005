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

Public partial Class SqlDataSourceParameters : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		Dim itemList As String = ""
		For Each item As DictionaryEntry In Cache
			itemList &= item.Key.ToString() & " "
		Next item
		Response.Write(itemList)
	End Sub


	Protected Sub lstCities_DataBinding(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
End Class
