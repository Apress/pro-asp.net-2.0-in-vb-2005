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

Public partial Class _Default : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Me.IsPostBack) Then
			Dim Root As MenuItem = New MenuItem("Select Mode")

			For Each mode As WebPartDisplayMode In MyPartManager.DisplayModes
				If mode.IsEnabled(MyPartManager) Then
					Root.ChildItems.Add(New MenuItem(mode.Name))
				End If
			Next mode

			PartsMenu.Items.Add(Root)
		End If
	End Sub
	Protected Sub MyCalendar_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub PartsMenu_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs)
		For Each mode As WebPartDisplayMode In MyPartManager.DisplayModes
			If mode.Name.Equals(e.Item.Text) Then
				MyPartManager.DisplayMode = mode
			End If
		Next mode
	End Sub
End Class