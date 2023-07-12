﻿Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form1
    Dim table As New DataTable()

    Public Function ShowTime()
        Dim displayDate As String
        displayDate = $"Today: {Date.Now.ToString("yyyy/MM/dd")}"
        Return displayDate
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectDatabase()

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

    End Sub

    Private Sub LoadData()
        Dim command As New SqlCommand("SELECT * FROM users", Connect)
        Dim adapter As New SqlDataAdapter(command)
        Dim dataset As New DataSet()
        adapter.Fill(dataset)

        For Each row As DataRow In dataset.Tables(0).Rows
            table.Rows.Add(row("id"), row("fullName"), row("dateOfBirth"), row("address"), row("department"), row("position"), row("note"))
        Next
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
            Dim selectedRow = tableView.SelectedRows(0)
            Dim id = CInt(selectedRow.Cells("ID").Value)
            Dim name = selectedRow.Cells("Họ Tên").Value.ToString()
            Dim dob = selectedRow.Cells("Năm sinh").Value.ToString()
            Dim address = selectedRow.Cells("Địa chỉ").Value.ToString()
            Dim department = selectedRow.Cells("Bộ phận").Value.ToString()
            Dim position = selectedRow.Cells("Chức vụ").Value.ToString()
            Dim note = selectedRow.Cells("Ghi chú").Value.ToString()

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
                    dataAccess.DeletePerson(id)
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
                    dataAccess.UpdatePerson(person)
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
            dataAccess.InsertPerson(person)
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
            Dim headers = table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName)
            writer.WriteLine(String.Join(" - ", headers))

            For Each row As DataRow In table.Rows
                Dim fields = row.ItemArray.Select(Function(field) If(field Is DBNull.Value, "", field.ToString()))
                writer.WriteLine(String.Join(" - ", fields))
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
                        dataAccess.InsertPerson(person)
                        table.Rows.Add(person.id, person.fullName, person.dateOfBirth, person.address, person.department, person.position, person.note)
                    End If
                End While
            End Using

            MessageBox.Show("Import completed successfully.", "Import file csv", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error importing file: " & ex.Message, "Import file csv", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class