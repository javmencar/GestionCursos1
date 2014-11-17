Imports System.Data.SqlClient

Public Class FrmCursos
    Dim EsCurso As Boolean
    Dim cont As Integer
    Dim cn As SqlConnection
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal EsC As Boolean) ' comento este constructor porque no lo necesito
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        EsCurso = EsC
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub


    Dim cur As Curso
    Private Sub FrmCursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Call cargarlistbox()
    End Sub
    Private Sub cargarlistbox()
        cn = New SqlConnection(ConeStr)
        Me.LstCursosOModulos.Items.Clear()
        Dim Sql As String = ""
        If EsCurso = True Then
            Sql = "SELECT cursos.codcur, cursos.nombre FROM cursos ORDER BY cursos.Id ASC"
        Else
            Sql = "SELECT modulos.id, modulos.Nombre FROM modulos ORDER BY modulos.id ASC"
        End If
        cn.Open()
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand(Sql, cn)
        dr = cmd.ExecuteReader
        Do While dr.Read
            Me.LstCursosOModulos.Items.Add(dr(0) & "_" & dr(1))
        Loop
        cn.Close()
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Try
            cont = Me.LstCursosOModulos.SelectedIndex
            If cont = -1 Then
                If EsCurso = True Then Throw New miExcepcion("No se ha seleccionado ningun curso")
                If EsCurso = False Then Throw New miExcepcion("No se ha seleccionado ningun modulo")
            Else
                If EsCurso = True Then 'cargamos cursos
                    'si estamos en cursos debo buscar el idcurso
                    cont = determinaridcurso()
                    Dim c As Curso
                    c = cargarElCurso(cont)
                    If Not IsNothing(c) Then
                        ' le paso el objeto curso cargado con todos los datos
                        Dim frm As New FrmModificarCursos(c)
                        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            MsgBox("Curso insertado" & vbCrLf & Me.Name.ToString)
                            Call cargarlistbox()
                        Else
                            Dim errorEnModif As String = "error al intentar modificar el curso al volver de FrmModificarCursos(" & cont & ")"
                            Throw New miExcepcion(errorEnModif, 41, Me.Name.ToString)
                        End If
                    Else
                        Throw New miExcepcion("Error al intentar modificar un curso")
                    End If
                Else 'cargamos modulos
                    Dim m As Modulo
                    m = cargarElModulo(cont)
                    If Not IsNothing(m) Then
                        Dim frm As New FrmModificarModulos(m)
                        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            MsgBox("Modulo insertado" & vbCrLf & Me.Name.ToString)
                            Call cargarlistbox()
                        End If
                    End If
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

    Private Sub cmdNuevoCurso_Click(sender As Object, e As EventArgs) Handles cmdNuevoCurso.Click
        Try
            'como no hay nada seleccionado le paso -1 para que sepa que será nuevo
            cont = -1
            If EsCurso = True Then
                Dim frm As New FrmModificarCursos(cont)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    MsgBox("Nuevo Curso insertado")
                    Call cargarlistbox()
                Else
                    Throw New miExcepcion("error al insertar el Curso", 105, Me.Name.ToString)
                    'Throw New miExcepcion("error al insertar el Curso")
                End If
            Else
                Dim frm As New FrmModificarModulos(cont)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    MsgBox("Nuevo Modulo insertado")
                    Call cargarlistbox()
                Else
                    Throw New miExcepcion("error al insertar el Modulo", 114, Me.Name.ToString)
                    'Throw New miExcepcion("error al insertar el Modulo")
                End If
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

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub


    Public Function determinaridcurso() As Integer
        cn = New SqlConnection(ConeStr)
        Dim i As Integer = 0
        Try
            Dim aux() As String = Me.LstCursosOModulos.SelectedItem.ToString.Split("_")
            Dim sql As String = "select Cursos.id from cursos where cursos.CodCur='" & aux(0) & "'"
            ' MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            i = cmd.ExecuteScalar
            '   MsgBox("El id devuelto es: " & i)
            cn.Close()
        Catch ex As Exception
        End Try
        Return i
    End Function

    Private Sub cmdBorrarCurso_Click(sender As Object, e As EventArgs) Handles cmdBorrarCurso.Click
        Try
            cont = Me.LstCursosOModulos.SelectedIndex
            Dim tabla As String = ""
            If EsCurso = True Then
                tabla = "Curso"
            Else
                tabla = "Modulo"
            End If
            If cont = -1 Then Throw New miExcepcion(String.Format("No se ha seleccionado ningun {0}", tabla), 32, Me.Name.ToString)
            Dim aux() As String = Split(Me.LstCursosOModulos.SelectedItem.ToString, "_")
            Dim respuesta1 As MsgBoxResult
            respuesta1 = MsgBox(String.Format("Ha seleccionado el {0} '{1}'" & vbCrLf &
                                              "¿Está seguro de querer borrar el {0} con todos sus datos?", tabla, aux(1)), MsgBoxStyle.YesNo)
            If respuesta1 = MsgBoxResult.No Then
                Me.DialogResult = Windows.Forms.DialogResult.None
            Else
                Dim respuesta2 As MsgBoxResult
                respuesta2 = MsgBox("¿Está totalmente seguro de querer borrarlo? Los datos no podrán recuperarse", MsgBoxStyle.YesNo)
                If respuesta2 = MsgBoxResult.No Then
                    Me.DialogResult = Windows.Forms.DialogResult.None
                Else
                    If EsCurso Then
                        cont = determinaridcurso()
                        Call borrarCurso(cont)
                        Call cargarlistbox()
                    Else
                        Call borrarModulo(cont)
                        Call cargarlistbox()
                    End If
            End If

        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub borrarCurso(ByVal id As Integer)
        'una llamada por cada tabla afectada
        'ojo, borrar primero las tablas secundarias, si no, da error
        If borrar("Cursos_Modulos", True, id) = True AndAlso borrar("Cursos", False, id) = True Then
            MsgBox("Curso Borrado con exito")

        End If

    End Sub
    Private Sub borrarModulo(ByVal id As Integer)
        'una llamada por cada tabla afectada. Como la funcion  es booleana, la puedo usar en una comparacion
        'ojo, borrar primero las tablas secundarias, si no, da error
        If borrar("Cursos_Modulos", True, id) = True AndAlso borrar("Modulos", False, id) = True Then
            MsgBox("Modulo Borrado con exito")
        End If
    End Sub
    Private Function borrar(ByVal tabla As String, ByVal EsTablaSecundaria As Boolean, ByVal ident As Integer) As Boolean
        cn = New SqlConnection(ConeStr)
        Try
            Dim sql As String
            If EsTablaSecundaria = False Then
                sql = String.Format("DELETE FROM {0} WHERE {0}.Id={1}", tabla, ident)
                ' sql = "DELETE FROM " & tabla & " WHERE " & tabla & ".Id=" & ident
            Else
                sql = String.Format("DELETE FROM {0} WHERE {0}.IdCur={1}", tabla, ident)
                ' sql = "DELETE FROM " & tabla & " WHERE " & tabla & ".IdCur=" & ident
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
        End Try
        Return True
    End Function
   
    Public Function cargarElCurso(ByVal i As Integer) As Curso
        Dim cu As New Curso

        Try
            Dim sql As String = "select * from cursos where cursos.Id=" & i
            cn.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                cu.Id = dr(0)
                cu.CodCur = dr(1)
                cu.Nombre = dr(2)
                cu.horas = dr(3)
            End If
            Dim cn2 As New SqlConnection(ConeStr)
            cn2.Open()
            Dim sql2 As String = "select modulos.Id, modulos.Nombre, Modulos.Horas from Modulos," &
                "Cursos_Modulos where modulos.Id=Cursos_Modulos.IdMod and Cursos_Modulos.Idcur=" & i
            Dim dr2 As SqlDataReader
            Dim cmd2 As New SqlCommand(sql2, cn2)
            dr2 = cmd2.ExecuteReader
            'creo el modulo vacío y lo instancio y lo borro dentro del bucle
            Dim m As Modulo
            While dr2.Read
                m = New Modulo
                m.Id = dr2(0)
                m.Nombre = dr2(1)
                m.horas = dr2(2)
                cu.añadirModulos(m)
                m = Nothing
            End While
            cn2.Close()
        Catch ex2 As miExcepcion
            cu = Nothing
            MsgBox(ex2.ToString)
        Catch ex As Exception
            cu = Nothing
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
        Return cu
    End Function
    Public Function cargarElModulo(ByVal i As Integer) As Modulo
        Dim Mo As New Modulo

        Try
            Dim sql As String = "SELECT * FROM Modulos WHERE Modulos.Id=" & i
            cn.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                Mo.Id = dr(0)
                Mo.Nombre = dr(1)
                Mo.horas = dr(2)
            End If
          
        Catch ex2 As miExcepcion
            Mo = Nothing
            MsgBox(ex2.ToString)
        Catch ex As Exception
            Mo = Nothing
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
        Return Mo
    End Function
End Class