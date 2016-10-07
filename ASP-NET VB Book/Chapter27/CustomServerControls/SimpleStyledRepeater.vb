Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace CustomServerControlsLibrary
	<ParseChildren(True)> _
	Public Class SimpleStyledRepeater : Inherits WebControl : Implements INamingContainer
		Public Sub New()
			MyBase.New()
			RepeatCount = 1

			' Note that in order to reduce page size, this
			' control doesn't store style information in view state.
			' That means if you change styles programmatically,
			' the changes will be lost after each postback.
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

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property ItemTemplate() As ITemplate
            Get
                Return iTmpl
            End Get
            Set(ByVal value As ITemplate)
                iTmpl = Value
            End Set
        End Property

        Private alternatingiTmpl As ITemplate

		<PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
		Public Property AlternatingItemTemplate() As ITemplate
			Get
                Return alternatingiTmpl
            End Get
            Set(ByVal value As ITemplate)
                alternatingiTmpl = Value
            End Set
		End Property

        Private hTmpl As ITemplate

		<PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
		Public Property HeaderTemplate() As ITemplate
			Get
                Return hTmpl
            End Get
            Set(ByVal value As ITemplate)
                hTmpl = Value
            End Set
		End Property

        Private footTmpl As ITemplate

		<PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
		Public Property FooterTemplate() As ITemplate
			Get
                Return footTmpl
            End Get
            Set(ByVal value As ITemplate)
                footTmpl = Value
            End Set
		End Property

        Private itmStyl As Style
        Private alternatingitmStyl As Style
        Private hStyl As Style
        Private ftStyl As Style

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(True), PersistenceMode(PersistenceMode.InnerProperty)> _
		Public ReadOnly Property ItemStyle() As Style
			Get
                If itmStyl Is Nothing Then
                    itmStyl = New Style()
                    If IsTrackingViewState Then
                        CType(itmStyl, IStateManager).TrackViewState()
                    End If
                End If
                Return itmStyl
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(True), PersistenceMode(PersistenceMode.InnerProperty)> _
		Public ReadOnly Property AlternatingItemStyle() As Style
			Get
                If alternatingitmStyl Is Nothing Then
                    alternatingitmStyl = New Style()
                    If IsTrackingViewState Then
                        CType(alternatingitmStyl, IStateManager).TrackViewState()
                    End If
                End If
                Return alternatingitmStyl
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(True), PersistenceMode(PersistenceMode.InnerProperty)> _
		Public ReadOnly Property HeaderStyle() As Style
			Get
                If hStyl Is Nothing Then
                    hStyl = New Style()
                    If IsTrackingViewState Then
                        CType(hStyl, IStateManager).TrackViewState()
                    End If
                End If
                Return hStyl
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(True), PersistenceMode(PersistenceMode.InnerProperty)> _
		Public ReadOnly Property FooterStyle() As Style
			Get
                If ftStyl Is Nothing Then
                    ftStyl = New Style()
                    If IsTrackingViewState Then
                        CType(ftStyl, IStateManager).TrackViewState()
                    End If
                End If
                Return ftStyl
			End Get
		End Property

		Protected Overrides Sub CreateChildControls()
			Controls.Clear()

            If (RepeatCount > 0) AndAlso (Not iTmpl Is Nothing) Then
                ' Start by outputing the header template (if supplied).
                If Not hTmpl Is Nothing Then
                    Dim headerContainer As SimpleRepeaterItem = New SimpleRepeaterItem(0, RepeatCount)
                    hTmpl.InstantiateIn(headerContainer)
                    Controls.Add(headerContainer)

                    If Not hStyl Is Nothing Then
                        headerContainer.ApplyStyle(hStyl)
                    End If
                End If

                ' Output the content the specified number of times.
                Dim i As Integer = 0
                'ORIGINAL LINE: for (int i = 0; i<RepeatCount; i += 1)

                Do While i < RepeatCount
                    Dim container As SimpleRepeaterItem = New SimpleRepeaterItem(i + 1, RepeatCount)

                    ' Create a style for alternate items.
                    Dim altStyle As Style = New Style()
                    altStyle.MergeWith(itmStyl)
                    altStyle.CopyFrom(alternatingitmStyl)

                    If (i Mod 2 = 0) AndAlso (Not alternatingiTmpl Is Nothing) Then
                        ' This is an alternating item and there is an alternating template.
                        alternatingiTmpl.InstantiateIn(container)
                        container.ApplyStyle(altStyle)
                    Else
                        iTmpl.InstantiateIn(container)
                        If Not itmStyl Is Nothing Then
                            container.ApplyStyle(itmStyl)
                        End If
                    End If

                    Controls.Add(container)
                    i += 1
                Loop

                ' Once all of the items have been rendered,
                ' add the footer template if specified.
                If Not footTmpl Is Nothing Then
                    Dim footerContainer As SimpleRepeaterItem = New SimpleRepeaterItem(RepeatCount, RepeatCount)
                    footTmpl.InstantiateIn(footerContainer)
                    Controls.Add(footerContainer)
                    If Not ftStyl Is Nothing Then
                        footerContainer.ApplyStyle(ftStyl)
                    End If
                End If
            Else
                ' Show an error message.
                Controls.Add(New LiteralControl("Specify the record count and an item template"))
            End If
		End Sub

		Public Overrides Overloads Sub DataBind()
			EnsureChildControls()
			MyBase.DataBind()
		End Sub


	End Class

End Namespace
