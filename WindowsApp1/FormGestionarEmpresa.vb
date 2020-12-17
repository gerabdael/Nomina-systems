Public Class FormGestionarEmpresa
	'mostrar info predeterminada
	Private Sub formgerente_Load(sender2 As Object, e As EventArgs) Handles MyBase.Load
		Dim tablax As New DataTable
		Dim tablax2 As New DataTable
		Dim obj As New EnlaceBD
		Dim empid As Integer

		'da el usuario y contra para poder llenar la tabla pero no son visibles
		TextBox7.Text = Form1.user.Text
		TextBox8.Text = Form1.pass.Text

		empid = obj.getIdEmpresaNow(TextBox7.Text, TextBox8.Text)

		TextBox9.Text = empid.ToString()

		tablax = obj.Get_EmpresaEspecifico(TextBox9.Text)

		TextBox1.Text = tablax.Rows(0)("name").ToString
		TextBox2.Text = tablax.Rows(0)("razonsoc").ToString
		TextBox3.Text = tablax.Rows(0)("domfis").ToString
		TextBox4.Text = tablax.Rows(0)("email").ToString
		TextBox5.Text = tablax.Rows(0)("regispat").ToString
		TextBox6.Text = tablax.Rows(0)("regiscont").ToString
		DateTimePicker1.Text = tablax.Rows(0)("inicop").ToString
		ComboBox1.Text = tablax.Rows(0)("frecuencia").ToString

		tablax = obj.Get_Departamento

		ListBox1.DataSource = tablax
		ListBox1.DisplayMember = "Nombre Departamento"
		ListBox1.ValueMember = "Clave"

        ListBox4.DataSource = tablax
        ListBox4.DisplayMember = "Clave"
        ListBox4.ValueMember = "Clave"

        tablax2 = obj.GetDeptosFromEmpresa(TextBox9.Text)
		ListBox2.DataSource = tablax2
		ListBox2.DisplayMember = "nombreDepto"

		ListBox3.DataSource = tablax2
		ListBox3.DisplayMember = "salario"

		TextBox10.Clear()
	End Sub
	'modificar empresa
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim obj As New EnlaceBD
		Dim tabla As New DataTable
		Dim tablax As New DataTable

		Dim result As Boolean = False

		Dim id_empres As Integer
		Dim nom As String
		Dim inicio_oper As Date
		Dim raz_soc As String
		Dim dom_fis As String
		Dim email1 As String
		Dim reg_pat As String
		Dim reg_cont As String
		Dim Frec_Pago As String



		tabla = obj.Get_empresa()

		nom = TextBox1.Text
		raz_soc = TextBox2.Text
		dom_fis = TextBox3.Text
		email1 = TextBox4.Text
		reg_pat = TextBox5.Text
		reg_cont = TextBox6.Text
        inicio_oper = DateTimePicker1.Value.Date
        id_empres = TextBox9.Text
		Frec_Pago = ComboBox1.SelectedItem

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or
                TextBox9.Text = "" Then
            MessageBox.Show("Favor llenar todos los campos correctamente")
        Else

            result = obj.ModEmpresa(id_empres, inicio_oper, nom, raz_soc, dom_fis, email1, reg_pat, reg_cont, Frec_Pago)
            Dim tabla2 As New DataTable
            tabla2 = obj.Get_Departamento()





            If result Then
                MessageBox.Show("La empresa " + nom + " a sido modificada")

                ListBox1.DataSource = tabla2
                ListBox1.DisplayMember = "Nombre Departamento"
                ListBox1.ValueMember = "Clave"


                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()

                tablax = obj.Get_EmpresaEspecifico(TextBox9.Text)

                TextBox1.Text = tablax.Rows(0)("name").ToString
                TextBox2.Text = tablax.Rows(0)("razonsoc").ToString
                TextBox3.Text = tablax.Rows(0)("domfis").ToString
                TextBox4.Text = tablax.Rows(0)("email").ToString
                TextBox5.Text = tablax.Rows(0)("regispat").ToString
                TextBox6.Text = tablax.Rows(0)("regiscont").ToString
                DateTimePicker1.Text = tablax.Rows(0)("inicop").ToString
            End If
        End If
    End Sub

	'poner un departamento en empresa
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim obj As New EnlaceBD
		Dim tablax2 As New DataTable
		Dim id_empres As Integer
		Dim id_depto As Integer
        Dim SueldoBase As Decimal
        Dim result2 As Boolean = False
		Dim result3 As Boolean = False
		Dim result1 As Boolean = False
		Dim aex As String
		aex = ListBox1.GetItemText(ListBox1.SelectedItem)

		If TextBox10.Text IsNot "" Then
			result2 = True
		End If

		If result2 = True Then
			id_empres = TextBox9.Text
			id_depto = obj.GetIdDeptoSelected(aex)
			SueldoBase = TextBox10.Text


			result3 = obj.CheckTheDepto4Empresa(id_empres, id_depto)
			If result3 = True Then
				MessageBox.Show("Ya tiene ese departamento")
			Else
				result1 = obj.Add_Departamento_toEmpresa(id_empres, id_depto, SueldoBase)
				If result1 = True Then
					MessageBox.Show("Se agrego departamento " + aex + " a la empresa")
				End If

				TextBox10.Clear()

				tablax2 = obj.GetDeptosFromEmpresa(TextBox9.Text)
				ListBox2.DataSource = tablax2
				ListBox2.DisplayMember = "nombreDepto"

				ListBox3.DataSource = tablax2
				ListBox3.DisplayMember = "salario"
			End If



		Else
			MessageBox.Show("Por favor asigne  salario base")
		End If
	End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim result As Boolean
        Dim result2 As Boolean
        Dim result3 As Boolean
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable
        Dim IdEmpresa = TextBox9.Text
        Dim depto As String = TextBox11.Text
        Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
        TextBox12.Text = inti

        If depto = "" Or IdEmpresa = "" Then
            MessageBox.Show("Favor de capturar un id valido")

        Else
            result = obj.deletedepartamentos("D", inti, depto)




            If result Then
                result3 = obj.deleteempleados(inti, depto)
                If result3 Then
                    result2 = obj.deletepuestos(inti, depto)
                    If result2 Then
                        MessageBox.Show("Se elimino depto")
                    Else
                        MessageBox.Show("no informacion")
                    End If
                Else
                    MessageBox.Show("no informacion")
                End If

            Else
                MessageBox.Show("no informacion")
            End If
        End If
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class
