﻿namespace SIGEFA.Reportes
{
    partial class frmRptCobranzaSucursal
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
            this.cRVRptCobranzaSucursal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVRptCobranzaSucursal
            // 
            this.cRVRptCobranzaSucursal.ActiveViewIndex = -1;
            this.cRVRptCobranzaSucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVRptCobranzaSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVRptCobranzaSucursal.Location = new System.Drawing.Point(0, 0);
            this.cRVRptCobranzaSucursal.Name = "cRVRptCobranzaSucursal";
            this.cRVRptCobranzaSucursal.SelectionFormula = "";
            this.cRVRptCobranzaSucursal.Size = new System.Drawing.Size(284, 262);
            this.cRVRptCobranzaSucursal.TabIndex = 0;
            this.cRVRptCobranzaSucursal.ViewTimeSelectionFormula = "";
            // 
            // frmRptCobranzaSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cRVRptCobranzaSucursal);
            this.Name = "frmRptCobranzaSucursal";
            this.Text = "frmRptCobranzaSucursal";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVRptCobranzaSucursal;

    }
}