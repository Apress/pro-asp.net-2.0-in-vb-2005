Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports FileDataComponent


Namespace ConsoleClient
	Friend Class Program
		Shared Sub Main(ByVal args As String())
			Console.WriteLine("Downloading to c:\")
			FileData.ClientFolder = "c:\"
			Console.WriteLine("Enter the name of the file to download.")
			Console.WriteLine("This is a file in the server's download directory.")
			Console.WriteLine("The download directory is c:\temp by default.")
			Console.Write("> ")
			Dim file As String = Console.ReadLine()
			Dim proxy As FileService = New FileService()
			Console.WriteLine()
			Console.WriteLine("Starting download.")
			proxy.DownloadFile(file)
			Console.WriteLine("Download complete.")
			Console.ReadLine()
		End Sub
	End Class
End Namespace
