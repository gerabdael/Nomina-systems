<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.raz_social = New System.Windows.Forms.TextBox()
        Me.dom_fiscal = New System.Windows.Forms.TextBox()
        Me.email = New System.Windows.Forms.TextBox()
        Me.reg_patronal = New System.Windows.Forms.TextBox()
        Me.reg_contador = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.nomEmpleado = New System.Windows.Forms.TextBox()
        Me.listempresas = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.startDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NombreD = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BotDept = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.apeEmpleado = New System.Windows.Forms.TextBox()
        Me.salarioDiario = New System.Windows.Forms.TextBox()
        Me.usergerente = New System.Windows.Forms.TextBox()
        Me.passGerente = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.curpbox = New System.Windows.Forms.TextBox()
        Me.IDempresas = New System.Windows.Forms.ListBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.idempresatxt = New System.Windows.Forms.TextBox()
        Me.RefreshList = New System.Windows.Forms.Button()
        Me.Check = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'nombre
        '
        Me.nombre.Location = New System.Drawing.Point(100, 48)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(151, 20)
        Me.nombre.TabIndex = 0
        '
        'raz_social
        '
        Me.raz_social.Location = New System.Drawing.Point(100, 74)
        Me.raz_social.Name = "raz_social"
        Me.raz_social.Size = New System.Drawing.Size(151, 20)
        Me.raz_social.TabIndex = 1
        '
        'dom_fiscal
        '
        Me.dom_fiscal.Location = New System.Drawing.Point(337, 47)
        Me.dom_fiscal.Name = "dom_fiscal"
        Me.dom_fiscal.Size = New System.Drawing.Size(146, 20)
        Me.dom_fiscal.TabIndex = 2
        '
        'email
        '
        Me.email.Location = New System.Drawing.Point(337, 77)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(146, 20)
        Me.email.TabIndex = 3
        '
        'reg_patronal
        '
        Me.reg_patronal.Location = New System.Drawing.Point(619, 47)
        Me.reg_patronal.Name = "reg_patronal"
        Me.reg_patronal.Size = New System.Drawing.Size(135, 20)
        Me.reg_patronal.TabIndex = 4
        '
        'reg_contador
        '
        Me.reg_contador.Location = New System.Drawing.Point(619, 74)
        Me.reg_contador.Name = "reg_contador"
        Me.reg_contador.Size = New System.Drawing.Size(135, 20)
        Me.reg_contador.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1064, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 35)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Crear Empresa"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'nomEmpleado
        '
        Me.nomEmpleado.Location = New System.Drawing.Point(87, 274)
        Me.nomEmpleado.Name = "nomEmpleado"
        Me.nomEmpleado.Size = New System.Drawing.Size(140, 20)
        Me.nomEmpleado.TabIndex = 8
        '
        'listempresas
        '
        Me.listempresas.FormattingEnabled = True
        Me.listempresas.Location = New System.Drawing.Point(546, 274)
        Me.listempresas.Name = "listempresas"
        Me.listempresas.Size = New System.Drawing.Size(99, 160)
        Me.listempresas.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Razon Social"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(275, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Dom fiscal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Email"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(525, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Registro Patronal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(494, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Registro Contribuyentes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(775, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Inicio Op."
        '
        'startDate
        '
        Me.startDate.Location = New System.Drawing.Point(843, 47)
        Me.startDate.Name = "startDate"
        Me.startDate.Size = New System.Drawing.Size(200, 20)
        Me.startDate.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Agregar Empresa"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Agregar Gerente Empresa"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Agregar Departamento"
        '
        'NombreD
        '
        Me.NombreD.Location = New System.Drawing.Point(80, 171)
        Me.NombreD.Name = "NombreD"
        Me.NombreD.Size = New System.Drawing.Size(135, 20)
        Me.NombreD.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 173)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Nombre"
        '
        'BotDept
        '
        Me.BotDept.Location = New System.Drawing.Point(238, 169)
        Me.BotDept.Name = "BotDept"
        Me.BotDept.Size = New System.Drawing.Size(148, 23)
        Me.BotDept.TabIndex = 35
        Me.BotDept.Text = "Crear Departamento"
        Me.BotDept.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(525, 248)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Ver Empresa"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 277)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Nombre"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 311)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Apellido"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 374)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Salario Diario"
        '
        'apeEmpleado
        '
        Me.apeEmpleado.Location = New System.Drawing.Point(87, 308)
        Me.apeEmpleado.Name = "apeEmpleado"
        Me.apeEmpleado.Size = New System.Drawing.Size(145, 20)
        Me.apeEmpleado.TabIndex = 41
        '
        'salarioDiario
        '
        Me.salarioDiario.Location = New System.Drawing.Point(87, 371)
        Me.salarioDiario.Name = "salarioDiario"
        Me.salarioDiario.Size = New System.Drawing.Size(145, 20)
        Me.salarioDiario.TabIndex = 42
        '
        'usergerente
        '
        Me.usergerente.Location = New System.Drawing.Point(87, 402)
        Me.usergerente.Name = "usergerente"
        Me.usergerente.Size = New System.Drawing.Size(145, 20)
        Me.usergerente.TabIndex = 43
        '
        'passGerente
        '
        Me.passGerente.Location = New System.Drawing.Point(82, 432)
        Me.passGerente.Name = "passGerente"
        Me.passGerente.Size = New System.Drawing.Size(145, 20)
        Me.passGerente.TabIndex = 44
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 409)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Usuario"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 439)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 13)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "Contraseña"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(502, 449)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(143, 41)
        Me.Button3.TabIndex = 47
        Me.Button3.Text = "Agregar Empleado"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 342)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 13)
        Me.Label20.TabIndex = 50
        Me.Label20.Text = "CURP"
        '
        'curpbox
        '
        Me.curpbox.Location = New System.Drawing.Point(87, 339)
        Me.curpbox.Name = "curpbox"
        Me.curpbox.Size = New System.Drawing.Size(145, 20)
        Me.curpbox.TabIndex = 51
        '
        'IDempresas
        '
        Me.IDempresas.FormattingEnabled = True
        Me.IDempresas.Location = New System.Drawing.Point(502, 274)
        Me.IDempresas.Name = "IDempresas"
        Me.IDempresas.Size = New System.Drawing.Size(38, 160)
        Me.IDempresas.TabIndex = 54
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 474)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 56
        Me.Label19.Text = "ID EMPRESA"
        '
        'idempresatxt
        '
        Me.idempresatxt.Location = New System.Drawing.Point(87, 471)
        Me.idempresatxt.Name = "idempresatxt"
        Me.idempresatxt.Size = New System.Drawing.Size(145, 20)
        Me.idempresatxt.TabIndex = 55
        '
        'RefreshList
        '
        Me.RefreshList.Location = New System.Drawing.Point(662, 277)
        Me.RefreshList.Name = "RefreshList"
        Me.RefreshList.Size = New System.Drawing.Size(148, 23)
        Me.RefreshList.TabIndex = 57
        Me.RefreshList.Text = "Refrescar"
        Me.RefreshList.UseVisualStyleBackColor = True
        '
        'Check
        '
        Me.Check.Location = New System.Drawing.Point(662, 364)
        Me.Check.Name = "Check"
        Me.Check.Size = New System.Drawing.Size(148, 23)
        Me.Check.TabIndex = 58
        Me.Check.Text = "ccc"
        Me.Check.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Semanal", "Catorcenal", "Quincenal", "Mensual"})
        Me.ComboBox1.Location = New System.Drawing.Point(922, 78)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 59
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(775, 82)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 13)
        Me.Label21.TabIndex = 60
        Me.Label21.Text = "Frecuencia de Pago"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1180, 518)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Check)
        Me.Controls.Add(Me.RefreshList)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.idempresatxt)
        Me.Controls.Add(Me.IDempresas)
        Me.Controls.Add(Me.curpbox)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.passGerente)
        Me.Controls.Add(Me.usergerente)
        Me.Controls.Add(Me.salarioDiario)
        Me.Controls.Add(Me.apeEmpleado)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.BotDept)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.NombreD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.startDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listempresas)
        Me.Controls.Add(Me.nomEmpleado)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.reg_contador)
        Me.Controls.Add(Me.reg_patronal)
        Me.Controls.Add(Me.email)
        Me.Controls.Add(Me.dom_fiscal)
        Me.Controls.Add(Me.raz_social)
        Me.Controls.Add(Me.nombre)
        Me.Name = "Form2"
        Me.Text = "Agregar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nombre As TextBox
    Friend WithEvents raz_social As TextBox
    Friend WithEvents dom_fiscal As TextBox
    Friend WithEvents email As TextBox
    Friend WithEvents reg_patronal As TextBox
    Friend WithEvents reg_contador As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents nomEmpleado As TextBox
    Friend WithEvents listempresas As ListBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents startDate As DateTimePicker
	Friend WithEvents Label8 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents NombreD As TextBox
	Friend WithEvents Label11 As Label
	Friend WithEvents BotDept As Button
	Friend WithEvents Label13 As Label
	Friend WithEvents Label14 As Label
	Friend WithEvents Label15 As Label
	Friend WithEvents Label16 As Label
	Friend WithEvents apeEmpleado As TextBox
	Friend WithEvents salarioDiario As TextBox
	Friend WithEvents usergerente As TextBox
	Friend WithEvents passGerente As TextBox
	Friend WithEvents Label17 As Label
	Friend WithEvents Label18 As Label
	Friend WithEvents Button3 As Button
	Friend WithEvents Label20 As Label
	Friend WithEvents curpbox As TextBox
	Friend WithEvents IDempresas As ListBox
	Friend WithEvents Label19 As Label
	Friend WithEvents idempresatxt As TextBox
	Friend WithEvents RefreshList As Button
	Friend WithEvents Check As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label21 As Label
End Class
