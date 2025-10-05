Imports System.Data.SQLite
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class Form1

    Private repo As New TaskRepository()
    Private sortColumn As Integer = -1
    Private sortState As Dictionary(Of Integer, SortOrder) = New Dictionary(Of Integer, SortOrder)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxPrioridad.DataSource = [Enum].GetValues(GetType(Prioridad))
        ComboBoxPrioridad.DisplayMember = "ToString"
        CrearBaseDeDatos()
        repo = New TaskRepository() ' Ahora que la BD existe, se puede usar
        CargarTareas()

        'ListView1.OwnerDraw = True DESCOMENTAR PARA PINTAR LA LISTVIEW SEGUN PRIORIDAD #TODO
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True

        ListView1.Columns.Clear()
        ListView1.Columns.Add("ID", 50)
        ListView1.Columns.Add("Descripción", 300)
        ListView1.Columns.Add("Completada", 80)
        ListView1.Columns.Add("Fecha", 100)
        ListView1.Columns.Add("Prioridad", 100)

    End Sub


#Region "Metodos de ordenacion y pintado"

    'ORDENAR COLUMNA AL HACER CLICK
    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        If e.Column <> sortColumn Then
            sortColumn = e.Column
            sortState(e.Column) = SortOrder.Ascending
        Else
            If sortState.ContainsKey(e.Column) Then
                sortState(e.Column) = If(sortState(e.Column) = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)
            Else
                sortState(e.Column) = SortOrder.Ascending
            End If
        End If
        ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column, sortState(e.Column))
        ListView1.Sort()
    End Sub

    'METODO PARA PINTAR LA LISTVIEW SEGUN LA PRIORIDAD #TODO

    'Private Sub ListView1_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles ListView1.DrawSubItem
    '    Dim priorityText As String = e.SubItem.Text
    '    Dim itemSelected As Boolean = (e.ItemState And ListViewItemStates.Selected) <> 0

    '    ' Fondo azul si está seleccionado
    '    If itemSelected Then
    '        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds)
    '        e.Graphics.DrawString(e.SubItem.Text, ListView1.Font, SystemBrushes.HighlightText, e.Bounds)
    '    Else
    '        ' Dibuja fondo rosa claro si la prioridad es Alta
    '        If e.ColumnIndex = 4 AndAlso priorityText = "Alta" Then
    '            e.Graphics.FillRectangle(Brushes.LightPink, e.Bounds)
    '            e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, Brushes.Red, e.Bounds)
    '        Else
    '            e.DrawBackground()
    '            e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, Brushes.Black, e.Bounds)
    '        End If
    '    End If
    'End Sub

    Private Sub ActualizarEncabezados(columnaClicada As Integer)
        For i As Integer = 0 To ListView1.Columns.Count - 1
            Dim textoBase As String = ObtenerNombreOriginal(i) ' ← Este método lo defines tú
            If sortState.ContainsKey(i) Then
                Dim flecha As String = If(sortState(i) = SortOrder.Ascending, " ↑", " ↓")
                ListView1.Columns(i).Text = textoBase & flecha
            Else
                ListView1.Columns(i).Text = textoBase
            End If
        Next
    End Sub

    Private Function ObtenerNombreOriginal(index As Integer) As String
        Select Case index
            Case 0 : Return "ID"
            Case 1 : Return "Descripción"
            Case 2 : Return "Completada"
            Case 3 : Return "Fecha"
            Case 4 : Return "Prioridad"
            Case Else : Return "Columna"
        End Select
    End Function

#End Region


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

        Dim exporter As New CsvExporter()
        exporter.ExportarCSV(tareas)

    End Sub

#End Region



End Class

