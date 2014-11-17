
Imports System.Data.SqlClient
Public Class FrmCrear
    Dim cn As SqlConnection
    Private Sub FrmCrear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdCurso_Click(sender As Object, e As EventArgs) Handles cmdCurso.Click
        'le paso true porque es curso
        Dim frm As New FrmCursos(True)
        frm.ShowDialog()

    End Sub

    Private Sub cmdModulos_Click(sender As Object, e As EventArgs) Handles cmdModulos.Click
        'le paso false porque es modulo
        Dim frm As New FrmModulos(False)
        frm.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'alumnos, le paso 1 como valor
        Dim frm As New FrmListado(1)
        frm.ShowDialog()
    End Sub

    Private Sub CmdProfesores_Click(sender As Object, e As EventArgs) Handles CmdProfesores.Click
        'profesor, le mando 0 como valor
        Dim frm As New FrmListado(0)
        frm.ShowDialog()
    End Sub
End Class