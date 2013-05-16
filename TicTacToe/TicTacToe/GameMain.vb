Module GameMain

    Sub Main()
        MainLoop()

    End Sub

    Sub MainLoop()
        Dim mainPlayer As New Player(UserType.User)
        Dim cpuPlayer As New Player(UserType.CPU)

        Dim players() As IPlay = {mainPlayer, cpuPlayer}
        Dim board As New GameBoard()
        '' TODO:
        Dim judge As New Judge(board)

        board.GameStart()
        board.Display()
        While (board.IsFinish() <> True)

            mainPlayer.Play(board)
            'If (judge.JudgeGame(mainPlayer)) Then
            '    Exit While
            'End If
            cpuPlayer.Play(board)
            'If (judge.JudgeGame(cpuPlayer)) Then
            '    Exit While
            'End If

        End While
        board.GameFinish()

    End Sub

End Module
