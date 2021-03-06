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

Public partial Class ComplexTypes : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Context.Items("AddressDirtyFlag") = False

	End Sub
	Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs)
		Profile.Address = New Address(txtName.Text, txtStreet.Text, txtCity.Text, txtZip.Text, txtState.Text, txtCountry.Text)
	End Sub
	Protected Sub cmdGet_Click(ByVal sender As Object, ByVal e As EventArgs)
		txtName.Text = Profile.Address.Name
		txtStreet.Text = Profile.Address.Street
		txtCity.Text = Profile.Address.City
		txtZip.Text = Profile.Address.ZipCode
		txtState.Text = Profile.Address.State
		txtCountry.Text = Profile.Address.Country
	End Sub
	Protected Sub txt_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		Context.Items("AddressDirtyFlag") = True
	End Sub
End Class

