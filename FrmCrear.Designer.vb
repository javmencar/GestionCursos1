<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrear
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
        Me.cmdCurso = New System.Windows.Forms.Button()
        Me.cmdModulos = New System.Windows.Forms.Button()
        Me.cmdAlumnos = New System.Windows.Forms.Button()
        Me.CmdProfesores = New System.Windows.Forms.Button()
        Me.lblCrear = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdCurso
        '
        Me.cmdCurso.Location = New System.Drawing.Point(12, 69)
        Me.cmdCurso.Name = "cmdCurso"
        Me.cmdCurso.Size = New System.Drawing.Size(94, 60)
        Me.cmdCurso.TabIndex = 0
        Me.cmdCurso.Text = "Cursos"
        Me.cmdCurso.UseVisualStyleBackColor = True
        '
        'cmdModulos
        '
        Me.cmdModulos.Location = New System.Drawing.Point(121, 69)
        Me.cmdModulos.Name = "cmdModulos"
        Me.cmdModulos.Size = New System.Drawing.Size(100, 60)
        Me.cmdModulos.TabIndex = 1
        Me.cmdModulos.Text = "Modulos"
        Me.cmdModulos.UseVisualStyleBackColor = True
        '
        'cmdAlumnos
        '
        Me.cmdAlumnos.AccessibleDescription = "cmdAlumnos"
        Me.cmdAlumnos.Location = New System.Drawing.Point(230, 69)
        Me.cmdAlumnos.Name = "cmdAlumnos"
        Me.cmdAlumnos.Size = New System.Drawing.Size(105, 60)
        Me.cmdAlumnos.TabIndex = 2
        Me.cmdAlumnos.Text = "Fichas de Alumnos"
        Me.cmdAlumnos.UseVisualStyleBackColor = True
        '
        'CmdProfesores
        '
        Me.CmdProfesores.Location = New System.Drawing.Point(352, 69)
        Me.CmdProfesores.Name = "CmdProfesores"
        Me.CmdProfesores.Size = New System.Drawing.Size(112, 60)
        Me.CmdProfesores.TabIndex = 3
        Me.CmdProfesores.Text = "Fichas de Profesores"
        Me.CmdProfesores.UseVisualStyleBackColor = True
        '
        'lblCrear
        '
        Me.lblCrear.AutoSize = True
        Me.lblCrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrear.Location = New System.Drawing.Point(24, 13)
        Me.lblCrear.Name = "lblCrear"
        Me.lblCrear.Size = New System.Drawing.Size(440, 25)
        Me.lblCrear.TabIndex = 4
        Me.lblCrear.Text = "¿Que es lo que desea crear o modificar?"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(174, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 60)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Ficha de Candidato a cursos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmCrear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 239)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblCrear)
        Me.Controls.Add(Me.CmdProfesores)
        Me.Controls.Add(Me.cmdAlumnos)
        Me.Controls.Add(Me.cmdModulos)
        Me.Controls.Add(Me.cmdCurso)
        Me.Name = "FrmCrear"
        Me.Text = "FrmCrear"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCurso As System.Windows.Forms.Button
    Friend WithEvents cmdModulos As System.Windows.Forms.Button
    Friend WithEvents cmdAlumnos As System.Windows.Forms.Button
    Friend WithEvents CmdProfesores As System.Windows.Forms.Button
    Friend WithEvents lblCrear As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
