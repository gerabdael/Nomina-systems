Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class Form6
	Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load




	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim tablax As New DataTable
		Dim tablax2 As New DataTable
		Dim obj As New EnlaceBD
		Dim inti As Integer
		'da el usuario y contra para poder llenar la tabla pero no son visibles

		Dim datee As Date

		inti = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)

		datee = DateTimePicker1.Value.Date


		tablax2 = obj.VerNominasGenerales2(inti, datee.ToString("yyyy-MM-dd"))

		DataGridView1.DataSource = tablax2

	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim tablax As New DataTable
		Dim tablax2 As New DataTable
		Dim obj As New EnlaceBD
		Dim inti As Integer
		'da el usuario y contra para poder llenar la tabla pero no son visibles



		inti = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)

		tablax2 = obj.VerNominasGenerales(inti)

		DataGridView1.DataSource = tablax2

	End Sub

	Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

	End Sub

	Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Dim tablax As New DataTable
		Dim tablax2 As New DataTable
		Dim obj As New EnlaceBD
		Dim inti As Integer
		'da el usuario y contra para poder llenar la tabla pero no son visibles


		inti = obj.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)


		Dim datee As Date = DateTimePicker2.Value.Date
		Dim datee2 As Date = DateTimePicker3.Value.Date


		tablax2 = obj.VerNominasGenerales3(inti, datee.ToString("yyyy-MM-dd"), datee2.ToString("yyyy-MM-dd"))

		DataGridView1.DataSource = tablax2
	End Sub

	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		'imprimir
		Dim aux As DataTable
		aux = DataGridView1.DataSource

		Dim obj As New EnlaceBD

		Dim pdfdoc As New Document()
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfdoc, New FileStream("A.pdf", FileMode.Create))
        'Dim pdfreader As PdfReader = New PdfReader(PdfTemplate)
        pdfdoc.Open()
		Dim table As New PdfPTable(1)
		Dim cell As New PdfPCell(New Phrase("Recibo de Nomina General"))
		Dim cvacio As New PdfPCell(New Phrase(" "))
		Dim cvacio2 As New PdfPCell(New Phrase(" "))
		cvacio.Border = 0
		Dim espacio As New PdfPCell(New Phrase("  "))
		espacio.Colspan = 4
		espacio.Border = 0
		cell.Colspan = 4
		cell.HorizontalAlignment = 1
		table.AddCell(espacio)
		table.AddCell(cell)

		Dim inta As Integer = 0
		Dim intix As Integer = aux.Rows.Count()

		Dim cella As New PdfPCell(New Phrase("EMPLEADOS"))

		While (inta < intix)
			table.AddCell("FECHA: " + aux.Rows(inta).Item("FECHA"))
			table.AddCell("Nombre:" + aux.Rows(inta).Item("NOMBRE_EMPLEADO"))
			table.AddCell("CURP: " + aux.Rows(inta).Item("CURP"))
			table.AddCell("NNS: " + aux.Rows(inta).Item("NUMERO_SEGURO_SOCIAL").ToString)
			table.AddCell("IMSS: " + aux.Rows(inta).Item("BANCO"))
			table.AddCell("Nocuenta: " + aux.Rows(inta).Item("NUMERO_DE_CUENTA").ToString)
			table.AddCell("RFC: " + aux.Rows(inta).Item("RFC"))
			table.AddCell("PUESTO: " + aux.Rows(inta).Item("PUESTO"))
			table.AddCell("SALARIO DIARIO: " + aux.Rows(inta).Item("SALARIO_DIARIO").ToString)
			table.AddCell("SUELDO BRUTO: " + aux.Rows(inta).Item("TOTAL_PAGO_NOMINAL").ToString)
			table.AddCell("TOTAL PERCEPCIONES: " + aux.Rows(inta).Item("TOTAL_PERCEPCIONES").ToString)
			table.AddCell("TOTAL DEDUCCIONES: " + aux.Rows(inta).Item("TOTAL_DEDUCCIONES").ToString)
			table.AddCell("PAGO TOTAL: " + aux.Rows(inta).Item("TOTAL").ToString)
			table.AddCell("PAGO TOTAL LETRAS: " + obj.EnLetras(aux.Rows(inta).Item("TOTAL")))
			table.AddCell("            ")
			table.AddCell("            ")

			inta += 1
		End While
		inta = 0

		pdfdoc.Add(table)

		pdfdoc.Close()
	End Sub
End Class