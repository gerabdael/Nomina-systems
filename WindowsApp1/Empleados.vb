Public Class Empleados

	Private Sub Empleados_Load(sender2 As Object, e As EventArgs) Handles MyBase.Load
		Dim tablax As New DataTable
		Dim tablax2 As New DataTable
		Dim obj As New EnlaceBD
		Dim inti As Integer
		'da el usuario y contra para poder llenar la tabla pero no son visibles
		TextBox1.Text = Form1.user.Text
		TextBox2.Text = Form1.pass.Text

		tablax = obj.Get_Empri(TextBox1.Text, TextBox2.Text)

		ListBox1.DataSource = tablax

		ListBox1.DisplayMember = "nombre"

		inti = obj.getIdEmpresaNow(TextBox1.Text, TextBox2.Text)

		tablax2 = obj.Ver_Empis(inti)

		DataGridView1.DataSource = tablax2


	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		ModEmpleado.ShowDialog()
	End Sub

	'modificar
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim datarow As DataGridViewRow
		Dim obj As New EnlaceBD

		obj.DespedirEmpleado(TextBox3.Text, TextBox4.Text)

		MessageBox.Show("Empleado Despedido!")
	End Sub

	Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
		Dim datarow As DataGridViewRow
		Dim obj As New EnlaceBD
		datarow = DataGridView1.Rows(e.RowIndex)

		TextBox3.Text = datarow.Cells(4).Value
		TextBox4.Text = datarow.Cells(5).Value
	End Sub

	Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

	End Sub
End Class