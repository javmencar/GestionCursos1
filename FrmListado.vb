
Imports System.Data.SqlClient
Public Class FrmListado
    '  Public pos As Integer
    Public cn As SqlConnection
    Public cat As String
    Dim LstClk(4) As Integer
    'Public Sub New()

    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    'End Sub
    Public Sub New(ByVal al As Boolean)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        If al = True Then
            cat = "Alumnos"
        Else
            cat = "Profesores"
        End If
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
      limpiarListView()
        With Me.CboFiltro
            .Items.Add("DNI")
            .Items.Add("Nombre")
            .Items.Add("Apellido1")
            .Items.Add("Apellido2")
        End With

    End Sub
    Private Sub limpiarListView()
        Me.ListView1.Refresh()
        With Me.ListView1
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Sorting = SortOrder.Ascending
            '.FocusedItem.EnsureVisible()
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
            Dim sql As String = String.Format("SELECT {0}.id, DatosPersonales.DNI, DatosPersonales.Nombre, DatosPersonales.Apellido1, DatosPersonales.Apellido2" &
                   " FROM {0}, DatosPersonales WHERE DatosPersonales.Id={0}.IdDP ORDER BY {0}.IdDP ASC ", cat)
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            'creo un contador para ayudarme a poner los valores en los items correctos
            Dim i As Integer = 0
            While dr.Read
                'aqui añado un dato nuevo
                Me.ListView1.Items.Add(dr(0))
                'aqui añado los subitems al recien añadido. El contador 'i' me llevará el item alque añadirlo
                Me.ListView1.Items(i).SubItems.Add(dr(1).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(2).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(3).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(4).ToString)
                'aumentamos 'i' para la siguiente vuelta
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
        Select Case cat
            Case "Profesores"
                'el objeto, si es alumno, si es nuevo
                Dim frm As New FrmFichas(dpers, False, True)
                If frm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                    MsgBox("Proceso cancelado")
                ElseIf frm.ShowDialog = Windows.Forms.DialogResult.Abort Then
                    MsgBox("Proceso cancelado a peticicion del usuario")
                ElseIf frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ' recupero el objeto alumno ya rellenado y lo vuelco en la base de datos
                    ' '  MsgBox(alu.Nombre & " ha sido insertado con exito")
                    MsgBox("Se ha insertado correctamente el Profesor en la base de datos")
                    Call cargarDatosEnListview()
                End If
            Case "Alumnos"
                'el objeto, si es alumno, si es nuevo 
                Dim frm As New FrmFichas(dpers, True, True)
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

                    MsgBox("Se ha insertado correctamente el alumno en la base de datos")
                    Call cargarDatosEnListview()
                End If
            Case Else

        End Select




    End Sub


    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        If Me.ListView1.SelectedIndices.Count = 0 Then
            MsgBox("Debe seleccionar un elemento del listado" & vbCrLf &
                   "Para ello pinche en el número de ID del elemento que quiera")
        Else
            Dim DP As DatosPersonales = RellenarDatosPersonales()
            If Not IsNothing(DP) Then
                Select Case cat
                    Case "Profesores"
                        'el objeto, si es alumno, si es nuevo 
                        Dim frm As New FrmFichas(DP, False, False)
                        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            MsgBox("Operacion Realizada con éxito")
                        Else
                            MsgBox("Salida sin crear nada")
                        End If
                    Case "Alumnos"
                        'el objeto, si es alumno, si es nuevo
                        Dim frm As New FrmFichas(DP, True, False)
                        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            MsgBox("Operacion Realizada con éxito")
                        Else
                            MsgBox("Salida sin modificar nada")
                        End If
                End Select
            End If
            Call limpiarListView()
            End If
    End Sub
    Private Function RellenarDatosPersonales() As DatosPersonales
        Dim DP As New DatosPersonales
        Try
            cn = New SqlConnection(ConeStr)
            'recupero el id del alumno que quiero modificar a traves del listview
            Dim id As Integer = CInt(Me.ListView1.SelectedItems(0).Text)
            Dim sql As String = String.Format("select * from DatosPersonales, {0} where DatosPersonales.Id={0}.IdDP and {0}.id={1}", cat, id)
            ' MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
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
                End With
            End If
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
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
        '  MsgBox(sqlIdDP)
        Dim sqlalumnos As String = String.Format("delete from {0} where {0}.id={1}", cat, CStr(i))
        ' MsgBox(sqlalumnos)
        Dim sqlDatosPersonales As String = "DELETE FROM DatosPersonales WHERE DatosPersonales.Id="
        ' MsgBox(sqlDatosPersonales)
        Dim cn2 As New SqlConnection(ConeStr)
        Try
            cn.Open()
            'hago la consulta para obtener la ID de DatosPersonales
            Dim cmd1, cmd2, cmd3 As SqlCommand
            cmd1 = New SqlCommand(sqlIdDP, cn)
            idDP = cmd1.ExecuteScalar
            cn.Close()
            cn.Open()
            cmd2 = New SqlCommand(sqlalumnos, cn)
            num = cmd2.ExecuteNonQuery
            If num < 0 Then
                If cat = "Alumnos" Then Throw New miExcepcion("Error al borrar Alumno")
                If cat = "Profesores" Then Throw New miExcepcion("Error al borrar Profesor")
            End If
            cn2.Open()
            sqlDatosPersonales &= CStr(idDP)
            ' MsgBox("Ahora con el Id: " & vbCrLf & sqlDatosPersonales)
            cmd3 = New SqlCommand(sqlDatosPersonales, cn2)
            num = cmd2.ExecuteNonQuery
            If num < 0 Then Throw New miExcepcion(String.Format("Error al borrar datos personales en {0}", cat))
        Catch ex2 As miExcepcion
            num = -1
            'MsgBox(ex2.ToString)
        Catch ex As Exception
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
                MsgBox("Alumno y sus datos borrados con éxito")
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
            Dim crit As String = Me.CboFiltro.SelectedItem.ToString
            Dim sb As Integer
            Select Case crit
                Case "DNI"
                    sb = 1
                Case "Nombre"
                    sb = 2
                Case "Apellido1"
                    sb = 3
                Case "Apellido2"
                    sb = 4
            End Select
            Dim pos As Integer = encontrarItemEnLIstView(sb)
            If pos = -1 Then
                MsgBox(String.Format("El {0} a buscar no se encuentra en el listado", crit))
            Else
                Me.ListView1.Focus()
                Me.ListView1.Items.Item(pos).Selected = True
                ' If Me.ListView1.SelectedIndices.Count = 1 Then
                Me.ListView1.SelectedItems.Item(0).Focused = True
                If Not IsNothing(Me.ListView1.FocusedItem) Then
                    Me.ListView1.FocusedItem.EnsureVisible()
                    Me.ListView1.SelectedItems.Item(0).Checked = True
                End If
                'End If
            End If
        End If
    End Sub
    Private Function encontrarItemEnLIstView(ByVal subit As Integer) As Integer
        Dim encontrado As Boolean = False
        Dim ind As Integer = -1
        For i As Integer = 0 To Me.ListView1.Items.Count - 1
            ' MsgBox(Me.ListView1.Items(i).SubItems(subit).Text)
            If Me.ListView1.Items(i).SubItems(subit).Text = Me.TxtCampo.Text Then
                encontrado = True
                ind = i
                Exit For
            End If
        Next
        Return ind
    End Function

End Class