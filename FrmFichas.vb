Public Class FrmFichas
    Dim nuevo As Boolean
    Public alum, a As Alumno
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
        If IsNothing(alum) Then
            'nada, viene vacío y lo tenemos que rellenar
            alum = New Alumno
            nuevo = True
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
        a = New Alumno
        With a
            .Apellido1 = Me.txtApellido1.Text
            .Apellido2 = Me.txtApellido2.Text
            .Nombre = Me.txtNombre.Text
            .DNI = Me.txtDNI.Text
            .NumSS = Me.txtNumSS.Text
            If Me.txtFNac.Text <> "00/00/0" Then
                .Fnac = Convert.ToDateTime(Me.txtFNac.Text)
                ' .Fnac = CDate(Me.txtFNac.Text)
            End If
            .LugNac = Me.txtLugNac.Text
            .Edad = CInt(Me.txtEdad.Text)
            .Tel1 = Me.txtTel1.Text
            .Tel2 = Me.txtTel2.Text
            .Domicilio = Me.txtDomicilio.Text
            .CP = Me.txtCP.Text
            .Poblacion = Me.txtPoblacion.Text
            If Me.optInaemSi.Checked = True Then
                .InInaem = True
            Else
                .InInaem = False
            End If
            If Me.txtInFecha.Text <> "00/00/0" Then
                .InFecha = Convert.ToDateTime(Me.txtInFecha.Text)
                ' .InFecha = CDate(Me.txtInFecha.Text)
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
            .TallaZapato = CInt(Me.txtTallaCalzado.Text)
            .Entrevistador = Me.txtEntrevistador.Text
            If Me.txtFecEntr.Text <> "00/00/0" Then
                .FecEntr = Convert.ToDateTime(Me.txtFecEntr.Text)
            End If
            '.FecEntr = CDate(Me.txtFecEntr.Text)
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
        Return a
    End Function

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Try
            Dim alumnoModificado As Alumno
            Dim fallos As Boolean = fallosEnCamposPrincipales()
            If fallos = False Then
                alumnoModificado = rellenarObjetoDesdeCampos()
            End If
            If Not IsNothing(alumnoModificado) Then
                If nuevo = True Then Call CrearNuevoAlumnoEnBaseDeDatos(alum)
                If nuevo = False Then Call cargarCambiosEnAlumnoYaCreado(alumnoModificado)
            End If
        Catch ex2 As miExcepcion
            MsgBox(ex2.ToString)
        Catch ex As Exception

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
            '                                    vbCrLf & "¿Es correcto?", c), MsgBoxStyle.YesCancel)
                If respuesta = MsgBoxResult.Cancel Then Throw New miExcepcion("Modificacion anulada a peticion del usuario")
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
        Dim tablas, valores As String

        Dim sql As String = ""
    End Sub
End Class