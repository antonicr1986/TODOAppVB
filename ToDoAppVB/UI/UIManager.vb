Public Class UIManager
    'CLASE PARA GESTIONAR MOSTRAR Y OCULTAR CONTROLES DE FORMA CENTRALIZADA

    Public Shared Sub Ocultar(control As Control)
        control.Visible = False
    End Sub

    Public Shared Sub Mostrar(control As Control)
        control.Visible = True
    End Sub

End Class

