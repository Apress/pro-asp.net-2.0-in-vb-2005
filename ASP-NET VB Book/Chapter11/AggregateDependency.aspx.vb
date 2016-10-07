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
Imports System.Web.Caching
Imports System.IO

Public partial Class AggregateDependency : Inherits System.Web.UI.Page
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
		lblInfo.Text &= "<br>"
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Me.IsPostBack) Then
			lblInfo.Text &= "Creating dependent item...<br>"
			Cache.Remove("Dependent")
			Dim dep1 As System.Web.Caching.CacheDependency = New System.Web.Caching.CacheDependency(Server.MapPath("dependency.txt"))
			Dim dep2 As System.Web.Caching.CacheDependency = New System.Web.Caching.CacheDependency(Server.MapPath("dependency2.txt"))


			' Create the aggregate.
			Dim dependencies As CacheDependency() = New CacheDependency() { dep1, dep2 }
			Dim aggregateDep As AggregateCacheDependency = New AggregateCacheDependency()
			aggregateDep.Add(dependencies)

			Dim item As String = "Dependent cached item"
			lblInfo.Text &= "Adding dependent item<br>"
			Cache.Insert("Dependent", item, aggregateDep)
		End If
	End Sub
	Protected Sub cmdModfiy_Click(ByVal sender As Object, ByVal e As EventArgs)
		lblInfo.Text &= "Modifying dependency2.txt file.<br>"
		Dim w As StreamWriter = File.CreateText(Server.MapPath("dependency2.txt"))
		w.Write(DateTime.Now)
		w.Flush()
		w.Close()
	End Sub
	Protected Sub cmdGetItem_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Cache("Dependent") Is Nothing Then
			lblInfo.Text &= "Cache item no longer exits.<br>"
		Else
			Dim cacheInfo As String = CStr(Cache("Dependent"))
			lblInfo.Text &= "Retrieved item with text: '" & cacheInfo & "'<br>"
		End If
	End Sub
End Class
