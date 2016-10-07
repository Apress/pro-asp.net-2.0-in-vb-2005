Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace CustomServerControlsLibrary
	<Designer(GetType(SuperSimpleRepeaterDesigner))> _
	Public Class SuperSimpleRepeater2 : Inherits WebControl : Implements INamingContainer
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


		Protected Overrides Sub CreateChildControls()
			Controls.Clear()

            If (RepeatCount > 0) AndAlso (Not iTmpl Is Nothing) Then
                ' Start by outputing the header template (if supplied).
                If Not hTmpl Is Nothing Then
                    Dim headerContainer As SimpleRepeaterItem = New SimpleRepeaterItem(0, RepeatCount)
                    hTmpl.InstantiateIn(headerContainer)
                    'headerContainer.DataBind();
                    Controls.Add(headerContainer)
                End If

                ' Output the content the specified number of times.
                Dim i As Integer = 0
                'ORIGINAL LINE: for (int i = 0; i<RepeatCount; i += 1)

                Do While i < RepeatCount
                    Dim container As SimpleRepeaterItem = New SimpleRepeaterItem(i + 1, RepeatCount)

                    If (i Mod 2 = 0) AndAlso (Not alternatingiTmpl Is Nothing) Then
                        ' This is an alternating item and there is an alternating template.
                        alternatingiTmpl.InstantiateIn(container)
                    Else
                        iTmpl.InstantiateIn(container)
                    End If
                    'container.DataBind();
                    Controls.Add(container)
                    i += 1
                Loop

                ' Once all of the items have been rendered,
                ' add the footer template if specified.
                If Not footTmpl Is Nothing Then
                    Dim footerContainer As SimpleRepeaterItem = New SimpleRepeaterItem(RepeatCount, RepeatCount)
                    footTmpl.InstantiateIn(footerContainer)
                    'footerContainer.DataBind();
                    Controls.Add(footerContainer)
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



	Public Class SimpleRepeaterItem : Inherits WebControl : Implements INamingContainer
        Private nIndex As Integer
		Public ReadOnly Property Index() As Integer
			Get
                Return nIndex
            End Get
        End Property

        Private nTotal As Integer
        Public ReadOnly Property Total() As Integer
            Get
                Return nTotal
            End Get
        End Property

        ' A constructor that allows you to set the index and total count
        ' when you create an item.
        Public Sub New(ByVal itemIndex As Integer, ByVal totalCount As Integer)
            nIndex = itemIndex
            nTotal = totalCount
        End Sub
	End Class
End Namespace
