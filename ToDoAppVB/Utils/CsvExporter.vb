Imports System.IO

Public Class CsvExporter
    Public Sub ExportarCSV(tareas As List(Of Task))
        Dim rutaArchivo As String = "tareas_exportadas.csv"

        Try
            Using writer As New StreamWriter(rutaArchivo, False, System.Text.Encoding.UTF8)
                ' Escribir encabezados
                writer.WriteLine("ID,Descripción,Completada,Fecha,Vencimiento,Prioridad")

                ' Escribir cada tarea
                For Each tarea In tareas
                    Dim completadaTexto As String = If(tarea.IsCompleted, "Sí", "No")
                    Dim linea As String = String.Format("{0},""{1}"",{2},{3},{4},{5}",
                                                    tarea.Id,
                                                    tarea.Description.Replace("""", """"""),
                                                    completadaTexto,
                                                    tarea.DueDate.ToString("dd/MM/yyyy"),
                                                    tarea.DueDate.ToString("yyyy-MM-dd"),
                                                    tarea.Prioridad.ToString())
                    writer.WriteLine(linea)
                Next
            End Using

            MessageBox.Show("Tareas exportadas correctamente a: " & rutaArchivo, "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al exportar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
