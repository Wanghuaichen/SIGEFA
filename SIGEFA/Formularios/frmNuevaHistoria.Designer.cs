namespace SIGEFA.Formularios
{
    partial class frmNuevaHistoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaHistoria));
            this.lblFechaHora = new DevComponents.DotNetBar.LabelX();
            this.dtiFechaHora = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panelSintomas = new DevComponents.DotNetBar.PanelEx();
            this.txtNotas = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNota = new DevComponents.DotNetBar.LabelX();
            this.diPeso = new DevComponents.Editors.DoubleInput();
            this.lblPeso = new DevComponents.DotNetBar.LabelX();
            this.diTemp = new DevComponents.Editors.DoubleInput();
            this.lblTemp = new DevComponents.DotNetBar.LabelX();
            this.lblTituloSintomas = new DevComponents.DotNetBar.LabelX();
            this.panelTratObs = new DevComponents.DotNetBar.PanelEx();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonX();
            this.chkFallecio = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtTratamiento = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTituloTratamientoObs = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaHora)).BeginInit();
            this.panelSintomas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diTemp)).BeginInit();
            this.panelTratObs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFechaHora
            // 
            // 
            // 
            // 
            this.lblFechaHora.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFechaHora.Location = new System.Drawing.Point(12, 12);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(75, 23);
            this.lblFechaHora.TabIndex = 0;
            this.lblFechaHora.Text = "Fecha/Hora:";
            // 
            // dtiFechaHora
            // 
            // 
            // 
            // 
            this.dtiFechaHora.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiFechaHora.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaHora.ButtonClear.Tooltip = "";
            this.dtiFechaHora.ButtonCustom.Tooltip = "";
            this.dtiFechaHora.ButtonCustom2.Tooltip = "";
            this.dtiFechaHora.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiFechaHora.ButtonDropDown.Tooltip = "";
            this.dtiFechaHora.ButtonDropDown.Visible = true;
            this.dtiFechaHora.ButtonFreeText.Tooltip = "";
            this.dtiFechaHora.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtiFechaHora.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.dtiFechaHora.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiFechaHora.IsPopupCalendarOpen = false;
            this.dtiFechaHora.Location = new System.Drawing.Point(93, 15);
            // 
            // 
            // 
            this.dtiFechaHora.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiFechaHora.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaHora.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiFechaHora.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiFechaHora.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiFechaHora.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaHora.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiFechaHora.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiFechaHora.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiFechaHora.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiFechaHora.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaHora.MonthCalendar.DayClickAutoClosePopup = false;
            this.dtiFechaHora.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.dtiFechaHora.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiFechaHora.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiFechaHora.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiFechaHora.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiFechaHora.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiFechaHora.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiFechaHora.MonthCalendar.TodayButtonVisible = true;
            this.dtiFechaHora.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiFechaHora.Name = "dtiFechaHora";
            this.dtiFechaHora.Size = new System.Drawing.Size(312, 20);
            this.dtiFechaHora.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiFechaHora.TabIndex = 1;
            // 
            // panelSintomas
            // 
            this.panelSintomas.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelSintomas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelSintomas.Controls.Add(this.txtNotas);
            this.panelSintomas.Controls.Add(this.lblNota);
            this.panelSintomas.Controls.Add(this.diPeso);
            this.panelSintomas.Controls.Add(this.lblPeso);
            this.panelSintomas.Controls.Add(this.diTemp);
            this.panelSintomas.Controls.Add(this.lblTemp);
            this.panelSintomas.Controls.Add(this.lblTituloSintomas);
            this.panelSintomas.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelSintomas.Location = new System.Drawing.Point(13, 41);
            this.panelSintomas.Name = "panelSintomas";
            this.panelSintomas.Size = new System.Drawing.Size(403, 152);
            this.panelSintomas.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelSintomas.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelSintomas.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelSintomas.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelSintomas.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelSintomas.Style.GradientAngle = 90;
            this.panelSintomas.TabIndex = 2;
            // 
            // txtNotas
            // 
            this.txtNotas.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNotas.Border.Class = "TextBoxBorder";
            this.txtNotas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNotas.ButtonCustom.Tooltip = "";
            this.txtNotas.ButtonCustom2.Tooltip = "";
            this.txtNotas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNotas.DisabledBackColor = System.Drawing.Color.White;
            this.txtNotas.ForeColor = System.Drawing.Color.Black;
            this.txtNotas.Location = new System.Drawing.Point(42, 60);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.PreventEnterBeep = true;
            this.txtNotas.Size = new System.Drawing.Size(350, 89);
            this.txtNotas.TabIndex = 6;
            // 
            // lblNota
            // 
            // 
            // 
            // 
            this.lblNota.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNota.Location = new System.Drawing.Point(3, 57);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(33, 23);
            this.lblNota.TabIndex = 5;
            this.lblNota.Text = "Nota:";
            // 
            // diPeso
            // 
            // 
            // 
            // 
            this.diPeso.BackgroundStyle.Class = "DateTimeInputBackground";
            this.diPeso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.diPeso.ButtonCalculator.Tooltip = "";
            this.diPeso.ButtonClear.Tooltip = "";
            this.diPeso.ButtonCustom.Tooltip = "";
            this.diPeso.ButtonCustom2.Tooltip = "";
            this.diPeso.ButtonDropDown.Tooltip = "";
            this.diPeso.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.diPeso.ButtonFreeText.Tooltip = "";
            this.diPeso.Increment = 0.1D;
            this.diPeso.Location = new System.Drawing.Point(284, 28);
            this.diPeso.MinValue = 0D;
            this.diPeso.Name = "diPeso";
            this.diPeso.ShowUpDown = true;
            this.diPeso.Size = new System.Drawing.Size(108, 20);
            this.diPeso.TabIndex = 4;
            // 
            // lblPeso
            // 
            // 
            // 
            // 
            this.lblPeso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPeso.Location = new System.Drawing.Point(219, 28);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(59, 23);
            this.lblPeso.TabIndex = 3;
            this.lblPeso.Text = "Peso (KG):";
            // 
            // diTemp
            // 
            // 
            // 
            // 
            this.diTemp.BackgroundStyle.Class = "DateTimeInputBackground";
            this.diTemp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.diTemp.ButtonCalculator.Tooltip = "";
            this.diTemp.ButtonClear.Tooltip = "";
            this.diTemp.ButtonCustom.Tooltip = "";
            this.diTemp.ButtonCustom2.Tooltip = "";
            this.diTemp.ButtonDropDown.Tooltip = "";
            this.diTemp.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.diTemp.ButtonFreeText.Tooltip = "";
            this.diTemp.Increment = 0.1D;
            this.diTemp.Location = new System.Drawing.Point(102, 28);
            this.diTemp.MinValue = 0D;
            this.diTemp.Name = "diTemp";
            this.diTemp.ShowUpDown = true;
            this.diTemp.Size = new System.Drawing.Size(98, 20);
            this.diTemp.TabIndex = 2;
            // 
            // lblTemp
            // 
            // 
            // 
            // 
            this.lblTemp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTemp.Location = new System.Drawing.Point(3, 28);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(93, 23);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "Temperatura (C°):";
            // 
            // lblTituloSintomas
            // 
            // 
            // 
            // 
            this.lblTituloSintomas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTituloSintomas.Location = new System.Drawing.Point(3, 3);
            this.lblTituloSintomas.Name = "lblTituloSintomas";
            this.lblTituloSintomas.Size = new System.Drawing.Size(118, 19);
            this.lblTituloSintomas.TabIndex = 0;
            this.lblTituloSintomas.Text = "<b>Síntomas/Diagnóstico</b>";
            // 
            // panelTratObs
            // 
            this.panelTratObs.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelTratObs.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelTratObs.Controls.Add(this.btnGuardar);
            this.panelTratObs.Controls.Add(this.chkFallecio);
            this.panelTratObs.Controls.Add(this.txtTratamiento);
            this.panelTratObs.Controls.Add(this.lblTituloTratamientoObs);
            this.panelTratObs.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelTratObs.Location = new System.Drawing.Point(12, 199);
            this.panelTratObs.Name = "panelTratObs";
            this.panelTratObs.Size = new System.Drawing.Size(404, 143);
            this.panelTratObs.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelTratObs.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelTratObs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelTratObs.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelTratObs.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelTratObs.Style.GradientAngle = 90;
            this.panelTratObs.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(285, 117);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(108, 23);
            this.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // chkFallecio
            // 
            // 
            // 
            // 
            this.chkFallecio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkFallecio.Location = new System.Drawing.Point(4, 113);
            this.chkFallecio.Name = "chkFallecio";
            this.chkFallecio.Size = new System.Drawing.Size(100, 23);
            this.chkFallecio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkFallecio.TabIndex = 3;
            this.chkFallecio.Text = "Fallecimiento";
            // 
            // txtTratamiento
            // 
            this.txtTratamiento.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTratamiento.Border.Class = "TextBoxBorder";
            this.txtTratamiento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTratamiento.ButtonCustom.Tooltip = "";
            this.txtTratamiento.ButtonCustom2.Tooltip = "";
            this.txtTratamiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTratamiento.DisabledBackColor = System.Drawing.Color.White;
            this.txtTratamiento.ForeColor = System.Drawing.Color.Black;
            this.txtTratamiento.Location = new System.Drawing.Point(4, 28);
            this.txtTratamiento.Multiline = true;
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.PreventEnterBeep = true;
            this.txtTratamiento.Size = new System.Drawing.Size(389, 79);
            this.txtTratamiento.TabIndex = 2;
            // 
            // lblTituloTratamientoObs
            // 
            // 
            // 
            // 
            this.lblTituloTratamientoObs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTituloTratamientoObs.Location = new System.Drawing.Point(4, 3);
            this.lblTituloTratamientoObs.Name = "lblTituloTratamientoObs";
            this.lblTituloTratamientoObs.Size = new System.Drawing.Size(148, 19);
            this.lblTituloTratamientoObs.TabIndex = 1;
            this.lblTituloTratamientoObs.Text = "<b>Tratamiento/Observaciones</b>";
            // 
            // frmNuevaHistoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 354);
            this.Controls.Add(this.panelTratObs);
            this.Controls.Add(this.panelSintomas);
            this.Controls.Add(this.dtiFechaHora);
            this.Controls.Add(this.lblFechaHora);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNuevaHistoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TitleText = "<b>Nueva Historia</b>";
            ((System.ComponentModel.ISupportInitialize)(this.dtiFechaHora)).EndInit();
            this.panelSintomas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diTemp)).EndInit();
            this.panelTratObs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblFechaHora;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiFechaHora;
        private DevComponents.DotNetBar.PanelEx panelSintomas;
        private DevComponents.DotNetBar.LabelX lblTituloSintomas;
        private DevComponents.Editors.DoubleInput diTemp;
        private DevComponents.DotNetBar.LabelX lblTemp;
        private DevComponents.Editors.DoubleInput diPeso;
        private DevComponents.DotNetBar.LabelX lblPeso;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNotas;
        private DevComponents.DotNetBar.LabelX lblNota;
        private DevComponents.DotNetBar.PanelEx panelTratObs;
        private DevComponents.DotNetBar.LabelX lblTituloTratamientoObs;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTratamiento;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkFallecio;
        private DevComponents.DotNetBar.ButtonX btnGuardar;
    }
}