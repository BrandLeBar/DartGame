Option Strict On
Option Explicit On

Public Class DartGameForm

    Sub SetDefaults()

    End Sub

    Sub DrawLine()
        Dim g As Graphics = DartBoardPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Black, 10)
        g.DrawLine(pen, 100, 100, 200, 200)
        pen.Dispose()
        g.Dispose()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        DartBoardPictureBox.Invalidate()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles DartBoardPictureBox.Click
        ThrowDart()
    End Sub

    Sub DrawDart(x%, y%)
        Dim g As Graphics = DartBoardPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Green)
        Dim dartWidth% = 30

        g.DrawEllipse(pen, x - (dartWidth \ 2), y - (dartWidth \ 2), dartWidth, dartWidth)
        g.DrawLine(pen, x - (dartWidth \ 4), y, x + (dartWidth \ 4), y)
        g.DrawLine(pen, x, y - (dartWidth \ 4), x, y + (dartWidth \ 4))

        pen.Dispose()
        g.Dispose()
    End Sub

    Function ThrowDart(Optional oldValues As Boolean = False, Optional x1% = 0, Optional x2% = 0, Optional x3% = 0, Optional y1% = 0, Optional y2% = 0, Optional y3% = 0) As (Integer, Integer, Integer, Integer, Integer, Integer)
        Dim randomX1 As Integer
        Dim randomX2 As Integer
        Dim randomX3 As Integer
        Dim randomY1 As Integer
        Dim randomY2 As Integer
        Dim randomY3 As Integer
        If oldValues = False Then
            randomX1 = RandomNumberGeneratorZeroTo(DartBoardPictureBox.Width)
            randomX2 = RandomNumberGeneratorZeroTo(DartBoardPictureBox.Width)
            randomX3 = RandomNumberGeneratorZeroTo(DartBoardPictureBox.Width)
            randomY1 = RandomNumberGeneratorZeroTo(DartBoardPictureBox.Height)
            randomY2 = RandomNumberGeneratorZeroTo(DartBoardPictureBox.Height)
            randomY3 = RandomNumberGeneratorZeroTo(DartBoardPictureBox.Height)
        ElseIf oldValues = True Then
            randomX1 = x1
            randomX2 = x2
            randomX3 = x3
            randomY1 = y1
            randomY2 = y2
            randomY3 = y3
        End If
        DrawDart(randomX1, randomY1)
        DrawDart(randomX2, randomY2)
        DrawDart(randomX3, randomY3)
        Return (randomX1, randomX2, randomX3, randomY1, randomY2, randomY3)
    End Function

    Function RandomNumberGeneratorZeroTo(max%) As Integer
        Randomize()
        Return CInt(System.Math.Floor(CDbl(Rnd() * max))) + 1
    End Function

    Private Sub DrawPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DartBoardPictureBox.MouseMove
        CoordsStatusLabel.Text = ($"X = {e.X} & Y = {e.Y}")
    End Sub

    Private Sub ThrowButton_Click(sender As Object, e As EventArgs) Handles ThrowButton.Click
        Dim results As (Integer, Integer, Integer, Integer, Integer, Integer)
        If True = True Then
            results = ThrowDart()
            LogEvent(results.Item1, results.Item2, results.Item3, results.Item4, results.Item5, results.Item6)
        End If

    End Sub

    Private Sub ReviewButton_Click(sender As Object, e As EventArgs) Handles ReviewButton.Click
        ReadFromFile(1, "Round.log")
    End Sub

    Sub LogEvent(x1%, x2%, x3%, y1%, y2%, y3%)
        Dim path As String = "Round.log"
        FileOpen(1, path, OpenMode.Append)
        Write(1, $"Dart 1 X = {x1}")
        Write(1, $"Dart 2 X = {x2}")
        Write(1, $"Dart 3 X = {x3}")
        Write(1, $"Dart 1 Y = {y1}")
        Write(1, $"Dart 2 Y = {y2}")
        Write(1, $"Dart 3 Y = {y3}")
        WriteLine(1, DateAndTime.Now)
        FileClose(1)
    End Sub

    Sub ReadFromFile(fileNumber As Integer, fileName As String)
        Dim currentRecord As String
        FileOpen(fileNumber, fileName, OpenMode.Input)
        'assign record data to ByRef arg
        Do Until EOF(fileNumber)
            Input(fileNumber, currentRecord)
            Console.WriteLine(currentRecord)
        Loop

        FileClose(fileNumber)
    End Sub

End Class
