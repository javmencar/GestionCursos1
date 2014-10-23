
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

    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class