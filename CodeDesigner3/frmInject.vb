Public Class frmInject
    Private InjectData As String

    Public Sub SetData(Code As String)
        InjectData = Code
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rt As Integer

        With OpenFileDialog1
            .FileName = ""
            .Filter = "All Files|*.*"

            rt = .ShowDialog
            If rt = 2 Then Exit Sub

            txtFile.Text = .FileName
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim FS As System.IO.FileStream, fBytes() As Byte, rt As Integer, wrAddr As Integer


        Try
            If My.Computer.FileSystem.FileExists(txtFile.Text) = False Then
                MsgBox("File does not exist!", vbOKOnly, "File Injection")
                Exit Sub
            End If
            rt = CodeToBytes(InjectData, fBytes)
            wrAddr = Val("&H" + txtOffset.Text)

            FS = System.IO.File.OpenWrite(txtFile.Text)
            FS.Seek(wrAddr, IO.SeekOrigin.Begin)
            FS.Write(fBytes, 0, fBytes.Length)
            FS.Close()

            MsgBox("File injected successfully!")
            Me.Close()
        Catch ex As Exception
            MsgBox("An error occurred")
            Me.Close()
        End Try
    End Sub
End Class