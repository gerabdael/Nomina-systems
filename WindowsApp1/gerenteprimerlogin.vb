Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class gerenteprimerlogin

	Private Sub gerenteprimerlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'da el usuario y contra para poder llenar la tabla pero no son visibles


		Dim tablaxs As New DataTable

		Dim objs As New EnlaceBD
		Dim obj As New EnlaceBD
		Dim tablax As New DataTable
		tablax = objs.Get_loged(Form1.user.Text, Form1.pass.Text)

		ListBox1.DataSource = tablax

		ListBox1.DisplayMember = "fullname"

		Dim inti As Integer = objs.getIdEmpresaNow(Form1.user.Text, Form1.pass.Text)
		Dim inti2 = objs.GetIdEmpleado(Form1.user.Text, Form1.pass.Text)

		Dim tabla3x As DataTable = objs.getdeptofromgerente(inti2)
		Dim iddeptos As Integer = tabla3x.Rows(0).Item("iddepto")

		TextBox4.Text = tabla3x.Rows(0).Item("nombredepto")
		TextBox5.Text = iddeptos.ToString()
		Dim tablax2 As New DataTable
		tablax2 = obj.VerEmpleadosGerentito(inti, iddeptos)

		DataGridView1.DataSource = tablax2


	End Sub

	Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
		Dim datarow As DataGridViewRow
		Dim obj As New EnlaceBD
		datarow = DataGridView1.Rows(e.RowIndex)

		TextBox1.Text = datarow.Cells(1).Value
		TextBox2.Text = datarow.Cells(2).Value
		TextBox3.Text = datarow.Cells(0).Value
	End Sub



	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Form7.ShowDialog()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Recibos_de_Nómina.ShowDialog()
	End Sub

	Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		'imprimir
		Dim obj As New EnlaceBD
		Dim aux As DataTable

		Dim inti2 = obj.GetIdEmpleado(Form1.user.Text, Form1.pass.Text)

		Dim tabla3x As DataTable = obj.getdeptofromgerente(inti2)
		Dim iddeptos As Integer = tabla3x.Rows(0).Item("iddepto")

		Dim datee As Date = DateTimePicker1.Value.Date
		Dim datee2 As Date = DateTimePicker2.Value.Date

		aux = obj.VerNominasGenerales7(iddeptos, datee.ToString("yyyy-MM-dd"), datee2.ToString("yyyy-MM-dd"))
		Dim pdfdoc As New Document()
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfdoc, New FileStream("C.pdf", FileMode.Create))
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