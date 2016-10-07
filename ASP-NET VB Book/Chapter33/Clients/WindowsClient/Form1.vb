Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports localhost1
Imports System.Web.Services.Protocols


Namespace WindowsClient
    Partial Friend Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub cmdGetData_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Cursor = Cursors.WaitCursor

            ' Create the proxy.
            Dim proxy As EmployeesService = New EmployeesService()

            ' Bind the results.
            dataGridView1.DataSource = proxy.GetEmployees()

            Me.Cursor = Cursors.Default

        End Sub

        Private Sub cmdError_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim proxy As EmployeesService = New EmployeesService()
            Try
                Dim count As Integer = proxy.GetEmployeesCountError()
            Catch err As SoapException
                MessageBox.Show("Original error was: " & err.Detail.InnerText)
            End Try

        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim proxy As SessionHeaderService = New SessionHeaderService()
            proxy.CreateSession()
            proxy.SetSessionData(New DataSet("TestDataSet"))
            Dim ds As DataSet = proxy.GetSessionData()
            If ds Is Nothing Then
                MessageBox.Show("Test Failed.")
            Else
                MessageBox.Show("Retrieved DataSet " & ds.DataSetName)
            End If
        End Sub


    End Class
End Namespace