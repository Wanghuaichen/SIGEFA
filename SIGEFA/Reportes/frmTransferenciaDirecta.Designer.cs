namespace SIGEFA.Reportes
{
    partial class frmTransferenciaDirecta
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
            this.crvTransferenciaPendiente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvTransferenciaPendiente
            // 
            this.crvTransferenciaPendiente.ActiveViewIndex = -1;
            this.crvTransferenciaPendiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvTransferenciaPendiente.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvTransferenciaPendiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvTransferenciaPendiente.Location = new System.Drawing.Point(0, 0);
            this.crvTransferenciaPendiente.Name = "crvTransferenciaPendiente";
            this.crvTransferenciaPendiente.Size = new System.Drawing.Size(710, 496);
            this.crvTransferenciaPendiente.TabIndex = 0;
            // 
            // frmTransferenciaDirecta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 496);
            this.Controls.Add(this.crvTransferenciaPendiente);
            this.Name = "frmTransferenciaDirecta";
            this.Text = "frmTransferenciaDirecta";
            this.Load += new System.EventHandler(this.frmTransferenciaDirecta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvTransferenciaPendiente;



    }
}