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

Public partial Class BulletedList : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			For Each style As String In System.Enum.GetNames(GetType(BulletStyle))
				BulletedList1.Items.Add(style)
			Next style
		End If
	End Sub
	Protected Sub BulletedList1_Click(ByVal sender As Object, ByVal e As BulletedListEventArgs)
		Dim styleName As String = BulletedList1.Items(e.Index).Text
		Dim style As BulletStyle = CType(System.Enum.Parse(GetType(BulletStyle), styleName), BulletStyle)
		BulletedList1.BulletStyle = style
	End Sub
End Class
