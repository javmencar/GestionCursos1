<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarModulos
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
        Me.txtHorasCurso = New System.Windows.Forms.TextBox()
        Me.lblNumHoras = New System.Windows.Forms.Label()
        Me.txtNombreCurso = New System.Windows.Forms.TextBox()
        Me.lblNombreModulo = New System.Windows.Forms.Label()
        Me.txtIdModulos = New System.Windows.Forms.TextBox()
        Me.lblIdModulo = New System.Windows.Forms.Label()
        Me.CmdModificar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContenidoModulo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtHorasCurso
        '
        Me.txtHorasCurso.Location = New System.Drawing.Point(215, 98)
        Me.txtHorasCurso.Name = "txtHorasCurso"
        Me.txtHorasCurso.Size = New System.Drawing.Size(71, 20)
        Me.txtHorasCurso.TabIndex = 11
        '
        'lblNumHoras
        '
        Me.lblNumHoras.AutoSize = True
        Me.lblNumHoras.Location = New System.Drawing.Point(12, 101)
        Me.lblNumHoras.Name = "lblNumHoras"
        Me.lblNumHoras.Size = New System.Drawing.Size(197, 13)
        Me.lblNumHoras.TabIndex = 10
        Me.lblNumHoras.Text = "Duracion completa del Modulo en Horas"
        '
        'txtNombreCurso
        '
        Me.txtNombreCurso.Location = New System.Drawing.Point(163, 60)
        Me.txtNombreCurso.Name = "txtNombreCurso"
        Me.txtNombreCurso.Size = New System.Drawing.Size(341, 20)
        Me.txtNombreCurso.TabIndex = 9
        '
        'lblNombreModulo
        '
        Me.lblNombreModulo.AutoSize = True
        Me.lblNombreModulo.Location = New System.Drawing.Point(12, 63)
        Me.lblNombreModulo.Name = "lblNombreModulo"
        Me.lblNombreModulo.Size = New System.Drawing.Size(145, 13)
        Me.lblNombreModulo.TabIndex = 8
        Me.lblNombreModulo.Text = "Nombre completo del Modulo"
        '
        'txtIdModulos
        '
        Me.txtIdModulos.Enabled = False
        Me.txtIdModulos.Location = New System.Drawing.Point(34, 25)
        Me.txtIdModulos.Name = "txtIdModulos"
        Me.txtIdModulos.Size = New System.Drawing.Size(35, 20)
        Me.txtIdModulos.TabIndex = 7
        '
        'lblIdModulo
        '
        Me.lblIdModulo.AutoSize = True
        Me.lblIdModulo.Location = New System.Drawing.Point(12, 28)
        Me.lblIdModulo.Name = "lblIdModulo"
        Me.lblIdModulo.Size = New System.Drawing.Size(16, 13)
        Me.lblIdModulo.TabIndex = 6
        Me.lblIdModulo.Text = "Id"
        '
        'CmdModificar
        '
        Me.CmdModificar.Location = New System.Drawing.Point(139, 311)
        Me.CmdModificar.Name = "CmdModificar"
        Me.CmdModificar.Size = New System.Drawing.Size(88, 23)
        Me.CmdModificar.TabIndex = 12
        Me.CmdModificar.Text = "modificar/crear"
        Me.CmdModificar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(288, 311)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 13
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(67, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Contenido del módulo"
        '
        'txtContenidoModulo
        '
        Me.txtContenidoModulo.Location = New System.Drawing.Point(67, 148)
        Me.txtContenidoModulo.Multiline = True
        Me.txtContenidoModulo.Name = "txtContenidoModulo"
        Me.txtContenidoModulo.Size = New System.Drawing.Size(381, 134)
        Me.txtContenidoModulo.TabIndex = 14
        '
        'FrmModificarModulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 364)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtContenidoModulo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdModificar)
        Me.Controls.Add(Me.txtHorasCurso)
        Me.Controls.Add(Me.lblNumHoras)
        Me.Controls.Add(Me.txtNombreCurso)
        Me.Controls.Add(Me.lblNombreModulo)
        Me.Controls.Add(Me.txtIdModulos)
        Me.Controls.Add(Me.lblIdModulo)
        Me.Name = "FrmModificarModulos"
        Me.Text = "FrmModificarModulos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHorasCurso As System.Windows.Forms.TextBox
    Friend WithEvents lblNumHoras As System.Windows.Forms.Label
    Friend WithEvents txtNombreCurso As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreModulo As System.Windows.Forms.Label
    Friend WithEvents txtIdModulos As System.Windows.Forms.TextBox
    Friend WithEvents lblIdModulo As System.Windows.Forms.Label
    Friend WithEvents CmdModificar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtContenidoModulo As System.Windows.Forms.TextBox
End Class
