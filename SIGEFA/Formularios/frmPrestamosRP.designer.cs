namespace SIGEFA.Formularios
{
    partial class frmPrestamosRP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrestamosRP));
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.cRVClientesRP = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
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
            //this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Images = this.imageList1;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(762, 34);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar1.TabIndex = 0;
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
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ACP_PDF 2_file_document.png");
            this.imageList1.Images.SetKeyName(1, "Adobe_PDF_icon.png");
            this.imageList1.Images.SetKeyName(2, "excel_icon.png");
            this.imageList1.Images.SetKeyName(3, "Excel-icon.png");
            this.imageList1.Images.SetKeyName(4, "microsoft excel.png");
            this.imageList1.Images.SetKeyName(5, "pdfIcon.png");
            this.imageList1.Images.SetKeyName(6, "52ff0e80b07d28b590bbc4b30befde52 (1).png");
            this.imageList1.Images.SetKeyName(7, "52ff0e80b07d28b590bbc4b30befde52.png");
            this.imageList1.Images.SetKeyName(8, "647702-excel-512.png");
            this.imageList1.Images.SetKeyName(9, "pdf-512.png");
            this.imageList1.Images.SetKeyName(10, "unnamed.png");
            // 
            // buttonItem1
            // 
            this.buttonItem1.ImageIndex = 8;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Visible = false;
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ImageIndex = 9;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Visible = false;
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // cRVClientesRP
            // 
            this.cRVClientesRP.ActiveViewIndex = -1;
            this.cRVClientesRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVClientesRP.DisplayGroupTree = false;
            this.cRVClientesRP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVClientesRP.Location = new System.Drawing.Point(0, 34);
            this.cRVClientesRP.Name = "cRVClientesRP";
            this.cRVClientesRP.SelectionFormula = "";
            this.cRVClientesRP.ShowCloseButton = false;
            this.cRVClientesRP.ShowExportButton = false;
            this.cRVClientesRP.ShowGotoPageButton = false;
            this.cRVClientesRP.ShowGroupTreeButton = false;
            this.cRVClientesRP.Size = new System.Drawing.Size(762, 306);
            this.cRVClientesRP.TabIndex = 2;
            this.cRVClientesRP.ViewTimeSelectionFormula = "";
            // 
            // frmPrestamosRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 340);
            this.Controls.Add(this.cRVClientesRP);
            this.Controls.Add(this.ribbonBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPrestamosRP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestamos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClientesRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVClientesRP;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;

    }
}