Public Class ListViewItemComparer
    Implements IComparer

    Private ReadOnly columnIndex As Integer
    Private ReadOnly sortOrder As SortOrder

    Public Sub New(column As Integer, order As SortOrder)
        columnIndex = column
        sortOrder = order
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim itemX As ListViewItem = CType(x, ListViewItem)
        Dim itemY As ListViewItem = CType(y, ListViewItem)

        Dim textX As String = itemX.SubItems(columnIndex).Text
        Dim textY As String = itemY.SubItems(columnIndex).Text

        Dim result As Integer

        ' Comparación especial para fechas
        If columnIndex = 3 Then ' Suponiendo que la columna 3 es "Fecha"
            Dim dateX, dateY As DateTime
            If DateTime.TryParse(textX, dateX) AndAlso DateTime.TryParse(textY, dateY) Then
                result = DateTime.Compare(dateX, dateY)
            Else
                result = String.Compare(textX, textY)
            End If

            ' Comparación especial para prioridad
        ElseIf columnIndex = 4 Then ' Suponiendo que la columna 4 es "Prioridad"
            result = PrioridadValor(textX).CompareTo(PrioridadValor(textY))

            ' Comparación estándar
        Else
            result = String.Compare(textX, textY)
        End If

        If sortOrder = SortOrder.Descending Then result *= -1
        Return result
    End Function

    Private Function PrioridadValor(prioridad As String) As Integer
        Select Case prioridad.ToLower()
            Case "alta" : Return 3
            Case "media" : Return 2
            Case "baja" : Return 1
            Case Else : Return 0
        End Select
    End Function


End Class
