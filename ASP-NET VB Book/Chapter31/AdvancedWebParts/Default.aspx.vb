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

Imports APress.WebParts.Samples

Public partial Class _Default : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Me.IsPostBack) Then
			Dim i As Integer = 1
			For Each part As WebPart In MyPartManager.WebParts
				If TypeOf part Is GenericWebPart Then
					part.Title = String.Format("Web Part Nr. {0}", i)
					i += 1
				End If
			Next part
		End If

		If (Not Me.IsPostBack) Then
			MyCalendar.SelectedDate = DateTime.Now.AddDays(7)
		End If

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

	Protected Sub MyCalendar_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim part As GenericWebPart = CType(MyCalendar.Parent, GenericWebPart)
		part.AllowClose = False
		part.HelpMode = WebPartHelpMode.Modeless
		part.HelpUrl = "CalendarHelp.htm"
	End Sub

	Protected Sub MyCustomers_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim part As GenericWebPart = CType(MyCustomers.Parent, GenericWebPart)
		part.Title = "Customers"
		part.TitleUrl = "http://www.apress.com"
		part.CatalogIconImageUrl = "CustomersSmall.jpg"
		part.Description = "Displays all customers in the database!"
	End Sub

	Protected Sub MyPartManager_AuthorizeWebPart(ByVal sender As Object, ByVal e As WebPartAuthorizationEventArgs)
		' Ignore authorization in Visual Studio Design Mode
		If Me.DesignMode Then
			Return
		End If

		' Authorize a web part or not
		Dim PartType As Type = e.Type
		If PartType Is GetType(CustomerNotesPart) Then
			If User.Identity.IsAuthenticated Then
				If (Not User.IsInRole("BUILTIN\Administrators")) Then
					e.IsAuthorized = True
				Else
					e.IsAuthorized = False
				End If
			Else
				e.IsAuthorized = False
			End If
		End If
	End Sub
End Class