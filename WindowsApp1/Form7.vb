Public Class Form7
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		TextBox1.Clear()
		TextBox1.Text = "Percepcion"
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		TextBox1.Clear()

		TextBox1.Text = "Deduccion"
	End Sub

	Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		TextBox6.Text = gerenteprimerlogin.TextBox5.Text
		TextBox4.Text = gerenteprimerlogin.TextBox1.Text
		TextBox5.Text = gerenteprimerlogin.TextBox2.Text
		TextBox3.Text = gerenteprimerlogin.TextBox3.Text

		Dim obj As New EnlaceBD
		Dim tabla As New DataTable
		tabla = obj.getiddelempleadoespecificdepto(TextBox6.Text, TextBox4.Text)

		TextBox7.Text = tabla.Rows(0).Item("numeemp")


	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

		Dim obj As New EnlaceBD
		Dim valor As Decimal = TextBox9.Text
		Dim Dias As Decimal = TextBox8.Text
		Dim total As Decimal = valor * Dias

		Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)

		TextBox4.Text = total
		Dim Nombre As String = TextBox10.Text
		Dim Fecha As Date = DateTimePicker1.Value.Date
		Dim Identificador As String = TextBox1.Text
		Dim general As Boolean = False

        Dim result As Boolean

        result = obj.AgregarIncidencia1Empleado(Nombre, valor, Dias, total, Identificador, Fecha, general, inti, TextBox7.Text)
            MessageBox.Show("INCIDENCIA CREADA")
        Me.Close()
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

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class