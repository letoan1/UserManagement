<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainTitle = New System.Windows.Forms.Label()
        Me.usernameLabel = New System.Windows.Forms.Label()
        Me.usernameBox = New System.Windows.Forms.TextBox()
        Me.passwordLabel = New System.Windows.Forms.Label()
        Me.passwordBox = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.loginFailureLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'mainTitle
        '
        Me.mainTitle.AutoSize = True
        Me.mainTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTitle.Location = New System.Drawing.Point(328, 38)
        Me.mainTitle.Name = "mainTitle"
        Me.mainTitle.Size = New System.Drawing.Size(150, 17)
        Me.mainTitle.TabIndex = 0
        Me.mainTitle.Text = "QUẢN LÝ NHÂN SỰ"
        '
        'usernameLabel
        '
        Me.usernameLabel.AutoSize = True
        Me.usernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usernameLabel.Location = New System.Drawing.Point(130, 98)
        Me.usernameLabel.Name = "usernameLabel"
        Me.usernameLabel.Size = New System.Drawing.Size(65, 13)
        Me.usernameLabel.TabIndex = 1
        Me.usernameLabel.Text = "UserName"
        '
        'usernameBox
        '
        Me.usernameBox.Location = New System.Drawing.Point(225, 95)
        Me.usernameBox.Name = "usernameBox"
        Me.usernameBox.Size = New System.Drawing.Size(284, 20)
        Me.usernameBox.TabIndex = 2
        '
        'passwordLabel
        '
        Me.passwordLabel.AutoSize = True
        Me.passwordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordLabel.Location = New System.Drawing.Point(130, 144)
        Me.passwordLabel.Name = "passwordLabel"
        Me.passwordLabel.Size = New System.Drawing.Size(61, 13)
        Me.passwordLabel.TabIndex = 3
        Me.passwordLabel.Text = "Password"
        '
        'passwordBox
        '
        Me.passwordBox.Location = New System.Drawing.Point(225, 137)
        Me.passwordBox.Name = "passwordBox"
        Me.passwordBox.Size = New System.Drawing.Size(284, 20)
        Me.passwordBox.TabIndex = 4
        Me.passwordBox.UseSystemPasswordChar = True
        '
        'btnLogin
        '
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(298, 192)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(103, 30)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "LOGIN"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'loginFailureLabel
        '
        Me.loginFailureLabel.AutoSize = True
        Me.loginFailureLabel.ForeColor = System.Drawing.Color.Red
        Me.loginFailureLabel.Location = New System.Drawing.Point(222, 174)
        Me.loginFailureLabel.Name = "loginFailureLabel"
        Me.loginFailureLabel.Size = New System.Drawing.Size(0, 13)
        Me.loginFailureLabel.TabIndex = 6
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.loginFailureLabel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.passwordBox)
        Me.Controls.Add(Me.passwordLabel)
        Me.Controls.Add(Me.usernameBox)
        Me.Controls.Add(Me.usernameLabel)
        Me.Controls.Add(Me.mainTitle)
        Me.Name = "Form3"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mainTitle As Label
    Friend WithEvents usernameLabel As Label
    Friend WithEvents usernameBox As TextBox
    Friend WithEvents passwordLabel As Label
    Friend WithEvents passwordBox As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents loginFailureLabel As Label
End Class
