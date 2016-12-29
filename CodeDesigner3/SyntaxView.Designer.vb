<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SyntaxView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.tBlinker = New System.Windows.Forms.Timer(Me.components)
        Me.VScroll = New System.Windows.Forms.VScrollBar()
        Me.HScroll = New System.Windows.Forms.HScrollBar()
        Me.SuspendLayout()
        '
        'tBlinker
        '
        Me.tBlinker.Interval = 500
        '
        'VScroll
        '
        Me.VScroll.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.VScroll.Location = New System.Drawing.Point(655, 0)
        Me.VScroll.Name = "VScroll"
        Me.VScroll.Size = New System.Drawing.Size(18, 495)
        Me.VScroll.TabIndex = 0
        '
        'HScroll
        '
        Me.HScroll.Cursor = System.Windows.Forms.Cursors.Default
        Me.HScroll.LargeChange = 1
        Me.HScroll.Location = New System.Drawing.Point(0, 480)
        Me.HScroll.Maximum = 0
        Me.HScroll.Name = "HScroll"
        Me.HScroll.Size = New System.Drawing.Size(655, 18)
        Me.HScroll.TabIndex = 1
        '
        'SyntaxView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.HScroll)
        Me.Controls.Add(Me.VScroll)
        Me.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Name = "SyntaxView"
        Me.Size = New System.Drawing.Size(673, 495)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tBlinker As Timer
    Friend WithEvents VScroll As VScrollBar
    Friend WithEvents HScroll As HScrollBar
End Class
