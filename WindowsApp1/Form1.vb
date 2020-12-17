Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim conexion As New EnlaceBD
		Dim conexion2 As New EnlaceBD
		Dim user1 As String
        Dim pass1 As String
		Dim result As Boolean
		Dim gernom As Boolean 'boleano para ver si es gerente nomina
		Dim gerentedepto As Boolean 'boleano para ver si es gerente departamento

		Dim tabla As New DataTable

		user1 = user.Text
		pass1 = pass.Text
        If user1 = "admin" And pass1 = "admin" Then
            Form2.ShowDialog()
        ElseIf user1 = "" Or pass1 = "" Then
            MessageBox.Show("Favor de introducir valores correctos")
        Else

            result = conexion.ValidaUsuario(user1, pass1)
		gernom = conexion2.GerNom(user1, pass1)
		gerentedepto = conexion2.GerDepto(user1, pass1)




            If result = True Then
                    If gernom = True Then
                        formgerente.ShowDialog()
                    Else
                        If gerentedepto = True Then
                            MessageBox.Show("GERENTE DEPARTAMENTO!")
                            gerenteprimerlogin.ShowDialog()
                        Else
                            MessageBox.Show("EMPLEADO NORMAL!")
                            Recibos_de_Nómina.ShowDialog()
                        End If

                    End If

                Else
                    MessageBox.Show("Acceso invalido")
                End If
            End If

    End Sub
End Class
