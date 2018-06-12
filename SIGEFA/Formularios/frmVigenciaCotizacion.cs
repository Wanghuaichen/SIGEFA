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

namespace SIGEFA.Formularios
{
    public partial class frmVigenciaCotizacion : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa AdmEmp = new clsAdmEmpresa();
        clsValidar ok = new clsValidar();
        public Int32 Proceso = 0, CodRequerimiento=0,serie=0,Procede=0;
        public String numeracion;
        clsAdmRequerimiento AdmReq = new clsAdmRequerimiento();
        clsAdmNotaIngreso admNotaIngreso = new clsAdmNotaIngreso();

        public frmVigenciaCotizacion()
        {
            InitializeComponent();
        }

        private void frmVigenciaCotizacion_Load(object sender, EventArgs e)
        {
            if(Proceso==0)
            CargaConfiguracion();
        }

        private void CargaConfiguracion()
        {
            if (frmLogin.Configuracion != null)
            {

                txtDiasVigencia.Text = frmLogin.Configuracion.DiasVigencia.ToString();
                chbfacturasVencidas.Checked = frmLogin.Configuracion.FacturasVencidas;
            }
            else
            {
                frmLogin.Configuracion = new clsParametros();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Proceso == 0)
            {
                if (txtDiasVigencia.Text != "")
                {
                    frmLogin.Configuracion.DiasVigencia = Convert.ToInt32(txtDiasVigencia.Text);
                    frmLogin.Configuracion.FacturasVencidas = chbfacturasVencidas.Checked;
                }
                if (AdmEmp.UpdateConfiguracion(frmLogin.Configuracion))
                {
                    frmLogin.Configuracion = AdmEmp.CargaConfiguracion();
                    MessageBox.Show("Los datos se guardaron correctamente", "Configuracion", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                this.Close();
            }
            else if (Proceso == 2)
            {
                if (Procede == 1)
                {
                    if (txtComentario.Text != "")
                    {
                        if (txtComentario.Text != "" && AdmReq.rechazado(CodRequerimiento, txtComentario.Text))
                        {
                            MessageBox.Show("El requerimiento ha sido rechazado correctamente", "Requerimiento",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Close();
                        frmRequerimientosVigentes form = (frmRequerimientosVigentes)Application.OpenForms["frmRequerimientosVigentes"];
                        form.CargaListaHistorial(frmLogin.iCodAlmacen);
                    }
                    else
                    {
                        MessageBox.Show("ingrese Comentario");
                    }
                }
                else if (Procede == 2) {
                    if (txtComentario.Text != "")
                    {
                        if (txtComentario.Text != "" && admNotaIngreso.anular(serie, numeracion,txtComentario.Text))
                        {
                            MessageBox.Show("La Transferencia ha sido anulada correctamente", "Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        else
                        {
                            MessageBox.Show("Verifique.");
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ingrese Comentario");
                    }
                }

            }
        }

        private void txtDiasVigencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.NumerosEnteros(e);
        }
    }
}
