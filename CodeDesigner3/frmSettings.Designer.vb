<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFontSize = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSVFont = New System.Windows.Forms.TextBox()
        Me.chkUnderline = New System.Windows.Forms.CheckBox()
        Me.chkItalic = New System.Windows.Forms.CheckBox()
        Me.chkBold = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSVRGB = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SVCOLB = New System.Windows.Forms.HScrollBar()
        Me.SVCOLG = New System.Windows.Forms.HScrollBar()
        Me.SVCOLR = New System.Windows.Forms.HScrollBar()
        Me.SVColorTabs = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lstInstructionColors = New System.Windows.Forms.ListBox()
        Me.SVRegColors = New System.Windows.Forms.TabPage()
        Me.lstRegColors = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lstCMDColors = New System.Windows.Forms.ListBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.lstEnvironmentColors = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.pctSVDisplay = New CodeDesigner3.PicBox()
        Me.tabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SVColorTabs.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SVRegColors.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.pctSVDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(858, 471)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(766, 471)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 30)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(674, 471)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 30)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Apply"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(13, 471)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(116, 30)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Restore Default"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.TabPage2)
        Me.tabMain.Controls.Add(Me.TabPage6)
        Me.tabMain.Controls.Add(Me.TabPage7)
        Me.tabMain.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabMain.Location = New System.Drawing.Point(13, 11)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(931, 454)
        Me.tabMain.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pctSVDisplay)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtFontSize)
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtSVFont)
        Me.TabPage1.Controls.Add(Me.chkUnderline)
        Me.TabPage1.Controls.Add(Me.chkItalic)
        Me.TabPage1.Controls.Add(Me.chkBold)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtSVRGB)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.SVCOLB)
        Me.TabPage1.Controls.Add(Me.SVCOLG)
        Me.TabPage1.Controls.Add(Me.SVCOLR)
        Me.TabPage1.Controls.Add(Me.SVColorTabs)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(923, 425)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Syntax View Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(670, 395)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Font Size:"
        '
        'txtFontSize
        '
        Me.txtFontSize.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFontSize.Location = New System.Drawing.Point(764, 395)
        Me.txtFontSize.Name = "txtFontSize"
        Me.txtFontSize.ReadOnly = True
        Me.txtFontSize.Size = New System.Drawing.Size(112, 20)
        Me.txtFontSize.TabIndex = 34
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(882, 395)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(35, 20)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "..."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(636, 372)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Font:"
        '
        'txtSVFont
        '
        Me.txtSVFont.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSVFont.Location = New System.Drawing.Point(690, 369)
        Me.txtSVFont.Name = "txtSVFont"
        Me.txtSVFont.ReadOnly = True
        Me.txtSVFont.Size = New System.Drawing.Size(227, 20)
        Me.txtSVFont.TabIndex = 31
        '
        'chkUnderline
        '
        Me.chkUnderline.AutoSize = True
        Me.chkUnderline.Location = New System.Drawing.Point(803, 349)
        Me.chkUnderline.Name = "chkUnderline"
        Me.chkUnderline.Size = New System.Drawing.Size(107, 20)
        Me.chkUnderline.TabIndex = 30
        Me.chkUnderline.Text = "Underlined"
        Me.chkUnderline.UseVisualStyleBackColor = True
        '
        'chkItalic
        '
        Me.chkItalic.AutoSize = True
        Me.chkItalic.Location = New System.Drawing.Point(722, 349)
        Me.chkItalic.Name = "chkItalic"
        Me.chkItalic.Size = New System.Drawing.Size(75, 20)
        Me.chkItalic.TabIndex = 29
        Me.chkItalic.Text = "Italic"
        Me.chkItalic.UseVisualStyleBackColor = True
        '
        'chkBold
        '
        Me.chkBold.AutoSize = True
        Me.chkBold.Location = New System.Drawing.Point(657, 349)
        Me.chkBold.Name = "chkBold"
        Me.chkBold.Size = New System.Drawing.Size(59, 20)
        Me.chkBold.TabIndex = 28
        Me.chkBold.Text = "Bold"
        Me.chkBold.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(703, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "RGB Code:"
        '
        'txtSVRGB
        '
        Me.txtSVRGB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSVRGB.Location = New System.Drawing.Point(770, 221)
        Me.txtSVRGB.MaxLength = 8
        Me.txtSVRGB.Name = "txtSVRGB"
        Me.txtSVRGB.ReadOnly = True
        Me.txtSVRGB.Size = New System.Drawing.Size(147, 22)
        Me.txtSVRGB.TabIndex = 26
        Me.txtSVRGB.Text = "FFFFFFFF"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(641, 285)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Blue"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(633, 270)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Green"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(649, 253)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Red"
        '
        'SVCOLB
        '
        Me.SVCOLB.LargeChange = 1
        Me.SVCOLB.Location = New System.Drawing.Point(677, 286)
        Me.SVCOLB.Maximum = 255
        Me.SVCOLB.Name = "SVCOLB"
        Me.SVCOLB.Size = New System.Drawing.Size(240, 15)
        Me.SVCOLB.TabIndex = 22
        '
        'SVCOLG
        '
        Me.SVCOLG.LargeChange = 1
        Me.SVCOLG.Location = New System.Drawing.Point(677, 270)
        Me.SVCOLG.Maximum = 255
        Me.SVCOLG.Name = "SVCOLG"
        Me.SVCOLG.Size = New System.Drawing.Size(240, 15)
        Me.SVCOLG.TabIndex = 21
        '
        'SVCOLR
        '
        Me.SVCOLR.LargeChange = 1
        Me.SVCOLR.Location = New System.Drawing.Point(677, 254)
        Me.SVCOLR.Maximum = 255
        Me.SVCOLR.Name = "SVCOLR"
        Me.SVCOLR.Size = New System.Drawing.Size(240, 15)
        Me.SVCOLR.TabIndex = 20
        '
        'SVColorTabs
        '
        Me.SVColorTabs.Controls.Add(Me.TabPage3)
        Me.SVColorTabs.Controls.Add(Me.SVRegColors)
        Me.SVColorTabs.Controls.Add(Me.TabPage4)
        Me.SVColorTabs.Controls.Add(Me.TabPage5)
        Me.SVColorTabs.Location = New System.Drawing.Point(6, 6)
        Me.SVColorTabs.Name = "SVColorTabs"
        Me.SVColorTabs.SelectedIndex = 0
        Me.SVColorTabs.Size = New System.Drawing.Size(620, 416)
        Me.SVColorTabs.TabIndex = 18
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lstInstructionColors)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(612, 387)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Instructions"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lstInstructionColors
        '
        Me.lstInstructionColors.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInstructionColors.FormattingEnabled = True
        Me.lstInstructionColors.IntegralHeight = False
        Me.lstInstructionColors.ItemHeight = 16
        Me.lstInstructionColors.Location = New System.Drawing.Point(6, 7)
        Me.lstInstructionColors.Name = "lstInstructionColors"
        Me.lstInstructionColors.Size = New System.Drawing.Size(600, 377)
        Me.lstInstructionColors.TabIndex = 0
        '
        'SVRegColors
        '
        Me.SVRegColors.Controls.Add(Me.lstRegColors)
        Me.SVRegColors.Location = New System.Drawing.Point(4, 25)
        Me.SVRegColors.Name = "SVRegColors"
        Me.SVRegColors.Padding = New System.Windows.Forms.Padding(3)
        Me.SVRegColors.Size = New System.Drawing.Size(612, 387)
        Me.SVRegColors.TabIndex = 1
        Me.SVRegColors.Text = "Registers"
        Me.SVRegColors.UseVisualStyleBackColor = True
        '
        'lstRegColors
        '
        Me.lstRegColors.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRegColors.FormattingEnabled = True
        Me.lstRegColors.IntegralHeight = False
        Me.lstRegColors.ItemHeight = 16
        Me.lstRegColors.Location = New System.Drawing.Point(6, 6)
        Me.lstRegColors.Name = "lstRegColors"
        Me.lstRegColors.Size = New System.Drawing.Size(600, 378)
        Me.lstRegColors.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lstCMDColors)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(612, 387)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "Compiler Specifics"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lstCMDColors
        '
        Me.lstCMDColors.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCMDColors.FormattingEnabled = True
        Me.lstCMDColors.IntegralHeight = False
        Me.lstCMDColors.ItemHeight = 16
        Me.lstCMDColors.Location = New System.Drawing.Point(6, 6)
        Me.lstCMDColors.Name = "lstCMDColors"
        Me.lstCMDColors.Size = New System.Drawing.Size(600, 378)
        Me.lstCMDColors.TabIndex = 1
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.lstEnvironmentColors)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(612, 387)
        Me.TabPage5.TabIndex = 3
        Me.TabPage5.Text = "Environment"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lstEnvironmentColors
        '
        Me.lstEnvironmentColors.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEnvironmentColors.FormattingEnabled = True
        Me.lstEnvironmentColors.IntegralHeight = False
        Me.lstEnvironmentColors.ItemHeight = 16
        Me.lstEnvironmentColors.Location = New System.Drawing.Point(6, 7)
        Me.lstEnvironmentColors.Name = "lstEnvironmentColors"
        Me.lstEnvironmentColors.Size = New System.Drawing.Size(600, 377)
        Me.lstEnvironmentColors.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(923, 425)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "RAM View Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(923, 425)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Assembler Settings"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.Location = New System.Drawing.Point(4, 25)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(923, 425)
        Me.TabPage7.TabIndex = 3
        Me.TabPage7.Text = "Disassembler Settings"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'pctSVDisplay
        '
        Me.pctSVDisplay.Location = New System.Drawing.Point(632, 6)
        Me.pctSVDisplay.Name = "pctSVDisplay"
        Me.pctSVDisplay.Size = New System.Drawing.Size(285, 209)
        Me.pctSVDisplay.TabIndex = 36
        Me.pctSVDisplay.TabStop = False
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 506)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.tabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.SVColorTabs.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.SVRegColors.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.pctSVDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents tabMain As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFontSize As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSVFont As TextBox
    Friend WithEvents chkUnderline As CheckBox
    Friend WithEvents chkItalic As CheckBox
    Friend WithEvents chkBold As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSVRGB As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SVCOLB As HScrollBar
    Friend WithEvents SVCOLG As HScrollBar
    Friend WithEvents SVCOLR As HScrollBar
    Friend WithEvents SVColorTabs As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents lstInstructionColors As ListBox
    Friend WithEvents SVRegColors As TabPage
    Friend WithEvents lstRegColors As ListBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents lstCMDColors As ListBox
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents lstEnvironmentColors As ListBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents pctSVDisplay As PicBox
End Class
