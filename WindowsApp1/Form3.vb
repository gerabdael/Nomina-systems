Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ComboBox2.DataSource = tabla
        ComboBox2.DisplayMember = "Nombre"
        ComboBox2.ValueMember = "id"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable

        Dim result As Boolean

        Dim nomEmp As String
        Dim apeEmp As String
        Dim curp As String
        Dim empresa As Integer
        Dim Dpto As Integer
        Dim usuario As String
        Dim contraseña As String
        Dim Cod_Pos As String
        Dim calle As String
        Dim numero As String
        Dim Colonia As String
        Dim Mun As String
        Dim Estado As String
        Dim Fecha_Nac As Date
        Dim NNS As String
        Dim RFC As String
		Dim Banco As String
        Dim NoCuenta As String
        Dim Telefono As String
        Dim Fecha_Ingreso As Date
        Dim Mail As String
        Dim puesto As Integer

        nomEmp = TextBox1.Text
        apeEmp = TextBox2.Text
        usuario = TextBox3.Text
        contraseña = TextBox4.Text
        curp = TextBox6.Text

        Dpto = ComboBox1.GetItemText(ComboBox1.SelectedItem("Clave"))
        empresa = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
        puesto = ComboBox2.GetItemText(ComboBox2.SelectedItem("id"))

        Estado = TextBox5.Text

        Cod_Pos = TextBox14.Text
        calle = TextBox20.Text
        numero = TextBox12.Text
        Colonia = TextBox13.Text
        Mun = TextBox19.Text

        Fecha_Nac = startDate.Value.Date
        NNS = TextBox9.Text
        RFC = TextBox10.Text
        Banco = TextBox15.Text
        NoCuenta = TextBox16.Text
        Telefono = TextBox18.Text
        Fecha_Ingreso = DateTimePicker1.Value.Date
        Mail = TextBox17.Text
        If nomEmp = "" Or apeEmp = "" Or usuario = "" Or contraseña = "" Or curp = "" Or Estado = "" Or Cod_Pos = "" Or calle = "" Or numero = "" Or
         Colonia = "" Or Mun = "" Or NNS = "" Or RFC = "" Or Banco = "" Or NoCuenta = "" Or Telefono = "" Or Mail = "" Then
            MessageBox.Show("Favor de llenar todos los campos")
        Else
            result = obj.RegistrarEmpleado("I", empresa, nomEmp, apeEmp, usuario, contraseña, curp, Cod_Pos, calle, numero, Colonia,
        Mun, Estado, Fecha_Nac, NNS, RFC, Banco, NoCuenta, Telefono, Fecha_Ingreso, Mail, Dpto, puesto)

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox20.Clear()

        If result Then
            MessageBox.Show("Usuario registrado")
        Else
            MessageBox.Show("Llene todos los parametros")
        End If
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