Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class EnlaceBD
    Private aux As String
    Private conexion As SqlConnection
	'Private conexionNomina As SqlConnection
	Private tabla As DataTable = New DataTable
	Private adaptador As SqlDataAdapter = New SqlDataAdapter
    Private comandosql As SqlCommand = New SqlCommand

    Private Sub conectar()
        'Dim DBConnection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("SQL").ConnectionString)        
        conexion = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("desarrollo").ConnectionString)
    End Sub

    Private Sub desconectar()
        conexion.Close()
    End Sub

    Public ReadOnly Property obtenertabla() As DataTable
        Get
            Return tabla
        End Get
    End Property
    'agregar empresa
    Public Function AgregaEmpresa(ByVal Opc As String, ByVal inicio_oper As Date, ByVal nomb_emp As String, ByVal raz_soc As String,
                                     ByVal dom_fis As String, ByVal email As String, ByVal reg_pat As String,
                                  ByVal reg_cont As String, Frec_Pago As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_empresa", conexion)
            comandosql.CommandType = CommandType.StoredProcedure


            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Inicio_Operaciones", SqlDbType.Date, 15)
            parametro1.Value = inicio_oper
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20)
            parametro2.Value = nomb_emp
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Razón_social", SqlDbType.VarChar, 20)
            parametro3.Value = raz_soc
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Dominio_Fiscal", SqlDbType.VarChar, 20)
            parametro4.Value = dom_fis
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Email", SqlDbType.VarChar, 20)
            parametro5.Value = email
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Registro_Patronal", SqlDbType.VarChar, 20)
            parametro6.Value = reg_pat
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@Registro_cont", SqlDbType.VarChar, 20)
            parametro7.Value = reg_cont
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro8.Value = Opc
            Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@frecuencia_pago", SqlDbType.VarChar, 40)
            parametro9.Value = Frec_Pago

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    'obtener empresa
    Public Function Get_empresa() As DataTable
        Dim Qry As String
        Dim data As New DataTable

        Try

            conectar()

            Qry = "sp_empresa"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = "S"


            adaptador.SelectCommand = comandosql
            adaptador.Fill(data)

        Catch ex As SqlException

        Finally
            desconectar()
        End Try
        Return data

    End Function
    Public Function Del_empresa() As DataTable
        Dim Qry As String
        Dim data As New DataTable

        Try

            conectar()

            Qry = "sp_empresa"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = "D"


            adaptador.SelectCommand = comandosql
            adaptador.Fill(data)

        Catch ex As SqlException

        Finally
            desconectar()
        End Try
        Return data

    End Function
	'agregar departamento forma global
	Public Function AgregaDepto(ByVal Opc As String, ByVal nombre As String) As Boolean
		Dim estado2 As Boolean = True
		Try
			conectar()
			comandosql = New SqlCommand("sp_Departamento", conexion)
			comandosql.CommandType = CommandType.StoredProcedure


			Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@NombreDepto", SqlDbType.VarChar, 15)
			parametro1.Value = nombre
			Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
			parametro3.Value = Opc

			conexion.Open()
			adaptador.InsertCommand = comandosql
			comandosql.ExecuteNonQuery()

		Catch ex As SqlException
			estado2 = False
		Finally
			desconectar()
		End Try
		Return estado2
	End Function
	'obtener departamento
	Public Function Get_Departamento() As DataTable
		Dim Qry As String
		Dim data As New DataTable

		Try

			conectar()

			Qry = "sp_Departamento"
			comandosql = New SqlCommand(Qry, conexion)
			comandosql.CommandType = CommandType.StoredProcedure

			Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
			parametro1.Value = "S"


			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)

		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function
	'obtener puesto
	Public Function Get_Puesto() As DataTable
		Dim Qry As String
		Dim data As New DataTable

		Try

			conectar()

			Qry = "sp_PuestoGerente"
			comandosql = New SqlCommand(Qry, conexion)
			comandosql.CommandType = CommandType.StoredProcedure

			Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
			parametro1.Value = "S"


			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)

		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function

	Public Function Get_EmpleadoNomina(ByVal idempresa As Integer) As DataTable
		Dim Qry As String
		Dim data As New DataTable

		Try

			conectar()

			Qry = "sp_Empleados"
			comandosql = New SqlCommand(Qry, conexion)
			comandosql.CommandType = CommandType.StoredProcedure

			Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
			parametro1.Value = "A"

			Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@id", SqlDbType.Int, 20)
			parametro6.Value = idempresa


			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)

		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function

	Public Function Get_EmpresaEspecifico(ByVal idempresa As Integer) As DataTable
		Dim Qry As String
		Dim data As New DataTable

		Try


			conectar()

			Qry = "sp_Empleados"
			comandosql = New SqlCommand(Qry, conexion)
			comandosql.CommandType = CommandType.StoredProcedure

			Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
			parametro1.Value = "B"

			Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@id", SqlDbType.Int)
			parametro6.Value = idempresa


			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)

		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function
	'Obtener id del departamento seleccionado
	Public Function GetIdDeptoSelected(ByVal name As String) As Integer
		Dim data As New DataTable
		Dim aux As Integer
		conectar()
		comandosql = New SqlCommand("sp_Departamento", conexion)
		comandosql.CommandType = CommandType.StoredProcedure

		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@NombreDepto", SqlDbType.VarChar, 20)
		parametro3.Value = name
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
		parametro4.Value = "U"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		If data.Rows IsNot Nothing AndAlso data.Rows.Count > 0 Then
			aux = data.Rows(0).Item("iddepto")

		End If


		Return aux
	End Function
	Public Function getdeptofromgerente(ByVal idEmpleado As Integer) As DataTable

		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerDeptoGerente", conexion)
		comandosql.CommandText = "select nombredepto,iddepto from VerDeptoGerente where numempl =" + idEmpleado.ToString()

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data


	End Function

	Public Function getiddelempleadoespecificdepto(ByVal IdDepto As Integer, ByVal user As String) As DataTable

		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("verIdEmpleado", conexion)
		comandosql.CommandText = "select numeemp from verIdEmpleado where iddepto =" + IdDepto.ToString() + "and usero = '" + user.ToString + "'"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data


	End Function

	'Obtener id del empleado
	Public Function GetIdEmpleado(ByVal User As String, ByVal Pass As String) As Integer
		Dim data As New DataTable
		Dim aux As Integer
		conectar()
		comandosql = New SqlCommand("sp_AllInfo", conexion)
		comandosql.CommandType = CommandType.StoredProcedure

		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
		parametro3.Value = User
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
		parametro1.Value = Pass
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
		parametro4.Value = "X"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		If data.Rows IsNot Nothing AndAlso data.Rows.Count > 0 Then
			aux = data.Rows(0).Item("idempleado")

		End If


		Return aux
	End Function


	'letras
	Public Function EnLetras(numero As String) As String

		Dim b, paso As Integer

		Dim expresion, entero, deci, flag As String



		flag = "N"

		For paso = 1 To Len(numero)

			If Mid(numero, paso, 1) = "." Then

				flag = "S"

			Else

				If flag = "N" Then

					entero = entero + Mid(numero, paso, 1) 'Extae la parte entera del numero

				Else

					deci = deci + Mid(numero, paso, 1) 'Extrae la parte decimal del numero

				End If

			End If

		Next paso



		If Len(deci) = 1 Then

			deci = deci & "0"

		End If



		flag = "N"

		If Val(numero) >= -999999999 And Val(numero) <= 999999999 Then 'si el numero esta dentro de 0 a 999.999.999

			For paso = Len(entero) To 1 Step -1

				b = Len(entero) - (paso - 1)

				Select Case paso

					Case 3, 6, 9

						Select Case Mid(entero, b, 1)

							Case "1"

								If Mid(entero, b + 1, 1) = "0" And Mid(entero, b + 2, 1) = "0" Then

									expresion = expresion & "cien "

								Else

									expresion = expresion & "ciento "

								End If

							Case "2"

								expresion = expresion & "doscientos "

							Case "3"

								expresion = expresion & "trescientos "

							Case "4"

								expresion = expresion & "cuatrocientos "

							Case "5"

								expresion = expresion & "quinientos "

							Case "6"

								expresion = expresion & "seiscientos "

							Case "7"

								expresion = expresion & "setecientos "

							Case "8"

								expresion = expresion & "ochocientos "

							Case "9"

								expresion = expresion & "novecientos "

						End Select



					Case 2, 5, 8

						Select Case Mid(entero, b, 1)

							Case "1"

								If Mid(entero, b + 1, 1) = "0" Then

									flag = "S"

									expresion = expresion & "diez "

								End If

								If Mid(entero, b + 1, 1) = "1" Then

									flag = "S"

									expresion = expresion & "once "

								End If

								If Mid(entero, b + 1, 1) = "2" Then

									flag = "S"

									expresion = expresion & "doce "

								End If

								If Mid(entero, b + 1, 1) = "3" Then

									flag = "S"

									expresion = expresion & "trece "

								End If

								If Mid(entero, b + 1, 1) = "4" Then

									flag = "S"

									expresion = expresion & "catorce "

								End If

								If Mid(entero, b + 1, 1) = "5" Then

									flag = "S"

									expresion = expresion & "quince "

								End If

								If Mid(entero, b + 1, 1) > "5" Then

									flag = "N"

									expresion = expresion & "dieci"

								End If



							Case "2"

								If Mid(entero, b + 1, 1) = "0" Then

									expresion = expresion & "veinte "

									flag = "S"

								Else

									expresion = expresion & "veinti"

									flag = "N"

								End If



							Case "3"

								If Mid(entero, b + 1, 1) = "0" Then

									expresion = expresion & "treinta "

									flag = "S"

								Else

									expresion = expresion & "treinta y "

									flag = "N"

								End If



							Case "4"

								If Mid(entero, b + 1, 1) = "0" Then

									expresion = expresion & "cuarenta "

									flag = "S"

								Else

									expresion = expresion & "cuarenta y "

									flag = "N"

								End If



							Case "5"

								If Mid(entero, b + 1, 1) = "0" Then

									expresion = expresion & "cincuenta "

									flag = "S"

								Else

									expresion = expresion & "cincuenta y "

									flag = "N"

								End If



							Case "6"

								If Mid(entero, b + 1, 1) = "0" Then

									expresion = expresion & "sesenta "

									flag = "S"

								Else

									expresion = expresion & "sesenta y "

									flag = "N"

								End If



							Case "7"

								If Mid(entero, b + 1, 1) = "0" Then

									expresion = expresion & "setenta "

									flag = "S"

								Else

									expresion = expresion & "setenta y "

									flag = "N"

								End If



							Case "8"

								If Mid(entero, b + 1, 1) = "0" Then

									expresion = expresion & "ochenta "

									flag = "S"

								Else

									expresion = expresion & "ochenta y "

									flag = "N"

								End If



							Case "9"

								If Mid(entero, b + 1, 1) = "0" Then

									expresion = expresion & "noventa "

									flag = "S"

								Else

									expresion = expresion & "noventa y "

									flag = "N"

								End If

						End Select



					Case 1, 4, 7

						Select Case Mid(entero, b, 1)

							Case "1"

								If flag = "N" Then

									If paso = 1 Then

										expresion = expresion & "uno "

									Else

										expresion = expresion & "un "

									End If

								End If

							Case "2"

								If flag = "N" Then

									expresion = expresion & "dos "

								End If

							Case "3"

								If flag = "N" Then

									expresion = expresion & "tres "

								End If

							Case "4"

								If flag = "N" Then

									expresion = expresion & "cuatro "

								End If

							Case "5"

								If flag = "N" Then

									expresion = expresion & "cinco "

								End If

							Case "6"

								If flag = "N" Then

									expresion = expresion & "seis "

								End If

							Case "7"

								If flag = "N" Then

									expresion = expresion & "siete "

								End If

							Case "8"

								If flag = "N" Then

									expresion = expresion & "ocho "

								End If

							Case "9"

								If flag = "N" Then

									expresion = expresion & "nueve "

								End If

						End Select

				End Select

				If paso = 4 Then

					If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
				   Len(entero) <= 6) Then




						expresion = expresion & "mil "

					End If

				End If

				If paso = 7 Then

					If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then

						expresion = expresion & "millón "

					Else

						expresion = expresion & "millones "

					End If

				End If

			Next paso



			If deci <> "" Then

				If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo

					EnLetras = "menos " & expresion & "con " & deci ' & "/100"

				Else

					EnLetras = expresion & "con " & deci ' & "/100"

				End If

			Else

				If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo

					EnLetras = "menos " & expresion

				Else

					EnLetras = expresion

				End If

			End If

		Else 'si el numero a convertir esta fuera del rango superior e inferior

			EnLetras = ""

		End If

	End Function

	'VistaNominas
	Public Function VerNominasGenerales(ByVal idempresa As Integer) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerNominaGeneral", conexion)
		comandosql.CommandText = "select NOMBRE_EMPLEADO,BANCO,CURP,NUMERO_SEGURO_SOCIAL,NUMERO_DE_CUENTA,RFC,PUESTO,SALARIO_DIARIO,TOTAL_PERCEPCIONES,TOTAL_DEDUCCIONES,TOTAL_INCIDENCIAS,TOTAL_PAGO_NOMINAL,TOTAL,FECHA from VerNominaGeneral where IDEMPRESA =" + idempresa.ToString()

		adaptador.SelectCommand = comandosql
        adaptador.Fill(data)

        Return data

	End Function
	'ver toda la nomina por k si
	Public Function VerNominasGenerales2(ByVal idempresa As Integer, ByVal fechainge As String) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerNominaGeneral", conexion)
		comandosql.CommandText = "select NOMBRE_EMPLEADO,BANCO,CURP,NUMERO_SEGURO_SOCIAL,NUMERO_DE_CUENTA,RFC,PUESTO,SALARIO_DIARIO,TOTAL_PERCEPCIONES,TOTAL_DEDUCCIONES,TOTAL_INCIDENCIAS,TOTAL_PAGO_NOMINAL,TOTAL,FECHA from VerNominaGeneral where IDEMPRESA =" + idempresa.ToString() + "and FECHA = '" + fechainge + "'"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data

	End Function
	Public Function VerNominasGenerales3(ByVal idempresa As Integer, ByVal inicial As String, ByVal final As String) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerNominaGeneral", conexion)
		comandosql.CommandText = "select NOMBRE_EMPLEADO,BANCO,CURP,NUMERO_SEGURO_SOCIAL,NUMERO_DE_CUENTA,RFC,PUESTO,SALARIO_DIARIO,TOTAL_PERCEPCIONES,TOTAL_DEDUCCIONES,TOTAL_INCIDENCIAS,TOTAL_PAGO_NOMINAL,TOTAL,FECHA from VerNominaGeneral where IDEMPRESA =" + idempresa.ToString() + "and FECHA between '" + inicial + "' and '" + final + "'"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data

	End Function

	Public Function VerNominasGenerales4(ByVal idempresa As Integer, ByVal idempleado As Integer) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerNominaGeneral", conexion)
		comandosql.CommandText = "select NOMBRE_EMPLEADO,BANCO,CURP,NUMERO_SEGURO_SOCIAL,NUMERO_DE_CUENTA,RFC,PUESTO,SALARIO_DIARIO,TOTAL_PERCEPCIONES,TOTAL_DEDUCCIONES,TOTAL_INCIDENCIAS,TOTAL_PAGO_NOMINAL,TOTAL,FECHA from VerNominaGeneral where IDEMPRESA =" + idempresa.ToString() + "and IDEMPLEADO = " + idempleado.ToString()

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data

	End Function


	Public Function VerNominasGenerales5(ByVal idempresa As Integer, ByVal idempleado As Integer, ByVal inicial As String, ByVal final As String) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerNominaGeneral", conexion)
		comandosql.CommandText = "select NOMBRE_EMPLEADO,BANCO,CURP,NUMERO_SEGURO_SOCIAL,NUMERO_DE_CUENTA,RFC,PUESTO,SALARIO_DIARIO,TOTAL_PERCEPCIONES,TOTAL_DEDUCCIONES,TOTAL_INCIDENCIAS,TOTAL_PAGO_NOMINAL,TOTAL,FECHA from VerNominaGeneral where IDEMPRESA =" + idempresa.ToString() + "and IDEMPLEADO = " + idempleado.ToString() + "and FECHA between '" + inicial + "' and '" + final + "'"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data

	End Function

	Public Function VerNominasGenerales6(ByVal rfc As String, ByVal fecha As String) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerNominaGeneral", conexion)
		comandosql.CommandText = "select NOMBRE_EMPLEADO,BANCO,CURP,NUMERO_SEGURO_SOCIAL,NUMERO_DE_CUENTA,RFC,PUESTO,SALARIO_DIARIO,TOTAL_PERCEPCIONES,TOTAL_DEDUCCIONES,TOTAL_INCIDENCIAS,TOTAL_PAGO_NOMINAL,TOTAL,FECHA from VerNominaGeneral where RFC = '" + rfc + "' and FECHA = '" + fecha + "'"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data

	End Function


	Public Function VerNominasGenerales7(ByVal Iddeptos As Integer, ByVal inicial As String, ByVal final As String) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerNominaGeneral2", conexion)
		comandosql.CommandText = "select NOMBRE_EMPLEADO,BANCO,CURP,NUMERO_SEGURO_SOCIAL,NUMERO_DE_CUENTA,RFC,PUESTO,SALARIO_DIARIO,TOTAL_PERCEPCIONES,TOTAL_DEDUCCIONES,TOTAL_INCIDENCIAS,TOTAL_PAGO_NOMINAL,TOTAL,FECHA from VerNominaGeneral2 where iddepto = " + Iddeptos.ToString() + " and FECHA between '" + inicial + "' and '" + final + "'"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data

	End Function

	Public Function VerEmpleadosGerentito(ByVal idempresa As Integer, ByVal iddepto As Integer) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerEmpleadosGerentito", conexion)
		comandosql.CommandText = "select NombreCompleto,Usuario,Departamento,Puesto,nivel,Fecha_Ingreso,Fecha_Nacimiento,Salario_diario from VerEmpleadosGerentito where idemp =" + idempresa.ToString() + "and  id_dpto = " + iddepto.ToString()

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data

	End Function
	Public Function Verdatosrestantesnomina(ByVal idempresa As Integer) As DataTable
        Dim data As New DataTable
        conectar()
        comandosql = New SqlCommand("VerEmpleadosGerentito", conexion)
        comandosql.CommandText = "select id_dpto,Fecha_Ingreso from VerEmpleadosGerentito where idemp =" + idempresa.ToString()

        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)

        Return data

    End Function
    'checar si la empresa ya tiene ese departamento
    Public Function GetDeptosFromEmpresa(ByVal id As Integer) As DataTable
		Dim data As New DataTable

		conectar()
		comandosql = New SqlCommand("sp_DepartamentosMod2", conexion)
		comandosql.CommandType = CommandType.StoredProcedure

		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@id_emp", SqlDbType.Int, 20)
		parametro3.Value = id
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
		parametro4.Value = "S"


		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)


		Return data
	End Function
	'checar si la empresa tiene el depto para no poder agregar
	Public Function CheckTheDepto4Empresa(ByVal idempresa As Integer, ByVal iddepto As Integer) As Boolean
		Dim result As Boolean = False
		Dim data As New DataTable

		conectar()
		comandosql = New SqlCommand("sp_DepartamentosMod2", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@id_emp", SqlDbType.Int, 20)
		parametro1.Value = idempresa
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@id_depto", SqlDbType.VarChar, 20)
		parametro2.Value = iddepto
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
		parametro4.Value = "L"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		If data.Rows IsNot Nothing AndAlso data.Rows.Count > 0 Then

			result = True
		Else

			result = False
		End If

		Return result
	End Function
    'agregar departamento a la tabla asociativa
    Public Function Add_Departamento_toEmpresa(ByVal idempresa As Integer, ByVal iddepto As Integer, ByVal salariobase As Decimal) As Boolean
        Dim result As Boolean = False
        Dim data As New DataTable

        conectar()
        comandosql = New SqlCommand("sp_DepartamentosMod", conexion)
        comandosql.CommandType = CommandType.StoredProcedure
        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@id_emp", SqlDbType.Int, 20)
        parametro1.Value = idempresa
        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@id_depto", SqlDbType.VarChar, 20)
        parametro2.Value = iddepto
        Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@salarioBase", SqlDbType.Decimal, 15, 2)
        parametro3.Value = salariobase
        Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
        parametro4.Value = "I"

        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)



        result = True
        Return result
    End Function

    'delete departamentos
    Public Function deletedepartamentos(ByVal opc As String, ByVal idempresa As Integer, ByVal iddepto As Integer)
		Dim Qry As String
		Dim result As Boolean = False
		Dim data As New DataTable

		conectar()

		Qry = "sp_DepartamentosMod2"
		comandosql = New SqlCommand(Qry, conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@id_emp", SqlDbType.Int)
		parametro1.Value = idempresa
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@id_depto", SqlDbType.Int)
		parametro2.Value = iddepto
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
		parametro4.Value = opc

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		result = True



		desconectar()


		Return result

	End Function
    'NOMINA A
    Public Function nominavariablepercepcion(ByVal idEmpleado As Integer, ByVal idemp As Integer, ByVal FecPag As String, ByVal Ffin As String) As DataTable

        Dim data As New DataTable
        conectar()
        comandosql = New SqlCommand("AA", conexion)
        comandosql.CommandText = "select * from AA where idepresa = " + idemp.ToString() + " and numempleado = " + idEmpleado.ToString() + " and fecha between '" + FecPag + "' and '" + Ffin + "' and identificador = 'Percepcion'"
        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)

        Return data


    End Function

    Public Function vistaincidencia(ByVal idEmpresa As Integer) As DataTable

        Dim data As New DataTable
        conectar()
        comandosql = New SqlCommand("empleados", conexion)
        comandosql.CommandText = "select Idempleado ,Nombre,salario,nombrep  from empleados where idd =" + idEmpresa.ToString()
        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)

        Return data


    End Function
    Public Function nominavariablededuccion(ByVal idEmpleado As Integer, ByVal idemp As Integer, ByVal FecPag As String, ByVal Ffin As String) As DataTable

		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("AA", conexion)
		comandosql.CommandText = "select * from AA where idepresa = " + idemp.ToString() + " and numempleado = " + idEmpleado.ToString() + " and fecha between '" + FecPag + "' and '" + Ffin + "' and identificador = 'Deduccion'"
		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		Return data


	End Function
	Public Function forthdable(ByVal NumEmpleado As Integer, ByVal IDemp As Integer, ByVal FecPag As String) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("Ver2Nominapersona", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Numero_Empleado", SqlDbType.Int, 20)
		parametro1.Value = NumEmpleado
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int, 20)
		parametro2.Value = IDemp
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@FrecuenciaPago", SqlDbType.VarChar, 20)
		parametro3.Value = FecPag
		Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
		parametro6.Value = "B"


		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)


		Return data

	End Function
	'NOMINA B
	'delete puestos
	Public Function deletepuestos(ByVal idempresa As Integer, ByVal iddepto As Integer)
        Dim Qry As String
        Dim result As Boolean = False
        Dim data As New DataTable

        conectar()

        Qry = "sp_Eliminarpuesto"
        comandosql = New SqlCommand(Qry, conexion)
        comandosql.CommandType = CommandType.StoredProcedure
        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@id_empresa", SqlDbType.Int)
        parametro1.Value = idempresa
        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@id_departamento", SqlDbType.Int)
        parametro2.Value = iddepto


        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)

        result = True



        desconectar()


        Return result

    End Function
    'delete empleados from departamento
    Public Function deleteempleados(ByVal idempresa As Integer, ByVal iddepto As Integer)
        Dim Qry As String
        Dim result As Boolean = False
        Dim data As New DataTable

        conectar()

        Qry = "sp_Eliminaremp"
        comandosql = New SqlCommand(Qry, conexion)
        comandosql.CommandType = CommandType.StoredProcedure

        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@id_empresa", SqlDbType.Int, 20)
        parametro1.Value = idempresa
        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@id_dpto", SqlDbType.Int, 20)
        parametro2.Value = iddepto

        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)

        result = True



        desconectar()


        Return result

    End Function
    'modificar empresa
    Public Function ModEmpresa(ByVal Id As Integer, ByVal inicio_oper As Date, ByVal nomb_emp As String, ByVal raz_soc As String,
                                     ByVal dom_fis As String, ByVal email As String, ByVal reg_pat As String,
                                  ByVal reg_cont As String, ByVal Fecha_pago As String) As Boolean
        Dim Qry As String
		Dim result As Boolean = False
		Dim data As New DataTable

		conectar()

			Qry = "sp_empresa"
			comandosql = New SqlCommand(Qry, conexion)
			comandosql.CommandType = CommandType.StoredProcedure

			Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
			parametro8.Value = "M"

			Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Inicio_Operaciones", SqlDbType.Date, 15)
			parametro1.Value = inicio_oper
			Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20)
			parametro2.Value = nomb_emp
			Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Razón_social", SqlDbType.VarChar, 20)
			parametro3.Value = raz_soc
			Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Dominio_Fiscal", SqlDbType.VarChar, 20)
			parametro4.Value = dom_fis
			Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Email", SqlDbType.VarChar, 20)
			parametro5.Value = email
			Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Registro_Patronal", SqlDbType.VarChar, 20)
			parametro6.Value = reg_pat
			Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@Registro_cont", SqlDbType.VarChar, 20)
			parametro7.Value = reg_cont
			Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@frecuencia_pago", SqlDbType.VarChar, 40)
			parametro10.Value = Fecha_pago
			Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@Id_emp", SqlDbType.Int, 20)
			parametro9.Value = Id


		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		result = True



			desconectar()


			Return result

	End Function

	'agregar INCIDENCIAS GENERALES
	Public Function AgregarIncidenciaGeneral(ByVal Nombre As String, ByVal Valor As Decimal, ByVal Dias As Integer, ByVal Total As Decimal, ByVal Identificador As String,
											 ByVal Fecha As String, ByVal General As String, ByVal IdEmpresa As String) As Boolean

		Dim Qry As String
		Dim result As Boolean = False
		Dim data As New DataTable

		conectar()

		Qry = "Sp_INCIDENCIAS"
		comandosql = New SqlCommand(Qry, conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
		parametro1.Value = "I"
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 40)
		parametro2.Value = Nombre
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Valor", SqlDbType.Decimal, 15, 2)
		parametro3.Value = Valor
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Dias", SqlDbType.Int, 20)
		parametro4.Value = Dias
		Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Total", SqlDbType.Decimal, 15, 2)
		parametro5.Value = Total
		Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Identificador", SqlDbType.VarChar, 35)
		parametro6.Value = Identificador
		Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@FechaInicidencia", SqlDbType.Date, 20)
		parametro7.Value = Fecha
		Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@GENERAL", SqlDbType.Bit, 5)
		parametro8.Value = General
		Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@ID_EMPRESAFK", SqlDbType.TinyInt, 20)
		parametro9.Value = IdEmpresa

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		result = True



		desconectar()


		Return result


	End Function

	Public Function AgregarIncidencia1Empleado(ByVal Nombre As String, ByVal Valor As Decimal, ByVal Dias As Integer, ByVal Total As Decimal, ByVal Identificador As String,
											 ByVal Fecha As String, ByVal General As String, ByVal IdEmpresa As String, ByVal IDempleado As String) As Boolean

		Dim Qry As String
		Dim result As Boolean = False
		Dim data As New DataTable

		conectar()

		Qry = "Sp_INCIDENCIAS"
		comandosql = New SqlCommand(Qry, conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
		parametro1.Value = "V"
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 40)
		parametro2.Value = Nombre
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Valor", SqlDbType.Decimal, 15, 2)
		parametro3.Value = Valor
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Dias", SqlDbType.Int, 20)
		parametro4.Value = Dias
		Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Total", SqlDbType.Decimal, 15, 2)
		parametro5.Value = Total
		Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Identificador", SqlDbType.VarChar, 35)
		parametro6.Value = Identificador
		Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@FechaInicidencia", SqlDbType.Date, 20)
		parametro7.Value = Fecha
		Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@GENERAL", SqlDbType.Bit, 5)
		parametro8.Value = General
		Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@ID_EMPRESAFK", SqlDbType.TinyInt, 20)
		parametro9.Value = IdEmpresa
		Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@ID_EMPLEADOFK", SqlDbType.Int, 20)
		parametro10.Value = IDempleado

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		result = True



		desconectar()


		Return result


	End Function


	'empresa stuff
	Public Function getIdEmpresaNow(ByVal user As String, ByVal contra As String) As Integer

		Dim data As New DataTable

		Dim inti As Integer

		conectar()
		comandosql = New SqlCommand("sp_AllInfo", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
		parametro1.Value = user
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
		parametro2.Value = contra
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
		parametro3.Value = "N"


		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)

		If Data.Rows IsNot Nothing AndAlso Data.Rows.Count > 0 Then
			inti = data.Rows(0).Item("idd")
		End If

		Return inti
	End Function

	Public Function GeTfrecuencia(ByVal id As Integer) As DataTable

		Dim data As New DataTable



		conectar()
		comandosql = New SqlCommand("sp_Empleados", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@id", SqlDbType.VarChar, 20)
		parametro1.Value = id
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
		parametro3.Value = "B"


		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)



		Return data
	End Function


	Public Function AgregaGerente(ByVal Opc As String, ByVal ID_EMPRESA As Integer, ByVal SalarioD As Integer, ByVal NomPuesto As String,
                ByVal nombre As String, ByVal apellido As String, ByVal user As String, ByVal password As String, ByVal curp As String) As Boolean


        Dim estado2 As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_PuestoGerente", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro8.Value = Opc


            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 20)
            parametro2.Value = NomPuesto
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@SalarioDiario", SqlDbType.Int)
            parametro3.Value = SalarioD
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Id_empresaFK", SqlDbType.Int, 20)
            parametro6.Value = ID_EMPRESA
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@NombreP", SqlDbType.VarChar, 20)
            parametro7.Value = nombre
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@ApellidoP", SqlDbType.VarChar, 20)
            parametro4.Value = apellido
            Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
            parametro9.Value = user
            Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
            parametro10.Value = password
            Dim parametro11 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 20)
            parametro11.Value = curp



            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado2 = False
        Finally
            desconectar()
        End Try
        Return estado2
    End Function

	Public Function RegistrarEmpleado(ByVal Opc As String, ByVal ID_EMPRESA As Integer,
				ByVal nombre As String, ByVal apellido As String, ByVal user As String, ByVal password As String, ByVal curp As String, ByVal codpost As Integer,
				ByVal calle As String, ByVal numero As Integer, ByVal colonia As String, ByVal mun As String, ByVal estado As String,
				ByVal Fecha_nac As Date, ByVal nns As Integer, ByVal rfc As String, ByVal banco As String, ByVal Nocuenta As Integer, ByVal telefono As Integer, ByVal fecha_ingreso As Date,
				ByVal mail As String, ByVal ID_Departamento As Decimal, ByVal ID_Puesto As Decimal) As Boolean



		Dim estado2 As Boolean = True
		Try
			conectar()
			comandosql = New SqlCommand("sp_Register", conexion)
			comandosql.CommandType = CommandType.StoredProcedure

			Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
			parametro8.Value = Opc
			Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int)
			parametro6.Value = ID_EMPRESA
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 100)
            parametro7.Value = nombre
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Apellido", SqlDbType.VarChar, 100)
            parametro4.Value = apellido
            Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@Usuario", SqlDbType.VarChar, 100)
            parametro9.Value = user
            Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@Pass", SqlDbType.VarChar, 100)
            parametro10.Value = password
            Dim parametro11 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 100)
            parametro11.Value = curp
            Dim parametro12 As SqlParameter = comandosql.Parameters.Add("@Cod_Pos", SqlDbType.BigInt, 20)
            parametro12.Value = codpost
            Dim parametro13 As SqlParameter = comandosql.Parameters.Add("@calle", SqlDbType.VarChar, 100)
            parametro13.Value = calle
            Dim parametro14 As SqlParameter = comandosql.Parameters.Add("@numero", SqlDbType.BigInt, 20)
            parametro14.Value = numero
            Dim parametro15 As SqlParameter = comandosql.Parameters.Add("@Colonia", SqlDbType.VarChar, 100)
            parametro15.Value = colonia
            Dim parametro16 As SqlParameter = comandosql.Parameters.Add("@Mun", SqlDbType.VarChar, 100)
            parametro16.Value = mun
            Dim parametro17 As SqlParameter = comandosql.Parameters.Add("@Estado", SqlDbType.VarChar, 100)
            parametro17.Value = estado
			Dim parametro18 As SqlParameter = comandosql.Parameters.Add("@Fecha_Nac", SqlDbType.Date)
			parametro18.Value = Fecha_nac
            Dim parametro19 As SqlParameter = comandosql.Parameters.Add("@NNS", SqlDbType.BigInt, 20)
            parametro19.Value = nns
            Dim parametro20 As SqlParameter = comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 100)
            parametro20.Value = rfc
            Dim parametro21 As SqlParameter = comandosql.Parameters.Add("@Banco", SqlDbType.VarChar, 100)
            parametro21.Value = banco
            Dim parametro22 As SqlParameter = comandosql.Parameters.Add("@NoCuenta", SqlDbType.BigInt, 20)
            parametro22.Value = Nocuenta
            Dim parametro23 As SqlParameter = comandosql.Parameters.Add("@Telefono", SqlDbType.BigInt, 20)
            parametro23.Value = telefono
			Dim parametro24 As SqlParameter = comandosql.Parameters.Add("@Fecha_ingreso", SqlDbType.Date)
			parametro24.Value = fecha_ingreso
            Dim parametro25 As SqlParameter = comandosql.Parameters.Add("@Mail", SqlDbType.VarChar, 100)
            parametro25.Value = mail
			Dim parametro26 As SqlParameter = comandosql.Parameters.Add("@ID_Departamento", SqlDbType.Int)
			parametro26.Value = ID_Departamento
            Dim parametro27 As SqlParameter = comandosql.Parameters.Add("@ID_Puesto", SqlDbType.Int)
            parametro27.Value = ID_Puesto


			conexion.Open()
			adaptador.InsertCommand = comandosql
			comandosql.ExecuteNonQuery()

		Catch ex As SqlException
			estado2 = False
		Finally
			desconectar()
		End Try
		Return estado2
	End Function
	'primer paso para pagar nomina
	Public Function FirstTable(ByVal NumEmpleado As Integer, ByVal IDemp As Integer, ByVal FecPag As String, ByVal Fini As String, ByVal Ffin As String) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("VerNomina1persona", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Numero_Empleado", SqlDbType.Int, 20)
		parametro1.Value = NumEmpleado
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int, 20)
		parametro2.Value = IDemp
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@FrecuenciaPago", SqlDbType.VarChar, 20)
		parametro3.Value = FecPag
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@fechafinal", SqlDbType.VarChar, 20)
		parametro4.Value = Ffin
		Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@fechainicial", SqlDbType.VarChar, 20)
		parametro5.Value = Fini
		Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
		parametro6.Value = "A"


		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)


		Return data

	End Function
	'segundo paso para pagar nomina
	Public Function SecondTable(ByVal NumEmpleado As Integer, ByVal IDempresa As Integer, ByVal NombreCompleto As String,
		ByVal Banco As String, ByVal NoCuenta As Integer, ByVal rfc As String, ByVal Puesto As String, ByVal SalDIARIO As Decimal,
		ByVal TotalPercepciones As Decimal, ByVal TotalDeducciones As Decimal, ByVal TotalIncidencias As Decimal, ByVal TotalPagoNominal As Decimal,
		ByVal TotalNOMINA As Decimal, ByVal fechanomina As Date, ByVal CURP As String, ByVal NNS As Integer) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("sp_AgregarAnomFIN", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@idempleado", SqlDbType.Int, 20)
		parametro1.Value = NumEmpleado
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@idempresa", SqlDbType.Int, 20)
		parametro2.Value = IDempresa
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@NombreCompleto", SqlDbType.VarChar, 20)
		parametro3.Value = NombreCompleto
		Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Banco", SqlDbType.VarChar, 20)
		parametro4.Value = Banco
		Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@NoCuenta", SqlDbType.Int, 20)
		parametro5.Value = NoCuenta
		Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 20)
		parametro7.Value = rfc
		Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@Puesto", SqlDbType.VarChar, 20)
		parametro8.Value = Puesto
		Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@SalarioDiario", SqlDbType.Decimal, 15, 2)
		parametro9.Value = SalDIARIO
		Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@TotalPercepciones", SqlDbType.Decimal, 15, 2)
		parametro10.Value = TotalPercepciones
		Dim parametro11 As SqlParameter = comandosql.Parameters.Add("@TotalDeducciones", SqlDbType.Decimal, 15, 2)
		parametro11.Value = TotalDeducciones
		Dim parametro12 As SqlParameter = comandosql.Parameters.Add("@TotalIncidencias", SqlDbType.Decimal, 15, 2)
		parametro12.Value = TotalIncidencias
		Dim parametro13 As SqlParameter = comandosql.Parameters.Add("@TotalPagoNominal", SqlDbType.Decimal, 15, 2)
		parametro13.Value = TotalPagoNominal
		Dim parametro14 As SqlParameter = comandosql.Parameters.Add("@TotalNOMINA", SqlDbType.Decimal, 15, 2)
		parametro14.Value = TotalNOMINA
		Dim parametro15 As SqlParameter = comandosql.Parameters.Add("@FECHANOMINA", SqlDbType.Date)
		parametro15.Value = fechanomina
		Dim parametro17 As SqlParameter = comandosql.Parameters.Add("@NNS", SqlDbType.Int, 20)
		parametro17.Value = NNS
		Dim parametro18 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 20)
		parametro18.Value = CURP


		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)


		Return data

	End Function
    Public Function thirdable(ByVal NumEmpleado As Integer, ByVal IDemp As Integer, ByVal FecPag As String) As DataTable
        Dim data As New DataTable
        conectar()
        comandosql = New SqlCommand("Ver2Nominapersona", conexion)
        comandosql.CommandType = CommandType.StoredProcedure
        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Numero_Empleado", SqlDbType.Int, 20)
        parametro1.Value = NumEmpleado
        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int, 20)
        parametro2.Value = IDemp
        Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@FrecuenciaPago", SqlDbType.VarChar, 20)
        parametro3.Value = FecPag
        Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
        parametro6.Value = "A"


        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)


        Return data

    End Function

    Public Function Get_Persona() As DataTable
        Dim Qry As String
        Dim data As New DataTable

        Try

            conectar()

            Qry = "sp_Persona"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = "S"


            adaptador.SelectCommand = comandosql
            adaptador.Fill(data)

        Catch ex As SqlException

        Finally
            desconectar()
        End Try
        Return data

    End Function
    Public Function AgregaLogin(ByVal Opc As String, ByVal user As String, ByVal pass As String, ByVal Idempresa As Integer,
                                ByVal Idpuesto As Integer, ByVal Iddepartamento As Integer, ByVal curp As Integer) As Boolean
        Dim estado2 As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_Register_emp", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
            parametro1.Value = user
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
            parametro2.Value = pass
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro3.Value = Opc
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Id_empresaFK", SqlDbType.Int)
            parametro4.Value = Idempresa
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Id_puestoFK", SqlDbType.Int)
            parametro5.Value = Idpuesto
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Id_departamentoFK", SqlDbType.Int)
            parametro6.Value = Iddepartamento
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@Id_curpFK", SqlDbType.Int)
            parametro6.Value = curp


            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado2 = False
        Finally
            desconectar()
        End Try
        Return estado2
    End Function
	'login
	Public Function ValidaUsuario(ByVal User As String, ByVal Pass As String) As Boolean
		Dim estado As Boolean = True
		Try
			conectar()
			comandosql = New SqlCommand("sp_LOGIN", conexion)
			comandosql.CommandType = CommandType.StoredProcedure

			Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
			parametro1.Value = User
			Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
			parametro2.Value = Pass

			adaptador.SelectCommand = comandosql
			adaptador.Fill(tabla)

			If tabla.Rows IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
				estado = True
			Else
				estado = False
			End If


		Catch ex As SqlException
			estado = False
		Finally
			desconectar()
		End Try
		Return estado

	End Function
	'ir poniendo el usuario  logueado en todas las ventanas
	Public Function Get_loged(ByVal User As String, ByVal Pass As String) As DataTable
		Dim data As New DataTable

		Try

			conectar()
            comandosql = New SqlCommand("VerName", conexion)
            comandosql.CommandText = "select fullname from VerName where useroa = '" + User + "' and contra = '" + Pass + "'"

			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)



		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function
	'ir poniendo la empresa donde necesitamos
	Public Function Get_Empri(ByVal User As String, ByVal Pass As String) As DataTable
		Dim data As New DataTable

		Try

			conectar()
			comandosql = New SqlCommand("VerEmp", conexion)
			comandosql.CommandText = "select nombre from VerEmp where useroa = '" + User + "' and contra = '" + Pass + "'"

			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)



		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function
	'vusta para ver la nomina general
	Public Function Get_Empri(ByVal IDEmpresa As Integer, ByVal fecha As Date) As DataTable
		Dim data As New DataTable

		Try

			conectar()
			comandosql = New SqlCommand("VerNominaGeneral", conexion)
			comandosql.CommandText = "select NombreCompleto,Departamento,Puesto,Salario_diario from VerNominaGeneral where idemp = " + IDEmpresa + "and ingreso_a_empresa =" + fecha.ToString()

			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)



		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function
	'ir poniendo la empresa donde necesitamos
	Public Function DespedirEmpleado(ByVal User As String, ByVal Pass As String) As Boolean
		Dim data As New DataTable


		Dim result As Boolean = False
		conectar()
		comandosql = New SqlCommand("sp_AllInfo", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
		parametro1.Value = User
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
		parametro2.Value = Pass
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
		parametro3.Value = "D"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)


		desconectar()
		Return True

	End Function
	'Vista para todos los empleados de una empresa
	Public Function Ver_Empis(ByVal Id As String) As DataTable
		Dim data As New DataTable

		Try

			conectar()
			comandosql = New SqlCommand("VerEmpleados", conexion)
			comandosql.CommandText = "Select Nombre_Empleado , Departamento, Puesto, Activo, Usuario, Contraseña from VerEmpleados where ID_Empresa = " + Id + " "

			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)



		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function
	'Vista para todos los empleados de una empresa y su id
	Public Function Ver_Empispp(ByVal Id As String) As DataTable
		Dim data As New DataTable

		Try

			conectar()
			comandosql = New SqlCommand("VerParaPagar", conexion)
			comandosql.CommandText = "Select Empresa,ID_Empresa,Nombre_Empleado,frecuencia,idemp from VerParaPagar where ID_Empresa = " + Id + " "

			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)



		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function
	' FUNCION PARA CHECAR SI ES GERENTE NOMINA
	Public Function GerNom(ByVal User As String, ByVal Pass As String) As Boolean
		Dim data As New DataTable
		Dim result As Boolean = False
		conectar()
		comandosql = New SqlCommand("sp_AllInfo", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
		parametro1.Value = User
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
		parametro2.Value = Pass
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
		parametro3.Value = "L"

		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)


		If data.Rows IsNot Nothing AndAlso data.Rows.Count > 0 Then
			If data.Rows(0).Item("NombreP") = "gerente nomina" Then
				result = True
			End If
		End If

		Return result

	End Function
	'All info from empleado
	Public Function AllInfoBaby(ByVal User As String, ByVal Pass As String) As DataTable
		Dim data As New DataTable
		conectar()
		comandosql = New SqlCommand("sp_AllInfo", conexion)
		comandosql.CommandType = CommandType.StoredProcedure
		Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
		parametro1.Value = User
		Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
		parametro2.Value = Pass
		Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
		parametro3.Value = "A"


		adaptador.SelectCommand = comandosql
		adaptador.Fill(data)


		Return data

	End Function
    ''mod all info from empleado
    Public Function ModEmpleado(ByVal Nombre As String, ByVal Apellido As String, ByVal usuario As String, ByVal password As String, ByVal numempleado As Integer,
         ByVal idpersona As Integer, ByVal curp As String, ByVal numerosocial As Integer, ByVal rfc As String, ByVal telefono As Integer,
        ByVal banco As String, ByVal numcuenta As Integer, ByVal mail As String, ByVal fecha_ingreso As Date, ByVal fechaingresonacimiento As Date, ByVal calle As String, ByVal estado As String,
        ByVal municipio As String, ByVal numerocalle As Integer, ByVal colonia As String, ByVal codpos As Integer, ByVal iddomici As Integer, ByVal idpuesto As Integer, ByVal iddepto As Integer) As Boolean

        Dim data As New DataTable
        Dim result As Boolean = False
        conectar()
        comandosql = New SqlCommand("sp_Register", conexion)
        comandosql.CommandType = CommandType.StoredProcedure

        'empleado parameters
        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Numero_Empleado", SqlDbType.Int, 20)
        parametro1.Value = numempleado
        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Usuario", SqlDbType.VarChar, 100)
        parametro2.Value = usuario
        Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Pass", SqlDbType.VarChar, 100)
        parametro4.Value = password
        Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Banco", SqlDbType.VarChar, 100)
        parametro5.Value = banco
        Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@NoCuenta", SqlDbType.BigInt, 100)
        parametro6.Value = numcuenta
        Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@Telefono", SqlDbType.BigInt, 100)
        parametro7.Value = telefono
        Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@Mail", SqlDbType.VarChar, 100)
        parametro8.Value = mail
        Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@Fecha_Ingreso", SqlDbType.Date)
        parametro9.Value = fecha_ingreso
        'persona parameters
        Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 100)
        parametro10.Value = Nombre
        Dim parametro11 As SqlParameter = comandosql.Parameters.Add("@Apellido", SqlDbType.VarChar, 100)
        parametro11.Value = Apellido
        Dim parametro12 As SqlParameter = comandosql.Parameters.Add("@idpersona", SqlDbType.Int, 20)
        parametro12.Value = idpersona
        Dim parametro13 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 100)
        parametro13.Value = curp
        Dim parametro14 As SqlParameter = comandosql.Parameters.Add("@NNS", SqlDbType.BigInt, 20)
        parametro14.Value = numerosocial
        Dim parametro15 As SqlParameter = comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 100)
        parametro15.Value = rfc
        Dim parametro23 As SqlParameter = comandosql.Parameters.Add("@Fecha_Nac", SqlDbType.Date)
        parametro23.Value = fechaingresonacimiento
        'domicilio parameters
        Dim parametro16 As SqlParameter = comandosql.Parameters.Add("@ID_Domicilio", SqlDbType.Int, 20)
        parametro16.Value = iddomici
        Dim parametro17 As SqlParameter = comandosql.Parameters.Add("@calle", SqlDbType.VarChar, 100)
        parametro17.Value = calle
        Dim parametro18 As SqlParameter = comandosql.Parameters.Add("@Estado", SqlDbType.VarChar, 100)
        parametro18.Value = estado
        Dim parametro19 As SqlParameter = comandosql.Parameters.Add("@Mun", SqlDbType.VarChar, 100)
        parametro19.Value = municipio
        Dim parametro20 As SqlParameter = comandosql.Parameters.Add("@numero", SqlDbType.BigInt, 20)
        parametro20.Value = numerocalle
        Dim parametro21 As SqlParameter = comandosql.Parameters.Add("@Colonia", SqlDbType.VarChar, 100)
        parametro21.Value = colonia
        Dim parametro22 As SqlParameter = comandosql.Parameters.Add("@Cod_Pos", SqlDbType.BigInt, 20)
        parametro22.Value = codpos
        'puesto y depto parameters
        Dim parametro24 As SqlParameter = comandosql.Parameters.Add("@ID_Departamento", SqlDbType.Int, 20)
        parametro24.Value = iddepto
        Dim parametro25 As SqlParameter = comandosql.Parameters.Add("@ID_Puesto", SqlDbType.Int, 20)
        parametro25.Value = idpuesto
        'opcion
        Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
        parametro3.Value = "M"

        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)

        Return True

    End Function
    ' FUNCION PARA CHECAR SI ES GERENTE depto
    Public Function GerDepto(ByVal User As String, ByVal Pass As String) As Boolean
        Dim data As New DataTable
        Dim result As Boolean = False
        conectar()
        comandosql = New SqlCommand("sp_AllInfo", conexion)
        comandosql.CommandType = CommandType.StoredProcedure
        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@User", SqlDbType.VarChar, 20)
        parametro1.Value = User
        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pass", SqlDbType.VarChar, 20)
        parametro2.Value = Pass
        Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@opc", SqlDbType.Char, 1)
        parametro3.Value = "L"

        adaptador.SelectCommand = comandosql
        adaptador.Fill(data)


        If data.Rows IsNot Nothing AndAlso data.Rows.Count > 0 Then
            If data.Rows(0).Item("NombreP") = "Gerente" Then
                result = True
            End If
        End If

        Return result

    End Function
    Public Function Add_Puesto(ByVal opc As String,
                                    ByVal puesto1 As String,
                                    ByVal nivel As Decimal,
                                    ByVal id_empresa As Decimal,
                                    ByVal id_dpto As Decimal) As Boolean

        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_Puesto", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 20)
            parametro2.Value = puesto1
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Nivel", SqlDbType.Decimal, 15, 2)
            parametro3.Value = nivel
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Id_empresaFK", SqlDbType.Int)
            parametro5.Value = id_empresa
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@id_departamento", SqlDbType.Int)
            parametro6.Value = id_dpto

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function refresh(ByVal condition As Integer, ByVal identificador As Decimal) As DataTable
        Dim Qry As String
        Dim data As New DataTable

        Try

            conectar()

            Qry = "sp_refresh"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@condicion", SqlDbType.Int)
            parametro2.Value = condition
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@identificador", SqlDbType.Int)
            parametro3.Value = identificador

            adaptador.SelectCommand = comandosql
            adaptador.Fill(data)

        Catch ex As SqlException

        Finally
            desconectar()
        End Try
        Return data

    End Function

	Public Function refreshidpuesto(ByVal departamento As Integer, ByVal empresa As Integer, ByVal puestoname As String) As DataTable
		Dim Qry As String
		Dim data As New DataTable

		Try

			conectar()

			Qry = "sp_getidpuesto"
			comandosql = New SqlCommand(Qry, conexion)
			comandosql.CommandType = CommandType.StoredProcedure

			Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@departamento", SqlDbType.Int)
			parametro2.Value = departamento
			Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@empresa", SqlDbType.Int)
			parametro3.Value = empresa
			Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@name", SqlDbType.VarChar, 20)
			parametro4.Value = puestoname

			adaptador.SelectCommand = comandosql
			adaptador.Fill(data)

		Catch ex As SqlException

		Finally
			desconectar()
		End Try
		Return data

	End Function
	'regresar unica empresa
	'obtener empresa



	Public Function AgregaInventario(ByVal dFecha As Date, ByVal strCliente As String, ByVal strNoParte As String,
                                     ByVal strProducto As String, ByVal iPiezasAlm As Integer, ByVal iPiezasCuar As _
                                     Integer, ByVal iPiezasTot As Integer) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
            parametro1.Value = dFecha
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Cliente", SqlDbType.VarChar, 60)
            parametro2.Value = strCliente
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@NoParte", SqlDbType.VarChar, 20)
            parametro3.Value = strNoParte
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Producto", SqlDbType.VarChar, 50)
            parametro4.Value = strProducto
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@PiezasAlm", SqlDbType.Int, 8)
            parametro5.Value = iPiezasAlm
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@PiezasCuar", SqlDbType.Int, 8)
            parametro6.Value = iPiezasCuar
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@PiezasTot", SqlDbType.Int, 8)
            parametro7.Value = iPiezasTot
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@strUsuario", SqlDbType.VarChar, 20)
            'If Session("UserID") Is Nothing Then
            'parametro8.Value = "generic user"
            'Else
            'parametro8.Value = Session("UserID")
            'End If

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function LimpiaInventarioMes(ByVal dFecha As Date) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_Delete", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
            parametro1.Value = dFecha

            conexion.Open()
            adaptador.DeleteCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function Add_Puesto(ByVal opc As String,
                                    ByVal puesto As String,
                                    ByVal nivel As Decimal) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_Puestos", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 20)
            parametro2.Value = puesto
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Nivel", SqlDbType.Decimal, 5)
            parametro3.Value = nivel

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function ConsultaInventarioInicial(ByVal dFecha As Date, ByVal strCliente As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
            parametro1.Value = dFecha
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Cliente", SqlDbType.VarChar, 60)
            parametro2.Value = strCliente

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function ConsultaTonelaje() As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function GeneraAnalisis1(ByVal dFechaI As Date, ByVal dFechaF As Date, ByVal Tienda As Integer, ByVal Depto As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("dbo.cumhoGeneraAnalisis1", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@FechaIni", SqlDbType.SmallDateTime, 15)
            parametro1.Value = dFechaI
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@FechaFin", SqlDbType.SmallDateTime, 15)
            parametro2.Value = dFechaF
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pTienda", SqlDbType.Int, 8)
            parametro3.Value = Tienda
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@pDepto", SqlDbType.VarChar, 10)
            parametro4.Value = Depto

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function ObtenTiendas(ByVal Tienda As Integer) As Boolean
        Dim estado As Boolean = True
        Dim Qry As String = ""

        Qry = "SELECT Id, Nombre FROM Tienda"
        Try
            conectar()
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.Text

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function ObtenDeptos(ByVal tienda As Integer) As Boolean
        Dim estado As Boolean = True
        Dim Qry As String
        Qry = "sp_Deptos"
        Try
            conectar()
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function ObtenDatosArchivo(ByVal CveOperacion As String, ByVal TipoPago As Integer, ByVal DiaPago As String) As Boolean
        Dim estado As Boolean = True
        Dim qry As String
        'qry = "dbo.CtlInt_PagoNomina_pUP"
        qry = "dbo.sp_pruebas"
        Try
            conectar()
            comandosql = New SqlCommand(qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pCveOperacion", SqlDbType.VarChar, 4)
            parametro1.Value = CveOperacion
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pTipoPago", SqlDbType.SmallInt, 4)
            parametro2.Value = TipoPago
            If CveOperacion <> "HEDS" Then
                Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pDiaPago", SqlDbType.VarChar, 15)
                parametro3.Value = DiaPago
            End If
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function ObtenDatosPago(ByVal CveOperacion As String, ByVal TipoPago As Integer, ByVal DiaPago As String) As Boolean
        Dim estado As Boolean = True

        Try
            conectar()
            comandosql = New SqlCommand("dbo.sp_Pruebas", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pCveOperacion", SqlDbType.VarChar, 4)
            parametro1.Value = CveOperacion
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pTipoPago", SqlDbType.SmallInt, 4)
            parametro2.Value = TipoPago
            If CveOperacion = "DETS" Then
                Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pDiaPago", SqlDbType.VarChar, 15)
                parametro3.Value = DiaPago
            End If
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
End Class
