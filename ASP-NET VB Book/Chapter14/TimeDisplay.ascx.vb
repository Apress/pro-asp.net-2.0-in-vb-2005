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

Public partial Class TimeDisplay : Inherits System.Web.UI.UserControl
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		RefreshTime()
	End Sub

	Protected Sub lnkTime_Click(ByVal sender As Object, ByVal e As EventArgs)
		RefreshTime()
	End Sub

	Public Sub RefreshTime()
        If strFormat = "" Then
            lnkTime.Text = DateTime.Now.ToLongTimeString()
        Else
            ' This will throw an exception for invalid format strings,
            ' which is acceptable.
            lnkTime.Text = DateTime.Now.ToString(strFormat)
        End If

    End Sub

    Private strFormat As String
	Public Property Format() As String
		Get
            Return strFormat
        End Get
        Set(ByVal value As String)
            strFormat = Value
        End Set
	End Property


End Class
