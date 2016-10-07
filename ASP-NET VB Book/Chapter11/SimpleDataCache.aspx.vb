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

Public partial Class SimpleDataCache : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Me.IsPostBack Then
			lblInfo.Text &= "Page posted back.<br />"
		Else
			lblInfo.Text &= "Page created.<br />"
		End If

		If Cache("TestItem") Is Nothing Then
			lblInfo.Text &= "Creating TestItem...<br />"
			Dim testItem As DateTime = DateTime.Now

			lblInfo.Text &= "Storing TestItem in cache "
			lblInfo.Text &= "for 30 seconds.<br />"
			Cache.Insert("TestItem", testItem, Nothing, DateTime.Now.AddSeconds(30), TimeSpan.Zero)
		Else
			lblInfo.Text &= "Retrieving TestItem...<br />"
			Dim testItem As DateTime = CDate(Cache("TestItem"))
			lblInfo.Text &= "TestItem is '" & testItem.ToString()
			lblInfo.Text &= "'<br />"
		End If

		lblInfo.Text &= "<br />"
	End Sub

End Class
