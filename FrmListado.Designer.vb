<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListado
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
        Me.components = New System.ComponentModel.Container()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdBorrar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.GbBuscar = New System.Windows.Forms.GroupBox()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.TxtCampo = New System.Windows.Forms.TextBox()
        Me.LblCampo = New System.Windows.Forms.Label()
        Me.CboFiltro = New System.Windows.Forms.ComboBox()
        Me.GestionCursosDataSet = New GestionCursos_0._1.GestionCursosDataSet()
        Me.GestionCursosDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GbBuscar.SuspendLayout()
        CType(Me.GestionCursosDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GestionCursosDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(13, 35)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(668, 298)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Location = New System.Drawing.Point(687, 89)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(121, 48)
        Me.cmdNuevo.TabIndex = 1
        Me.cmdNuevo.Text = "Nuevo"
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.Location = New System.Drawing.Point(687, 153)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(121, 48)
        Me.cmdModificar.TabIndex = 2
        Me.cmdModificar.Text = "Modificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdBorrar
        '
        Me.cmdBorrar.Location = New System.Drawing.Point(687, 219)
        Me.cmdBorrar.Name = "cmdBorrar"
        Me.cmdBorrar.Size = New System.Drawing.Size(121, 48)
        Me.cmdBorrar.TabIndex = 3
        Me.cmdBorrar.Text = "Borrar"
        Me.cmdBorrar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(687, 285)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(121, 48)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'GbBuscar
        '
        Me.GbBuscar.Controls.Add(Me.cmdBuscar)
        Me.GbBuscar.Controls.Add(Me.TxtCampo)
        Me.GbBuscar.Controls.Add(Me.LblCampo)
        Me.GbBuscar.Controls.Add(Me.CboFiltro)
        Me.GbBuscar.Location = New System.Drawing.Point(37, 386)
        Me.GbBuscar.Name = "GbBuscar"
        Me.GbBuscar.Size = New System.Drawing.Size(627, 100)
        Me.GbBuscar.TabIndex = 5
        Me.GbBuscar.TabStop = False
        Me.GbBuscar.Text = "BUSCAR POR"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(555, 11)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(66, 41)
        Me.cmdBuscar.TabIndex = 5
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'TxtCampo
        '
        Me.TxtCampo.Location = New System.Drawing.Point(307, 22)
        Me.TxtCampo.Name = "TxtCampo"
        Me.TxtCampo.Size = New System.Drawing.Size(227, 20)
        Me.TxtCampo.TabIndex = 2
        '
        'LblCampo
        '
        Me.LblCampo.AutoSize = True
        Me.LblCampo.Location = New System.Drawing.Point(217, 25)
        Me.LblCampo.Name = "LblCampo"
        Me.LblCampo.Size = New System.Drawing.Size(84, 13)
        Me.LblCampo.TabIndex = 1
        Me.LblCampo.Text = "Campo a buscar"
        '
        'CboFiltro
        '
        Me.CboFiltro.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GestionCursosDataSet, "DatosPersonales.Id", True))
        Me.CboFiltro.FormattingEnabled = True
        Me.CboFiltro.Location = New System.Drawing.Point(16, 20)
        Me.CboFiltro.Name = "CboFiltro"
        Me.CboFiltro.Size = New System.Drawing.Size(180, 21)
        Me.CboFiltro.TabIndex = 0
        '
        'GestionCursosDataSet
        '
        Me.GestionCursosDataSet.DataSetName = "GestionCursosDataSet"
        Me.GestionCursosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GestionCursosDataSetBindingSource
        '
        Me.GestionCursosDataSetBindingSource.DataSource = Me.GestionCursosDataSet
        Me.GestionCursosDataSetBindingSource.Position = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(296, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'FrmListado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 492)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GbBuscar)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdBorrar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.cmdNuevo)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "FrmListado"
        Me.Text = "FrmListado"
        Me.GbBuscar.ResumeLayout(False)
        Me.GbBuscar.PerformLayout()
        CType(Me.GestionCursosDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GestionCursosDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents cmdModificar As System.Windows.Forms.Button
    Friend WithEvents cmdBorrar As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents GbBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCampo As System.Windows.Forms.TextBox
    Friend WithEvents LblCampo As System.Windows.Forms.Label
    Friend WithEvents CboFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents GestionCursosDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GestionCursosDataSet As GestionCursos_0._1.GestionCursosDataSet
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
