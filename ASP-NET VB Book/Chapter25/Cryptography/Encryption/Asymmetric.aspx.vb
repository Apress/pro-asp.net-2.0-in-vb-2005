Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Security.Cryptography
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports APress.ProAspNet.Utility

Public partial Class _Asymmetric : Inherits System.Web.UI.Page
	Private KeyFileName As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		KeyFileName = Server.MapPath("~/") & "\asymmetric_key.config"
	End Sub

	Protected Sub GenerateKeyCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		Try
			PublicKeyText.Text = AsymmetricEncryptionUtility.GenerateKey(KeyFileName)
			Response.Write("Key generated successfully!")
		Catch
			Response.Write("Exception occured when encrypting key!")
		End Try
	End Sub

	Protected Sub EncryptCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Check for encryption key
		If (Not File.Exists(KeyFileName)) Then
			Response.Write("Missing encryption key. Please generate key!")
		End If

		Try
			Dim data As Byte() = AsymmetricEncryptionUtility.EncryptData(ClearDataText.Text, PublicKeyText.Text)
			EncryptedDataText.Text = Convert.ToBase64String(data)
		Catch
			Response.Write("Unable to encrypt data!")
		End Try
	End Sub

	Protected Sub DecryptCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Check for encryption key
		If (Not File.Exists(KeyFileName)) Then
			Response.Write("Missing encryption key. Please generate key!")
		End If

		Try
			Dim data As Byte() = Convert.FromBase64String(EncryptedDataText.Text)
			ClearDataText.Text = AsymmetricEncryptionUtility.DecryptData(data, KeyFileName)
		Catch
			Response.Write("Unable to decrypt data!")
		End Try
	End Sub

	Protected Sub ClearCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		ClearDataText.Text = ""
		EncryptedDataText.Text = ""
	End Sub
End Class