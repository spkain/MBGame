Public Interface IPlay

    Sub Play(ByRef gameboard As GameBoard)
    Sub WinnerInfo()
    Function GetHand() As HandType
End Interface
