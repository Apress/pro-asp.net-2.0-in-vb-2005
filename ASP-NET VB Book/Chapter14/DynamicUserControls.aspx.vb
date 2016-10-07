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

Public partial Class DynamicUserControls : Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		LoadControls(div1)
		LoadControls(div2)
		LoadControls(div3)
	End Sub

	Private Sub LoadControls(ByVal container As Control)
		Dim list As DropDownList = Nothing
		Dim ph As PlaceHolder = Nothing
		Dim lbl As Label = Nothing

		' Find the controls for this panel.
		For Each ctrl As Control In container.Controls
			If TypeOf ctrl Is DropDownList Then
				list = CType(ctrl, DropDownList)
			Else If TypeOf ctrl Is PlaceHolder Then
				ph = CType(ctrl, PlaceHolder)
			Else If TypeOf ctrl Is Label Then
				lbl = CType(ctrl, Label)
			End If
		Next ctrl

		' Load the dynamic content into this panel.
		Dim ctrlName As String = list.SelectedItem.Value
		If ctrlName.EndsWith(".ascx") Then
			ph.Controls.Add(Page.LoadControl(ctrlName))
		End If
		lbl.Text = "Loaded..." & ctrlName
	End Sub

End Class
