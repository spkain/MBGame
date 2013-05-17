Module GameMain

    Sub Main()
        MainLoop()

    End Sub

    Sub MainLoop()
        Console.WriteLine("/-/ ■Tic Tac Toe Game! /-/")
        Console.WriteLine()

        Dim mainPlayer As New Player(UserType.User)
        Dim cpuPlayer As New Player(UserType.CPU)

        Dim board As New GameBoard()

        Dim judge As New Judge(board)

        board.GameStart()
        While (board.IsFinish() <> True)

            mainPlayer.Play(board)
            board.Display()

            If (judge.JudgeGame(mainPlayer)) Then
                Exit While
            End If

            cpuPlayer.Play(board)
            board.Display()

            If (judge.JudgeGame(cpuPlayer)) Then
                Exit While
            End If

        End While
        board.GameFinish()

    End Sub

End Module
