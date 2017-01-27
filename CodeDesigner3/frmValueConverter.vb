Public Class frmValueConverter
    Private fVal As RegisterFloat, allowUpdate As Boolean


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSingle.TextChanged
        If allowUpdate = False Then Exit Sub
        allowUpdate = False
        On Error Resume Next

        fVal.f32 = Val(txtSingle.Text)

        txtSingle32.Text = Strings.Right("00000000" + Hex(fVal.u32), 8)
        txtWord.Text = Strings.Right("00000000" + Hex(fVal.f32), 8)

        allowUpdate = True
    End Sub

    Private Sub txtSingle32_TextChanged(sender As Object, e As EventArgs) Handles txtSingle32.TextChanged
        If allowUpdate = False Then Exit Sub
        allowUpdate = False
        On Error Resume Next

        fVal.u32 = CDec("&H" + txtSingle32.Text)

        txtSingle.Text = fVal.f32.ToString
        txtWord.Text = Strings.Right("00000000" + Hex(fVal.f32), 8)

        allowUpdate = True
    End Sub

    Private Sub txtWord_TextChanged(sender As Object, e As EventArgs) Handles txtWord.TextChanged
        If allowUpdate = False Then Exit Sub
        allowUpdate = False
        On Error Resume Next

        fVal.f32 = Val("&H" + txtWord.Text)

        txtSingle.Text = fVal.f32.ToString
        txtSingle32.Text = Strings.Right("00000000" + Hex(fVal.u32), 8)

        allowUpdate = True
    End Sub

    Private Sub frmValueConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        allowUpdate = True
    End Sub

End Class