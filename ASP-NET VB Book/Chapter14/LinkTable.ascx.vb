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

Public partial Class LinkTable : Inherits System.Web.UI.UserControl
	Public Event LinkClicked As LinkClickedEventHandler

	Public Property Title() As String
		Get
			Return lblTitle.Text
		End Get
		Set
			lblTitle.Text = Value
		End Set
	End Property

    Private ltiItems As LinkTableItem()
    Public Property Items() As LinkTableItem()
        Get
            Return ltiItems
        End Get
        Set(ByVal value As LinkTableItem())
            ltiItems = Value

            ' Refresh the grid.
            listContent.DataSource = ltiItems
            listContent.DataBind()
        End Set
    End Property



	Protected Sub listContent_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
		If Not LinkClickedEvent Is Nothing Then
			' Get the HyperLink object that was clicked.
			Dim link As LinkButton = CType(e.Item.Controls(1), LinkButton)

			' Construct the event arguments.
			Dim item As LinkTableItem = New LinkTableItem(link.Text, link.CommandArgument)
			Dim args As LinkTableEventArgs = New LinkTableEventArgs(item)

			' Fire the event.
			RaiseEvent LinkClicked(Me, args)

			' Navigate to the link if the event recipient didn't
			' cancel the operation.
			If (Not args.Cancel) Then
				Response.Redirect(item.Url)
			End If
		End If
	End Sub

End Class

Public Class LinkTableItem
    Private m_Text As String
    Public Property MyText() As String
        Get
            Return m_Text
        End Get
        Set(ByVal value As String)
            m_Text = value
        End Set
    End Property

    Private m_URL As String
    Public Property MyUrl() As String
        Get
            Return m_URL
        End Get
        Set(ByVal value As String)
            m_URL = value
        End Set
    End Property

	' Default constructor.
	Public Sub New()
	End Sub

    Public Sub New(ByVal pText As String, ByVal pURL As String)
        Me.MyText = pText
        Me.MyURL = pURL
    End Sub
End Class
Public Class LinkTableEventArgs : Inherits EventArgs
    Private itSelectedItem As LinkTableItem
		Public ReadOnly Property SelectedItem() As LinkTableItem
			Get
            Return itSelectedItem
        End Get
    End Property

    Private bCancel As Boolean = False
    Public Property Cancel() As Boolean
        Get
            Return bCancel
        End Get
        Set(ByVal value As Boolean)
            bCancel = value
        End Set
    End Property

    Public Sub New(ByVal item As LinkTableItem)
        itSelectedItem = item
    End Sub
End Class


Public Delegate Sub LinkClickedEventHandler(ByVal sender As Object, ByVal e As LinkTableEventArgs)



