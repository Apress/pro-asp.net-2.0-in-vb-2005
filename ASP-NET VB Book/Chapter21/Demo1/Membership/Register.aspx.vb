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
Imports System.Diagnostics

Public partial Class Register : Inherits System.Web.UI.Page
	Private _Age As Short
	Private _Firstname, _Lastname As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Me.IsPostBack) Then
			_Age = -1
            If (_Lastname = String.Empty) Then
                _Firstname = _Lastname
            End If
	End Sub

	Protected Sub RegisterUser_CreatedUser(ByVal sender As Object, ByVal e As EventArgs)
		' Find the correct wizard step
        Dim MyStep As WizardStepBase = Nothing
        Dim i As Integer = 0


        Do While i < RegisterUser.WizardSteps.Count
            If RegisterUser.WizardSteps(i).ID = "NameStep" Then
                MyStep = RegisterUser.WizardSteps(i)
                Exit Do
            End If
            i += 1
        Loop

        If Not MyStep Is Nothing Then
            _Firstname = (CType(MyStep.FindControl("FirstnameText"), TextBox)).Text
            _Lastname = (CType(MyStep.FindControl("LastnameText"), TextBox)).Text
            _Age = Short.Parse((CType(MyStep.FindControl("AgeTExt"), TextBox)).Text)

            ' Store the information
            Debug.WriteLine(String.Format("{0} {1} {2}", _Firstname, _Lastname, _Age))
        End If
	End Sub
End Class
