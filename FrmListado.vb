
Imports System.Data.SqlClient
Public Class FrmListado

    Public cn As SqlConnection
    Public cat As String
    Dim tipo As Integer
    Public Sub New(ByVal ti As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        tipo = ti
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        With Me.CboFiltro
            .Items.Add("DNI")
            .Items.Add("Nombre")
            .Items.Add("Apellido1")
            .Items.Add("Apellido2")
        End With
        Select Case tipo
            Case 1
                cat = "Alumnos"
                Me.Label1.Text = "Listado de Alumnos"
            Case 2
                cat = "Profesores"
                Me.Label1.Text = "Listado de Profesores"
            Case 3
                cat = "Candidatos"
                Me.Label1.Text = "Listado de candidatos"
        End Select
      limpiarListView()
    End Sub
    Private Sub limpiarListView()
        Me.ListView1.Refresh()
        With Me.ListView1
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Sorting = SortOrder.Ascending
            .Items.Clear()
            With .Columns
                .Add("Id", 25, HorizontalAlignment.Center)
                .Add("DNI", 75, HorizontalAlignment.Center)
                .Add("Nombre", 180, HorizontalAlignment.Center)
                .Add("Apellido1", 180, HorizontalAlignment.Center)
                .Add("Apellido2", 180, HorizontalAlignment.Center)
            End With
        End With
        Call cargarDatosEnListview()
    End Sub
    Private Sub cargarDatosEnListview()
        Try
            Me.ListView1.Items.Clear()
            cn.Open()
            Dim sql As String = ""
            Select Case tipo
                Case 1  ' "Alumnos"
                    sql = "SELECT Alumnos.Id, DatosPersonales.DNI, DatosPersonales.Nombre, DatosPersonales.Apellido1, DatosPersonales.Apellido2" &
                            " FROM Alumnos, DatosPersonales " &
                             " WHERE DatosPersonales.Id=Alumnos.IdDP ORDER BY Alumnos.IdDP ASC "
                Case 2  ' "Profesores"
                    sql = "SELECT Profesores.Id, DatosPersonales.DNI, DatosPersonales.Nombre, DatosPersonales.Apellido1, DatosPersonales.Apellido2" &
                             " FROM Profesores, DatosPersonales " &
                             "  WHERE DatosPersonales.Id=Profesores.IdDP ORDER BY Profesores.IdDP ASC "
                Case 3  ' "Candidatos"
                    sql = "SELECT DatosPersonales.Id, DatosPersonales.DNI, DatosPersonales.Nombre, DatosPersonales.Apellido1, DatosPersonales.Apellido2" &
                            " FROM DatosPersonales " &
                             " WHERE NOT EXISTS (SELECT 1 FROM Alumnos WHERE Alumnos.IdDP=DatosPersonales.Id) " &
                             " AND NOT EXISTS (SELECT 1 FROM Profesores WHERE Profesores.IdDP=DatosPersonales.Id)" &
                             " ORDER BY DatosPersonales.Id ASC"
                Case Else
                    Throw New miExcepcion("error al cargar los datos en el listview")
            End Select
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader

            Dim i As Integer = 0
            While dr.Read
                Me.ListView1.Items.Add(dr(0))
                Me.ListView1.Items(i).SubItems.Add(dr(1).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(2).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(3).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(4).ToString)
                i += 1
            End While
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        Dim dpers As New DatosPersonales
        'en tipo llevo si es alumno, profesor o candidato; true porque es nuevo
        Dim frm As New FrmFichas(dpers, tipo, True)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            MsgBox("Insercion en la base de datos Completada")
            Call cargarDatosEnListview()
        ElseIf frm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Throw New miExcepcion("cancelado a peticion del usuario")
        ElseIf frm.ShowDialog = Windows.Forms.DialogResult.Abort Then
            Throw New miExcepcion("cancelado a peticion del usuario")
        End If
    End Sub
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim aviso As String = cat.Substring(0, cat.Length - 1)
        Try
            If Me.ListView1.SelectedIndices.Count = 0 Then Throw New miExcepcion("Debe seleccionar un elemento del listado")
            Dim DP As DatosPersonales = RellenarDatosPersonales()
            If Not IsNothing(DP) Then
                'en tipo llevo si es alumno, profesor o candidato; false porque es modificacion de uno existente
                Dim frm As New FrmFichas(DP, tipo, False)
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    MsgBox("Modificación Completada Correctamente")
                    Call cargarDatosEnListview()
                ElseIf frm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                    Throw New miExcepcion("proceso cancelado a peticion del usuario")
                ElseIf frm.ShowDialog = Windows.Forms.DialogResult.Abort Then
                    Throw New miExcepcion("proceso cancelado")
                End If
            Else
                Throw New miExcepcion("Error al cargar los datos")
            End If
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function RellenarDatosPersonales() As DatosPersonales
        Dim DP As New DatosPersonales
        Try
            cn = New SqlConnection(ConeStr)
            'recupero el id del elemento que quiero modificar a traves del listview
            Dim id As Integer = CInt(Me.ListView1.SelectedItems(0).Text)
            Dim Sql As String
            If tipo = 3 Then '3 es candidato
                sql = String.Format("SELECT * FROM DatosPersonales WHERE DatosPersonales.Id={0}", id)
            Else
                Sql = String.Format("SELECT * FROM DatosPersonales, {0} WHERE DatosPersonales.Id={0}.IdDP and {0}.Id={1}", cat, id)
            End If
            cn.Open()
            Dim cmd As New SqlCommand(Sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                With DP
                    If Not IsNothing(dr(0)) Then
                        .Id = dr(0)
                    End If
                    If Not IsDBNull(dr(1)) Then
                        .DNI = dr(1)
                    End If
                    If Not IsDBNull(dr(2)) Then
                        .Nombre = dr(2)
                    End If
                    If Not IsDBNull(dr(3)) Then
                        .Apellido1 = dr(3)
                    End If
                    If Not IsDBNull(dr(4)) Then
                        .Apellido2 = dr(4)
                    End If
                    If Not IsDBNull(dr(5)) Then
                        .Fnac = dr(5)
                    End If
                    If Not IsDBNull(dr(6)) Then
                        .LugNac = dr(6)
                    End If
                    If Not IsDBNull(dr(7)) Then
                        .Edad = dr(7)
                    End If
                    If Not IsDBNull(dr(8)) Then
                        .Domicilio = dr(8)
                    End If
                    If Not IsDBNull(dr(9)) Then
                        .CP = dr(9)
                    End If
                    If Not IsDBNull(dr(10)) Then
                        .Poblacion = dr(10)
                    End If
                    If Not IsDBNull(dr(11)) Then
                        .Tel1 = dr(11)
                    End If
                    If Not IsDBNull(dr(12)) Then
                        .Tel2 = dr(12)
                    End If
                    If Not IsDBNull(dr(13)) Then
                        .NumSS = dr(13)
                    End If
                    If Not IsDBNull(dr(14)) Then
                        .InInaem = dr(14)
                    End If
                    If Not IsDBNull(dr(15)) Then
                        .InFecha = dr(15)
                    End If
                    If Not IsDBNull(dr(16)) Then
                        .NivelEstudios = dr(16)
                    End If
                    If Not IsDBNull(dr(17)) Then
                        .ExpSector = dr(17)
                    End If
                    If Not IsDBNull(dr(18)) Then
                        .TallaCamiseta = dr(18)
                    End If
                    If Not IsDBNull(dr(19)) Then
                        .TallaPantalon = dr(19)
                    End If
                    If Not IsDBNull(dr(20)) Then
                        .TallaZapato = dr(20)
                    End If
                    If Not IsDBNull(dr(21)) Then
                        .Entrevistador = dr(21)
                    End If
                    If Not IsDBNull(dr(22)) Then
                        .FecEntr = dr(22)
                    End If
                    If Not IsDBNull(dr(23)) Then
                        .Valoracion = dr(23)
                    End If
                    If Not IsDBNull(dr(24)) Then
                        .Apto = dr(24)
                    End If
                    If Not IsDBNull(dr(25)) Then
                        .PathFoto = dr(25)
                    End If
                    .cargarlistas()
                End With
            End If

        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
            DP = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
            DP = Nothing
        Finally
            cn.Close()
        End Try
        Return DP
    End Function
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Public Function borrarDatosPersonales(ByVal i As Integer) As Integer
        Dim num, idDP As Integer
        Dim sqlIdDP As String = String.Format("Select DatosPersonales.Id from DatosPersonales, {0} where DatosPersonales.Id={0}.IdDP and {0}.id={1}", cat, CStr(i))
        Dim sqlalumnos As String = String.Format("delete from {0} where {0}.id={1}", cat, CStr(i))
        Dim sqlDatosPersonales As String = "DELETE FROM DatosPersonales WHERE DatosPersonales.Id="
        Dim cn2 As New SqlConnection(ConeStr)
        Try
            If cat = "Candidatos" Then
                cn.Open()
                Dim cmd1 As SqlCommand
                sqlDatosPersonales &= CStr(i)
                cmd1 = New SqlCommand(sqlDatosPersonales, cn)
                num = cmd1.ExecuteNonQuery
                If num < 0 Then Throw New miExcepcion(String.Format("Error al borrar datos personales en {0}", cat))
            Else ' Para alumnos y profesores primero busco la ID
                Dim cmd1, cmd2, cmd3 As SqlCommand
                cmd1 = New SqlCommand(sqlIdDP, cn)
                idDP = cmd1.ExecuteScalar
                cn.Close()
                cn.Open()
                cmd2 = New SqlCommand(sqlalumnos, cn)
                num = cmd2.ExecuteNonQuery
                If num <> 1 Then Throw New miExcepcion("error al borrar")
                cn2.Open()
                sqlDatosPersonales &= CStr(idDP) ' Añado la Id obtenida al final de la consulta
                cmd3 = New SqlCommand(sqlDatosPersonales, cn2)
                num = cmd3.ExecuteNonQuery
                If num <> 1 Then Throw New miExcepcion("Error al borrar datos personales en")
            End If
        Catch ex2 As miExcepcion
            num = -1
        Catch ex As Exception
            num = -1
            MsgBox(ex.ToString)
        Finally
            cn.Close()
            cn2.Close()
        End Try
        Return num
    End Function

    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click
        Try
            Dim respuesta1, respuesta2 As MsgBoxResult
            Dim nombre As String = ""
            Dim id As Integer = CInt(Me.ListView1.SelectedItems(0).Text)
            MsgBox(id)
            If Me.ListView1.SelectedItems.Count = 0 Then
                MsgBox("Debe seleccionar el elemento a borrar")
            Else
                For i As Integer = 2 To 4
                    nombre &= " " & Me.ListView1.SelectedItems.Item(0).SubItems(i).Text
                Next
                respuesta1 = MsgBox(String.Format("Ha seleccionado el elemento: ' {0} ' para ser borrado" & vbCrLf & "¿Está seguro?", nombre), MsgBoxStyle.YesNo)
                If respuesta1 = MsgBoxResult.No Then Throw New miExcepcion("Borrado cancelado a peticion del usuario")
                respuesta2 = MsgBox("¿Seguro que desea continuar?" & vbCrLf & "Una vez borrado no se puede recuperar", MsgBoxStyle.YesNo)
                If respuesta2 = MsgBoxResult.No Then Throw New miExcepcion("Borrado cancelado a peticion del usuario")
                Dim resultadoBorrar As Integer = borrarDatosPersonales(id)
                If resultadoBorrar = -1 Then Throw New miExcepcion("Error al borrar")
                MsgBox("Datos borrados con éxito")
                Call cargarDatosEnListview()
            End If
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        If Me.CboFiltro.SelectedIndex = -1 Then
            MsgBox(" Seleccione un criterio de busqueda del combo")
        Else
            Dim pos As Integer = -1
            Dim encontrado As Boolean = False
            For i As Integer = 0 To Me.ListView1.Items.Count - 1
                If Me.ListView1.Items(i).SubItems(Me.CboFiltro.SelectedIndex + 1).Text = Me.TxtCampo.Text Then
                    encontrado = True
                    pos = i
                    Exit For
                End If
            Next
            If pos = -1 Then ' No lo ha encontrado
                MsgBox(String.Format("El {0} a buscar no se encuentra en el listado", Me.CboFiltro.SelectedItem.ToString))
                Me.TxtCampo.Focus()
                Me.TxtCampo.SelectAll()
            Else 'Lo ha encontrado
                Me.ListView1.Focus()
                Me.ListView1.Items.Item(pos).Selected = True
                Me.ListView1.SelectedItems.Item(0).Focused = True
                If Not IsNothing(Me.ListView1.FocusedItem) Then
                    Me.ListView1.FocusedItem.EnsureVisible()
                    Me.ListView1.SelectedItems.Item(0).Checked = True
                End If
                'Limpio el combo y el campo
                Me.CboFiltro.SelectedIndex = -1
                Me.TxtCampo.Text = ""
            End If
        End If
    End Sub
End Class