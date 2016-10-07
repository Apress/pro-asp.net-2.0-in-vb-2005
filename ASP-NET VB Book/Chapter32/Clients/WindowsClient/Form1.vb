Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports localhost
Imports localhost1


Namespace WindowsClient
    Partial Friend Class Form1 : Inherits Form
        Private cookieContainer As System.Net.CookieContainer = New System.Net.CookieContainer()


        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub cmdGetData_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Cursor = Cursors.WaitCursor

            ' Create the proxy.
            Dim proxy As EmployeesService = New EmployeesService()

            ' Call the web service and get the results.
            Dim ds As DataSet = proxy.GetEmployees()

            ' Bind the results.
            dataGridView1.DataSource = ds.Tables(0)

            Me.Cursor = Cursors.Default

        End Sub

        Private Sub cmdTestStateRight_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim proxy As StatefulService = New StatefulService()
            proxy.CookieContainer = cookieContainer

            proxy.StoreName("John Smith")
            MessageBox.Show("You set: " & proxy.GetName())

        End Sub

        Private Sub cmdTestStateWrong_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create the proxy.
            Dim proxy As StatefulService = New StatefulService()


            ' Set a name.
            proxy.StoreName("John Smith")

            ' Try to retrieve the name.
            MessageBox.Show("You set: " & proxy.GetName())

        End Sub
    End Class
End Namespace