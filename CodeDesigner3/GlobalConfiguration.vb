Module GlobalConfiguration


    Public Sub SVUseDefault(ByRef SV As SyntaxView, ByRef mpAsm As MIPSAssembly)
        SV.SetSyntaxCmdConfig("hexcode", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("setreg", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("setfpr", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("setfloat", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("address", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("string", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("print", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("padding", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("call", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("goto", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("define", Val("&HFFff00ff"), "{b}")

        SV.SetSyntaxCmdConfig("import", Val("&HFFff00ff"), "{b}")

        SV.SetSyntaxCmdConfig("if", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("else", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxArgConfig("if", Val("&HFFff00ff"))

        SV.SetSyntaxCmdConfig("switch", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("case", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("default", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("%break", Val("&HFFff00ff"), "{b}")

        SV.SetSyntaxCmdConfig("fnc", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("return", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("extern", Val("&HFFff00ff"), "{b}")

        SV.SetSyntaxCmdConfig("for", Val("&HFFff00ff"), "{b}")
        SV.SetSyntaxCmdConfig("while", Val("&HFFff00ff"), "{b}")

        SV.SetSyntaxCmdConfig("%7b", Val("&HFFffff00"), "{b}")
        SV.SetSyntaxCmdConfig("%7d", Val("&HFFffff00"), "{b}")

        SV.SetSyntaxArgConfig("zero", Val("&HFFaaaaaa"))
        SV.SetSyntaxArgConfig("at", Val("&HFF00a070"))
        SV.SetSyntaxArgConfig("v0", Val("&HFFff8000"))
        SV.SetSyntaxArgConfig("v1", Val("&HFFff8000"))
        SV.SetSyntaxArgConfig("a0", Val("&HFF0080ff"))
        SV.SetSyntaxArgConfig("a1", Val("&HFF0080ff"))
        SV.SetSyntaxArgConfig("a2", Val("&HFF0080ff"))
        SV.SetSyntaxArgConfig("a3", Val("&HFF0080ff"))
        SV.SetSyntaxArgConfig("t0", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t1", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t2", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t3", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t4", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t5", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t6", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t7", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t8", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("t9", Val("&HFF904090"))
        SV.SetSyntaxArgConfig("s0", Val("&HFFc0c040"))
        SV.SetSyntaxArgConfig("s1", Val("&HFFc0c040"))
        SV.SetSyntaxArgConfig("s2", Val("&HFFc0c040"))
        SV.SetSyntaxArgConfig("s3", Val("&HFFc0c040"))
        SV.SetSyntaxArgConfig("s4", Val("&HFFc0c040"))
        SV.SetSyntaxArgConfig("s5", Val("&HFFc0c040"))
        SV.SetSyntaxArgConfig("s6", Val("&HFFc0c040"))
        SV.SetSyntaxArgConfig("s7", Val("&HFFc0c040"))
        SV.SetSyntaxArgConfig("fp", Val("&HFFc0ffc0"))
        SV.SetSyntaxArgConfig("gp", Val("&HFF80ff00"))
        SV.SetSyntaxArgConfig("sp", Val("&HFFffff00"))
        SV.SetSyntaxArgConfig("k0", Val("&HFF808000"))
        SV.SetSyntaxArgConfig("k1", Val("&HFF808000"))
        SV.SetSyntaxArgConfig("ra", Val("&HFF900000"))


        SV.SetSyntaxArgConfig("ee", Val("&HFFff8080"))
        SV.SetSyntaxArgConfig("cop1", Val("&HFFff8080"))
        SV.SetSyntaxArgConfig("void", Val("&HFFff8080"))

        Dim i As Integer
        For i = 0 To 258
            SV.SetSyntaxCmdConfig(mpAsm.GetInstrName(i), Val("&HFFffffff"), "{b}")
        Next
        SV.SetSyntaxCmdConfig("at", Val("&HFF00a070"), "{b}")
        SV.SetSyntaxCmdConfig("v0", Val("&HFFff8000"), "{b}")
        SV.SetSyntaxCmdConfig("v1", Val("&HFFff8000"), "{b}")
        SV.SetSyntaxCmdConfig("a0", Val("&HFF0080ff"), "{b}")
        SV.SetSyntaxCmdConfig("a1", Val("&HFF0080ff"), "{b}")
        SV.SetSyntaxCmdConfig("a2", Val("&HFF0080ff"), "{b}")
        SV.SetSyntaxCmdConfig("a3", Val("&HFF0080ff"), "{b}")
        SV.SetSyntaxCmdConfig("t0", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t1", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t2", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t3", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t4", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t5", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t6", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t7", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t8", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("t9", Val("&HFF904090"), "{b}")
        SV.SetSyntaxCmdConfig("s0", Val("&HFFc0c040"), "{b}")
        SV.SetSyntaxCmdConfig("s1", Val("&HFFc0c040"), "{b}")
        SV.SetSyntaxCmdConfig("s2", Val("&HFFc0c040"), "{b}")
        SV.SetSyntaxCmdConfig("s3", Val("&HFFc0c040"), "{b}")
        SV.SetSyntaxCmdConfig("s4", Val("&HFFc0c040"), "{b}")
        SV.SetSyntaxCmdConfig("s5", Val("&HFFc0c040"), "{b}")
        SV.SetSyntaxCmdConfig("s6", Val("&HFFc0c040"), "{b}")
        SV.SetSyntaxCmdConfig("s7", Val("&HFFc0c040"), "{b}")
        SV.SetSyntaxCmdConfig("fp", Val("&HFFc0ffc0"), "{b}")
        SV.SetSyntaxCmdConfig("gp", Val("&HFF80ff00"), "{b}")
        SV.SetSyntaxCmdConfig("sp", Val("&HFFffff00"), "{b}")
        SV.SetSyntaxCmdConfig("k0", Val("&HFF808000"), "{b}")
        SV.SetSyntaxCmdConfig("k1", Val("&HFF808000"), "{b}")
        SV.SetSyntaxCmdConfig("ra", Val("&HFF900000"), "{b}")
    End Sub

    Public Function ReadFile(fName As String, ByRef fData As String) As Integer
        Dim F As System.IO.FileStream, fBytes() As Byte, rt As Integer

        Try
            If System.IO.File.Exists(fName) Then

                F = System.IO.File.Open(fName, System.IO.FileMode.Open)
                ReDim fBytes(F.Length)
                rt = F.Read(fBytes, 0, F.Length)
                F.Close()

                F.Dispose()

                'fData = System.Text.Encoding.UTF8.GetString(fBytes)
                fData = BytesToStr(fBytes)
                If Strings.Right(fData, 1) = Chr(0) Then fData = Strings.Left(fData, Len(fData) - 1)

                GC.Collect()
                Return 0
            Else
                Return -2
            End If
        Catch Ex As Exception
            frmMain.DebugOut(Ex.ToString)
            Return -1
        End Try

    End Function

    Public Function SaveFile(fName As String, fData As String) As Integer
        Dim F As System.IO.FileStream, fBytes() As Byte

        Try
            If System.IO.File.Exists(fName) Then
                Try
                    System.IO.File.Delete(fName)

                    F = System.IO.File.Create(fName)
                    'fBytes = New System.Text.UTF8Encoding(False).GetBytes(fData)
                    StrToBytes(fData, fBytes)
                    F.Write(fBytes, 0, fBytes.Length)
                    F.Close()

                    F.Dispose()
                    fBytes = Nothing
                Catch Ex As Exception
                    frmMain.DebugOut(Ex.ToString)
                    Return -1
                End Try
            Else

                Try
                    F = System.IO.File.Create(fName)
                    'fBytes = New System.Text.UTF8Encoding(False).GetBytes(fData)
                    StrToBytes(fData, fBytes)
                    F.Write(fBytes, 0, fBytes.Length)
                    F.Close()

                    F.Dispose()
                    fBytes = Nothing
                Catch Ex As Exception
                    frmMain.DebugOut(Ex.ToString)
                    Return -1
                End Try

            End If
        Catch Ex As Exception
            frmMain.DebugOut(Ex.ToString)
            Return -1
        End Try

        GC.Collect()
        Return 0
    End Function

    Public Function HexToStr(ByRef HexStr As String) As String
        Dim i As Integer, ret As String

        ret = ""
        For i = 1 To Len(HexStr)
            ret += Chr(Val("&H" + Strings.Mid(HexStr, i, 2)))
            i += 1
        Next

        Return ret
    End Function

    Public Function HexReverse(ByRef HexStr As String) As String
        Dim i As Integer, ret As String

        ret = ""
        For i = 1 To Len(HexStr)
            ret = Strings.Mid(HexStr, i, 2) + ret
            i += 1
        Next

        Return ret
    End Function

    Public Function StrToHex(ByRef Str As String) As String
        Dim i As Integer, ret As String

        ret = ""
        For i = 1 To Len(Str)
            ret += Strings.Right("00" + Hex(Asc(Strings.Mid(Str, i, 1))), 2)
        Next

        Return ret
    End Function

    Public Function StrToBytes(Str As String, ByRef Bytes() As Byte) As Integer
        Dim i As Integer, n As Integer

        n = Len(Str) - 1
        ReDim Bytes(n)
        For i = 1 To Len(Str)
            Bytes(i - 1) = Asc(Strings.Mid(Str, i, 1))
        Next

        Return n
    End Function

    Public Function BytesToStr(ByRef Bytes() As Byte) As String
        Dim i As Integer, ret As String

        ret = ""
        For i = 0 To Bytes.Count - 1
            ret += Chr(Bytes(i))
        Next

        Return ret
    End Function


    Public Function StringToCode(StartAddr As Int32, Bin As String) As String
        Dim i As Integer, ret As String, tStr As String, MemAddr As Int32

        MemAddr = StartAddr

        ret = ""
        For i = 1 To Len(Bin)
            tStr = HexReverse(StrToHex(Strings.Mid(Bin, i, 4)))
            ret += Strings.Right("00000000" + Hex(MemAddr), 8) + " " + tStr
            MemAddr += 4
        Next

        Return ret
    End Function

    Public Function CodeToBytes(Code As String, ByRef Bytes() As Byte) As Integer
        Dim i As Integer, Lines() As String, sp() As String, ret As String
        Dim n As Integer

        ret = ""

        n = -1
        Lines = Split(Code + vbCrLf, vbCrLf)
        For i = 0 To Lines.Count - 1
            sp = Split(Lines(i) + " ", " ")
            If sp(1) <> "" Then
                sp(1) = Strings.Right("00000000" + sp(1), 8)
                ret = HexToStr(HexReverse(sp(1)))
                n += 4
                ReDim Preserve Bytes(n)
                Bytes(n - 3) = Asc(Strings.Mid(ret, 1, 1))
                Bytes(n - 2) = Asc(Strings.Mid(ret, 2, 1))
                Bytes(n - 1) = Asc(Strings.Mid(ret, 3, 1))
                Bytes(n - 0) = Asc(Strings.Mid(ret, 4, 1))
            End If
        Next

        Return n
    End Function

    Public Function CodeToString(Code As String) As String
        Dim i As Integer, Lines() As String, sp() As String, ret As String

        ret = ""

        Lines = Split(Code + vbCrLf, vbCrLf)
        For i = 0 To Lines.Count - 1
            sp = Split(Lines(i) + " ", " ")
            If sp(1) <> "" Then
                sp(1) = Strings.Right("00000000" + sp(1), 8)
                ret += HexToStr(HexReverse(sp(1)))
            End If
        Next

        Return ret
    End Function

End Module
