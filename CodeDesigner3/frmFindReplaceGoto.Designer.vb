<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindReplaceGoto
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.txtReplace = New System.Windows.Forms.TextBox()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.chkCase = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(351, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 21)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Find Next"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(351, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 21)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Replace"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(351, 66)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(79, 21)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Replace All"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(267, 118)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(79, 21)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Goto"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Find:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Replace With:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(77, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Line Number:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFind
        '
        Me.txtFind.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFind.Location = New System.Drawing.Point(106, 12)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(239, 22)
        Me.txtFind.TabIndex = 7
        '
        'txtReplace
        '
        Me.txtReplace.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReplace.Location = New System.Drawing.Point(106, 40)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.Size = New System.Drawing.Size(239, 22)
        Me.txtReplace.TabIndex = 8
        '
        'txtLine
        '
        Me.txtLine.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLine.Location = New System.Drawing.Point(171, 118)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(90, 22)
        Me.txtLine.TabIndex = 9
        Me.txtLine.Text = "0"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(351, 118)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(79, 21)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Close"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'chkCase
        '
        Me.chkCase.AutoSize = True
        Me.chkCase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCase.Location = New System.Drawing.Point(262, 68)
        Me.chkCase.Name = "chkCase"
        Me.chkCase.Size = New System.Drawing.Size(83, 17)
        Me.chkCase.TabIndex = 11
        Me.chkCase.Text = "Match Case"
        Me.chkCase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCase.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(220, 91)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(126, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Search Entire Project"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmFindReplaceGoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 151)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.chkCase)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtLine)
        Me.Controls.Add(Me.txtReplace)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFindReplaceGoto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Find / Replace / Goto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFind As TextBox
    Friend WithEvents txtReplace As TextBox
    Friend WithEvents txtLine As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents chkCase As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
