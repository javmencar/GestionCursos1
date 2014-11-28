'Este es el original
Imports System.Data.SqlClient
Public Class FrmFichas
    Dim nuevo, fotoCambiada As Boolean
    Public DP As DatosPersonales
    Public cat As String
    Public cn As SqlConnection
    Dim NuIdDP As Integer

    Sub New(ByVal Da As DatosPersonales, ByVal tipo As Integer, ByVal nw As Boolean)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        nuevo = nw
        DP = Da
        Select Case tipo
            Case 1
                cat = "Alumnos"
            Case 2
                cat = "Profesores"
            Case 3
                cat = "Candidatos"
        End Select
    End Sub

    Private Sub FrmFichas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Me.txtId.Enabled = False
        Me.LstExpSector.Items.Clear()
        Me.CboExpSector.SelectedIndex = -1
        Me.LstExpSector.Enabled = True
        NuIdDP = -1
        Me.cmdAñadirAAlumnos.Visible = False
        If nuevo = True Then
            DP = New DatosPersonales
            Me.cmdModificar.Text = "CREAR NUEVA FICHA"
            Me.cmdCancelar.Text = "Cancelar La Creación"
            Me.cmdCambiarFoto.Text = "Insertar Foto"
            Me.PicBx1.Image = Image.FromFile("C:\GIT\GestionCursos1\Resources\female-silhouette_0.jpg")
            Me.PicBx1.Tag = "C:\GIT\GestionCursos1\Resources\female-silhouette_0.jpg"
            ' NuIdDP = cogerUltimaId() + 1
            ' MsgBox("UltimaID + 1=  " & NuIdDP)
            Me.OptAptoPendiente.Select()
        Else
            Me.cmdModificar.Text = "MODIFICAR FICHA"
            Me.cmdCancelar.Text = "Cancelar La Modificación"
            Me.cmdCambiarFoto.Text = "Cambiar Foto"
            Me.cmdBorrar.Visible = True
            Me.cmdBorrar.Enabled = True
            Call rellenarCamposDesdeObjeto(DP)
        End If
    End Sub

    Private Sub rellenarCamposDesdeObjeto(ByVal Datos As DatosPersonales)
        With Datos
            Me.txtId.Text = CStr(.Id)
            Me.txtApellido1.Text = .Apellido1
            Me.txtApellido2.Text = .Apellido2
            Me.txtNombre.Text = .Nombre
            Me.txtDNI.Text = .DNI
            Me.txtNumSS.Text = .NumSS
            If .Fnac <> "1/1/1900" Then
                Me.txtFNac.Text = .Fnac
            Else
                Me.txtFNac.Text = ""
            End If
            ' Me.txtFNac.Text = CStr(.FecEntr)
            Me.txtLugNac.Text = .LugNac
            Me.txtEdad.Text = CStr(.Edad)
            Me.txtTel1.Text = .Tel1
            Me.txtTel2.Text = .Tel2
            Me.txtDomicilio.Text = .Domicilio
            Me.txtCP.Text = .CP
            Me.txtPoblacion.Text = .Poblacion
            If .InInaem = True Then
                Me.optInaemSi.Select()
            Else
                Me.OptInaemNo.Select()
            End If
            If .InFecha <> "1/1/1900" Then
                Me.txtInFecha.Text = .InFecha
            Else
                Me.txtInFecha.Text = ""
            End If
            ' Me.txtInFecha.Text = CStr(.InFecha)
            Me.txtNivelEstudios.Text = .NivelEstudios
            'hago una matriz con la string de experiencia y la vuelco en el listbox
            'controlo si hay algo en el string
            Me.LstExpSector.Items.Clear()
            If Not IsNothing(.ExpSector) Then
                Dim sectores() As String = .ExpSector.Split("/")
                For Each s As String In sectores
                    Me.LstExpSector.Items.Add(s)
                Next
            End If
            Me.CboTallaCamiseta.SelectedItem = .TallaCamiseta
            Me.CboTallaPantalon.SelectedItem = .TallaPantalon
            Me.txtTallaCalzado.Text = CStr(.TallaZapato)
            Me.txtEntrevistador.Text = .Entrevistador
            If .FecEntr <> "1/1/1900" Then
                Me.txtFecEntr.Text = .InFecha
            Else
                Me.txtFecEntr.Text = ""
            End If
            ' Me.txtFecEntr.Text = CStr(.FecEntr)
            Me.txtValoracion.Text = .Valoracion
            If Not IsNothing(.Apto) Then
                Dim esta As Boolean
                Select Case .Apto
                    Case "Apto"
                        Me.optAptoSi.Select()
                        Me.cmdAñadirAAlumnos.Visible = True
                        If nuevo = True Then
                            Me.cmdAñadirAAlumnos.Enabled = True
                        Else
                            If cat = "Alumnos" Or cat = "Profesores" Then
                                esta = EstaEnTablas(.Id)
                                If esta = False Then Me.cmdAñadirAAlumnos.Enabled = True
                            End If
                        End If
                    Case "No Apto"
                        Me.OptAptoNo.Select()
                    Case "Pendiente"
                        Me.OptAptoPendiente.Select()
                        Me.cmdAñadirAAlumnos.Visible = True
                        Me.cmdAñadirAAlumnos.Enabled = False
                End Select
            Else
                Me.OptAptoPendiente.Select()
            End If
            If Not IsNothing(.PathFoto) Then
                Me.PicBx1.ImageLocation = .PathFoto
                Me.PicBx1.Show()
                Me.PicBx1.Tag = .PathFoto
            Else
                Me.PicBx1.Image = Image.FromFile("C:\GIT\GestionCursos1\Resources\female-silhouette_0.jpg")
                Me.PicBx1.Tag = "C:\GIT\GestionCursos1\Resources\female-silhouette_0.jpg"
            End If
        End With
    End Sub

    Private Function EstaEnTablas(ByVal i As String) As Boolean
        Try
            Dim sql As String = String.Format("SELECT {0}.Id FROM DatosPersonales, {0} " &
                                              "WHERE DatosPersonales.Id={0}.IdDP AND DatosPersonales.Id={1}", cat, i)
            Dim cmd As SqlCommand
            cn.Open()
            cmd = New SqlCommand(sql, cn)
            Dim j As Integer = cmd.ExecuteScalar
            If j > 0 Then Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Private Function rellenarObjetoDesdeCampos() As DatosPersonales
        Dim D1 As New DatosPersonales
        Try
            Dim reparador As String = ""
            With D1
                If Me.txtId.Text <> "" Then
                    .Id = Me.txtId.Text
                End If
                .Apellido1 = Me.txtApellido1.Text
                .Apellido2 = Me.txtApellido2.Text
                .Nombre = Me.txtNombre.Text
                .DNI = Me.txtDNI.Text
                .NumSS = Me.txtNumSS.Text.Replace("/", "")
                Dim err As Integer = 0
                err = comprobarformatofecha(Me.txtFNac.Text)
                If err <> 0 Then Throw New miExcepcion("error en fecha de nacimiento")
                .Fnac = Me.txtFNac.Text
                .LugNac = Me.txtLugNac.Text
                If Me.txtEdad.Text = "" Then Me.txtEdad.Text = "0"
                .Edad = CInt(Me.txtEdad.Text)
                reparador = Me.txtTel1.Text.Replace("-", "")
                .Tel1 = reparador
                reparador = Me.txtTel2.Text.Replace("-", "")
                .Tel2 = reparador
                .Domicilio = Me.txtDomicilio.Text
                .CP = Me.txtCP.Text
                .Poblacion = Me.txtPoblacion.Text
                If Me.optInaemSi.Checked = True Then
                    'ojo, la propiedad alumno.Ininaem es un string
                    .InInaem = "True"
                    err = comprobarformatofecha(Me.txtInFecha.Text)
                    If err <> 0 Then Throw New miExcepcion("error en fecha de inscripcion en el Inaem")
                    .InFecha = Me.txtInFecha.Text
                Else
                    .InInaem = "False"
                End If
                .NivelEstudios = Me.txtNivelEstudios.Text
                Dim expSect1 As String = ""
                If Me.LstExpSector.Items.Count > 0 Then
                    For Each l As String In Me.LstExpSector.Items
                        expSect1 &= String.Format("/{0}", l)
                    Next
                    expSect1 = expSect1.Substring(1)
                End If
                .ExpSector = expSect1
                If Me.CboTallaCamiseta.SelectedIndex <> -1 Then
                    .TallaCamiseta = Me.CboTallaCamiseta.SelectedItem.ToString
                End If
                If Me.CboTallaPantalon.SelectedIndex <> -1 Then
                    .TallaPantalon = Me.CboTallaPantalon.SelectedItem.ToString
                End If
                If Me.txtTallaCalzado.Text = "" Then Me.txtTallaCalzado.Text = "0"
                .TallaZapato = CInt(Me.txtTallaCalzado.Text)
                .Entrevistador = Me.txtEntrevistador.Text
                If Me.txtEntrevistador.Text <> "" Or Me.txtValoracion.Text <> "" Then
                    err = comprobarformatofecha(Me.txtFecEntr.Text)
                    If err <> 0 Then Throw New miExcepcion("error en fecha de entrevista")
                    .FecEntr = Me.txtFecEntr.Text
                End If
                .Valoracion = Me.txtValoracion.Text
                If Me.optAptoSi.Checked = True Then
                    .Apto = "Apto"
                ElseIf Me.OptAptoNo.Checked = True Then
                    .Apto = "No Apto"
                Else
                    .Apto = "Pendiente"
                End If
                .PathFoto = Me.PicBx1.Tag
                .cargarlistas() 'Llamo al procedimiento de la clase que carga listadoNombres y listavalores
            End With
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
            D1 = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
            D1 = Nothing
        End Try
        Return D1
    End Function

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Call ModificarOCrear()
    End Sub

    Private Sub ModificarOCrear()
        'Lo he metido en un sub  porque se repite todo en añadir a alumnos
        Try
            Dim DPConDatosDelFormulario As DatosPersonales
            Dim fallos As List(Of String)
            If nuevo = True Then
                fallos = camposvacios()
                'ademas de campos vacios , quiero que compruebe el DNI y el NumSS
                Dim comprobado As Boolean
                If Me.txtDNI.Text <> "" Then
                    comprobado = ValidaNif(Me.txtDNI.Text)
                    If comprobado = False Then
                        fallos.Add("El DNI introducido NO es válido.")
                    End If
                End If
                Dim numSSSinBarras As String = Me.txtNumSS.Text.Replace("/", "")
                If numSSSinBarras <> "" Then
                    comprobado = ValidaNumSS(numSSSinBarras)
                    If comprobado = False Then
                        fallos.Add("El Numero de la Seguridad Social NO es válido")
                    End If
                End If
                'Hasta aqui las validaciones del DNI y NumSS
                '########
            Else
                fallos = fallosEnCampos()
            End If
            If fallos.Count > 0 Then
                Dim respuesta As MsgBoxResult
                Dim recogefallos As String = ""
                For Each s As String In fallos
                    recogefallos &= String.Format(" '{0}'" & vbCrLf, s)
                Next
                respuesta = MsgBox("Está creando una ficha con estas incidencias: " & vbCrLf & recogefallos &
                            vbCrLf & "¿Seguro que desea seguir?", MsgBoxStyle.YesNo)
                If respuesta = MsgBoxResult.No Then
                    'vuelvo a cargar los datos originales
                    Call rellenarCamposDesdeObjeto(DP)
                    Throw New miExcepcion("Operación cancelada a peticion del usuario")
                End If
            End If
            'aceptado seguir con los fallos (o bien si no los había) continuamos
            DPConDatosDelFormulario = rellenarObjetoDesdeCampos()
            If Not IsNothing(DPConDatosDelFormulario) Then
                If nuevo = True Then ' creo una ficha, porque es nuevo
                    Dim cargado As Boolean = CrearNuevoDPEnBaseDeDatos(DPConDatosDelFormulario)
                    If cargado = False Then Throw New miExcepcion("Error al cargar la ficha")
                    ' Dim nuevaId As Integer = cogerUltimaId()
                    NuIdDP = cogerUltimaId()
                    If NuIdDP = -1 Then Throw New miExcepcion("Error al calcular la ultima ID")
                    If cat = "alumnos" Or cat = "Profesores then" Then '    los candidatos no necesitan esta parte
                        Dim comp As Integer = insertarEnTablacategoria(NuIdDP)
                        If comp = -1 Then Throw New miExcepcion(String.Format("Problema al insertar en {0}", cat))
                    End If
                Else
                    'cargo los datos del objeto ya creado
                    Dim cargado As Boolean = cargarCambiosEnDPYaCreado(DPConDatosDelFormulario)
                    If cargado = False Then Throw New miExcepcion("No se ha podido cargar la ficha")
                End If
            Else ' si no hay nada en el objeto es que ha habido error al crearlo
                If nuevo = True Then
                    Throw New miExcepcion("Cambie los campos necesarios para poder Crear la ficha" & vbCrLf &
                                          " o Pulse Salir")
                Else
                    Throw New miExcepcion("Cambie los campos necesarios para poder Modificar la ficha" & vbCrLf &
                                          " o Pulse Salir")
                End If
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
            Me.DialogResult = Windows.Forms.DialogResult.None
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.DialogResult = Windows.Forms.DialogResult.None
        End Try
    End Sub

    Private Function camposvacios() As List(Of String)
        Dim vacios As New List(Of String)
        If Me.txtNombre.Text = "" Then vacios.Add("El campo 'Nombre' está vacío")
        If Me.txtApellido1.Text = "" Then vacios.Add("El campo 'Primer Apellido'  está vacío")
        If Me.txtApellido2.Text = "" Then vacios.Add("El campo 'Segundo Apellido' está vacío")
        If Me.txtDNI.Text = "" Then vacios.Add("El campo 'DNI' está vacío")
        Dim numSSSinBarras As String
        numSSSinBarras = Me.txtNumSS.Text.Replace("/", "") '    Quito las barras para comprobar si el campo está vacío
        If numSSSinBarras = "" Then vacios.Add("El campo 'Numero de la seguridad Social' está vacío")
        'añadir o quitar los campos que queramos comprobar
        Return vacios
    End Function

    Private Function fallosEnCampos() As List(Of String)
        Dim comprobado As Boolean
        Dim cambios As New List(Of String)
        Dim numSSSinBarras As String = Me.txtNumSS.Text.Replace("/", "") '  Quito la barra para comprobar si el campo está vacío
        If DP.Nombre <> Me.txtNombre.Text Then cambios.Add(String.Format("El campo 'Nombre' va a ser cambiado de '{0}' a '{1}", DP.Nombre, Me.txtNombre.Text))
        If DP.Apellido1 <> Me.txtApellido1.Text Then cambios.Add(String.Format("El campo 'Primer Apellido' va a ser cambiado de '{0}' a '{1}", DP.Apellido1, Me.txtApellido1.Text))
        If DP.Apellido2 <> Me.txtApellido2.Text Then cambios.Add(String.Format("El campo 'Segundo Apellido' va a ser cambiado de '{0}' a '{1}", DP.Apellido2, Me.txtApellido2.Text))

        '   If DP.DNI <> Me.txtDNI.Text Then cambios.Add(String.Format("El campo 'DNI' va a ser cambiado de '{0}' a '{1}", DP.DNI, Me.txtDNI.Text))
        If DP.DNI <> Me.txtDNI.Text Then
            comprobado = ValidaNif(Me.txtDNI.Text)
            If comprobado = False Then
                cambios.Add("El DNI introducido no es válido.")
            Else
                cambios.Add(String.Format("El campo 'DNI' va a ser cambiado de '{0}' a '{1}", DP.DNI, Me.txtDNI.Text))
            End If
        End If
        '  If DP.NumSS <> numSSSinBarras Then cambios.Add(String.Format("El campo 'Numero de la Seguridad Social' va a ser cambiado de '{0}' a '{1}", DP.NumSS, Me.txtNumSS.Text))
        If DP.NumSS <> numSSSinBarras Then
            comprobado = ValidaNumSS(numSSSinBarras)
            If comprobado = False Then
                cambios.Add("El Numero de la Seguridad Social introducido no es válido.")
            Else
                cambios.Add(String.Format("El campo 'Numero de la Seguridad Social' va a ser cambiado de '{0}' a '{1}", DP.NumSS, Me.txtNumSS.Text))
            End If
        End If
        'añadir mas campos si queremos comprobarlos
        Return cambios
    End Function

    Public Function cargarCambiosEnDPYaCreado(ByVal dat As DatosPersonales) As Boolean
        Try
            Dim Datos As String = ""
            For i As Integer = 2 To 26 ' i=2 porque listavalores empieza en 1 y el primer valor no lo queremos
                If Not IsNothing(dat.listaValores.Item(i)) Then
                    Select Case i
                        Case 8, 21 'valores integer
                            Datos &= String.Format(", {0}={1}", dat.listadoNombres.Item(i - 1), dat.listaValores.Item(i))
                        Case 15  'valores boolean
                            If dat.listaValores.Item(i) = True Then
                                Datos &= String.Format(", {0}=1", dat.listadoNombres.Item(i - 1))
                            Else
                                Datos &= String.Format(", {0}=0", dat.listadoNombres.Item(i - 1))
                            End If
                        Case Else   'valores String (necesitamos ponerles comillas simples delante y detrás)
                            Datos &= String.Format(", {0}='{1}'", dat.listadoNombres.Item(i - 1), dat.listaValores.Item(i))
                    End Select
                End If
            Next
            '   le quito la primera coma
            Datos = Datos.Substring(1)
            Dim sql As String = String.Format("UPDATE DatosPersonales SET {0} Where DatosPersonales.Id={1}", Datos, CInt(dat.Id))
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim j As Integer = cmd.ExecuteNonQuery()
            '   No debería dar distinto de 1, porque solo debería afectar a un registro
            If j <> 1 Then Throw New miExcepcion("error en la insercion")
            MsgBox("Datos personales modificados en la base de datos")
        Catch ex2 As miExcepcion
            Return False
        Catch ex As Exception
            Return False
        Finally
            cn.Close()
        End Try
        Return True
    End Function

    Public Function CrearNuevoDPEnBaseDeDatos(ByVal Dat As DatosPersonales) As Boolean
        'INSERT INTO
        Try
            Dim tablas As String = ""
            Dim valores As String = ""
            For i As Integer = 2 To 26 ' i=2 porque listavalores empieza en 1 y el primer valor (Id)no lo queremos (es autoincremental)
                If Not IsNothing(Dat.listaValores.Item(i)) Then
                    Select Case i
                        Case 8, 21 'valores integer
                            tablas &= String.Format(", {0}", Dat.listadoNombres.Item(i - 1))
                            valores &= String.Format(", {0}", Dat.listaValores.Item(i))
                        Case 15  'valores boolean
                            tablas &= String.Format(", {0}", Dat.listadoNombres.Item(i - 1))
                            If Dat.listaValores.Item(i) = True Then
                                valores &= String.Format(", {0}", 1)
                            Else
                                valores &= String.Format(", {0}", 0)
                            End If
                        Case Else  'valores String (necesitamos ponerles comillas simples delante y detrás a los valores)
                            tablas &= String.Format(", {0}", Dat.listadoNombres.Item(i - 1))
                            valores &= String.Format(", '{0}'", Dat.listaValores.Item(i))
                    End Select
                End If
            Next
            'Le quito la primera coma y el primer espacio a las dos variables
            tablas = tablas.Substring(2)
            valores = valores.Substring(2)
            Dim sql As String = String.Format("INSERT INTO DatosPersonales ({0}) VALUES ({1})", tablas, valores)
            '  MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim j As Integer = cmd.ExecuteNonQuery()
            '   No debería dar distinto de 1, porque solo debería afectar a un registro
            If j <> 1 Then Throw New miExcepcion("error en la insercion")
            'recojo la nueva IdDP en la variable publica
            NuIdDP = cogerUltimaId()
            MsgBox("Datos personales introducidos en la base de datos")
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
            Return False
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        Finally
            cn.Close()
        End Try
        Return True
    End Function

    Public Function cambiarFormatoFecha(ByVal f As Date) As String
        Dim vieja, dias, meses, años As String
        vieja = f.ToString
        dias = vieja.Substring(0, 2)
        meses = vieja.Substring(3, 2)
        años = vieja.Substring(6, 4)
        Dim nueva As String = "'" & años & meses & dias & "'"
        Return nueva
    End Function

    Public Function comprobarformatofecha(ByVal s As String) As Integer
        Try
            Dim fechacorrecta As Date = DateTime.Parse(s)
        Catch ex1 As FormatException
            Return 1
        Catch ex2 As InvalidCastException
            Return 2
        Catch ex3 As ArgumentException
            Return 3
        Catch ex4 As Exception
            Return 4
        End Try
        Return 0
    End Function

    Private Sub cmdExperiencia_Click(sender As Object, e As EventArgs) Handles cmdExperiencia.Click
        If Me.CboExpSector.SelectedIndex = -1 Then
            MsgBox("seleccione un sector de experiencia laboral a añadir al listado")
        Else
            Dim repetido As Boolean = False
            For Each s As String In Me.LstExpSector.Items
                If s.ToString = Me.CboExpSector.SelectedItem.ToString Then
                    repetido = True
                    Exit For
                End If
            Next
            If repetido = False Then
                Me.LstExpSector.Items.Add(Me.CboExpSector.SelectedItem.ToString)
                '  MsgBox("Sector añadido al listado")
            Else
                MsgBox("Ese sector ya está elegido")
            End If
        End If
    End Sub

    Private Sub cmdQuitar_Click(sender As Object, e As EventArgs) Handles cmdQuitar.Click
        If Me.LstExpSector.SelectedIndex = -1 Then
            MsgBox("Seleccione del listado el sector que desse quitar")
        Else
            Me.LstExpSector.Items.RemoveAt(Me.LstExpSector.SelectedIndex)
            MsgBox("Sector eliminado del listado")
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Abort
    End Sub

    Public Function cogerUltimaId() As Integer
        Dim i As Integer = 0
        cn = New SqlConnection(ConeStr)
        Try
            cn.Open()
            Dim sql As String = "select top 1 DatosPersonales.id from DatosPersonales order by id desc"
            Dim cmd As New SqlCommand(sql, cn)
            i = cmd.ExecuteScalar
        Catch ex As Exception
            i = -1
        Finally
            cn.Close()
        End Try
        Return i
    End Function

    Public Function insertarEnTablacategoria(ByVal nid As Integer) As Integer
        Dim i As Integer
        cn = New SqlConnection(ConeStr)
        Try
            cn.Open()
            MsgBox(nid)
            Dim sql As String = String.Format("INSERT INTO {0} ({0}.idDP) VALUES ({1})", cat, nid)
            MsgBox(sql)
            Dim cmd As New SqlCommand(sql, cn)
            i = cmd.ExecuteNonQuery
        Catch ex As Exception
            i = -1
        Finally
            cn.Close()
        End Try
        Return i
    End Function

    Private Sub cmdCambiarFoto_Click(sender As Object, e As EventArgs) Handles cmdCambiarFoto.Click
        Call CambiarFoto()
    End Sub

    Private Sub cargarFotoEnFormulario(ByVal I As Integer)
        Try
            'Dim id As String = "22"
            Dim sql As String = String.Format("select FotoPath from DatosPersonales WHERE Id={0})", I)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim str As String = ""
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.Read Then
                Me.PicBx1.ImageLocation = dr(0)
                Me.PicBx1.Show()
                'Me.PicBx1.Load(str)
                Me.LblFoto.Tag = dr(1)
            Else
                Throw New miExcepcion("No hay foto cargada")
            End If
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PicBx1.DoubleClick
        Call CambiarFoto()
    End Sub

    Private Sub CambiarFoto()
        fotoCambiada = True
        ' PicBx1.Tag = ""
        If OFGSelectImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            PicBx1.Image = Image.FromFile(OFGSelectImage.FileName)
            Dim Path As String = ""
            'El Path lo deberé ajustar una vez sepa donde se guardarán los archivos del programa
            If nuevo = False Then
                'por ahora es en GIT,pero lo más seguro es que sea en S:\
                'Que es donde guardan las cosas en el servidor.
                Path = (String.Format("C:\GIT\Fotos\Ficha{0}.bmp", DP.Id))
                PicBx1.Image.Save(Path)
            Else
                Path = "C:\GIT\Fotos\FichaNew.bmp"
            End If
            ' PicBx1.Image.Save(Path)
            ' MsgBox(String.Format("Imagen guardada en {0}", Path))
            'asi guardo la ubicacion de la foto en el picturebox
            PicBx1.Tag = Path
        End If
    End Sub

    Function ValidaNif(ByVal nif As String) As Boolean
        Dim n As Long
        Dim letras() As String = {"T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E"}
        If (Len(nif) = 9 AndAlso IsNumeric(nif.Substring(0, 8))) Then
            n = CLng(nif.Substring(0, 8))
            n = n Mod 23
            If (UCase(nif.Substring(8)) = letras(CInt(n))) Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function GetDCNumSegSocial(ByVal numSegSocial As String, _
                                  ByVal esNumEmpresa As Boolean) As String
        If (numSegSocial.Length > 10) OrElse (numSegSocial.Length = 0) Then _
            Throw New System.ArgumentException()
        Dim regex As New System.Text.RegularExpressions.Regex("[^0-9]")
        If (regex.IsMatch(numSegSocial)) Then _
            Throw New System.ArgumentException()
        Try
            Dim dcProv As String = numSegSocial.Substring(0, 2)
            Dim numero As String = numSegSocial.Substring(2, numSegSocial.Length - 2)
            Select Case numero.Length
                Case 8
                    If (esNumEmpresa) Then
                        Return String.Empty
                    Else
                        If (numero.Chars(0) = "0"c) Then
                            numero = numero.Remove(0, 1)
                        End If
                    End If
                Case 7
                    If (esNumEmpresa) Then
                        If (numero.Chars(0) = "0"c) Then
                            numero = numero.Remove(0, 1)
                        End If
                    End If
                Case 6
                    If (Not (esNumEmpresa)) Then
                        numero = numero.PadLeft(7, "0"c)
                    End If
                Case Else
                    If (esNumEmpresa) Then
                        numero = numero.PadLeft(6, "0"c)
                    Else
                        numero = numero.PadLeft(7, "0"c)
                    End If
            End Select
            Dim naf As Int64 = Convert.ToInt64(dcProv & numero)
            naf = naf - (naf \ 97) * 97
            Return String.Format("{0:00}", naf)
        Catch
            Return String.Empty
        End Try
    End Function

    Public Function ValidaNumSS(ByVal NSS As String) As Boolean

        Dim CP As String = NSS.Substring(0, 2)
        If CP = "  " Then Return False
        If Not IsNumeric(CP) AndAlso (CInt(CP) < 1 Or CInt(CP) > 50) Then Return False
        Dim NssSCC As String = NSS.Substring(0, NSS.Length - 2)
        Dim dc As String = GetDCNumSegSocial(NssSCC, False)
        Dim s As String = NSS.Substring(NSS.Length - 2, 2)
        If s = dc Then Return True
        Return False
    End Function

    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click
        Dim respuesta1, respuesta2 As MsgBoxResult
        'Dim nombre As String = DP.Nombre & DP.Apellido1 & DP.Apellido2

        respuesta1 = MsgBox(String.Format("Ha seleccionado la ficha:" & vbCrLf &
                                          " ' {0} {1} {2} '" & vbCrLf &
                                          " para ser borrada" & vbCrLf &
                                          "¿Está seguro?", DP.Nombre, DP.Apellido1, DP.Apellido2), MsgBoxStyle.YesNo)
        If respuesta1 = MsgBoxResult.No Then Throw New miExcepcion("Borrado cancelado a peticion del usuario")
        respuesta2 = MsgBox("¿Seguro que desea continuar?" & vbCrLf & "Una vez borrado no se puede recuperar", MsgBoxStyle.YesNo)
        If respuesta2 = MsgBoxResult.No Then Throw New miExcepcion("Borrado cancelado a peticion del usuario")
        Dim borrado As Boolean = False
        borrado = borrarDatosPersonales(DP.Id)
        If borrado = True Then
            MsgBox("Alumno y sus datos borrados con éxito")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
            Throw New miExcepcion("Error al borrar")
        End If
    End Sub

    Public Function borrarDatosPersonales(ByVal i As String) As Boolean
        Dim num, idAl_Pr As Integer
        Dim sqlIdAl, sqlalumnos, sqlDatosPersonales As String
        sqlIdAl = String.Format("Select {0}.Id from DatosPersonales, {0} where DatosPersonales.Id={0}.IdDP and DatosPersonales.Id={1}", cat, i)
        ' MsgBox(sqlIdAl)
        sqlDatosPersonales = String.Format("DELETE FROM DatosPersonales WHERE DatosPersonales.Id={0}", DP.Id)
        ' MsgBox(sqlDatosPersonales)
        Dim cn2 As New SqlConnection(ConeStr)
        Try
            Dim cmdDelDP As SqlCommand
            If cat = "Candidatos" Then
                cn.Open()
                cmdDelDP = New SqlCommand(sqlDatosPersonales, cn)
                num = cmdDelDP.ExecuteNonQuery
                If num < 0 Then Throw New miExcepcion(String.Format("Error al borrar datos personales en {0}", cat))
            Else
                Dim cmdIdAl, cmdDelTablaAl_PR As SqlCommand
                cn.Open()
                'hago la consulta para obtener la ID del Alumno
                cmdIdAl = New SqlCommand(sqlIdAl, cn)
                idAl_Pr = cmdIdAl.ExecuteScalar
                If idAl_Pr < 0 Then Throw New miExcepcion(String.Format("Error al obtener la Id de {0}", cat))
                cn.Close()
                'con el Id correcto, lo cargo en la sql de borrado
                sqlalumnos = String.Format("delete from {0} where {0}.id={1}", cat, idAl_Pr)
                'MsgBox(sqlalumnos)
                'Abro otra vez para borrar en tabla Alumnos o profesores
                cn.Open()
                cmdDelTablaAl_PR = New SqlCommand(sqlalumnos, cn)
                num = cmdDelTablaAl_PR.ExecuteNonQuery
                If num < 0 Then Throw New miExcepcion(String.Format("Error al borrar de {0}", cat))
                cn2.Open()
                cmdDelDP = New SqlCommand(sqlDatosPersonales, cn2)
                num = cmdDelDP.ExecuteNonQuery
                If num < 0 Then Throw New miExcepcion(String.Format("Error al borrar datos personales en {0}", cat))
            End If
        Catch ex2 As miExcepcion
            Return False
            MsgBox(ex2.ToString)
        Catch ex As Exception
            Return False
            MsgBox(ex.ToString)
        Finally
            cn2.Close()
            cn.Close()
        End Try
        Return True
    End Function

    Private Sub cmdAñadirAAlumnos_Click(sender As Object, e As EventArgs) Handles cmdAñadirAAlumnos.Click
        If Me.optAptoSi.Checked = False Then
            MsgBox("El candidato no está calificado como Apto")
        Else
            cat = "Alumnos"
            Call ModificarOCrear()
        End If
    End Sub

    Private Sub optAptoSi_Click(sender As Object, e As EventArgs) Handles optAptoSi.Click
        Me.cmdAñadirAAlumnos.Visible = True
        Me.cmdAñadirAAlumnos.Enabled = True
    End Sub

    Private Sub OptAptoNo_Click(sender As Object, e As EventArgs) Handles OptAptoNo.Click
        Me.cmdAñadirAAlumnos.Visible = False
        Me.cmdAñadirAAlumnos.Enabled = False
    End Sub

    Private Sub OptAptoPendiente_Click(sender As Object, e As EventArgs) Handles OptAptoPendiente.Click
        Me.cmdAñadirAAlumnos.Visible = True
        Me.cmdAñadirAAlumnos.Enabled = False
    End Sub

End Class