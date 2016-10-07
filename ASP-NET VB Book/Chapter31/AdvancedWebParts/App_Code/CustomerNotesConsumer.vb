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

Namespace APress.WebParts.Samples
	Public Class CustomerNotesConsumer : Inherits WebPart
		Private NotesTextLabel As Label
		Private NotesContentText As TextBox
		Private UpdateNotesContent As Button

		Protected Overrides Sub CreateChildControls()
			NotesTextLabel = New Label()
			NotesTextLabel.Text = DateTime.Now.ToString()

			NotesContentText = New TextBox()
			NotesContentText.TextMode = TextBoxMode.MultiLine
			NotesContentText.Rows = 5
			NotesContentText.Columns = 20

			UpdateNotesContent = New Button()
			UpdateNotesContent.Text = "Update"
			AddHandler UpdateNotesContent.Click, AddressOf UpdateNotesContent_Click

			Controls.Add(NotesTextLabel)
			Controls.Add(NotesContentText)
			Controls.Add(UpdateNotesContent)
		End Sub

		Private Sub UpdateNotesContent_Click(ByVal sender As Object, ByVal e As EventArgs)
			If Not _NotesProvider Is Nothing Then
				_NotesProvider.Notes = NotesContentText.Text
			End If
		End Sub

		Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
			' Don't forget to call base implementation
			MyBase.OnPreRender(e)

			' Initialize control
			If Not _NotesProvider Is Nothing Then
				NotesContentText.Text = _NotesProvider.Notes
				NotesTextLabel.Text = _NotesProvider.SubmittedDate.ToShortDateString()
			End If
		End Sub

		Private _NotesProvider As INotesContract

		<ConnectionConsumer("Customer Notes", "MyConsumerID")> _
		Public Sub InitializeProvider(ByVal provider As INotesContract)
			_NotesProvider = provider
		End Sub
	End Class
End Namespace