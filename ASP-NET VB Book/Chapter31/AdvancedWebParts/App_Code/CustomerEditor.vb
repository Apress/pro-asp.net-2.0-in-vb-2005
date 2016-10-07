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
Imports CustomersSetTableAdapters

Namespace APress.WebParts.Samples
	Public Class CustomerEditor : Inherits EditorPart
		Public Sub New()
			AddHandler Init, AddressOf CustomerEditor_Init
		End Sub

		Private Sub CustomerEditor_Init(ByVal sender As Object, ByVal e As EventArgs)
			EnsureChildControls()

			Dim adapter As CustomerTableAdapter = New CustomerTableAdapter()
			CustomersList.DataSource = adapter.GetData()
			CustomersList.DataTextField = "CompanyName"
			CustomersList.DataValueField = "CustomerID"
			CustomersList.DataBind()

			CustomersList.Items.Insert(0, "")
		End Sub

		Public Overrides Function ApplyChanges() As Boolean
			' Make sure that all controls are available
			EnsureChildControls()

			' Get the property from the WebPart
			Dim part As CustomerNotesPart = CType(WebPartToEdit, CustomerNotesPart)
			If Not part Is Nothing Then
				If CustomersList.SelectedIndex >= 0 Then
					part.Customer = CustomersList.SelectedValue
				Else
					part.Customer = String.Empty
				End If
			Else
				Return False
			End If

			Return True
		End Function

		Public Overrides Sub SyncChanges()
			' Make sure that all controls are available
			EnsureChildControls()

			' Get the property from the WebPart
			Dim part As CustomerNotesPart = CType(WebPartToEdit, CustomerNotesPart)
			If Not part Is Nothing Then
				CustomersList.SelectedValue = part.Customer
			End If
		End Sub

		Private CustomersList As ListBox

		Protected Overrides Sub CreateChildControls()
			CustomersList = New ListBox()
			CustomersList.Rows = 4

			Controls.Add(CustomersList)
		End Sub
	End Class
End Namespace