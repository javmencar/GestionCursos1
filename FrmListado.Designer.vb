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
        Me.GbBusquedaUnica = New System.Windows.Forms.GroupBox()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.TxtCampo = New System.Windows.Forms.TextBox()
        Me.LblCampo = New System.Windows.Forms.Label()
        Me.CboFiltroBusquedaUnica = New System.Windows.Forms.ComboBox()
        Me.GestionCursosDataSet = New GestionCursos_0._1.GestionCursosDataSet()
        Me.GestionCursosDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdExportar = New System.Windows.Forms.Button()
        Me.ChkExportar = New System.Windows.Forms.CheckBox()
        Me.GbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmdQuitarFiltro = New System.Windows.Forms.Button()
        Me.cmdFiltrar = New System.Windows.Forms.Button()
        Me.CboFiltroGordo = New System.Windows.Forms.ComboBox()
        Me.lblFiltroGordo = New System.Windows.Forms.Label()
        Me.GbBusquedaUnica.SuspendLayout()
        CType(Me.GestionCursosDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GestionCursosDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(13, 152)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1077, 298)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Location = New System.Drawing.Point(1120, 206)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(121, 48)
        Me.cmdNuevo.TabIndex = 1
        Me.cmdNuevo.Text = "Nuevo"
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.Location = New System.Drawing.Point(1120, 270)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(121, 48)
        Me.cmdModificar.TabIndex = 2
        Me.cmdModificar.Text = "Modificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdBorrar
        '
        Me.cmdBorrar.Location = New System.Drawing.Point(1120, 336)
        Me.cmdBorrar.Name = "cmdBorrar"
        Me.cmdBorrar.Size = New System.Drawing.Size(121, 48)
        Me.cmdBorrar.TabIndex = 3
        Me.cmdBorrar.Text = "Borrar"
        Me.cmdBorrar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(1120, 560)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(121, 48)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'GbBusquedaUnica
        '
        Me.GbBusquedaUnica.Controls.Add(Me.cmdBuscar)
        Me.GbBusquedaUnica.Controls.Add(Me.TxtCampo)
        Me.GbBusquedaUnica.Controls.Add(Me.LblCampo)
        Me.GbBusquedaUnica.Controls.Add(Me.CboFiltroBusquedaUnica)
        Me.GbBusquedaUnica.Location = New System.Drawing.Point(37, 503)
        Me.GbBusquedaUnica.Name = "GbBusquedaUnica"
        Me.GbBusquedaUnica.Size = New System.Drawing.Size(627, 100)
        Me.GbBusquedaUnica.TabIndex = 5
        Me.GbBusquedaUnica.TabStop = False
        Me.GbBusquedaUnica.Text = "Buscar una ficha "
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
        'CboFiltroBusquedaUnica
        '
        Me.CboFiltroBusquedaUnica.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GestionCursosDataSet, "DatosPersonales.Id", True))
        Me.CboFiltroBusquedaUnica.FormattingEnabled = True
        Me.CboFiltroBusquedaUnica.Location = New System.Drawing.Point(16, 20)
        Me.CboFiltroBusquedaUnica.Name = "CboFiltroBusquedaUnica"
        Me.CboFiltroBusquedaUnica.Size = New System.Drawing.Size(180, 21)
        Me.CboFiltroBusquedaUnica.TabIndex = 0
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
        Me.Label1.Location = New System.Drawing.Point(296, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'CmdExportar
        '
        Me.CmdExportar.Location = New System.Drawing.Point(1122, 402)
        Me.CmdExportar.Name = "CmdExportar"
        Me.CmdExportar.Size = New System.Drawing.Size(121, 48)
        Me.CmdExportar.TabIndex = 7
        Me.CmdExportar.Text = "Exportar Datos"
        Me.CmdExportar.UseVisualStyleBackColor = True
        '
        'ChkExportar
        '
        Me.ChkExportar.AutoSize = True
        Me.ChkExportar.Location = New System.Drawing.Point(1037, 456)
        Me.ChkExportar.Name = "ChkExportar"
        Me.ChkExportar.Size = New System.Drawing.Size(206, 17)
        Me.ChkExportar.TabIndex = 8
        Me.ChkExportar.Text = "Quiero Activar la exportación de datos"
        Me.ChkExportar.UseVisualStyleBackColor = True
        '
        'GbFiltros
        '
        Me.GbFiltros.Controls.Add(Me.cmdQuitarFiltro)
        Me.GbFiltros.Controls.Add(Me.cmdFiltrar)
        Me.GbFiltros.Controls.Add(Me.CboFiltroGordo)
        Me.GbFiltros.Controls.Add(Me.lblFiltroGordo)
        Me.GbFiltros.Location = New System.Drawing.Point(37, 27)
        Me.GbFiltros.Name = "GbFiltros"
        Me.GbFiltros.Size = New System.Drawing.Size(668, 88)
        Me.GbFiltros.TabIndex = 9
        Me.GbFiltros.TabStop = False
        Me.GbFiltros.Text = "Filtrar"
        '
        'cmdQuitarFiltro
        '
        Me.cmdQuitarFiltro.Location = New System.Drawing.Point(364, 37)
        Me.cmdQuitarFiltro.Name = "cmdQuitarFiltro"
        Me.cmdQuitarFiltro.Size = New System.Drawing.Size(66, 41)
        Me.cmdQuitarFiltro.TabIndex = 18
        Me.cmdQuitarFiltro.Text = "Quitar Filtro"
        Me.cmdQuitarFiltro.UseVisualStyleBackColor = True
        '
        'cmdFiltrar
        '
        Me.cmdFiltrar.Location = New System.Drawing.Point(272, 37)
        Me.cmdFiltrar.Name = "cmdFiltrar"
        Me.cmdFiltrar.Size = New System.Drawing.Size(66, 41)
        Me.cmdFiltrar.TabIndex = 17
        Me.cmdFiltrar.Text = "Filtrar"
        Me.cmdFiltrar.UseVisualStyleBackColor = True
        '
        'CboFiltroGordo
        '
        Me.CboFiltroGordo.FormattingEnabled = True
        Me.CboFiltroGordo.Location = New System.Drawing.Point(27, 48)
        Me.CboFiltroGordo.Name = "CboFiltroGordo"
        Me.CboFiltroGordo.Size = New System.Drawing.Size(187, 21)
        Me.CboFiltroGordo.TabIndex = 14
        '
        'lblFiltroGordo
        '
        Me.lblFiltroGordo.AutoSize = True
        Me.lblFiltroGordo.Location = New System.Drawing.Point(40, 32)
        Me.lblFiltroGordo.Name = "lblFiltroGordo"
        Me.lblFiltroGordo.Size = New System.Drawing.Size(171, 13)
        Me.lblFiltroGordo.TabIndex = 13
        Me.lblFiltroGordo.Text = "Seleccione el curso que desea ver"
        '
        'FrmListado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1274, 620)
        Me.Controls.Add(Me.GbFiltros)
        Me.Controls.Add(Me.ChkExportar)
        Me.Controls.Add(Me.CmdExportar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GbBusquedaUnica)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdBorrar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.cmdNuevo)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "FrmListado"
        Me.Text = "FrmListado"
        Me.GbBusquedaUnica.ResumeLayout(False)
        Me.GbBusquedaUnica.PerformLayout()
        CType(Me.GestionCursosDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GestionCursosDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbFiltros.ResumeLayout(False)
        Me.GbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents cmdModificar As System.Windows.Forms.Button
    Friend WithEvents cmdBorrar As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents GbBusquedaUnica As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCampo As System.Windows.Forms.TextBox
    Friend WithEvents LblCampo As System.Windows.Forms.Label
    Friend WithEvents CboFiltroBusquedaUnica As System.Windows.Forms.ComboBox
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents GestionCursosDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GestionCursosDataSet As GestionCursos_0._1.GestionCursosDataSet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdExportar As System.Windows.Forms.Button
    Friend WithEvents ChkExportar As System.Windows.Forms.CheckBox
    Friend WithEvents GbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents CboFiltroGordo As System.Windows.Forms.ComboBox
    Friend WithEvents lblFiltroGordo As System.Windows.Forms.Label
    Friend WithEvents cmdFiltrar As System.Windows.Forms.Button
    Friend WithEvents cmdQuitarFiltro As System.Windows.Forms.Button
End Class
