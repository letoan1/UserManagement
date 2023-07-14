Imports System.Globalization
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Cryptography
Imports Model

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
        departmentBox.DropDownStyle = ComboBoxStyle.DropDownList
        Dim departments As String() = {"IT", "HR", "Sale", "Dev"}
        departmentBox.DataSource = departments
        Me.panelSignup.Hide()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Function ValidateTextBox(textBox As TextBox, errorLabel As Label, Optional maxLength As Integer = Integer.MaxValue, Optional minLength As Integer = 0) As String
        Dim text = textBox.Text.Trim()

        If String.IsNullOrEmpty(text) Then
            errorLabel.Text = "This field is required."
            errorLabel.Visible = True
            Return Nothing
        End If

        If text.Length > maxLength Then
            errorLabel.Text = $"Maximum length is {maxLength}."
            errorLabel.Visible = True
            Return Nothing
        ElseIf (text.Length < minLength) Then
            errorLabel.Text = $"Miximum length is {minLength}."
            errorLabel.Visible = True
            Return Nothing
        End If

        errorLabel.Visible = False
        Return text
    End Function

    Private Function ValidateComboBox(comboBox As ComboBox, errorLabel As Label, allowedValues As String()) As String
        Dim selectedValue = comboBox.SelectedItem?.ToString()

        If Not allowedValues.Contains(selectedValue) Then
            errorLabel.Text = $"Invalid value. Allowed values: {String.Join(", ", allowedValues)}."
            errorLabel.Visible = True
            Return Nothing
        End If
        Return selectedValue
    End Function

    Private Function ValidateDateTimePicker(dateTimePicker As DateTimePicker, errorLabel As Label) As Date?
        Dim selectedDate = dateTimePicker.Value.Date

        If selectedDate > Date.Today Then
            errorLabel.Text = "Date of birth cannot be in the future."
            errorLabel.Visible = True
            Return Nothing
        End If

        errorLabel.Visible = False

        Return selectedDate
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Dim name = ValidateTextBox(fullNameBox, nameErrorLabel, maxLength:=50)
        Dim dob = ValidateDateTimePicker(dateOfBirthBox, dobErrorLabel)
        Dim address = ValidateTextBox(addressBox, addressErrorLabel, maxLength:=50)
        Dim department = ValidateComboBox(departmentBox, departmentErrorLabel, {"IT", "HR", "Sale", "Dev"})
        Dim position = ValidateTextBox(positionBox, positionErrorLabel, maxLength:=50)
        Dim note = noteBox.Text.Trim()
        Dim user_name = ValidateTextBox(nameSignup, usernameErrorLabel, maxLength:=50)
        Dim pass = ValidateTextBox(pwSignup, pwErrorLabel, maxLength:=50, minLength:=8)

        If name Is Nothing OrElse dob Is Nothing OrElse address Is Nothing OrElse department Is Nothing OrElse position Is Nothing OrElse note Is Nothing Then
            Return
        End If


        Dim result As DialogResult
        Dim newId As Integer
        Dim dataAccess As New DataAccess()

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
                If nameSignup.Visible = True And pwSignup.Visible = True Then
                    DataAccess.SignUp(user_name, pass)
                End If
            Else
                Form1.Show()
            End If
        End If

        Me.Close()
    End Sub
    Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles fullNameBox.Leave, dateOfBirthBox.Leave, addressBox.Leave, departmentBox.Leave, positionBox.Leave, noteBox.Leave
        Dim control = DirectCast(sender, Control)
        Dim errorLabel = DirectCast(control.Tag, Label)

        If TypeOf control Is TextBox AndAlso Not String.IsNullOrEmpty(control.Text) Then
            Select Case control.Name
                Case "fullNameBox"
                    ValidateTextBox(fullNameBox, nameErrorLabel, maxLength:=50)
                Case "addressBox"
                    ValidateTextBox(addressBox, addressErrorLabel, maxLength:=50)
                Case "positionBox"
                    ValidateTextBox(positionBox, positionErrorLabel, maxLength:=50)
                Case "nameSignup"
                    ValidateTextBox(nameSignup, usernameErrorLabel, maxLength:=50)
                Case "pwSignup"
                    ValidateTextBox(pwSignup, pwErrorLabel, maxLength:=50, minLength:=8)
            End Select
        ElseIf TypeOf control Is ComboBox Then
            ValidateComboBox(DirectCast(control, ComboBox), errorLabel, {"IT", "HR", "Sale", "Dev"})
        ElseIf TypeOf control Is DateTimePicker Then
            ValidateDateTimePicker(DirectCast(control, DateTimePicker), dobErrorLabel)
        End If
    End Sub

    Private Sub F5ToSave(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            btnSave_Click(sender, e)
        End If
    End Sub

    Private Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        panelSignup.Visible = Not panelSignup.Visible
    End Sub
End Class
