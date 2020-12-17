Public Class Percepciones

	Private Sub Percepciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim tablax As New DataTable
		Dim obj As New EnlaceBD

		'da el usuario y contra para poder llenar la tabla pero no son visibles
		Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)

		tablax = obj.Ver_Empispp(inti)
		ListBox1.DataSource = tablax
		ListBox1.DisplayMember = "Nombre_Empleado"
		ListBox1.ValueMember = "idemp"


        TextBox1.Text = obj.GetIdEmpleado(Form1.user.Text, Form1.pass.Text)
        ListBox2.DataSource = tablax
        ListBox2.DisplayMember = "idemp"
        ListBox2.ValueMember = "idemp"
        TextBox13.Text = tablax.Rows(0).Item("frecuencia")

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim tablax As New DataTable
		Dim tablax2 As New DataTable
		Dim obj As New EnlaceBD

		Dim IDEmpleado As Integer = TextBox1.Text
		Dim Frecuencia As String = TextBox13.Text
		Dim IdEmpresa As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
		Dim fechainicial As String = DateTimePicker1.Value.Date.ToString("yyyy-MM-dd")
		Dim fechafinal As String = DateTimePicker2.Value.Date.ToString("yyyy-MM-dd")
		Dim fechanomina As Date = DateTimePicker3.Value.Date

		tablax2 = obj.FirstTable(IDEmpleado, IdEmpresa, Frecuencia, fechainicial, fechafinal)

		TextBox2.Clear()
		TextBox3.Clear()
		TextBox4.Clear()
		TextBox5.Clear()
		TextBox6.Clear()
		TextBox7.Clear()
		TextBox8.Clear()
		TextBox9.Clear()
		TextBox10.Clear()
		TextBox11.Clear()
		TextBox12.Clear()
		TextBox14.Clear()
		TextBox15.Clear()

		TextBox2.Text = tablax2.Rows(0).Item("Nombre_Completo")
		TextBox3.Text = tablax2.Rows(0).Item("Banco")
		TextBox4.Text = tablax2.Rows(0).Item("No.Cuenta")
		TextBox5.Text = tablax2.Rows(0).Item("No_Seguro_Social")
		TextBox6.Text = tablax2.Rows(0).Item("RFC")
		TextBox7.Text = tablax2.Rows(0).Item("CURP")
		TextBox8.Text = tablax2.Rows(0).Item("Puesto")
		TextBox9.Text = tablax2.Rows(0).Item("salario_diario")
		TextBox10.Text = tablax2.Rows(0).Item("total_percepciones")
		TextBox11.Text = tablax2.Rows(0).Item("total_Deducciones")
        Dim aa As Decimal = tablax2.Rows(0).Item("total_percepciones")
        Dim ded As Decimal = tablax2.Rows(0).Item("total_Deducciones")
        Dim incidencias As Decimal = aa - ded
        ''TextBox12.Text = tablax2.Rows(0).Item("Total_INcidencias") 'quitar'
        TextBox12.Text = incidencias
        TextBox14.Text = tablax2.Rows(0).Item("total_cuatorsena")
        Dim salariobruto As Decimal = tablax2.Rows(0).Item("total_cuatorsena")
        ''TextBox15.Text = tablax2.Rows(0).Item("TOTAL NOMINA")
        Dim salariototal As Decimal = salariobruto + aa - ded
        TextBox15.Text = salariototal

        tablax = obj.SecondTable(IDEmpleado, IdEmpresa, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox6.Text, TextBox8.Text, TextBox9.Text, TextBox10.Text,
TextBox11.Text, TextBox12.Text, TextBox14.Text, TextBox15.Text, fechanomina, TextBox7.Text, TextBox5.Text)



		MessageBox.Show("agregado")
	End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class