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

Public partial Class GridViewTemplates2 : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Function GetStatusPicture(ByVal dataItem As Object) As String
		Dim units As Integer = Int32.Parse(DataBinder.Eval(dataItem, "UnitsInStock").ToString())
		If units = 0 Then
			Return "Cancel.gif"
		Else If units > 50 Then
			Return "OK.gif"
		Else
			Return "blank.gif"
		End If
	End Function
	Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
		If e.CommandName = "StatusClick" Then
			lblInfo.Text = "You clicked product #" & e.CommandArgument
		End If
	End Sub


End Class
