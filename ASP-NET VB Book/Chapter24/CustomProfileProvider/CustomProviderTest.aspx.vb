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


	End Sub
	Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs)
		Profile.AddressName = txtName.Text
		Profile.AddressStreet = txtStreet.Text
		Profile.AddressCity = txtCity.Text
		Profile.AddressZipCode = txtZip.Text
		Profile.AddressState = txtState.Text
		Profile.AddressCountry = txtCountry.Text
	End Sub
	Protected Sub cmdGet_Click(ByVal sender As Object, ByVal e As EventArgs)
		txtName.Text = Profile.AddressName
		txtStreet.Text = Profile.AddressStreet
		txtCity.Text = Profile.AddressCity
		txtZip.Text = Profile.AddressZipCode
		txtState.Text = Profile.AddressState
		txtCountry.Text = Profile.AddressCountry
	End Sub

End Class

