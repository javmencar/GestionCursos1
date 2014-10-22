<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarCursos
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
        Me.lblCodigoCurso = New System.Windows.Forms.Label()
        Me.txtCodcur = New System.Windows.Forms.TextBox()
        Me.txtNombreCurso = New System.Windows.Forms.TextBox()
        Me.lblNombreCurso = New System.Windows.Forms.Label()
        Me.txtHorasCurso = New System.Windows.Forms.TextBox()
        Me.lblNumHoras = New System.Windows.Forms.Label()
        Me.lblModulos = New System.Windows.Forms.Label()
        Me.GbModulos = New System.Windows.Forms.GroupBox()
        Me.cmdQuitarModListbox = New System.Windows.Forms.Button()
        Me.cmdNuevoModulo = New System.Windows.Forms.Button()
        Me.cmdAñadirModulo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboModulos = New System.Windows.Forms.ComboBox()
        Me.LstModulos = New System.Windows.Forms.ListBox()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.GbModulos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCodigoCurso
        '
        Me.lblCodigoCurso.AutoSize = True
        Me.lblCodigoCurso.Location = New System.Drawing.Point(12, 27)
        Me.lblCodigoCurso.Name = "lblCodigoCurso"
        Me.lblCodigoCurso.Size = New System.Drawing.Size(165, 13)
        Me.lblCodigoCurso.TabIndex = 0
        Me.lblCodigoCurso.Text = "Código del curso en formato DGA"
        '
        'txtCodcur
        '
        Me.txtCodcur.Location = New System.Drawing.Point(183, 24)
        Me.txtCodcur.Name = "txtCodcur"
        Me.txtCodcur.Size = New System.Drawing.Size(94, 20)
        Me.txtCodcur.TabIndex = 1
        '
        'txtNombreCurso
        '
        Me.txtNombreCurso.Location = New System.Drawing.Point(183, 62)
        Me.txtNombreCurso.Name = "txtNombreCurso"
        Me.txtNombreCurso.Size = New System.Drawing.Size(260, 20)
        Me.txtNombreCurso.TabIndex = 3
        '
        'lblNombreCurso
        '
        Me.lblNombreCurso.AutoSize = True
        Me.lblNombreCurso.Location = New System.Drawing.Point(12, 62)
        Me.lblNombreCurso.Name = "lblNombreCurso"
        Me.lblNombreCurso.Size = New System.Drawing.Size(136, 13)
        Me.lblNombreCurso.TabIndex = 2
        Me.lblNombreCurso.Text = "Nombre completo del curso"
        '
        'txtHorasCurso
        '
        Me.txtHorasCurso.Location = New System.Drawing.Point(206, 97)
        Me.txtHorasCurso.Name = "txtHorasCurso"
        Me.txtHorasCurso.Size = New System.Drawing.Size(71, 20)
        Me.txtHorasCurso.TabIndex = 5
        '
        'lblNumHoras
        '
        Me.lblNumHoras.AutoSize = True
        Me.lblNumHoras.Location = New System.Drawing.Point(12, 100)
        Me.lblNumHoras.Name = "lblNumHoras"
        Me.lblNumHoras.Size = New System.Drawing.Size(188, 13)
        Me.lblNumHoras.TabIndex = 4
        Me.lblNumHoras.Text = "Duracion completa del curso en Horas"
        '
        'lblModulos
        '
        Me.lblModulos.AutoSize = True
        Me.lblModulos.Location = New System.Drawing.Point(3, 17)
        Me.lblModulos.Name = "lblModulos"
        Me.lblModulos.Size = New System.Drawing.Size(201, 13)
        Me.lblModulos.TabIndex = 6
        Me.lblModulos.Text = "Modulos Disponibles para añadir al Curso"
        '
        'GbModulos
        '
        Me.GbModulos.Controls.Add(Me.cmdQuitarModListbox)
        Me.GbModulos.Controls.Add(Me.cmdNuevoModulo)
        Me.GbModulos.Controls.Add(Me.cmdAñadirModulo)
        Me.GbModulos.Controls.Add(Me.Label1)
        Me.GbModulos.Controls.Add(Me.CboModulos)
        Me.GbModulos.Controls.Add(Me.LstModulos)
        Me.GbModulos.Controls.Add(Me.lblModulos)
        Me.GbModulos.Location = New System.Drawing.Point(15, 133)
        Me.GbModulos.Name = "GbModulos"
        Me.GbModulos.Size = New System.Drawing.Size(367, 293)
        Me.GbModulos.TabIndex = 7
        Me.GbModulos.TabStop = False
        Me.GbModulos.Text = "Modulos Del Curso"
        '
        'cmdQuitarModListbox
        '
        Me.cmdQuitarModListbox.Location = New System.Drawing.Point(252, 137)
        Me.cmdQuitarModListbox.Name = "cmdQuitarModListbox"
        Me.cmdQuitarModListbox.Size = New System.Drawing.Size(109, 54)
        Me.cmdQuitarModListbox.TabIndex = 12
        Me.cmdQuitarModListbox.Text = "Quitar un Modulo Ya añadido del Listado"
        Me.cmdQuitarModListbox.UseVisualStyleBackColor = True
        '
        'cmdNuevoModulo
        '
        Me.cmdNuevoModulo.Location = New System.Drawing.Point(252, 197)
        Me.cmdNuevoModulo.Name = "cmdNuevoModulo"
        Me.cmdNuevoModulo.Size = New System.Drawing.Size(109, 54)
        Me.cmdNuevoModulo.TabIndex = 11
        Me.cmdNuevoModulo.Text = "Crear Un Modulo Nuevo y Añadirlo al Listado"
        Me.cmdNuevoModulo.UseVisualStyleBackColor = True
        '
        'cmdAñadirModulo
        '
        Me.cmdAñadirModulo.Location = New System.Drawing.Point(252, 61)
        Me.cmdAñadirModulo.Name = "cmdAñadirModulo"
        Me.cmdAñadirModulo.Size = New System.Drawing.Size(109, 70)
        Me.cmdAñadirModulo.TabIndex = 10
        Me.cmdAñadirModulo.Text = "Añadir el Modulo Seleccionado del Menu deplegable al Listado"
        Me.cmdAñadirModulo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Listado de Modulos Añadidos Hasta Ahora"
        '
        'CboModulos
        '
        Me.CboModulos.FormattingEnabled = True
        Me.CboModulos.Location = New System.Drawing.Point(6, 34)
        Me.CboModulos.Name = "CboModulos"
        Me.CboModulos.Size = New System.Drawing.Size(336, 21)
        Me.CboModulos.TabIndex = 8
        '
        'LstModulos
        '
        Me.LstModulos.FormattingEnabled = True
        Me.LstModulos.Location = New System.Drawing.Point(6, 93)
        Me.LstModulos.Name = "LstModulos"
        Me.LstModulos.Size = New System.Drawing.Size(224, 173)
        Me.LstModulos.TabIndex = 7
        '
        'cmdModificar
        '
        Me.cmdModificar.Location = New System.Drawing.Point(412, 100)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(109, 39)
        Me.cmdModificar.TabIndex = 8
        Me.cmdModificar.Text = "crear/modificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(412, 210)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(109, 39)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Cancelar "
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'FrmModificarCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 438)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.GbModulos)
        Me.Controls.Add(Me.txtHorasCurso)
        Me.Controls.Add(Me.lblNumHoras)
        Me.Controls.Add(Me.txtNombreCurso)
        Me.Controls.Add(Me.lblNombreCurso)
        Me.Controls.Add(Me.txtCodcur)
        Me.Controls.Add(Me.lblCodigoCurso)
        Me.Name = "FrmModificarCursos"
        Me.Text = "FrmModificarCursos"
        Me.GbModulos.ResumeLayout(False)
        Me.GbModulos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCodigoCurso As System.Windows.Forms.Label
    Friend WithEvents txtCodcur As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCurso As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreCurso As System.Windows.Forms.Label
    Friend WithEvents txtHorasCurso As System.Windows.Forms.TextBox
    Friend WithEvents lblNumHoras As System.Windows.Forms.Label
    Friend WithEvents lblModulos As System.Windows.Forms.Label
    Friend WithEvents GbModulos As System.Windows.Forms.GroupBox
    Friend WithEvents cmdQuitarModListbox As System.Windows.Forms.Button
    Friend WithEvents cmdNuevoModulo As System.Windows.Forms.Button
    Friend WithEvents cmdAñadirModulo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboModulos As System.Windows.Forms.ComboBox
    Friend WithEvents LstModulos As System.Windows.Forms.ListBox
    Friend WithEvents cmdModificar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
End Class
