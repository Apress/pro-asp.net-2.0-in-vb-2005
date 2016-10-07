Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Collections.Generic
Imports CustomerNotesSetTableAdapters

Namespace APress.WebParts.Samples
	Public Class CustomerNotesPart : Inherits WebPart : Implements IWebEditable, INotesContract
		#Region "INotesContract Members"

		Public Property Notes() As String Implements INotesContract.Notes
			Get
				EnsureChildControls()

				If CustomerNotesGrid.SelectedIndex >= 0 Then
					Dim RowIndex As Integer = CustomerNotesGrid.SelectedRow.DataItemIndex

					Dim dt As DataTable = CType(CustomerNotesGrid.DataSource, DataTable)
					Return CStr(dt.Rows(RowIndex)("NoteContent"))
				Else
					Return String.Empty
				End If
			End Get
			Set
				EnsureChildControls()

				If CustomerNotesGrid.SelectedIndex >= 0 Then
					' Retrieve the selected row and upate the value
					Dim RowIndex As Integer = CustomerNotesGrid.SelectedRow.DataItemIndex

					Dim dt As DataTable = CType(CustomerNotesGrid.DataSource, DataTable)
					dt.Rows(RowIndex)("NoteContent") = Value

					' Write changes back to the database
					Dim adpater As CustomerNotesTableAdapter = New CustomerNotesTableAdapter()
					adpater.Update(dt.Rows(RowIndex))

					' Update the grids content
					BindGrid()
				End If
			End Set
		End Property

		Public ReadOnly Property SubmittedDate() As DateTime Implements INotesContract.SubmittedDate
			Get
				EnsureChildControls()

				If CustomerNotesGrid.SelectedIndex >= 0 Then
					Dim RowIndex As Integer = CustomerNotesGrid.SelectedRow.DataItemIndex

					Dim dt As DataTable = CType(CustomerNotesGrid.DataSource, DataTable)
					Return CDate(dt.Rows(RowIndex)("NoteDate"))
				Else
					Return DateTime.MinValue
				End If
			End Get
		End Property

		#End Region

		<ConnectionProvider("Notes Text")> _
		Public Function GetNotesCommunicationPoint() As INotesContract
			Return CType(Me, INotesContract)
		End Function

		#Region "IWebEditable Members"

		Private Function CreateEditorParts() As EditorPartCollection Implements IWebEditable.CreateEditorParts
			' Create editor parts
			Dim Editors As List(Of EditorPart) = New List(Of EditorPart)()
			Editors.Add(New CustomerEditor())
			Return New EditorPartCollection(Editors)
		End Function

		Private ReadOnly Property WebBrowsableObject() As Object Implements IWebEditable.WebBrowsableObject
			Get
				Return Me
			End Get
		End Property

		#End Region

		Public Sub New()
			AddHandler Init, AddressOf CustomerNotesPart_Init
			AddHandler Load, AddressOf CustomerNotesPart_Load
			AddHandler PreRender, AddressOf CustomerNotesPart_PreRender
		End Sub

		Private Sub CustomerNotesPart_Load(ByVal sender As Object, ByVal e As EventArgs)
			' Initialize Web Part Properties
			Me.Title = "Customer Notes"
			Me.TitleIconImageUrl = "NotesImage.jpg"
		End Sub

		Private Sub CustomerNotesPart_Init(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Me.DesignMode) Then
				BindGrid()
			End If
		End Sub

		Private Sub BindGrid()
			EnsureChildControls()

			Dim adapter As CustomerNotesTableAdapter = New CustomerNotesTableAdapter()

			If Customer.Equals(String.Empty) Then
				CustomerNotesGrid.DataSource = adapter.GetDataAll()
			Else
				CustomerNotesGrid.DataSource = adapter.GetDataByCustomer(Customer)
			End If
		End Sub

		Private Sub CustomerNotesPart_PreRender(ByVal sender As Object, ByVal e As EventArgs)
            If Customer = String.Empty Then
                InsertNewNote.Enabled = False
            Else
                InsertNewNote.Enabled = True
            End If

			CustomerNotesGrid.DataBind()
		End Sub

		Public Overrides Property AllowClose() As Boolean
			Get
				Return False
			End Get
			Set
				' Don't want this to be set
			End Set
		End Property

		Private _Customer As String = String.Empty

		<WebBrowsable(True), Personalizable(PersonalizationScope.User)> _
		Public Property Customer() As String
			Get
				Return _Customer
			End Get
			Set
				_Customer = Value

				If (Not Me.DesignMode) Then
					EnsureChildControls()
					CustomerNotesGrid.PageIndex = 0
					CustomerNotesGrid.SelectedIndex = -1
					BindGrid()
				End If
			End Set
		End Property

		Private NewNoteText As TextBox
		Private InsertNewNote As Button
		Private CustomerNotesGrid As GridView

		Protected Overrides Sub CreateChildControls()
			' Create a textbox for adding new notes
			NewNoteText = New TextBox()

			' Create a button for submitting new notes
			InsertNewNote = New Button()
			InsertNewNote.Text = "Insert..."
			AddHandler InsertNewNote.Click, AddressOf InsertNewNote_Click

			' Create the grid for displaying customer notes
			CustomerNotesGrid = New GridView()
			CustomerNotesGrid.HeaderStyle.BackColor = Color.LightBlue
			CustomerNotesGrid.RowStyle.BackColor = Color.LightGreen
			CustomerNotesGrid.AlternatingRowStyle.BackColor = Color.LightGray
			CustomerNotesGrid.SelectedRowStyle.Font.Bold = True
			CustomerNotesGrid.SelectedRowStyle.BackColor = Color.Red
			CustomerNotesGrid.AllowPaging = True
			CustomerNotesGrid.PageSize = 5
			CustomerNotesGrid.DataKeyNames = New String() { "NoteID" }
			CustomerNotesGrid.AutoGenerateSelectButton = True
			AddHandler CustomerNotesGrid.PageIndexChanging, AddressOf CustomerNotesGrid_PageIndexChanging
			AddHandler CustomerNotesGrid.SelectedIndexChanging, AddressOf CustomerNotesGrid_SelectedIndexChanging

			' Add all controls to the controls collection
			Controls.Add(NewNoteText)
			Controls.Add(InsertNewNote)
			Controls.Add(CustomerNotesGrid)
		End Sub

		Private Sub CustomerNotesGrid_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
			CustomerNotesGrid.SelectedIndex = e.NewSelectedIndex
		End Sub

		Private Sub CustomerNotesGrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
			CustomerNotesGrid.PageIndex = e.NewPageIndex
		End Sub

		Private Sub InsertNewNote_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim adapter As CustomerNotesTableAdapter = New CustomerNotesTableAdapter()

			adapter.Insert(Customer, DateTime.Now, NewNoteText.Text)

			BindGrid()
		End Sub

		Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
			writer.Write("<table>")

			writer.Write("<tr>")
			writer.Write("<td>")
			NewNoteText.RenderControl(writer)
			InsertNewNote.RenderControl(writer)
			writer.Write("</td>")
			writer.Write("</tr>")

			writer.Write("<tr>")
			writer.Write("<td>")
			CustomerNotesGrid.RenderControl(writer)
			writer.Write("</td>")
			writer.Write("</tr>")

			writer.Write("</table>")
		End Sub
	End Class
End Namespace
