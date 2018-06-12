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
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmArqueoFondoFijo : DevComponents.DotNetBar.Office2007Form
    {
        
        clsAdmArqueoFondoFijo admarqueo = new clsAdmArqueoFondoFijo();
        clsArqueoFondoFijo arqueo = new clsArqueoFondoFijo();

        
        List<clsDetalleArqueFondoFijo> detalle = new List<clsDetalleArqueFondoFijo>();
        public Decimal billetes = 0, monedas = 0, monto = 0,montoacumulado = 0, totalbilletes = 0, totalmonedas = 0;
        public Int32 Proceso = 0, CodArqueo=0;
        public frmArqueoFondoFijo()
        {
            InitializeComponent();
        }

        public Int32 tipodinero = 0; //1 billetes    2 monedas 

        private void frmArqueoFondoFijo_Load(object sender, EventArgs e)
        {
            CargaBilletes(1);
            CargaMonedas(2);

            if (Proceso == 1) 
            {
                txtmontoaevaluar.Text = String.Format("{0:#,##0.00}", monto);
            }
        }

        private void CargaBilletes(Int32 tipo)
        {
            try
            {
                cmbBilletes.DataSource = admarqueo.ListaDinero(tipo);
                cmbBilletes.DisplayMember = "denominacion";
                cmbBilletes.ValueMember = "coddinero";
                cmbBilletes.SelectedIndex = 0;
                cmbBilletes_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }
        }

        private void CargaMonedas(Int32 tipo)
        {
            try
            {
                cmbMonedas.DataSource = admarqueo.ListaDinero(tipo);
                cmbMonedas.DisplayMember = "denominacion";
                cmbMonedas.ValueMember = "coddinero";
                cmbMonedas.SelectedIndex = 0;
                cmbMonedas_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }
        }

        private void cmbBilletes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            billetes = admarqueo.TraeValor(Convert.ToInt32(cmbBilletes.SelectedValue));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCantidadBilletes.Text != "") 
            {
                if (Convert.ToDecimal(txtCantidadBilletes.Text) > 0) 
                {
                    if ((montoacumulado + (Convert.ToDecimal(txtCantidadBilletes.Text) * billetes)) <= monto)
                    {
                        dgvBilletes.Rows.Add(Convert.ToInt32(cmbBilletes.SelectedValue), txtCantidadBilletes.Text, cmbBilletes.Text, (Convert.ToDecimal(txtCantidadBilletes.Text) * billetes));
                        montoacumulado = montoacumulado + (Convert.ToDecimal(txtCantidadBilletes.Text) * billetes);
                        totalbilletes = totalbilletes + (Convert.ToDecimal(txtCantidadBilletes.Text) * billetes);
                        txtCantidadBilletes.Text = "0";
                        txtTotalBilletes.Text = String.Format("{0:#,##0.00}", totalbilletes);
                    }
                    else
                    {
                        MessageBox.Show("el monto sobrepasa el monto a evaluar");
                    }
                }

                txtTotal.Text = String.Format("{0:#,##0.00}", montoacumulado);
            }
        }

        private void cmbMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            monedas = admarqueo.TraeValor(Convert.ToInt32(cmbMonedas.SelectedValue));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCantidadMonedas.Text != "")
            {
                if (Convert.ToDecimal(txtCantidadMonedas.Text) > 0)                
                {
                    if ((montoacumulado + (Convert.ToDecimal(txtCantidadMonedas.Text) * monedas)) <= monto)
                    {
                        dgvMonedas.Rows.Add(Convert.ToInt32(cmbMonedas.SelectedValue), txtCantidadMonedas.Text, cmbMonedas.Text, (Convert.ToDecimal(txtCantidadMonedas.Text) * monedas));
                        montoacumulado = montoacumulado + (Convert.ToDecimal(txtCantidadMonedas.Text) * monedas);
                        totalmonedas = totalmonedas + (Convert.ToDecimal(txtCantidadMonedas.Text) * monedas);
                        txtCantidadMonedas.Text = "0";
                        txtTotalMonedas.Text = String.Format("{0:#,##0.00}", totalmonedas);
                    }
                    else 
                    {
                        MessageBox.Show("el monto sobrepasa el monto a evaluar");
                    }
                }

                txtTotal.Text = String.Format("{0:#,##0.00}", montoacumulado);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Int32 contador = 0;
                arqueo.Encargado = txtnombre.Text;
                arqueo.Horainicio = txthorainicio.Text;
                arqueo.Horafin = txthorafin.Text;
                arqueo.Total = Convert.ToDecimal(txtTotal.Text);
                arqueo.Coduser = frmLogin.iCodUser;
                arqueo.Codsucursa = frmLogin.iCodSucursal;

                if (Proceso == 1)
                {
                    if (admarqueo.insert(arqueo)) 
                    {
                        CodArqueo = arqueo.CodarqueofondodijoNuevo;

                        recorrebilletes();
                        recorremonedas();

                        if (detalle.Count > 0) 
                        {
                            foreach (clsDetalleArqueFondoFijo det in detalle) 
                            {
                                if (admarqueo.insertDetalle(det)) 
                                {
                                    contador++;
                                }
                            }

                            if (detalle.Count == contador)
                            {
                                MessageBox.Show("El Arqueo se Guardo Correctamente");
                                sololectura();
                                btnImprimir.Visible = true;
                                btnImprimir.Enabled = true;
                                txtcodarqueo.Visible = true;
                                txtcodarqueo.Text = CodArqueo.ToString().PadLeft(5, '0');
                                txtcodarqueo.ReadOnly = true;
                                label11.Visible = true;
                            }
                        }                        
                    }
                }
        }

        private void sololectura()
        {
            txtnombre.ReadOnly = true;
            txthorainicio.ReadOnly = true;
            txthorafin.ReadOnly = true;
            txtCantidadBilletes.ReadOnly = true;
            txtCantidadMonedas.ReadOnly = true;
            txtTotalBilletes.ReadOnly = true;
            txtTotalMonedas.ReadOnly = true;
            txtTotal.ReadOnly = true;
            button1.Enabled = false;
            button2.Enabled = false;
            dgvBilletes.ReadOnly = true;
            dgvMonedas.ReadOnly = true;
            cmbBilletes.Enabled = false;
            cmbMonedas.Enabled = false;
        }

        private void recorremonedas()
        {
            if (dgvMonedas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvMonedas.Rows)
                {
                    añadedetallemod(row);
                }
            }
        }

        private void añadedetallemod(DataGridViewRow fila)
        {
            clsDetalleArqueFondoFijo detallearqueo = new clsDetalleArqueFondoFijo();

            detallearqueo.Codarqueofondofijo = CodArqueo;
            detallearqueo.Coddinero = Convert.ToInt32(fila.Cells[codigo1.Name].Value);
            detallearqueo.Cantidad = Convert.ToInt32(fila.Cells[cantidad1.Name].Value);
            detallearqueo.Importe = Convert.ToDecimal(fila.Cells[importe1.Name].Value);
            detallearqueo.Coduser = frmLogin.iCodUser;

            detalle.Add(detallearqueo);
        }

        private void recorrebilletes()
        {
            if (dgvBilletes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvBilletes.Rows)
                {
                    añadedetalle(row);
                }
            }
        }

        private void añadedetalle(DataGridViewRow fila)
        {
            clsDetalleArqueFondoFijo detallearqueo = new clsDetalleArqueFondoFijo();

            detallearqueo.Codarqueofondofijo = CodArqueo;
            detallearqueo.Coddinero = Convert.ToInt32(fila.Cells[codigo.Name].Value);
            detallearqueo.Cantidad = Convert.ToInt32(fila.Cells[cantidad.Name].Value);
            detallearqueo.Importe = Convert.ToDecimal(fila.Cells[importe.Name].Value);
            detallearqueo.Coduser = frmLogin.iCodUser;

            detalle.Add(detallearqueo);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            clsReporteCaja dso = new clsReporteCaja();
            CRReporteArqueoFondoFijo rpt = new CRReporteArqueoFondoFijo();
            frmReporteArqueoFondoFijoRPT frm = new frmReporteArqueoFondoFijoRPT();
            rpt.SetDataSource(dso.ReporteArqueoFondoFijo(CodArqueo));
            frm.crvArqueoFondoFijo.ReportSource = rpt;
            frm.Show();
        }

    }
}
