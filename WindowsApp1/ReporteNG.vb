Public Class Form6
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tablax As New DataTable
        Dim Filtro As Date
        Dim obj As New EnlaceBD
        'da el usuario y contra para poder llenar la tabla pero no son visibles
        Dim empresa As String
        Dim init As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
        empresa = ComboBox2.GetItemText(ComboBox2.SelectedItem("Nombre Empresa"))
        Filtro = DateTimePicker1.Value.Date
        tablax = obj.Get_vista(init)

        DataGridView1.DataSource = tablax
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim obj As New EnlaceBD
        tabla = obj.Get_empresa()

        ComboBox2.DataSource = tabla
        ComboBox2.DisplayMember = "Nombre Departamento"
        ComboBox2.ValueMember = "Clave"
    End Sub
End Class