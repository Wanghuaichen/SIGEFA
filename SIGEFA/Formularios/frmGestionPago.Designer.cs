namespace SIGEFA.Formularios
{
    partial class frmGestionPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionPago));
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtPagado = new System.Windows.Forms.TextBox();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.gbMonedas = new System.Windows.Forms.GroupBox();
            this.btExacto = new System.Windows.Forms.Button();
            this.btM50cent = new System.Windows.Forms.Button();
            this.btM20cent = new System.Windows.Forms.Button();
            this.btM10cent = new System.Windows.Forms.Button();
            this.bt200sol = new System.Windows.Forms.Button();
            this.bt100sol = new System.Windows.Forms.Button();
            this.bt50sol = new System.Windows.Forms.Button();
            this.bt20sol = new System.Windows.Forms.Button();
            this.bt10sol = new System.Windows.Forms.Button();
            this.bt5sol = new System.Windows.Forms.Button();
            this.btM2sol = new System.Windows.Forms.Button();
            this.btM1sol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbCalculadora = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btPunto = new System.Windows.Forms.Button();
            this.btCero = new System.Windows.Forms.Button();
            this.btTres = new System.Windows.Forms.Button();
            this.btDos = new System.Windows.Forms.Button();
            this.btUno = new System.Windows.Forms.Button();
            this.btSeis = new System.Windows.Forms.Button();
            this.btCinco = new System.Windows.Forms.Button();
            this.btCuatro = new System.Windows.Forms.Button();
            this.btNueve = new System.Windows.Forms.Button();
            this.btOcho = new System.Windows.Forms.Button();
            this.btSiete = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbMonedas.SuspendLayout();
            this.gbCalculadora.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(217, 262);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPagado
            // 
            this.txtPagado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagado.Location = new System.Drawing.Point(217, 290);
            this.txtPagado.Name = "txtPagado";
            this.txtPagado.Size = new System.Drawing.Size(100, 22);
            this.txtPagado.TabIndex = 1;
            this.txtPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPagado.TextChanged += new System.EventHandler(this.txtPagado_TextChanged);
            this.txtPagado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagado_KeyPress);
            // 
            // txtVuelto
            // 
            this.txtVuelto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVuelto.Location = new System.Drawing.Point(217, 318);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.ReadOnly = true;
            this.txtVuelto.Size = new System.Drawing.Size(100, 22);
            this.txtVuelto.TabIndex = 2;
            this.txtVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbMonedas
            // 
            this.gbMonedas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMonedas.Controls.Add(this.btExacto);
            this.gbMonedas.Controls.Add(this.btM50cent);
            this.gbMonedas.Controls.Add(this.btM20cent);
            this.gbMonedas.Controls.Add(this.btM10cent);
            this.gbMonedas.Controls.Add(this.bt200sol);
            this.gbMonedas.Controls.Add(this.bt100sol);
            this.gbMonedas.Controls.Add(this.bt50sol);
            this.gbMonedas.Controls.Add(this.bt20sol);
            this.gbMonedas.Controls.Add(this.bt10sol);
            this.gbMonedas.Controls.Add(this.bt5sol);
            this.gbMonedas.Controls.Add(this.btM2sol);
            this.gbMonedas.Controls.Add(this.btM1sol);
            this.gbMonedas.Location = new System.Drawing.Point(149, 10);
            this.gbMonedas.Name = "gbMonedas";
            this.gbMonedas.Size = new System.Drawing.Size(177, 246);
            this.gbMonedas.TabIndex = 15;
            this.gbMonedas.TabStop = false;
            this.gbMonedas.Text = "Monedas";
            // 
            // btExacto
            // 
            this.btExacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExacto.Location = new System.Drawing.Point(118, 187);
            this.btExacto.Name = "btExacto";
            this.btExacto.Size = new System.Drawing.Size(50, 50);
            this.btExacto.TabIndex = 38;
            this.btExacto.Text = "Pago Exacto";
            this.btExacto.UseVisualStyleBackColor = true;
            // 
            // btM50cent
            // 
            this.btM50cent.Location = new System.Drawing.Point(118, 19);
            this.btM50cent.Name = "btM50cent";
            this.btM50cent.Size = new System.Drawing.Size(50, 50);
            this.btM50cent.TabIndex = 37;
            this.btM50cent.Text = "0.5";
            this.btM50cent.UseVisualStyleBackColor = true;
            // 
            // btM20cent
            // 
            this.btM20cent.Location = new System.Drawing.Point(62, 19);
            this.btM20cent.Name = "btM20cent";
            this.btM20cent.Size = new System.Drawing.Size(50, 50);
            this.btM20cent.TabIndex = 36;
            this.btM20cent.Text = "0.2";
            this.btM20cent.UseVisualStyleBackColor = true;
            // 
            // btM10cent
            // 
            this.btM10cent.Location = new System.Drawing.Point(6, 19);
            this.btM10cent.Name = "btM10cent";
            this.btM10cent.Size = new System.Drawing.Size(50, 50);
            this.btM10cent.TabIndex = 35;
            this.btM10cent.Text = "0.1";
            this.btM10cent.UseVisualStyleBackColor = true;
            // 
            // bt200sol
            // 
            this.bt200sol.Location = new System.Drawing.Point(62, 187);
            this.bt200sol.Name = "bt200sol";
            this.bt200sol.Size = new System.Drawing.Size(50, 50);
            this.bt200sol.TabIndex = 34;
            this.bt200sol.Text = "200";
            this.bt200sol.UseVisualStyleBackColor = true;
            // 
            // bt100sol
            // 
            this.bt100sol.Location = new System.Drawing.Point(6, 187);
            this.bt100sol.Name = "bt100sol";
            this.bt100sol.Size = new System.Drawing.Size(50, 50);
            this.bt100sol.TabIndex = 33;
            this.bt100sol.Text = "100";
            this.bt100sol.UseVisualStyleBackColor = true;
            // 
            // bt50sol
            // 
            this.bt50sol.Location = new System.Drawing.Point(118, 131);
            this.bt50sol.Name = "bt50sol";
            this.bt50sol.Size = new System.Drawing.Size(50, 50);
            this.bt50sol.TabIndex = 32;
            this.bt50sol.Text = "50";
            this.bt50sol.UseVisualStyleBackColor = true;
            // 
            // bt20sol
            // 
            this.bt20sol.Location = new System.Drawing.Point(62, 131);
            this.bt20sol.Name = "bt20sol";
            this.bt20sol.Size = new System.Drawing.Size(50, 50);
            this.bt20sol.TabIndex = 31;
            this.bt20sol.Text = "20";
            this.bt20sol.UseVisualStyleBackColor = true;
            // 
            // bt10sol
            // 
            this.bt10sol.Location = new System.Drawing.Point(6, 131);
            this.bt10sol.Name = "bt10sol";
            this.bt10sol.Size = new System.Drawing.Size(50, 50);
            this.bt10sol.TabIndex = 30;
            this.bt10sol.Text = "10";
            this.bt10sol.UseVisualStyleBackColor = true;
            // 
            // bt5sol
            // 
            this.bt5sol.Location = new System.Drawing.Point(118, 75);
            this.bt5sol.Name = "bt5sol";
            this.bt5sol.Size = new System.Drawing.Size(50, 50);
            this.bt5sol.TabIndex = 29;
            this.bt5sol.Text = "5";
            this.bt5sol.UseVisualStyleBackColor = true;
            // 
            // btM2sol
            // 
            this.btM2sol.Location = new System.Drawing.Point(62, 75);
            this.btM2sol.Name = "btM2sol";
            this.btM2sol.Size = new System.Drawing.Size(50, 50);
            this.btM2sol.TabIndex = 28;
            this.btM2sol.Text = "2";
            this.btM2sol.UseVisualStyleBackColor = true;
            // 
            // btM1sol
            // 
            this.btM1sol.Location = new System.Drawing.Point(6, 75);
            this.btM1sol.Name = "btM1sol";
            this.btM1sol.Size = new System.Drawing.Size(50, 50);
            this.btM1sol.TabIndex = 27;
            this.btM1sol.Text = "1";
            this.btM1sol.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Total :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Pagado :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(148, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "A Pagar :";
            // 
            // gbCalculadora
            // 
            this.gbCalculadora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCalculadora.Controls.Add(this.button1);
            this.gbCalculadora.Controls.Add(this.btPunto);
            this.gbCalculadora.Controls.Add(this.btCero);
            this.gbCalculadora.Controls.Add(this.btTres);
            this.gbCalculadora.Controls.Add(this.btDos);
            this.gbCalculadora.Controls.Add(this.btUno);
            this.gbCalculadora.Controls.Add(this.btSeis);
            this.gbCalculadora.Controls.Add(this.btCinco);
            this.gbCalculadora.Controls.Add(this.btCuatro);
            this.gbCalculadora.Controls.Add(this.btNueve);
            this.gbCalculadora.Controls.Add(this.btOcho);
            this.gbCalculadora.Controls.Add(this.btSiete);
            this.gbCalculadora.Location = new System.Drawing.Point(149, 10);
            this.gbCalculadora.Name = "gbCalculadora";
            this.gbCalculadora.Size = new System.Drawing.Size(177, 246);
            this.gbCalculadora.TabIndex = 19;
            this.gbCalculadora.TabStop = false;
            this.gbCalculadora.Text = "Telclado Numérico";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 22;
            this.button1.Text = "C";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btPunto
            // 
            this.btPunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPunto.Location = new System.Drawing.Point(118, 187);
            this.btPunto.Name = "btPunto";
            this.btPunto.Size = new System.Drawing.Size(50, 50);
            this.btPunto.TabIndex = 21;
            this.btPunto.Text = ".";
            this.btPunto.UseVisualStyleBackColor = true;
            this.btPunto.Click += new System.EventHandler(this.btPunto_Click);
            // 
            // btCero
            // 
            this.btCero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCero.Location = new System.Drawing.Point(62, 187);
            this.btCero.Name = "btCero";
            this.btCero.Size = new System.Drawing.Size(50, 50);
            this.btCero.TabIndex = 20;
            this.btCero.Text = "0";
            this.btCero.UseVisualStyleBackColor = true;
            this.btCero.Click += new System.EventHandler(this.btCero_Click);
            // 
            // btTres
            // 
            this.btTres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTres.Location = new System.Drawing.Point(118, 131);
            this.btTres.Name = "btTres";
            this.btTres.Size = new System.Drawing.Size(50, 50);
            this.btTres.TabIndex = 19;
            this.btTres.Text = "3";
            this.btTres.UseVisualStyleBackColor = true;
            this.btTres.Click += new System.EventHandler(this.btTres_Click);
            // 
            // btDos
            // 
            this.btDos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDos.Location = new System.Drawing.Point(62, 131);
            this.btDos.Name = "btDos";
            this.btDos.Size = new System.Drawing.Size(50, 50);
            this.btDos.TabIndex = 18;
            this.btDos.Text = "2";
            this.btDos.UseVisualStyleBackColor = true;
            this.btDos.Click += new System.EventHandler(this.btDos_Click);
            // 
            // btUno
            // 
            this.btUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUno.Location = new System.Drawing.Point(6, 131);
            this.btUno.Name = "btUno";
            this.btUno.Size = new System.Drawing.Size(50, 50);
            this.btUno.TabIndex = 17;
            this.btUno.Text = "1";
            this.btUno.UseVisualStyleBackColor = true;
            this.btUno.Click += new System.EventHandler(this.btUno_Click);
            // 
            // btSeis
            // 
            this.btSeis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSeis.Location = new System.Drawing.Point(118, 75);
            this.btSeis.Name = "btSeis";
            this.btSeis.Size = new System.Drawing.Size(50, 50);
            this.btSeis.TabIndex = 16;
            this.btSeis.Text = "6";
            this.btSeis.UseVisualStyleBackColor = true;
            this.btSeis.Click += new System.EventHandler(this.btSeis_Click);
            // 
            // btCinco
            // 
            this.btCinco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCinco.Location = new System.Drawing.Point(62, 75);
            this.btCinco.Name = "btCinco";
            this.btCinco.Size = new System.Drawing.Size(50, 50);
            this.btCinco.TabIndex = 15;
            this.btCinco.Text = "5";
            this.btCinco.UseVisualStyleBackColor = true;
            this.btCinco.Click += new System.EventHandler(this.btCinco_Click);
            // 
            // btCuatro
            // 
            this.btCuatro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCuatro.Location = new System.Drawing.Point(6, 75);
            this.btCuatro.Name = "btCuatro";
            this.btCuatro.Size = new System.Drawing.Size(50, 50);
            this.btCuatro.TabIndex = 14;
            this.btCuatro.Text = "4";
            this.btCuatro.UseVisualStyleBackColor = true;
            this.btCuatro.Click += new System.EventHandler(this.btCuatro_Click);
            // 
            // btNueve
            // 
            this.btNueve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNueve.Location = new System.Drawing.Point(118, 19);
            this.btNueve.Name = "btNueve";
            this.btNueve.Size = new System.Drawing.Size(50, 50);
            this.btNueve.TabIndex = 13;
            this.btNueve.Text = "9";
            this.btNueve.UseVisualStyleBackColor = true;
            this.btNueve.Click += new System.EventHandler(this.btNueve_Click);
            // 
            // btOcho
            // 
            this.btOcho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOcho.Location = new System.Drawing.Point(62, 19);
            this.btOcho.Name = "btOcho";
            this.btOcho.Size = new System.Drawing.Size(50, 50);
            this.btOcho.TabIndex = 12;
            this.btOcho.Text = "8";
            this.btOcho.UseVisualStyleBackColor = true;
            this.btOcho.Click += new System.EventHandler(this.btOcho_Click);
            // 
            // btSiete
            // 
            this.btSiete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSiete.Location = new System.Drawing.Point(6, 19);
            this.btSiete.Name = "btSiete";
            this.btSiete.Size = new System.Drawing.Size(50, 50);
            this.btSiete.TabIndex = 11;
            this.btSiete.Text = "7";
            this.btSiete.UseVisualStyleBackColor = true;
            this.btSiete.Click += new System.EventHandler(this.btSiete_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ImageIndex = 4;
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(238, 346);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(79, 37);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Write Document.png");
            this.imageList1.Images.SetKeyName(1, "New Document.png");
            this.imageList1.Images.SetKeyName(2, "Remove Document.png");
            this.imageList1.Images.SetKeyName(3, "document-print.png");
            this.imageList1.Images.SetKeyName(4, "guardar-documento-icono-7840-48.png");
            this.imageList1.Images.SetKeyName(5, "exit.png");
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.ImageIndex = 3;
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(149, 346);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(79, 37);
            this.btnImprimir.TabIndex = 21;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmGestionPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 395);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVuelto);
            this.Controls.Add(this.txtPagado);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.gbCalculadora);
            this.Controls.Add(this.gbMonedas);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGestionPago";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion Pago";
            this.Load += new System.EventHandler(this.frmGestionPago_Load);
            this.Shown += new System.EventHandler(this.frmGestionPago_Shown);
            this.gbMonedas.ResumeLayout(false);
            this.gbCalculadora.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtPagado;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.GroupBox gbMonedas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbCalculadora;
        private System.Windows.Forms.Button btExacto;
        private System.Windows.Forms.Button btM50cent;
        private System.Windows.Forms.Button btM20cent;
        private System.Windows.Forms.Button btM10cent;
        private System.Windows.Forms.Button bt200sol;
        private System.Windows.Forms.Button bt100sol;
        private System.Windows.Forms.Button bt50sol;
        private System.Windows.Forms.Button bt20sol;
        private System.Windows.Forms.Button bt10sol;
        private System.Windows.Forms.Button bt5sol;
        private System.Windows.Forms.Button btM2sol;
        private System.Windows.Forms.Button btM1sol;
        private System.Windows.Forms.Button btPunto;
        private System.Windows.Forms.Button btCero;
        private System.Windows.Forms.Button btTres;
        private System.Windows.Forms.Button btDos;
        private System.Windows.Forms.Button btUno;
        private System.Windows.Forms.Button btSeis;
        private System.Windows.Forms.Button btCinco;
        private System.Windows.Forms.Button btCuatro;
        private System.Windows.Forms.Button btNueve;
        private System.Windows.Forms.Button btOcho;
        private System.Windows.Forms.Button btSiete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ImageList imageList1;
    }
}