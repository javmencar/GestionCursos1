<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModulos
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
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdNuevoModulo = New System.Windows.Forms.Button()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstModulos = New System.Windows.Forms.ListBox()
        Me.lblLstModulos = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(425, 161)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(118, 51)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Salir de Aquí"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdNuevoModulo
        '
        Me.cmdNuevoModulo.Location = New System.Drawing.Point(425, 104)
        Me.cmdNuevoModulo.Name = "cmdNuevoModulo"
        Me.cmdNuevoModulo.Size = New System.Drawing.Size(118, 51)
        Me.cmdNuevoModulo.TabIndex = 8
        Me.cmdNuevoModulo.Text = "Crear un Nuevo Modulo"
        Me.cmdNuevoModulo.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.Location = New System.Drawing.Point(425, 47)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(118, 51)
        Me.cmdModificar.TabIndex = 7
        Me.cmdModificar.Text = "Modificar el Modulo seleccionado"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstModulos)
        Me.GroupBox1.Controls.Add(Me.lblLstModulos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(407, 409)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'lstModulos
        '
        Me.lstModulos.FormattingEnabled = True
        Me.lstModulos.Location = New System.Drawing.Point(20, 47)
        Me.lstModulos.Name = "lstModulos"
        Me.lstModulos.Size = New System.Drawing.Size(381, 316)
        Me.lstModulos.TabIndex = 0
        '
        'lblLstModulos
        '
        Me.lblLstModulos.AutoSize = True
        Me.lblLstModulos.Location = New System.Drawing.Point(17, 16)
        Me.lblLstModulos.Name = "lblLstModulos"
        Me.lblLstModulos.Size = New System.Drawing.Size(150, 13)
        Me.lblLstModulos.TabIndex = 1
        Me.lblLstModulos.Text = "Listado de Modulos Existentes"
        '
        'FrmModulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 486)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdNuevoModulo)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmModulos"
        Me.Text = "FrmModulos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevoModulo As System.Windows.Forms.Button
    Friend WithEvents cmdModificar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstModulos As System.Windows.Forms.ListBox
    Friend WithEvents lblLstModulos As System.Windows.Forms.Label
End Class
