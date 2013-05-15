Public Class GameBoard

    Private _winner As IPlay

    Private _field(,) As Integer = { _
         {0, 0, 0}, _
         {0, 0, 0}, _
         {0, 0, 0} _
            }
    Private dic As Dictionary(Of Integer, Point)

    Public WriteOnly Property Winner As IPlay
        Set(value As IPlay)
            Me._winner = value
        End Set
    End Property

    Public Sub New()
        dic.Add(1, New Point(0, 0))
        dic.Add(2, New Point(0, 1))
        dic.Add(3, New Point(0, 2))
        dic.Add(4, New Point(1, 0))
        dic.Add(5, New Point(1, 1))
        dic.Add(6, New Point(1, 2))
        dic.Add(7, New Point(2, 0))
        dic.Add(8, New Point(2, 1))
        dic.Add(9, New Point(2, 2))
    End Sub


    Private Function GetCell(ByVal index As Integer) As Point
        If (dic.ContainsKey(index) = False) Then
            Return Nothing
        End If

        Return dic(index)

    End Function

    Public Function IsCellEmpty(ByVal i As Integer) As Boolean
        Dim pos As Point
        pos = GetCell(i)

        If (_field(pos.Y, pos.X) <> 0) Then
            Return False
        End If
        Return True

    End Function


    Public Sub UpdateCell(ByVal i As Integer, ByVal val As Integer)
        Dim pos As Point
        pos = GetCell(i)
        _field(pos.Y, pos.X) = val
    End Sub

    Public Function IsBoardEmpty()
        For y As Integer = 0 To 3
            For x As Integer = 0 To 3
                If _field(y, x) = 0 Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Public Function IsWin(ByRef h As HandType) As Boolean

        '
        For x As Integer = 0 To 3
            If (_field(0, x) = h And _
                _field(1, x) = h And _
                _field(2, x) = h) Then

                Return True
            End If
        Next

        '
        For y As Integer = 0 To 3
            If (_field(y, 0) = h And _
                _field(y, 1) = h And _
                _field(y, 2) = h) Then

                Return True
            End If
        Next

        '
        If (_field(0, 0) = h And _
            _field(1, 1) = h And _
            _field(2, 2) = h) Then

            Return True
        End If
        '

        If (_field(0, 2) = h And _
            _field(1, 1) = h And _
            _field(2, 0) = h And) Then _

            Return True
        End If

        '
        Return False

    End Function

    Public Sub GameStart()
        Console.WriteLine("/-/ game start! /-/")
    End Sub

    Public Sub GameFinish()
        Console.WriteLine("/-/ game was finished. /-/")
        If (_winner IsNot Nothing) Then
            _winner.WinnerInfo()
        Else
            Console.WriteLine("/-/ the game is draw. /-/")
        End If
    End Sub

    Public Function IsFinish() As Boolean
        ' TODO:
        Return False
    End Function




End Class
