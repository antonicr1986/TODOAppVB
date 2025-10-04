Imports System.Data.SQLite
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class Form1

    Private repo As New TaskRepository()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxPrioridad.DataSource = [Enum].GetValues(GetType(Prioridad))
        ComboBoxPrioridad.DisplayMember = "ToString"
        CrearBaseDeDatos()
        repo = New TaskRepository() ' Ahora que la BD existe, se puede usar
        CargarTareas()

        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True

        ListView1.Columns.Clear()
        ListView1.Columns.Add("ID", 50)
        ListView1.Columns.Add("Descripción", 200)
        ListView1.Columns.Add("Completada", 80)
        ListView1.Columns.Add("Fecha", 100)
        ListView1.Columns.Add("Prioridad", 100)

    End Sub

    Private Sub CrearBaseDeDatos()
        Dim rutaBD As String = "tasks.db"

        ' Si el archivo no existe, lo crea
        If Not File.Exists(rutaBD) Then
            SQLiteConnection.CreateFile(rutaBD)

            Using conexion As New SQLiteConnection("Data Source=tasks.db;Version=3;")
                conexion.Open()
                Dim sql As String = "CREATE TABLE Tasks (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Description TEXT NOT NULL,
                                    IsCompleted INTEGER NOT NULL,
                                    DueDate TEXT,
                                    Prioridad TEXT
                                 );"
                Dim comando As New SQLiteCommand(sql, conexion)
                comando.ExecuteNonQuery()
            End Using

            MessageBox.Show("Base de datos creada correctamente.")
        End If
    End Sub

    Private Sub CargarTareas()
        ListView1.Items.Clear()
        Dim tareas As List(Of Task) = repo.GetAllTasks()

        For Each tarea In tareas
            Dim item As New ListViewItem(tarea.Id.ToString())
            item.SubItems.Add(tarea.Description)
            item.SubItems.Add(If(tarea.IsCompleted, "Sí", "No"))
            item.SubItems.Add(tarea.DueDate.ToString("dd/MM/yyyy")) ' Mostrar la fecha en formato europeo
            item.SubItems.Add(tarea.Prioridad.ToString())
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Function ObtenerIdSeleccionado() As Integer
        If ListView1.SelectedItems.Count > 0 Then
            Return Convert.ToInt32(ListView1.SelectedItems(0).Text)
        End If
        Return -1 ' Ninguna tarea seleccionada
    End Function




#Region "Métodos de click"
    Private Sub ButtonAgregarTarea_Click(sender As Object, e As EventArgs) Handles ButtonAgregarTarea.Click
        Dim descripcion As String = TextBoxTarea.Text.Trim()
        Dim fecha As DateTime = DateTimePicker1.Value

        If descripcion <> "" Then
            Dim prioridadSeleccionada As Prioridad = CType(ComboBoxPrioridad.SelectedItem, Prioridad)
            repo.AddTask(descripcion, fecha, prioridadSeleccionada.ToString())
            TextBoxTarea.Clear()
            CargarTareas()
        Else
            MessageBox.Show("Escribe una descripción para la tarea.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ButtonCompletada_Click(sender As Object, e As EventArgs) Handles ButtonCompletada.Click
        Dim id As Integer = ObtenerIdSeleccionado()

        If id <> -1 Then
            ' Buscar la tarea por ID
            Dim tareas As List(Of Task) = repo.GetAllTasks()
            Dim tarea = tareas.FirstOrDefault(Function(t) t.Id = id)

            If tarea IsNot Nothing Then
                If tarea.IsCompleted Then
                    MessageBox.Show("La tarea ya está marcada como completada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    tarea.IsCompleted = True
                    repo.UpdateTask(tarea)
                    CargarTareas()
                End If
            Else
                MessageBox.Show("No se encontró la tarea seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecciona una tarea para marcar como completada.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonEliminar_Click(sender As Object, e As EventArgs) Handles ButtonEliminar.Click
        Dim id As Integer = ObtenerIdSeleccionado()

        If id <> -1 Then
            Dim confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar esta tarea?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirmacion = DialogResult.Yes Then
                repo.DeleteTask(id)
                CargarTareas()
            End If
        Else
            MessageBox.Show("Selecciona una tarea en la lista para eliminar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ButtonEditar_Click(sender As Object, e As EventArgs) Handles ButtonEditar.Click
        Dim id As Integer = ObtenerIdSeleccionado()
        Dim nuevaDescripcion As String = TextBoxTarea.Text.Trim()

        If id = -1 Then
            MessageBox.Show("Selecciona una tarea para editar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If nuevaDescripcion = "" Then
            MessageBox.Show("Escribe una nueva descripción para la tarea.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Buscar la tarea original
        Dim tareas As List(Of Task) = repo.GetAllTasks()
        Dim tarea = tareas.FirstOrDefault(Function(t) t.Id = id)

        If tarea IsNot Nothing Then
            tarea.Description = nuevaDescripcion
            repo.UpdateTask(tarea)
            TextBoxTarea.Clear()
            CargarTareas()
        Else
            MessageBox.Show("No se encontró la tarea seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If



    End Sub

    Private Sub ButtonExportarCSV_Click(sender As Object, e As EventArgs) Handles ButtonExportarCSV.Click
        Dim tareas As List(Of Task) = repo.GetAllTasks()
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

#End Region

End Class

