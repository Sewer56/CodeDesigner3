Public Class frmPS2Controller
    Private Const PAD_D_UP = &H10
    Private Const PAD_D_DOWN = &H40
    Private Const PAD_D_LEFT = &H80
    Private Const PAD_D_RIGHT = &H20
    Private Const PAD_TRIANGLE = &H1000
    Private Const PAD_CIRCLE = &H2000
    Private Const PAD_CROSS = &H4000
    Private Const PAD_SQUARE = &H8000
    Private Const PAD_R1 = &H800
    Private Const PAD_R2 = &H200
    Private Const PAD_R3 = &H4
    Private Const PAD_L1 = &H400
    Private Const PAD_L2 = &H100
    Private Const PAD_L3 = &H2
    Private Const PAD_START = &H8
    Private Const PAD_SELECT = &H1

    Private Sub UpdateSelections()
        Dim JokerValue As Integer, SelText As String
        JokerValue = &HFFFF

        SelText = ""

        If chkSelect.Checked Then
            JokerValue -= PAD_SELECT
            SelText += "Select, "
        End If
        If chkStart.Checked Then
            JokerValue -= PAD_START
            SelText += "Start, "
        End If

        If SelText <> "" Then SelText += vbCrLf
        If chkR1.Checked Then
            JokerValue -= PAD_R1
            SelText += "R1, "
        End If
        If chkR2.Checked Then
            JokerValue -= PAD_R2
            SelText += "R2, "
        End If
        If chkR3.Checked Then
            JokerValue -= PAD_R3
            SelText += "R3, "
        End If

        If SelText <> "" Then SelText += vbCrLf
        If chkL1.Checked Then
            JokerValue -= PAD_L1
            SelText += "L1, "
        End If
        If chkL2.Checked Then
            JokerValue -= PAD_L2
            SelText += "L2, "
        End If
        If chkL3.Checked Then
            JokerValue -= PAD_L3
            SelText += "L3, "
        End If

        If SelText <> "" Then SelText += vbCrLf
        If chkDUp.Checked Then
            JokerValue -= PAD_D_UP
            SelText += "D-Up, "
        End If
        If chkDDown.Checked Then
            JokerValue -= PAD_D_DOWN
            SelText += "D-Down, "
        End If
        If chkDLeft.Checked Then
            JokerValue -= PAD_D_LEFT
            SelText += "D-Left, "
        End If
        If chkDRight.Checked Then
            JokerValue -= PAD_D_RIGHT
            SelText += "D-Right, "
        End If

        If SelText <> "" Then SelText += vbCrLf
        If chkTriangle.Checked Then
            JokerValue -= PAD_TRIANGLE
            SelText += "Triangle, "
        End If
        If chkCircle.Checked Then
            JokerValue -= PAD_CIRCLE
            SelText += "Circle, "
        End If
        If chkCross.Checked Then
            JokerValue -= PAD_CROSS
            SelText += "Cross, "
        End If
        If chkSquare.Checked Then
            JokerValue -= PAD_SQUARE
            SelText += "Square, "
        End If

        If SelText = "" Then SelText = "(None)"
        If Strings.Right(SelText, 2) = ", " Then SelText = Strings.Left(SelText, Len(SelText) - 2)

        txtSelections.Text = "Selections:" + vbCrLf + SelText
        txtOutput.Text = Strings.Right("00000000" + Hex(JokerValue), 8)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        chkR1.Checked = False
        chkR2.Checked = False
        chkR3.Checked = False
        chkL1.Checked = False
        chkL2.Checked = False
        chkL3.Checked = False
        chkTriangle.Checked = False
        chkCircle.Checked = False
        chkCross.Checked = False
        chkSquare.Checked = False
        chkStart.Checked = False
        chkSelect.Checked = False
        chkDUp.Checked = False
        chkDRight.Checked = False
        chkDDown.Checked = False
        chkDLeft.Checked = False
    End Sub

    Private Sub chkStart_CheckedChanged(sender As Object, e As EventArgs) Handles chkStart.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelect.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkR2_CheckedChanged(sender As Object, e As EventArgs) Handles chkR2.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkR1_CheckedChanged(sender As Object, e As EventArgs) Handles chkR1.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkTriangle_CheckedChanged(sender As Object, e As EventArgs) Handles chkTriangle.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkSquare_CheckedChanged(sender As Object, e As EventArgs) Handles chkSquare.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkCircle_CheckedChanged(sender As Object, e As EventArgs) Handles chkCircle.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkCross_CheckedChanged(sender As Object, e As EventArgs) Handles chkCross.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkR3_CheckedChanged(sender As Object, e As EventArgs) Handles chkR3.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkL3_CheckedChanged(sender As Object, e As EventArgs) Handles chkL3.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkL2_CheckedChanged(sender As Object, e As EventArgs) Handles chkL2.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkL1_CheckedChanged(sender As Object, e As EventArgs) Handles chkL1.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkDUp_CheckedChanged(sender As Object, e As EventArgs) Handles chkDUp.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkDLeft_CheckedChanged(sender As Object, e As EventArgs) Handles chkDLeft.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkDDown_CheckedChanged(sender As Object, e As EventArgs) Handles chkDDown.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub chkDRight_CheckedChanged(sender As Object, e As EventArgs) Handles chkDRight.CheckedChanged
        UpdateSelections()
    End Sub

    Private Sub frmPS2Controller_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class