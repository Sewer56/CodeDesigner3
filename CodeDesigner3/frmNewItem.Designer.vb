<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewItem
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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(226, 64)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(89, 27)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(321, 64)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 27)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(2, 34)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(73, 19)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "File Name:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(81, 38)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(329, 20)
        Me.txtName.TabIndex = 3
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(81, 12)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(329, 20)
        Me.txtPath.TabIndex = 5
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(2, 8)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(73, 19)
        Me.lblPath.TabIndex = 4
        Me.lblPath.Text = "File Path:"
        Me.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPath
        '
        Me.btnPath.Location = New System.Drawing.Point(416, 12)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(41, 20)
        Me.btnPath.TabIndex = 6
        Me.btnPath.Text = "..."
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmNewItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 108)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewItem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtPath As TextBox
    Friend WithEvents lblPath As Label
    Friend WithEvents btnPath As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
