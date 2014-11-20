Imports System.Data.SqlClient

Public Class Form1
    Dim cn As SqlConnection
    ''BOTON DE PRUEBA CON CONSULTA
    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    cn = New SqlConnection("Data Source=JAVIPORTATIL;Initial Catalog=BBDD_02;Integrated Security=True")
    '    Dim sql As String = "Select alumnos.CodAl from alumnos"
    '    cn.Open()
    '    Dim dr As SqlDataReader
    '    Dim cmd As New SqlCommand(sql, cn)
    '    dr = cmd.ExecuteReader
    '    Do While dr.Read
    '        Me.ListBox1.Items.Add(dr(0))
    '    Loop
    '    cn.Close()
    'End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Button1.Visible = False
        Me.Label1.Visible = False
        Me.CmdGestionar.Enabled = False
    End Sub

    Private Sub cmdCrear_Click(sender As Object, e As EventArgs) Handles cmdCrear.Click
        Dim frm As New FrmCrear
        frm.ShowDialog()
    End Sub

    Private Sub CmdGestionar_Click(sender As Object, e As EventArgs) Handles CmdGestionar.Click
        Dim frm As New FrmGestionar
        frm.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'boton de acceso al formulario de pruebas
        Dim frm As New Form2
        frm.ShowDialog()
    End Sub
End Class
