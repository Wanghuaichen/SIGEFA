namespace SIGEFA.Formularios
{
    partial class frmPlanContable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanContable));
            this.gbPlan = new System.Windows.Forms.GroupBox();
            this.tvClasificacion = new System.Windows.Forms.TreeView();
            this.gbPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPlan
            // 
            this.gbPlan.Controls.Add(this.tvClasificacion);
            this.gbPlan.Location = new System.Drawing.Point(12, 12);
            this.gbPlan.Name = "gbPlan";
            this.gbPlan.Size = new System.Drawing.Size(747, 567);
            this.gbPlan.TabIndex = 0;
            this.gbPlan.TabStop = false;
            this.gbPlan.Text = "PCGE";
            // 
            // tvClasificacion
            // 
            this.tvClasificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvClasificacion.Location = new System.Drawing.Point(3, 16);
            this.tvClasificacion.Name = "tvClasificacion";
            this.tvClasificacion.Size = new System.Drawing.Size(741, 548);
            this.tvClasificacion.TabIndex = 0;
            
            // 
            // frmPlanContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 591);
            this.Controls.Add(this.gbPlan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPlanContable";
            this.Text = "Plan Contable General Empresarial";
            this.Load += new System.EventHandler(this.frmPlanContable_Load);
            this.gbPlan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPlan;
        private System.Windows.Forms.TreeView tvClasificacion;
    }
}