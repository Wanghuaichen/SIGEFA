using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using System.Net;
using System.IO;
using System.Xml;

namespace SIGEFA.Formularios
{
    public partial class frmCacularComision : DevComponents.DotNetBar.Office2007Form
    {        

        clsAdmVendedor vendedor = new clsAdmVendedor();       

        public frmCacularComision()
        {
            
            InitializeComponent();
        }
        private void CargaComisiones()
        {
            dgvComisiones.DataSource = vendedor.MuestraComisones(dtpFechaInicial.Value, dtpFechaFinal.Value);
            dgvComisiones.ClearSelection();            
        }
        private void filtroComisiones()
        {
            dgvComisiones.DataSource = vendedor.MuestraComisonesFiltros(Convert.ToInt32(cbVendedor.SelectedValue), Convert.ToDateTime(dtpFechaInicial.Value), Convert.ToDateTime(dtpFechaFinal.Value));
            dgvComisiones.ClearSelection();
        }
          private void CargarVendedores()
        {
            cbVendedor.DataSource = vendedor.MuestraVendedoresCombo();
            cbVendedor.DisplayMember = "apellido";
            cbVendedor.ValueMember = "codVendedor";
            cbVendedor.SelectedIndex = -1;
        }
          private void CalcularComision()
          {
              int i;
              Decimal comision_total = 0, comision1 = 0;

              if (dgvComisiones.Rows.Count > 0)
              {

                  for (i = 0; i <= dgvComisiones.Rows.Count - 1; i++)
                  {
                      comision1 = Convert.ToDecimal(dgvComisiones.Rows[i].Cells[comision.Name].Value);
                      comision_total = comision_total + comision1;
                  }
              }
              txtComisionTotal.Text = comision_total.ToString();
          }

        private void frmCacularComision_Load(object sender, EventArgs e)
        {
            DateTime iniciomes = new DateTime(DateTime.Now.Year, DateTime.Now.Month,1);
            dtpFechaInicial.Value = iniciomes;
            CargarVendedores();
            CargaComisiones(); //  cargar comisioon
            CalcularComision();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            filtroComisiones();
        }

        private void cbVendedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filtroComisiones();
            CalcularComision();
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            filtroComisiones();
            CalcularComision();
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            filtroComisiones();
            CalcularComision();
        }

     
       
    }
   
}
