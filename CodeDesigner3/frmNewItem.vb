Public Class frmNewItem
    Private ItemMode As String, ItemArgs As String

    Public Sub SetMode(newMode As String, Args As String)
        ItemMode = newMode
        ItemArgs = Args
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Exit Sub
        Dim s As Integer, ext As String

        ext = ".cds"
        If ItemMode = "SaveProjectAs" Then ext = ".cdp"
        If ItemMode = "ChangeProject" Then ext = ".cdp"

        s = txtName.SelectionStart
        If LCase(Strings.Right(txtName.Text, Len(ext))) <> ext Then
            txtName.Text += ext
            txtName.SelectionStart = s
        Else
            If txtName.SelectionStart > Len(txtName.Text) - Len(ext) Then s = Len(txtName.Text) - Len(ext)
            txtName.SelectionStart = s
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim args(2) As String, rt As Integer

        args(0) = txtPath.Text
        args(1) = txtName.Text
        args(2) = ""

        Select Case ItemMode
            Case "BlankFile"
                If LCase(args(1)) = ".cds" Then
                    MsgBox("File must have a name", vbOKOnly, Me.Text)
                    Exit Sub
                End If
            Case "ExistingFile"
                If LCase(args(1)) = ".cds" Then
                    MsgBox("File must have a name", vbOKOnly, Me.Text)
                    Exit Sub
                End If
                rt = ReadFile(args(0), args(2))
                If rt < 0 Then
                    MsgBox("Error opening file!", vbOKOnly, "Add File")
                    Exit Sub
                End If
            Case "ChangeFile"
            Case "SaveFileAs"
            Case "SaveProjectAs"
            Case "ChangeProject"

        End Select


        frmMain.formNewItemReturn(args, 1)

        Me.Close()
    End Sub

    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        Dim rt As Integer, sp() As String

        Select Case ItemMode
            Case "ExistingFile"
                With OpenFileDialog1
                    .FileName = ""
                    .Filter = "CodeDesigner Source|*.cds"
                    rt = .ShowDialog()
                    If rt = 2 Then Exit Sub
                    txtPath.Text = .FileName
                    sp = Split("\" + .FileName, "\")
                    txtName.Text = sp(sp.Count - 1)
                End With
            Case "SaveFileAs"
            Case "SaveProjectAs"
        End Select
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmNewItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case ItemMode
            Case "BlankFile"
                Me.Text = "Add Blank File"
                btnPath.Visible = False
                lblPath.Visible = False
                txtPath.Visible = False
                lblName.Visible = True
                txtName.Visible = True
                txtName.Text = ItemArgs
            Case "ExistingFile"
                Me.Text = "Add Existing File"
                btnPath.Visible = True
                lblPath.Visible = True
                txtPath.Visible = True
                lblName.Visible = True
                txtName.Visible = True
                txtName.Text = ""
            Case "ChangeFile"
                Me.Text = "Edit File Name"
                btnPath.Visible = False
                lblPath.Visible = False
                txtPath.Visible = False
                lblName.Visible = True
                txtName.Visible = True
                txtName.Text = ItemArgs
            Case "SaveFileAs"
                Me.Text = "Save File As..."
            Case "SaveProjectAs"
                Me.Text = "Save Project As..."
            Case "ChangeProject"
                Me.Text = "Edit Project Name"
        End Select
    End Sub
End Class