<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuildArchive
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chkFinish = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtFunc = New System.Windows.Forms.TextBox()
        Me.lstLibs = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lstFuncs = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLib = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(431, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(378, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Function Source Code"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(633, 390)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 22)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Create"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chkFinish
        '
        Me.chkFinish.AutoSize = True
        Me.chkFinish.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFinish.Location = New System.Drawing.Point(226, 360)
        Me.chkFinish.Name = "chkFinish"
        Me.chkFinish.Size = New System.Drawing.Size(155, 20)
        Me.chkFinish.TabIndex = 15
        Me.chkFinish.Text = "Compiled Library"
        Me.chkFinish.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(724, 390)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 22)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Cacnel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtFunc
        '
        Me.txtFunc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFunc.Location = New System.Drawing.Point(434, 24)
        Me.txtFunc.Multiline = True
        Me.txtFunc.Name = "txtFunc"
        Me.txtFunc.ReadOnly = True
        Me.txtFunc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFunc.Size = New System.Drawing.Size(378, 356)
        Me.txtFunc.TabIndex = 13
        '
        'lstLibs
        '
        Me.lstLibs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLibs.FormattingEnabled = True
        Me.lstLibs.ItemHeight = 16
        Me.lstLibs.Location = New System.Drawing.Point(12, 24)
        Me.lstLibs.Name = "lstLibs"
        Me.lstLibs.Size = New System.Drawing.Size(205, 388)
        Me.lstLibs.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(204, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Library Listings"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(225, 390)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Archive Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(303, 390)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(324, 22)
        Me.txtName.TabIndex = 9
        Me.txtName.Text = "NewLib"
        '
        'lstFuncs
        '
        Me.lstFuncs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFuncs.FormattingEnabled = True
        Me.lstFuncs.ItemHeight = 16
        Me.lstFuncs.Location = New System.Drawing.Point(223, 24)
        Me.lstFuncs.Name = "lstFuncs"
        Me.lstFuncs.Size = New System.Drawing.Size(205, 276)
        Me.lstFuncs.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(223, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(205, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Function Listings"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(225, 306)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Library Name:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLib
        '
        Me.txtLib.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLib.Location = New System.Drawing.Point(303, 306)
        Me.txtLib.Name = "txtLib"
        Me.txtLib.Size = New System.Drawing.Size(125, 22)
        Me.txtLib.TabIndex = 20
        Me.txtLib.Text = "MyLib"
        '
        'frmBuildArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(822, 423)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLib)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstFuncs)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.chkFinish)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtFunc)
        Me.Controls.Add(Me.lstLibs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(838, 461)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(838, 461)
        Me.Name = "frmBuildArchive"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Library Tools - Create Archive"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents chkFinish As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtFunc As TextBox
    Friend WithEvents lstLibs As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lstFuncs As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLib As TextBox
End Class
