<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFichas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LblApellido1 = New System.Windows.Forms.Label()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.lblApellido2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblFNac = New System.Windows.Forms.Label()
        Me.txtFNac = New System.Windows.Forms.MaskedTextBox()
        Me.txtLugNac = New System.Windows.Forms.TextBox()
        Me.txtEdad = New System.Windows.Forms.TextBox()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.lblDNI = New System.Windows.Forms.Label()
        Me.GbDNI_NIE = New System.Windows.Forms.GroupBox()
        Me.optDNI = New System.Windows.Forms.RadioButton()
        Me.optNIE = New System.Windows.Forms.RadioButton()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.txtPoblacion = New System.Windows.Forms.TextBox()
        Me.lblPoblacion = New System.Windows.Forms.Label()
        Me.lblTel1 = New System.Windows.Forms.Label()
        Me.lblTel2 = New System.Windows.Forms.Label()
        Me.txtTel1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtTel2 = New System.Windows.Forms.MaskedTextBox()
        Me.lblNumSS = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumSS = New System.Windows.Forms.MaskedTextBox()
        Me.GbInaem = New System.Windows.Forms.GroupBox()
        Me.OptNo = New System.Windows.Forms.RadioButton()
        Me.txtInFecha = New System.Windows.Forms.MaskedTextBox()
        Me.optSi = New System.Windows.Forms.RadioButton()
        Me.lblInFecha = New System.Windows.Forms.Label()
        Me.lblNivelEstudios = New System.Windows.Forms.Label()
        Me.txtNivelEstudios = New System.Windows.Forms.TextBox()
        Me.GbExperiencia = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GbUniforme = New System.Windows.Forms.GroupBox()
        Me.lblTallaCamiseta = New System.Windows.Forms.Label()
        Me.CboTallaCamiseta = New System.Windows.Forms.ComboBox()
        Me.lblTallaPantalon = New System.Windows.Forms.Label()
        Me.lblNumZapato = New System.Windows.Forms.Label()
        Me.CboTallaPantalon = New System.Windows.Forms.ComboBox()
        Me.cboTallaZapato = New System.Windows.Forms.ComboBox()
        Me.GbEntrevista = New System.Windows.Forms.GroupBox()
        Me.txtEntrevistador = New System.Windows.Forms.TextBox()
        Me.lblEntrevistador = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtFecEntr = New System.Windows.Forms.MaskedTextBox()
        Me.lblFecEntr = New System.Windows.Forms.Label()
        Me.optAptoSi = New System.Windows.Forms.RadioButton()
        Me.OptAptoNo = New System.Windows.Forms.RadioButton()
        Me.OptAptoPendiente = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbDNI_NIE.SuspendLayout()
        Me.GbInaem.SuspendLayout()
        Me.GbExperiencia.SuspendLayout()
        Me.GbUniforme.SuspendLayout()
        Me.GbEntrevista.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblApellido1
        '
        Me.LblApellido1.AutoSize = True
        Me.LblApellido1.Location = New System.Drawing.Point(22, 23)
        Me.LblApellido1.Name = "LblApellido1"
        Me.LblApellido1.Size = New System.Drawing.Size(76, 13)
        Me.LblApellido1.TabIndex = 1
        Me.LblApellido1.Text = "Primer Apellido"
        '
        'txtApellido1
        '
        Me.txtApellido1.Location = New System.Drawing.Point(118, 20)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(165, 20)
        Me.txtApellido1.TabIndex = 2
        '
        'txtApellido2
        '
        Me.txtApellido2.Location = New System.Drawing.Point(118, 59)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(165, 20)
        Me.txtApellido2.TabIndex = 4
        '
        'lblApellido2
        '
        Me.lblApellido2.AutoSize = True
        Me.lblApellido2.Location = New System.Drawing.Point(22, 62)
        Me.lblApellido2.Name = "lblApellido2"
        Me.lblApellido2.Size = New System.Drawing.Size(90, 13)
        Me.lblApellido2.TabIndex = 3
        Me.lblApellido2.Text = "Segundo Apellido"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(118, 94)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(165, 20)
        Me.txtNombre.TabIndex = 6
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(22, 97)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(475, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 118)
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'lblFNac
        '
        Me.lblFNac.AutoSize = True
        Me.lblFNac.Location = New System.Drawing.Point(22, 218)
        Me.lblFNac.Name = "lblFNac"
        Me.lblFNac.Size = New System.Drawing.Size(146, 13)
        Me.lblFNac.TabIndex = 8
        Me.lblFNac.Text = "Fecha y Lugar de Nacimiento"
        '
        'txtFNac
        '
        Me.txtFNac.Location = New System.Drawing.Point(174, 215)
        Me.txtFNac.Mask = "00/00/0000"
        Me.txtFNac.Name = "txtFNac"
        Me.txtFNac.Size = New System.Drawing.Size(67, 20)
        Me.txtFNac.TabIndex = 10
        Me.txtFNac.ValidatingType = GetType(Date)
        '
        'txtLugNac
        '
        Me.txtLugNac.Location = New System.Drawing.Point(247, 215)
        Me.txtLugNac.Name = "txtLugNac"
        Me.txtLugNac.Size = New System.Drawing.Size(214, 20)
        Me.txtLugNac.TabIndex = 12
        '
        'txtEdad
        '
        Me.txtEdad.Location = New System.Drawing.Point(509, 215)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.Size = New System.Drawing.Size(57, 20)
        Me.txtEdad.TabIndex = 14
        '
        'lblEdad
        '
        Me.lblEdad.AutoSize = True
        Me.lblEdad.Location = New System.Drawing.Point(472, 218)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(32, 13)
        Me.lblEdad.TabIndex = 13
        Me.lblEdad.Text = "Edad"
        '
        'lblDNI
        '
        Me.lblDNI.AutoSize = True
        Me.lblDNI.Location = New System.Drawing.Point(21, 45)
        Me.lblDNI.Name = "lblDNI"
        Me.lblDNI.Size = New System.Drawing.Size(44, 13)
        Me.lblDNI.TabIndex = 15
        Me.lblDNI.Text = "Numero"
        '
        'GbDNI_NIE
        '
        Me.GbDNI_NIE.Controls.Add(Me.optNIE)
        Me.GbDNI_NIE.Controls.Add(Me.txtDNI)
        Me.GbDNI_NIE.Controls.Add(Me.optDNI)
        Me.GbDNI_NIE.Controls.Add(Me.lblDNI)
        Me.GbDNI_NIE.Location = New System.Drawing.Point(25, 130)
        Me.GbDNI_NIE.Name = "GbDNI_NIE"
        Me.GbDNI_NIE.Size = New System.Drawing.Size(235, 69)
        Me.GbDNI_NIE.TabIndex = 18
        Me.GbDNI_NIE.TabStop = False
        Me.GbDNI_NIE.Text = "Seleccione el tipo de Documento que posee"
        '
        'optDNI
        '
        Me.optDNI.AutoSize = True
        Me.optDNI.Location = New System.Drawing.Point(23, 19)
        Me.optDNI.Name = "optDNI"
        Me.optDNI.Size = New System.Drawing.Size(44, 17)
        Me.optDNI.TabIndex = 0
        Me.optDNI.TabStop = True
        Me.optDNI.Text = "DNI"
        Me.optDNI.UseVisualStyleBackColor = True
        '
        'optNIE
        '
        Me.optNIE.AutoSize = True
        Me.optNIE.Location = New System.Drawing.Point(130, 19)
        Me.optNIE.Name = "optNIE"
        Me.optNIE.Size = New System.Drawing.Size(43, 17)
        Me.optNIE.TabIndex = 1
        Me.optNIE.TabStop = True
        Me.optNIE.Text = "NIE"
        Me.optNIE.UseVisualStyleBackColor = True
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(77, 255)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(384, 20)
        Me.txtDomicilio.TabIndex = 20
        '
        'lblDomicilio
        '
        Me.lblDomicilio.AutoSize = True
        Me.lblDomicilio.Location = New System.Drawing.Point(22, 258)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(49, 13)
        Me.lblDomicilio.TabIndex = 19
        Me.lblDomicilio.Text = "Domicilio"
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(509, 255)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(57, 20)
        Me.txtCP.TabIndex = 22
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Location = New System.Drawing.Point(472, 258)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(27, 13)
        Me.lblCP.TabIndex = 21
        Me.lblCP.Text = "C.P."
        '
        'txtPoblacion
        '
        Me.txtPoblacion.Location = New System.Drawing.Point(77, 289)
        Me.txtPoblacion.Name = "txtPoblacion"
        Me.txtPoblacion.Size = New System.Drawing.Size(164, 20)
        Me.txtPoblacion.TabIndex = 24
        '
        'lblPoblacion
        '
        Me.lblPoblacion.AutoSize = True
        Me.lblPoblacion.Location = New System.Drawing.Point(22, 292)
        Me.lblPoblacion.Name = "lblPoblacion"
        Me.lblPoblacion.Size = New System.Drawing.Size(54, 13)
        Me.lblPoblacion.TabIndex = 23
        Me.lblPoblacion.Text = "Poblacion"
        '
        'lblTel1
        '
        Me.lblTel1.AutoSize = True
        Me.lblTel1.Location = New System.Drawing.Point(278, 292)
        Me.lblTel1.Name = "lblTel1"
        Me.lblTel1.Size = New System.Drawing.Size(58, 13)
        Me.lblTel1.TabIndex = 25
        Me.lblTel1.Text = "Telefono 1"
        '
        'lblTel2
        '
        Me.lblTel2.AutoSize = True
        Me.lblTel2.Location = New System.Drawing.Point(435, 292)
        Me.lblTel2.Name = "lblTel2"
        Me.lblTel2.Size = New System.Drawing.Size(58, 13)
        Me.lblTel2.TabIndex = 27
        Me.lblTel2.Text = "Telefono 2"
        '
        'txtTel1
        '
        Me.txtTel1.Location = New System.Drawing.Point(342, 289)
        Me.txtTel1.Mask = "000-00-00-00"
        Me.txtTel1.Name = "txtTel1"
        Me.txtTel1.Size = New System.Drawing.Size(67, 20)
        Me.txtTel1.TabIndex = 29
        '
        'txtTel2
        '
        Me.txtTel2.Location = New System.Drawing.Point(499, 289)
        Me.txtTel2.Mask = "000-00-00-00"
        Me.txtTel2.Name = "txtTel2"
        Me.txtTel2.Size = New System.Drawing.Size(67, 20)
        Me.txtTel2.TabIndex = 30
        '
        'lblNumSS
        '
        Me.lblNumSS.AutoSize = True
        Me.lblNumSS.Location = New System.Drawing.Point(324, 149)
        Me.lblNumSS.Name = "lblNumSS"
        Me.lblNumSS.Size = New System.Drawing.Size(157, 13)
        Me.lblNumSS.TabIndex = 31
        Me.lblNumSS.Text = "Numero de La Seguridad Social"
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(93, 42)
        Me.txtDNI.Mask = "00000000A"
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(67, 20)
        Me.txtDNI.TabIndex = 33
        '
        'txtNumSS
        '
        Me.txtNumSS.Location = New System.Drawing.Point(342, 172)
        Me.txtNumSS.Mask = "00/00000000/00"
        Me.txtNumSS.Name = "txtNumSS"
        Me.txtNumSS.Size = New System.Drawing.Size(100, 20)
        Me.txtNumSS.TabIndex = 34
        '
        'GbInaem
        '
        Me.GbInaem.Controls.Add(Me.OptNo)
        Me.GbInaem.Controls.Add(Me.txtInFecha)
        Me.GbInaem.Controls.Add(Me.optSi)
        Me.GbInaem.Controls.Add(Me.lblInFecha)
        Me.GbInaem.Location = New System.Drawing.Point(25, 323)
        Me.GbInaem.Name = "GbInaem"
        Me.GbInaem.Size = New System.Drawing.Size(235, 69)
        Me.GbInaem.TabIndex = 35
        Me.GbInaem.TabStop = False
        Me.GbInaem.Text = "¿Está inscrito en laOficina de Empleo?"
        '
        'OptNo
        '
        Me.OptNo.AutoSize = True
        Me.OptNo.Location = New System.Drawing.Point(130, 19)
        Me.OptNo.Name = "OptNo"
        Me.OptNo.Size = New System.Drawing.Size(39, 17)
        Me.OptNo.TabIndex = 1
        Me.OptNo.TabStop = True
        Me.OptNo.Text = "No"
        Me.OptNo.UseVisualStyleBackColor = True
        '
        'txtInFecha
        '
        Me.txtInFecha.Location = New System.Drawing.Point(132, 42)
        Me.txtInFecha.Mask = "00/00/0000"
        Me.txtInFecha.Name = "txtInFecha"
        Me.txtInFecha.Size = New System.Drawing.Size(67, 20)
        Me.txtInFecha.TabIndex = 33
        Me.txtInFecha.ValidatingType = GetType(Date)
        '
        'optSi
        '
        Me.optSi.AutoSize = True
        Me.optSi.Location = New System.Drawing.Point(23, 19)
        Me.optSi.Name = "optSi"
        Me.optSi.Size = New System.Drawing.Size(36, 17)
        Me.optSi.TabIndex = 0
        Me.optSi.TabStop = True
        Me.optSi.Text = "Sí"
        Me.optSi.UseVisualStyleBackColor = True
        '
        'lblInFecha
        '
        Me.lblInFecha.AutoSize = True
        Me.lblInFecha.Location = New System.Drawing.Point(21, 45)
        Me.lblInFecha.Name = "lblInFecha"
        Me.lblInFecha.Size = New System.Drawing.Size(105, 13)
        Me.lblInFecha.TabIndex = 15
        Me.lblInFecha.Text = "Fecha de inscripción"
        '
        'lblNivelEstudios
        '
        Me.lblNivelEstudios.AutoSize = True
        Me.lblNivelEstudios.Location = New System.Drawing.Point(282, 323)
        Me.lblNivelEstudios.Name = "lblNivelEstudios"
        Me.lblNivelEstudios.Size = New System.Drawing.Size(102, 13)
        Me.lblNivelEstudios.TabIndex = 36
        Me.lblNivelEstudios.Text = "Estudios Realizados"
        '
        'txtNivelEstudios
        '
        Me.txtNivelEstudios.Location = New System.Drawing.Point(285, 339)
        Me.txtNivelEstudios.Multiline = True
        Me.txtNivelEstudios.Name = "txtNivelEstudios"
        Me.txtNivelEstudios.Size = New System.Drawing.Size(281, 53)
        Me.txtNivelEstudios.TabIndex = 37
        '
        'GbExperiencia
        '
        Me.GbExperiencia.Controls.Add(Me.ListBox1)
        Me.GbExperiencia.Controls.Add(Me.ComboBox1)
        Me.GbExperiencia.Location = New System.Drawing.Point(25, 409)
        Me.GbExperiencia.Name = "GbExperiencia"
        Me.GbExperiencia.Size = New System.Drawing.Size(235, 130)
        Me.GbExperiencia.TabIndex = 34
        Me.GbExperiencia.TabStop = False
        Me.GbExperiencia.Text = "Sectores Experiencia Laboral"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"HOSTELERÍA", "PANADERÍA", "PASTELERÍA", "COMERCIO PANADERÍA PASTELERÍA", "COMERCIO VARIOS", "OPERARIO DE PRODUCCIÓN", "OTROS"})
        Me.ComboBox1.Location = New System.Drawing.Point(7, 20)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(209, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(7, 48)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(209, 56)
        Me.ListBox1.TabIndex = 1
        '
        'GbUniforme
        '
        Me.GbUniforme.Controls.Add(Me.cboTallaZapato)
        Me.GbUniforme.Controls.Add(Me.CboTallaPantalon)
        Me.GbUniforme.Controls.Add(Me.lblNumZapato)
        Me.GbUniforme.Controls.Add(Me.lblTallaPantalon)
        Me.GbUniforme.Controls.Add(Me.CboTallaCamiseta)
        Me.GbUniforme.Controls.Add(Me.lblTallaCamiseta)
        Me.GbUniforme.Location = New System.Drawing.Point(327, 409)
        Me.GbUniforme.Name = "GbUniforme"
        Me.GbUniforme.Size = New System.Drawing.Size(172, 130)
        Me.GbUniforme.TabIndex = 35
        Me.GbUniforme.TabStop = False
        Me.GbUniforme.Text = "Tallaje Uniforme"
        '
        'lblTallaCamiseta
        '
        Me.lblTallaCamiseta.AutoSize = True
        Me.lblTallaCamiseta.Location = New System.Drawing.Point(12, 28)
        Me.lblTallaCamiseta.Name = "lblTallaCamiseta"
        Me.lblTallaCamiseta.Size = New System.Drawing.Size(50, 13)
        Me.lblTallaCamiseta.TabIndex = 25
        Me.lblTallaCamiseta.Text = "Camiseta"
        '
        'CboTallaCamiseta
        '
        Me.CboTallaCamiseta.FormattingEnabled = True
        Me.CboTallaCamiseta.Items.AddRange(New Object() {"XS", "S", "M", "L", "XL", "XXL", "XXXL"})
        Me.CboTallaCamiseta.Location = New System.Drawing.Point(89, 20)
        Me.CboTallaCamiseta.Name = "CboTallaCamiseta"
        Me.CboTallaCamiseta.Size = New System.Drawing.Size(69, 21)
        Me.CboTallaCamiseta.TabIndex = 26
        '
        'lblTallaPantalon
        '
        Me.lblTallaPantalon.AutoSize = True
        Me.lblTallaPantalon.Location = New System.Drawing.Point(12, 60)
        Me.lblTallaPantalon.Name = "lblTallaPantalon"
        Me.lblTallaPantalon.Size = New System.Drawing.Size(49, 13)
        Me.lblTallaPantalon.TabIndex = 27
        Me.lblTallaPantalon.Text = "Pantalon"
        '
        'lblNumZapato
        '
        Me.lblNumZapato.AutoSize = True
        Me.lblNumZapato.Location = New System.Drawing.Point(12, 95)
        Me.lblNumZapato.Name = "lblNumZapato"
        Me.lblNumZapato.Size = New System.Drawing.Size(45, 13)
        Me.lblNumZapato.TabIndex = 29
        Me.lblNumZapato.Text = "Calzado"
        '
        'CboTallaPantalon
        '
        Me.CboTallaPantalon.FormattingEnabled = True
        Me.CboTallaPantalon.Items.AddRange(New Object() {"XS", "S", "M", "L", "XL", "XXL", "XXXL"})
        Me.CboTallaPantalon.Location = New System.Drawing.Point(89, 57)
        Me.CboTallaPantalon.Name = "CboTallaPantalon"
        Me.CboTallaPantalon.Size = New System.Drawing.Size(69, 21)
        Me.CboTallaPantalon.TabIndex = 31
        '
        'cboTallaZapato
        '
        Me.cboTallaZapato.FormattingEnabled = True
        Me.cboTallaZapato.Items.AddRange(New Object() {"XS", "S", "M", "L", "XL", "XXL", "XXXL"})
        Me.cboTallaZapato.Location = New System.Drawing.Point(89, 92)
        Me.cboTallaZapato.Name = "cboTallaZapato"
        Me.cboTallaZapato.Size = New System.Drawing.Size(69, 21)
        Me.cboTallaZapato.TabIndex = 32
        '
        'GbEntrevista
        '
        Me.GbEntrevista.Controls.Add(Me.OptAptoPendiente)
        Me.GbEntrevista.Controls.Add(Me.OptAptoNo)
        Me.GbEntrevista.Controls.Add(Me.optAptoSi)
        Me.GbEntrevista.Controls.Add(Me.txtFecEntr)
        Me.GbEntrevista.Controls.Add(Me.lblFecEntr)
        Me.GbEntrevista.Controls.Add(Me.TextBox1)
        Me.GbEntrevista.Controls.Add(Me.txtEntrevistador)
        Me.GbEntrevista.Controls.Add(Me.lblEntrevistador)
        Me.GbEntrevista.Location = New System.Drawing.Point(25, 547)
        Me.GbEntrevista.Name = "GbEntrevista"
        Me.GbEntrevista.Size = New System.Drawing.Size(519, 165)
        Me.GbEntrevista.TabIndex = 35
        Me.GbEntrevista.TabStop = False
        Me.GbEntrevista.Text = "Entrevista"
        '
        'txtEntrevistador
        '
        Me.txtEntrevistador.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.txtEntrevistador.Location = New System.Drawing.Point(79, 19)
        Me.txtEntrevistador.Name = "txtEntrevistador"
        Me.txtEntrevistador.Size = New System.Drawing.Size(164, 20)
        Me.txtEntrevistador.TabIndex = 26
        '
        'lblEntrevistador
        '
        Me.lblEntrevistador.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.lblEntrevistador.AutoSize = True
        Me.lblEntrevistador.Location = New System.Drawing.Point(6, 22)
        Me.lblEntrevistador.Name = "lblEntrevistador"
        Me.lblEntrevistador.Size = New System.Drawing.Size(69, 13)
        Me.lblEntrevistador.TabIndex = 25
        Me.lblEntrevistador.Text = "Entrevistador"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(23, 59)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(482, 78)
        Me.TextBox1.TabIndex = 38
        '
        'txtFecEntr
        '
        Me.txtFecEntr.Location = New System.Drawing.Point(407, 19)
        Me.txtFecEntr.Mask = "00/00/0000"
        Me.txtFecEntr.Name = "txtFecEntr"
        Me.txtFecEntr.Size = New System.Drawing.Size(67, 20)
        Me.txtFecEntr.TabIndex = 40
        Me.txtFecEntr.ValidatingType = GetType(Date)
        '
        'lblFecEntr
        '
        Me.lblFecEntr.AutoSize = True
        Me.lblFecEntr.Location = New System.Drawing.Point(288, 22)
        Me.lblFecEntr.Name = "lblFecEntr"
        Me.lblFecEntr.Size = New System.Drawing.Size(113, 13)
        Me.lblFecEntr.TabIndex = 39
        Me.lblFecEntr.Text = "Fecha de la Entrevista"
        '
        'optAptoSi
        '
        Me.optAptoSi.AutoSize = True
        Me.optAptoSi.Location = New System.Drawing.Point(79, 142)
        Me.optAptoSi.Name = "optAptoSi"
        Me.optAptoSi.Size = New System.Drawing.Size(47, 17)
        Me.optAptoSi.TabIndex = 41
        Me.optAptoSi.TabStop = True
        Me.optAptoSi.Text = "Apto"
        Me.optAptoSi.UseVisualStyleBackColor = True
        '
        'OptAptoNo
        '
        Me.OptAptoNo.AutoSize = True
        Me.OptAptoNo.Location = New System.Drawing.Point(222, 142)
        Me.OptAptoNo.Name = "OptAptoNo"
        Me.OptAptoNo.Size = New System.Drawing.Size(64, 17)
        Me.OptAptoNo.TabIndex = 42
        Me.OptAptoNo.TabStop = True
        Me.OptAptoNo.Text = "No Apto"
        Me.OptAptoNo.UseVisualStyleBackColor = True
        '
        'OptAptoPendiente
        '
        Me.OptAptoPendiente.AutoSize = True
        Me.OptAptoPendiente.Location = New System.Drawing.Point(344, 142)
        Me.OptAptoPendiente.Name = "OptAptoPendiente"
        Me.OptAptoPendiente.Size = New System.Drawing.Size(73, 17)
        Me.OptAptoPendiente.TabIndex = 43
        Me.OptAptoPendiente.TabStop = True
        Me.OptAptoPendiente.Text = "Pendiente"
        Me.OptAptoPendiente.UseVisualStyleBackColor = True
        '
        'FrmFichas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 733)
        Me.Controls.Add(Me.GbEntrevista)
        Me.Controls.Add(Me.GbUniforme)
        Me.Controls.Add(Me.GbExperiencia)
        Me.Controls.Add(Me.txtNivelEstudios)
        Me.Controls.Add(Me.lblNivelEstudios)
        Me.Controls.Add(Me.GbInaem)
        Me.Controls.Add(Me.txtNumSS)
        Me.Controls.Add(Me.lblNumSS)
        Me.Controls.Add(Me.txtTel2)
        Me.Controls.Add(Me.txtTel1)
        Me.Controls.Add(Me.lblTel2)
        Me.Controls.Add(Me.lblTel1)
        Me.Controls.Add(Me.txtPoblacion)
        Me.Controls.Add(Me.lblPoblacion)
        Me.Controls.Add(Me.txtCP)
        Me.Controls.Add(Me.lblCP)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.lblDomicilio)
        Me.Controls.Add(Me.GbDNI_NIE)
        Me.Controls.Add(Me.txtEdad)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.txtLugNac)
        Me.Controls.Add(Me.txtFNac)
        Me.Controls.Add(Me.lblFNac)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtApellido2)
        Me.Controls.Add(Me.lblApellido2)
        Me.Controls.Add(Me.txtApellido1)
        Me.Controls.Add(Me.LblApellido1)
        Me.Name = "FrmFichas"
        Me.Text = "FrmFichas"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbDNI_NIE.ResumeLayout(False)
        Me.GbDNI_NIE.PerformLayout()
        Me.GbInaem.ResumeLayout(False)
        Me.GbInaem.PerformLayout()
        Me.GbExperiencia.ResumeLayout(False)
        Me.GbUniforme.ResumeLayout(False)
        Me.GbUniforme.PerformLayout()
        Me.GbEntrevista.ResumeLayout(False)
        Me.GbEntrevista.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblApellido1 As System.Windows.Forms.Label
    Friend WithEvents txtApellido1 As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents lblApellido2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblFNac As System.Windows.Forms.Label
    Friend WithEvents txtFNac As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtLugNac As System.Windows.Forms.TextBox
    Friend WithEvents txtEdad As System.Windows.Forms.TextBox
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents lblDNI As System.Windows.Forms.Label
    Friend WithEvents GbDNI_NIE As System.Windows.Forms.GroupBox
    Friend WithEvents optNIE As System.Windows.Forms.RadioButton
    Friend WithEvents txtDNI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents optDNI As System.Windows.Forms.RadioButton
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents lblDomicilio As System.Windows.Forms.Label
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents txtPoblacion As System.Windows.Forms.TextBox
    Friend WithEvents lblPoblacion As System.Windows.Forms.Label
    Friend WithEvents lblTel1 As System.Windows.Forms.Label
    Friend WithEvents lblTel2 As System.Windows.Forms.Label
    Friend WithEvents txtTel1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTel2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblNumSS As System.Windows.Forms.Label
    Friend WithEvents txtNumSS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GbInaem As System.Windows.Forms.GroupBox
    Friend WithEvents OptNo As System.Windows.Forms.RadioButton
    Friend WithEvents txtInFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents optSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblInFecha As System.Windows.Forms.Label
    Friend WithEvents lblNivelEstudios As System.Windows.Forms.Label
    Friend WithEvents txtNivelEstudios As System.Windows.Forms.TextBox
    Friend WithEvents GbExperiencia As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GbUniforme As System.Windows.Forms.GroupBox
    Friend WithEvents cboTallaZapato As System.Windows.Forms.ComboBox
    Friend WithEvents CboTallaPantalon As System.Windows.Forms.ComboBox
    Friend WithEvents lblNumZapato As System.Windows.Forms.Label
    Friend WithEvents lblTallaPantalon As System.Windows.Forms.Label
    Friend WithEvents CboTallaCamiseta As System.Windows.Forms.ComboBox
    Friend WithEvents lblTallaCamiseta As System.Windows.Forms.Label
    Friend WithEvents GbEntrevista As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecEntr As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblFecEntr As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtEntrevistador As System.Windows.Forms.TextBox
    Friend WithEvents lblEntrevistador As System.Windows.Forms.Label
    Friend WithEvents OptAptoPendiente As System.Windows.Forms.RadioButton
    Friend WithEvents OptAptoNo As System.Windows.Forms.RadioButton
    Friend WithEvents optAptoSi As System.Windows.Forms.RadioButton
End Class
