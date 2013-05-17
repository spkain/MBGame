Public Class Judge
    Private board As GameBoard

    Public Sub New(ByRef board As GameBoard)
        Me.board = board
    End Sub

    Public Function JudgeGame(ByRef p As IPlay) As Boolean

        If board.IsBoardEmpty() Then
            Return True
        End If

        If board.IsWin(p.GetHand()) Then
            board.Winner = p
            Return True
        End If

        Return False
    End Function

End Class
