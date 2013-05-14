Public Class GameBoard

    Private _field(,) As Integer = { _
         {0, 0, 0}, _
         {0, 0, 0}, _
         {0, 0, 0} _
            }
    Private dic As Dictionary(Of Integer, Point)

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

    Public Function IsFinish() As Boolean

    End Function




End Class
