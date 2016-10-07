Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Namespace APress.ProAspNet.Utility
	Public Class MyEncryptionUtility
		' Shhh!!! Don't tell anybody!
		Private Const MyKey As String = "m$%&kljasldk$%/65asjdl"

		Private Sub New()
		End Sub
		Public Shared Function Encrypt(ByVal data As String) As Byte()
			' Use "MyKey" to encrypt data
			Return Nothing
		End Function
	End Class

	Public Class SymmetricEncryptionUtility
		Private Shared _ProtectKey As Boolean
		Private Shared _AlgorithmName As String

		' Shhh!!! Don't tell anybody!
		Private Const MyKey As String = "m$%&kljasldk$%/65asjdl"

		Private Sub New()
		End Sub
		Public Shared Property AlgorithmName() As String
			Get
				Return _AlgorithmName
			End Get
			Set
				_AlgorithmName = Value
			End Set
		End Property

		Public Shared Property ProtectKey() As Boolean
			Get
				Return _ProtectKey
			End Get
			Set
				_ProtectKey = Value
			End Set
		End Property

		Public Shared Sub GenerateKey(ByVal targetFile As String)
			' Create the algorithm
			Dim Algorithm As SymmetricAlgorithm = SymmetricAlgorithm.Create(AlgorithmName)
			Algorithm.GenerateKey()

			' No get the key
			Dim Key As Byte() = Algorithm.Key

			If ProtectKey Then
				' Use DPAPI to encrypt key
				Key = ProtectedData.Protect(Key, Nothing, DataProtectionScope.LocalMachine)
			End If

			' Store the key in a file called key.config
			Using fs As FileStream = New FileStream(targetFile, FileMode.Create)
				fs.Write(Key, 0, Key.Length)
			End Using
		End Sub

		Public Shared Sub ReadKey(ByVal algorithm As SymmetricAlgorithm, ByVal keyFile As String)
			Dim Key As Byte()

			Using fs As FileStream = New FileStream(keyFile, FileMode.Open)
				Key = New Byte(fs.Length - 1){}
				fs.Read(Key, 0, CInt(fs.Length))
			End Using

			If ProtectKey Then
				algorithm.Key = ProtectedData.Unprotect(Key, Nothing, DataProtectionScope.LocalMachine)
			Else
				algorithm.Key = Key
			End If
		End Sub

		Public Shared Function EncryptData(ByVal data As String, ByVal keyFile As String) As Byte()
			' Convert string data to byte array
			Dim ClearData As Byte() = Encoding.UTF8.GetBytes(data)

			' Now Create the algorithm
			Dim Algorithm As SymmetricAlgorithm = SymmetricAlgorithm.Create(AlgorithmName)
			ReadKey(Algorithm, keyFile)

			' Encrypt information
			Dim Target As MemoryStream = New MemoryStream()

			' Append IV
			Algorithm.GenerateIV()
			Target.Write(Algorithm.IV, 0, Algorithm.IV.Length)

			' Encrypt actual data
			Dim cs As CryptoStream = New CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write)
			cs.Write(ClearData, 0, ClearData.Length)
			cs.FlushFinalBlock()

			' Output the bytes of the encrypted array to the textbox
			Return Target.ToArray()
		End Function

		Public Shared Function DecryptData(ByVal data As Byte(), ByVal keyFile As String) As String
			' Now create the algorithm
			Dim Algorithm As SymmetricAlgorithm = SymmetricAlgorithm.Create(AlgorithmName)
			ReadKey(Algorithm, keyFile)

			' Decrypt information
			Dim Target As MemoryStream = New MemoryStream()

			' Read IV
			Dim ReadPos As Integer = 0
			Dim IV As Byte() = New Byte(Algorithm.IV.Length - 1){}
			Array.Copy(data, IV, IV.Length)
			Algorithm.IV = IV
			ReadPos += Algorithm.IV.Length

			Dim cs As CryptoStream = New CryptoStream(Target, Algorithm.CreateDecryptor(), CryptoStreamMode.Write)
			cs.Write(data, ReadPos, data.Length - ReadPos)
			cs.FlushFinalBlock()

			' Get the bytes from the memory stream and convert them to text
			Return Encoding.UTF8.GetString(Target.ToArray())
		End Function
	End Class
End Namespace
