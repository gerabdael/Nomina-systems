Public Class ModEmpleado

	Private Sub Empleados_Load(sender2 As Object, e As EventArgs) Handles MyBase.Load
		Dim tablax As New DataTable
		Dim obj As New EnlaceBD



		TextBox21.Text = Empleados.TextBox3.Text
		TextBox8.Text = Empleados.TextBox4.Text

		tablax = obj.AllInfoBaby(TextBox21.Text, TextBox8.Text)
		TextBox27.Text = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)

		TextBox22.Text = tablax.Rows(0).Item("idpuesto").ToString()
		TextBox7.Text = tablax.Rows(0).Item("iddepto").ToString()
		TextBox23.Text = tablax.Rows(0).Item("idpersona").ToString()
		TextBox11.Text = tablax.Rows(0).Item("iddom").ToString()
		TextBox24.Text = tablax.Rows(0).Item("numE").ToString()

		TextBox1.Text = tablax.Rows(0).Item("namep").ToString()
		TextBox2.Text = tablax.Rows(0).Item("apellido").ToString()
		TextBox3.Text = tablax.Rows(0).Item("Usero").ToString()
		TextBox4.Text = tablax.Rows(0).Item("pass").ToString()
		TextBox6.Text = tablax.Rows(0).Item("curp").ToString()
		TextBox9.Text = tablax.Rows(0).Item("nns").ToString()
		TextBox10.Text = tablax.Rows(0).Item("rfc").ToString()
		TextBox19.Text = tablax.Rows(0).Item("municipio").ToString()
		TextBox5.Text = tablax.Rows(0).Item("estado").ToString()
		TextBox12.Text = tablax.Rows(0).Item("numer").ToString()
		TextBox20.Text = tablax.Rows(0).Item("calle").ToString()
		TextBox13.Text = tablax.Rows(0).Item("col").ToString()
		TextBox18.Text = tablax.Rows(0).Item("tel").ToString()
		TextBox15.Text = tablax.Rows(0).Item("bank").ToString()
		TextBox16.Text = tablax.Rows(0).Item("acc").ToString()
		TextBox17.Text = tablax.Rows(0).Item("mail").ToString()
		TextBox14.Text = tablax.Rows(0).Item("cp").ToString()

		If TextBox11.Text = "" Then
			TextBox11.Text = "0"
		End If

		If TextBox7.Text = "" Then
			TextBox7.Text = "0"
		End If

		Dim tabla As New DataTable
		Dim tabla2 As New DataTable
		tabla = obj.Get_Departamento()
		ComboBox1.DataSource = tabla
		ComboBox1.DisplayMember = "Nombre Departamento"
		ComboBox1.ValueMember = "Clave"

		Dim condition As Integer
		Dim empresa As String

		condition = ComboBox1.SelectedItem("Clave")
		empresa = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
		tabla = obj.refresh(condition, empresa)
		ComboBox2.DataSource = tabla
		ComboBox2.DisplayMember = "Nombre"
		ComboBox2.ValueMember = "id"

		startDate.Value = tablax.Rows(0).Item("FecI")

		Dim auxdate As Date = CDate("1900-09-12")
		If tablax.Rows(0).Item("fnac").ToString() IsNot "" Then
			DateTimePicker1.Value = tablax.Rows(0).Item("fnac")
		End If
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim tablax As New DataTable
		Dim obj As New EnlaceBD
		Dim result As Boolean = False

		Dim inti As Integer = obj.GetIdEmpleado(TextBox21.Text, TextBox8.Text)
		'persona
		Dim nombre As String = TextBox1.Text
		Dim apellido As String = TextBox2.Text
		Dim curp As String = TextBox6.Text
		Dim rfc As String = TextBox10.Text
		'empleado
		Dim usuario As String = TextBox3.Text
		Dim contraseña As String = TextBox4.Text
		Dim telefono As String = TextBox18.Text
		Dim banco As String = TextBox15.Text
		Dim numerocuenta As String = TextBox16.Text
		Dim numerosocial As Integer = TextBox9.Text
		Dim mail As String = TextBox17.Text
		Dim fechaingreso As Date = startDate.Value.Date
		Dim fechanacimiento As Date = DateTimePicker1.Value.Date
		'Domicilio
		Dim calle As String = TextBox20.Text
		Dim estado As String = TextBox5.Text
		Dim municipio As String = TextBox19.Text
		Dim numerocalle As String = TextBox12.Text
		Dim codpos As String = TextBox14.Text
		Dim colonia As String = TextBox13.Text
		Dim intaexdom As Integer = TextBox11.Text
		'puesto y depto
		Dim newpuesto As Integer = TextBox25.Text
		Dim newdepto As Integer = TextBox26.Text

        result = obj.ModEmpleado(nombre, apellido, usuario, contraseña, inti, TextBox23.Text, curp, numerosocial, rfc, telefono, banco, numerocuenta, mail,
fechaingreso, fechanacimiento, calle, estado, municipio, numerocalle, colonia, codpos, intaexdom, newpuesto, newdepto)

        If result Then
            MessageBox.Show("Empleado Modificado y Recontratado!")
            Me.Close()

        End If
    End Sub

	Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
		Dim obj As New EnlaceBD
		Dim tabla As New DataTable
		Dim condition As Integer
		Dim empresa As String

		condition = ComboBox1.SelectedItem("Clave")
		empresa = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
		tabla = obj.refresh(condition, empresa)
		ComboBox2.DataSource = tabla
		ComboBox2.DisplayMember = "Nombre"
		ComboBox2.ValueMember = "id"

		If tabla.Rows.Count > 0 Then
			TextBox26.Text = tabla.Rows(0).Item("iddepto").ToString()
		Else
			TextBox26.Text = "0"
		End If

		If tabla.Rows.Count > 0 Then
			TextBox25.Text = tabla.Rows(0).Item("id").ToString()
		Else
			TextBox25.Text = "0"
		End If

	End Sub

	Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
		Dim obj As New EnlaceBD
		Dim tabla As New DataTable
		Dim condition As Integer
		Dim empresa As String

		If TextBox26.Text.ToString() = "" Then
			condition = 1
		Else

			condition = TextBox26.Text.ToString()
		End If
		empresa = TextBox27.Text


		Dim namepuesto As String = TextBox28.Text

		tabla = obj.refreshidpuesto(condition, empresa, namepuesto)



		If tabla.Rows.Count > 0 Then
			TextBox25.Text = tabla.Rows(0).Item("id").ToString()
		Else
			TextBox25.Text = "0"
		End If

	End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
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

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged

    End Sub

    Private Sub TextBox18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox18.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged

    End Sub

    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox16.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class