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
        Call llamarFicha()
    End Sub
    Private Sub lstModulos_DoubleClick(sender As Object, e As EventArgs) Handles lstModulos.DoubleClick
        Call llamarFicha()
    End Sub
    Private Sub llamarFicha()
        Try
            If Me.lstModulos.SelectedIndex = -1 Then Throw New miExcepcion("Debe seleccionar un Modulo")
            Dim aux(2) As String
            aux = Split(Me.lstModulos.SelectedItem.ToString, "_")
            cont = CInt(aux(0))
            Dim mo As Modulo = rellenarModulo(cont)
            If Not IsNothing(mo) Then
                Dim frm As New FrmModificarModulos(False, mo)

                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    MsgBox("Modulo insertado")

                    Call cargarlistbox()
                End If
            Else
                ' Throw New miExcepcion("error al insertar el Modulo")
                Throw New miExcepcion("error al insertar el Modulo", 53, Me.Name.ToString)
            End If

        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'reseteo el contador
            cont = 0
        End Try
    End Sub

    Private Function rellenarModulo(ByVal id As String) As Modulo
        Dim m As New Modulo
        Try
            Dim cn As New SqlConnection(ConeStr)
            cn.Open()
            Dim sql As String = String.Format("SELECT Modulos.Id, Modulos.Nombre, Modulos.Horas, Modulos.Contenidos FROM Modulos WHERE Modulos.Id={0}", id)
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                m.Id = dr(0)
                m.Nombre = dr(1)
                m.horas = dr(2)
                m.Contenidos = dr(3)
            Else
                Throw New miExcepcion("Error al cargar el modulo")
            End If
        Catch ex2 As miExcepcion
            m = Nothing
            MsgBox(ex2.ToString)
        Catch ex As Exception
            m = Nothing
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
        Return m
    End Function
    Private Sub cmdNuevoModulo_Click(sender As Object, e As EventArgs) Handles cmdNuevoModulo.Click
        Try
            'si no hay nada seleccionado le paso -1 para que sepa que será nuevo
            cont = -1
            Dim frm As New FrmModificarModulos(True)
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

    Private Sub cmdBorrarModulo_Click(sender As Object, e As EventArgs) Handles cmdBorrarModulo.Click
        Try
            cont = Me.lstModulos.SelectedIndex
            If cont = -1 Then Throw New miExcepcion("No se ha seleccionado ningun modulo", 32, Me.Name.ToString)
            Dim datosModulo() As String = Split(Me.lstModulos.SelectedItem.ToString, "_") ' en el (0) llevo el id y en el (1) el nombre
            Dim respuesta1 As MsgBoxResult
            respuesta1 = MsgBox("Ha seleccionado para borrar el modulo: '" & datosModulo(1) & "' " &
                vbCrLf & "¿Está seguro de querer borrar el Modulo con todos sus datos?", MsgBoxStyle.YesNo)
            If respuesta1 = MsgBoxResult.No Then
                Me.DialogResult = Windows.Forms.DialogResult.None
            Else
                Dim respuesta2 As MsgBoxResult
                respuesta2 = MsgBox("¿Está totalmente seguro de querer borrarlo? Los datos no podrán recuperarse", MsgBoxStyle.YesNo)
                If respuesta2 = MsgBoxResult.No Then
                    Me.DialogResult = Windows.Forms.DialogResult.None
                Else

                    Call borrarModulo(CInt(datosModulo(0)))
                    Call cargarlistbox()
                End If
            End If

        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub borrarModulo(ByVal id As Integer)
        'una llamada por cada tabla afectada. Como la funcion  es booleana, la puedo usar en una comparacion
        'ojo, borrar primero las tablas secundarias, si no, da error
        If borrar("Cursos_Modulos", True, id) = True AndAlso borrar("Modulos", False, id) = True Then
            MsgBox("Modulo Borrado con exito")
        End If
    End Sub
    Friend Function borrar(ByVal tabla As String, ByVal EsTablaSecundaria As Boolean, ByVal ident As Integer) As Boolean
        cn = New SqlConnection(ConeStr)
        Try
            Dim sql As String
            If EsTablaSecundaria = True Then
                sql = "DELETE FROM " & tabla & " WHERE " & tabla & ".IdMod=" & ident
            Else
                sql = "DELETE FROM " & tabla & " WHERE " & tabla & ".Id=" & ident
            End If
            ' MsgBox(sql)
            cn.Open()
            Dim cmd2 As New SqlCommand(sql, cn)
            Dim i As Integer = cmd2.ExecuteNonQuery
            If i <= 0 AndAlso EsTablaSecundaria = False Then Throw New miExcepcion("error al borrar elemento de " & tabla, 155, Me.Name.ToString)
            '  MsgBox("elemento de " & tabla & " eliminado correctamente")
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
        Return True
    End Function

  
End Class