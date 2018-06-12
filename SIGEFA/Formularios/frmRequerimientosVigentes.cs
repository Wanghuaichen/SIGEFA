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

    public partial class frmRequerimientosVigentes : DevComponents.DotNetBar.Office2007Form    
    {
        clsAlmacen alma=new clsAlmacen();
        clsAdmAlmacen admalma=new clsAdmAlmacen();
        clsAdmRequerimiento AdmReq = new clsAdmRequerimiento();
        clsRequerimiento Req = new clsRequerimiento();        
        public Int32 Proceso = 0; //
        clsAdmAlmacen Admalmac = new clsAdmAlmacen();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 tipo = 0, almadest=0;
        private Int32 tip = 0;
        private String AtendidoReq = "" ;
        public String comentario="";
        public frmRequerimientosVigentes()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            dgvOrdenes.DataSource = data;
            data.DataSource = AdmReq.MuestraRequerimiento(frmLogin.iCodAlmacen, dtpDesde.Value.Date, dtpHasta.Value.Date);
            data.Filter = String.Empty;
            filtro = String.Empty;
        }
        public void CargaListaHistorial(Int32 alma)
        {
            dgvOrdenes.DataSource = data;
            data.DataSource = AdmReq.MuestraRequerimientoHistorial(alma, dtpDesde.Value.Date, dtpHasta.Value.Date);
            data.Filter = String.Empty;
            filtro = String.Empty;
        }

        private void btnIrCotizacion_Click(object sender, EventArgs e)
        {
            
            if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            {
                DataGridViewRow row = dgvOrdenes.CurrentRow;
                if (Application.OpenForms["frmRequerimiento"] != null)
                {
                    Application.OpenForms["frmRequerimiento"].Close();
                }
                else
                {
                    frmRequerimiento form = new frmRequerimiento();
                    form.MdiParent = this.MdiParent;
                    form.CodRequer = Req.CodRequerimiento;
                    form.Proceso = 3;
                    form.Tipo = tipo;
                    form.Show();
                }
            }
        }

        private void dgvCotizaciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && e.Row.Selected)
            {
                Req.CodRequerimiento= Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                Req.CodAlmacen = Convert.ToInt32(e.Row.Cells[codAlmacen.Name].Value);
                Req.codAlmaDestino = Convert.ToInt32(e.Row.Cells[almacendestino.Name].Value);
                AtendidoReq = e.Row.Cells[Atendido.Name].Value.ToString();  
            }
        }

        private void dgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            {
                DataGridViewRow row = dgvOrdenes.CurrentRow;
                if (Application.OpenForms["frmRequerimiento"] != null)
                {
                    Application.OpenForms["frmRequerimiento"].Close();
                }
                else
                {
                    frmRequerimiento form = new frmRequerimiento();
                    form.MdiParent = this.MdiParent;
                    form.CodRequer = Req.CodRequerimiento;
                    form.Proceso = 3;
                    form.Tipo = tipo;
                    form.Show();
                }
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow != null && Req.CodRequerimiento != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular el Requerimiento seleccionado", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    
                    if (AdmReq.anular(Req.CodRequerimiento))
                    {
                        MessageBox.Show("El requerimiento ha sido anulado correctamente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (tipo == 1)
                        {
                            CargaLista();
                        }
                        else if (tipo == 2)
                        {
                            CargaListaHistorial(frmLogin.iCodAlmacen);
                        }
                    }
                }
            }
           
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                CargaLista();
            }
            if (tipo == 2)
            {
                if (Convert.ToInt32(cmbAlmacen.SelectedValue) >0)
                {
                    CargaListaHistorial(frmLogin.iCodAlmacen);
                }
                else
                {
                    CargaListaHistorial(frmLogin.iCodAlmacen);
                }
            }
            if (Req.codAlmaDestino == frmLogin.iCodAlmacen) btnrechazar.Visible = true;
            else btnrechazar.Visible = false;
        }

        private void frmRequerimientosVigentes_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                Estado.Visible = false;
                Atendido.Visible = false;
                lbalmacen.Visible = false;
                cmbAlmacen.Visible = false;
                btnAtendido.Visible = false;
                btnrechazar.Visible = false;
                btnAnular.Visible = true;
                ComentarioRechazado.Visible = false;
                CargaLista();
            }
            else if (tipo == 2)
            {
                CargaListaHistorial(frmLogin.iCodAlmacen);
                cargaAlmacenes();
                Estado.Visible = true;
                Atendido.Visible = true;
                lbalmacen.Visible = true;
                cmbAlmacen.Visible = true;
                btnAtendido.Visible = true;
                btnAnular.Visible = false;
            }
            
            
        }

        private void cargaAlmacenes()
        {
            cmbAlmacen.DataSource = Admalmac.ListaAlmacen2();
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.ValueMember = "codAlmacen";
            alma = admalma.CargaAlmacen(frmLogin.iCodAlmacen);
            if (Convert.ToBoolean(alma.EstadoPrincipal))
            {
                cmbAlmacen.SelectedIndex = -1;
                cmbAlmacen.Enabled = false;
            }
            else
            {
                cmbAlmacen.SelectedValue = frmLogin.iCodAlmacen;
                cmbAlmacen.Enabled = false;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label2.Text.Trim(), txtFiltro.Text.Trim());
                }
                else
                {
                    data.Filter = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dgvOrdenes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvOrdenes.Columns[e.ColumnIndex].HeaderText;
            label2.Text = dgvOrdenes.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void button1_Click(object sender, EventArgs e)// enviar requerimiento 
        {
            if (tipo == 1) {
                    frmSeleccionarAlmacen alma = new frmSeleccionarAlmacen();
                    alma.tipo = 2;
                    alma.ShowDialog();
                    Req.codAlmaDestino = almadest;
                    if (dgvOrdenes.CurrentRow != null && Req.codAlmaDestino != 0 && Req.codAlmaDestino != frmLogin.iCodAlmacen)
                    {
                        DialogResult dlgResult = MessageBox.Show("Esta seguro que desea enviar el Borrador Requerimiento seleccionado", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {

                            if (AdmReq.Envio(Req.codAlmaDestino, Req.CodRequerimiento))
                            {
                                MessageBox.Show("El Borrador de requerimiento ha envio correctamente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaLista();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Se Puede Enviar, verifique Almacen Destino", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            else if (tipo == 2) {
                if (Req.CodAlmacen != frmLogin.iCodAlmacen)
                {
                    frmSeleccionarAlmacen alma = new frmSeleccionarAlmacen();
                    alma.tipo = 2;
                    alma.ShowDialog();
                    Req.codAlmaDestino = almadest;
                    if (dgvOrdenes.CurrentRow != null && Req.codAlmaDestino != 0 && Req.codAlmaDestino != frmLogin.iCodAlmacen && Req.codAlmaDestino != Req.CodAlmacen)
                    {
                        DialogResult dlgResult = MessageBox.Show("Esta seguro que desea enviar el Borrador Requerimiento seleccionado", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {

                            if (AdmReq.Envio(Req.codAlmaDestino, Req.CodRequerimiento))
                            {
                                MessageBox.Show("El Borrador de requerimiento ha envio correctamente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaLista();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Se Puede Enviar, verifique Almacen Destino", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("No Se Puede Enviar, Ya tiene un Almacen Destino", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnrechazar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow != null && Req.codAlmaDestino == frmLogin.iCodAlmacen && AtendidoReq == "VIGENTE")
            {
                DialogResult dlgResult = MessageBox.Show(
                    "Esta seguro que desea rechazar el Requerimiento seleccionado", "Requerimiento",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {

                    if (Application.OpenForms["frmVigenciaCotizacion"] != null)
                    {
                        Application.OpenForms["frmVigenciaCotizacion"].Close();
                    }
                    else
                    {
                        frmVigenciaCotizacion form = new frmVigenciaCotizacion();
                        form.Proceso = 2;
                        form.Procede = 1;
                        form.groupBox2.Visible = true;
                        form.groupBox1.Visible = false;
                        form.CodRequerimiento = Req.CodRequerimiento;
                        form.Show();


                        //if (tipo == 2)
                        //{
                        //    CargaListaHistorial(frmLogin.iCodAlmacen, tip);
                        //}
                    }    
                }            
            }
            else
            {
                MessageBox.Show("No se puede anular. Verifique");
            }
        }

        private void btnAtendido_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow != null && Req.codAlmaDestino == frmLogin.iCodAlmacen && AtendidoReq == "VIGENTE")
            {
                DialogResult dlgResult = MessageBox.Show(
                    "Esta seguro que desea Atender el Requerimiento seleccionado", "Requerimiento",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmReq.Atender(Req.CodRequerimiento))
                    {
                        MessageBox.Show("El Borrador de requerimiento ha envio correctamente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("No se puede Atender Requerimiento. Verifique");
            }
        }

        private void frmRequerimientosVigentes_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
