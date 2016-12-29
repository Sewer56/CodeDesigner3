Public Class frmExtract
    Private mpAsm As MIPSAssembly, mpCom As Compiler, FileBytes() As Byte

    Public Sub SetAsm(ByRef Asm As MIPSAssembly, ByRef mCom As Compiler)
        mpAsm = Asm
        mpCom = mCom
    End Sub

    Private Sub frmExtract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SelCols(2) As Integer
        SelCols(1) = Val("&HFF00ff00") 'RGB(0, 255, 0)
        SelCols(2) = Val("&HFFff0000") 'RGB(255, 0, 0)

        RamView1.InitMemory(Nothing, Nothing, 0, mpAsm, 0)
        RamView1.SetBreakOpsColors(2, SelCols)

    End Sub

    Private Sub RamView1_KeyUp(sender As Object, e As KeyEventArgs) Handles RamView1.KeyUp
        Dim Low As Int64, high As Int64
        If RamView1.SelLine <> -1 Then
            Low = RamView1.SelLine
            If Low < RamView1.CursorPos Then
                high = RamView1.CursorPos
            Else
                Low = RamView1.CursorPos
                high = RamView1.SelLine
            End If
            txtStart.Text = Strings.Right("00000000" + Hex(Low * 4), 8)
            txtStop.Text = Strings.Right("00000000" + Hex(high * 4), 8)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rt As Integer, FS As System.IO.FileStream, sp() As String
        With OpenFileDialog1
            .FileName = ""
            .Filter = "All Files|*.*"

            rt = .ShowDialog
            If rt = 2 Then Exit Sub

            Try
                sp = Split("\" + .FileName, "\")
                Me.Text = "File Extraction - " + sp(sp.Count - 1)

                FS = System.IO.File.OpenRead(.FileName)
                ReDim FileBytes(FS.Length - 1)
                FS.Read(FileBytes, 0, FS.Length)
                FS.Close()
                FS.Dispose()

                RamView1.InitMemory(FileBytes, Nothing, 1, mpAsm, 0)
            Catch ex As Exception
                MsgBox("Error.")
            End Try

        End With
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim I As Integer, rt As Integer
        Dim ret As String, tStr As String, fakeAddr As String

        If FileBytes Is Nothing Then Exit Sub
        If txtStart.Text = "" Then Exit Sub
        If txtStop.Text = "" Then Exit Sub
        If Val("&H" + txtStart.Text) > FileBytes.Count - 1 Then Exit Sub
        If Val("&H" + txtStop.Text) > FileBytes.Count - 1 Then Exit Sub
        If Val("&H" + txtStart.Text) > Val("&H" + txtStop.Text) Then Exit Sub
        If Val("&H" + txtStart.Text) = Val("&H" + txtStop.Text) Then Exit Sub

        ret = ""
        For I = Val("&H" + txtStart.Text) To Val("&H" + txtStop.Text) Step 4
            tStr = Strings.Right("00" + Hex(FileBytes(I + 3)), 2)
            tStr += Strings.Right("00" + Hex(FileBytes(I + 2)), 2)
            tStr += Strings.Right("00" + Hex(FileBytes(I + 1)), 2)
            tStr += Strings.Right("00" + Hex(FileBytes(I + 0)), 2)

            fakeAddr = Strings.Right("00000000" + Hex(I), 8)
            ret += fakeAddr + " " + tStr + vbCrLf
        Next

        frmMain.SyntaxView1.TxtSource = mpCom.Decompile(ret)
        Me.Close()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        RamView1.GotoAddress(Val("&H" + txtGoto.Text))
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub RamView1_MouseUp(sender As Object, e As MouseEventArgs) Handles RamView1.MouseUp
        Dim Low As Int64, high As Int64
        If RamView1.SelLine <> -1 Then
            Low = RamView1.SelLine
            If Low < RamView1.CursorPos Then
                high = RamView1.CursorPos
            Else
                Low = RamView1.CursorPos
                high = RamView1.SelLine
            End If
            txtStart.Text = Strings.Right("00000000" + Hex(Low * 4), 8)
            txtStop.Text = Strings.Right("00000000" + Hex(high * 4), 8)
        End If
    End Sub

    Private Sub frmExtract_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        RamView1.Left = 0
        RamView1.Top = 0
        RamView1.Width = Me.ClientRectangle.Width
        RamView1.Height = Me.ClientRectangle.Height - GroupBox1.Height
        GroupBox1.Top = RamView1.Top + RamView1.Height
        GroupBox1.Left = Me.ClientRectangle.Width - GroupBox1.Width
    End Sub
End Class