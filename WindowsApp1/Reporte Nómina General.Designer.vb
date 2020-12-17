<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
		Me.ComboBox2 = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
		Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.Button4 = New System.Windows.Forms.Button()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'DataGridView1
		'
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Location = New System.Drawing.Point(14, 161)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.Size = New System.Drawing.Size(1012, 269)
		Me.DataGridView1.TabIndex = 18
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(479, 22)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 17
		Me.Button1.Text = "Filtrar"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.Location = New System.Drawing.Point(243, 24)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker1.TabIndex = 16
		'
		'ComboBox2
		'
		Me.ComboBox2.FormattingEnabled = True
		Me.ComboBox2.Location = New System.Drawing.Point(84, 24)
		Me.ComboBox2.Name = "ComboBox2"
		Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
		Me.ComboBox2.TabIndex = 15
		Me.ComboBox2.Visible = False
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 136)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(124, 13)
		Me.Label2.TabIndex = 14
		Me.Label2.Text = "Reporte Nomina General"
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(780, 17)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(117, 23)
		Me.Button2.TabIndex = 19
		Me.Button2.Text = "Mostrar todo"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'DateTimePicker2
		'
		Me.DateTimePicker2.Location = New System.Drawing.Point(176, 86)
		Me.DateTimePicker2.Name = "DateTimePicker2"
		Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker2.TabIndex = 20
		'
		'DateTimePicker3
		'
		Me.DateTimePicker3.Location = New System.Drawing.Point(382, 86)
		Me.DateTimePicker3.Name = "DateTimePicker3"
		Me.DateTimePicker3.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker3.TabIndex = 21
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(588, 83)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(75, 23)
		Me.Button3.TabIndex = 22
		Me.Button3.Text = "Filtrar"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'Button4
		'
		Me.Button4.Location = New System.Drawing.Point(780, 83)
		Me.Button4.Name = "Button4"
		Me.Button4.Size = New System.Drawing.Size(117, 23)
		Me.Button4.TabIndex = 23
		Me.Button4.Text = "IMPRIMIR"
		Me.Button4.UseVisualStyleBackColor = True
		'
		'Form6
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1038, 450)
		Me.Controls.Add(Me.Button4)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.DateTimePicker3)
		Me.Controls.Add(Me.DateTimePicker2)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.DateTimePicker1)
		Me.Controls.Add(Me.ComboBox2)
		Me.Controls.Add(Me.Label2)
		Me.Name = "Form6"
		Me.Text = "Form6"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label2 As Label
	Friend WithEvents Button2 As Button
	Friend WithEvents DateTimePicker2 As DateTimePicker
	Friend WithEvents DateTimePicker3 As DateTimePicker
	Friend WithEvents Button3 As Button
	Friend WithEvents Button4 As Button
End Class
