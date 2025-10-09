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

End Class

