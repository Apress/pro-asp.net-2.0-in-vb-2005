Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace APress.ProAspNet.Utility
	Public Class HexEncoding
		Private Sub New()
		End Sub
		Public Shared Function GetString(ByVal data As Byte()) As String
			Dim Results As StringBuilder = New StringBuilder()
			For Each b As Byte In data
				Results.Append(b.ToString("X2"))
			Next b

			Return Results.ToString()
		End Function

		Public Shared Function GetBytes(ByVal data As String) As Byte()
			' GetString encodes the hex-numbers with two digits
			Dim Results As Byte() = New Byte(data.Length / 2 - 1){}
			Dim i As Integer = 0
            Do While i < data.Length
                Results(i / 2) = Convert.ToByte(data.Substring(i, 2), 16)
                i += 2
            Loop

			Return Results
		End Function
	End Class
End Namespace
