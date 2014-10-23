
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
        'Call cargarColumnasListview(Me.ListView1, "Personal")
        Call cargarSoloColumnasPrincipalesListview()
        Dim categoria As String
        If pos = 0 Then
            categoria = "Profesor"
        Else
            categoria = "Alumno"
        End If
        Call cargarDatosEnListview(categoria)
       

    End Sub
    'Private Sub cargarColumnasListview(ByVal lst As ListView, ByVal tabla As String)
    '    'con esto cargamos todas las columnas del listview
    '    Try
    '        Dim sql As String = "Select c.name FROM sys.columns c JOIN sys.tables t ON c.object_id = t.object_id WHERE t.name = '" & tabla & "'"
    '        cn.Open()
    '        Dim cmd As New SqlCommand(sql, cn)
    '        Dim dr As SqlDataReader
    '        dr = cmd.ExecuteReader
    '        While dr.Read
    '            Me.ListView1.Columns.Add(dr(0), 75, HorizontalAlignment.Center)
    '        End While
    '    Catch ex2 As miExcepcion
    '        MsgBox(ex2.ToString)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    Finally
    '        cn.Close()
    '    End Try
    'End Sub
    Private Sub cargarSoloColumnasPrincipalesListview()
        Me.ListView1.Columns.Add("Id", 25, HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("DNI", 75, HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Nombre", 180, HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Apellido1", 180, HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Apellido2", 180, HorizontalAlignment.Center)
    End Sub
    'Private Sub cargarDatosEnListview(ByVal pr As String)
    '    Try
    '        cn.Open()
    '        Dim sql As String
    '        sql = String.Format("SELECT Personal.{0}, Personal.DNI, Personal.Nombre, Personal.Apellido1, Personal.Apellido2 FROM Personal", pr)

    '        Dim cmd As New SqlCommand(sql, cn)
    '        Dim dr As SqlDataReader
    '        dr = cmd.ExecuteReader
    '        'creo un contador para ayudarme a poner los valores en los items correctos
    '        Dim i As Integer = 0
    '        While dr.Read
    '            ' compruebo el primer valor, si es uno añado el dato
    '            If dr(0) = True Then
    '                'aqui añado un dato nuevo
    '                Me.ListView1.Items.Add(dr(1))
    '                'aqui añado los subitems al recien añadido
    '                Me.ListView1.Items(i).SubItems.Add(CStr(dr(2)))
    '                Me.ListView1.Items(i).SubItems.Add(CStr(dr(3)))
    '                Me.ListView1.Items(i).SubItems.Add(CStr(dr(4)))
    '                'aumentamos el contador para la siguiente vuelta
    '                i += 1
    '            Else
    '            End If
    '        End While

    '    Catch ex2 As miExcepcion
    '        MsgBox(ex2.ToString)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    Finally
    '        cn.Close()
    '    End Try
    'End Sub

    Private Sub cargarDatosEnListview(ByVal cat As String)
        Try
            cn.Open()
            Dim sql As String
            If cat = "profesor" Then
                sql = "SELECT Alumnos.id, DatosPersonales.DNI, DatosPersonales.Nombre, DatosPersonales.Apellido1, DatosPersonales.Apellido2" &
                    " FROM(alumnos, DatosPersonales) WHERE DatosPersonales.Id= Alumnos.IdDP"
            Else
                sql = "SELECT Profesores.id, DatosPersonales.DNI, DatosPersonales.Nombre, DatosPersonales.Apellido1, DatosPersonales.Apellido2" &
                    " FROM(Profesores, DatosPersonales) WHERE DatosPersonales.Id = Profesores.IdDP"
            End If
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            'creo un contador para ayudarme a poner los valores en los items correctos
            Dim i As Integer = 0
            While dr.Read
                ' compruebo el primer valor, si es uno añado el dato

                'aqui añado un dato nuevo
                Me.ListView1.Items.Add(dr(0))
                'aqui añado los subitems al recien añadido
                Me.ListView1.Items(i).SubItems.Add(CStr(dr(1)))
                Me.ListView1.Items(i).SubItems.Add(CStr(dr(2)))
                Me.ListView1.Items(i).SubItems.Add(CStr(dr(3)))
                Me.ListView1.Items(i).SubItems.Add(CStr(dr(4)))
                'aumentamos el contador para la siguiente vuelta
                i += 1
                Else
                End If
            End While

        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
    End Sub
End Class