Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports APress.ProAspNet.Utility

Public partial Class _Default : Inherits System.Web.UI.Page
	Private DemoDb As SqlConnection

	Private CreditCardText As TextBox
	Private StreetText As TextBox
	Private ZipCodeText As TextBox
	Private CityText As TextBox

	Private EncryptionKeyFile As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' Configure Encryption Utility
		EncryptionKeyFile = Server.MapPath("key.config")
		SymmetricEncryptionUtility.AlgorithmName = "DES"
		If (Not System.IO.File.Exists(EncryptionKeyFile)) Then
			SymmetricEncryptionUtility.GenerateKey(EncryptionKeyFile)
		End If

		' Create the connection
		DemoDb = New SqlConnection(ConfigurationManager.ConnectionStrings("DemoSql").ConnectionString)

		' Associate with Textfields
		CreditCardText = CType(MainLoginView.FindControl("CreditCardText"), TextBox)
		StreetText = CType(MainLoginView.FindControl("StreetText"), TextBox)
		ZipCodeText = CType(MainLoginView.FindControl("ZipCodeText"), TextBox)
		CityText = CType(MainLoginView.FindControl("CityText"), TextBox)
	End Sub

	Protected Sub LoadCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		DemoDb.Open()

		Try
			Dim SqlText As String = "SELECT * FROM ShopInfo WHERE UserId=@key"
			Dim Cmd As SqlCommand = New SqlCommand(SqlText, DemoDb)
			Cmd.Parameters.AddWithValue("@key", Membership.GetUser().ProviderUserKey)
			Using Reader As SqlDataReader = Cmd.ExecuteReader()
				If Reader.Read() Then
					' Cleartext Data
					StreetText.Text = Reader("City").ToString()
					ZipCodeText.Text = Reader("ZipCode").ToString()
					CityText.Text = Reader("City").ToString()

					' Encrypted Data
					Dim SecretCard As Byte() = CType(Reader("CreditCard"), Byte())
					CreditCardText.Text = SymmetricEncryptionUtility.DecryptData(SecretCard, EncryptionKeyFile)
				End If
			End Using
		Finally
			DemoDb.Close()
		End Try
	End Sub

	Protected Sub SaveCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		DemoDb.Open()

		Try
			Dim SqlText As String = "UPDATE ShopInfo " & "SET Street=@street, ZipCode=@zip, " & "City=@city, CreditCard=@card " & "WHERE UserId=@key"

			Dim Cmd As SqlCommand = New SqlCommand(SqlText, DemoDb)

			' Add simple values
			Cmd.Parameters.AddWithValue("@street", StreetText.Text)
			Cmd.Parameters.AddWithValue("@zip", ZipCodeText.Text)
			Cmd.Parameters.AddWithValue("@city", CityText.Text)
			Cmd.Parameters.AddWithValue("@key", Membership.GetUser().ProviderUserKey)

			' Now add the encrypted value
			Dim EncryptedData As Byte() = SymmetricEncryptionUtility.EncryptData(CreditCardText.Text, EncryptionKeyFile)
			Cmd.Parameters.AddWithValue("@card", EncryptedData)

			' Execute the command
			Dim results As Integer = Cmd.ExecuteNonQuery()
			If results = 0 Then
				Cmd.CommandText = "INSERT INTO ShopInfo VALUES(@key, @card, @street, @zip, @city)"
				Cmd.ExecuteNonQuery()
			End If
		Finally
			DemoDb.Close()
		End Try
	End Sub
End Class