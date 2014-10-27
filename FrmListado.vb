
Imports System.Data.SqlClient
Public Class FrmListado
    Public pos As Integer
    Public cn As SqlConnection
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
        Call cargarSoloColumnasPrincipalesListview()
        Select Case pos
            Case 0
                Call cargarDatosEnListview("Profesores")
            Case 1
                Call cargarDatosEnListview("Alumnos")
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
  
    Private Sub cargarDatosEnListview(ByVal cat As String)
        Try
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
                Me.ListView1.Items(i).SubItems.Add(CStr(dr(1)))
                Me.ListView1.Items(i).SubItems.Add(CStr(dr(2)))
                Me.ListView1.Items(i).SubItems.Add(CStr(dr(3)))
                Me.ListView1.Items(i).SubItems.Add(CStr(dr(4)))
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
                'Dim pro As New Profesor
                'Dim frm As New FrmFichas(pro)
            Case 1
                'creo un objeto alumno y lo paso vacío
                Dim alu As New Alumno
                Dim frm As New FrmFichas()
                If frm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                    MsgBox("Proceso cancelado")
                ElseIf frm.ShowDialog = Windows.Forms.DialogResult.Abort Then
                    MsgBox("Proceso cancelado a peticicion del usuario")
                ElseIf frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ' recupero el objeto alumno ya rellenado y la vuelco en la base de datos
                    Call insertarAlumnoEnBaseDatos(alu)
                    MsgBox("Se ha insertado correctamente el alumno en la base de datos")
                End If
            Case Else

        End Select




    End Sub
    Private Sub insertarAlumnoEnBaseDatos(ByVal a As Alumno)

    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim alu As Alumno = RellenarAlumno()
        Dim frm As New FrmFichas(alu)
        frm.ShowDialog()

    End Sub
    Private Function RellenarAlumno() As Alumno
        Dim alum As New Alumno

        Try
            cn = New SqlConnection(ConeStr)
            'recupero el id del alumno que quiero modificar a traves del listview
            Dim id As Integer = CInt(Me.ListView1.SelectedItems(0).Text)
            Dim sql As String = "select * from DatosPersonales, alumnos where DatosPersonales.Id=Alumnos.IdDP and Alumnos.id=" & id
            MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                With alum
                    If Not IsDBNull(dr(1)) Then
                        .DNI = dr(1)
                    End If
                    If Not IsDBNull(dr(2)) Then
                        .Nombre = dr(2)
                    End If
                    If Not IsDBNull(dr(3)) Then
                        
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
                        .Fnac = dr(15)
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
                        .Fnac = dr(22)
                    End If
                    If Not IsDBNull(dr(23)) Then
                        .Valoracion = dr(23)
                    End If
                    If Not IsDBNull(dr(24)) Then
                        .Apto = dr(24)
                    End If
                    If Not IsDBNull(dr(25)) Then
                        .IdFoto = dr(25)
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

        Return alum
    End Function

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class