Imports System.Data.SQLite
Imports System.IO

Public Class DatabaseInitializer
    Private ReadOnly rutaBD As String

    Public Sub New(Optional ruta As String = "tasks.db")
        rutaBD = ruta
    End Sub

    Public Sub Inicializar()
        If File.Exists(rutaBD) Then Exit Sub

        SQLiteConnection.CreateFile(rutaBD)

        Using conexion As New SQLiteConnection($"Data Source={rutaBD};Version=3;")
            conexion.Open()

            Dim sql As String = "
                CREATE TABLE Tasks (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Description TEXT NOT NULL,
                    IsCompleted INTEGER NOT NULL,
                    DueDate TEXT,
                    Prioridad TEXT
                );"

            Using comando As New SQLiteCommand(sql, conexion)
                comando.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Base de datos creada correctamente.", "Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


End Class
