<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Recibos_de_Nómina
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.Imprimir = New System.Windows.Forms.Button()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.TextBox13 = New System.Windows.Forms.TextBox()
		Me.ListBox1 = New System.Windows.Forms.ListBox()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Imprimir
		'
		Me.Imprimir.Location = New System.Drawing.Point(704, 86)
		Me.Imprimir.Name = "Imprimir"
		Me.Imprimir.Size = New System.Drawing.Size(95, 34)
		Me.Imprimir.TabIndex = 0
		Me.Imprimir.Text = "Imprimir"
		Me.Imprimir.UseVisualStyleBackColor = True
		'
		'DataGridView1
		'
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Location = New System.Drawing.Point(12, 126)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.Size = New System.Drawing.Size(959, 232)
		Me.DataGridView1.TabIndex = 1
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.Location = New System.Drawing.Point(257, 16)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker1.TabIndex = 2
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(473, 29)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 3
		Me.Button1.Text = "Filtrar"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'TextBox13
		'
		Me.TextBox13.Location = New System.Drawing.Point(715, 34)
		Me.TextBox13.Name = "TextBox13"
		Me.TextBox13.Size = New System.Drawing.Size(70, 20)
		Me.TextBox13.TabIndex = 25
		'
		'ListBox1
		'
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Location = New System.Drawing.Point(57, 19)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(194, 17)
		Me.ListBox1.TabIndex = 27
		Me.ListBox1.Visible = False
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(879, 12)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(70, 20)
		Me.TextBox1.TabIndex = 28
		Me.TextBox1.Visible = False
		'
		'DateTimePicker2
		'
		Me.DateTimePicker2.Location = New System.Drawing.Point(257, 42)
		Me.DateTimePicker2.Name = "DateTimePicker2"
		Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker2.TabIndex = 29
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(324, 77)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(75, 23)
		Me.Button3.TabIndex = 30
		Me.Button3.Text = "TODOS"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'DateTimePicker3
		'
		Me.DateTimePicker3.Location = New System.Drawing.Point(646, 60)
		Me.DateTimePicker3.Name = "DateTimePicker3"
		Me.DateTimePicker3.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker3.TabIndex = 31
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(503, 94)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(103, 20)
		Me.TextBox2.TabIndex = 32
		Me.TextBox2.Visible = False
		'
		'Recibos_de_Nómina
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(983, 382)
		Me.Controls.Add(Me.TextBox2)
		Me.Controls.Add(Me.DateTimePicker3)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.DateTimePicker2)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.ListBox1)
		Me.Controls.Add(Me.TextBox13)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.DateTimePicker1)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.Imprimir)
		Me.Name = "Recibos_de_Nómina"
		Me.Text = "Recibos_de_Nómina"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Imprimir As Button
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents DateTimePicker1 As DateTimePicker
	Friend WithEvents Button1 As Button
	Friend WithEvents TextBox13 As TextBox
	Friend WithEvents ListBox1 As ListBox
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents DateTimePicker2 As DateTimePicker
	Friend WithEvents Button3 As Button
	Friend WithEvents DateTimePicker3 As DateTimePicker
	Friend WithEvents TextBox2 As TextBox
End Class
