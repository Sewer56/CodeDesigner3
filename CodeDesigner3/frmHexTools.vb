Public Class frmHexTools
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIN.Text = "" Then Exit Sub
        txtOUT.Text = StrToHex(txtIN.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Tmp As String, i As Integer
        If txtIN.Text = "" Then Exit Sub

        Tmp = ""
        For i = 1 To Len(txtIN.Text) Step 2
            If Strings.Mid(txtIN.Text, i, 2) <> "00" Then Tmp += Strings.Mid(txtIN.Text, i, 2)
        Next
        txtOUT.Text = HexToStr(Tmp) 'txtIN.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim addr As Integer, i As Integer, outp As String, cline As String
        addr = Val("&H" + txtAddr.Text)

        If txtIN.Text = "" Then Exit Sub
        outp = ""
        For i = 1 To Len(txtIN.Text) Step 4
            cline = Strings.Right("00000000" + HexReverse(StrToHex(Strings.Mid(txtIN.Text, i, 4))), 8)
            outp += Strings.Right("00000000" + Hex(addr), 8) + " " + cline + vbCrLf
            addr += 4
        Next

        txtOUT.Text = outp
    End Sub
End Class