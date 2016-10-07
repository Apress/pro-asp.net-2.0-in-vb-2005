#Region "Using directives"


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports CustomServerControlsLibrary

#End Region

Namespace CustomServerControlsLibrary
	Public Class TitledTextBoxActionList : Inherits System.ComponentModel.Design.DesignerActionList
		Private linkedControl As TitledTextBox

		' The constructor associates the control to the smart tag action list. 
		Public Sub New(ByVal ctrl As TitledTextBox)
			MyBase.New(ctrl)
			linkedControl = ctrl
		End Sub


		' A helper method to retrieve control properties.
		' GetProperties ensures undo and menu updates to work properly. 

		Private Function GetPropertyByName(ByVal propName As String) As PropertyDescriptor
			Dim prop As PropertyDescriptor
			prop = TypeDescriptor.GetProperties(linkedControl)(propName)

			If Nothing Is prop Then
				Throw New ArgumentException("Matching property not found.", propName)
			Else
				Return prop
			End If
		End Function


		' Properties that are targets of DesignerActionPropertyItem 
		' entries. 
		Public Property Text() As String
			Get
				Return linkedControl.Text
			End Get
			Set
				GetPropertyByName("Text").SetValue(linkedControl, Value)
			End Set
		End Property

		Public Property Title() As String
			Get
				Return linkedControl.Title
			End Get
			Set
				GetPropertyByName("Title").SetValue(linkedControl, Value)
			End Set
		End Property

		Public Property BackColor() As Color
			Get
				Return linkedControl.BackColor
			End Get
			Set
				GetPropertyByName("BackColor").SetValue(linkedControl, Value)

			End Set
		End Property

		' Method that is target of a DesignerActionMethodItem 
		Public Sub LaunchSite()
			Try
				System.Diagnostics.Process.Start("http://www.prosetech.com")
			Catch
			End Try

		End Sub



		' Implementation of this abstract method creates smart tag 
		' items, associates their targets, and collects into list. 
		Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
			' Create 8 items.
			Dim items As DesignerActionItemCollection = New DesignerActionItemCollection()

			' Begin by creating the headers.
			items.Add(New DesignerActionHeaderItem("Appearance"))
			items.Add(New DesignerActionHeaderItem("Information"))

			' Add items that wrap the properties.
			items.Add(New DesignerActionPropertyItem("Title", "TextBox Title", "Appearance", "The heading for this control."))

			items.Add(New DesignerActionPropertyItem("Text", "TextBox Text", "Appearance", "The content in the TextBox."))

			items.Add(New DesignerActionPropertyItem("BackColor", "Background Color", "Appearance", "The color shown behind the control as a background."))

			' Add an action link. 
			' This item is also added to the context menu 
			' as a designer verb. 
			items.Add(New DesignerActionMethodItem(Me, "LaunchSite", "See website information", "Information", "Opens a web browser with the company site.", True))

			' Create entries for static Information section. 
			items.Add(New DesignerActionTextItem("ID: " & linkedControl.ID, "ID"))

			Return items

		End Function


	End Class

End Namespace
