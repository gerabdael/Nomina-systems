<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formgerente
	Inherits System.Windows.Forms.Form

	'Form reemplaza a Dispose para limpiar la lista de componentes.
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

	'Requerido por el Diseñador de Windows Forms
	Private components As System.ComponentModel.IContainer

	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar usando el Diseñador de Windows Forms.  
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.Usuario = New System.Windows.Forms.ListBox()
		Me.User = New System.Windows.Forms.TextBox()
		Me.Pass = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.Button4 = New System.Windows.Forms.Button()
		Me.Button5 = New System.Windows.Forms.Button()
		Me.Button6 = New System.Windows.Forms.Button()
		Me.Button7 = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Usuario
		'
		Me.Usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Usuario.FormattingEnabled = True
		Me.Usuario.Location = New System.Drawing.Point(143, 12)
		Me.Usuario.MultiColumn = True
		Me.Usuario.Name = "Usuario"
		Me.Usuario.Size = New System.Drawing.Size(178, 15)
		Me.Usuario.TabIndex = 0
		'
		'User
		'
		Me.User.Location = New System.Drawing.Point(332, 12)
		Me.User.Name = "User"
		Me.User.Size = New System.Drawing.Size(100, 20)
		Me.User.TabIndex = 1
		Me.User.Visible = False
		'
		'Pass
		'
		Me.Pass.Location = New System.Drawing.Point(332, 35)
		Me.Pass.Name = "Pass"
		Me.Pass.Size = New System.Drawing.Size(100, 20)
		Me.Pass.TabIndex = 2
		Me.Pass.Visible = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 12)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(116, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Bienvenido Empleado: "
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(15, 81)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(113, 23)
		Me.Button1.TabIndex = 4
		Me.Button1.Text = "Gestionar Empresa"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(152, 81)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(113, 23)
		Me.Button2.TabIndex = 5
		Me.Button2.Text = "Agregar Empleado"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(291, 81)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(141, 23)
		Me.Button3.TabIndex = 6
		Me.Button3.Text = "Agregar Puestos"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'Button4
		'
		Me.Button4.Location = New System.Drawing.Point(54, 126)
		Me.Button4.Name = "Button4"
		Me.Button4.Size = New System.Drawing.Size(151, 23)
		Me.Button4.TabIndex = 7
		Me.Button4.Text = "Gestionar Empleados"
		Me.Button4.UseVisualStyleBackColor = True
		'
		'Button5
		'
		Me.Button5.Location = New System.Drawing.Point(247, 180)
		Me.Button5.Name = "Button5"
		Me.Button5.Size = New System.Drawing.Size(151, 23)
		Me.Button5.TabIndex = 8
		Me.Button5.Text = "Nomina General"
		Me.Button5.UseVisualStyleBackColor = True
		'
		'Button6
		'
		Me.Button6.Location = New System.Drawing.Point(54, 180)
		Me.Button6.Name = "Button6"
		Me.Button6.Size = New System.Drawing.Size(145, 23)
		Me.Button6.TabIndex = 9
		Me.Button6.Text = "PAGAR EMPLEADOS"
		Me.Button6.UseVisualStyleBackColor = True
		'
		'Button7
		'
		Me.Button7.Location = New System.Drawing.Point(247, 126)
		Me.Button7.Name = "Button7"
		Me.Button7.Size = New System.Drawing.Size(145, 23)
		Me.Button7.TabIndex = 10
		Me.Button7.Text = "Incidencias Generales"
		Me.Button7.UseVisualStyleBackColor = True
		'
		'formgerente
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(446, 281)
		Me.Controls.Add(Me.Button7)
		Me.Controls.Add(Me.Button6)
		Me.Controls.Add(Me.Button5)
		Me.Controls.Add(Me.Button4)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Pass)
		Me.Controls.Add(Me.User)
		Me.Controls.Add(Me.Usuario)
		Me.Name = "formgerente"
		Me.Text = "formgerente"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Usuario As ListBox
	Friend WithEvents User As TextBox
	Friend WithEvents Pass As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
	Friend WithEvents Button4 As Button
	Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
End Class
