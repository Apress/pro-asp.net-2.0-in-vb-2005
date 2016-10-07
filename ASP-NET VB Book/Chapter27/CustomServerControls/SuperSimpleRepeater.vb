Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Web.UI.Design
Imports System.ComponentModel.Design

Namespace CustomServerControlsLibrary
	Public Class SuperSimpleRepeater : Inherits WebControl : Implements INamingContainer
		Public Sub New()
			MyBase.New()
			RepeatCount = 1
		End Sub

		Public Property RepeatCount() As Integer
			Get
				Return CInt(ViewState("RepeatCount"))
			End Get
			Set
				ViewState("RepeatCount") = Value
			End Set
		End Property

        Private iTmpl As ITemplate

		<PersistenceMode(PersistenceMode.InnerProperty)> _
		Public Property ItemTemplate() As ITemplate
			Get
                Return iTmpl
            End Get
            Set(ByVal value As ITemplate)
                iTmpl = Value
            End Set
		End Property

		Protected Overrides Sub CreateChildControls()
			'clear out the control colletion if there
			'are any children we want to wipe them out 
			'before starting
			Controls.Clear()

			'as long as we are repeating at least once
			'and the template is defined, then loop and 
			'instantiate the template in a panel
            If (RepeatCount > 0) AndAlso (Not iTmpl Is Nothing) Then
                Dim i As Integer = 0
                'ORIGINAL LINE: for(int i = 0; i<RepeatCount;i += 1)

                Do While i < RepeatCount
                    Dim container As Panel = New Panel()
                    iTmpl.InstantiateIn(container)
                    Controls.Add(container)
                    i += 1
                Loop
            Else 'otherwise we output a message
                Controls.Add(New LiteralControl("Specify the record count and an item template"))
            End If
		End Sub


	End Class

End Namespace
