Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Model
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form1
    Dim table As New DataTable()

    Public Function ShowTime()
        Dim displayDate As String
        displayDate = $"Today: {Date.Now.ToString("yyyy/MM/dd")}"
        Return displayDate
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dataAccess As New DataAccess()
        DataAccess.ConnectionDatabase()

        dateLabel.Text = ShowTime()

        table.Columns.Add("ID", GetType(Integer))
        table.Columns.Add("Họ Tên", GetType(String))
        table.Columns.Add("Năm sinh", GetType(Date))
        table.Columns.Add("Địa chỉ", GetType(String))
        table.Columns.Add("Bộ phận", GetType(String))
        table.Columns.Add("Chức vụ", GetType(String))
        table.Columns.Add("Ghi chú", GetType(String))

        LoadData()

        tableView.DataSource = table

        tableView.AutoGenerateColumns = True
        tableView.AllowUserToAddRows = False
        tableView.ReadOnly = True

        Dim role As String = DataAccess.GetRole()
        If role = "viewer" Then
            Me.createBtn.Hide()
            Me.btnImport.Hide()
            Me.btnExport.Hide()
            Me.btnExportPDF.Hide()
            Me.editBtn.Hide()
            Me.deleteBtn.Hide()
        End If

    End Sub

    Private Sub LoadData()
        Dim persons As List(Of Person) = DataAccess.GetAllPersons()

        For Each person As Person In persons
            table.Rows.Add(person.id, person.fullName, person.dateOfBirth, person.address, person.department, person.position, person.note)
        Next
    End Sub

    Private Sub ExportToPdf(fileName As String)
        Dim document As New Document()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(fileName, FileMode.Create))
        document.Open()

        Dim pdfTable As New PdfPTable(table.Columns.Count)

        For Each column As DataColumn In table.Columns
            Dim cell As New PdfPCell(New Phrase(column.ColumnName))
            If column.ColumnName = "Năm sinh" Then
                cell.Phrase = New Phrase("Năm sinh")
            End If
            pdfTable.AddCell(cell)
        Next

        For Each row As DataRow In table.Rows
            For Each item As Object In row.ItemArray
                Dim cell As New PdfPCell(New Phrase(If(TypeOf item Is Date, DirectCast(item, Date).ToString("MM/dd/yyyy"), If(item Is DBNull.Value, "", item.ToString()))))
                pdfTable.AddCell(cell)
            Next
        Next

        document.Add(pdfTable)
        document.Close()

        MessageBox.Show("Export completed successfully.", "Export file PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        Dim query As String = searchBox.Text.Trim()
        If query <> String.Empty Then
            Dim view As New DataView(table)

            view.RowFilter = $"[Họ Tên] like '%{query}%'"
            tableView.DataSource = view
        Else

            tableView.DataSource = table
        End If
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles createBtn.Click
        Dim form2 As New Form2()
        form2.Show(Me)
        Me.Hide()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles editBtn.Click
        If tableView.SelectedRows.Count > 0 Then
            Dim selectedrow = tableView.SelectedRows(0)
            Dim id = CInt(selectedrow.Cells("id").Value)
            Dim name = selectedrow.Cells("họ tên").Value.ToString()
            Dim dob = selectedrow.Cells("năm sinh").Value.ToString()
            Dim address = selectedrow.Cells("địa chỉ").Value.ToString()
            Dim department = selectedrow.Cells("bộ phận").Value.ToString()
            Dim position = selectedrow.Cells("chức vụ").Value.ToString()
            Dim note = selectedrow.Cells("ghi chú").Value.ToString()

            Dim form2 As New Form2(id, name, dob, address, department, position, note)

            form2.Show()
            Me.Hide()
        Else
            MessageBox.Show("Please select a record to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
        If tableView.SelectedRows.Count > 0 Then
            Dim name As String = tableView.SelectedRows(0).Cells("Họ Tên").Value.ToString()
            Dim result = MessageBox.Show($"Are you sure you want to delete '{name}'?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                For Each row As DataGridViewRow In tableView.SelectedRows
                    Dim id = CInt(row.Cells("ID").Value)
                    Dim dataAccess As New DataAccess()
                    DataAccess.DeletePerson(id)
                    tableView.Rows.Remove(row)
                Next
            End If
        Else
            MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub UpdateRecord(id As Integer, name As String, dob As String, address As String, department As String, position As String, note As String)
        For Each row As DataRow In table.Rows
            If CInt(row("ID")) = id Then
                row("Họ Tên") = name
                row("Năm sinh") = dob
                row("Địa chỉ") = address
                row("Bộ phận") = department
                row("Chức vụ") = position
                row("Ghi chú") = note

                Dim person As New Person(id, name, Date.Parse(dob), address, department, position, note)
                Dim dataAccess As New DataAccess()

                If person IsNot Nothing Then
                    DataAccess.UpdatePerson(person)
                End If
                Exit For
            End If
        Next
    End Sub

    Public Function CreateUser(name As String, dob As String, address As String, department As String, position As String, note As String)
        Dim id = table.Rows.Count + 1
        Dim person As New Person(id, name, Date.Parse(dob), address, department, position, note)
        Dim dataAccess As New DataAccess()

        If person IsNot Nothing Then
            If DataAccess.PersonExists(person.id) Then
                Dim newId As Integer = DataAccess.GetNewId()
                person.id = newId
            End If
            DataAccess.InsertPerson(person)
            table.Rows.Add(person.id, person.fullName, person.dateOfBirth, person.address, person.department, person.position, person.note)
        End If

        Return id
    End Function

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        If saveFileDialog.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        Using writer As New StreamWriter(saveFileDialog.FileName)
            Dim headers = table.Columns.Cast(Of DataColumn)().Select(Function(col) If(col.ColumnName = "Năm sinh", "Năm sinh", col.ColumnName))
            writer.WriteLine(String.Join(",", headers))

            For Each row As DataRow In table.Rows
                Dim fields = row.ItemArray.Select(Function(field) If(TypeOf field Is Date, DirectCast(field, Date).ToString("MM/dd/yyyy"), If(field Is DBNull.Value, "", field.ToString())))
                writer.WriteLine(String.Join(",", fields))
            Next
        End Using

        MessageBox.Show("Export completed successfully.", "Export file csv", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        If openFileDialog.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        Try
            Using reader As New StreamReader(openFileDialog.FileName)
                While reader.Peek() <> -1
                    Dim line As String = reader.ReadLine()
                    Dim row As String() = line.Split(","c)
                    Dim person As Person = Person.FromCsvRow(row)
                    Dim dataAccess As New DataAccess()
                    If person IsNot Nothing Then
                        If DataAccess.PersonExists(person.id) Then
                            Dim newId As Integer = DataAccess.GetNewId()
                            person.id = newId
                        End If
                        DataAccess.InsertPerson(person)
                        table.Rows.Add(person.id, person.fullName, person.dateOfBirth, person.address, person.department, person.position, person.note)
                    End If
                End While
            End Using

            MessageBox.Show("Import completed successfully.", "Import file csv", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error importing file: " & ex.Message, "Import file csv", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"

        If saveFileDialog.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        ExportToPdf(saveFileDialog.FileName)
    End Sub
End Class