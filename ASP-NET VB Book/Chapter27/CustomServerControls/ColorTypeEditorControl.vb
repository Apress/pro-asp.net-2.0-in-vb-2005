Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Web.UI.WebControls

Namespace CustomServerControlsLibrary
	''' <summary>
	''' A custom UI editor for colors.
	''' </summary>
	<ToolboxItem(False)> _
	Public Class ColorTypeEditorControl : Inherits System.Windows.Forms.UserControl
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private pnlSample As System.Windows.Forms.Panel
		Private trkRed As System.Windows.Forms.TrackBar
		Private trkGreen As System.Windows.Forms.TrackBar
		Private trkBlue As System.Windows.Forms.TrackBar
		Private label5 As System.Windows.Forms.Label
		Private trkAlpha As System.Windows.Forms.TrackBar
		Private txtSample As System.Windows.Forms.Label
		Private WithEvents btnPicker As System.Windows.Forms.Button
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing


		'Variable keeping the current color selection. It is initialized to black.
		Private _color As Color = Color.Black
		Private _component As WebControl

		''' <summary>
		''' Constructor of the user control.
		''' </summary>
		''' <param name="colorToEdit">The color which is going to be edited.</param>
		Public Sub New(ByVal colorToEdit As Color, ByVal component As WebControl)
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

			_component = component

			'Initialize controls.
			_color = colorToEdit
			trkAlpha.Value = _color.A
			trkBlue.Value = _color.B
			trkGreen.Value = _color.G
			trkRed.Value = _color.R
			pnlSample.BackColor = _color

			'Attach handlers to controls.
			AddHandler trkAlpha.ValueChanged, AddressOf OnColorChanged
			AddHandler trkBlue.ValueChanged, AddressOf OnColorChanged
			AddHandler trkGreen.ValueChanged, AddressOf OnColorChanged
			AddHandler trkRed.ValueChanged, AddressOf OnColorChanged
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.trkBlue = New System.Windows.Forms.TrackBar()
			Me.trkAlpha = New System.Windows.Forms.TrackBar()
			Me.trkGreen = New System.Windows.Forms.TrackBar()
			Me.pnlSample = New System.Windows.Forms.Panel()
			Me.txtSample = New System.Windows.Forms.Label()
			Me.btnPicker = New System.Windows.Forms.Button()
			Me.label5 = New System.Windows.Forms.Label()
			Me.trkRed = New System.Windows.Forms.TrackBar()
			CType(Me.trkBlue, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.trkAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.trkGreen, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.trkRed, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 48)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(40, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Red:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 80)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(40, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Green:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 112)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(40, 16)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Blue:"
			' 
			' trkBlue
			' 
			Me.trkBlue.AutoSize = False
			Me.trkBlue.Location = New System.Drawing.Point(52, 108)
			Me.trkBlue.Maximum = 255
			Me.trkBlue.Name = "trkBlue"
			Me.trkBlue.Size = New System.Drawing.Size(144, 45)
			Me.trkBlue.SmallChange = 10
			Me.trkBlue.TabIndex = 3
			' 
			' trkAlpha
			' 
			Me.trkAlpha.AutoSize = False
			Me.trkAlpha.Location = New System.Drawing.Point(52, 12)
			Me.trkAlpha.Maximum = 255
			Me.trkAlpha.Name = "trkAlpha"
			Me.trkAlpha.Size = New System.Drawing.Size(144, 45)
			Me.trkAlpha.SmallChange = 10
			Me.trkAlpha.TabIndex = 3
			' 
			' trkGreen
			' 
			Me.trkGreen.AutoSize = False
			Me.trkGreen.Location = New System.Drawing.Point(52, 76)
			Me.trkGreen.Maximum = 255
			Me.trkGreen.Name = "trkGreen"
			Me.trkGreen.Size = New System.Drawing.Size(144, 45)
			Me.trkGreen.SmallChange = 10
			Me.trkGreen.TabIndex = 3
			' 
			' pnlSample
			' 
			Me.pnlSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlSample.Location = New System.Drawing.Point(8, 184)
			Me.pnlSample.Name = "pnlSample"
			Me.pnlSample.Size = New System.Drawing.Size(188, 16)
			Me.pnlSample.TabIndex = 2
			' 
			' txtSample
			' 
			Me.txtSample.Location = New System.Drawing.Point(8, 164)
			Me.txtSample.Name = "txtSample"
			Me.txtSample.Size = New System.Drawing.Size(76, 16)
			Me.txtSample.TabIndex = 1
			Me.txtSample.Text = "Sample Color:"
			' 
			' btnPicker
			' 
			Me.btnPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
			Me.btnPicker.Location = New System.Drawing.Point(148, 160)
			Me.btnPicker.Name = "btnPicker"
			Me.btnPicker.Size = New System.Drawing.Size(48, 20)
			Me.btnPicker.TabIndex = 4
			Me.btnPicker.Text = "Picker"
'			Me.btnPicker.Click += New System.EventHandler(Me.btnPicker_Click);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 16)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(40, 16)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Alpha:"
			' 
			' trkRed
			' 
			Me.trkRed.AutoSize = False
			Me.trkRed.Location = New System.Drawing.Point(52, 44)
			Me.trkRed.Maximum = 255
			Me.trkRed.Name = "trkRed"
			Me.trkRed.Size = New System.Drawing.Size(144, 45)
			Me.trkRed.SmallChange = 10
			Me.trkRed.TabIndex = 3
			' 
			' ColorTypeEditorControl
			' 
			Me.BackColor = System.Drawing.Color.FromArgb((CByte(153)), (CByte(153)), (CByte(255)))
			Me.Controls.AddRange(New System.Windows.Forms.Control() { Me.btnPicker, Me.txtSample, Me.trkBlue, Me.trkGreen, Me.trkRed, Me.pnlSample, Me.label3, Me.label2, Me.label1, Me.label5, Me.trkAlpha})
			Me.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.Name = "ColorTypeEditorControl"
			Me.Size = New System.Drawing.Size(204, 208)
			CType(Me.trkBlue, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.trkAlpha, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.trkGreen, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.trkRed, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub OnColorChanged(ByVal sender As Object, ByVal e As EventArgs)
			_color = Color.FromArgb(trkAlpha.Value, trkRed.Value, trkGreen.Value, trkBlue.Value)
			pnlSample.BackColor = _color
			'_component.BackColor = _color;	//This won't work!
			'PropertyDescriptorCollection col = TypeDescriptor.GetProperties(_component);
			'col["BackColor"].SetValue(_component, _color);
			'Resumed version of the previous 2 lines
			TypeDescriptor.GetProperties(_component)("BackColor").SetValue(_component, _color)
		End Sub

		Private Sub btnPicker_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPicker.Click
'			ColorDialog dlg = new ColorDialog();
'			dlg.Color = _color;
'			if (dlg.ShowDialog() == DialogResult.OK) _color = dlg.Color;

			Dim tc As TypeConverter = TypeDescriptor.GetConverter(_color)

			Dim res As String = System.Web.UI.Design.ColorBuilder.BuildColor(_component, Me, tc.ConvertToString(_color))

			If res <> String.Empty AndAlso Not res Is Nothing Then
				_color = CType(tc.ConvertFromString(res), Color)
			End If
		End Sub

		Friend ReadOnly Property SelectedColor() As Color
			Get
				Return _color
			End Get
		End Property
	End Class
End Namespace