<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.mainTitle = New System.Windows.Forms.Label()
        Me.dateLabel = New System.Windows.Forms.Label()
        Me.fullName = New System.Windows.Forms.Label()
        Me.address = New System.Windows.Forms.Label()
        Me.dateOfBirth = New System.Windows.Forms.Label()
        Me.department = New System.Windows.Forms.Label()
        Me.position = New System.Windows.Forms.Label()
        Me.note = New System.Windows.Forms.Label()
        Me.fullNameBox = New System.Windows.Forms.TextBox()
        Me.addressBox = New System.Windows.Forms.TextBox()
        Me.positionBox = New System.Windows.Forms.TextBox()
        Me.noteBox = New System.Windows.Forms.TextBox()
        Me.departmentBox = New System.Windows.Forms.ComboBox()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.exitBtn = New System.Windows.Forms.Button()
        Me.dateOfBirthBox = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'mainTitle
        '
        Me.mainTitle.AutoSize = True
        Me.mainTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTitle.Location = New System.Drawing.Point(76, 18)
        Me.mainTitle.Name = "mainTitle"
        Me.mainTitle.Size = New System.Drawing.Size(303, 17)
        Me.mainTitle.TabIndex = 0
        Me.mainTitle.Text = "MÀN HÌNH ĐĂNG KÍ/THAY ĐỔI NHÂN SỰ"
        '
        'dateLabel
        '
        Me.dateLabel.AutoSize = True
        Me.dateLabel.Location = New System.Drawing.Point(76, 49)
        Me.dateLabel.Name = "dateLabel"
        Me.dateLabel.Size = New System.Drawing.Size(101, 13)
        Me.dateLabel.TabIndex = 1
        Me.dateLabel.Text = "Today: 2023/07/10"
        '
        'fullName
        '
        Me.fullName.AutoSize = True
        Me.fullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fullName.Location = New System.Drawing.Point(134, 142)
        Me.fullName.Name = "fullName"
        Me.fullName.Size = New System.Drawing.Size(49, 13)
        Me.fullName.TabIndex = 2
        Me.fullName.Text = "Họ Tên"
        '
        'address
        '
        Me.address.AutoSize = True
        Me.address.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.address.Location = New System.Drawing.Point(134, 217)
        Me.address.Name = "address"
        Me.address.Size = New System.Drawing.Size(47, 13)
        Me.address.TabIndex = 3
        Me.address.Text = "Địa chỉ"
        '
        'dateOfBirth
        '
        Me.dateOfBirth.AutoSize = True
        Me.dateOfBirth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateOfBirth.Location = New System.Drawing.Point(134, 181)
        Me.dateOfBirth.Name = "dateOfBirth"
        Me.dateOfBirth.Size = New System.Drawing.Size(59, 13)
        Me.dateOfBirth.TabIndex = 4
        Me.dateOfBirth.Text = "Năm sinh"
        '
        'department
        '
        Me.department.AutoSize = True
        Me.department.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department.Location = New System.Drawing.Point(134, 257)
        Me.department.Name = "department"
        Me.department.Size = New System.Drawing.Size(54, 13)
        Me.department.TabIndex = 5
        Me.department.Text = "Bộ phận"
        '
        'position
        '
        Me.position.AutoSize = True
        Me.position.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.position.Location = New System.Drawing.Point(134, 297)
        Me.position.Name = "position"
        Me.position.Size = New System.Drawing.Size(54, 13)
        Me.position.TabIndex = 6
        Me.position.Text = "Chức vụ"
        '
        'note
        '
        Me.note.AutoSize = True
        Me.note.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.note.Location = New System.Drawing.Point(134, 344)
        Me.note.Name = "note"
        Me.note.Size = New System.Drawing.Size(51, 13)
        Me.note.TabIndex = 7
        Me.note.Text = "Ghi chú"
        '
        'fullNameBox
        '
        Me.fullNameBox.Location = New System.Drawing.Point(229, 139)
        Me.fullNameBox.MaxLength = 50
        Me.fullNameBox.Name = "fullNameBox"
        Me.fullNameBox.Size = New System.Drawing.Size(469, 20)
        Me.fullNameBox.TabIndex = 8
        '
        'addressBox
        '
        Me.addressBox.Location = New System.Drawing.Point(229, 217)
        Me.addressBox.Name = "addressBox"
        Me.addressBox.Size = New System.Drawing.Size(469, 20)
        Me.addressBox.TabIndex = 10
        '
        'positionBox
        '
        Me.positionBox.Location = New System.Drawing.Point(229, 294)
        Me.positionBox.Name = "positionBox"
        Me.positionBox.Size = New System.Drawing.Size(469, 20)
        Me.positionBox.TabIndex = 12
        '
        'noteBox
        '
        Me.noteBox.Location = New System.Drawing.Point(231, 343)
        Me.noteBox.MaxLength = 200
        Me.noteBox.Multiline = True
        Me.noteBox.Name = "noteBox"
        Me.noteBox.Size = New System.Drawing.Size(466, 95)
        Me.noteBox.TabIndex = 13
        '
        'departmentBox
        '
        Me.departmentBox.FormattingEnabled = True
        Me.departmentBox.Items.AddRange(New Object() {"IT", "HR", "Sale", "Dev"})
        Me.departmentBox.Location = New System.Drawing.Point(229, 254)
        Me.departmentBox.Name = "departmentBox"
        Me.departmentBox.Size = New System.Drawing.Size(469, 21)
        Me.departmentBox.TabIndex = 14
        '
        'saveBtn
        '
        Me.saveBtn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.saveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveBtn.Location = New System.Drawing.Point(229, 470)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(101, 33)
        Me.saveBtn.TabIndex = 15
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = False
        '
        'exitBtn
        '
        Me.exitBtn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.exitBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitBtn.Location = New System.Drawing.Point(379, 470)
        Me.exitBtn.Name = "exitBtn"
        Me.exitBtn.Size = New System.Drawing.Size(101, 33)
        Me.exitBtn.TabIndex = 16
        Me.exitBtn.Text = "Exit"
        Me.exitBtn.UseVisualStyleBackColor = False
        '
        'dateOfBirthBox
        '
        Me.dateOfBirthBox.CustomFormat = "yyyy/MM/dd"
        Me.dateOfBirthBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateOfBirthBox.Location = New System.Drawing.Point(229, 181)
        Me.dateOfBirthBox.Name = "dateOfBirthBox"
        Me.dateOfBirthBox.Size = New System.Drawing.Size(469, 20)
        Me.dateOfBirthBox.TabIndex = 17
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 637)
        Me.Controls.Add(Me.dateOfBirthBox)
        Me.Controls.Add(Me.exitBtn)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.departmentBox)
        Me.Controls.Add(Me.noteBox)
        Me.Controls.Add(Me.positionBox)
        Me.Controls.Add(Me.addressBox)
        Me.Controls.Add(Me.fullNameBox)
        Me.Controls.Add(Me.note)
        Me.Controls.Add(Me.position)
        Me.Controls.Add(Me.department)
        Me.Controls.Add(Me.dateOfBirth)
        Me.Controls.Add(Me.address)
        Me.Controls.Add(Me.fullName)
        Me.Controls.Add(Me.dateLabel)
        Me.Controls.Add(Me.mainTitle)
        Me.KeyPreview = True
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mainTitle As Label
    Friend WithEvents dateLabel As Label
    Friend WithEvents fullName As Label
    Friend WithEvents address As Label
    Friend WithEvents dateOfBirth As Label
    Friend WithEvents department As Label
    Friend WithEvents position As Label
    Friend WithEvents note As Label
    Friend WithEvents fullNameBox As TextBox
    Friend WithEvents addressBox As TextBox
    Friend WithEvents positionBox As TextBox
    Friend WithEvents noteBox As TextBox
    Friend WithEvents departmentBox As ComboBox
    Friend WithEvents saveBtn As Button
    Friend WithEvents exitBtn As Button
    Friend WithEvents dateOfBirthBox As DateTimePicker
End Class
