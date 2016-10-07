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

Public partial Class GridViewTemplate : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected ReadOnly Property TitlesOfCourtesy() As String()
		Get
			Return New String() { "Mr.", "Dr.", "Ms.", "Mrs." }
		End Get
	End Property
	Protected Function GetSelectedTitle(ByVal title As Object) As Integer
		Return Array.IndexOf(TitlesOfCourtesy, title.ToString())
	End Function

	Protected Sub gridEmployees_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
		' Get the ID of the record to update.
		'int empID = (int)gridEmployees.DataKeys.[e.RowIndex];

		' Get the reference to the list control.
		Dim title As DropDownList = CType(gridEmployees.Rows(e.RowIndex).FindControl("EditTitle"), DropDownList)

		' Add it to the parameters.
		e.NewValues.Add("TitleOfCourtesy", title.Text)
	End Sub
End Class
