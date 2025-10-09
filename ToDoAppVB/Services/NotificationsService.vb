Public Class NotificationsService

    Public Shared Sub MostrarInfo(mensaje As String)
        MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Sub MostrarError(errorMsg As String)
        MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub NotificarTareasUrgentes(tareas As List(Of Task))
        Dim urgentes = tareas.Where(Function(t) t.Prioridad = Prioridad.Alta AndAlso Not t.IsCompleted)
        If urgentes.Any() Then
            MostrarInfo($"Tienes {urgentes.Count()} tareas urgentes sin completar.")
        End If
    End Sub

End Class
