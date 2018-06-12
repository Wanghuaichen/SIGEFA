namespace SIGEFA.Formularios
{
    partial class frmGestionTipoEgresoRP
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
            this.cRVTipoEgresoCaja = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVTipoEgresoCaja
            // 
            this.cRVTipoEgresoCaja.ActiveViewIndex = -1;
            this.cRVTipoEgresoCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVTipoEgresoCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVTipoEgresoCaja.Location = new System.Drawing.Point(0, 0);
            this.cRVTipoEgresoCaja.Name = "cRVTipoEgresoCaja";
            this.cRVTipoEgresoCaja.SelectionFormula = "";
            this.cRVTipoEgresoCaja.Size = new System.Drawing.Size(427, 340);
            this.cRVTipoEgresoCaja.TabIndex = 0;
            this.cRVTipoEgresoCaja.ViewTimeSelectionFormula = "";
            // 
            // frmGestionTipoEgresoRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 340);
            this.Controls.Add(this.cRVTipoEgresoCaja);
            this.Name = "frmGestionTipoEgresoRP";
            this.Text = "frmGestionTipoEgresoRP";
            this.Load += new System.EventHandler(this.frmGestionTipoEgresoRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVTipoEgresoCaja;

    }
}