Imports System.Globalization
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Cryptography
Imports Model

Public Class DataInteraction
    Private id As Integer
    Public Sub New(Optional id As Integer = 0, Optional name As String = "", Optional birthDay As String = "", Optional address As String = "", Optional department As String = "", Optional position As String = "", Optional note As String = "")
        InitializeComponent()
        Me.id = id
        fullNameBox.Text = name
        dateOfBirthBox.Text = birthDay
        addressBox.Text = address
        departmentBox.Text = department
        positionBox.Text = position
        noteBox.Text = note
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateLabel.Text = HomePage.ShowTime()
        departmentBox.DropDownStyle = ComboBoxStyle.DropDownList
        Me.panelSignup.Hide()
    End Sub

    'click button exit
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        HomePage.Show()
        Me.Hide()
    End Sub

    'validate textbox
    '@params textbox, errorLabel, maxLength, minLength
    '@return boolean type
    Private Function IsValidText(textBox As TextBox, errorLabel As Label, Optional maxLength As Integer = Integer.MaxValue, Optional minLength As Integer = 0) As Boolean
        Dim text = textBox.Text.Trim()

        If String.IsNullOrEmpty(text) Then
            errorLabel.Text = "This field is required."
            errorLabel.Visible = True
            Return False
        End If

        If text.Length > maxLength Then
            errorLabel.Text = $"Maximum length is {maxLength}."
            errorLabel.Visible = True
            Return False
        ElseIf (text.Length < minLength) Then
            errorLabel.Text = $"Minimum length is {minLength}."
            errorLabel.Visible = True
            Return False
        End If

        errorLabel.Visible = False

        Return True
    End Function

    'validate combobox
    '@params comboBox, errorLabel, allowedValues
    '@return string
    Private Function ValidateComboBox(comboBox As ComboBox, errorLabel As Label, allowedValues As String()) As String
        Dim selectedValue = comboBox.SelectedItem?.ToString()

        If Not allowedValues.Contains(selectedValue) Then
            errorLabel.Text = $"Invalid value. Allowed values: {String.Join(", ", allowedValues)}."
            errorLabel.Visible = True
            Return Nothing
        End If

        Return selectedValue
    End Function

    'validate dateTimePicker
    '@params dateTimePicker, errorLabel
    '@return boolean type
    Private Function ValidateDateTimePicker(dateTimePicker As DateTimePicker, errorLabel As Label) As Boolean
        If dateTimePicker.Value > DateTime.Now Then
            errorLabel.Text = "Date cannot be in the future."
            errorLabel.Visible = True
            Return False
        Else
            errorLabel.Visible = False
            Return True
        End If

        errorLabel.Visible = False
    End Function

    Private Function CheckValidations() As Boolean
        Dim isValidInput = True

        isValidInput = isValidInput AndAlso IsValidText(fullNameBox, nameErrorLabel, maxLength:=50, minLength:=1)
        isValidInput = isValidInput AndAlso ValidateDateTimePicker(dateOfBirthBox, dobErrorLabel)
        isValidInput = isValidInput AndAlso IsValidText(addressBox, addressErrorLabel, maxLength:=50, minLength:=1)
        isValidInput = isValidInput AndAlso IsValidText(positionBox, positionErrorLabel, maxLength:=50, minLength:=1)

        Return isValidInput
    End Function

    'handle click button save
    '@output: save data
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Dim isValidInput = CheckValidations()

        Dim department = ValidateComboBox(departmentBox, departmentErrorLabel, {"IT", "HR", "Sale", "Dev"})
        Dim note = noteBox.Text.Trim()

        Dim user_name = If(nameSignup.Visible, IsValidText(nameSignup, usernameErrorLabel, maxLength:=50, minLength:=1), Nothing)
        Dim pass = If(pwSignup.Visible, IsValidText(pwSignup, pwErrorLabel, maxLength:=50, minLength:=8), Nothing)
        Dim role = If(comboboxRole.Visible, comboboxRole.Text, Nothing)

        If Not isValidInput Then
            Return
        End If

        Dim result = If(id > 0, MessageBox.Show("Are you sure you want to update this record?", "Confirm Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Question), MessageBox.Show("Are you sure you want to create this record?", "Confirm Create", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))

        If result = DialogResult.OK Then
    If id > 0 Then
                HomePage.UpdateRecord(id, fullNameBox.Text.Trim(), dateOfBirthBox.Value, addressBox.Text.Trim(), department.ToString(), positionBox.Text.Trim(), note)
            Else
                Dim newId = HomePage.CreateUser(fullNameBox.Text.Trim(), dateOfBirthBox.Value, addressBox.Text.Trim(), department.ToString(), positionBox.Text.Trim(), note)

                If user_name OrElse pass OrElse role IsNot Nothing Then
            DataAccess.SignUp(user_name, pass, role)
        End If
    End If
End If

Me.Close()
HomePage.Show()
    End Sub


    'handle when user press F5 on keyboard
    '@output: save data like button save
    Private Sub F5ToSave(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            btnSave_Click(sender, e)
        End If
    End Sub

    'handle toggle click button create in form
    Private Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        panelSignup.Visible = Not panelSignup.Visible
    End Sub


End Class
