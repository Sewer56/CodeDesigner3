Public Class frmBuildArchive
    Private PageNames() As String, Pages() As String, PCount As Integer, mpCom As Compiler
    Private MyLibs() As LibInfo, LibCount As Integer, UseableLibs As Integer
    Private isMakeable As Boolean

    Private Structure FuncInfo
        Dim FuncName As String
        Dim FuncData As String
    End Structure

    Private Structure LibInfo
        Dim LibName As String
        Dim Funcs() As FuncInfo
        Dim FCount As Integer
    End Structure

    Private Sub frmBuildArchive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isMakeable = False
        ParsePages()
        RefreshLibs()
    End Sub

    Public Sub SetData(Names() As String, Src() As String, mCom As Compiler)
        Dim i As Integer

        ReDim PageNames(Names.Count - 1)
        ReDim Pages(Names.Count - 1)
        For i = 0 To Names.Count - 1
            PageNames(i) = Names(i)
            Pages(i) = Src(i)
        Next
        PCount = PageNames.Count - 1
    End Sub

    Private Sub ParsePages()
        If PCount < 0 Then Exit Sub

        Dim i As Integer, i2 As Integer, Lines() As String, sp() As String
        Dim isFunc As Boolean, Brc As Integer

        LibCount = -1
        UseableLibs = -1

        For i = 0 To PCount
            If LCase(Strings.Right(PageNames(i), 4)) = ".cds" Then PageNames(i) = Strings.Left(PageNames(i), Len(PageNames(i)) - 4)

            LibCount += 1
            ReDim Preserve MyLibs(LibCount)
            MyLibs(LibCount).LibName = PageNames(i)
            MyLibs(LibCount).FCount = -1

            Brc = -1
            isFunc = False
            Lines = Split(Pages(i) + vbCrLf, vbCrLf)
            For i2 = 0 To Lines.Count - 1
                sp = Split(parseSyntax(Lines(i2)) + "      ", " ")
                If LCase(sp(0)) = "fnc" Then
                    MyLibs(LibCount).FCount += 1
                    ReDim Preserve MyLibs(LibCount).Funcs(MyLibs(LibCount).FCount)
                    MyLibs(LibCount).Funcs(MyLibs(LibCount).FCount).FuncName = sp(1)
                    MyLibs(LibCount).Funcs(MyLibs(LibCount).FCount).FuncData = ""
                    isFunc = True
                End If

                If sp(0) = "{" Then Brc += 1
                If sp(0) = "}" Then Brc -= 1

                If isFunc Then MyLibs(LibCount).Funcs(MyLibs(LibCount).FCount).FuncData += Lines(i2) + vbCrLf

                If sp(0) = "}" And Brc < 0 Then isFunc = False

            Next
            If MyLibs(LibCount).FCount < 0 Then MyLibs(LibCount).LibName = ""
            If MyLibs(LibCount).LibName <> "" Then UseableLibs += 1
        Next
        isMakeable = True
        If UseableLibs < 0 Then isMakeable = False
    End Sub

    Private Sub RefreshLibs()
        If UseableLibs < 0 Then Exit Sub

        Dim i As Integer, L1 As Integer

        L1 = lstLibs.SelectedIndex

        lstLibs.Items.Clear()

        For i = 0 To MyLibs.Count - 1
            lstLibs.Items.Add(MyLibs(i).LibName)
        Next
        If L1 >= 0 Then lstLibs.SelectedIndex = L1

    End Sub

    Private Sub RefreshFuncs()
        If UseableLibs < 0 Then Exit Sub
        If lstLibs.SelectedIndex < 0 Then Exit Sub

        Dim i As Integer, LI As Integer, L1 As Integer

        L1 = lstFuncs.SelectedIndex

        lstFuncs.Items.Clear()
        For i = 0 To MyLibs.Count - 1
            If MyLibs(i).LibName = lstLibs.Items(lstLibs.SelectedIndex).ToString Then LI = i
        Next

        For i = 0 To MyLibs(LI).FCount
            lstFuncs.Items.Add(MyLibs(LI).Funcs(i).FuncName)
        Next

        If L1 < 0 Then Exit Sub
        If L1 > lstFuncs.Items.Count - 1 Then Exit Sub
        lstFuncs.SelectedIndex = L1
    End Sub

    Private Sub lstLibs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLibs.SelectedIndexChanged
        If lstLibs.SelectedIndex < 0 Then Exit Sub
        Dim i As Integer, LI As Integer
        For i = 0 To MyLibs.Count - 1
            If MyLibs(i).LibName = lstLibs.Items(lstLibs.SelectedIndex).ToString Then LI = i
        Next
        txtLib.Text = MyLibs(LI).LibName
        RefreshFuncs()
    End Sub

    Private Sub lstFuncs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFuncs.SelectedIndexChanged
        If lstFuncs.SelectedIndex < 0 Then Exit Sub
        If lstLibs.SelectedIndex < 0 Then Exit Sub

        Dim i As Integer, LI As Integer
        For i = 0 To MyLibs.Count - 1
            If MyLibs(i).LibName = lstLibs.Items(lstLibs.SelectedIndex).ToString Then LI = i
        Next

        With MyLibs(LI).Funcs(lstFuncs.SelectedIndex)
            txtFunc.Text = .FuncData
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub



    Private Function RemoveForbiddenChars(StrIn As String) As String
        Dim ret As String
        ret = StrIn
        ret = Replace(ret, "~", "")
        ret = Replace(ret, "`", "")
        ret = Replace(ret, "!", "")
        ret = Replace(ret, "@", "")
        ret = Replace(ret, "#", "")
        ret = Replace(ret, "$", "")
        ret = Replace(ret, "%", "")
        ret = Replace(ret, "^", "")
        ret = Replace(ret, "&", "")
        ret = Replace(ret, "*", "")
        ret = Replace(ret, "(", "")
        ret = Replace(ret, ")", "")
        ret = Replace(ret, "-", "")
        ret = Replace(ret, "_", "")
        ret = Replace(ret, "=", "")
        ret = Replace(ret, "+", "")
        ret = Replace(ret, "[", "")
        ret = Replace(ret, "{", "")
        ret = Replace(ret, "]", "")
        ret = Replace(ret, "}", "")
        ret = Replace(ret, "|", "")
        ret = Replace(ret, "\", "")
        ret = Replace(ret, ";", "")
        ret = Replace(ret, ":", "")
        ret = Replace(ret, "'", "")
        ret = Replace(ret, """", "")
        ret = Replace(ret, ",", "")
        ret = Replace(ret, "<", "")
        ret = Replace(ret, ".", "")
        ret = Replace(ret, ">", "")
        ret = Replace(ret, "/", "")
        ret = Replace(ret, "?", "")
        ret = Replace(ret, " ", "")
        Return ret
    End Function


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