Imports System.Data.SqlClient

Public Class FrmComentarios
    Public DP As DatosPersonales
    Public cn As SqlConnection

    'Private Sub New()

    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    'End Sub
    'Sub New(ByVal dat As DatosPersonales)

    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()
    '    DP = dat
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    'End Sub
    Sub New(ByRef dat As DatosPersonales)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        DP = dat
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub FrmComentarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        If Not IsNothing(DP.Comentarios) Then
            Me.txtComentarios.Text = DP.Comentarios
        End If
    End Sub
    'Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
    '    'Try
    '    '    Dim sql As String = ""
    '    '    If Not IsNothing(DP.Comentarios) Then
    '    '        sql = String.Format("UPDATE DatosPersonales SET ComentariosAdicionales='{0}' WHERE DatosPersonales.Id={1}", Me.txtComentarios.Text, DP.Id)
    '    '    Else
    '    '        sql = String.Format("INSERT INTO DatosPersonales (Comentarios) VALUES ('{0}') WHERE DatosPersonales.Id={1}", Me.txtComentarios.Text, DP.Id)
    '    '    End If
    '    '    cn.Open()
    '    '    Dim cmd As New SqlCommand(sql, cn)
    '    '    Dim i As Integer = cmd.ExecuteNonQuery()
    '    '    If i <> 1 Then Throw New miExcepcion("Error al cargar comentario")
    '    'Catch ex2 As miExcepcion
    '    '    Me.DialogResult = Windows.Forms.DialogResult.No
    '    'Catch ex As Exception
    '    '    MsgBox(ex.ToString)
    '    '    Me.DialogResult = Windows.Forms.DialogResult.No
    '    'Finally
    '    '    cn.Close()
    '    'End Try
    '    'Me.DialogResult = Windows.Forms.DialogResult.OK
    'End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        DP.Comentarios = Me.txtComentarios.Text
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class