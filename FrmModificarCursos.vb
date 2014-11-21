Imports System.Data.SqlClient
Public Class FrmModificarCursos
    Dim pos As Integer
    Dim sqlcn, cn As SqlConnection
    Dim c1 As Curso
    Dim nuevo As Boolean
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    'Sub New(ByVal id As Integer)
    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()
    '    pos = id
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    'End Sub
    Sub New(ByVal nue As Boolean, Optional ByVal cu As Curso = Nothing)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        nuevo = nue
        c1 = cu
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    'Sub New(ByVal cu As Curso)
    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()
    '    c1 = cu
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    'End Sub

    Private Sub FrmModificarCursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '#ESTE LOAD ES PARA CUANDO ME PASAN EL OBJETO CURSO COMPLETO
        sqlcn = New SqlConnection(ConeStr)
        Try
            'hay que modificar textos de los botones segun de donde venga
            If nuevo = True Then  'el curso es nuevo
                Me.cmdModificar.Text = "crear el curso"
                Me.cmdCancelar.Text = "cancelar la creacion"
            Else  'el curso ya existe
                Me.cmdModificar.Text = "modificar este curso"
                Me.cmdCancelar.Text = "cancelar la modificacion"
                If IsNothing(c1) Then Throw New miExcepcion("Error al cargar formulario. Por favor vuelva al formulario anterior")
                Call cargarformulario()
                ' al ser modificacion, bloqueo el código para que no se pueda tocar
                Me.txtCodcur.Enabled = False
            End If
            Call cargarComboModulos()
        Catch ex As miExcepcion
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            MsgBox(ex2.ToString)
        End Try
    End Sub  
    Sub cargarformulario()
        Me.LstModulos.Items.Clear()
        Me.txtCodcur.Text = c1.CodCur.ToString
        Me.txtNombreCurso.Text = c1.Nombre.ToString
        Me.txtHorasCurso.Text = c1.horas.ToString
        If Not IsNothing(c1.modulos) Then
            For Each m As Modulo In c1.modulos
                If m.Id > 0 AndAlso m.Id < 10 Then
                    Me.LstModulos.Items.Add(String.Format("0{0}_{1}", m.Id.ToString, m.Nombre))
                Else
                    Me.LstModulos.Items.Add(String.Format("{0}_{1}", m.Id.ToString, m.Nombre))
                End If
            Next
            Me.LstModulos.Sorted = True
        End If
    End Sub
    Sub cargarComboModulos()
        cn = New SqlConnection(ConeStr)
        Try
            Me.CboModulos.Items.Clear()
            cn.Open()
            Dim sql As String = "SELECT Modulos.Id, Modulos.Nombre FROM  Modulos ORDER BY Modulos.Id ASC"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            Dim i As Integer = 0
            dr = cmd.ExecuteReader
            Do While dr.Read
                i += 1
                Me.CboModulos.Items.Add((String.Format("{0}_{1}", dr(0), dr(1))))
            Loop
            ''asi se ordenan
            'Me.CboModulos.Sorted = True
        Catch ex As Exception
            MsgBox(ex)
        Finally
            cn.Close()
        End Try
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
                    Me.LstModulos.Sorted = True
                    ' si hay modulos, metemos los modulos
                    If Me.LstModulos.Items.Count > 0 Then
                        'Dim ultcur As Integer = averiguarUltimoIndice("Cursos")

                        Dim ListaDeModuloEnListbox As New List(Of String)
                        '   y vuelco en el array los id modulos, que saco con una funcion 
                        ListaDeModuloEnListbox = localizarIdModulosEnListbox()
                        '   recorro el array de idmodulos
                        Dim modEnBD As Boolean
                        For Each indMod As String In ListaDeModuloEnListbox
                            modEnBD = añadirModulosAlCurso(CStr(NumReg), indMod)
                            If modEnBD = False Then Throw New miExcepcion("Error al insertar modulos")
                            modEnBD = False
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
                cambioNombre = QuieroCambiosEnCampos(c1.Nombre.ToString, " como nombre de curso ", Me.txtNombreCurso.Text)

                'comprobamos si queremos seguro las nuevas horas
                cambioHoras = QuieroCambiosEnCampos(c1.horas.ToString, " horas en el curso ", Me.txtHorasCurso.Text)
                nomrep = valorRepetido(Me.txtNombreCurso.Text, "SELECT Cursos.Nombre FROM Cursos")
                If nomrep = True AndAlso Me.txtNombreCurso.Text <> c1.Nombre Then Throw New miExcepcion("El nombre ya está en uso en otro Curso")
                'ordenamos el listbox
                Me.LstModulos.Sorted = True
                Dim modificado As Boolean
                modificado = ModificarCurso()
                If modificado = False Then Throw New miExcepcion("error al modificar")
                'MsgBox("Curso Modificado con exito" & vbCrLf & "aviso1")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex2 As miExcepcion
            'Me.DialogResult = Windows.Forms.DialogResult.Cancel
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Friend Function QuieroCambiosEnCampos(ByVal t1 As String, ByVal t2 As String, ByVal t3 As String) As Boolean
        ' Dim respuesta As MsgBoxResult
        '   t1 es nombre viejo, t2 es el campo a cambiar y t3 es nombre nuevo
        Dim respuesta As MsgBoxResult = MsgBox(String.Format("Está cambiando de '{0}' {1} a '{2}'" & vbCrLf &
                                "¿Es correcto?", t1, t2, t3), MsgBoxStyle.YesNo)
        If respuesta = MsgBoxResult.Yes Then Return True
        If respuesta = MsgBoxResult.No Then Throw New miExcepcion("Modificacion cancelada a peticion del usuario")
        Return False
    End Function
    Private Function valorRepetido(ByVal val As String, consulta As String) As Boolean
        cn = New SqlConnection(ConeStr)
        Try
            cn.Open()
            Dim sql As String = consulta
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Do While dr.Read
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
            Dim sql2 As String
            sql2 = String.Format("INSERT INTO Cursos (Cursos.CodCur,Cursos.Nombre, Cursos.Horas) VALUES ('{0}', '{1}', {2})",
                                Me.txtCodcur.Text, Me.txtNombreCurso.Text, CInt(Me.txtHorasCurso.Text))
            MsgBox(sql2)
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
                Dim listaModulos As List(Of String)
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
    Private Function repetidos(ByVal s As String, ByVal lst As List(Of String)) As Boolean
        For Each it As String In lst
            If it = s Then Return True
        Next
        Return False
    End Function
    Private Function ModificarCurso() As Boolean
        cn = New SqlConnection(ConeStr)
        Try
            Dim insercionHecha As Boolean = modif()
            If insercionHecha = False Then Throw New miExcepcion
            'Una vez hecha la insercion, vuelco los datos en el objeto, para que esté actualizado
            c1.CodCur = Me.txtCodcur.Text
            c1.Nombre = Me.txtNombreCurso.Text
            c1.horas = CInt(Me.txtHorasCurso.Text)
            'una vez modificado el curso, le añado los posibles modulos
            '   Primero me cepillo los que hay
            Call CepillarmeLosModulos(c1.Id)
            If Not IsNothing(c1.modulos) Then c1.modulos.Clear()
            '   luego los vuelco otra vez
            Dim ModulosEnElListbox As List(Of String)
            '   y vuelco en el array los id modulos, que saco con una funcion 
            ModulosEnElListbox = localizarIdModulosEnListbox()
            '   recorro el array de idmodulos
            Dim modEnBD As Boolean
            For Each indMod As String In ModulosEnElListbox
                '   y los añado uno por uno, primero a la base de datos
                modEnBD = añadirModulosAlCurso(CStr(c1.Id), indMod)
                If modEnBD = False Then Throw New miExcepcion("Error al cargar los modulos")
                'y luego al objeto
                c1.añadirModulos(CargarModulo(indMod))
                'y reseteo la variable
                modEnBD = False
            Next
            c1.ordenarModulos()
        Catch ex2 As miExcepcion
            Return False
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        Finally
            cn.Close()
        End Try
        Return True
    End Function
    Private Function modif() As Boolean
        Try
            Dim sql2 As String
            sql2 = String.Format("UPDATE Cursos SET Cursos.CodCur='{0}', Cursos.Nombre='{1}',Cursos.Horas={2} WHERE Cursos.Id={3}",
                                 Me.txtCodcur.Text, Me.txtNombreCurso.Text, Me.txtHorasCurso.Text, c1.Id.ToString)
            ' MsgBox(sql2)
            cn.Open()
            Dim cmd As New SqlCommand(sql2, cn)
            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then Return True
        Catch ex As Exception
            cn.Close()
        End Try
        Return False
    End Function

    Private Sub cmdNuevoModulo_Click(sender As Object, e As EventArgs) Handles cmdNuevoModulo.Click
        'true es nuevo
        Dim frm As New FrmModificarModulos(True)
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
    Private Function localizarIdModulosEnListbox() As List(Of String)
        Dim list As New List(Of String)
        Dim aux(2) As String
        'recorro todo el listbox
        For Each item As String In Me.LstModulos.Items
            'divido las filas para sacar el id de los modulos(la primera parte del string del listbox)
            aux = Split(item.ToString, "_")
            list.Add(aux(0))
        Next
        Return list
    End Function
    Private Function averiguarUltimoIndice(ByVal t As String) As Integer
        cn = New SqlConnection(ConeStr)
        Dim i As Integer = 0
        Try
            ' Dim sql As String = "select count(*) from " & t
            Dim sql As String
            sql = String.Format("SELECT TOP 1 {0}.Id FROM {0} ORDER BY {0}.Id DESC", t)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            i = cmd.ExecuteScalar
            cn.Close()
        Catch ex2 As miExcepcion
            i = -1
            MsgBox(ex2.ToString)
        Catch ex As Exception
            i = -1
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
    Private Function añadirModulosAlCurso(ByVal ic As String, im As String) As Boolean
        cn = New SqlConnection(ConeStr)
        Try
            Dim sql As String
            sql = String.Format("INSERT INTO Cursos_Modulos(Cursos_Modulos.Idcur, Cursos_Modulos.IdMod) VALUES ({0}, {1})", ic, im)

            'MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim i2 As Integer = cmd.ExecuteNonQuery
            If i2 <= 0 Then Throw New miExcepcion("error al insertar el modulo", 381, Me.Name.ToString)
            ' MsgBox("modulo insertado con exito")
        Catch ex As miExcepcion
            Return False
            MsgBox(ex.ToString)
        Catch ex2 As Exception
            Return False
            MsgBox(ex2.ToString)
        Finally
            cn.Close()
        End Try
        Return True
    End Function
    Private Function CargarModulo(im As String) As Modulo
        Dim m As New Modulo
        cn = New SqlConnection(ConeStr)
        Try
            cn.Open()
            Dim sql As String '
            sql = String.Format("SELECT Modulos.ID, Modulos.Nombre,Modulos.Horas FROM Modulos WHERE Modulos.Id={0}", im)
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