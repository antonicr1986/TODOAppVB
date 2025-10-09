Public Class ThemeManager
    Public Shared IsDarkMode As Boolean = False

    Public Shared Sub ApplyTheme(form As Form)
        If IsDarkMode Then
            form.BackColor = Color.FromArgb(45, 45, 45)
            form.ForeColor = Color.White
        Else
            form.BackColor = SystemColors.Control
            form.ForeColor = SystemColors.ControlText
        End If

        ' Aplica también a controles internos
        For Each ctrl As Control In form.Controls
            ApplyThemeToControl(ctrl)
        Next
    End Sub

    Private Shared Sub ApplyThemeToControl(ctrl As Control)

        If TypeOf ctrl Is Button Then
            If IsDarkMode Then
                ctrl.BackColor = Color.FromArgb(70, 70, 70)
                ctrl.ForeColor = Color.White
            Else
                ctrl.BackColor = SystemColors.Control
                ctrl.ForeColor = SystemColors.ControlText
            End If
            Return
        End If

        If IsDarkMode Then
            ctrl.BackColor = Color.FromArgb(45, 45, 45)
            ctrl.ForeColor = Color.White
        Else
            ctrl.BackColor = SystemColors.Control
            ctrl.ForeColor = Color.Black
        End If

        ' Si el control tiene hijos (como Panel, GroupBox)
        For Each child As Control In ctrl.Controls
            ApplyThemeToControl(child)
        Next
    End Sub

End Class
