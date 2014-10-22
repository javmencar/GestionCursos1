Public Class miExcepcion
    Inherits System.Exception
    Dim texto As String
    Sub New()

    End Sub
    Sub New(ByVal x As String)
        Me.texto = x
    End Sub
    Sub New(ByVal x As String, i As Integer, ByVal y As String)
        Me.texto = String.Format(" {0} " & vbCrLf & " cerca de la linea  {1} " & vbCrLf & " en el formulario {2} ", x, i, y)
    End Sub
    Public Overrides Function ToString() As String
        Return Me.texto
    End Function
End Class
