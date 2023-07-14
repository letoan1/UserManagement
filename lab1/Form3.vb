Imports Model

Public Class Form3
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = usernameBox.Text.Trim()
        Dim pw As String = passwordBox.Text.Trim()

        Dim dataAccess As New DataAccess()

        If DataAccess.Login(username, pw) Then
            Form1.Show()
            Me.Hide()
        Else
            loginFailureLabel.Text = "* Invalid username or password !"
        End If
    End Sub
End Class