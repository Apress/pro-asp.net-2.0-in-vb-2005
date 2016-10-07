Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports localhost


Namespace WindowsClient
    Partial Friend Class AsyncTest : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private proxy As EmployeesService = New EmployeesService()

        Private requestID As Guid


        Private Sub cmdGetEmployees_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Disable the button so that only one asynchronous
            ' call will be permitted at a time.
            cmdGetEmployees.Enabled = False
            cmdCancel.Enabled = True

            ' Call the web service asynchronously.
            requestID = Guid.NewGuid()
            'proxy.GetEmployeesAsync(requestID)
            proxy.GetEmployeesLoggedAsync(requestID)
            
        End Sub

        Private Sub GetEmployeesCompleted(ByVal sender As Object, ByVal e As GetEmployeesLoggedCompletedEventArgs)
            If (Not e.Cancelled) Then
                ' Get the result.
                Try
                    dataGridView1.DataSource = e.Result
                Catch err As System.Reflection.TargetInvocationException
                    MessageBox.Show("An error occurred.")
                End Try
            End If
            cmdCancel.Enabled = False
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)

            ' Create the callback delegate.
            AddHandler proxy.GetEmployeesLoggedCompleted, AddressOf GetEmployeesCompleted

        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            proxy.CancelAsync(requestID)
            MessageBox.Show("Operation cancelled.")
        End Sub

        Private Sub cmdGetEmployees_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetEmployees.Click

        End Sub
    End Class
End Namespace