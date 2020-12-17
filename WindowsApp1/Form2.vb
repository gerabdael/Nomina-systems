Public Class Form2
    'agregar empresa
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable

        Dim result As Boolean = False

        Dim nom As String
        Dim inicio_oper As String
        Dim raz_soc As String
        Dim dom_fis As String
        Dim email1 As String
        Dim reg_pat As String
        Dim reg_cont As String
        Dim Frec_Pago As String



        tabla = obj.Get_empresa()

        nom = nombre.Text
        raz_soc = raz_social.Text
        dom_fis = dom_fiscal.Text
        email1 = email.Text
        reg_pat = reg_patronal.Text
        reg_cont = reg_contador.Text
        inicio_oper = startDate.Value.Date
        Frec_Pago = ComboBox1.SelectedItem
        If nom = "" Or raz_soc = "" Or dom_fis = "" Or email1 = "" Or reg_pat = "" Or reg_cont = "" Or inicio_oper = "" Or Frec_Pago = "" Then
            MessageBox.Show("favor de llenar los datos")
        Else
            result = obj.AgregaEmpresa("I", inicio_oper, nom, raz_soc, dom_fis, email1, reg_pat, reg_cont, Frec_Pago)

        End If
        Dim tabla2 As New DataTable
        tabla2 = obj.Get_empresa()
        If result Then
            MessageBox.Show("La empresa " + nom + " a sido creada")
            nombre.Clear()
            raz_social.Clear()
            dom_fiscal.Clear()
            email.Clear()
            reg_patronal.Clear()
            reg_contador.Clear()
        End If
        listempresas.DataSource = tabla2
            listempresas.DisplayMember = "Nombre Empresa"
            listempresas.ValueMember = "Clave"

            IDempresas.DataSource = tabla2
        IDempresas.DisplayMember = "Clave"
        IDempresas.ValueMember = "Clave"






    End Sub

    'agregar Departamento Forma Global
    Private Sub BotDept_Click(sender As Object, e As EventArgs) Handles BotDept.Click
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable
        Dim result2 As Boolean = False

        tabla = obj.Get_Departamento()


        Dim nom As String



		nom = NombreD.Text


        If nom = "" Then
            MessageBox.Show("Favor de llenar todos los campos")

        Else
            result2 = obj.AgregaDepto("I", nom)
            If result2 Then
                MessageBox.Show("Departamento " + nom + " a sido creado globalmente")
                NombreD.Clear()
            End If
        End If


    End Sub
    'mostrar empresas ascendente
    Private Sub Form2_Load(sender2 As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable
        tabla = obj.Get_empresa()

        listempresas.DataSource = tabla
        listempresas.DisplayMember = "Nombre Empresa"
        listempresas.ValueMember = "Clave"


        IDempresas.DataSource = tabla
        IDempresas.DisplayMember = "Clave"
        IDempresas.ValueMember = "Clave"


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim obj As New EnlaceBD
        Dim obj2 As New EnlaceBD
        Dim tabla As New DataTable
        Dim tabla2 As New DataTable


        Dim result As Boolean = False
        Dim nomEmp As String
        Dim apeEmp As String
        Dim curp As String
        Dim empresa As String
        Dim Nompuesto As String
        Dim salariod As String
        Dim usuario As String
        Dim contraseña As String

        nomEmp = nomEmpleado.Text
        apeEmp = apeEmpleado.Text
        curp = curpbox.Text
        Nompuesto = "gerente nomina"
        salariod = salarioDiario.Text
        empresa = idempresatxt.Text
        contraseña = usergerente.Text
        usuario = passGerente.Text



        If nomEmp = "" Or apeEmp = "" Or curp = "" Or Nompuesto = "" Or salariod = "" Or empresa = "" Or contraseña = "" Or usuario = "" Then
            MessageBox.Show("Favor de llenar todos los campos")
        Else
            tabla2 = obj.Get_EmpresaEspecifico(empresa)
            If tabla2.Rows IsNot Nothing AndAlso tabla.Rows.Count >= 0 Then

                tabla = obj.Get_EmpleadoNomina(empresa)
                If tabla.Rows IsNot Nothing AndAlso tabla.Rows.Count >= 0 Then
                    result = obj.AgregaGerente("I", empresa, salariod, Nompuesto, nomEmp, apeEmp, usuario, contraseña, curp)
                    MessageBox.Show("Gerente  " + nomEmp + " creado Para la empresa ")
                    nomEmpleado.Clear()
                    apeEmpleado.Clear()
                    curpbox.Clear()
                    salarioDiario.Clear()
                    idempresatxt.Clear()
                    usergerente.Clear()
                    passGerente.Clear()

                Else
                    MessageBox.Show("ya existe un gerente para esa empresa  ")

                End If
            Else
                MessageBox.Show("esa empresa no existe ")
            End If
        End If


    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click


    End Sub

    Private Sub salarioDiario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles salarioDiario.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Check_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Check.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Form2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim obj As New EnlaceBD
        Dim tabla As New DataTable
        tabla = obj.Get_empresa()
        If Asc(e.KeyChar) = "F5" Then

            MessageBox.Show("simon")
        End If
    End Sub

    Private Sub salarioDiario_TextChanged(sender As Object, e As EventArgs) Handles salarioDiario.TextChanged

    End Sub

    Private Sub salarioDiario_KeyDown(sender As Object, e As KeyEventArgs) Handles salarioDiario.KeyDown

    End Sub
End Class


