<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuildLibrary
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
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstFuncs = New System.Windows.Forms.ListBox()
        Me.txtFunc = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkFinish = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(404, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(196, 22)
        Me.txtName.TabIndex = 0
        Me.txtName.Text = "NewLib"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(326, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Library Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(204, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Function Listings"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lstFuncs
        '
        Me.lstFuncs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFuncs.FormattingEnabled = True
        Me.lstFuncs.ItemHeight = 16
        Me.lstFuncs.Location = New System.Drawing.Point(11, 21)
        Me.lstFuncs.Name = "lstFuncs"
        Me.lstFuncs.Size = New System.Drawing.Size(205, 388)
        Me.lstFuncs.TabIndex = 3
        '
        'txtFunc
        '
        Me.txtFunc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFunc.Location = New System.Drawing.Point(222, 53)
        Me.txtFunc.Multiline = True
        Me.txtFunc.Name = "txtFunc"
        Me.txtFunc.ReadOnly = True
        Me.txtFunc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFunc.Size = New System.Drawing.Size(378, 356)
        Me.txtFunc.TabIndex = 4
        Me.txtFunc.WordWrap = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(515, 415)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 22)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Cacnel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkFinish
        '
        Me.chkFinish.AutoSize = True
        Me.chkFinish.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFinish.Location = New System.Drawing.Point(15, 418)
        Me.chkFinish.Name = "chkFinish"
        Me.chkFinish.Size = New System.Drawing.Size(155, 20)
        Me.chkFinish.TabIndex = 6
        Me.chkFinish.Text = "Compiled Library"
        Me.chkFinish.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(424, 415)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 22)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Create"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(222, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(378, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Function Source Code"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmBuildLibrary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(612, 447)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.chkFinish)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtFunc)
        Me.Controls.Add(Me.lstFuncs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(628, 485)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(628, 485)
        Me.Name = "frmBuildLibrary"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Library Tools - Create New"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lstFuncs As ListBox
    Friend WithEvents txtFunc As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents chkFinish As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
End Class
