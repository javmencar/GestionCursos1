

'Imports System.Reflection
Imports System.Data.SqlClient
Public Class FrmFichas
    Dim nuevo As Boolean
    '  Public alum, a As DatosPersonales
    Public DP, D As DatosPersonales
    Public cat As String
    Public cn As SqlConnection
    'Public profe As profesor
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal D As DatosPersonales, ByVal c As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DP = D
        If c = 0 Then
            cat = "Profesores"
        ElseIf c = 1 Then
            cat = "Alumnos"
        End If
    End Sub
    'Sub New(ByVal al As DatosPersonales)

    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    alum = al
    'End Sub

    Private Sub FrmFichas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Me.LstExpSector.Items.Clear()
        If IsNothing(DP) Then
            'nada, viene vacío y lo tenemos que rellenar
            DP = New DatosPersonales
            nuevo = True
            Me.txtId.Enabled = False
        Else
            '   MsgBox(alum.Nombre & vbCrLf & alum.DNI)
            nuevo = False
            'cargamos el objeto en los campos
            Call rellenarCamposDesdeObjeto(DP)

            Me.txtId.Enabled = False
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
            'falta la foto
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
                    Case 1, 2
                        Throw New miExcepcion("Error de formato en la fecha de nacimiento" & vbCrLf &
                                              "El formato debe ser dd/MM/yyyy ")
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
                'falta la foto
            End With
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return D
    End Function

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Try
  
            Dim DPConDatosDelFormulario As DatosPersonales
            Dim fallos As List(Of String) = fallosEnCamposPrincipales()

            If Not IsNothing(fallos) Then
                Dim respuesta As MsgBoxResult
                For Each s As String In fallos
                    respuesta = MsgBox(String.Format("Está creando una ficha con esta incidencia: " & vbCrLf & s &
                                                     vbCrLf & "¿Seguro que desea seguir?", s), MsgBoxStyle.YesNo)
                    If respuesta = MsgBoxResult.No Then Throw New miExcepcion("Operación cancelada a peticion del usuario")
                Next
            End If
            DPConDatosDelFormulario = rellenarObjetoDesdeCampos()
            If Not IsNothing(DPConDatosDelFormulario) Then
                If nuevo = True Then
                    Call CrearNuevoDPEnBaseDeDatos(DPConDatosDelFormulario)
                    'con el alumno en datos personales cargo de nuevo el formulario y asi tengo la ID
                    Dim nuevaId As Integer = cogerUltimaId()
                    If nuevaId = -1 Then Throw New miExcepcion("Error al calcular la ultima ID")
                    'ya controlare luego si es en alumnos o en profesores
                    Dim comp As Integer = insertarEnTablaCategoria(nuevaId)
                    If comp = -1 Then Throw New miExcepcion(String.Format("Problema al insertar en tabla {0}", cat))
                    MsgBox("Alumno insertado con éxito")
                Else
                    'Falta por hacer la consulta de update
                    Dim DPConModificaciones As DatosPersonales = rellenarObjetoDesdeCampos()
                    Call cargarCambiosEnDPYaCreado(DPConModificaciones)
                End If
            End If
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function fallosEnCamposPrincipales() As List(Of String)
        Dim cambios As New List(Of String)

        Try
            If Me.txtNombre.Text = "" Then cambios.Add("El campo 'Nombre' está vacío")
            If Me.txtApellido1.Text = "" Then cambios.Add("El campo 'Primer Apellido'  está vacío")
            If Me.txtApellido2.Text = "" Then cambios.Add("El campo 'Segundo Apellido' está vacío")
            If Me.txtDNI.Text = "" Then cambios.Add("El campo 'DNI' está vacío")
            Dim numSSSinBarras As String
            numSSSinBarras = Me.txtNumSS.Text.Replace("/", "")
            If numSSSinBarras = "" Then cambios.Add("El campo 'Numero de la seguridad Social' está vacío")
            If nuevo = False AndAlso alum.Nombre <> Me.txtNombre.Text Then cambios.Add("El campo 'Nombre' va a ser cambiado")
            If nuevo = False AndAlso alum.Apellido1 <> Me.txtApellido1.Text Then cambios.Add("El campo 'Primer Apellido'  va a ser cambiado")
            If nuevo = False AndAlso alum.Apellido2 <> Me.txtApellido2.Text Then cambios.Add("El campo 'Segundo Apellido'  va a ser cambiado")
            If nuevo = False AndAlso alum.DNI <> Me.txtDNI.Text Then cambios.Add("El campo 'DNI'  va a ser cambiadoo")
            If nuevo = False AndAlso alum.NumSS <> numSSSinBarras Then cambios.Add("El campo 'Numero de la Seguridad Social'  va a ser cambiado")

        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
            '  Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return cambios
    End Function

    Public Sub cargarCambiosEnDPYaCreado(ByVal d As DatosPersonales)
        Try
            Dim listanombres As List(Of String)
            Dim listavalores As ArrayList
            listanombres = d.ListadoNombreDeLasPropiedades
            listavalores = ListadoDeValoresDeLasPropiedades(d)
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
                        Datos &= String.Format(", {0}={1}", listanombres(i), "1")
                    Else
                        Datos &= String.Format(", {0}={1}", listanombres(i), "0")
                    End If
                End If
            Next
            Datos = Datos.Substring(1)
            Dim sql As String = String.Format("UPDATE DatosPersonales SET {0} Where DatosPersonales.Id={1}", Datos, CInt(d.Id))
            MsgBox(sql)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            Dim j As Integer = cmd.ExecuteNonQuery()
            If j <= 0 Then Throw New miExcepcion("error en la insercion")
            MsgBox("Datos personales modificados en la base de datos")

        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try

    End Sub
    Public Sub CrearNuevoDPEnBaseDeDatos(ByVal Datos As DatosPersonales)
        Try
            Dim listanombres As List(Of String)
            Dim listavalores As ArrayList
            listanombres = Datos.ListadoNombreDeLasPropiedades
            listavalores = ListadoDeValoresDeLasPropiedades(Datos)
            Dim tablas As String = ""
            Dim valores As String = ""

            For j As Integer = 1 To listanombres.Count - 2
                'solo meto los campos que tengan valores y empiezo en 1 para no meter la Id, que es Identity 
                'y tampoco pongo por ahora la foto, cuando lo haga, el for irá hasta -1
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

            MsgBox("Datos personales introducidos en la base de datos")
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cn.Close()
        End Try


    End Sub
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
        End With
        Return lista
    End Function
    Private Sub cmdExperiencia_Click(sender As Object, e As EventArgs) Handles cmdExperiencia.Click
        If Me.CboExpSector.SelectedIndex = -1 Then
            MsgBox("seleccione un sector de experiencia laboral")
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
            Else
                MsgBox("Ese sector ya está elegido")
            End If
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
End Class