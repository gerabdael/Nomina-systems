Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable
        Dim obj As New EnlaceBD


        Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)

        table = obj.vistaincidencia(inti)

        ListBox1.DataSource = table
        ListBox1.DisplayMember = "Idempleado"
        ListBox1.ValueMember = "Idempleado"


        ListBox2.DataSource = table
        ListBox2.DisplayMember = "Nombre"
        ListBox2.ValueMember = "Idempleado"

        ListBox3.DataSource = table
        ListBox3.DisplayMember = "nombrep"
        ListBox3.ValueMember = "Idempleado"

        ListBox4.DataSource = table
        ListBox4.DisplayMember = "salario"
        ListBox4.ValueMember = "Idempleado"



        Dim tabla2 As New DataTable



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim salariodiario As Decimal = TextBox2.Text
        Dim dias As Integer = TextBox3.Text
        Dim monto As Decimal = TextBox6.Text
        Dim total As Decimal = (salariodiario * dias) * monto

        Dim obj As New EnlaceBD

        Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)

        TextBox4.Text = total
        Dim Nombre As String = TextBox7.Text
        Dim Fecha As Date = DateTimePicker1.Value.Date
        Dim Identificador As String = TextBox5.Text
        Dim general As Boolean = False


        Dim result As Boolean
            result = obj.AgregarIncidencia1Empleado(Nombre, monto, dias, total, Identificador, Fecha, general, inti, TextBox1.Text)
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox5.Clear()


            MessageBox.Show("INCIDENCIA CREADA")


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox5.Clear()
        TextBox5.Text = "Percepcion"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox5.Clear()

        TextBox5.Text = "Deduccion"
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class