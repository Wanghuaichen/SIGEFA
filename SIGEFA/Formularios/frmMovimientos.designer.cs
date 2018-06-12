namespace SIGEFA.Formularios
{
    partial class frmMovimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimientos));
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.codMovimientos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCtaCorriente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentacorriente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTransaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desctipomovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipomovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codnotasalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codnotaingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionactivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.biNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.biEditar = new DevComponents.DotNetBar.ButtonItem();
            this.biEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.btnConsultar = new DevComponents.DotNetBar.ButtonItem();
            this.biActualizar = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.biImprimir = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codMovimientos,
            this.codBanco,
            this.banco,
            this.codCtaCorriente,
            this.cuentacorriente,
            this.numTransaccion,
            this.fechaMov,
            this.transaccion,
            this.desctipomovimiento,
            this.tipomovimiento,
            this.haber,
            this.debe,
            this.tipoCV,
            this.saldo,
            this.tipoCC,
            this.codnotasalida,
            this.codnotaingreso,
            this.fecharegistro,
            this.nombre,
            this.direccion,
            this.dni,
            this.descripcion,
            this.activo,
            this.descripcionactivo});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 59);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(1183, 382);
            this.dgvDetalle.TabIndex = 6;
            this.dgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellDoubleClick);
            this.dgvDetalle.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetalle_ColumnHeaderMouseClick);
            // 
            // codMovimientos
            // 
            this.codMovimientos.DataPropertyName = "codCtaCteMovimiento";
            this.codMovimientos.HeaderText = "codMovimientos";
            this.codMovimientos.Name = "codMovimientos";
            this.codMovimientos.ReadOnly = true;
            // 
            // codBanco
            // 
            this.codBanco.DataPropertyName = "codBanco";
            this.codBanco.HeaderText = "codBanco";
            this.codBanco.Name = "codBanco";
            this.codBanco.ReadOnly = true;
            this.codBanco.Visible = false;
            // 
            // banco
            // 
            this.banco.DataPropertyName = "NomBanco";
            this.banco.HeaderText = "Banco";
            this.banco.Name = "banco";
            this.banco.ReadOnly = true;
            this.banco.Width = 150;
            // 
            // codCtaCorriente
            // 
            this.codCtaCorriente.DataPropertyName = "codCuentaCorriente";
            this.codCtaCorriente.HeaderText = "codCtaCorriente";
            this.codCtaCorriente.Name = "codCtaCorriente";
            this.codCtaCorriente.ReadOnly = true;
            this.codCtaCorriente.Visible = false;
            // 
            // cuentacorriente
            // 
            this.cuentacorriente.DataPropertyName = "cuentacorriente";
            this.cuentacorriente.HeaderText = "CuentaCorriente";
            this.cuentacorriente.Name = "cuentacorriente";
            this.cuentacorriente.ReadOnly = true;
            this.cuentacorriente.Width = 150;
            // 
            // numTransaccion
            // 
            this.numTransaccion.DataPropertyName = "NumTransaccion";
            this.numTransaccion.HeaderText = "NumTransaccion";
            this.numTransaccion.Name = "numTransaccion";
            this.numTransaccion.ReadOnly = true;
            this.numTransaccion.Visible = false;
            // 
            // fechaMov
            // 
            this.fechaMov.DataPropertyName = "fechaMovimiento";
            this.fechaMov.HeaderText = "Fecha Movimiento";
            this.fechaMov.Name = "fechaMov";
            this.fechaMov.ReadOnly = true;
            // 
            // transaccion
            // 
            this.transaccion.DataPropertyName = "Transaccion";
            this.transaccion.HeaderText = "Transaccion";
            this.transaccion.Name = "transaccion";
            this.transaccion.ReadOnly = true;
            // 
            // desctipomovimiento
            // 
            this.desctipomovimiento.DataPropertyName = "desctipomovimiento";
            this.desctipomovimiento.HeaderText = "MOVIMIENTO";
            this.desctipomovimiento.Name = "desctipomovimiento";
            this.desctipomovimiento.ReadOnly = true;
            this.desctipomovimiento.Width = 200;
            // 
            // tipomovimiento
            // 
            this.tipomovimiento.HeaderText = "Tipo Movimiento";
            this.tipomovimiento.Name = "tipomovimiento";
            this.tipomovimiento.ReadOnly = true;
            this.tipomovimiento.Visible = false;
            this.tipomovimiento.Width = 200;
            // 
            // haber
            // 
            this.haber.DataPropertyName = "ingreso";
            this.haber.HeaderText = "INGRESO (DEUDOR)";
            this.haber.Name = "haber";
            this.haber.ReadOnly = true;
            // 
            // debe
            // 
            this.debe.DataPropertyName = "egreso";
            this.debe.HeaderText = "EGRESO (ACREEDOR)";
            this.debe.Name = "debe";
            this.debe.ReadOnly = true;
            // 
            // tipoCV
            // 
            this.tipoCV.DataPropertyName = "tcventa";
            this.tipoCV.HeaderText = "TipoCambio Venta";
            this.tipoCV.Name = "tipoCV";
            this.tipoCV.ReadOnly = true;
            this.tipoCV.Visible = false;
            // 
            // saldo
            // 
            this.saldo.DataPropertyName = "saldo";
            this.saldo.HeaderText = "SALDO";
            this.saldo.Name = "saldo";
            this.saldo.ReadOnly = true;
            this.saldo.Width = 80;
            // 
            // tipoCC
            // 
            this.tipoCC.DataPropertyName = "tccompra";
            this.tipoCC.HeaderText = "TipoCambio Compra";
            this.tipoCC.Name = "tipoCC";
            this.tipoCC.ReadOnly = true;
            this.tipoCC.Visible = false;
            // 
            // codnotasalida
            // 
            this.codnotasalida.HeaderText = "codnotasalida";
            this.codnotasalida.Name = "codnotasalida";
            this.codnotasalida.ReadOnly = true;
            this.codnotasalida.Visible = false;
            // 
            // codnotaingreso
            // 
            this.codnotaingreso.HeaderText = "codnotaingreso";
            this.codnotaingreso.Name = "codnotaingreso";
            this.codnotaingreso.ReadOnly = true;
            this.codnotaingreso.Visible = false;
            // 
            // fecharegistro
            // 
            this.fecharegistro.HeaderText = "fecharegistro";
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
            this.fecharegistro.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "NOMBRE";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 150;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "DIRECCION";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Visible = false;
            this.direccion.Width = 150;
            // 
            // dni
            // 
            this.dni.DataPropertyName = "dni";
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 200;
            // 
            // activo
            // 
            this.activo.DataPropertyName = "activo";
            this.activo.HeaderText = "activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            this.activo.Visible = false;
            // 
            // descripcionactivo
            // 
            this.descripcionactivo.DataPropertyName = "descripcionactivo";
            this.descripcionactivo.HeaderText = "Desc. Pago";
            this.descripcionactivo.Name = "descripcionactivo";
            this.descripcionactivo.ReadOnly = true;
            // 
            // buttonItem9
            // 
            this.buttonItem9.ImageIndex = 18;
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.SubItemsExpandWidth = 14;
            this.buttonItem9.Text = "Salir";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add Green Button.png");
            this.imageList1.Images.SetKeyName(1, "Add.png");
            this.imageList1.Images.SetKeyName(2, "Remove.png");
            this.imageList1.Images.SetKeyName(3, "Write Document.png");
            this.imageList1.Images.SetKeyName(4, "New Document.png");
            this.imageList1.Images.SetKeyName(5, "Remove Document.png");
            this.imageList1.Images.SetKeyName(6, "1328102023_Copy.png");
            this.imageList1.Images.SetKeyName(7, "document-print.png");
            this.imageList1.Images.SetKeyName(8, "g-icon-new-update.png");
            this.imageList1.Images.SetKeyName(9, "refresh_256.png");
            this.imageList1.Images.SetKeyName(10, "Refresh-icon.png");
            this.imageList1.Images.SetKeyName(11, "search (1).png");
            this.imageList1.Images.SetKeyName(12, "search (5).png");
            this.imageList1.Images.SetKeyName(13, "search (6).png");
            this.imageList1.Images.SetKeyName(14, "search (8).png");
            this.imageList1.Images.SetKeyName(15, "search_top.png");
            this.imageList1.Images.SetKeyName(16, "icon-47203_640.png");
            this.imageList1.Images.SetKeyName(17, "Folder open.png");
            this.imageList1.Images.SetKeyName(18, "por-periodo-de-sesiones-icono-8745-96.png");
            this.imageList1.Images.SetKeyName(19, "icon_check.png");
            this.imageList1.Images.SetKeyName(20, "Symbol-Delete.png");
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Images = this.imageList1;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biNuevo,
            this.biEditar,
            this.biEliminar,
            this.btnConsultar,
            this.biActualizar,
            this.buttonItem7,
            this.biImprimir,
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem3});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1183, 59);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar1.TabIndex = 7;
            this.ribbonBar1.Text = "ribbonBar1";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.TitleVisible = false;
            this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
            // 
            // biNuevo
            // 
            this.biNuevo.ImageIndex = 4;
            this.biNuevo.ImagePaddingHorizontal = 10;
            this.biNuevo.ImagePaddingVertical = 15;
            this.biNuevo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biNuevo.Name = "biNuevo";
            this.biNuevo.SubItemsExpandWidth = 14;
            this.biNuevo.Text = "Nuevo";
            this.biNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // biEditar
            // 
            this.biEditar.ImageIndex = 3;
            this.biEditar.ImagePaddingHorizontal = 10;
            this.biEditar.ImagePaddingVertical = 15;
            this.biEditar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biEditar.Name = "biEditar";
            this.biEditar.SubItemsExpandWidth = 14;
            this.biEditar.Text = "Consultar";
            this.biEditar.Visible = false;
            this.biEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // biEliminar
            // 
            this.biEliminar.ImageIndex = 5;
            this.biEliminar.ImagePaddingHorizontal = 10;
            this.biEliminar.ImagePaddingVertical = 15;
            this.biEliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biEliminar.Name = "biEliminar";
            this.biEliminar.SubItemsExpandWidth = 14;
            this.biEliminar.Text = "Eliminar";
            this.biEliminar.Visible = false;
            this.biEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Enabled = false;
            this.btnConsultar.ImageIndex = 17;
            this.btnConsultar.ImagePaddingVertical = 4;
            this.btnConsultar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.SubItemsExpandWidth = 14;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Visible = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // biActualizar
            // 
            this.biActualizar.ImageIndex = 8;
            this.biActualizar.ImagePaddingHorizontal = 10;
            this.biActualizar.ImagePaddingVertical = 15;
            this.biActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biActualizar.Name = "biActualizar";
            this.biActualizar.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.biActualizar.SubItemsExpandWidth = 14;
            this.biActualizar.Text = "Actualizar";
            this.biActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // buttonItem7
            // 
            this.buttonItem7.ImageIndex = 11;
            this.buttonItem7.ImagePaddingHorizontal = 10;
            this.buttonItem7.ImagePaddingVertical = 15;
            this.buttonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlB);
            this.buttonItem7.SubItemsExpandWidth = 14;
            this.buttonItem7.Text = "Buscar";
            this.buttonItem7.Visible = false;
            // 
            // biImprimir
            // 
            this.biImprimir.ImageIndex = 7;
            this.biImprimir.ImagePaddingHorizontal = 10;
            this.biImprimir.ImagePaddingVertical = 15;
            this.biImprimir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biImprimir.Name = "biImprimir";
            this.biImprimir.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
            this.biImprimir.SubItemsExpandWidth = 14;
            this.biImprimir.Text = "Imprimir";
            this.biImprimir.Click += new System.EventHandler(this.biImprimir_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.ImageIndex = 18;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "Salir";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ImageIndex = 19;
            this.buttonItem2.ImagePaddingHorizontal = 10;
            this.buttonItem2.ImagePaddingVertical = 15;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "Activar";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ImageIndex = 20;
            this.buttonItem3.ImagePaddingHorizontal = 10;
            this.buttonItem3.ImagePaddingVertical = 15;
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.buttonItem3.SubItemsExpandWidth = 14;
            this.buttonItem3.Text = "Desactivar";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // frmMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1183, 441);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.ribbonBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMovimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMovimientos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMovimientos_Load);
            this.Shown += new System.EventHandler(this.frmMovimientos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem biNuevo;
        private DevComponents.DotNetBar.ButtonItem biEditar;
        private DevComponents.DotNetBar.ButtonItem biEliminar;
        private DevComponents.DotNetBar.ButtonItem btnConsultar;
        private DevComponents.DotNetBar.ButtonItem biActualizar;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem biImprimir;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCtaCorriente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentacorriente;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn desctipomovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn haber;
        private System.Windows.Forms.DataGridViewTextBoxColumn debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCV;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn codnotasalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn codnotaingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionactivo;
    }
}