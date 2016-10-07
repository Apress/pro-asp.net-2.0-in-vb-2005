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

Public partial Class Validators : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Submit_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Page.IsValid Then
			Result.Text = "Thanks for sending your data"
		Else
			Result.Text = "There are some errors, please correct them and re-send the form."
		End If
	End Sub
	Protected Sub OptionsChanged(ByVal sender As Object, ByVal e As EventArgs)
		For Each valCtl As BaseValidator In Page.Validators
			valCtl.Enabled = EnableValidators.Checked
			valCtl.EnableClientScript = EnableClientSide.Checked
		Next valCtl
		ValidationSum.ShowMessageBox = ShowMsgBox.Checked
		ValidationSum.ShowSummary = ShowSummary.Checked
	End Sub
	Protected Sub ValidateEmpID2_ServerValidate(ByVal source As Object, ByVal args As ServerValidateEventArgs)
		Try
			args.IsValid = (Integer.Parse(args.Value) Mod 5 = 0)
		Catch
			args.IsValid = False
		End Try
	End Sub
End Class
