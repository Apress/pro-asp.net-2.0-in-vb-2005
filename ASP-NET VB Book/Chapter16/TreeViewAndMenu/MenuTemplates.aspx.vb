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

Public partial Class MenuTemplates : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Private matchingDescription As String = ""

	Protected Function GetDescriptionFromTitle(ByVal title As String) As String
		' This assumes there's only one node with this tile.
		Dim node As SiteMapNode = SiteMap.RootNode
		SearchNodes(node, title)
		Return matchingDescription
	End Function
	Private Sub SearchNodes(ByVal node As SiteMapNode, ByVal title As String)
		If node.Title = title Then
			matchingDescription = node.Description
			Return
		Else
			For Each child As SiteMapNode In node.ChildNodes
				' Perform recursive search.
				SearchNodes(child, title)
			Next child
		End If
	End Sub
End Class
