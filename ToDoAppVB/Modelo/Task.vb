Public Enum Prioridad
    Baja = 0
    Media = 1
    Alta = 2
End Enum

Public Class Task

    Public Property Id As Integer
    Public Property Description As String
    Public Property IsCompleted As Boolean
    Public Property DueDate As DateTime
    Public Property Prioridad As Prioridad

End Class
