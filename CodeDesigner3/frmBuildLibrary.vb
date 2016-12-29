Public Class frmBuildLibrary
    Private SourceData As String, isMakeable As Boolean, Funcs() As FuncInfo, FuncCount As Integer
    Private mpCom As Compiler

    Private Structure FuncInfo
        Dim FuncName As String
        Dim FuncData As String
    End Structure

    Public Sub SetData(Src As String, ByRef mCom As Compiler)
        SourceData = Src
        mpCom = mCom
    End Sub

    Private Sub ParseSource()
        If SourceData = "" Then Exit Sub

        Dim Lines() As String, sp() As String, isFunc As Boolean, i As Integer, myFunc As Integer
        Dim Brc As Integer
        Lines = Split(SourceData + vbCrLf, vbCrLf)

        myFunc = -1
        isFunc = False
        Brc = -1
        For i = 0 To Lines.Count - 1
            sp = Split(parseSyntax(Lines(i)) + "      ", " ")
            If LCase(sp(0)) = "fnc" Then
                myFunc += 1
                ReDim Preserve Funcs(myFunc)
                Funcs(myFunc).FuncName = sp(1)
                Funcs(myFunc).FuncData = ""
                isFunc = True
            End If

            If sp(0) = "{" Then Brc += 1
            If sp(0) = "}" Then Brc -= 1

            If isFunc Then Funcs(myFunc).FuncData += Lines(i) + vbCrLf

            If sp(0) = "}" And Brc < 0 Then isFunc = False
        Next
        FuncCount = myFunc

        If FuncCount >= 0 Then isMakeable = True
    End Sub

    Private Sub ShowFuncList()
        Dim i As Integer
        lstFuncs.Items.Clear()

        For i = 0 To FuncCount
            lstFuncs.Items.Add(Funcs(i).FuncName)
        Next

        If lstFuncs.Items.Count > 0 Then lstFuncs.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim CDL As New CDLibrary, rt As Integer, Src As String, i As Integer, ret As String

        If txtName.Text = "" Then isMakeable = False

        If isMakeable Then
            If chkFinish.Checked Then
                Try
                    If My.Computer.FileSystem.FileExists(Application.StartupPath + "\lib\" + txtName.Text + ".cdl") Then
                        rt = MsgBox("A library already exists with" + vbCrLf +
                                    "this name. Overwrite it?", vbOKCancel, "Create Lib")
                        If rt = 2 Then Exit Sub
                        My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\lib\" + txtName.Text + ".cdl")
                    End If

                    Src = ""
                    For i = 0 To FuncCount
                        Src += Funcs(i).FuncData + vbCrLf
                    Next

                    ret = CDL.BuildCompiledLibrary(Src, mpCom)
                    If ret = "" Then
                        MsgBox("Build error")
                        Exit Sub
                    Else
                        'My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\lib\" + txtName.Text + ".cdl", ret, False)
                        Dim FS As System.IO.FileStream, FBytes() As Byte
                        FS = System.IO.File.OpenWrite(Application.StartupPath + "\lib\" + txtName.Text + ".cdl")

                        ReDim FBytes(Len(ret) - 1)
                        For i = 1 To Len(ret)
                            FBytes(i - 1) = Asc(Strings.Mid(ret, i, 1))
                        Next

                        FS.Write(FBytes, 0, FBytes.Length)
                        FS.Close()

                        MsgBox("Library Created!")
                        Me.Close()
                    End If
                Catch ex As Exception
                    MsgBox("An error has occurred")
                    Exit Sub
                End Try
            Else

            End If
        Else
            MsgBox("Cannot produce a library with this!")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmBuildLibrary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isMakeable = False
        ParseSource()
        ShowFuncList()
    End Sub

    Private Sub lstFuncs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFuncs.SelectedIndexChanged
        If lstFuncs.SelectedIndex < 0 Then Exit Sub
        txtFunc.Text = Funcs(lstFuncs.SelectedIndex).FuncData
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        txtName.Text = Replace(txtName.Text, "~", "")
        txtName.Text = Replace(txtName.Text, "`", "")
        txtName.Text = Replace(txtName.Text, "!", "")
        txtName.Text = Replace(txtName.Text, "@", "")
        txtName.Text = Replace(txtName.Text, "#", "")
        txtName.Text = Replace(txtName.Text, "$", "")
        txtName.Text = Replace(txtName.Text, "%", "")
        txtName.Text = Replace(txtName.Text, "^", "")
        txtName.Text = Replace(txtName.Text, "&", "")
        txtName.Text = Replace(txtName.Text, "*", "")
        txtName.Text = Replace(txtName.Text, "(", "")
        txtName.Text = Replace(txtName.Text, ")", "")
        txtName.Text = Replace(txtName.Text, "-", "")
        txtName.Text = Replace(txtName.Text, "_", "")
        txtName.Text = Replace(txtName.Text, "=", "")
        txtName.Text = Replace(txtName.Text, "+", "")
        txtName.Text = Replace(txtName.Text, "[", "")
        txtName.Text = Replace(txtName.Text, "{", "")
        txtName.Text = Replace(txtName.Text, "]", "")
        txtName.Text = Replace(txtName.Text, "}", "")
        txtName.Text = Replace(txtName.Text, "|", "")
        txtName.Text = Replace(txtName.Text, "\", "")
        txtName.Text = Replace(txtName.Text, ";", "")
        txtName.Text = Replace(txtName.Text, ":", "")
        txtName.Text = Replace(txtName.Text, "'", "")
        txtName.Text = Replace(txtName.Text, """", "")
        txtName.Text = Replace(txtName.Text, ",", "")
        txtName.Text = Replace(txtName.Text, "<", "")
        txtName.Text = Replace(txtName.Text, ".", "")
        txtName.Text = Replace(txtName.Text, ">", "")
        txtName.Text = Replace(txtName.Text, "/", "")
        txtName.Text = Replace(txtName.Text, "?", "")
        txtName.Text = Replace(txtName.Text, " ", "")
    End Sub

    Private Function parseSyntax(strIn As String) As String
        Dim ret As String, cmtStrip() As String
        ret = strIn
        If ret = "" Then Return ret

        cmtStrip = Split(ret + "//", "//")
        ret = cmtStrip(0)

        ret = Replace(ret, vbTab, " ")
        ret = Replace(ret, ",", " ")
        ret = Replace(ret, ";", " ")
        ret = Replace(ret, "--", " --")
        ret = Replace(ret, "++", " ++")
        ret = Replace(ret, "(", " ")
        ret = Replace(ret, ")", " ")
        ret = Replace(ret, "0x", "$")
        ret = stripSpaces(ret)
        Return ret
    End Function
    Private Function stripSpaces(strIn As String) As String
        Dim lastLen As Integer, ret As String
        ret = strIn
        Do
            lastLen = ret.Length
            ret = Replace(ret, "  ", " ")
            If Strings.Left(ret, 1).Equals(" ") Then ret = Strings.Right(ret, ret.Length - 1)
            If Strings.Right(ret, 1).Equals(" ") Then ret = Strings.Left(ret, ret.Length - 1)
            If ret = "" Then Return ""
        Loop Until lastLen = ret.Length
        Return ret
    End Function
    Private Function stripWhiteSpace(strIn As String) As String
        Dim ret As String

        ret = strIn
        Do While Strings.Left(ret, 1) = " " Or Strings.Left(ret, 1) = vbTab
            If ret = "" Then Return ""
            ret = Strings.Right(ret, Len(ret) - 1)
        Loop

        Return ret
    End Function
End Class