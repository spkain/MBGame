Module GameMain

    Sub Main()


    End Sub

    Sub MainLoop()
        Dim mainPlayer As New Player(UserType.User)
        Dim cpuPlayer As New Player(UserType.CPU)

        '' TODO:
        Dim judge As New Judge()
        Dim board As New GameBoard()

        Dim players() As IPlay = {mainPlayer, cpuPlayer}









    End Sub

End Module
