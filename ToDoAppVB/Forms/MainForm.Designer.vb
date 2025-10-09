<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ButtonCompletada = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ButtonEditar = New System.Windows.Forms.Button()
        Me.TextBoxTarea = New System.Windows.Forms.TextBox()
        Me.ButtonAgregarTarea = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxPrioridad = New System.Windows.Forms.ComboBox()
        Me.ButtonExportarCSV = New System.Windows.Forms.Button()
        Me.LabelDescripcion = New System.Windows.Forms.Label()
        Me.LabelFecha = New System.Windows.Forms.Label()
        Me.LabelPrioridad = New System.Windows.Forms.Label()
        Me.CheckBoxTheme = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ButtonCompletada
        '
        Me.ButtonCompletada.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ButtonCompletada.Location = New System.Drawing.Point(119, 337)
        Me.ButtonCompletada.Name = "ButtonCompletada"
        Me.ButtonCompletada.Size = New System.Drawing.Size(85, 23)
        Me.ButtonCompletada.TabIndex = 0
        Me.ButtonCompletada.Text = "✅ Completar"
        Me.ButtonCompletada.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ButtonEliminar.Location = New System.Drawing.Point(309, 337)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 1
        Me.ButtonEliminar.Text = "🗑️ Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonEditar
        '
        Me.ButtonEditar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ButtonEditar.Location = New System.Drawing.Point(24, 337)
        Me.ButtonEditar.Name = "ButtonEditar"
        Me.ButtonEditar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEditar.TabIndex = 2
        Me.ButtonEditar.Text = "✏️ Editar"
        Me.ButtonEditar.UseVisualStyleBackColor = True
        '
        'TextBoxTarea
        '
        Me.TextBoxTarea.Location = New System.Drawing.Point(24, 58)
        Me.TextBoxTarea.Name = "TextBoxTarea"
        Me.TextBoxTarea.Size = New System.Drawing.Size(268, 20)
        Me.TextBoxTarea.TabIndex = 3
        '
        'ButtonAgregarTarea
        '
        Me.ButtonAgregarTarea.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonAgregarTarea.Location = New System.Drawing.Point(577, 52)
        Me.ButtonAgregarTarea.Name = "ButtonAgregarTarea"
        Me.ButtonAgregarTarea.Size = New System.Drawing.Size(103, 23)
        Me.ButtonAgregarTarea.TabIndex = 4
        Me.ButtonAgregarTarea.Text = "Agregar tarea"
        Me.ButtonAgregarTarea.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(24, 84)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(656, 247)
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(330, 55)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker1.TabIndex = 6
        '
        'ComboBoxPrioridad
        '
        Me.ComboBoxPrioridad.FormattingEnabled = True
        Me.ComboBoxPrioridad.Items.AddRange(New Object() {"Baja", "Media", "Alta"})
        Me.ComboBoxPrioridad.Location = New System.Drawing.Point(444, 54)
        Me.ComboBoxPrioridad.Name = "ComboBoxPrioridad"
        Me.ComboBoxPrioridad.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxPrioridad.TabIndex = 7
        '
        'ButtonExportarCSV
        '
        Me.ButtonExportarCSV.BackColor = System.Drawing.Color.Gainsboro
        Me.ButtonExportarCSV.Location = New System.Drawing.Point(577, 337)
        Me.ButtonExportarCSV.Name = "ButtonExportarCSV"
        Me.ButtonExportarCSV.Size = New System.Drawing.Size(103, 23)
        Me.ButtonExportarCSV.TabIndex = 8
        Me.ButtonExportarCSV.Text = "📤 Exportar a CSV"
        Me.ButtonExportarCSV.UseVisualStyleBackColor = True
        '
        'LabelDescripcion
        '
        Me.LabelDescripcion.AutoSize = True
        Me.LabelDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDescripcion.Location = New System.Drawing.Point(21, 35)
        Me.LabelDescripcion.Name = "LabelDescripcion"
        Me.LabelDescripcion.Size = New System.Drawing.Size(90, 16)
        Me.LabelDescripcion.TabIndex = 9
        Me.LabelDescripcion.Text = "Descripción"
        '
        'LabelFecha
        '
        Me.LabelFecha.AutoSize = True
        Me.LabelFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFecha.Location = New System.Drawing.Point(327, 35)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(50, 16)
        Me.LabelFecha.TabIndex = 10
        Me.LabelFecha.Text = "Fecha"
        '
        'LabelPrioridad
        '
        Me.LabelPrioridad.AutoSize = True
        Me.LabelPrioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPrioridad.Location = New System.Drawing.Point(441, 35)
        Me.LabelPrioridad.Name = "LabelPrioridad"
        Me.LabelPrioridad.Size = New System.Drawing.Size(71, 16)
        Me.LabelPrioridad.TabIndex = 11
        Me.LabelPrioridad.Text = "Prioridad"
        '
        'CheckBoxTheme
        '
        Me.CheckBoxTheme.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxTheme.Location = New System.Drawing.Point(611, 12)
        Me.CheckBoxTheme.Name = "CheckBoxTheme"
        Me.CheckBoxTheme.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxTheme.TabIndex = 12
        Me.CheckBoxTheme.Text = "Modo Oscuro"
        Me.CheckBoxTheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxTheme.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 376)
        Me.Controls.Add(Me.CheckBoxTheme)
        Me.Controls.Add(Me.LabelPrioridad)
        Me.Controls.Add(Me.LabelFecha)
        Me.Controls.Add(Me.LabelDescripcion)
        Me.Controls.Add(Me.ButtonExportarCSV)
        Me.Controls.Add(Me.ComboBoxPrioridad)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ButtonAgregarTarea)
        Me.Controls.Add(Me.TextBoxTarea)
        Me.Controls.Add(Me.ButtonEditar)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonCompletada)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Gestor de tareas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonCompletada As Button
    Friend WithEvents ButtonEliminar As Button
    Friend WithEvents ButtonEditar As Button
    Friend WithEvents TextBoxTarea As TextBox
    Friend WithEvents ButtonAgregarTarea As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ComboBoxPrioridad As ComboBox
    Friend WithEvents ButtonExportarCSV As Button
    Friend WithEvents LabelDescripcion As Label
    Friend WithEvents LabelFecha As Label
    Friend WithEvents LabelPrioridad As Label
    Friend WithEvents CheckBoxTheme As CheckBox
End Class
