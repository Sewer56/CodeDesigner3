Public Class frmFindReplaceGoto
    Private Sub txtLine_TextChanged(sender As Object, e As EventArgs) Handles txtLine.TextChanged
        If Val(txtLine.Text).ToString <> txtLine.Text Then txtLine.Text = Val(txtLine.Text).ToString
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmMain.SyntaxView1.GotoLine(Val(txtLine.Text))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rt As Integer
        If txtFind.Text = "" Then Exit Sub
        rt = frmMain.SyntaxView1.FindNext(txtFind.Text, chkCase.Checked)
        If rt < 0 Then MsgBox("No results found", vbOKOnly, "Find/Replace")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim rt As Integer
        If txtFind.Text = "" Then Exit Sub
        rt = frmMain.SyntaxView1.FindReplace(txtFind.Text, txtReplace.Text, chkCase.Checked)
        If rt < 0 Then MsgBox("No results found", vbOKOnly, "Find/Replace")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim rt As Integer
        If txtFind.Text = "" Then Exit Sub
        rt = frmMain.SyntaxView1.ReplaceAll(txtFind.Text, txtReplace.Text, chkCase.Checked)
        If rt <= 0 Then MsgBox("No results found", vbOKOnly, "Find/Replace")
        If rt > 0 Then MsgBox(rt.ToString + " replacements made", vbOKOnly, "Find/Replace")
    End Sub
End Class