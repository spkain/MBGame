Public Class Point

    Private _x As Integer
    Private _y As Integer

    Public Sub New(ByVal y As Integer, ByVal x As Integer)
        _x = x
        _y = y
    End Sub

    Public ReadOnly Property X As Integer
        Get
            Return _x
        End Get
    End Property

    Public ReadOnly Property Y As Integer
        Get
            Return _y
        End Get
    End Property

End Class
