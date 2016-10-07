Imports Microsoft.VisualBasic
Imports System
Namespace WindowsClient
	Friend partial Class AsyncTest
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (Not components Is Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.cmdGetEmployees = New System.Windows.Forms.Button
            Me.dataGridView1 = New System.Windows.Forms.DataGridView
            Me.cmdCancel = New System.Windows.Forms.Button
            CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cmdGetEmployees
            '
            Me.cmdGetEmployees.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmdGetEmployees.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.cmdGetEmployees.Location = New System.Drawing.Point(300, 269)
            Me.cmdGetEmployees.Name = "cmdGetEmployees"
            Me.cmdGetEmployees.Size = New System.Drawing.Size(96, 28)
            Me.cmdGetEmployees.TabIndex = 3
            Me.cmdGetEmployees.Text = "Get Employees"
            '
            'dataGridView1
            '
            Me.dataGridView1.Location = New System.Drawing.Point(7, 7)
            Me.dataGridView1.Name = "dataGridView1"
            Me.dataGridView1.Size = New System.Drawing.Size(491, 259)
            Me.dataGridView1.TabIndex = 4
            Me.dataGridView1.Text = "dataGridView1"
            '
            'cmdCancel
            '
            Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmdCancel.Enabled = False
            Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.cmdCancel.Location = New System.Drawing.Point(402, 269)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(96, 28)
            Me.cmdCancel.TabIndex = 5
            Me.cmdCancel.Text = "Cancel"
            '
            'AsyncTest
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(508, 307)
            Me.Controls.Add(Me.cmdCancel)
            Me.Controls.Add(Me.dataGridView1)
            Me.Controls.Add(Me.cmdGetEmployees)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "AsyncTest"
            Me.Text = "EmployeesService Client"
            CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

		#End Region

		Private WithEvents cmdGetEmployees As System.Windows.Forms.Button
		Private dataGridView1 As System.Windows.Forms.DataGridView
		Private WithEvents cmdCancel As System.Windows.Forms.Button
	End Class
End Namespace

