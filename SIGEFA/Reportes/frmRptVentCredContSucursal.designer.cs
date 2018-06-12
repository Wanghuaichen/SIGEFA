namespace SIGEFA.Reportes
{
    partial class frmRptVentCredContSucursal
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
            this.cRVRptVentCredContSucursal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVRptVentCredContSucursal
            // 
            this.cRVRptVentCredContSucursal.ActiveViewIndex = -1;
            this.cRVRptVentCredContSucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVRptVentCredContSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVRptVentCredContSucursal.Location = new System.Drawing.Point(0, 0);
            this.cRVRptVentCredContSucursal.Name = "cRVRptVentCredContSucursal";
            this.cRVRptVentCredContSucursal.SelectionFormula = "";
            this.cRVRptVentCredContSucursal.Size = new System.Drawing.Size(284, 262);
            this.cRVRptVentCredContSucursal.TabIndex = 0;
            this.cRVRptVentCredContSucursal.ViewTimeSelectionFormula = "";
            // 
            // frmRptVentCredContSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cRVRptVentCredContSucursal);
            this.Name = "frmRptVentCredContSucursal";
            this.Text = "frmRptVentCredContSucursal";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVRptVentCredContSucursal;

    }
}