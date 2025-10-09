Public Class ListViewRenderer

    Public Shared Sub ConfigurarPropiedadesListView(lv As ListView)
        With lv
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Columns.Clear()
            .Columns.Add("ID", 50)
            .Columns.Add("Descripción", 300)
            .Columns.Add("Completada", 80)
            .Columns.Add("Fecha", 100)
            .Columns.Add("Prioridad", 122)
        End With
    End Sub

    Public Shared Sub ActualizarEncabezadosConFlechas(lv As ListView, sortColumn As Integer, sortOrder As SortOrder)
        For i = 0 To lv.Columns.Count - 1
            Dim textoOriginal = lv.Columns(i).Text.TrimEnd(" ▲", " ▼")

            ' Elimina cualquier flecha previa
            textoOriginal = textoOriginal.Replace(" ▲", "").Replace(" ▼", "")

            ' Agrega flecha solo en la columna ordenada
            If i = sortColumn Then
                Dim flecha = If(sortOrder = SortOrder.Ascending, " ▲", " ▼")
                lv.Columns(i).Text = textoOriginal & flecha
            Else
                lv.Columns(i).Text = textoOriginal
            End If
        Next
    End Sub

End Class

