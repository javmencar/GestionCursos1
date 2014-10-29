Imports System.Data.SqlClient
'formulario borrable, es para hacer pruebas
Public Class Form2
    Dim cn As SqlConnection
    Dim cur As Curso
    Public arr As ArrayList
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Arr = New ArrayList
        arr.Add("5_modulo 5")
        arr.Add("3_modulo 3")
        arr.Add("1_modulo 1")
        arr.Add("4_modulo 4")
        arr.Add("2_modulo 2")

        For Each lin As String In arr
            Me.ListBox1.Items.Add(lin.ToString)
        Next

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '       prueba para ver como sacaba los valores de un objeto a string
    '    Dim i As Integer = CInt(Me.TextBox1.Text)
    '    Dim sql As String = "select cursos.codcur, cursos.nombre,cursos.horas from cursos where cursos.id=" & i
    '    cn.Open()
    '    Dim dr As SqlDataReader
    '    Dim cmd As New SqlCommand(sql, cn)
    '    dr = cmd.ExecuteReader
    '    cur = New Curso
    '    MsgBox(sql)
    '    Do While dr.Read
    '        cur.CodCur = dr(0)
    '        cur.Nombre = dr(1)
    '        cur.horas = dr(2)
    '    Loop
    '    cn.Close()

    '    Me.TextBox2.Text = cur.ValoresAString
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    ''cur = New Curso
    '    'Try
    '    '    If 1 = 1 Then Throw New miExcepcion(String.Format("error al {0} en la linea  {1} en el formulario " & Me.Name.ToString, "", 0))
    '    'Catch ex As miExcepcion
    '    '    MsgBox(ex.ToString)
    '    '    Me.Name.ToString()
    '    'End Try
    '    '' Dim str As String = String.Format("error al insertar el registro en la linea  {0} en el formulario " & Me.ToString, 225)
    '    ''MsgBox(str)
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    arr.Sort()
    '    Me.ListBox1.Items.Clear()
    '    For Each lin As String In arr
    '        Me.ListBox1.Items.Add(lin.ToString)
    '    Next
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim vieja As String = Me.TextBox1.Text
        Dim dias, meses, años As String
        dias = vieja.Substring(0, 2)
        meses = vieja.Substring(3, 2)
        años = vieja.Substring(6, 4)
        Dim nueva As String = años & meses & dias
        MsgBox(nueva)
    End Sub
End Class