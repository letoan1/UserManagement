Imports System.Globalization
Imports System.Security.Cryptography

Public Class Form2
    Private id As Integer
    Public Sub New(Optional id As Integer = 0, Optional name As String = "", Optional dob As String = "", Optional address As String = "", Optional department As String = "", Optional position As String = "", Optional note As String = "")
        InitializeComponent()
        Me.id = id
        fullNameBox.Text = name
        dateOfBirthBox.Text = dob
        addressBox.Text = address
        departmentBox.Text = department
        positionBox.Text = position
        noteBox.Text = note
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateLabel.Text = Form1.ShowTime()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Form1.Show()
        Me.Hide()
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Dim name = fullNameBox.Text.Trim()
        Dim dob = dateOfBirthBox.Text.Trim()
        Dim address = addressBox.Text.Trim()
        Dim department = departmentBox.Text.Trim()
        Dim position = positionBox.Text.Trim()
        Dim note = noteBox.Text.Trim()

        Dim result As DialogResult
        Dim newId As Integer

        If id > 0 Then
            result = MessageBox.Show("Are you sure you want to update this record?", "Confirm Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                Form1.UpdateRecord(id, name, dob, address, department, position, note)
                Form1.Show()
            Else
                Form1.Show()
            End If
        Else
            result = MessageBox.Show("Are you sure you want to create this record?", "Confirm Create", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                Form1.Show()
                newId = Form1.CreateUser(name, dob, address, department, position, note)
            Else
                Form1.Show()
            End If
        End If

        Me.Close()
    End Sub

    Private Sub F5ToSave(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            btnSave_Click(sender, e)
        End If
    End Sub
End Class
