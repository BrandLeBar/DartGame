Option Strict On
Option Explicit On
Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class DartGameForm
    Public roundCount As Integer = 0
    Public dartCount As Integer
    Public reviewMode As Boolean

    Sub SetDefaults()
        Dim path As String = "Round.log"
        FileOpen(1, path, OpenMode.Output)
        Write(1, $"Round 1 @ {DateAndTime.Now}")
        FileClose(1)
        ReviewRoundComboBox.Items.Add($"Round: {1}")
        RoundNumberLabel.Text = $"{1}"
        roundCount += 2
        reviewMode = False
    End Sub

    Private Sub DartGameForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetDefaults()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        DartBoardPictureBox.Invalidate()
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

    Function ThrowDart(Optional oldValues As Boolean = False, Optional x% = 0, Optional y% = 0) As (Integer, Integer)
        Dim randomX As Integer
        Dim randomY As Integer

        If oldValues = False Then
            randomX = RandomNumberGeneratorZeroTo(DartBoardPictureBox.Width)
            randomY = RandomNumberGeneratorZeroTo(DartBoardPictureBox.Height)
        ElseIf oldValues = True Then
            randomX = x
            randomY = y
        End If

        DrawDart(randomX, randomY)
        Return (randomX, randomY)
    End Function

    Function RandomNumberGeneratorZeroTo(max%) As Integer
        Randomize()
        Return CInt(System.Math.Floor(CDbl(Rnd() * max))) + 1
    End Function

    Private Sub DrawPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DartBoardPictureBox.MouseMove
        CoordsStatusLabel.Text = ($"X = {e.X} & Y = {e.Y}")
    End Sub

    Private Sub ThrowButton_Click(sender As Object, e As EventArgs) Handles ThrowButton.Click
        Dim results As (Integer, Integer)
        Dim response As MsgBoxResult


        If reviewMode = False Then

            If RoundChecker() = True Then
                results = ThrowDart()
                dartCount += 1
                DartNumberLabel.Text = $"{dartCount}"
                LogDart(results.Item1, results.Item2, dartCount)
            ElseIf RoundChecker() = False Then
                MsgBox("please start new round")
            End If

        Else
            response = MsgBox($"Review mode enabled would you like to continue rounds?", MsgBoxStyle.YesNo, "Current Mode: Review")
            If response = MsgBoxResult.Yes Then
                DartBoardPictureBox.Invalidate()
                reviewMode = False
            Else
                reviewMode = True
            End If
        End If

    End Sub

    Function RoundChecker(Optional reset As Boolean = False) As Boolean

        If reset = True Then
            ReviewRoundComboBox.Items.Add($"Round: {roundCount}")
            RoundNumberLabel.Text = $"{roundCount}"
            LogRound()
            roundCount += 1
            dartCount = 0
            DartNumberLabel.Text = $"{dartCount}"
            Return True
        End If

        If dartCount = 3 Then
            Return False
        ElseIf dartCount < 3 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub ReviewButton_Click(sender As Object, e As EventArgs) Handles ReviewButton.Click
        reviewMode = True
        ReadFromFile(1, "Round.log")

        Console.WriteLine()
        For Each line In CurrentReviewRound()
            Console.WriteLine(line)
        Next
        ReviewDarts()
    End Sub

    Sub LogDart(x%, y%, dartNumber%)
        Dim path As String = "Round.log"
        FileOpen(1, path, OpenMode.Append)
        Write(1, $"Dart {dartNumber} = ({x},{y})")
        FileClose(1)
    End Sub

    Sub LogRound()
        Dim path As String = "Round.log"
        FileOpen(1, path, OpenMode.Append)
        Write(1, "?")
        WriteLine(1, $"Round {roundCount} @ {DateAndTime.Now}")
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

    Function ReadCoordsFromFile(fileNumber As Integer, fileName As String) As (Integer, Integer, Integer, Integer, Integer, Integer)
        Dim xyCoords As (Integer, Integer, Integer, Integer, Integer, Integer)
        Dim listOfData As New List(Of String)
        Dim currentRecord As String
        Dim sort As Integer
        FileOpen(fileNumber, fileName, OpenMode.Input)

        Do Until EOF(fileNumber)
            Input(fileNumber, currentRecord)
            listOfData.Add(currentRecord)
        Loop

        FileClose(fileNumber)

        For Each line In listOfData
            If line.StartsWith("Dart") Then
                For Each seperation In line.Split(CChar("("))
                    For Each thing In seperation.Split(CChar(","))
                        For Each xy In thing.Split(CChar(")"))

                            Select Case sort
                                Case 0
                                    If IsNumeric(xy) Then
                                        sort += 1
                                        xyCoords.Item1 = CInt(xy)
                                    End If
                                Case 1
                                    If IsNumeric(xy) Then
                                        sort += 1
                                        xyCoords.Item2 = CInt(xy)
                                    End If
                                Case 2
                                    If IsNumeric(xy) Then
                                        sort += 1
                                        xyCoords.Item3 = CInt(xy)
                                    End If
                                Case 3
                                    If IsNumeric(xy) Then
                                        sort += 1
                                        xyCoords.Item4 = CInt(xy)
                                    End If
                                Case 4
                                    If IsNumeric(xy) Then
                                        sort += 1
                                        xyCoords.Item5 = CInt(xy)
                                    End If
                                Case 5
                                    If IsNumeric(xy) Then
                                        sort = 0
                                        xyCoords.Item6 = CInt(xy)
                                    End If
                            End Select
                        Next
                    Next
                Next
            End If
        Next
        Return xyCoords
    End Function

    Private Sub RoundButton_Click(sender As Object, e As EventArgs) Handles RoundButton.Click
        RoundChecker(True)
        DartBoardPictureBox.Invalidate()
        ReviewRoundComboBox.Text = ""
    End Sub

    Sub ReviewDarts()
        Dim xy As (Integer, Integer, Integer, Integer, Integer, Integer)
        Dim sort As Integer
        For Each line In CurrentReviewRound()
            Select Case sort
                Case 0
                    sort += 1
                    xy.Item1 = ExtractDartCoords(line).Item1
                    xy.Item2 = ExtractDartCoords(line).Item2
                Case 1
                    sort += 1
                    xy.Item3 = ExtractDartCoords(line).Item1
                    xy.Item4 = ExtractDartCoords(line).Item2
                Case 2
                    sort = 0
                    xy.Item5 = ExtractDartCoords(line).Item1
                    xy.Item6 = ExtractDartCoords(line).Item2

            End Select
        Next
        If xy.Item1 <> Nothing And xy.Item2 <> Nothing And xy.Item3 <> Nothing And xy.Item4 <> Nothing And xy.Item5 <> Nothing And xy.Item6 <> Nothing Then
            ThrowDart(True, xy.Item1, xy.Item2)
            ThrowDart(True, xy.Item3, xy.Item4)
            ThrowDart(True, xy.Item5, xy.Item6)
        Else
            MsgBox("Please complete round before reviewing")
        End If
    End Sub

    Function CurrentReviewRound() As List(Of String)
        Dim roundList As New List(Of String)
        Dim listOfData As New List(Of String)
        Dim checker As Boolean = False
        Dim currentRecord As String
        Dim tempName As Integer
        Dim selectedRound As Integer = ReviewRoundComboBox.SelectedIndex

        FileOpen(1, "Round.log", OpenMode.Input)
        Do Until EOF(1)
            Input(1, currentRecord)
            listOfData.Add(currentRecord)
        Loop

        FileClose(1)

        For Each line In listOfData

            If line.StartsWith("Round") Then

                For Each round In line.Split(CChar("?"))

                    For Each at In round.Split(CChar("@"))

                        For Each blank In at.Split(CChar(" "))
                            If IsNumeric(blank) Then
                                'roundList.Add(blank)
                                tempName = (CInt(blank) - 1)
                            End If
                        Next
                    Next
                Next
            End If
            If line.Contains($"Round {tempName + 1}") And tempName = selectedRound Then
                checker = True
            End If
            If line.Contains($"?") Then
                checker = False
            End If
            If line.StartsWith("Dart 1") Or line.StartsWith("Dart 2") Or line.StartsWith("Dart 3") Then
                If checker = True Then
                    roundList.Add(ExtractDartCoords(line).ToString)

                End If
            End If
        Next

        Return roundList
    End Function

    Function ExtractDartCoords(line As String) As (Integer, Integer)
        Dim sort As Integer
        Dim xyCoords As (Integer, Integer)
        For Each seperation In line.Split(CChar("("))
            For Each thing In seperation.Split(CChar(","))
                For Each xy In thing.Split(CChar(")"))

                    Select Case sort
                        Case 0
                            If IsNumeric(xy) Then
                                sort += 1
                                xyCoords.Item1 = CInt(xy)
                            End If
                        Case 1
                            If IsNumeric(xy) Then
                                sort = 0
                                xyCoords.Item2 = CInt(xy)
                            End If
                    End Select
                Next
            Next
        Next
        Return xyCoords
    End Function

    Private Sub DartGameForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim path As String = "Round.log"
        FileOpen(1, path, OpenMode.Output)
        Write(1, path, "Cleared")
        FileClose(1)
    End Sub

    Private Sub ReviewRoundComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReviewRoundComboBox.SelectedIndexChanged
        If reviewMode = True Then
            DartBoardPictureBox.Invalidate()
        End If
    End Sub

End Class

Public Class Card

    Private _suit As String
    Public Property suit() As String
        Get
            Return _suit
        End Get
        Set(ByVal value As String)
            _suit = value
        End Set
    End Property

End Class