Public Class frmSettings

    Private NewConfigs() As ConfigSetting, SynView As SyntaxView, mpAsm As MIPSAssembly
    Private SelectedConfig As Integer


    Private SV_BGCol_Index As Integer, SV_Font_Index As Integer, SV_FontColor_Index As Integer
    Private SV_FontSize_Index As Integer, SV_LineHL_Index As Integer, SV_Sel_Index As Integer
    Private SV_RenderString As String, SV_CanDraw As Boolean

    Public Sub Init(ByRef SView As SyntaxView, ByRef Asm As MIPSAssembly)
        SynView = SView
        mpAsm = Asm
    End Sub


    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rt As Integer, i As Integer, sp() As String

        SV_CanDraw = False
        Me.DoubleBuffered = True
        pctSVDisplay.DoubleBuffEnable()

        SelectedConfig = -1
        lstInstructionColors.Items.Clear()
        lstRegColors.Items.Clear()
        lstEnvironmentColors.Items.Clear()
        lstCMDColors.Items.Clear()

        rt = CopyConfigs(NewConfigs)
        If rt >= 0 Then
            For i = 0 To NewConfigs.Count - 1
                With NewConfigs(i)
                    sp = Split(.SettingName + ":", ":")
                    Select Case .SettingName
                        Case "SVFont"
                            SV_Font_Index = i
                            txtSVFont.Text = .SettingValue
                            'txtSVFont.Font = New Font(.SettingValue, FontStyle.Regular)
                        Case "SVFontSize"
                            SV_FontSize_Index = i
                            txtFontSize.Text = .SettingValue
                        Case "SVFontColor"
                            SV_FontColor_Index = i
                            lstEnvironmentColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] Font Color")
                        Case "SVBackColor"
                            SV_BGCol_Index = i
                            lstEnvironmentColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] Background Color")
                        Case "SVLineColor"
                            SV_LineHL_Index = i
                            lstEnvironmentColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] Current Line Back Color")
                        Case "SVSelColor"
                            SV_Sel_Index = i
                            lstEnvironmentColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] Selected Text Highlight Color")
                        Case "SVMultiComments"
                            lstEnvironmentColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] /* Multiline Comments */")
                        Case "SVSingleComments"
                            lstEnvironmentColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] // Single Line Comment")
                        Case "SVInvalid"
                            lstEnvironmentColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] Invalid Statement")

                        Case "SVCOM:hexcode"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:code"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:setreg"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:setfpr"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:setfloat"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:address"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:alloc"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:string"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:print"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:padding"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:call"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:goto"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:define"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:prochook"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:hook"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:thread"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:thread.start"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:thread.stop"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:thread.sleep"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:thread.wakeup"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:event"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:import"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:if"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:else"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVARG:if"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] (Secondary) " + sp(1))
                        Case "SVCOM:switch"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:case"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:default"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:%break"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:fnc"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:return"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:extern"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:for"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:while"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                        Case "SVCOM:%7b"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] (Open Brace) {")
                        Case "SVCOM:%7d"
                            lstCMDColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] (Close Brace) }")
                        Case Else
                            If Strings.Left(.SettingName, 5) = "SVARG" Then
                                lstRegColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                            ElseIf Strings.Left(.SettingName, 5) = "SVCOM" Then
                                lstInstructionColors.Items.Add("[" + Strings.Right("0000" + i.ToString, 4) + "] " + sp(1))
                            End If
                    End Select
                End With
            Next
        Else
            MsgBox("Error grabbing settings")
        End If

        tabMain.SelectedIndex = 0
        SVColorTabs.SelectedIndex = 0
    End Sub

    Private Sub SVCOLR_Scroll_1(sender As Object, e As ScrollEventArgs) Handles SVCOLR.Scroll
        If SelectedConfig < 0 Then Exit Sub

        txtSVRGB.Text = "FF" +
                        Strings.Right("00" + Hex(SVCOLR.Value), 2) +
                        Strings.Right("00" + Hex(SVCOLG.Value), 2) +
                        Strings.Right("00" + Hex(SVCOLB.Value), 2)

        NewConfigs(SelectedConfig).SettingValue = txtSVRGB.Text
        SVRenderChanges()
    End Sub

    Private Sub SVCOLG_Scroll_1(sender As Object, e As ScrollEventArgs) Handles SVCOLG.Scroll
        If SelectedConfig < 0 Then Exit Sub

        txtSVRGB.Text = "FF" +
                Strings.Right("00" + Hex(SVCOLR.Value), 2) +
                Strings.Right("00" + Hex(SVCOLG.Value), 2) +
                Strings.Right("00" + Hex(SVCOLB.Value), 2)

        NewConfigs(SelectedConfig).SettingValue = txtSVRGB.Text
        SVRenderChanges()
    End Sub

    Private Sub SVCOLB_Scroll_1(sender As Object, e As ScrollEventArgs) Handles SVCOLB.Scroll
        If SelectedConfig < 0 Then Exit Sub

        txtSVRGB.Text = "FF" +
                Strings.Right("00" + Hex(SVCOLR.Value), 2) +
                Strings.Right("00" + Hex(SVCOLG.Value), 2) +
                Strings.Right("00" + Hex(SVCOLB.Value), 2)

        NewConfigs(SelectedConfig).SettingValue = txtSVRGB.Text
        SVRenderChanges()
    End Sub

    Private Sub pctSVDisplay_Click(sender As Object, e As EventArgs) Handles pctSVDisplay.Click

    End Sub

    Private Sub lstRegColors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRegColors.SelectedIndexChanged
        If lstRegColors.SelectedIndex < 0 Then Exit Sub

        Dim i As Integer, tstr As String, sp() As String
        i = lstRegColors.SelectedIndex
        tstr = lstRegColors.Items(i).ToString
        SelectedConfig = Val(Strings.Mid(tstr, 2, 4))
        sp = Split(lstRegColors.Items(i).ToString, " ")

        With NewConfigs(SelectedConfig)
            SVCOLR.Value = Val("&H" + Strings.Mid(.SettingValue, 3, 2))
            SVCOLG.Value = Val("&H" + Strings.Mid(.SettingValue, 5, 2))
            SVCOLB.Value = Val("&H" + Strings.Mid(.SettingValue, 7, 2))

            If .Special = "{b}" Then chkBold.Checked = True
            If .Special = "{i}" Then chkItalic.Checked = True
            If .Special = "{u}" Then chkUnderline.Checked = True

            txtSVRGB.Text = .SettingValue

        End With


        SV_RenderString = "<cmd> " + sp(sp.Count - 1)

        SVRenderChanges()
    End Sub

    Private Sub lstCMDColors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCMDColors.SelectedIndexChanged
        If lstCMDColors.SelectedIndex < 0 Then Exit Sub

        Dim i As Integer, tstr As String, sp() As String
        i = lstCMDColors.SelectedIndex
        tstr = lstCMDColors.Items(i).ToString
        SelectedConfig = Val(Strings.Mid(tstr, 2, 4))
        sp = Split(lstCMDColors.Items(i).ToString, " ")

        With NewConfigs(SelectedConfig)
            SVCOLR.Value = Val("&H" + Strings.Mid(.SettingValue, 3, 2))
            SVCOLG.Value = Val("&H" + Strings.Mid(.SettingValue, 5, 2))
            SVCOLB.Value = Val("&H" + Strings.Mid(.SettingValue, 7, 2))

            If .Special = "{b}" Then chkBold.Checked = True
            If .Special = "{i}" Then chkItalic.Checked = True
            If .Special = "{u}" Then chkUnderline.Checked = True

            txtSVRGB.Text = .SettingValue

        End With


        SV_RenderString = sp(sp.Count - 1)

        SVRenderChanges()
    End Sub

    Private Sub lstEnvironmentColors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEnvironmentColors.SelectedIndexChanged
        If lstEnvironmentColors.SelectedIndex < 0 Then Exit Sub

        Dim i As Integer, tstr As String, sp() As String
        i = lstEnvironmentColors.SelectedIndex
        tstr = lstEnvironmentColors.Items(i).ToString
        SelectedConfig = Val(Strings.Mid(tstr, 2, 4))
        'sp = Split(lstRegColors.Items(i).ToString, " ")

        With NewConfigs(SelectedConfig)
            SVCOLR.Value = Val("&H" + Strings.Mid(.SettingValue, 3, 2))
            SVCOLG.Value = Val("&H" + Strings.Mid(.SettingValue, 5, 2))
            SVCOLB.Value = Val("&H" + Strings.Mid(.SettingValue, 7, 2))

            If .Special = "{b}" Then chkBold.Checked = True
            If .Special = "{i}" Then chkItalic.Checked = True
            If .Special = "{u}" Then chkUnderline.Checked = True

            txtSVRGB.Text = .SettingValue

        End With


        SV_RenderString = "Text"

        SVRenderChanges()
    End Sub

    Private Sub chkBold_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkBold.CheckedChanged
        If SelectedConfig < 0 Then Exit Sub

        If chkBold.Checked Then
            chkItalic.Checked = False
            chkUnderline.Checked = False
            NewConfigs(SelectedConfig).Special = "{b}"
        Else
            NewConfigs(SelectedConfig).Special = ""
        End If

        SVRenderChanges()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LoadDefault(mpAsm)
        frmSettings_Load(sender, e)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ApplyChanges(NewConfigs, SynView, mpAsm)
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim F As New FontDialog, rt As Integer, fntSize As Integer
        With F
            fntSize = Val(NewConfigs(SV_FontSize_Index).SettingValue)

            .Font = New Font(NewConfigs(SV_Font_Index).SettingValue,
                             fntSize,
                             FontStyle.Regular)

            rt = .ShowDialog()
            If rt = 2 Then Exit Sub
            txtSVFont.Text = .Font.FontFamily.Name
            txtSVFont.Font = .Font
            txtFontSize.Text = .Font.Size.ToString

            NewConfigs(SV_Font_Index).SettingValue = .Font.FontFamily.Name
            NewConfigs(SV_FontSize_Index).SettingValue = .Font.Size.ToString
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ApplyChanges(NewConfigs, SynView, mpAsm)
        SaveConfig()
    End Sub

    Private Sub chkUnderline_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkUnderline.CheckedChanged
        If SelectedConfig < 0 Then Exit Sub

        If chkUnderline.Checked Then
            chkBold.Checked = False
            chkItalic.Checked = False
            NewConfigs(SelectedConfig).Special = "{u}"
        Else
            NewConfigs(SelectedConfig).Special = ""
        End If

        SVRenderChanges()
    End Sub

    Private Sub chkItalic_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkItalic.CheckedChanged
        If SelectedConfig < 0 Then Exit Sub

        If chkItalic.Checked Then
            chkBold.Checked = False
            chkUnderline.Checked = False
            NewConfigs(SelectedConfig).Special = "{i}"
        Else
            NewConfigs(SelectedConfig).Special = ""
        End If

        SVRenderChanges()
    End Sub


    Private Sub lstInstructionColors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstInstructionColors.SelectedIndexChanged
        If lstInstructionColors.SelectedIndex < 0 Then Exit Sub

        Dim i As Integer, tstr As String, sp() As String
        i = lstInstructionColors.SelectedIndex
        tstr = lstInstructionColors.Items(i).ToString
        SelectedConfig = Val(Strings.Mid(tstr, 2, 4))
        sp = Split(lstInstructionColors.Items(i).ToString, " ")

        With NewConfigs(SelectedConfig)
            SVCOLR.Value = Val("&H" + Strings.Mid(.SettingValue, 3, 2))
            SVCOLG.Value = Val("&H" + Strings.Mid(.SettingValue, 5, 2))
            SVCOLB.Value = Val("&H" + Strings.Mid(.SettingValue, 7, 2))

            If .Special = "{b}" Then chkBold.Checked = True
            If .Special = "{i}" Then chkItalic.Checked = True
            If .Special = "{u}" Then chkUnderline.Checked = True

            txtSVRGB.Text = .SettingValue

        End With


        SV_RenderString = sp(sp.Count - 1)

        SVRenderChanges()
    End Sub

    Private Sub SVRenderChanges()
        SV_CanDraw = True
        pctSVDisplay.Invalidate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub pctSVDisplay_Paint(sender As Object, e As PaintEventArgs) Handles pctSVDisplay.Paint
        Dim BGCol As Integer, LineCol As Integer, FontCol As Integer, SelCol As Integer
        Dim XY As Point, MaxLines As Integer, i As Integer, renLine As Integer, SXCol As Integer
        Dim GFX As Graphics, RCT As Rectangle, Fnt As Font, FntSize As Integer, FntCol As Integer

        Dim mWidth As Integer

        If SV_CanDraw = False Then Exit Sub

        GFX = e.Graphics

        BGCol = Val("&H" + NewConfigs(SV_BGCol_Index).SettingValue)
        FontCol = Val("&H" + NewConfigs(SV_FontColor_Index).SettingValue)
        LineCol = Val("&H" + NewConfigs(SV_LineHL_Index).SettingValue)

        FntSize = Val(NewConfigs(SV_FontSize_Index).SettingValue)
        Fnt = New Font(NewConfigs(SV_Font_Index).SettingValue, FntSize, FontStyle.Regular)
        FntCol = Val("&H" + NewConfigs(SV_FontColor_Index).SettingValue)
        SelCol = Val("&H" + NewConfigs(SV_Sel_Index).SettingValue)
        SXCol = Val("&H" + NewConfigs(SelectedConfig).SettingValue)

        MaxLines = (pctSVDisplay.Height \ Fnt.Height) - 1

        GFX.Clear(Color.FromArgb(BGCol))

        renLine = 123
        mWidth = StrWidth("  1234", GFX, Fnt)

        For i = 0 To MaxLines
            XY.X = 0

            If i = 1 Then
                RCT.X = 0
                RCT.Y = XY.Y
                RCT.Height = Fnt.Height
                RCT.Width = pctSVDisplay.Width

                GFX.FillRectangle(New SolidBrush(Color.FromArgb(LineCol)), RCT)
            End If

            If i = 5 Then
                RCT.X = mWidth
                RCT.Y = XY.Y
                RCT.Height = Fnt.Height
                RCT.Width = StrWidth("Text ", GFX, Fnt)

                GFX.FillRectangle(New SolidBrush(Color.FromArgb(SelCol)), RCT)
            End If

            'Render margin
            Fnt = New Font(Fnt.FontFamily, Fnt.Size, FontStyle.Regular)
            GFX.DrawString("  " + (renLine + i).ToString, Fnt, New SolidBrush(Color.FromArgb(FntCol)), XY)
            XY.X += mWidth


            'Render text
            If i = 3 Then
                Select Case NewConfigs(SelectedConfig).Special
                    Case "{b}"
                        Fnt = New Font(Fnt.FontFamily, Fnt.Size, FontStyle.Bold)
                    Case "{i}"
                        Fnt = New Font(Fnt.FontFamily, Fnt.Size, FontStyle.Italic)
                    Case "{u}"
                        Fnt = New Font(Fnt.FontFamily, Fnt.Size, FontStyle.Underline)
                    Case Else
                        Fnt = New Font(Fnt.FontFamily, Fnt.Size, FontStyle.Regular)
                End Select
                GFX.DrawString(SV_RenderString, Fnt, New SolidBrush(Color.FromArgb(SXCol)), XY)
            Else
                Fnt = New Font(Fnt.FontFamily, Fnt.Size, FontStyle.Regular)
                GFX.DrawString("Text", Fnt, New SolidBrush(Color.FromArgb(FntCol)), XY)
            End If


            XY.Y += Fnt.Height
        Next

    End Sub

    Private Function StrWidth(Str As String, G As Graphics, F As Font) As Integer
        Dim SzF As SizeF, SzF2 As SizeF
        SzF2 = G.MeasureString("I", F)
        SzF = G.MeasureString(Str + "I", F)
        Return SzF.Width - SzF2.Width
    End Function

End Class

Public Class PicBox
    Inherits PictureBox

    Public Sub DoubleBuffEnable()
        Me.DoubleBuffered = True
    End Sub

End Class
