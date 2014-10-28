Public Class FrmFichas
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
        Else
            MsgBox(alum.Nombre & vbCrLf & alum.DNI)

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
        'Call rellenarObjetoDesdeCampos()
        Call comprobarcampos(alum)
        Dim alumnoModificado As Alumno = rellenarObjetoDesdeCampos()
        Call comprobarcampos2()
        'Call comprobarcampos(alumnoModificado)
    End Sub
    Private Sub comprobarcampos(ByVal ALU As Alumno)


        Dim listaNombres As List(Of String) = ALU.ListadoNombreDeLasPropiedades
        Dim listadoPropiedades As List(Of String) = ALU.ListadoDeValoresDeLasPropiedades
        Dim estadoDeCampos As New List(Of Integer)


    End Sub
    Sub comprobarcampos2()
        Dim listacontroles As New List(Of Control)
        For Each c As Control In Me.Controls

            If c.Tag <> "" Then
                listacontroles.Add(c)
            ElseIf TypeOf (c) Is GroupBox Then
                For Each c2 As Control In c.Controls
                    If Not TypeOf (c2) Is RadioButton Then
                        listacontroles.Add(c2)

                    End If
                Next
            End If
        Next
        'listacontroles.

        For Each c As Control In listacontroles
            MsgBox(c.Tag & "  " & c.Name & "  " & c.Text)
        Next
        MsgBox("Todos recorridos")
    End Sub
    Sub comprobarcampos3()
        Dim listacontroles As New ArrayList
        For Each c As Control In Me.Controls
            If TypeOf (c) Is TextBox Then
                listacontroles.Add(c)
            ElseIf TypeOf (c) Is MaskedTextBox Then
                listacontroles.Add(c)
            ElseIf TypeOf (c) Is PictureBox Then
                listacontroles.Add(c)
            ElseIf TypeOf (c) Is GroupBox Then
                For Each c2 As Control In c.Controls
                    If Not TypeOf (c2) Is RadioButton Then
                        listacontroles.Add(c2)
                    Else
                        listacontroles.Add(c)
                    End If
                Next
            End If
        Next
        ' ya tengo una puta lista de controles 
        listacontroles.Sort()
      
        For Each c As Control In listacontroles
            MsgBox(c.Tag & "  " & c.Name & "  " & c.Text)
        Next
        MsgBox("Todos recorridos")
    End Sub
End Class