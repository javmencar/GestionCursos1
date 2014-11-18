Imports System.Data.SqlClient

Public Class FrmModificarModulos
    Dim nuevo As Boolean
    ' Dim pos As Integer
    Dim modu As Modulo
    Dim cn As SqlConnection
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal nue As Boolean, Optional ByVal m As Modulo = Nothing)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        nuevo = nue
        modu = m
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub FrmModificarModulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Try
            'hay que modificar textos de los botones segun de donde venga
            If nuevo = True Then
                'curso nuevo, textos: "crear el curso" , "cancelar la creacion"
                Me.CmdModificar.Text = "crear el Modulo"
                Me.cmdCancelar.Text = "cancelar la creacion"
                Me.txtIdModulos.Enabled = False
            Else
                'modificar: "modificar este curso" , "cancelar la modificacion"
                Me.CmdModificar.Text = "modificar este Modulo"
                Me.cmdCancelar.Text = "cancelar la modificacion"

                Call cargarformulario(modu)
                modu = New Modulo
                modu.Id = CInt(Me.txtIdModulos.Text)
                modu.Nombre = Me.txtNombreCurso.Text
                modu.horas = CInt(Me.txtHorasCurso.Text)
            End If
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        End Try
    End Sub
    'Friend Sub cargarformulario(ByVal i As Integer)
    '    cn = New SqlConnection(ConeStr)
    '    Try
    '        cn.Open()
    '        ' MsgBox(cn.ToString)

    '        Dim sql As String = "select modulos.Id, modulos.Nombre, Modulos.Horas from modulos where modulos.id=" & i
    '        ' MsgBox(sql)
    '        Dim cmd As New SqlCommand(sql, cn)
    '        Dim dr As SqlDataReader

    '        dr = cmd.ExecuteReader

    '        If Not (dr.Read()) Then
    '            Throw New miExcepcion("No hay modulos con esa id", 49, Me.Name.ToString)
    '        Else

    '            Me.txtldModulos.Text = CStr(dr(0))
    '            Me.txtNombreCurso.Text = dr(1)
    '            Me.txtHorasCurso.Text = CStr(dr(2))
    '        End If
    '        cn.Close()
    '    Catch ex2 As miExcepcion
    '        MsgBox(ex2.ToString)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub
    Private Sub cargarformulario(ByVal m As Modulo)
        Me.txtIdModulos.Text = m.Id
        Me.txtNombreCurso.Text = m.Nombre
        Me.txtHorasCurso.Text = CStr(m.horas)
    End Sub

    Private Sub CmdModificar_Click(sender As Object, e As EventArgs) Handles CmdModificar.Click
        Try
            If Me.txtNombreCurso.Text = "" Or Me.txtHorasCurso.Text = "" Then Throw New miExcepcion("Faltan datos por rellenar")
            Dim Sql As String = ""
            If nuevo = True Then
                If Me.txtNombreCurso.Text = "" Or Me.txtHorasCurso.Text = "" Then Throw New miExcepcion("No puede crear un modulo con campos vacíos" & vbCrLf &
                    "Si es necesario los puede cambiar luego")
                Sql = String.Format("INSERT INTO Modulos (Modulos.Nombre,Modulos.Horas) VALUES ('{0}',{1})",
                                    Me.txtNombreCurso.Text, Me.txtHorasCurso.Text)
            Else
                Dim cambiosvalidos As Boolean = ValidarCambios()
                If cambiosvalidos = False Then Throw New miExcepcion("Modificacion cancelada a instancia del ususario")
                Sql = String.Format("UPDATE Modulos SET MODULOS.Nombre='{0}', Modulos.Horas={1} WHERE Modulos.Id={2}",
                                   Me.txtNombreCurso.Text, Me.txtHorasCurso.Text, modu.Id)
            End If
            ' MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(Sql, cn)
            Dim val As Integer = 0
            val = cmd.ExecuteNonQuery()
            If val > 0 Then
                MsgBox("Modulo añadido")
            Else
                Throw New miExcepcion("al introducir el registro. cmd.ExecuteNonQuery da <= 0", 109, Me.Name.ToString)
            End If
            cn.Close()
            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Function ValidarCambios() As Boolean
        Dim vale As Boolean = True
        Dim respuesta As MsgBoxResult
        If Me.txtNombreCurso.Text <> modu.Nombre Then
            respuesta = MsgBox(String.Format("Está cambiando el nombre del Modulo de'{0}' a '{1}'" & vbCrLf &
                                                 "¿Quiere continuar con este cambio?", modu.Nombre, Me.txtNombreCurso.Text), MsgBoxStyle.YesNo)
            If respuesta = MsgBoxResult.No Then Return False
        End If
        If Me.txtHorasCurso.Text <> CStr(modu.horas) Then
            respuesta = MsgBox(String.Format("Está cambiando el numero de horas del curso de del Modulo de'{0}' a '{1}'" & vbCrLf &
                                                "¿Quiere continuar con este cambio?", CStr(modu.horas), Me.txtHorasCurso.Text), MsgBoxStyle.YesNo)
            If respuesta = MsgBoxResult.No Then Return False
        End If
        Return True
    End Function
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class