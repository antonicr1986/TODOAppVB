Imports System.Data.SQLite

Public Class TaskRepository
    Private connectionString As String = "Data Source=tasks.db;Version=3;"

    Public Function GetAllTasks() As List(Of Task)
        Dim tasks As New List(Of Task)

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT * FROM Tasks"
            Dim command As New SQLiteCommand(query, connection)
            Dim reader As SQLiteDataReader = command.ExecuteReader()

            While reader.Read()
                Dim prioridadTexto As String = reader("Prioridad").ToString()
                Dim prioridadEnum As Prioridad

                If [Enum].TryParse(prioridadTexto, True, prioridadEnum) Then
                    ' OK
                Else
                    prioridadEnum = Prioridad.Media ' Valor por defecto si falla
                End If

                Dim task As New Task With {
                    .Id = Convert.ToInt32(reader("Id")),
                    .Description = reader("Description").ToString(),
                    .IsCompleted = Convert.ToBoolean(reader("IsCompleted")),
                    .DueDate = DateTime.Parse(reader("DueDate").ToString()),
                    .Prioridad = prioridadEnum
                }
                tasks.Add(task)
            End While
        End Using

        Return tasks
    End Function

    Public Sub AddTask(description As String, dueDate As DateTime, priority As String)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim query As String = "INSERT INTO Tasks (Description, IsCompleted, DueDate, Prioridad) VALUES (@desc, 0, @date, @prioridad)"
            Dim command As New SQLiteCommand(query, connection)
            command.Parameters.AddWithValue("@desc", description)
            command.Parameters.AddWithValue("@date", dueDate.ToString("yyyy-MM-dd"))
            command.Parameters.AddWithValue("@prioridad", priority.ToString())
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub UpdateTask(task As Task)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim query As String = "UPDATE Tasks SET Description = @desc, IsCompleted = @done, DueDate = @date, Prioridad = @prioridad WHERE Id = @id"
            Dim command As New SQLiteCommand(query, connection)
            command.Parameters.AddWithValue("@desc", task.Description)
            command.Parameters.AddWithValue("@done", If(task.IsCompleted, 1, 0))
            command.Parameters.AddWithValue("@prioridad", task.Prioridad.ToString())
            command.Parameters.AddWithValue("@date", task.DueDate.ToString("yyyy-MM-dd"))
            command.Parameters.AddWithValue("@id", task.Id)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub DeleteTask(id As Integer)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim query As String = "DELETE FROM Tasks WHERE Id = @id"
            Dim command As New SQLiteCommand(query, connection)
            command.Parameters.AddWithValue("@id", id)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Class