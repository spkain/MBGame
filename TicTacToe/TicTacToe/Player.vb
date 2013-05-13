Public Class Player
    Implements IPlay

    Private _name As String
    Private _win As Boolean

    Public Sub New(ByVal type As UserType)

    End Sub

    Public ReadOnly Property IsWin As Boolean
        Get
            Return _win
        End Get
    End Property






    Public Sub Play(ByRef gameboard As GameBoard) Implements IPlay.Play

    End Sub
End Class
