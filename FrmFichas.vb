Public Class FrmFichas
    Public alum As Alumno
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
        End If
    End Sub

    Private Sub rellenarCamposDesdeObjeto()
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
       
    End Sub






    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim errores As Boolean = ErrorEnCamposRellenados()
        If errores = True Then
            MsgBox("error al guardar")
        Else
            MsgBox("Aqui codigo para guardar")
        End If
    End Sub
    Private Function ErrorEnCamposRellenados()
        'creo una lista de controles y le añado solo los que estan marcados por el tag
        Dim listacontroles As New List(Of Control)
        Dim listadecambios As New List(Of String)
        For Each c As Control In Me.Controls
            If c.Tag <> "" Then
                listacontroles.Add(c)
            End If
            'ordeno el listado por el tag, eso me deja los controles en posicion para comparar
            listacontroles.Sort(c.Tag)
        Next
        'cargo las propiedades del objeto en una lista
        Dim l As New List(Of String)
        l = alum.ListadoDePropiedades
        'recorro los controles  y comparo el contenido con los valores de las propiedades
        For i As Integer = 0 To listacontroles.Count
            'si hay cambio lo meto en una lista, para luego poder ponerlo en un mensaje
            'segun que tipo de control sea, lo hago de una manera u otra
            'textbox
            If TypeOf (listacontroles(i)) Is TextBox Or TypeOf (listacontroles(i)) Is MaskedTextBox Then
                If listacontroles(i).Text <> alum.ListadoDePropiedades(i) Then
                    listadecambios.Add(listacontroles(i).Name)
                End If
            End If
        Next
        Dim resp As MsgBoxResult
        For Each li As String In listadecambios
            resp = MsgBox("hay cambios en " & vbCrLf & li & "¿Desea hacerlos?", MsgBoxStyle.YesNo)
            If resp = MsgBoxResult.No Then
                Return True
            End If
        Next
        Return False
    End Function
End Class