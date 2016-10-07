Imports Microsoft.VisualBasic
Imports System
Namespace WindowsClient
	Friend partial Class Form1
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
			Me.dataGridView1 = New System.Windows.Forms.DataGridView()
			Me.cmdGetData = New System.Windows.Forms.Button()
			Me.cmdTestStateRight = New System.Windows.Forms.Button()
			Me.cmdTestStateWrong = New System.Windows.Forms.Button()
			CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dataGridView1
			' 
			Me.dataGridView1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.dataGridView1.Location = New System.Drawing.Point(3, 3)
			Me.dataGridView1.Name = "dataGridView1"
			Me.dataGridView1.Size = New System.Drawing.Size(463, 331)
			Me.dataGridView1.TabIndex = 0
			Me.dataGridView1.Text = "dataGridView1"
			' 
			' cmdGetData
			' 
			Me.cmdGetData.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cmdGetData.Location = New System.Drawing.Point(390, 338)
			Me.cmdGetData.Name = "cmdGetData"
			Me.cmdGetData.Size = New System.Drawing.Size(75, 29)
			Me.cmdGetData.TabIndex = 1
			Me.cmdGetData.Text = "Get Data"
'			Me.cmdGetData.Click += New System.EventHandler(Me.cmdGetData_Click);
			' 
			' cmdTestStateRight
			' 
			Me.cmdTestStateRight.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cmdTestStateRight.Location = New System.Drawing.Point(3, 338)
			Me.cmdTestStateRight.Name = "cmdTestStateRight"
			Me.cmdTestStateRight.Size = New System.Drawing.Size(138, 29)
			Me.cmdTestStateRight.TabIndex = 2
			Me.cmdTestStateRight.Text = "Test State (Successful)"
'			Me.cmdTestStateRight.Click += New System.EventHandler(Me.cmdTestStateRight_Click);
			' 
			' cmdTestStateWrong
			' 
			Me.cmdTestStateWrong.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cmdTestStateWrong.Location = New System.Drawing.Point(147, 338)
			Me.cmdTestStateWrong.Name = "cmdTestStateWrong"
			Me.cmdTestStateWrong.Size = New System.Drawing.Size(138, 29)
			Me.cmdTestStateWrong.TabIndex = 3
			Me.cmdTestStateWrong.Text = "Test State (Unsuccessful)"
'			Me.cmdTestStateWrong.Click += New System.EventHandler(Me.cmdTestStateWrong_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(469, 372)
			Me.Controls.Add(Me.cmdTestStateWrong)
			Me.Controls.Add(Me.cmdTestStateRight)
			Me.Controls.Add(Me.cmdGetData)
			Me.Controls.Add(Me.dataGridView1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private dataGridView1 As System.Windows.Forms.DataGridView
		Private WithEvents cmdGetData As System.Windows.Forms.Button
		Private WithEvents cmdTestStateRight As System.Windows.Forms.Button
		Private WithEvents cmdTestStateWrong As System.Windows.Forms.Button
	End Class
End Namespace

