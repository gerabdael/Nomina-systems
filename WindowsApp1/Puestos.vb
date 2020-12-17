Public Class Puestos
    Private Sub Puestos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable
        Dim tabla2 As New DataTable

        Dim result As Boolean = False
        tabla = obj.Get_Departamento()

        ComboBox1.DataSource = tabla
        ComboBox1.DisplayMember = "Nombre Departamento"
        ComboBox1.ValueMember = "Clave"

        Dim condition As Integer
        Dim empresa As String

        condition = ComboBox1.SelectedItem("Clave")
        empresa = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
        tabla = obj.refresh(condition, empresa)
        ListBox1.DataSource = tabla
        ListBox1.DisplayMember = "Nombre"
        ListBox1.ValueMember = "id"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable
        Dim result As Boolean

        Dim Departamento As String
        Dim NomPuestos As String
        Dim Nivel_Salarial As Decimal
        Dim empresa As String

        NomPuestos = TextBox1.Text
        Nivel_Salarial = TextBox2.Text

        Departamento = ComboBox1.GetItemText(ComboBox1.SelectedItem("Clave"))
        empresa = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
        result = obj.Add_Puesto("I", NomPuestos, Nivel_Salarial, empresa, Departamento)


        If result Then
            MessageBox.Show("Puesto agregado")
        Else
            MessageBox.Show("Error")
        End If
        TextBox1.Clear()
        TextBox2.Clear()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable
        Dim condition As Integer
        Dim empresa As String

        condition = ComboBox1.SelectedItem("Clave")
        empresa = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
        tabla = obj.refresh(condition, empresa)
        ListBox1.DataSource = tabla
        ListBox1.DisplayMember = "Nombre"
        ListBox1.ValueMember = "id"



    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class

