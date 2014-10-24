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
        Else
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
        Dim sectores() As String = alum.ExpSector.Split(";")
        For Each s As String In sectores
            Me.LstExpSector.Items.Add(s)
        Next
        Me.CboTallaCamiseta.SelectedItem = alum.TallaCamiseta
        Me.CboTallaPantalon.SelectedItem = alum.TallaPantalon
        Me.txtTallaCalzado.Text = CStr(alum.TallaZapato)
        Me.txtEntrevistador.Text = alum.Entrevistador
        Me.txtFecEntr.Text = CStr(alum.FecEntr)
        Me.txtValoracion.Text = alum.Valoracion
        Select Case alum.Apto
            Case "Apto"
                Me.optAptoSi.Select()
            Case "No Apto"
                Me.OptAptoNo.Select()
            Case "Pendiente"
                Me.OptAptoPendiente.Select()
        End Select
    End Sub






    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim camposComprobados As Boolean = comprobarQueLosCamposEstanBienRellenados()
        If camposComprobados = False Then

        Else

        End If
    End Sub
    Private Function comprobarQueLosCamposEstanBienRellenados()
        Return False
    End Function
End Class