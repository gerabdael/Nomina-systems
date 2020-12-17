<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ComboBox1 = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.ComboBox2 = New System.Windows.Forms.ComboBox()
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(28, 26)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(39, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Label1"
		'
		'ComboBox1
		'
		Me.ComboBox1.FormattingEnabled = True
		Me.ComboBox1.Location = New System.Drawing.Point(98, 23)
		Me.ComboBox1.Name = "ComboBox1"
		Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
		Me.ComboBox1.TabIndex = 1
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(259, 26)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(39, 13)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Label2"
		'
		'ComboBox2
		'
		Me.ComboBox2.FormattingEnabled = True
		Me.ComboBox2.Location = New System.Drawing.Point(318, 23)
		Me.ComboBox2.Name = "ComboBox2"
		Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
		Me.ComboBox2.TabIndex = 3
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.Location = New System.Drawing.Point(477, 23)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker1.TabIndex = 4
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(713, 21)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 5
		Me.Button1.Text = "Button1"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'DataGridView1
		'
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Location = New System.Drawing.Point(15, 159)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.Size = New System.Drawing.Size(773, 272)
		Me.DataGridView1.TabIndex = 6
		'
		'Form4
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.DateTimePicker1)
		Me.Controls.Add(Me.ComboBox2)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.ComboBox1)
		Me.Controls.Add(Me.Label1)
		Me.Name = "Form4"
		Me.Text = "Form4"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
