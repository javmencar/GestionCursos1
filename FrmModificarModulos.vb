Imports System.Data.SqlClient

Public Class FrmModificarModulos
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal id As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        pos = id
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Dim pos As Integer
    Dim modu As Modulo
    Dim cn As SqlConnection

    Private Sub FrmModificarModulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Try
            'hay que modificar textos de los botones segun de donde venga
            If pos = -1 Then
                'curso nuevo, textos: "crear el curso" , "cancelar la creacion"
                Me.CmdModificar.Text = "crear el Modulo"
                Me.cmdCancelar.Text = "cancelar la creacion"
            Else
                'modificar: "modificar este curso" , "cancelar la modificacion"
                Me.CmdModificar.Text = "modificar este Modulo"
                Me.cmdCancelar.Text = "cancelar la modificacion"

                Call cargarformulario(pos)
                modu = New Modulo
                modu.Id = CInt(Me.txtlblModulos.Text)
                modu.Nombre = Me.txtNombreCurso.Text
                modu.horas = CInt(Me.txtHorasCurso.Text)
            End If
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        End Try
    End Sub
    Friend Sub cargarformulario(ByVal i As Integer)
        cn = New SqlConnection(ConeStr)
        Try
            cn.Open()
            ' MsgBox(cn.ToString)
            
            Dim sql As String = "select modulos.Id, modulos.Nombre, Modulos.Horas from modulos where modulos.id=" & i
            ' MsgBox(sql)
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader

            dr = cmd.ExecuteReader

            If Not (dr.Read()) Then
                Throw New miExcepcion("No hay modulos con esa id", 49, Me.Name.ToString)
            Else
               
                Me.txtlblModulos.Text = CStr(dr(0))
                Me.txtNombreCurso.Text = dr(1)
                Me.txtHorasCurso.Text = CStr(dr(2))
            End If
            cn.Close()
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CmdModificar_Click(sender As Object, e As EventArgs) Handles CmdModificar.Click
        Try
            Dim id As Integer = 0
            If pos = -1 Then
                'si es nuevo inserto nuevo registro
               
                Dim valores As String = "('" & Me.txtNombreCurso.Text & "', " & (CInt(Me.txtHorasCurso.Text)) & ")"
                ' INSERT INTO Modulos (Modulos.id, Modulos.Nombre, Modulos.Horas) VALUES (14,'PRUEBA_INSERCION',100)

                Dim sql As String = "INSERT INTO Modulos (Modulos.Nombre, Modulos.Horas) VALUES " & valores & ""
                ' MsgBox(sql)
                cn.Open()
                Dim cmd As New SqlCommand(sql, cn)
                Dim val As Integer = 0
                val = cmd.ExecuteNonQuery()
                If val > 0 Then
                    MsgBox("Modulo añadido")
                Else
                    Throw New miExcepcion("al introducir el registro. cmd.ExecuteNonQuery da <= 0", 72, Me.Name.ToString)
                End If
                cn.Close()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                'si viene con modulo selecionado, hay que alterar

                cn.Open()
                Dim cambio As Boolean = QuieroCambiosEnCampos(modu.Nombre.ToString, " como nombre de modulo ", Me.txtNombreCurso.Text)
                If cambio = False Then Throw New miExcepcion("modificacion cancelada a instancia del usuario")
                cambio = QuieroCambiosEnCampos(modu.horas.ToString, " horas en el modulo ", Me.txtHorasCurso.Text)
                If cambio = False Then Throw New miExcepcion("modificacion cancelada a instancia del usuario")
                'UPDATE Modulos SET  Modulos.Nombre='novisimo modulo' , Modulos.Horas=10 where Modulos.id=15

                Dim sql As String = "UPDATE Modulos SET Modulos.Nombre='" _
                                    & Me.txtNombreCurso.Text & "' , Modulos.Horas=" _
                                    & CInt(Me.txtHorasCurso.Text) & " where Modulos.id=" _
                                    & modu.Id
                MsgBox(sql)
                Dim cmd As New SqlCommand(sql, cn)
                Dim val As Integer = 0
                val = cmd.ExecuteNonQuery()
                If val <= 0 Then Throw New miExcepcion("al modificar el registro", 91, Me.ToString)
                MsgBox("Modulo añadido")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        Finally
            cn.Close()
        End Try
    End Sub
    Friend Function QuieroCambiosEnCampos(ByVal t1 As String, ByVal t2 As String, ByVal t3 As String) As Boolean
        Dim respuesta As MsgBoxResult
        '   t1 es nombre viejo, t3 es nombre nuevo, t2 es el campo a cambiar
        respuesta = MsgBox("Esta cambiando de:" & vbCrLf & "'" & t1 & "' " & vbCrLf & t2 &
                           " a " & vbCrLf & "'" & t3 & "' " & vbCrLf & t2 & vbCrLf & "¿Es correcto?", MsgBoxStyle.YesNo)
        If respuesta = MsgBoxResult.Yes Then Return True
        Return False
    End Function
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class