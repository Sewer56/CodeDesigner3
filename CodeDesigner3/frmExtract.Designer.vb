<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtract
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtGoto = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStop = New System.Windows.Forms.TextBox()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RamView1 = New CodeDesigner3.RAMView()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.txtGoto)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtStop)
        Me.GroupBox1.Controls.Add(Me.txtStart)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 316)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 101)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(110, 19)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(67, 20)
        Me.Button5.TabIndex = 30
        Me.Button5.Text = "Goto"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtGoto
        '
        Me.txtGoto.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGoto.Location = New System.Drawing.Point(8, 19)
        Me.txtGoto.MaxLength = 8
        Me.txtGoto.Name = "txtGoto"
        Me.txtGoto.Size = New System.Drawing.Size(96, 21)
        Me.txtGoto.TabIndex = 29
        Me.txtGoto.Text = "00000000"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(565, 66)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 27)
        Me.Button4.TabIndex = 28
        Me.Button4.Text = "Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(476, 66)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 27)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Extract"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "End Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(107, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Start Address"
        '
        'txtStop
        '
        Me.txtStop.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStop.Location = New System.Drawing.Point(8, 72)
        Me.txtStop.MaxLength = 8
        Me.txtStop.Name = "txtStop"
        Me.txtStop.Size = New System.Drawing.Size(96, 21)
        Me.txtStop.TabIndex = 23
        '
        'txtStart
        '
        Me.txtStart.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStart.Location = New System.Drawing.Point(8, 46)
        Me.txtStart.MaxLength = 8
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(96, 21)
        Me.txtStart.TabIndex = 22
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(390, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 27)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Open File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RamView1
        '
        Me.RamView1.BulletMargin = 0
        Me.RamView1.CursorPos = CType(0, Long)
        Me.RamView1.Location = New System.Drawing.Point(1, 2)
        Me.RamView1.Name = "RamView1"
        Me.RamView1.SelLine = CType(-1, Long)
        Me.RamView1.Size = New System.Drawing.Size(658, 443)
        Me.RamView1.TabIndex = 11
        '
        'frmExtract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 537)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RamView1)
        Me.Name = "frmExtract"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "File Extraction"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents RamView1 As RAMView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents txtGoto As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStop As TextBox
    Friend WithEvents txtStart As TextBox
    Friend WithEvents Button1 As Button
End Class
