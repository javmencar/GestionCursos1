<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCursos
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
        Me.LstCursosOModulos = New System.Windows.Forms.ListBox()
        Me.lblLstCursos = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdNuevoCurso = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdBorrarCurso = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LstCursosOModulos
        '
        Me.LstCursosOModulos.FormattingEnabled = True
        Me.LstCursosOModulos.Location = New System.Drawing.Point(20, 47)
        Me.LstCursosOModulos.Name = "LstCursosOModulos"
        Me.LstCursosOModulos.Size = New System.Drawing.Size(361, 95)
        Me.LstCursosOModulos.TabIndex = 0
        '
        'lblLstCursos
        '
        Me.lblLstCursos.AutoSize = True
        Me.lblLstCursos.Location = New System.Drawing.Point(17, 16)
        Me.lblLstCursos.Name = "lblLstCursos"
        Me.lblLstCursos.Size = New System.Drawing.Size(142, 13)
        Me.lblLstCursos.TabIndex = 1
        Me.lblLstCursos.Text = "Listado de Cursos Existentes"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LstCursosOModulos)
        Me.GroupBox1.Controls.Add(Me.lblLstCursos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(387, 172)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'cmdModificar
        '
        Me.cmdModificar.Location = New System.Drawing.Point(420, 97)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(118, 51)
        Me.cmdModificar.TabIndex = 3
        Me.cmdModificar.Text = "Modificar el curso seleccionado"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdNuevoCurso
        '
        Me.cmdNuevoCurso.Location = New System.Drawing.Point(420, 40)
        Me.cmdNuevoCurso.Name = "cmdNuevoCurso"
        Me.cmdNuevoCurso.Size = New System.Drawing.Size(118, 51)
        Me.cmdNuevoCurso.TabIndex = 4
        Me.cmdNuevoCurso.Text = "Crear un Nuevo Curso"
        Me.cmdNuevoCurso.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(420, 211)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(118, 51)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Salir de Aquí"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdBorrarCurso
        '
        Me.cmdBorrarCurso.Location = New System.Drawing.Point(420, 154)
        Me.cmdBorrarCurso.Name = "cmdBorrarCurso"
        Me.cmdBorrarCurso.Size = New System.Drawing.Size(118, 51)
        Me.cmdBorrarCurso.TabIndex = 6
        Me.cmdBorrarCurso.Text = "Borrar Curso Selecionado"
        Me.cmdBorrarCurso.UseVisualStyleBackColor = True
        '
        'FrmCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 350)
        Me.Controls.Add(Me.cmdBorrarCurso)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdNuevoCurso)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmCursos"
        Me.Text = "FrmCursos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LstCursosOModulos As System.Windows.Forms.ListBox
    Friend WithEvents lblLstCursos As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdModificar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevoCurso As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdBorrarCurso As System.Windows.Forms.Button
End Class
