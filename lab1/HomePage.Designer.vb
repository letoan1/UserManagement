<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HomePage
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
        Me.components = New System.ComponentModel.Container()
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.mainTitle = New System.Windows.Forms.Label()
        Me.dateLabel = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.searchBox = New System.Windows.Forms.TextBox()
        Me.tableView = New System.Windows.Forms.DataGridView()
        Me.deleteBtn = New System.Windows.Forms.Button()
        Me.editBtn = New System.Windows.Forms.Button()
        Me.createBtn = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnExportPDF = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.usernameLabel = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        CType(Me.tableView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'searchBtn
        '
        Me.searchBtn.BackColor = System.Drawing.Color.IndianRed
        Me.searchBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.searchBtn.Location = New System.Drawing.Point(719, 112)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(102, 27)
        Me.searchBtn.TabIndex = 0
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = False
        '
        'mainTitle
        '
        Me.mainTitle.AutoSize = True
        Me.mainTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTitle.Location = New System.Drawing.Point(69, 24)
        Me.mainTitle.Name = "mainTitle"
        Me.mainTitle.Size = New System.Drawing.Size(230, 17)
        Me.mainTitle.TabIndex = 1
        Me.mainTitle.Text = "MÀN HÌNH QUẢN LÝ NHÂN SỰ"
        '
        'dateLabel
        '
        Me.dateLabel.AutoSize = True
        Me.dateLabel.Location = New System.Drawing.Point(69, 52)
        Me.dateLabel.Name = "dateLabel"
        Me.dateLabel.Size = New System.Drawing.Size(101, 13)
        Me.dateLabel.TabIndex = 2
        Me.dateLabel.Text = "Today: 2023/07/10"
        '
        'searchBox
        '
        Me.searchBox.Location = New System.Drawing.Point(437, 112)
        Me.searchBox.Multiline = True
        Me.searchBox.Name = "searchBox"
        Me.searchBox.Size = New System.Drawing.Size(263, 24)
        Me.searchBox.TabIndex = 3
        '
        'tableView
        '
        Me.tableView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tableView.Location = New System.Drawing.Point(72, 178)
        Me.tableView.Name = "tableView"
        Me.tableView.Size = New System.Drawing.Size(749, 249)
        Me.tableView.TabIndex = 4
        '
        'deleteBtn
        '
        Me.deleteBtn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.deleteBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteBtn.Location = New System.Drawing.Point(724, 455)
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.Size = New System.Drawing.Size(97, 34)
        Me.deleteBtn.TabIndex = 5
        Me.deleteBtn.Text = "Delete"
        Me.deleteBtn.UseVisualStyleBackColor = False
        '
        'editBtn
        '
        Me.editBtn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.editBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editBtn.Location = New System.Drawing.Point(603, 455)
        Me.editBtn.Name = "editBtn"
        Me.editBtn.Size = New System.Drawing.Size(97, 34)
        Me.editBtn.TabIndex = 6
        Me.editBtn.Text = "Edit"
        Me.editBtn.UseVisualStyleBackColor = False
        '
        'createBtn
        '
        Me.createBtn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.createBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createBtn.Location = New System.Drawing.Point(485, 455)
        Me.createBtn.Name = "createBtn"
        Me.createBtn.Size = New System.Drawing.Size(97, 34)
        Me.createBtn.TabIndex = 7
        Me.createBtn.Text = "Create"
        Me.createBtn.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.Gold
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(230, 455)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(97, 34)
        Me.btnExport.TabIndex = 8
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnImport
        '
        Me.btnImport.BackColor = System.Drawing.Color.Gold
        Me.btnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Location = New System.Drawing.Point(72, 455)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(97, 34)
        Me.btnImport.TabIndex = 9
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = False
        '
        'btnExportPDF
        '
        Me.btnExportPDF.BackColor = System.Drawing.Color.Gold
        Me.btnExportPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportPDF.Location = New System.Drawing.Point(359, 455)
        Me.btnExportPDF.Name = "btnExportPDF"
        Me.btnExportPDF.Size = New System.Drawing.Size(97, 34)
        Me.btnExportPDF.TabIndex = 10
        Me.btnExportPDF.Text = "PDF"
        Me.btnExportPDF.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Location = New System.Drawing.Point(72, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(749, 10)
        Me.Panel1.TabIndex = 11
        '
        'usernameLabel
        '
        Me.usernameLabel.AutoSize = True
        Me.usernameLabel.Location = New System.Drawing.Point(69, 115)
        Me.usernameLabel.Name = "usernameLabel"
        Me.usernameLabel.Size = New System.Drawing.Size(39, 13)
        Me.usernameLabel.TabIndex = 12
        Me.usernameLabel.Text = "Label1"
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.IndianRed
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.SystemColors.InfoText
        Me.btnLogout.Location = New System.Drawing.Point(72, 131)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 23)
        Me.btnLogout.TabIndex = 13
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1109, 570)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.usernameLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnExportPDF)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.createBtn)
        Me.Controls.Add(Me.editBtn)
        Me.Controls.Add(Me.deleteBtn)
        Me.Controls.Add(Me.tableView)
        Me.Controls.Add(Me.searchBox)
        Me.Controls.Add(Me.dateLabel)
        Me.Controls.Add(Me.mainTitle)
        Me.Controls.Add(Me.searchBtn)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.tableView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents searchBtn As Button
    Friend WithEvents mainTitle As Label
    Friend WithEvents dateLabel As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents searchBox As TextBox
    Friend WithEvents tableView As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents Panel1 As Panel
    Public WithEvents deleteBtn As Button
    Public WithEvents editBtn As Button
    Public WithEvents createBtn As Button
    Public WithEvents btnExport As Button
    Public WithEvents btnImport As Button
    Public WithEvents btnExportPDF As Button
    Friend WithEvents usernameLabel As Label
    Friend WithEvents btnLogout As Button
End Class
