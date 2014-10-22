Imports System.Data.SqlClient
Public Class FrmModulos
    Dim cont As Integer
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal id As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Dim cn As SqlConnection
    Dim modu As Modulo
    Private Sub FrmModulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Call cargarlistbox()
    End Sub

    Public Sub cargarlistbox()
        Me.lstModulos.Items.Clear()
        Dim sql As String = "select modulos.id, modulos.Nombre from modulos order by modulos.id asc"
        cn.Open()
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        Do While dr.Read
            Me.lstModulos.Items.Add(dr(0) & "_" & dr(1))
        Loop
        cn.Close()
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Try
            Dim aux(2) As String
            aux = Split(Me.lstModulos.SelectedItem.ToString, "_")
            cont = CInt(aux(0))
            If cont = -1 Then
            ' Throw New miExcepcion("No se ha seleccionado nada")
            Throw New miExcepcion("No se ha seleccionado nada", 43, Me.Name.ToString)
            Else
            Dim frm As New FrmModificarModulos(cont)

            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MsgBox("Modulo insertado")

                Call cargarlistbox()
            Else
                ' Throw New miExcepcion("error al insertar el Modulo")
                Throw New miExcepcion("error al insertar el Modulo", 53, Me.Name.ToString)
            End If
            End If
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        Finally
            'reseteo el contador
            cont = 0
        End Try
    End Sub

    Private Sub cmdNuevoModulo_Click(sender As Object, e As EventArgs) Handles cmdNuevoModulo.Click
        Try
            'si no hay nada seleccionado le paso -1 para que sepa que será nuevo
            cont = -1
            Dim frm As New FrmModificarModulos(cont)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MsgBox("Modulo insertado")
                Call cargarlistbox()
            Else
                'Throw New miExcepcion("error al insertar el Modulo")
                Throw New miExcepcion("error al insertar el Modulo", 76, Me.Name.ToString)
            End If
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        Finally
            'reseteo el contador
            cont = 0
        End Try
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class