
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
        Call cargarColumnasListview(Me.ListView1, "Personal")
        Select Case pos
            Case 1
                'Aqui el codigo si es para alumnos

            Case 2
                'aqui el codigo si es para profesores
        End Select

    End Sub
    Private Sub cargarColumnasListview(ByVal lst As ListView, ByVal tabla As String)

        Try
            Dim sql As String = "Select c.name FROM sys.columns c JOIN sys.tables t ON c.object_id = t.object_id WHERE t.name = '" & tabla & "'"
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Me.ListView1.Columns.Add(dr(0), 75, HorizontalAlignment.Center)
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