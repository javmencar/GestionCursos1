
Imports System.Data.SqlClient
Public Class FrmListado
    Public pos As Integer
    Public cn As SqlConnection
    Public cat As String
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub New(ByVal i As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        pos = i
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Me.ListView1.View = View.Details
        'cargo los nombres de las columnas
        Me.ListView1.Items.Clear()
        Call cargarSoloColumnasPrincipalesListview()
        Select Case pos
            Case 0
                cat = "Profesores"
                Call cargarDatosEnListview()
            Case 1
                cat = "Alumnos"
                Call cargarDatosEnListview()
            Case Else
                MsgBox("Por ahora esto no debería salir")
        End Select
    End Sub
    Private Sub cargarSoloColumnasPrincipalesListview()
        Me.ListView1.Columns.Add("Id", 25, HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("DNI", 75, HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Nombre", 180, HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Apellido1", 180, HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Apellido2", 180, HorizontalAlignment.Center)
    End Sub
  
    Private Sub cargarDatosEnListview()
        Try
            Me.ListView1.Items.Clear()
            cn.Open()
            Dim sql As String = String.Format("SELECT {0}.id, DatosPersonales.DNI, DatosPersonales.Nombre, DatosPersonales.Apellido1, DatosPersonales.Apellido2" &
                   " FROM {0}, DatosPersonales WHERE DatosPersonales.Id={0}.IdDP", cat)
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            'creo un contador para ayudarme a poner los valores en los items correctos
            Dim i As Integer = 0
            While dr.Read
                'aqui añado un dato nuevo
                Me.ListView1.Items.Add(dr(0))
                'aqui añado los subitems al recien añadido
                Me.ListView1.Items(i).SubItems.Add(dr(1).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(2).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(3).ToString)
                Me.ListView1.Items(i).SubItems.Add(dr(4).ToString)
                'aumentamos el contador para la siguiente vuelta
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

        Select Case pos
            Case 0
                Dim pro As New DatosPersonales
                'el objeto, si el profesor o alumno, si es nuevo o no
                Dim frm As New FrmFichas(pro, 0, True)
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
            Case 1
                'el objeto, si el profesor o alumno, si es nuevo o no
                Dim alu As New DatosPersonales
                Dim frm As New FrmFichas(alu, 1, True)
               If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                  
                    MsgBox("Se ha insertado correctamente el alumno en la base de datos")
                    Call cargarDatosEnListview()
                End If
            Case Else

        End Select




    End Sub
    

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Select pos
            Case 0
                Dim pr As DatosPersonales = RellenarDatosPersonales()
                'el objeto, si el profesor o alumno, si es nuevo o no
                Dim frm As New FrmFichas(pr, 0, False)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    MsgBox("Operacion Realizada con éxito")
                    Call cargarDatosEnListview()
                Else
                    MsgBox("Salida sin crear nada")
                End If
            Case 1

                Dim alu As DatosPersonales = RellenarDatosPersonales()
                'el objeto, si el profesor o alumno, si es nuevo o no
                Dim frm As New FrmFichas(alu, 1, False)
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        MsgBox("Operacion Realizada con éxito")
                    Call cargarDatosEnListview()
                Else
                    MsgBox("Salida sin modificar nada")
                End If
        End Select
    End Sub
    Private Function RellenarDatosPersonales() As DatosPersonales
        Dim DP As New DatosPersonales

        Try
            cn = New SqlConnection(ConeStr)
            'recupero el id del alumno que quiero modificar a traves del listview
            Dim id As Integer = CInt(Me.ListView1.SelectedItems(0).Text)
            Dim sql As String = String.Format("select * from DatosPersonales, {0} where DatosPersonales.Id={0}.IdDP and {0}.id={1}", cat, id)
            MsgBox(sql)
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
End Class