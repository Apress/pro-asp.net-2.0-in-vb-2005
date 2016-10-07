#Region "Using directives"


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports CustomServerControlsLibrary

#End Region

Namespace CustomServerControlsLibrary
	Public Class TitledTextBoxDesigner : Inherits System.Web.UI.Design.ControlDesigner
        Private acLists As DesignerActionListCollection

		Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
			Get
                If acLists Is Nothing Then
                    acLists = New DesignerActionListCollection()
                    acLists.Add(New TitledTextBoxActionList(CType(Component, TitledTextBox)))
                End If
                Return acLists
			End Get
		End Property
	End Class
End Namespace
