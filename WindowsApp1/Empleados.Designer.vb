<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Empleados
	Inherits System.Windows.Forms.Form

	'Form reemplaza a Dispose para limpiar la lista de componentes.
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

	'Requerido por el Diseñador de Windows Forms
	Private components As System.ComponentModel.IContainer

	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar usando el Diseñador de Windows Forms.  
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ListBox1 = New System.Windows.Forms.ListBox()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.TextBox3 = New System.Windows.Forms.TextBox()
		Me.TextBox4 = New System.Windows.Forms.TextBox()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(788, 3)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(44, 20)
		Me.TextBox1.TabIndex = 0
		Me.TextBox1.Visible = False
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(738, 3)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(44, 20)
		Me.TextBox2.TabIndex = 1
		Me.TextBox2.Visible = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 10)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(105, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Empleados empresa:"
		'
		'ListBox1
		'
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Location = New System.Drawing.Point(123, 10)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(208, 17)
		Me.ListBox1.TabIndex = 4
		'
		'DataGridView1
		'
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Location = New System.Drawing.Point(15, 54)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.Size = New System.Drawing.Size(648, 266)
		Me.DataGridView1.TabIndex = 5
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(498, 326)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 6
		Me.Button1.Text = "Modificar"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(588, 326)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(75, 23)
		Me.Button2.TabIndex = 7
		Me.Button2.Text = "Despedir"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'TextBox3
		'
		Me.TextBox3.Location = New System.Drawing.Point(720, 195)
		Me.TextBox3.Name = "TextBox3"
		Me.TextBox3.Size = New System.Drawing.Size(44, 20)
		Me.TextBox3.TabIndex = 9
		Me.TextBox3.Visible = False
		'
		'TextBox4
		'
		Me.TextBox4.Location = New System.Drawing.Point(738, 221)
		Me.TextBox4.Name = "TextBox4"
		Me.TextBox4.Size = New System.Drawing.Size(44, 20)
		Me.TextBox4.TabIndex = 8
		Me.TextBox4.Visible = False
		'
		'Empleados
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(829, 450)
		Me.Controls.Add(Me.TextBox3)
		Me.Controls.Add(Me.TextBox4)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.ListBox1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.TextBox2)
		Me.Controls.Add(Me.TextBox1)
		Me.Name = "Empleados"
		Me.Text = "Empleados"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents ListBox1 As ListBox
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents TextBox3 As TextBox
	Friend WithEvents TextBox4 As TextBox
End Class
