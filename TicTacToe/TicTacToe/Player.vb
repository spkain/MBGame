Public Class Player
    Implements IPlay

    Private _name As String
    Private _hand As HandType
    Private _win As Boolean
    Private _cpu As Boolean

    Public Sub New(ByVal type As UserType)
        Select Case type
            Case UserType.User
                CreateUserData()
            Case UserType.CPU
                CreateCpuData()
        End Select
    End Sub

    Private Sub CreateCpuData()
        _name = "CPU"
        _cpu = True
        _hand = HandType.Cross
    End Sub

    Private Sub CreateUserData()
        Console.Write("input your name: ")
        _name = Console.ReadLine()

        If _name.Length = 0 Then
            Console.WriteLine("input error")
            Console.WriteLine("your name is nothing.")
            _name = "nothing"
        End If
        _hand = HandType.Circle

    End Sub

    Public ReadOnly Property IsCPU As Boolean
        Get
            Return _cpu
        End Get
    End Property

    Public ReadOnly Property IsWin As Boolean
        Get
            Return _win
        End Get
    End Property

    Public Sub Play(ByRef gameboard As GameBoard) Implements IPlay.Play
        If _cpu = True Then
            gameboard.UpdateCell(New Random().Next() * 10, _hand)
        Else
            gameboard.UpdateCell(GetSelectCellNumber(), _hand)
        End If
    End Sub


    Private Function GetSelectCellNumber() As Integer
        Return Int32.Parse(Console.ReadLine())
    End Function

    Public Sub WinnerInfo() Implements IPlay.WinnerInfo
        Console.WriteLine("winner is {0}.", _name)
    End Sub
End Class
