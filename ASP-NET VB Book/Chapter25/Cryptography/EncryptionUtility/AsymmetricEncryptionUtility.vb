Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Namespace APress.ProAspNet.Utility
	Public Class AsymmetricEncryptionUtility
		Private Sub New()
		End Sub
		Public Shared Function GenerateKey(ByVal targetFile As String) As String
			Dim Algorithm As RSACryptoServiceProvider = New RSACryptoServiceProvider()

			' Save the private key
			Dim CompleteKey As String = Algorithm.ToXmlString(True)
			Dim KeyBytes As Byte() = Encoding.UTF8.GetBytes(CompleteKey)

			KeyBytes = ProtectedData.Protect(KeyBytes, Nothing, DataProtectionScope.LocalMachine)

			Using fs As FileStream = New FileStream(targetFile, FileMode.Create)
				fs.Write(KeyBytes, 0, KeyBytes.Length)
			End Using

			' Return the public key
			Return Algorithm.ToXmlString(False)
		End Function

		Private Shared Sub ReadKey(ByVal algorithm As RSACryptoServiceProvider, ByVal keyFile As String)
			Dim KeyBytes As Byte()

			Using fs As FileStream = New FileStream(keyFile, FileMode.Open)
				KeyBytes = New Byte(fs.Length - 1){}
				fs.Read(KeyBytes, 0, CInt(fs.Length))
			End Using

			KeyBytes = ProtectedData.Unprotect(KeyBytes, Nothing, DataProtectionScope.LocalMachine)

			algorithm.FromXmlString(Encoding.UTF8.GetString(KeyBytes))
		End Sub

		Public Shared Function EncryptData(ByVal data As String, ByVal publicKey As String) As Byte()
			' Create the algorithm based on the key
			Dim Algorithm As RSACryptoServiceProvider = New RSACryptoServiceProvider()
			Algorithm.FromXmlString(publicKey)

			' Now encrypt the data
			Return Algorithm.Encrypt(Encoding.UTF8.GetBytes(data), True)
		End Function

		Public Shared Function DecryptData(ByVal data As Byte(), ByVal keyFile As String) As String
			Dim Algorithm As RSACryptoServiceProvider = New RSACryptoServiceProvider()
			ReadKey(Algorithm, keyFile)

			Dim ClearData As Byte() = Algorithm.Decrypt(data, True)
			Return Convert.ToString(Encoding.UTF8.GetString(ClearData))
		End Function
	End Class
End Namespace
