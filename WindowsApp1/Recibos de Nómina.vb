Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class Recibos_de_Nómina
    Private Sub Recibos_de_Nómina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tablax As New DataTable
        Dim tablax3 As New DataTable
        Dim obj As New EnlaceBD

		'da el usuario y contra para poder llenar la tabla pero no son visibles

		Dim datee As Date = DateTimePicker1.Value.Date
		Dim datee2 As Date = DateTimePicker2.Value.Date

		Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
		Dim idemp As Integer = obj.GetIdEmpleado(Form1.user.Text, Form1.pass.Text)

		tablax = obj.VerNominasGenerales4(inti, idemp)

		DataGridView1.DataSource = tablax

		Dim auxx As DataTable = obj.GeTfrecuencia(inti)
		TextBox2.Text = auxx.Rows(0).Item("frecuencia")

	End Sub

	Private Sub Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimir.Click
		Dim tablax2 As New DataTable
		Dim obj As New EnlaceBD
		Dim fechainicial As Date = DateTimePicker1.Value.Date
		Dim fechafinal As Date = DateTimePicker2.Value.Date
		Dim tablax3 As New DataTable
		Dim tablax4 As New DataTable
		Dim tablax5 As New DataTable
		Dim tablax6 As New DataTable
		Dim tablax7 As New DataTable
		Dim pdfdoc As New Document()
		Dim fechainicial2 As String = fechainicial.ToString("yyyy-MM-dd")
		Dim Fechafinal2 As String = fechafinal.ToString("yyyy-MM-dd")


		Dim fechafss As Date = DateTimePicker3.Value.Date
		Dim Fechaselect As String = fechafss.ToString("yyyy-MM-dd")
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfdoc, New FileStream("B.pdf", FileMode.Create))
        'Dim pdfreader As PdfReader = New PdfReader(PdfTemplate)
        Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
		Dim idemp As Integer = obj.GetIdEmpleado(Form1.user.Text, Form1.pass.Text)

		tablax2 = obj.VerNominasGenerales6(TextBox1.Text, Fechaselect)


		tablax6 = obj.nominavariablepercepcion(idemp, inti, fechainicial2, Fechafinal2)
		tablax7 = obj.nominavariablededuccion(idemp, inti, fechainicial2, Fechafinal2)
		Dim percepcion As Integer = tablax6.Rows.Count()
		Dim deduccion As Integer = tablax7.Rows.Count()
		TextBox1.Text = idemp
		Dim contador As Integer = tablax5.Rows.Count()
		pdfdoc.Open()
		Dim aa As Decimal = tablax2.Rows(0).Item("TOTAL_PERCEPCIONES")
		Dim ded As Decimal = tablax2.Rows(0).Item("TOTAL_DEDUCCIONES")
		Dim incidencias As Decimal = aa - ded
		Dim salariobruto As Decimal = tablax2.Rows(0).Item("TOTAL_PAGO_NOMINAL")
		Dim salariototal As Decimal = salariobruto + aa - ded
		Dim diast As String
		Dim aux As Integer = 0
		Dim aux2 As Integer = 0
		If TextBox2.Text = " Semanal" Then
			diast = "7"
		ElseIf TextBox2.Text = "Catorcenal" Then
			diast = "14"
		ElseIf TextBox2.Text = "Quincenal" Then
			diast = "15"
		ElseIf TextBox2.Text = "Mensual" Then
			diast = "30"
		End If
		Dim table As New PdfPTable(4)
		Dim cell As New PdfPCell(New Phrase("Recibo de Nomina       Fecha:     " + TextBox13.Text))

		Dim cvacio As New PdfPCell(New Phrase(" "))
		cvacio.Border = 0
		Dim espacio As New PdfPCell(New Phrase("  "))
		espacio.Colspan = 4
		espacio.Border = 0
		cell.Colspan = 4
		cell.HorizontalAlignment = 1
		table.AddCell(espacio)
		table.AddCell(cell)
		table.AddCell("Nombre: " + tablax2.Rows(0).Item("NOMBRE_EMPLEADO"))
		table.AddCell("IMSS: " + tablax2.Rows(0).Item("NUMERO_SEGURO_SOCIAL").ToString)
		table.AddCell("CURP: " + tablax2.Rows(0).Item("CURP"))
		table.AddCell("RFC: " + tablax2.Rows(0).Item("RFC"))


		table.AddCell(espacio)
		pdfdoc.Add(table)
		Dim table2 As New PdfPTable(3)
		table2.AddCell("Num. Emp: " + inti.ToString)
		table2.AddCell("Puesto:  " + tablax2.Rows(0).Item("PUESTO"))
		'table2.AddCell("Depto:" + tablax4.Rows(0).Item("nombredepto"))
		table2.AddCell("Dias trabajados " + diast)
		table2.AddCell("Salario Diario: " + tablax2.Rows(0).Item("SALARIO_DIARIO").ToString)
		table2.AddCell("Salario Nominal: " + tablax2.Rows(0).Item("TOTAL_PAGO_NOMINAL").ToString())
		'table2.AddCell("Fecha de alta" + tablax3.Rows(0).Item("").ToString)
		table2.AddCell(espacio)
		pdfdoc.Add(table2)
		'tabla percepciones
		Dim table3 As New PdfPTable(3)
		Dim perc As New PdfPCell(New Phrase("Percepciones"))
		perc.Colspan = 3
		perc.HorizontalAlignment = 1
		table3.AddCell(perc)
		table3.AddCell(espacio)
		table3.AddCell("Clave")
		table3.AddCell("Concepto")
		table3.AddCell("Cantidad")
		While aux < percepcion
			table3.AddCell(" " + tablax6.Rows(aux).Item("identificador"))
			table3.AddCell(" " + tablax6.Rows(aux).Item("Nombre_Incidencia"))
			table3.AddCell(" " + tablax6.Rows(aux).Item("TOTAL").ToString())
			aux = aux + 1
		End While
		table3.AddCell(cvacio)
		table3.AddCell(cvacio)
		table3.AddCell("Total  " + tablax2.Rows(0).Item("TOTAL_PERCEPCIONES").ToString)
		table3.AddCell(espacio)
		pdfdoc.Add(table3)
		'tabla deducciones
		Dim table4 As New PdfPTable(3)
		Dim deduc As New PdfPCell(New Phrase("Deducciones"))
		deduc.Colspan = 3
		deduc.HorizontalAlignment = 1
		table4.AddCell(deduc)
		table4.AddCell(espacio)
		table4.AddCell("Clave")
		table4.AddCell("concepto")
		table4.AddCell("Cantidad")
		While aux2 < deduccion
			table4.AddCell(" " + tablax7.Rows(aux2).Item("identificador"))
			table4.AddCell(" " + tablax7.Rows(aux2).Item("Nombre_Incidencia"))
			table4.AddCell(" " + tablax7.Rows(aux2).Item("TOTAL").ToString())
			aux2 = aux2 + 1
		End While
		table4.AddCell(cvacio)
		table4.AddCell(cvacio)
		table4.AddCell("Total  " + tablax2.Rows(0).Item("TOTAL_DEDUCCIONES").ToString)
		table4.AddCell(espacio)
		pdfdoc.Add(table4)
		'tabla nomina final
		Dim table5 As New PdfPTable(2)
		Dim nom As New PdfPCell(New Phrase("Nomina total"))
		nom.Colspan = 2
		nom.HorizontalAlignment = 1
		table5.AddCell(espacio)
		table5.AddCell(nom)
		table5.AddCell("Total:  " + tablax2.Rows(0).Item("TOTAL").ToString)
		table5.AddCell("letra:  " + obj.EnLetras(tablax2.Rows(0).Item("TOTAL")))
		pdfdoc.Add(table5)



		pdfdoc.Close()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim tablax3 As New DataTable
		Dim obj As New EnlaceBD
		Dim datee As Date = DateTimePicker1.Value.Date
		Dim datee2 As Date = DateTimePicker2.Value.Date
		Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
		Dim idemp As Integer = obj.GetIdEmpleado(Form1.user.Text, Form1.pass.Text)


		tablax3 = obj.VerNominasGenerales5(inti, idemp, datee.ToString("yyyy-MM-dd"), datee2.ToString("yyyy-MM-dd"))

		DataGridView1.DataSource = tablax3
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Dim tablax As New DataTable
		Dim tablax3 As New DataTable
		Dim obj As New EnlaceBD

		'da el usuario y contra para poder llenar la tabla pero no son visibles

		Dim datee As Date = DateTimePicker1.Value.Date
		Dim datee2 As Date = DateTimePicker2.Value.Date

		Dim inti As Integer = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
		Dim idemp As Integer = obj.GetIdEmpleado(Form1.user.Text, Form1.pass.Text)

		tablax = obj.VerNominasGenerales4(inti, idemp)

		DataGridView1.DataSource = tablax
	End Sub

	Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
		Dim datarow As DataGridViewRow
		Dim obj As New EnlaceBD
		datarow = DataGridView1.Rows(e.RowIndex)

		'Dim fecha As Date = datarow.Cells(5).Value
		TextBox1.Text = datarow.Cells(5).Value 'fecha.ToString("yyyy-MM-dd")
		TextBox13.Text = datarow.Cells(13).Value
	End Sub
End Class