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
            Dim rnd As New Random()
            Dim rndvalue As Integer

            rndvalue = rnd.Next(1, 10)

            While (gameboard.IsCellEmpty(rndvalue) = False)
                rndvalue = rnd.Next(1, 10)
            End While

            gameboard.UpdateCell(rndvalue, _hand)
        Else
            gameboard.SelectShowDisplay()
            gameboard.UpdateCell(GetSelectCellNumber(gameboard), _hand)
        End If
    End Sub

    Private Function GetSelectCellNumber(ByRef gameboard As GameBoard) As Integer
        Dim num As Integer
        Dim str As String

        While True
            Console.Write("input put area number. :")
            str = Console.ReadLine()

            If IsNumeric(str) = False Then
                Console.WriteLine("error, retry.")
                Continue While
            End If

            num = Int32.Parse(str)

            If (num < 1 Or num > 9) Then
                Console.WriteLine("error, retry.")
                Continue While
            End If

            If gameboard.IsCellEmpty(num) = False Then
                Console.WriteLine("not empty, retry input area number.")
                Continue While
            Else
                Exit While
            End If

        End While

        Return num
    End Function

    Public Sub WinnerInfo() Implements IPlay.WinnerInfo
        Console.WriteLine("winner is {0}.", _name)
    End Sub

    Public Function GetHand() As HandType Implements IPlay.GetHand
        Return _hand
    End Function
End Class
