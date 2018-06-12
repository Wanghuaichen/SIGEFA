namespace SIGEFA.Formularios
{
    partial class frmHistoriaClinica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoriaClinica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelPaciente = new DevComponents.DotNetBar.PanelEx();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonX();
            this.txtNumero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNumero = new DevComponents.DotNetBar.LabelX();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.txtSexo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblSexo = new DevComponents.DotNetBar.LabelX();
            this.txtEdad = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblEdad = new DevComponents.DotNetBar.LabelX();
            this.txtDireccion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtPropietario = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblProp = new DevComponents.DotNetBar.LabelX();
            this.txtRaza = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblRaza = new DevComponents.DotNetBar.LabelX();
            this.txtEspecie = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblEspecie = new DevComponents.DotNetBar.LabelX();
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPaciente = new DevComponents.DotNetBar.LabelX();
            this.btnImprimir = new DevComponents.DotNetBar.ButtonX();
            this.panelDetalle = new DevComponents.DotNetBar.PanelEx();
            this.dgvDetalle = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cmsPrincipal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAgregar = new DevComponents.DotNetBar.ButtonX();
            this.panelPaciente.SuspendLayout();
            this.panelDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.cmsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPaciente
            // 
            this.panelPaciente.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelPaciente.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelPaciente.Controls.Add(this.btnGuardar);
            this.panelPaciente.Controls.Add(this.txtNumero);
            this.panelPaciente.Controls.Add(this.lblNumero);
            this.panelPaciente.Controls.Add(this.btnBuscar);
            this.panelPaciente.Controls.Add(this.txtSexo);
            this.panelPaciente.Controls.Add(this.lblSexo);
            this.panelPaciente.Controls.Add(this.txtEdad);
            this.panelPaciente.Controls.Add(this.lblEdad);
            this.panelPaciente.Controls.Add(this.txtDireccion);
            this.panelPaciente.Controls.Add(this.labelX1);
            this.panelPaciente.Controls.Add(this.txtPropietario);
            this.panelPaciente.Controls.Add(this.lblProp);
            this.panelPaciente.Controls.Add(this.txtRaza);
            this.panelPaciente.Controls.Add(this.lblRaza);
            this.panelPaciente.Controls.Add(this.txtEspecie);
            this.panelPaciente.Controls.Add(this.lblEspecie);
            this.panelPaciente.Controls.Add(this.txtNombre);
            this.panelPaciente.Controls.Add(this.lblPaciente);
            this.panelPaciente.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelPaciente.Location = new System.Drawing.Point(12, 12);
            this.panelPaciente.Name = "panelPaciente";
            this.panelPaciente.Size = new System.Drawing.Size(646, 185);
            this.panelPaciente.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelPaciente.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelPaciente.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelPaciente.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelPaciente.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelPaciente.Style.GradientAngle = 90;
            this.panelPaciente.TabIndex = 0;
            this.panelPaciente.Click += new System.EventHandler(this.panelPaciente_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(431, 138);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(209, 23);
            this.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Tooltip = "Asocia éste número de guía al paciente seleccionado.";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNumero.Border.Class = "TextBoxBorder";
            this.txtNumero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumero.ButtonCustom.Tooltip = "";
            this.txtNumero.ButtonCustom2.Tooltip = "";
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.DisabledBackColor = System.Drawing.Color.White;
            this.txtNumero.ForeColor = System.Drawing.Color.Black;
            this.txtNumero.Location = new System.Drawing.Point(73, 19);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PreventEnterBeep = true;
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 17;
            // 
            // lblNumero
            // 
            // 
            // 
            // 
            this.lblNumero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(3, 12);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(50, 32);
            this.lblNumero.TabIndex = 16;
            this.lblNumero.Text = "<b>Número:</b>";
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(191, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 20);
            this.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "<b>Buscar</b>";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtSexo
            // 
            this.txtSexo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSexo.Border.Class = "TextBoxBorder";
            this.txtSexo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSexo.ButtonCustom.Tooltip = "";
            this.txtSexo.ButtonCustom2.Tooltip = "";
            this.txtSexo.DisabledBackColor = System.Drawing.Color.White;
            this.txtSexo.Enabled = false;
            this.txtSexo.ForeColor = System.Drawing.Color.Black;
            this.txtSexo.Location = new System.Drawing.Point(431, 71);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.PreventEnterBeep = true;
            this.txtSexo.Size = new System.Drawing.Size(212, 20);
            this.txtSexo.TabIndex = 13;
            // 
            // lblSexo
            // 
            // 
            // 
            // 
            this.lblSexo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSexo.Location = new System.Drawing.Point(361, 71);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(64, 20);
            this.lblSexo.TabIndex = 12;
            this.lblSexo.Text = "Sexo:";
            this.lblSexo.WordWrap = true;
            // 
            // txtEdad
            // 
            this.txtEdad.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEdad.Border.Class = "TextBoxBorder";
            this.txtEdad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEdad.ButtonCustom.Tooltip = "";
            this.txtEdad.ButtonCustom2.Tooltip = "";
            this.txtEdad.DisabledBackColor = System.Drawing.Color.White;
            this.txtEdad.Enabled = false;
            this.txtEdad.ForeColor = System.Drawing.Color.Black;
            this.txtEdad.Location = new System.Drawing.Point(431, 45);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.PreventEnterBeep = true;
            this.txtEdad.Size = new System.Drawing.Size(212, 20);
            this.txtEdad.TabIndex = 11;
            // 
            // lblEdad
            // 
            // 
            // 
            // 
            this.lblEdad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEdad.Location = new System.Drawing.Point(361, 45);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(64, 20);
            this.lblEdad.TabIndex = 10;
            this.lblEdad.Text = "Edad:";
            this.lblEdad.WordWrap = true;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDireccion.Border.Class = "TextBoxBorder";
            this.txtDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDireccion.ButtonCustom.Tooltip = "";
            this.txtDireccion.ButtonCustom2.Tooltip = "";
            this.txtDireccion.DisabledBackColor = System.Drawing.Color.White;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.ForeColor = System.Drawing.Color.Black;
            this.txtDireccion.Location = new System.Drawing.Point(431, 13);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PreventEnterBeep = true;
            this.txtDireccion.Size = new System.Drawing.Size(212, 20);
            this.txtDireccion.TabIndex = 9;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(361, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(64, 20);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "Dirección:";
            this.labelX1.WordWrap = true;
            // 
            // txtPropietario
            // 
            this.txtPropietario.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPropietario.Border.Class = "TextBoxBorder";
            this.txtPropietario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPropietario.ButtonCustom.Tooltip = "";
            this.txtPropietario.ButtonCustom2.Tooltip = "";
            this.txtPropietario.DisabledBackColor = System.Drawing.Color.White;
            this.txtPropietario.Enabled = false;
            this.txtPropietario.ForeColor = System.Drawing.Color.Black;
            this.txtPropietario.Location = new System.Drawing.Point(73, 141);
            this.txtPropietario.Name = "txtPropietario";
            this.txtPropietario.PreventEnterBeep = true;
            this.txtPropietario.Size = new System.Drawing.Size(212, 20);
            this.txtPropietario.TabIndex = 7;
            // 
            // lblProp
            // 
            // 
            // 
            // 
            this.lblProp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblProp.Location = new System.Drawing.Point(3, 141);
            this.lblProp.Name = "lblProp";
            this.lblProp.Size = new System.Drawing.Size(64, 20);
            this.lblProp.TabIndex = 6;
            this.lblProp.Text = "Propietario";
            this.lblProp.WordWrap = true;
            // 
            // txtRaza
            // 
            this.txtRaza.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRaza.Border.Class = "TextBoxBorder";
            this.txtRaza.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRaza.ButtonCustom.Tooltip = "";
            this.txtRaza.ButtonCustom2.Tooltip = "";
            this.txtRaza.DisabledBackColor = System.Drawing.Color.White;
            this.txtRaza.Enabled = false;
            this.txtRaza.ForeColor = System.Drawing.Color.Black;
            this.txtRaza.Location = new System.Drawing.Point(73, 115);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.PreventEnterBeep = true;
            this.txtRaza.Size = new System.Drawing.Size(212, 20);
            this.txtRaza.TabIndex = 5;
            // 
            // lblRaza
            // 
            // 
            // 
            // 
            this.lblRaza.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblRaza.Location = new System.Drawing.Point(3, 112);
            this.lblRaza.Name = "lblRaza";
            this.lblRaza.Size = new System.Drawing.Size(52, 23);
            this.lblRaza.TabIndex = 4;
            this.lblRaza.Text = "Raza:";
            // 
            // txtEspecie
            // 
            this.txtEspecie.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEspecie.Border.Class = "TextBoxBorder";
            this.txtEspecie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEspecie.ButtonCustom.Tooltip = "";
            this.txtEspecie.ButtonCustom2.Tooltip = "";
            this.txtEspecie.DisabledBackColor = System.Drawing.Color.White;
            this.txtEspecie.Enabled = false;
            this.txtEspecie.ForeColor = System.Drawing.Color.Black;
            this.txtEspecie.Location = new System.Drawing.Point(73, 89);
            this.txtEspecie.Name = "txtEspecie";
            this.txtEspecie.PreventEnterBeep = true;
            this.txtEspecie.Size = new System.Drawing.Size(212, 20);
            this.txtEspecie.TabIndex = 3;
            // 
            // lblEspecie
            // 
            // 
            // 
            // 
            this.lblEspecie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEspecie.Location = new System.Drawing.Point(3, 86);
            this.lblEspecie.Name = "lblEspecie";
            this.lblEspecie.Size = new System.Drawing.Size(52, 23);
            this.lblEspecie.TabIndex = 2;
            this.lblEspecie.Text = "Especie:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNombre.Border.Class = "TextBoxBorder";
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombre.ButtonCustom.Tooltip = "";
            this.txtNombre.ButtonCustom2.Tooltip = "";
            this.txtNombre.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(73, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(212, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtNombre.WatermarkImage = ((System.Drawing.Image)(resources.GetObject("txtNombre.WatermarkImage")));
            this.txtNombre.WatermarkText = "Doble clic para buscar al paciente...";
            this.txtNombre.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNombre_MouseDoubleClick);
            // 
            // lblPaciente
            // 
            // 
            // 
            // 
            this.lblPaciente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPaciente.Location = new System.Drawing.Point(3, 57);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(52, 23);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "Paciente:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(523, 238);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(117, 23);
            this.btnImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.Text = "<b>Imprimir</b>";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panelDetalle
            // 
            this.panelDetalle.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDetalle.Controls.Add(this.btnImprimir);
            this.panelDetalle.Controls.Add(this.dgvDetalle);
            this.panelDetalle.Controls.Add(this.btnAgregar);
            this.panelDetalle.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDetalle.Location = new System.Drawing.Point(12, 200);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(646, 269);
            this.panelDetalle.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDetalle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDetalle.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDetalle.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDetalle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDetalle.Style.GradientAngle = 90;
            this.panelDetalle.TabIndex = 1;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.ContextMenuStrip = this.cmsPrincipal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.dgvDetalle.Location = new System.Drawing.Point(3, 3);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(640, 229);
            this.dgvDetalle.TabIndex = 0;
            // 
            // cmsPrincipal
            // 
            this.cmsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetalleToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.cmsPrincipal.Name = "cmsPrincipal";
            this.cmsPrincipal.Size = new System.Drawing.Size(130, 48);
            // 
            // verDetalleToolStripMenuItem
            // 
            this.verDetalleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verDetalleToolStripMenuItem.Image")));
            this.verDetalleToolStripMenuItem.Name = "verDetalleToolStripMenuItem";
            this.verDetalleToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verDetalleToolStripMenuItem.Text = "Ver Detalle";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // btnAgregar
            // 
            this.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(3, 238);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(170, 23);
            this.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.Text = "Agregar Nueva Ocurrencia";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmHistoriaClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 481);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.panelPaciente);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHistoriaClinica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TitleText = "<b>Historia Clínica</b>";
            this.panelPaciente.ResumeLayout(false);
            this.panelDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.cmsPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelPaciente;
        private DevComponents.DotNetBar.LabelX lblPaciente;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.LabelX lblEspecie;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEspecie;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRaza;
        private DevComponents.DotNetBar.LabelX lblRaza;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPropietario;
        private DevComponents.DotNetBar.LabelX lblProp;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDireccion;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSexo;
        private DevComponents.DotNetBar.LabelX lblSexo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEdad;
        private DevComponents.DotNetBar.LabelX lblEdad;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.ButtonX btnImprimir;
        private DevComponents.DotNetBar.PanelEx panelDetalle;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDetalle;
        private System.Windows.Forms.ContextMenuStrip cmsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem verDetalleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnAgregar;
        private DevComponents.DotNetBar.LabelX lblNumero;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNumero;
        private DevComponents.DotNetBar.ButtonX btnGuardar;
    }
}