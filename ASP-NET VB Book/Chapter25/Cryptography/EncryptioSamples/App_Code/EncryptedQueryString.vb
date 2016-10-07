Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Security.Cryptography
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports APress.ProAspNet.Utility

Public Class EncryptedQueryString : Inherits System.Collections.Specialized.StringDictionary
	Public Sub New()
		' Nothing to do here
	End Sub

	Public Sub New(ByVal encryptedData As String)
		' Decrypt data passed in using DPAPI
		Dim RawData As Byte() = HexEncoding.GetBytes(encryptedData)
		Dim ClearRawData As Byte() = ProtectedData.Unprotect(RawData, Nothing, DataProtectionScope.LocalMachine)
		Dim StringData As String = Encoding.UTF8.GetString(ClearRawData)

		' Split the data and add the contents
		Dim Index As Integer
		Dim SplittedData As String() = StringData.Split(New Char() { "&"c })
		For Each SingleData As String In SplittedData
			Index = SingleData.IndexOf("="c)
			MyBase.Add(HttpUtility.UrlDecode(SingleData.Substring(0, Index)), HttpUtility.UrlDecode(SingleData.Substring(Index + 1)))
		Next SingleData
	End Sub

	Public Overrides Function ToString() As String
		Dim Content As StringBuilder = New StringBuilder()

		' Go through the contents and build a 
		' typical query string
		For Each key As String In MyBase.Keys
			Content.Append(HttpUtility.UrlEncode(key))
			Content.Append("=")
			Content.Append(HttpUtility.UrlEncode(MyBase.Item(key)))
			Content.Append("&")
		Next key

		' Remove the last '&'
		Content.Remove(Content.Length-1, 1)

		' Now encrypt the contents using DPAPI
		Dim EncryptedData As Byte() = ProtectedData.Protect(Encoding.UTF8.GetBytes(Content.ToString()), Nothing, DataProtectionScope.LocalMachine)

		' Convert encrypted byte array to a URL-legal string
		' This would also be a good place to check that data
		' is not larger than typical 4KB query string
		Return HexEncoding.GetString(EncryptedData)
	End Function
End Class
