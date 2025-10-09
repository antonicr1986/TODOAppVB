Public Class TaskService
    'FALTA DARLE USO A ESTA CLASE, PERO LLEVARA UN TIEMPO 2 HORITAS O ASI

    Private repository As TaskRepositoryCRUD

    Public Sub New()
        repository = New TaskRepositoryCRUD()
    End Sub
    Public Function ObtenerTodasLasTareas() As List(Of Task)
        Return repository.GetAllTasks()
    End Function

    Public Sub AgregarTarea(description As String, dueDate As DateTime, priority As String)
        If String.IsNullOrWhiteSpace(description) Then
            NotificationsService.MostrarError("La descripción no puede estar vacía.")
            Return
        End If
        If dueDate < DateTime.Now.Date Then
            NotificationsService.MostrarError("La fecha de vencimiento no puede ser en el pasado.")
            Return
        End If
        repository.AddTask(description, dueDate, priority)
        NotificationsService.MostrarInfo("Tarea agregada correctamente.")
    End Sub

    Public Sub ActualizarTarea(task As Task)
        If task Is Nothing Then
            NotificationsService.MostrarError("La tarea no puede ser nula.")
            Return
        End If
        If String.IsNullOrWhiteSpace(task.Description) Then
            NotificationsService.MostrarError("La descripción no puede estar vacía.")
            Return
        End If
        If task.DueDate < DateTime.Now.Date Then
            NotificationsService.MostrarError("La fecha de vencimiento no puede ser en el pasado.")
            Return
        End If
        repository.UpdateTask(task)
        NotificationsService.MostrarInfo("Tarea actualizada correctamente.")
    End Sub

End Class
