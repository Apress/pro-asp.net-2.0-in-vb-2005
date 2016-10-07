<%@ Application Language="vb" ClassName="Global" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Collections.Generic" %>
<script runat="server">

    Private Shared TheFileList As String()
	Public Shared ReadOnly Property FileList() As String()
		Get
            If TheFileList Is Nothing Then
                TheFileList = Directory.GetFiles(HttpContext.Current.Request.PhysicalApplicationPath)
            End If
            Return TheFileList
		End Get
	End Property

	Private Shared metadata As Dictionary(Of String, String) = New Dictionary(Of String, String)()
	Public Sub AddMetadata(ByVal key As String, ByVal value As String)
		SyncLock metadata
			metadata(key) = value
		End SyncLock
	End Sub
	Public Function GetMetadata(ByVal key As String) As String
		SyncLock metadata
			Return metadata(key)
		End SyncLock
	End Function
</script>
