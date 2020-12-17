Public Class formgerente

	'mostrar info predeterminada
	Private Sub formgerente_Load(sender2 As Object, e As EventArgs) Handles MyBase.Load
		Dim tablax As New DataTable
		Dim obj As New EnlaceBD

		'da el usuario y contra para poder llenar la tabla pero no son visibles
		User.Text = Form1.user.Text
		Pass.Text = Form1.pass.Text

		tablax = obj.Get_loged(User.Text, Pass.Text)

		Usuario.DataSource = tablax

		Usuario.DisplayMember = "fullname"

	End Sub


	Private Sub button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		FormGestionarEmpresa.ShowDialog()


	End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.ShowDialog()
    End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Puestos.ShowDialog()
	End Sub

	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Empleados.ShowDialog()
	End Sub

	Private Sub User_TextChanged(sender As Object, e As EventArgs) Handles User.TextChanged

    End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Form6.Show()
	End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Percepciones.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Incidencia.Show()
    End Sub

    Private Sub Usuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Usuario.SelectedIndexChanged

    End Sub
End Class