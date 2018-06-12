namespace SIGEFA.Formularios
{
    partial class frmPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaciente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelCabecera = new DevComponents.DotNetBar.PanelEx();
            this.txtDireccion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtPropietario = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPropietario = new DevComponents.DotNetBar.LabelX();
            this.cmbSexo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblSexo = new DevComponents.DotNetBar.LabelX();
            this.txtEdad = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtiFechaNacimiento = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblFechaNac = new DevComponents.DotNetBar.LabelX();
            this.txtRaza = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblRaza = new DevComponents.DotNetBar.LabelX();
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNombre = new DevComponents.DotNetBar.LabelX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonX();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonX();
            this.btnModificar = new DevComponents.DotNetBar.ButtonX();
            this.btnNuevo = new DevComponents.DotNetBar.ButtonX();
            this.cmbEspecie = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.lblEspecie = new DevComponents.DotNetBar.LabelX();
            this.lblTituloCab = new DevComponents.DotNetBar.LabelX();
            this.panelDetalle = new DevComponents.DotNetBar.PanelEx();
            this.dgvDetalle = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.lblTituloDet = new DevComponents.DotNetBar.LabelX();
            this.panelCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaNacimiento)).BeginInit();
            this.panelDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCabecera
            // 
            this.panelCabecera.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelCabecera.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelCabecera.Controls.Add(this.txtDireccion);
            this.panelCabecera.Controls.Add(this.labelX1);
            this.panelCabecera.Controls.Add(this.txtPropietario);
            this.panelCabecera.Controls.Add(this.lblPropietario);
            this.panelCabecera.Controls.Add(this.cmbSexo);
            this.panelCabecera.Controls.Add(this.lblSexo);
            this.panelCabecera.Controls.Add(this.txtEdad);
            this.panelCabecera.Controls.Add(this.dtiFechaNacimiento);
            this.panelCabecera.Controls.Add(this.lblFechaNac);
            this.panelCabecera.Controls.Add(this.txtRaza);
            this.panelCabecera.Controls.Add(this.lblRaza);
            this.panelCabecera.Controls.Add(this.txtNombre);
            this.panelCabecera.Controls.Add(this.lblNombre);
            this.panelCabecera.Controls.Add(this.btnCancelar);
            this.panelCabecera.Controls.Add(this.btnEliminar);
            this.panelCabecera.Controls.Add(this.btnGuardar);
            this.panelCabecera.Controls.Add(this.btnModificar);
            this.panelCabecera.Controls.Add(this.btnNuevo);
            this.panelCabecera.Controls.Add(this.cmbEspecie);
            this.panelCabecera.Controls.Add(this.line1);
            this.panelCabecera.Controls.Add(this.lblEspecie);
            this.panelCabecera.Controls.Add(this.lblTituloCab);
            this.panelCabecera.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelCabecera.Location = new System.Drawing.Point(12, 12);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(927, 178);
            this.panelCabecera.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelCabecera.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelCabecera.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine;
            this.panelCabecera.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelCabecera.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelCabecera.Style.GradientAngle = 90;
            this.panelCabecera.TabIndex = 0;
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
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.DisabledBackColor = System.Drawing.Color.White;
            this.txtDireccion.ForeColor = System.Drawing.Color.Black;
            this.txtDireccion.Location = new System.Drawing.Point(652, 90);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PreventEnterBeep = true;
            this.txtDireccion.Size = new System.Drawing.Size(272, 20);
            this.txtDireccion.TabIndex = 21;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(586, 87);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(73, 23);
            this.labelX1.TabIndex = 20;
            this.labelX1.Text = "Dirección:";
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
            this.txtPropietario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPropietario.DisabledBackColor = System.Drawing.Color.White;
            this.txtPropietario.ForeColor = System.Drawing.Color.Black;
            this.txtPropietario.Location = new System.Drawing.Point(652, 52);
            this.txtPropietario.Name = "txtPropietario";
            this.txtPropietario.PreventEnterBeep = true;
            this.txtPropietario.Size = new System.Drawing.Size(272, 20);
            this.txtPropietario.TabIndex = 19;
            // 
            // lblPropietario
            // 
            // 
            // 
            // 
            this.lblPropietario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPropietario.Location = new System.Drawing.Point(586, 49);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(60, 23);
            this.lblPropietario.TabIndex = 18;
            this.lblPropietario.Text = "Propietario:";
            // 
            // cmbSexo
            // 
            this.cmbSexo.DisplayMember = "Text";
            this.cmbSexo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.ItemHeight = 14;
            this.cmbSexo.Location = new System.Drawing.Point(486, 90);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(94, 20);
            this.cmbSexo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSexo.TabIndex = 17;
            // 
            // lblSexo
            // 
            // 
            // 
            // 
            this.lblSexo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSexo.Location = new System.Drawing.Point(453, 90);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(36, 23);
            this.lblSexo.TabIndex = 16;
            this.lblSexo.Text = "Sexo:";
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
            this.txtEdad.Location = new System.Drawing.Point(453, 52);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.PreventEnterBeep = true;
            this.txtEdad.Size = new System.Drawing.Size(127, 20);
            this.txtEdad.TabIndex = 15;
            this.txtEdad.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtEdad.WatermarkText = "EDAD";
            // 
            // dtiFechaNacimiento
            // 
            // 
            // 
            // 
            this.dtiFechaNacimiento.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiFechaNacimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaNacimiento.ButtonClear.Tooltip = "";
            this.dtiFechaNacimiento.ButtonCustom.Tooltip = "";
            this.dtiFechaNacimiento.ButtonCustom2.Tooltip = "";
            this.dtiFechaNacimiento.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiFechaNacimiento.ButtonDropDown.Tooltip = "";
            this.dtiFechaNacimiento.ButtonDropDown.Visible = true;
            this.dtiFechaNacimiento.ButtonFreeText.Tooltip = "";
            this.dtiFechaNacimiento.IsPopupCalendarOpen = false;
            this.dtiFechaNacimiento.Location = new System.Drawing.Point(332, 52);
            // 
            // 
            // 
            this.dtiFechaNacimiento.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiFechaNacimiento.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaNacimiento.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiFechaNacimiento.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiFechaNacimiento.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiFechaNacimiento.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaNacimiento.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiFechaNacimiento.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiFechaNacimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiFechaNacimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiFechaNacimiento.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaNacimiento.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.dtiFechaNacimiento.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiFechaNacimiento.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiFechaNacimiento.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiFechaNacimiento.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaNacimiento.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiFechaNacimiento.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaNacimiento.MonthCalendar.TodayButtonVisible = true;
            this.dtiFechaNacimiento.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiFechaNacimiento.Name = "dtiFechaNacimiento";
            this.dtiFechaNacimiento.Size = new System.Drawing.Size(115, 20);
            this.dtiFechaNacimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiFechaNacimiento.TabIndex = 14;
            this.dtiFechaNacimiento.ValueChanged += new System.EventHandler(this.dtiFechaNacimiento_ValueChanged);
            // 
            // lblFechaNac
            // 
            // 
            // 
            // 
            this.lblFechaNac.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaNac.Location = new System.Drawing.Point(225, 49);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(101, 23);
            this.lblFechaNac.TabIndex = 13;
            this.lblFechaNac.Text = "Fecha Nacimiento:";
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
            this.txtRaza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRaza.DisabledBackColor = System.Drawing.Color.White;
            this.txtRaza.ForeColor = System.Drawing.Color.Black;
            this.txtRaza.Location = new System.Drawing.Point(259, 90);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.PreventEnterBeep = true;
            this.txtRaza.Size = new System.Drawing.Size(188, 20);
            this.txtRaza.TabIndex = 12;
            // 
            // lblRaza
            // 
            // 
            // 
            // 
            this.lblRaza.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblRaza.Location = new System.Drawing.Point(225, 90);
            this.lblRaza.Name = "lblRaza";
            this.lblRaza.Size = new System.Drawing.Size(37, 23);
            this.lblRaza.TabIndex = 11;
            this.lblRaza.Text = "Raza:";
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
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.DisabledBackColor = System.Drawing.Color.White;
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(50, 52);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PreventEnterBeep = true;
            this.txtNombre.Size = new System.Drawing.Size(163, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.Location = new System.Drawing.Point(3, 49);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(75, 23);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(804, 152);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 23);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "<b>CANCELAR</b>";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(594, 152);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 23);
            this.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "<b>ELIMINAR</b>";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(387, 152);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 23);
            this.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "<b>GUARDAR</b>";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Location = new System.Drawing.Point(197, 152);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 23);
            this.btnModificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "<b>MODIFICAR</b>";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(3, 152);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 23);
            this.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "<b>NUEVO</b>";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cmbEspecie
            // 
            this.cmbEspecie.DisplayMember = "Text";
            this.cmbEspecie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEspecie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecie.FormattingEnabled = true;
            this.cmbEspecie.ItemHeight = 14;
            this.cmbEspecie.Location = new System.Drawing.Point(50, 90);
            this.cmbEspecie.Name = "cmbEspecie";
            this.cmbEspecie.Size = new System.Drawing.Size(163, 20);
            this.cmbEspecie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbEspecie.TabIndex = 3;
            // 
            // line1
            // 
            this.line1.ForeColor = System.Drawing.Color.DarkCyan;
            this.line1.Location = new System.Drawing.Point(0, 24);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(927, 10);
            this.line1.TabIndex = 2;
            this.line1.Text = "line1";
            this.line1.Thickness = 2;
            // 
            // lblEspecie
            // 
            // 
            // 
            // 
            this.lblEspecie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEspecie.Location = new System.Drawing.Point(3, 90);
            this.lblEspecie.Name = "lblEspecie";
            this.lblEspecie.Size = new System.Drawing.Size(50, 23);
            this.lblEspecie.TabIndex = 1;
            this.lblEspecie.Text = "Especie:";
            // 
            // lblTituloCab
            // 
            // 
            // 
            // 
            this.lblTituloCab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTituloCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCab.Location = new System.Drawing.Point(3, 3);
            this.lblTituloCab.Name = "lblTituloCab";
            this.lblTituloCab.Size = new System.Drawing.Size(156, 23);
            this.lblTituloCab.TabIndex = 0;
            this.lblTituloCab.Text = "<b>INGRESE LOS DATOS:</b>";
            // 
            // panelDetalle
            // 
            this.panelDetalle.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDetalle.Controls.Add(this.dgvDetalle);
            this.panelDetalle.Controls.Add(this.line2);
            this.panelDetalle.Controls.Add(this.lblTituloDet);
            this.panelDetalle.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDetalle.Location = new System.Drawing.Point(12, 196);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(927, 306);
            this.panelDetalle.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDetalle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDetalle.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine;
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
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.dgvDetalle.Location = new System.Drawing.Point(3, 87);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(921, 216);
            this.dgvDetalle.TabIndex = 5;
            this.dgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellDoubleClick);
            this.dgvDetalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalle_CellFormatting);
            // 
            // line2
            // 
            this.line2.ForeColor = System.Drawing.Color.DarkCyan;
            this.line2.Location = new System.Drawing.Point(0, 31);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(927, 10);
            this.line2.TabIndex = 4;
            this.line2.Text = "line2";
            this.line2.Thickness = 2;
            // 
            // lblTituloDet
            // 
            // 
            // 
            // 
            this.lblTituloDet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTituloDet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDet.Location = new System.Drawing.Point(3, 10);
            this.lblTituloDet.Name = "lblTituloDet";
            this.lblTituloDet.Size = new System.Drawing.Size(189, 23);
            this.lblTituloDet.TabIndex = 3;
            this.lblTituloDet.Text = "<b>BUSQUEDA DE PACIENTES:</b>";
            // 
            // frmPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 514);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.panelCabecera);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TitleText = "<b>Pacientes</b>";
            this.panelCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaNacimiento)).EndInit();
            this.panelDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelCabecera;
        private DevComponents.DotNetBar.LabelX lblTituloCab;
        private DevComponents.DotNetBar.PanelEx panelDetalle;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.LabelX lblEspecie;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbEspecie;
        private DevComponents.DotNetBar.ButtonX btnNuevo;
        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnEliminar;
        private DevComponents.DotNetBar.ButtonX btnGuardar;
        private DevComponents.DotNetBar.ButtonX btnModificar;
        private DevComponents.DotNetBar.Controls.Line line2;
        private DevComponents.DotNetBar.LabelX lblTituloDet;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.LabelX lblNombre;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDetalle;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiFechaNacimiento;
        private DevComponents.DotNetBar.LabelX lblFechaNac;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRaza;
        private DevComponents.DotNetBar.LabelX lblRaza;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEdad;
        private DevComponents.DotNetBar.LabelX lblPropietario;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSexo;
        private DevComponents.DotNetBar.LabelX lblSexo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPropietario;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDireccion;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}