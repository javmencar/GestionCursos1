Imports System.Data.SqlClient
Public Class FrmFichas
    Dim nuevo, fotoCambiada As Boolean
    Public DP, D As DatosPersonales
    Public cat As String
    Public cn As SqlConnection
    Dim NuIdDP As Integer
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal Da As DatosPersonales, ByVal c As Integer, ByVal nw As Boolean)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        nuevo = nw
        DP = Da
        If c = 0 Then
            cat = "Profesores"
        ElseIf c = 1 Then
            cat = "Alumnos"
        End If
    End Sub

    Private Sub FrmFichas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Me.txtId.Enabled = False
        Me.LstExpSector.Items.Clear()
        'hola
        Me.CboExpSector.SelectedIndex = -1
        NuIdDP = -1
        If nuevo = True Then
            DP = New DatosPersonales
            Me.cmdModificar.Text = "CREAR NUEVA FICHA"
            Me.cmdCancelar.Text = "Cancelar La Creación"
            Me.PicBx1.Image = Image.FromFile("C:\GIT\GestionCursos1\Resources\female-silhouette_0.jpg")
            Me.PicBx1.Tag = "C:\GIT\GestionCursos1\Resources\female-silhouette_0.jpg"
            NuIdDP = cogerUltimaId() + 1
            MsgBox("UltimaID + 1=  " & NuIdDP)
        Else
            Me.cmdModificar.Text = "MODIFICAR FICHA"
            Me.cmdCancelar.Text = "Cancelar La Modificación"

            Call rellenarCamposDesdeObjeto(DP)
        End If
        'Este es el original
    End Sub

    Private Sub rellenarCamposDesdeObjeto(ByVal Datos As DatosPersonales)
        With Datos
            Me.txtId.Text = CStr(.Id)
            Me.txtApellido1.Text = .Apellido1
            Me.txtApellido2.Text = .Apellido2
            Me.txtNombre.Text = .Nombre
            Me.txtDNI.Text = .DNI
            Me.txtNumSS.Text = .NumSS
            ' MsgBox("Propiedad del objeto sin pasar a string" & al.Fnac)
            ' MsgBox("Propiedad del objeto pasada a string" & al.Fnac.ToString)
            Me.txtFNac.Text = CStr(.Fnac)
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
            Me.txtInFecha.Text = CStr(.InFecha)
            Me.txtNivelEstudios.Text = .NivelEstudios
            'hago una matriz con la string de experiencia y la vuelco en el listbox
            'controlo si hay algo en el string
            Me.LstExpSector.Items.Clear()
            If Not IsNothing(.ExpSector) Then
                Dim sectores() As String = .ExpSector.Split(";")
                For Each s As String In sectores
                    Me.LstExpSector.Items.Add(s)
                Next
            End If
            Me.CboTallaCamiseta.SelectedItem = .TallaCamiseta
            Me.CboTallaPantalon.SelectedItem = .TallaPantalon
            Me.txtTallaCalzado.Text = CStr(.TallaZapato)
            Me.txtEntrevistador.Text = .Entrevistador
            Me.txtFecEntr.Text = CStr(.FecEntr)
            Me.txtValoracion.Text = .Valoracion
            If Not IsNothing(.Apto) Then
                Select Case .Apto
                    Case "Apto"
                        Me.optAptoSi.Select()
                    Case "No Apto"
                        Me.OptAptoNo.Select()
                    Case "Pendiente"
                        Me.OptAptoPendiente.Select()
                End Select
            Else
                Me.OptAptoPendiente.Select()
            End If

            Me.LblFoto.Tag = .IdFoto
            Call cargarFotoEnFormulario(.Id)
            Me.PicBx1.Tag = .PathFoto
         
        End With
    End Sub
    Private Function rellenarObjetoDesdeCampos() As DatosPersonales
        Try
            D = New DatosPersonales
            With D
                If Me.txtId.Text <> "" Then
                    .Id = Me.txtId.Text
                End If
                .Apellido1 = Me.txtApellido1.Text
                .Apellido2 = Me.txtApellido2.Text
                .Nombre = Me.txtNombre.Text
                .DNI = Me.txtDNI.Text
                .NumSS = Me.txtNumSS.Text
                Dim err As Integer = 0
                Dim t As String = Me.txtFNac.Text
                err = comprobarformatofecha(t)
                Select Case err
                    Case 0
                        .Fnac = t
                    Case 1
                        Throw New miExcepcion("Error de formato en la fecha de nacimiento" & vbCrLf &
                                              "El formato debe ser dd/MM/yyyy " & vbCrLf & " case 1")
                    Case 2
                        Throw New miExcepcion("Error de formato en la fecha de nacimiento" & vbCrLf &
                                              "El formato debe ser dd/MM/yyyy " & vbCrLf & " case 2")
                    Case 3, 4
                        Throw New miExcepcion("error en fecha de nacimiento de tipo: " & err)
                End Select
                .LugNac = Me.txtLugNac.Text
                If Me.txtEdad.Text = "" Then Me.txtEdad.Text = "0"
                .Edad = CInt(Me.txtEdad.Text)
                .Tel1 = Me.txtTel1.Text
                .Tel2 = Me.txtTel2.Text
                .Domicilio = Me.txtDomicilio.Text
                .CP = Me.txtCP.Text
                .Poblacion = Me.txtPoblacion.Text
                If Me.optInaemSi.Checked = True Then
                    'ojo, la propiedad alumno.Ininaem es un string
                    .InInaem = "True"
                    t = Me.txtInFecha.Text
                    err = comprobarformatofecha(t)
                    Select Case err
                        Case 0
                            .InFecha = t
                        Case 1, 2
                            Throw New miExcepcion("Error de formato en la fecha de inscripcion en la oficina de empleo" & vbCrLf &
                                              "El formato debe ser dd/MM/yyyy ")
                        Case 3, 4
                            Throw New miExcepcion("error en fecha de inscripcion en el Inaem: " & err)
                    End Select
                Else
                    .InInaem = "False"
                End If
                .NivelEstudios = Me.txtNivelEstudios.Text

                Dim expSect1 As String = ""
                Dim expSect2 As String = ""
                If Me.LstExpSector.Items.Count > 0 Then

                    For Each l As String In Me.LstExpSector.Items
                        expSect1 &= ";" & l
                    Next
                    ' MsgBox("Antes del subString: " & vbCrLf & expSect1)
                    expSect2 = expSect1.Substring(1)
                    ' MsgBox("Despues del subString: " & vbCrLf & expSect2)
                End If
                .ExpSector = expSect2
                If Me.CboTallaCamiseta.SelectedIndex <> -1 Then
                    .TallaCamiseta = Me.CboTallaCamiseta.SelectedItem.ToString
                End If
                If Me.CboTallaPantalon.SelectedIndex <> -1 Then
                    .TallaPantalon = Me.CboTallaPantalon.SelectedItem.ToString
                End If
                If Me.txtTallaCalzado.Text = "" Then Me.txtTallaCalzado.Text = "0"
                .TallaZapato = CInt(Me.txtTallaCalzado.Text)
                .Entrevistador = Me.txtEntrevistador.Text
                If Me.txtEntrevistador.Text <> "" Xor Me.txtValoracion.Text <> "" Then
                    t = Me.txtFecEntr.Text
                    err = comprobarformatofecha(t)
                    Select Case err
                        Case 0
                            .FecEntr = t
                        Case 1, 2
                            Throw New miExcepcion("Error de formato en la fecha de entrevista" & vbCrLf &
                                             "El formato debe ser dd/MM/yyyy ")
                        Case 3, 4
                            Throw New miExcepcion("error en fecha de inscripcion en el Inaem: " & err)
                    End Select
                    '.FecEntr = t
                    'MsgBox(.FecEntr.ToString)
                End If
                .Valoracion = Me.txtValoracion.Text
                If Me.optAptoSi.Checked = True Then
                    .Apto = "Apto"
                End If
                If Me.OptAptoNo.Checked = True Then
                    .Apto = "No Apto"
                End If
                If Me.OptAptoPendiente.Checked = True Then
                    .Apto = "Pendiente"
                End If
              
                    .IdFoto = Me.cmdCambiarFoto.Tag
                    .PathFoto = Me.PicBx1.Tag

            End With
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
            D = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
            D = Nothing
        End Try
        Return D
    End Function

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Try

            Dim DPConDatosDelFormulario As DatosPersonales
            Dim fallos As List(Of String)
            If nuevo = True Then
                fallos = camposvacios()
            Else
                fallos = fallosEnCampos()
            End If
            If fallos.Count > 0 Then
                'If Not IsNothing(fallos) Then
                Dim respuesta As MsgBoxResult
                Dim recogefallos As String = ""
                For Each s As String In fallos
                    recogefallos &= "' " & s & " '" & vbCrLf
                Next
                respuesta = MsgBox("Está creando una ficha con estas incidencias: " & vbCrLf & recogefallos &
                            vbCrLf & "¿Seguro que desea seguir?", MsgBoxStyle.YesNo)
                If respuesta = MsgBoxResult.No Then Throw New miExcepcion("Operación cancelada a peticion del usuario")
            Else
                ' MsgBox("No hay fallos")
            End If
            'Primera llamada controlada
            DPConDatosDelFormulario = rellenarObjetoDesdeCampos()
            If Not IsNothing(DPConDatosDelFormulario) Then
                'Primero inserto o modifico la foto
                If nuevo = True Then
                    Call CrearNuevoDPEnBaseDeDatos(DPConDatosDelFormulario)
                    'con el alumno en datos personales cargo de nuevo el formulario y asi tengo la ID
                    Dim nuevaId As Integer = cogerUltimaId()
                    If nuevaId = -1 Then Throw New miExcepcion("Error al calcular la ultima ID")
                    Dim comp As Integer = insertarEnTablacategoria(nuevaId)
                    If comp = -1 Then Throw New miExcepcion(String.Format("Problema al insertar en {0}", cat))
                Else
                    'estoy modificando
                    'Dim DPConModificaciones As DatosPersonales = rellenarObjetoDesdeCampos()
                    Call cargarCambiosEnDPYaCreado(DPConDatosDelFormulario)
                End If
            Else
                Throw New miExcepcion("Cambie los campos necesarios para poder continuar o salga de la pantalla")
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
        numSSSinBarras = Me.txtNumSS.Text.Replace("/", "")
        If numSSSinBarras = "" Then vacios.Add("El campo 'Numero de la seguridad Social' está vacío")
        'añadir o quitar los campos que queramos comprobar
        Return vacios
    End Function
    Private Function fallosEnCampos() As List(Of String)
        Dim cambios As New List(Of String)
        Dim numSSSinBarras As String = Me.txtNumSS.Text.Replace("/", "")
        If DP.Nombre <> Me.txtNombre.Text Then cambios.Add(String.Format("El campo 'Nombre' va a ser cambiado de '{0}' a '{1}", DP.Nombre, Me.txtNombre.Text))
        If DP.Apellido1 <> Me.txtApellido1.Text Then cambios.Add(String.Format("El campo 'Primer Apellido' va a ser cambiado de '{0}' a '{1}", DP.Apellido1, Me.txtApellido1.Text))
        If DP.Apellido2 <> Me.txtApellido2.Text Then cambios.Add(String.Format("El campo 'Segundo Apellido' va a ser cambiado de '{0}' a '{1}", DP.Apellido2, Me.txtApellido2.Text))
        If DP.DNI <> Me.txtDNI.Text Then cambios.Add(String.Format("El campo 'DNI' va a ser cambiado de '{0}' a '{1}", DP.DNI, Me.txtDNI.Text))
        If DP.NumSS <> numSSSinBarras Then cambios.Add(String.Format("El campo 'Numero de la Seguridad Social' va a ser cambiado de '{0}' a '{1}", DP.NumSS, Me.txtNumSS.Text))
        Return cambios
    End Function

    Public Sub cargarCambiosEnDPYaCreado(ByVal dat As DatosPersonales)
        'UPDATE
        Try
            Dim listanombres As List(Of String)
            Dim listavalores As ArrayList
            listanombres = dat.ListadoNombreDeLasPropiedades
            listavalores = ListadoDeValoresDeLasPropiedades(dat)
            Dim Datos As String = ""
            Dim fechaFormatoCorrecto As String = ""
            For i As Integer = 1 To 25
                If TypeOf (listavalores(i)) Is String Then
                    Datos &= String.Format(", {0}='{1}'", listanombres(i), listavalores(i))
                ElseIf TypeOf (listavalores(i)) Is Integer Then
                    Datos &= String.Format(", {0}={1}", listanombres(i), listavalores(i))
                ElseIf TypeOf (listavalores(i)) Is Date Then
                    fechaFormatoCorrecto = cambiarFormatoFecha(listavalores(i))
                    Datos &= String.Format(", {0}={1}", listanombres(i), listavalores(i))
                ElseIf TypeOf (listavalores(i)) Is Boolean Then
                    If listavalores(i) = True Then
                        Datos &= String.Format(", {0}=1", listanombres(i))
                    Else
                        Datos &= String.Format(", {0}=0", listanombres(i))
                    End If
                End If
            Next
            '   le quito la primera coma
            Datos = Datos.Substring(1)
            Dim sql As String = String.Format("UPDATE DatosPersonales SET {0} Where DatosPersonales.Id={1}", Datos, CInt(D.Id))
            MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim j As Integer = cmd.ExecuteNonQuery()
            If j <> 1 Then Throw New miExcepcion("error en la insercion") '   No debería dar distinto de 1, porque solo afecta a un registro
            MsgBox("Datos personales modificados en la base de datos")

        Catch ex2 As miExcepcion
            '    MsgBox(ex2.ToString)   '   Así devolvera la excepcion en el cmd y lo parará
        Catch ex As Exception
            '     MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try

    End Sub
    Public Sub CrearNuevoDPEnBaseDeDatos(ByVal Datos As DatosPersonales)
        'INSERT INTO
        Try
            Dim listanombres As List(Of String)
            Dim listavalores As ArrayList
            listanombres = Datos.ListadoNombreDeLasPropiedades
            listavalores = ListadoDeValoresDeLasPropiedades(Datos)
            Dim tablas As String = ""
            Dim valores As String = ""

            For j As Integer = 1 To listanombres.Count - 2
                'solo meto los campos que tengan valores y empiezo en 1 para no meter la Id, que es Identity 
                'y tampoco pongo el PathFoto
                If Not IsNothing(listavalores(j)) Then
                    If TypeOf (listavalores(j)) Is String Then
                        tablas &= ", " & listanombres(j)
                        valores &= ", '" & listavalores(j) & "'"
                    ElseIf TypeOf (listavalores(j)) Is Integer Then
                        tablas &= ", " & listanombres(j)
                        valores &= ", " & listavalores(j).ToString
                    ElseIf TypeOf (listavalores(j)) Is Date Then
                        tablas &= ", " & listanombres(j)
                        Dim fechaFormatoCorrecto As String = cambiarFormatoFecha(listavalores(j))
                        valores &= ", " & fechaFormatoCorrecto
                    ElseIf TypeOf (listavalores(j)) Is Boolean Then
                        tablas &= ", " & listanombres(j)
                        'creo recordar que los valores booleanos se meten con 0 y 1
                        If listavalores(j) = True Then valores &= ", 1"
                        If listavalores(j) = False Then valores &= ", 0"
                    End If
                End If
            Next
            'Le quito la primera coma y el primer espacio a las dos variables
            tablas = tablas.Substring(2)
            valores = valores.Substring(2)
            Dim sql As String = String.Format("INSERT INTO DatosPersonales ({0}) VALUES ({1})", tablas, valores)
            MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i <= 0 Then Throw New miExcepcion("error en la insercion")
            'recojo la nueva IdDP
            Dim pathfoto As String = Datos.PathFoto
            NuIdDP = cogerUltimaId()
            'Inserto en la tabla fotos
            Dim idfoto As Integer = InsertarEnTablaFotos(pathfoto, NuIdDP)
            If idfoto <= 0 Then Throw New miExcepcion("error en la insercion de la foto en tabla fotos")
            Call MeterIdFotoEnDatosPersonales(idfoto, NuIdDP)
            MsgBox("Datos personales introducidos en la base de datos")
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try


    End Sub
    Public Function InsertarEnTablaFotos(ByVal path As String, ByVal I As Integer) As Integer
        Dim Id As Integer = -1
        Try
            Dim sql As String = String.Format("INSERT INTO Fotos (FotoPath,IdDP) VALUES ({0},{1})", path, I)
            MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim j As Integer = cmd.ExecuteNonQuery()
            If j <> 1 Then Throw New miExcepcion("Error en IdFoto")
            Dim cn2 As New SqlConnection(ConeStr)
            cn2.Open()
            Dim sql2 As String = String.Format("Select Id from Fotos where Fotos.idDP={0}", I)
            Dim cmd2 As New SqlCommand(sql2, cn2)
            Id = cmd2.ExecuteScalar
            cn2.Close()
            MsgBox(String.Format("La IdFoto es: {0}", Id))
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try
        Return Id
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
    Public Function ListadoDeValoresDeLasPropiedades(ByVal a As DatosPersonales) As ArrayList
        'List(Of String)
        Dim lista As New ArrayList
        Dim arreglafallos As String = ""
        With lista
            .Add(a.Id)
            .Add(a.DNI)
            .Add(a.Nombre)
            .Add(a.Apellido1)
            .Add(a.Apellido2)
            .Add(a.Fnac)
            .Add(a.LugNac)
            .Add(a.Edad)
            .Add(a.Domicilio)
            .Add(a.CP)
            .Add(a.Poblacion)
            arreglafallos = a.Tel1.Replace("-", "")
            .Add(arreglafallos)
            arreglafallos = a.Tel2.Replace("-", "")
            .Add(arreglafallos)
            arreglafallos = a.NumSS.Replace("/", "")
            .Add(arreglafallos)
            .Add(a.InInaem)
            .Add(a.InFecha)
            .Add(a.NivelEstudios)
            .Add(a.ExpSector)
            .Add(a.TallaCamiseta)
            .Add(a.TallaPantalon)
            .Add(a.TallaZapato)
            .Add(a.Entrevistador)
            .Add(a.FecEntr)
            .Add(a.Valoracion)
            .Add(a.Apto)
            .Add(a.IdFoto)
            .Add(a.PathFoto)
        End With
        Return lista
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
                MsgBox("Sector añadido al listado")
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
        Me.DialogResult = Windows.Forms.DialogResult.Abort
    End Sub
    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
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

    Private Sub guardarFotoDeLaFicha(ByVal str As String, ByVal I As Integer)
        Try
            Dim sql As String = ""
            sql = String.Format("UPDATE Fotos SET FotoPath='{0}' WHERE Fotos.Id = (select fotos.id from Fotos where IdDP={1})", str, I)
            MsgBox(sql)
            'falta la insercion

        Catch ex As Exception

        End Try

    End Sub
    Private Sub cargarFotoEnFormulario(ByVal I As Integer)
        Try
            cn = New SqlConnection(ConeStr)
            'Dim id As String = "22"
            Dim sql As String = String.Format("select FotoPath,Fotos.Id from fotos WHERE Fotos.Id = (select fotos.id from Fotos where IdDP={0})", I)

            cn.Open()

            Dim cmd As New SqlCommand(sql, cn)
            Dim str As String = ""
            Dim dr1 As SqlDataReader = cmd.ExecuteReader
            If dr1.Read Then
                '  dr1.Read()
                str = dr1(0)
                Me.PicBx1.ImageLocation = str
                'Me.PicBx1.Show()
                Me.PicBx1.Load(str)
                Me.LblFoto.Tag = dr1(1)
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
    Private Sub MeterIdFotoEnDatosPersonales(ByVal idf As Integer, ByVal Id As Integer)
        Try
            Dim sql As String = String.Format("UPDATE DatosPersonales SET IdFoto={0}  WHERE Id= {1}", idf, Id)
            MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i <> 1 Then Throw New miExcepcion("Error al insertar IdFoto en DatosPersonales")
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
                Path = (String.Format("c:\GIT\Fotos\Ficha{0}.bmp", DP.Id))
            Else
                ' le cargo un IdProvisional
                Path = (String.Format("c:\GIT\Fotos\Ficha{0}.bmp", NuIdDP))
            End If
            PicBx1.Image.Save(Path)
            MsgBox(String.Format("Imagen guardada en {0}", Path))
            'asi guardo la ubicacion de la foto en el picturebox
            PicBx1.Tag = Path
        End If
    End Sub

    Private Sub PicBx1_Click(sender As Object, e As EventArgs) Handles PicBx1.Click

    End Sub
End Class