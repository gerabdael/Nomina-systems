Public Class Incidencia
	Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
		TextBox5.Clear()




	End Sub

	Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		TextBox5.Clear()
		TextBox5.Text = "Percepcion"
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		TextBox5.Clear()

		TextBox5.Text = "Deduccion"
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Dim obj As New EnlaceBD
		Dim valor As Decimal = TextBox2.Text
		Dim Dias As Decimal = TextBox3.Text
		Dim total As Decimal = valor * Dias

		Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)

		TextBox4.Text = total
		Dim Nombre As String = TextBox1.Text
		Dim Fecha As Date = DateTimePicker1.Value.Date
		Dim Identificador As String = TextBox5.Text
		Dim general As Boolean = True

        Dim result As Boolean
            result = obj.AgregarIncidenciaGeneral(Nombre, valor, Dias, total, Identificador, Fecha, general, inti)


        MessageBox.Show("INCIDENCIA CREADA")
    End Sub

	Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

	End Sub

	Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

	End Sub

	Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

	End Sub

	Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

	End Sub

	Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

	End Sub

	Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

	End Sub

	Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

	End Sub

	Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

	End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form8.ShowDialog()

    End Sub

    Private Sub Incidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class