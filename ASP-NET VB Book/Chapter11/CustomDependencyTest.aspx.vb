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
Imports System.Messaging

Public partial Class CustomDependencyTest : Inherits System.Web.UI.Page
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
		lblInfo.Text &= "<br>"
	End Sub

	Private queueName As String = ".\Private$\TestQueue"
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Me.IsPostBack) Then
			' Set up the queue.
			Dim queue As MessageQueue
			If MessageQueue.Exists(queueName) Then
				queue = New MessageQueue(queueName)
			Else
				queue = MessageQueue.Create(".\Private$\TestQueue")
			End If

			lblInfo.Text &= "Creating dependent item...<br/>"
			Cache.Remove("Item")
			Dim dependency As MessageQueueCacheDependency = New MessageQueueCacheDependency(queueName)
			Dim item As String = "Dependent cached item"
			lblInfo.Text &= "Adding dependent item<br/>"
			Cache.Insert("Item", item, dependency)
		End If
	End Sub

	Protected Sub cmdModfiy_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim queue As MessageQueue = New MessageQueue(queueName)

		' (You could send a custom object instead
		'  of a string.)
		queue.Send("Invalidate!")
		lblInfo.Text &= "Message sent<br/>"
	End Sub

	Protected Sub cmdGetItem_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Cache("Item") Is Nothing Then
			lblInfo.Text &= "Cache item no longer exits.<br>"
		Else
			Dim cacheInfo As String = CStr(Cache("Item"))
			lblInfo.Text &= "Retrieved item with text: '" & cacheInfo & "'<br>"
		End If
	End Sub
End Class
