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
        Dim cat As String = ""
        If EsCurso = True Then
            cat = "Curso"
        Else
            cat = "Modulo"
        End If
        Me.cmdNuevoCurso.Text = String.Format("Crear un nuevo {0}", cat)
        Me.cmdModificar.Text = String.Format("Modificar El {0} Seleccionado", cat)
        Me.cmdBorrarCurso.Text = String.Format("Borrar El {0} Seleccionado", cat)
        Me.lblLstCursos.Text = String.Format("Listado De {0}s Existentes", cat)
        'y ahora cargo los datos
        Call cargarlistbox()
    End Sub
    Private Sub cargarlistbox()
        cn = New SqlConnection(ConeStr)
        Me.LstCursosOModulos.Items.Clear()
        Dim Sql As String = ""
        If EsCurso = True Then
            Sql = "SELECT Cursos.Id, Cursos.Codcur, Cursos.Nombre FROM Cursos ORDER BY Cursos.Id ASC"
        Else
            Sql = "SELECT Modulos.Id, Modulos.Nombre FROM Modulos ORDER BY Modulos.Id ASC"
        End If
        cn.Open()
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand(Sql, cn)
        dr = cmd.ExecuteReader
        Do While dr.Read
            If EsCurso = True Then
                Me.LstCursosOModulos.Items.Add(String.Format("{0}_{1}_{2}", dr(0), dr(1), dr(2)))
            Else
                Me.LstCursosOModulos.Items.Add(String.Format("{0}_{1}", dr(0), dr(1)))
            End If
        Loop
        Me.LstCursosOModulos.Sorted = True
        cn.Close()
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Call cargarFicha()
    End Sub
    Private Sub LstCursosOModulos_DoubleClick(sender As Object, e As EventArgs) Handles LstCursosOModulos.DoubleClick
        Call cargarFicha()
    End Sub
    Private Sub cargarFicha()
        Try
            cont = Me.LstCursosOModulos.SelectedIndex
            If cont = -1 Then
                If EsCurso = True Then Throw New miExcepcion("No se ha seleccionado ningun curso")
                If EsCurso = False Then Throw New miExcepcion("No se ha seleccionado ningun modulo")
            Else
                Dim aux() As String = Split(Me.LstCursosOModulos.SelectedItem.ToString, "_")
                cont = CInt(aux(0))
                If EsCurso = True Then 'cargamos cursos
                    'si estamos en cursos debo buscar el idcurso

                    Dim c As Curso
                    c = cargarElCurso(cont)
                    If Not IsNothing(c) Then
                        ' le paso el objeto curso cargado con todos los datos
                        Dim frm As New FrmModificarCursos(False, c)
                        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            MsgBox("Curso insertado" & vbCrLf & Me.Name.ToString)
                            Call cargarlistbox()
                        ElseIf Windows.Forms.DialogResult.Cancel Then
                            Throw New miExcepcion("Modificacion cancelada")
                        Else
                            Dim errorEnModif As String = "error al intentar modificar el curso al volver de FrmModificarCursos(" & cont & ")"
                            Throw New miExcepcion(errorEnModif)
                        End If
                    Else
                        Throw New miExcepcion("Error al intentar modificar un curso")
                    End If
                Else 'cargamos modulos
                    Dim m As Modulo
                    m = cargarElModulo(cont)
                    If Not IsNothing(m) Then
                        Dim frm As New FrmModificarModulos(False, m)
                        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            MsgBox("Modulo insertado" & vbCrLf & Me.Name.ToString)
                            Call cargarlistbox()
                        Else
                            Dim errorEnModif As String = "error al intentar modificar el modulo al volver de FrmModificarModulos(" & cont & ")"
                            Throw New miExcepcion(errorEnModif, 81, Me.Name.ToString)
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
            Me.LstCursosOModulos.SelectedIndex = -1
        End Try
    End Sub
    Private Sub cmdNuevoCurso_Click(sender As Object, e As EventArgs) Handles cmdNuevoCurso.Click
        Try
            'como no hay nada seleccionado le paso -1 para que sepa que será nuevo
            cont = -1
            If EsCurso = True Then
                Dim frm As New FrmModificarCursos(True)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    MsgBox("Nuevo Curso insertado")
                    Call cargarlistbox()
                Else
                    Throw New miExcepcion("error al insertar el Curso", 105, Me.Name.ToString)
                    'Throw New miExcepcion("error al insertar el Curso")
                End If
            Else
                Dim frm As New FrmModificarModulos(True)
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

    Private Sub cmdBorrarCurso_Click(sender As Object, e As EventArgs) Handles cmdBorrarCurso.Click
        Try
            cont = Me.LstCursosOModulos.SelectedIndex
            If cont = -1 Then Throw New miExcepcion("No se ha seleccionado nada del listado")
            Dim categoria As String = ""
            

            Dim aux() As String = Split(Me.LstCursosOModulos.SelectedItem.ToString, "_")
            cont = CInt(aux(0))
            If EsCurso = True Then
                categoria = "Curso"
            Else
                categoria = "Modulo"
            End If
            Dim respuesta1 As MsgBoxResult
            respuesta1 = MsgBox(String.Format("Ha seleccionado el {0} '{1}'" & vbCrLf &
                                              "¿Está seguro de querer borrar el {0} con todos sus datos?", categoria, aux(1)), MsgBoxStyle.YesNo)
            If respuesta1 = MsgBoxResult.No Then
                Me.DialogResult = Windows.Forms.DialogResult.None
            Else
                Dim respuesta2 As MsgBoxResult
                respuesta2 = MsgBox("¿Está totalmente seguro de querer borrarlo? Los datos no podrán recuperarse", MsgBoxStyle.YesNo)
                If respuesta2 = MsgBoxResult.No Then
                    Me.DialogResult = Windows.Forms.DialogResult.None
                Else
                    Dim borrado As Boolean = borrar(cont)
                    If borrado = False Then Throw New miExcepcion("Error al borrar")
                    Call cargarlistbox()
                    MsgBox("Borrado efectuado")
                End If
            End If
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function borrar(ByVal i As Integer) As Boolean
        Dim cn2 As New SqlConnection(ConeStr)
        Try
            Dim sql1, sql2, sql3 As String
            Dim cmd1, cmd2, cmd3 As SqlCommand
            Dim j As Integer
            If EsCurso = True Then
                sql1 = "SELECT Cursos_Modulos.Id FROM Cursos, Cursos_Modulos " &
                        "WHERE Cursos_Modulos.IdCur=Cursos.Id And Cursos.Id=" & CStr(i)
                sql2 = "DELETE FROM Cursos_Modulos WHERE Cursos_Modulos.IdCur=" & CStr(i)
                sql3 = "DELETE FROM Cursos WHERE Cursos.Id=" & i
            Else
                sql1 = "SELECT Cursos_Modulos.Id FROM Modulos, Cursos_Modulos " &
                       "WHERE Cursos_Modulos.IdMod=Modulos.Id And Modulos.Id=" & CStr(i)
                sql2 = "DELETE FROM Cursos_Modulos WHERE Cursos_Modulos.IdMod=" & CStr(i)
                sql3 = "DELETE FROM Modulos WHERE Modulos.Id=" & CStr(i)
            End If
            cn.Open()
            cmd1 = New SqlCommand(sql1, cn)
            j = cmd1.ExecuteScalar
            cn.Close()
            'reabro la conexion, si hay registro en cursos_Modulos lo borro
            If j > 0 Then
                cn.Open()
                cmd2 = New SqlCommand(sql2, cn)
                j = cmd2.ExecuteNonQuery()
                If j <= 0 Then Throw New miExcepcion()
            End If
            cn2.Open()
            cmd3 = New SqlCommand(sql3, cn2)
            j = cmd3.ExecuteNonQuery()
        Catch ex2 As miExcepcion
            Return False
        Catch ex As Exception
            Return False
        Finally
            cn.Close()
            cn2.Close()
        End Try
        Return True
    End Function
    Private Function borrar(ByVal tabla As String, ByVal EsTablaSecundaria As Boolean, ByVal ident As Integer) As Boolean
        cn = New SqlConnection(ConeStr)
        Try
            Dim sql As String
            If EsTablaSecundaria = False Then
                sql = String.Format("DELETE FROM {0} WHERE {0}.Id={1}", tabla, ident)
            Else
                If EsCurso = True Then
                    sql = String.Format("DELETE FROM {0} WHERE {0}.IdCur={1}", tabla, ident)
                Else
                    sql = String.Format("DELETE FROM {0} WHERE {0}.IdMod={1}", tabla, ident)
                End If

            End If
            ' MsgBox(sql)
            cn.Open()
            Dim cmd2 As New SqlCommand(sql, cn)
            Dim i As Integer = cmd2.ExecuteNonQuery
            If i <= 0 AndAlso EsTablaSecundaria = False Then Throw New miExcepcion("error al borrar elemento de " & tabla, 155, Me.Name.ToString)
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
            Dim sql As String = "SELECT * FROM Cursos WHERE Cursos.Id=" & i
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
            Dim sql2 As String = "SELECT Modulos.Id, Modulos.Nombre, Modulos.Horas FROM Modulos," &
                "Cursos_Modulos WHERE Modulos.Id=Cursos_Modulos.IdMod and Cursos_Modulos.Idcur=" & i
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
            cu.ordenarModulos()
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