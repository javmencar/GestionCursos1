

'Imports System.Reflection
Imports System.Data.SqlClient
Public Class FrmFichas
    Dim nuevo As Boolean
    Public alum, a As Alumno
    Public cn As SqlConnection
    'Public profe As profesor
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub New(ByVal al As Alumno)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        alum = al
    End Sub

    Private Sub FrmFichas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)

        If IsNothing(alum) Then
            'nada, viene vacío y lo tenemos que rellenar
            alum = New Alumno
            nuevo = True
            Me.txtId.Enabled = False
        Else
            '   MsgBox(alum.Nombre & vbCrLf & alum.DNI)
            nuevo = False
            'cargamos el objeto en los campos
            Call rellenarCamposDesdeObjeto()
            Me.txtId.Enabled = False
        End If
    End Sub

    Private Sub rellenarCamposDesdeObjeto()
        Me.txtId.Text = CStr(alum.Id)
        Me.txtApellido1.Text = alum.Apellido1
        Me.txtApellido2.Text = alum.Apellido2
        Me.txtNombre.Text = alum.Nombre
        Me.txtDNI.Text = alum.DNI
        Me.txtNumSS.Text = alum.NumSS
        Me.txtFNac.Text = CStr(alum.Fnac)
        Me.txtLugNac.Text = alum.LugNac
        Me.txtEdad.Text = CStr(alum.Edad)
        Me.txtTel1.Text = alum.Tel1
        Me.txtTel2.Text = alum.Tel2
        Me.txtDomicilio.Text = alum.Domicilio
        Me.txtCP.Text = alum.CP
        Me.txtPoblacion.Text = alum.Poblacion
        If alum.InInaem = True Then
            Me.optInaemSi.Select()
        Else
            Me.OptInaemNo.Select()
        End If
        Me.txtInFecha.Text = CStr(alum.InFecha)
        Me.txtNivelEstudios.Text = alum.NivelEstudios
        'hago una matriz con la string de experiencia y la vuelco en el listbox
        'controlo si hay algo en el string
        If Not IsNothing(alum.ExpSector) Then
            Dim sectores() As String = alum.ExpSector.Split(";")
            For Each s As String In sectores
                Me.LstExpSector.Items.Add(s)
            Next
        End If
        Me.CboTallaCamiseta.SelectedItem = alum.TallaCamiseta
        Me.CboTallaPantalon.SelectedItem = alum.TallaPantalon
        Me.txtTallaCalzado.Text = CStr(alum.TallaZapato)
        Me.txtEntrevistador.Text = alum.Entrevistador
        Me.txtFecEntr.Text = CStr(alum.FecEntr)
        Me.txtValoracion.Text = alum.Valoracion
        If Not IsNothing(alum.Apto) Then
            Select Case alum.Apto
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
    End Sub
    Private Function rellenarObjetoDesdeCampos() As Alumno
        Try
            a = New Alumno
            With a
                .Apellido1 = Me.txtApellido1.Text
                .Apellido2 = Me.txtApellido2.Text
                .Nombre = Me.txtNombre.Text
                .DNI = Me.txtDNI.Text
                .NumSS = Me.txtNumSS.Text
                Dim err As Integer = 0
                Dim t As String = Me.txtFNac.Text

                err = comprobarformatofechaPorExcepciones(t)
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
                    err = comprobarformatofechaPorExcepciones(t)
                    Select Case err
                        Case 0
                            .InFecha = t
                        Case 1, 2
                            Throw New miExcepcion("Error de formato en la fecha de inscripcion en la oficina de empleo" & vbCrLf &
                                              "El formato debe ser dd/MM/yyyy ")
                        Case 3, 4
                            Throw New miExcepcion("error en fecha de inscripcion en el Inaem: " & err)
                    End Select
                    '.InFecha = t
                    ' MsgBox(.InFecha.ToString)
                Else
                    .InInaem = "False"
                End If
                .NivelEstudios = Me.txtNivelEstudios.Text
                If Me.LstExpSector.Items.Count > 0 Then
                    Dim str As String = ""
                    For Each l As String In Me.LstExpSector.Items
                        String.Format("{0} ; {1}", str, l)
                    Next
                    If str.Length > 0 Then
                        str.Substring(1)
                        MsgBox(str)
                    End If
                    .ExpSector = str
                End If
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
                    err = comprobarformatofechaPorExcepciones(t)
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
        Return a
    End Function

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Try
            'If Me.txtFNac.mas Then
            '    MsgBox(alum.Fnac.ToString)
            Dim alumnoConDatosDelFormulario As Alumno
            ' Dim fallos As Boolean = fallosEnCamposPrincipales()
            ' If fallos = False Then
            alumnoConDatosDelFormulario = rellenarObjetoDesdeCampos()
            '   End If
            If Not IsNothing(alumnoConDatosDelFormulario) Then
                If nuevo = True Then
                    Call CrearNuevoAlumnoEnBaseDeDatos(alumnoConDatosDelFormulario)
                    'con el alumno en datos personales cargo de nuevo el formulario y asi tengo la ID
                    Dim nuevaId As Integer = cogerUltimaId()
                    If nuevaId = -1 Then Throw New miExcepcion("Error al calcular la ultima ID")
                    'ya controlare luego si es en alumnos o en profesores
                    Dim comp As Integer = insertarEnTablaAlumnos(nuevaId)
                    If comp = -1 Then Throw New miExcepcion("Problema al insertar en tabla alumnos")
                    MsgBox("Alumno insertado con éxito")
                Else
                    Call cargarCambiosEnAlumnoYaCreado(alumnoConDatosDelFormulario)
                End If
            End If
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function fallosEnCamposPrincipales() As Boolean
        Dim cambios As New List(Of String)
        Dim vacios As New List(Of String)
        Dim respuesta As MsgBoxResult
        Try
            If alum.Nombre <> Me.txtNombre.Text Then cambios.Add("Nombre")
            If alum.Apellido1 <> Me.txtApellido1.Text Then cambios.Add("Apellido1")
            If alum.Apellido2 <> Me.txtApellido2.Text Then cambios.Add("Apellido2")
            If Me.txtDNI.Text = "" Then vacios.Add("DNI")
            If Me.txtNombre.Text = "" Then vacios.Add("Nombre")
            If Me.txtApellido1.Text = "" Then vacios.Add("Apellido1")
            If Me.txtApellido2.Text = "" Then vacios.Add("Apellido2")
            If Me.lblNumSS.Text = "  /        /" Then vacios.Add("NumSS")
            For Each v As String In vacios
                respuesta = MsgBox(String.Format("Va generar una ficha con un campo vacío en la casilla '{0}'" &
                                                vbCrLf & "¿Es correcto?", v), MsgBoxStyle.YesNo)
                If respuesta = MsgBoxResult.No Then Throw New miExcepcion("Modificacion anulada a peticion del usuario")
            Next
            Dim numSSSinBarras As String
            numSSSinBarras = Me.txtNumSS.Text.Replace("/", "")
            If alum.NumSS <> numSSSinBarras Then
                respuesta = MsgBox(String.Format("El numero de la Seguridad Social va a pasar de '{0}' a '{1}'" &
                                                 vbCrLf & "¿Es correcto?", alum.NumSS, Me.txtNumSS.Text), MsgBoxStyle.YesNoCancel)
                If respuesta = MsgBoxResult.No Then Me.txtNumSS.Text = alum.NumSS
                If respuesta = MsgBoxResult.Cancel Then Throw New miExcepcion("Modificacion anulada a peticion del usuario")
            End If
            If alum.DNI <> Me.txtDNI.Text Then
                respuesta = MsgBox(String.Format("El numero del DNI va a pasar de '{0}' a '{1}'" &
                                            vbCrLf & "¿Es correcto?", alum.DNI, Me.txtDNI.Text), MsgBoxStyle.YesNoCancel)
                If respuesta = MsgBoxResult.No Then Me.txtDNI.Text = alum.DNI
                If respuesta = MsgBoxResult.Cancel Then Throw New miExcepcion("Modificacion anulada a peticion del usuario")
            End If
            For Each dato As String In cambios
                respuesta = MsgBox(String.Format("Va generar una ficha con cambios en la casilla '{0}'" &
                                               vbCrLf & "¿Es correcto?", dato), MsgBoxStyle.YesNo)
                If respuesta = MsgBoxResult.No Then Throw New miExcepcion("Modificacion anulada a peticion del usuario")
            Next
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return False
    End Function

    Public Sub cargarCambiosEnAlumnoYaCreado(ByVal al As Alumno)

    End Sub
    Public Sub CrearNuevoAlumnoEnBaseDeDatos(ByVal al As Alumno)
        Try
            Dim listanombres As List(Of String)
            Dim listavalores As ArrayList
            listanombres = al.ListadoNombreDeLasPropiedades
            listavalores = ListadoDeValoresDeLasPropiedades(al)
            Dim tablas As String = ""
            Dim valores As String = ""

            For j As Integer = 1 To listanombres.Count - 2
                'solo meto los campos que tengan valores y empiezo en 1 para no meter la Id, que es Identity 
                'y tampoco pongo por ahora la foto
                If Not IsNothing(listavalores(j)) Then
                    If TypeOf (listavalores(j)) Is String Then
                        tablas &= ", " & listanombres(j)
                        valores &= ", '" & listavalores(j) & "'"
                    ElseIf TypeOf (listavalores(j)) Is Integer Then
                        tablas &= ", " & listanombres(j).ToString
                        valores &= ", " & listavalores(j)
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
    Public Function comprobarformatofechaPorExcepciones(ByVal s As String) As Integer
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
    Public Function ListadoDeValoresDeLasPropiedades(ByVal a As Alumno) As ArrayList
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
    Public Function insertarEnTablaAlumnos(ByVal nid As Integer) As Integer
        Dim i As Integer
        cn = New SqlConnection(ConeStr)
        Try
            cn.Open()
            MsgBox(nid)
            Dim sql As String = String.Format("INSERT INTO Alumnos (alumnos.idDP) VALUES ({0})", nid)
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