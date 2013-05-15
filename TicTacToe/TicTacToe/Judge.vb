Public Class Judge
    Private board As GameBoard

    Public Sub New(ByRef board As GameBoard)
        Me.board = board
    End Sub

    Public Function JudgeGame(ByRef p As IPlay) As Boolean

        board.Winner = p
        Return False
    End Function

End Class
