Public Class FrmProfesores

    Private Sub FrmProfesores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ListView1.View = View.Details
        ''prueba de insercion de columnas 
        'Me.ListView1.Columns.Add("DNI", 100, HorizontalAlignment.Center)
        'Me.ListView1.Columns.Add("Nombre", 350, HorizontalAlignment.Center)
        '' y prueba de insercion de datos
        'Me.ListView1.Items.Add("29130381F")
        'Me.ListView1.Items(0).SubItems.Add("Javier Mendiz Carpi")

    End Sub
End Class