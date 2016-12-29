Public Class CDLibrary

    Private Structure FunctionInfo
        Dim Declaration As String
        Dim DSize As Integer

        Dim Dependancies() As String
        Dim DependCount As Integer
        Dim DependantSize As Integer

        Dim Contents As String
        Dim FSize As Integer
    End Structure

    Private Function ReadString(ByRef Str As String, startPos As Integer) As String
        Dim i As Integer, ret As String

        ret = ""
        i = startPos
        Do Until Strings.Mid(Str, i, 1) = Chr(0)
            ret += Strings.Mid(Str, i, 1)
            i += 1
        Loop

        Return ret
    End Function

    Private Function ExtractLib(ArchiveData As String, LibName As String) As String
        If Mid(ArchiveData, 1, 4) <> ".CDL" Then Return ""
        If Val("&H" + HexReverse(StrToHex(Mid(ArchiveData, 5, 4)))) <> 1 Then Return ""

        '========================================= Header
        'xxxxxxxx -> library identifier data ".CDL"
        'iiiiiiii -> library type identifier
        'tttttttt -> table size
        'cccccccc -> function count

        'i:00000000 = function library
        'i:00000001 = library archive


        '========================================= library table (archive)
        'nnnnnnnn -> function library name entry
        'eeeeeeee -> function library entry
        'ssssssss -> function library size



    End Function

    Public Function LoadFromLibrary(LibName As String, FuncName As String, ByRef Dependancies() As String) As String
        Dim LibData As String, LibType As Integer, rt As Integer, i As Integer, i2 As Integer
        Dim TableSize As Integer, FuncCount As Integer
        Dim ReadPos As Integer, Entry As Integer
        Dim MyFunc As FunctionInfo, sp() As String, ret As String, tStr As String
        Dim LibI As Integer

        Dim FS As System.IO.FileStream, FBytes() As Byte

        LibI = 0
        Try
            'FS = System.IO.File.Open(LibName, IO.FileMode.Open)
            'ReDim FBytes(FS.Length - 1)
            'FS.Read(FBytes, 0, FS.Length)
            sp = Split(LibName + ".", ".")


            FBytes = My.Computer.FileSystem.ReadAllBytes(Application.StartupPath.ToString + "\lib\" + sp(LibI) + ".cdl")
            LibI += 1
            'FS.Close()

            'LibData = System.Text.Encoding.UTF8.GetString(FBytes)
            For i = 0 To FBytes.Length - 1
                LibData += Chr(FBytes(i))
            Next

        Catch ex As Exception
            Return ""
        End Try

        'rt = ReadFile(LibName, LibData)
        'If rt < 0 Then Return ""

        '========================================= Header
        'xxxxxxxx -> library identifier data ".CDL"
        'iiiiiiii -> library type identifier
        'tttttttt -> table size
        'cccccccc -> function count

        'i:00000000 = function library
        'i:00000001 = library archive

        If sp(LibI) <> "" Then
            Do
                LibData = ExtractLib(LibData, sp(LibI))
                LibI += 1
            Loop Until sp(LibI) = ""
        End If

        If LibData = "" Then Return ""
        If Strings.Mid(LibData, 1, 4) <> ".CDL" Then Return ""
        LibType = Val("&H" + HexReverse(StrToHex(Strings.Mid(LibData, 5, 4))))

        If LibType > 1 Then Return ""

        TableSize = Val("&H" + HexReverse(StrToHex(Strings.Mid(LibData, 9, 4))))
        FuncCount = Val("&H" + HexReverse(StrToHex(Strings.Mid(LibData, 13, 4))))

        ret = ""
        ReadPos = 17
        For i = 1 To FuncCount
            '========================================= function table (function library)
            'ffffffff -> function declaration entry
            'cccccccc -> function call dependancies entry
            'nnnnnnnn -> function call dependancies count
            'dddddddd -> function data entry
            'ssssssss -> function size

            'Read Function Declaration
            Entry = Val("&H" + HexReverse(StrToHex(Strings.Mid(LibData, (ReadPos + 0), 4)))) + 1
            MyFunc.Declaration = ReadString(LibData, Entry)

            'Read Function Dependancies
            MyFunc.DependCount = Val("&H" + HexReverse(StrToHex(Strings.Mid(LibData, (ReadPos + 8), 4))))
            If MyFunc.DependCount > 0 Then
                Entry = Val("&H" + HexReverse(StrToHex(Strings.Mid(LibData, (ReadPos + 4), 4)))) + 1
                ReDim MyFunc.Dependancies(MyFunc.DependCount - 1)
                For i2 = 0 To MyFunc.DependCount - 1
                    MyFunc.Dependancies(i2) = ReadString(LibData, Entry)
                    Entry += Len(MyFunc.Dependancies(i2))
                    Do Until Strings.Mid(LibData, Entry, 1) <> Chr(0) Or Entry > Len(LibData)
                        Entry += 1
                    Loop
                Next
            End If
            Entry = Val("&H" + HexReverse(StrToHex(Strings.Mid(LibData, (ReadPos + 12), 4)))) + 1

            'Read Function Data
            MyFunc.FSize = Val("&H" + HexReverse(StrToHex(Strings.Mid(LibData, (ReadPos + 16), 4))))
            'MyFunc.Contents = ""
            'For i2 = 0 To MyFunc.FSize
            'MyFunc.Contents += Strings.Right("00" + Hex(FBytes(Entry + i2)), 2)
            'Next
            MyFunc.Contents = Strings.Mid(LibData.ToString, Entry, MyFunc.FSize)

            'Check if this is the requested function
            sp = Split(parseSyntax(MyFunc.Declaration) + " ", " ")
            If sp(2) = FuncName Then
                If MyFunc.DependCount > 0 Then
                    ReDim Dependancies(MyFunc.DependCount - 1)
                    For i2 = 0 To MyFunc.DependCount - 1
                        Dependancies(i2) = MyFunc.Dependancies(i2)
                    Next
                End If
                ret = ""
                i = 0
                For i2 = 1 To Len(MyFunc.Contents)
                    tStr = HexReverse(StrToHex(Strings.Mid(MyFunc.Contents, i2, 4)))
                    If LCase(Strings.Left(tStr, 2)) = "0c" Then
                        tStr = "jal :" + MyFunc.Dependancies(i)
                        i += 1
                    Else
                        tStr = "hexcode $" + tStr
                    End If

                    ret += tStr + vbCrLf
                    i2 += 3
                Next

                'FuncDeclare = MyFunc.Declaration
                Return MyFunc.Declaration + vbCrLf + ret  'vbCrLf + vbCrLf + StrToHex(MyFunc.Contents)
            End If

            ReadPos += 20
        Next

        Return ""
    End Function

    Public Function BuildArchive(Src() As String, Names() As String) As String
        Dim pHeader As String, vHeader As String, pBody As String


        '========================================= Header
        'xxxxxxxx -> library identifier data ".CDL"
        'iiiiiiii -> library type identifier
        'tttttttt -> table size
        'cccccccc -> function count

        'i:00000000 = function library
        'i:00000001 = library archive
        'i:00000002 = source library

        pHeader = ".CDL"
        pHeader += StrToHex(HexReverse("00000001"))
        pHeader += StrToHex(HexReverse(Strings.Right("00000000" + Hex(Src.Count * 12), 8)))
        pHeader += StrToHex(HexReverse(Strings.Right("00000000" + Hex(Src.Count), 8)))

        '========================================= library table (archive)
        'nnnnnnnn -> function library name entry
        'eeeeeeee -> function library entry
        'ssssssss -> function library size

        Dim I As Integer, entry As Integer, tstr As String
        entry = Len(pHeader) + (Src.Count * 12)
        For I = 0 To Src.Count - 1

            'Library Name Entry
            vHeader += StrToHex(HexReverse(Strings.Right("00000000" + Hex(entry), 8)))
            tstr = Names(I) + Chr(0)
            Do Until (Len(tstr) / 4) = (Len(tstr) \ 4)
                tstr += Chr(0)
            Loop
            pBody += tstr

            'Library Data Entry
            entry += Len(tstr)
            vHeader += StrToHex(HexReverse(Strings.Right("00000000" + Hex(entry), 8)))
            pBody += Src(I)

            'Library Size 
            vHeader += StrToHex(HexReverse(Strings.Right("00000000" + Hex(Len(Src(I))), 8)))
            entry += Len(Src(I))
        Next


        Return pHeader + vHeader + pBody
    End Function

    Public Function BuildSourceLibrary(Src As String) As String

    End Function

    Public Function BuildCompiledLibrary(Src As String, ByRef Cmp As Compiler) As String
        Dim rt As Integer, ret As String, CodeData As String
        Dim Lines() As String, sp() As String, i As Integer
        Dim FncList() As FunctionInfo, FncCount As Integer, isInFunc As Boolean
        Dim BrC As Integer

        ret = ""
        CodeData = ""
        rt = Cmp.CompileSingle(Src, CodeData, False)
        If rt < 0 Then Return ""

        FncCount = -1
        isInFunc = False
        Lines = Split(Replace(Src, vbCrLf, vbLf) + vbLf, vbLf)
        BrC = -1
        For i = 0 To Lines.Count - 1
            Lines(i) = stripWhiteSpace(Lines(i))
            sp = Split(parseSyntax(Lines(i)) + " ", " ")


            Select Case LCase(sp(0))
                Case "fnc"
                    FncCount += 1
                    ReDim Preserve FncList(FncCount)
                    sp(0) = "extern %thisaddr"
                    FncList(FncCount).Declaration = Join(sp, " ") + Chr(0) 'Strings.Right(Lines(i), Len(Lines(i)) - 3) + Chr(0)
                    Do Until (Len(FncList(FncCount).Declaration) / 4) = (Len(FncList(FncCount).Declaration) \ 4)
                        FncList(FncCount).Declaration += Chr(0)
                    Loop
                    FncList(FncCount).DSize = Len(FncList(FncCount).Declaration)
                    FncList(FncCount).DependCount = -1
                    isInFunc = True
                    BrC = 0
                Case "{"
                    BrC += 1
                Case "}"
                    BrC -= 1
                    If BrC = 0 Then isInFunc = False
                Case "call"
                    If isInFunc Then
                        With FncList(FncCount)
                            .DependCount += 1
                            ReDim Preserve .Dependancies(.DependCount)
                            .Dependancies(.DependCount) = sp(1) + Chr(0)
                            Do Until (Len(.Dependancies(.DependCount)) / 4) = (Len(.Dependancies(.DependCount)) \ 4)
                                .Dependancies(.DependCount) += Chr(0)
                            Loop
                            .DependantSize += Len(.Dependancies(.DependCount))
                        End With
                    End If
            End Select
        Next
        If FncCount < 0 Then Return ""

        isInFunc = False
        BrC = -1
        Lines = Split(CodeData + vbCrLf, vbCrLf)
        For i = 0 To Lines.Count - 1
            If Lines(i) <> "" Then
                sp = Split(Lines(i), " ")
                If UCase(Strings.Left(sp(1), 5)) = "27BDF" Then
                    BrC += 1
                    isInFunc = True
                End If

                If isInFunc Then
                    FncList(BrC).Contents += HexToStr(HexReverse(sp(1)))
                    If UCase(sp(1)) = "03E00008" Then
                        sp = Split(Lines(i + 1), " ")
                        If UCase(Strings.Left(sp(1), 5)) = "27BD0" Then
                            FncList(BrC).Contents += HexToStr(HexReverse(sp(1)))
                            isInFunc = False
                        End If
                    End If
                End If
            End If
        Next

        Dim pHeader As String, vHeader As String, pBody As String, Entry As Integer

        '========================================= Header
        'xxxxxxxx -> library identifier data ".CDL"
        'iiiiiiii -> library type identifier
        'tttttttt -> table size
        'cccccccc -> function count

        'i:00000000 = function library
        'i:00000001 = library archive

        Entry = 0
        pHeader = ".CDL"
        pHeader += HexToStr("00000000")
        pHeader += HexToStr(HexReverse(Strings.Right("00000000" + Hex((FncCount + 1) * 20), 8)))
        pHeader += HexToStr(HexReverse(Strings.Right("00000000" + Hex(FncCount + 1), 8)))

        Entry += Len(pHeader) + ((FncCount + 1) * 20)

        '========================================= function table (function library)
        'ffffffff -> function declaration entry
        'cccccccc -> function call dependancies entry
        'nnnnnnnn -> function call dependancies count
        'dddddddd -> function data entry
        'ssssssss -> function size
        vHeader = ""
        pBody = ""
        For i = 0 To FncCount
            With FncList(i)
                .FSize = Len(.Contents)

                'Declaration Entry
                vHeader += HexToStr(HexReverse(Strings.Right("00000000" + Hex(Entry), 8)))
                Entry += .DSize
                pBody += .Declaration

                'Dependancies List Entry
                If .DependCount < 0 Then
                    vHeader += HexToStr("00000000")
                Else
                    vHeader += HexToStr(HexReverse(Strings.Right("00000000" + Hex(Entry), 8)))
                End If
                Entry += .DependantSize
                pBody += Join(.Dependancies, "")

                'Dependancies List Count
                vHeader += HexToStr(HexReverse(Strings.Right("00000000" + Hex(.DependCount + 1), 8)))

                'Function Data Entry
                vHeader += HexToStr(HexReverse(Strings.Right("00000000" + Hex(Entry), 8)))

                'Function Data Size
                vHeader += HexToStr(HexReverse(Strings.Right("00000000" + Hex(.FSize), 8)))
                Entry += .FSize
                pBody += .Contents

            End With
        Next

        Return pHeader + vHeader + pBody
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
            If Left(ret, 1).Equals(" ") Then ret = Right(ret, ret.Length - 1)
            If Right(ret, 1).Equals(" ") Then ret = Left(ret, ret.Length - 1)
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
