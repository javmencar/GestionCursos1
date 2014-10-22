Imports System.Data.SqlClient
Public Class FrmModificarCursos
    Dim pos As Integer
    Dim sqlcn, cn As SqlConnection
    Dim c1 As Curso

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
    Sub New(ByVal cu As Curso)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        c1 = cu
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
   
    Private Sub FrmModificarCursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '#ESTE LOAD ES PARA CUANDO ME PASAN EL OBJETO CURSO COMPLETO
        sqlcn = New SqlConnection(ConeStr)
        Try
            'hay que modificar textos de los botones segun de donde venga

            'el curso es nuevo
            If pos = -1 Then
                Me.cmdModificar.Text = "crear el curso"
                Me.cmdCancelar.Text = "cancelar la creacion"
                Call cargarComboModulos()

                'el curso ya existe
            Else
                Me.cmdModificar.Text = "modificar este curso"
                Me.cmdCancelar.Text = "cancelar la modificacion"
                Call cargarComboModulos()
                Call cargarformulario()
                'además al ser modificacion, bloqueo el código para que no se pueda tocar
                Me.txtCodcur.Enabled = False
            End If
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        End Try
    End Sub
    'Sub cargarformulario(ByVal idCur As Integer)
    '    cn = New SqlConnection(ConeStr)
    '    Try
    '        cn.Open()
    '        Dim sql As String = "select cursos.codcur, cursos.nombre, cursos.horas " &
    '                           " from cursos where cursos.id=" & idCur

    '        ' MsgBox(sql)
    '        Dim cmd As New SqlCommand(sql, cn)
    '        Dim dr As SqlDataReader
    '        dr = cmd.ExecuteReader
    '        dr.Read()

    '        If Not (dr.HasRows) Then Throw New miExcepcion("No hay registros con ese id", 56, Me.Name.ToString)
    '        Me.txtCodcur.Text = dr(0).ToString
    '        Me.txtNombreCurso.Text = dr(1).ToString
    '        Me.txtHorasCurso.Text = dr(2).ToString
    '        cn.Close()

    '        Call cargarListBox(idCur)
    '    Catch ex As miExcepcion
    '        MsgBox(ex.ToString)
    '    Catch ex2 As Exception
    '        MsgBox(ex2.ToString)
    '    End Try
    'End Sub
    Sub cargarformulario()
        Me.LstModulos.Items.Clear()
        Me.txtCodcur.Text = c1.CodCur.ToString
        Me.txtNombreCurso.Text = c1.Nombre.ToString
        Me.txtHorasCurso.Text = c1.horas.ToString
        If Not IsNothing(c1.modulos) Then
            c1.ordenarModulos()
            For Each m As Modulo In c1.modulos
                If m.Id > 0 AndAlso m.Id < 10 Then
                    Me.LstModulos.Items.Add("0" & m.Id.ToString & "_" & m.Nombre.ToString)
                Else
                    Me.LstModulos.Items.Add(m.Id.ToString & "_" & m.Nombre.ToString)
                End If

            Next
        End If
    End Sub
    Public Sub cargarListBox(ByVal i As Integer)
        'hay que comprobar si se puede cargar aqui dede objeto
        cn = New SqlConnection(ConeStr)
        Try
            Me.LstModulos.Items.Clear()
            cn.Open()
            Dim sql As String = "SELECT Modulos.Id, Modulos.Nombre" &
                " FROM modulos, Cursos_Modulos" &
                " WHERE Cursos_Modulos.IdMod = modulos.Id And Cursos_Modulos.Idcur =" & i &
                " ORDER BY Modulos.id ASC"
            '   MsgBox(sql)
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            ' If Not (dr.HasRows) Then Throw New miExcepcion("No hay modulos a mostrar", 83, Me.Name.ToString)
            Do While dr.Read
                If dr(0) > 0 AndAlso dr(0) < 10 Then
                    Me.LstModulos.Items.Add("0" & dr(0) & "_" & dr(1))
                End If
                Me.LstModulos.Items.Add(dr(0) & "_" & dr(1))
            Loop
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        Finally
            cn.Close()
        End Try
    End Sub
    Sub cargarComboModulos()
        cn = New SqlConnection(ConeStr)
        Try
            Me.CboModulos.Items.Clear()
            cn.Open()
            Dim sql As String = "select modulos.id, modulos.nombre from  modulos order by modulos.id asc"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            Dim i As Integer = 0
            dr = cmd.ExecuteReader
            Do While dr.Read
                i += 1
                Me.CboModulos.Items.Add(dr(0) & "_" & dr(1))
            Loop
        Catch ex As Exception
            MsgBox(ex)
        Finally
            cn.Close()
        End Try
    End Sub
  
    Private Sub ordenarelListbox(ByVal lst As ListBox)
        Dim arr As New ArrayList
        For Each ite As String In lst.Items
            arr.Add(ite)
        Next
        Me.LstModulos.Items.Clear()
        arr.Sort()
        For Each ite As String In arr
            lst.Items.Add(ite.ToString)
        Next
    End Sub
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        '# VALE IGUAL PARA MODIFICAR QUE PARA CREAR

        Try
            'CREAMOS UN CURSO NUEVO
            If IsNothing(c1) Then
                'Primero comprobamos si el código es correcto 
                Dim preguntaCodigo As MsgBoxResult
                preguntaCodigo = MsgBox("¿Seguro que el código es correcto?" & vbCrLf &
                                        "Una vez creado el curso, no se podrá cambiar", MsgBoxStyle.YesNo)
                If preguntaCodigo = MsgBoxResult.No Then

                    'paralizamos la creacion
                    Me.DialogResult = Windows.Forms.DialogResult.None
                    Throw New miExcepcion("Creacion cancelada a instancia del usuario")
                Else
                    'seguimos adelante:Comprobamos si el código ya está
                    Dim codrep, nomrep As Boolean
                    codrep = valorRepetido(Me.txtCodcur.Text, "SELECT Cursos.codcur from Cursos")
                    If codrep = True Then Throw New miExcepcion("El código ya está en uso en otro Curso")
                    nomrep = valorRepetido(Me.txtNombreCurso.Text, "SELECT Cursos.nombre from Cursos")
                    If nomrep = True Then Throw New miExcepcion("El nombre ya está en uso en otro Curso")
                    'si todo va bien seguimos
                    Dim NumReg As Integer = crearCurso()
                    If NumReg = -1 Then Throw New miExcepcion("Error al crear el curso", 146, Me.Name.ToString)
                    'antes de meter los modulos, ordenamos el listbox
                    Call ordenarelListbox(Me.LstModulos)
                    ' si hay modulos, metemos los modulos
                    If Me.LstModulos.Items.Count > 0 Then
                        Dim ultcur As Integer = averiguarUltimoIndice("Cursos")
                        Dim ListaDeModuloEnListbox As New List(Of Integer)
                        '   y vuelco en el array los id modulos, que saco con una funcion 
                        ListaDeModuloEnListbox = localizarIdModulosEnListbox()
                        '   recorro el array de idmodulos
                        For Each indMod As Integer In ListaDeModuloEnListbox
                            Call añadirModulosAlCurso(ultcur, indMod)
                        Next
                    End If
                    MsgBox("Curso creado con exito" & vbCrLf & "aviso1")
                    'volvemos a cursos
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                ' MODIFICAMOS UN CURSO EXISTENTE
                ' he bloqueado el código para que no se pueda cambiar, al menos desde aquí
                Dim cambioHoras, cambioNombre, nomrep As Boolean
                'comprobamos si queremos seguro el nuevo nombre
                cambioNombre = QuieroCambiosEnCampos(c1.Nombre, " como nombre de curso ", Me.txtNombreCurso.Text)
                'comprobamos si queremos seguro las nuevas horas
                cambioHoras = QuieroCambiosEnCampos(c1.horas.ToString, " horas en el curso ", Me.txtHorasCurso.Text)
                nomrep = valorRepetido(Me.txtNombreCurso.Text, "SELECT Cursos.nombre from Cursos")
                If nomrep = True AndAlso Me.txtNombreCurso.Text <> c1.Nombre Then Throw New miExcepcion("El nombre ya está en uso en otro Curso")
                'ordenamos el listbox
                Call ordenarelListbox(Me.LstModulos)
                Call ModificarCurso()
                'MsgBox("Curso Modificado con exito" & vbCrLf & "aviso1")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

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
    Friend Function valorRepetido(ByVal val As String, consulta As String) As Boolean
        ' por ahora solo string
        cn = New SqlConnection(ConeStr)
        Try
            cn.Open()
            Dim sql As String = consulta
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            'If Not (dr.HasRows) Then Throw New miExcepcion("no hay valores para comparar")
            Do While dr.Read
                'si el nombre es el mismo, pero la id es distinta, el nombre ya está en uso
                If dr(0) = val Then Return True
            Loop
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
        Return False
    End Function
    Private Function crearCurso() As Integer
        Dim id As Integer = 0
        cn = New SqlConnection(ConeStr)
        Try
            ' abro la conexion y hago la consulta de ejecucion
            cn.Open()
            ' me guardo los valores en una string para facilitar la insercion
            ' no pongo el id, porque ahora es autoincremental
            Dim valores As String = "('" & Me.txtCodcur.Text & "', '" &
                Me.txtNombreCurso.Text & "', " & CInt(Me.txtHorasCurso.Text) & ")"
            ' MsgBox(valores)
            Dim sql2 As String
            sql2 = "INSERT INTO cursos (cursos.codcur, cursos.nombre, cursos.horas) VALUES " & valores
            'MsgBox(sql2)
            Dim cmd2 As New SqlCommand(sql2, cn)
            Dim i2 As Integer = cmd2.ExecuteNonQuery
            If i2 < 0 Then Throw New miExcepcion("el cmd.ExecuteNonQuery devuelve menos de 0 lineas afectadas", 219, Me.Name.ToString)
            If i2 <= 0 Then Throw New miExcepcion("el cmd.ExecuteNonQuery devuelve 0 lineas afectadas", 219, Me.Name.ToString)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            'consulto el ultimo indice y lo devuelvo
            id = averiguarUltimoIndice("Cursos")
        Catch ex2 As miExcepcion
            id = -1
            MsgBox(ex2.ToString)
        Catch ex As Exception
            id = -1
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
        Return id
    End Function

    Private Sub cmdAñadirModulo_Click(sender As Object, e As EventArgs) Handles cmdAñadirModulo.Click
        Try
            '   si no hay nada seleccionado en el combo lo aviso
            If Me.CboModulos.SelectedIndex = -1 Then Throw New miExcepcion("seleccione un modulo del menu desplegable para añadirlo")
           
            ' si hay algo seleccionado del combo, añado el nombre del modulo al listbox
            '   Antes comprobaré si está ya o no
            If Me.LstModulos.Items.Count = 0 Then
                'si no hay nada en el listbox, lo añado directamente
                Me.LstModulos.Items.Add(Me.CboModulos.SelectedItem.ToString)
            Else
                'si hay algo en el listbox, comprobar
                Dim aux(2) As String
                aux = Split(Me.CboModulos.SelectedItem.ToString, "_")
                Dim listaModulos As List(Of Integer)
                listaModulos = localizarIdModulosEnListbox()
                Dim repe As Boolean = repetidos(aux(0), listaModulos)
                If repe = True Then Throw New miExcepcion("ese modulo ya está en la lista")
                Me.LstModulos.Items.Add(Me.CboModulos.SelectedItem)
            End If
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'limpio el itm seleccionado del combo
            Me.CboModulos.SelectedItem = Nothing
          
        End Try

    End Sub
    Private Function repetidos(ByVal p1 As Integer, ByVal ls1 As List(Of Integer)) As Boolean
        For Each it As Integer In ls1
            If it = p1 Then Return True
        Next
        Return False
    End Function
    Private Sub ModificarCurso(id)
        cn = New SqlConnection(ConeStr)
        Try
            Dim sql2 As String
            sql2 = "UPDATE Cursos SET cursos.codcur='" & Me.txtCodcur.Text &
                "', cursos.nombre='" & Me.txtNombreCurso.Text &
                "', cursos.horas=" & CInt(Me.txtHorasCurso.Text) &
                " where cursos.id=" & id
            ' MsgBox(sql2)
            cn.Open()
            Dim cmd As New SqlCommand(sql2, cn)
            Dim i As Integer = cmd.ExecuteNonQuery
            cn.Close()
            'una vez modificado el curso, le añado los posibles modulos
            '   Primero me cepillo los que hay
            Call CepillarmeLosModulos(id)
            '   luego los vuelco otra vez
            Dim ModulosEnElListbox As List(Of Integer)
            '   y vuelco en el array los id modulos, que saco con una funcion 
            ModulosEnElListbox = localizarIdModulosEnListbox()
            '   recorro el array de idmodulos
            For Each indMod As Integer In ModulosEnElListbox
                '   y los añado uno por uno
                Call añadirModulosAlCurso(pos, indMod)
            Next
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        Finally

        End Try

    End Sub
    Private Sub ModificarCurso()
        cn = New SqlConnection(ConeStr)
        Try
            Dim sql2 As String
            sql2 = "UPDATE Cursos SET cursos.codcur='" & Me.txtCodcur.Text &
                "', cursos.nombre='" & Me.txtNombreCurso.Text &
                "', cursos.horas=" & CInt(Me.txtHorasCurso.Text) &
                " where cursos.id=" & c1.Id
            ' MsgBox(sql2)
            cn.Open()
            Dim cmd As New SqlCommand(sql2, cn)
            Dim i As Integer = cmd.ExecuteNonQuery
            cn.Close()
            'Una vez hecha la insercion, vuelco los datos en el objeto, para que esté actualizado
            c1.CodCur = Me.txtCodcur.Text
            c1.Nombre = Me.txtNombreCurso.Text
            c1.horas = CInt(Me.txtHorasCurso.Text)
            'una vez modificado el curso, le añado los posibles modulos
            '   Primero me cepillo los que hay
            Call CepillarmeLosModulos(c1.Id)
            c1.modulos.Clear()
            '   luego los vuelco otra vez
            Dim ModulosEnElListbox As List(Of Integer)
            '   y vuelco en el array los id modulos, que saco con una funcion 
            ModulosEnElListbox = localizarIdModulosEnListbox()
            '   recorro el array de idmodulos
            For Each indMod As Integer In ModulosEnElListbox
                '   y los añado uno por uno, primero a la base de datos
                Call añadirModulosAlCurso(c1.Id, indMod)
                'y luego al objeto
                c1.añadirModulos(CargarModulo(indMod))
            Next
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        Finally

        End Try
    End Sub
    

    Private Sub cmdNuevoModulo_Click(sender As Object, e As EventArgs) Handles cmdNuevoModulo.Click
        Dim i As Integer = -1
        Dim frm As New FrmModificarModulos(i)
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'si se ha creado correctamente el modulo, vuelvo a cargar el combo
            Call cargarComboModulos()
            'cojo el ultimo elemento del combo y lo añado al listbox
            Me.LstModulos.Items.Add(Me.CboModulos.Items.Item(Me.CboModulos.Items.Count - 1).ToString)
            ' y ordeno el listbox

        Else
            Throw New miExcepcion("Error al crear el modulo", 329, Me.Name.ToString)
        End If
        pos = 0
    End Sub
    Friend Function localizarIdModulosEnListbox() As List(Of Integer)
        Dim list As New List(Of Integer)
        Dim aux(2) As String
        'recorro todo el listbox
        For Each item As String In Me.LstModulos.Items
            'divido las filas para sacar el id de los modulos(la primera parte del string del listbox)
            aux = Split(item.ToString, "_")
            list.Add(CInt(aux(0)))
        Next
        Return list
    End Function
    Friend Function averiguarUltimoIndice(ByVal t As String) As Integer
        cn = New SqlConnection(ConeStr)
        Dim i As Integer = 0
        Try
            ' Dim sql As String = "select count(*) from " & t
            Dim sql As String = "select top 1 id from " & t & " order by id desc"
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            i = cmd.ExecuteScalar
            cn.Close()
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return i
    End Function
    Private Sub cmdQuitarModListbox_Click(sender As Object, e As EventArgs) Handles cmdQuitarModListbox.Click
        If Me.LstModulos.SelectedIndex = -1 Then
            MsgBox("seleccione el modulo del listado que desee borrar")
        Else
            'borro el nombre
            Me.LstModulos.Items.RemoveAt(Me.LstModulos.SelectedIndex)
            MsgBox("Modulo retirado del listado")
            ' y ordeno el listbox

        End If

    End Sub
    Friend Sub añadirModulosAlCurso(ByVal ic As Integer, im As Integer)
        cn = New SqlConnection(ConeStr)
        Try
            Dim sql As String
            sql = "INSERT INTO Cursos_Modulos(Cursos_Modulos.Idcur, Cursos_Modulos.IdMod)" & _
                "VALUES(" & ic & ", " & im & ")"
            'MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim i2 As Integer = cmd.ExecuteNonQuery
            If i2 = 0 Then Throw New miExcepcion("error al insertar el modulo", 381, Me.Name.ToString)
            ' MsgBox("modulo insertado con exito")
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        Finally
            cn.Close()
        End Try
    End Sub
    Friend Function CargarModulo(im As Integer) As Modulo
        Dim m As New Modulo
        cn = New SqlConnection(ConeStr)
        Try
            cn.Open()
            Dim sql As String = "select modulos.Id, modulos.Nombre, Modulos.Horas from Modulos where modulos.Id=" & im
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                m.Id = dr(0)
                m.Nombre = dr(1)
                m.horas = dr(2)
            End If
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        Finally
            cn.Close()
        End Try
        Return m
    End Function
    Friend Function determinaridcurso(ByVal cod As String) As Integer
        Dim i As Integer = 0
        cn = New SqlConnection(ConeStr)
        Try
            Dim sql As String = "select Cursos.id from cursos where cursos.CodCur='" & cod & "'"
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            i = cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
        Return i
    End Function
    Friend Sub CepillarmeLosModulos(ByVal ident As Integer)
        cn = New SqlConnection(ConeStr)
        Dim i As Integer = 0
        Try
            Dim sql As String = "delete from Cursos_Modulos where Cursos_Modulos.Idcur=" & ident
            cn.Open()
            ' MsgBox(sql)
            Dim cmd As New SqlCommand(sql, cn)
            i = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

  
End Class