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
Imports localhost
Imports System.Threading

Public partial Class AsyncTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdSynchronous_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Record the start time.
		Dim startTime As DateTime = DateTime.Now

        ' Get the web service data.
        Dim proxy As EmployeesService = New EmployeesService()
		Try
			GridView1.DataSource = proxy.GetEmployeesSlow()
		Catch err As Exception
			lblInfo.Text = "Problem contacting web service."
			Return
		End Try

		GridView1.DataBind()

		' Perform some other time-consuming tasks.
		DoSomethingSlow()

		' Determine the total time taken.
		Dim timeTaken As TimeSpan = DateTime.Now.Subtract(startTime)
		lblInfo.Text = "Synchronous operations took " & timeTaken.TotalSeconds & " seconds."

	End Sub

	Private Sub DoSomethingSlow()
		System.Threading.Thread.Sleep(3000)
	End Sub

	Protected Sub cmdAsynchronous_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Record the start time.
		Dim startTime As DateTime = DateTime.Now

		' Start the web service on another thread.
		Dim proxy As EmployeesService = New EmployeesService()
		Dim async As GetEmployeesDelegate = New GetEmployeesDelegate(AddressOf proxy.GetEmployeesSlow)
		Dim handle As IAsyncResult = async.BeginInvoke(Nothing, Nothing)

		' Perform some other time-consuming tasks.
		DoSomethingSlow()

		' Retrieve the result. If it isn't ready, wait.
		Try
			GridView1.DataSource = async.EndInvoke(handle)
		Catch err As Exception
			lblInfo.Text = "Problem contacting web service."
			Return
		End Try
		GridView1.DataBind()

		' Determine the total time taken.
		Dim timeTaken As TimeSpan = DateTime.Now.Subtract(startTime)
		lblInfo.Text = "Asynchronous operations took " & timeTaken.TotalSeconds & " seconds."

	End Sub
	Public Delegate Function GetEmployeesDelegate() As DataSet

	Protected Sub cmdMultiple_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Record the start time.
		Dim startTime As DateTime = DateTime.Now

		Dim proxy As EmployeesService = New EmployeesService()
		Dim async As GetEmployeesDelegate = New GetEmployeesDelegate(AddressOf proxy.GetEmployeesSlow)

		' Call three methods asynchronously.
		Dim handle1 As IAsyncResult = async.BeginInvoke(Nothing, Nothing)
		Dim handle2 As IAsyncResult = async.BeginInvoke(Nothing, Nothing)
		Dim handle3 As IAsyncResult = async.BeginInvoke(Nothing, Nothing)

		' Create an array of WaitHandle objects.
		Dim waitHandles As WaitHandle() = {handle1.AsyncWaitHandle, handle2.AsyncWaitHandle, handle3.AsyncWaitHandle}

		' Wait for all the calls to finish.
		WaitHandle.WaitAll(waitHandles)

		' You can now retrieve the results.
		Dim ds1 As DataSet = async.EndInvoke(handle1)
		Dim ds2 As DataSet = async.EndInvoke(handle2)
		Dim ds3 As DataSet = async.EndInvoke(handle3)

		' Merge all the results into one table and display it.
		Dim dsMerge As DataSet = New DataSet()
		dsMerge.Merge(ds1)
		dsMerge.Merge(ds2)
		dsMerge.Merge(ds3)
		GridView1.DataSource = dsMerge
		GridView1.DataBind()

		' Determine the total time taken.
		Dim timeTaken As TimeSpan = DateTime.Now.Subtract(startTime)
		lblInfo.Text = "Calling three methods took " & timeTaken.TotalSeconds & " seconds."

	End Sub
End Class
