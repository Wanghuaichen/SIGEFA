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
    public partial class frmTarjetasPago : DevComponents.DotNetBar.Office2007Form
    {
        clsTarjetaPago tarjeta = new clsTarjetaPago();
        clsAdmTarjetaPago admTar = new clsAdmTarjetaPago();
        clsValidar ok = new clsValidar();

        public Int32 Proceso = 0; //(1) Nuevo (2)Editar

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmTarjetasPago()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvTarjetas.DataSource = data;
            data.DataSource = admTar.MuestraTarjetas(frmLogin.iCodAlmacen);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvTarjetas.ClearSelection();
        }

        private void frmTarjetasPago_Load(object sender, EventArgs e)
        {
            groupBox1.Height = 192;
            CargaLista();
            label4.Text = "Tipo Tarjeta";
            label5.Text = "tipotarjeta";
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label5.Text.Trim(), txtFiltro.Text.Trim());
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

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            txtDescripcion.Text = "";
            txtTipoTarjeta.Text = "";
            superValidator1.Validate();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            txtTipoTarjeta.Text = tarjeta.Tipo;
            txtDescripcion.Text = tarjeta.Descripcion;
        }

        private void frmTarjetasPago_Shown(object sender, EventArgs e)
        {
            CargaLista();
            txtFiltro.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible)
            {
                this.Close();
            }
            else
            {
                Proceso = 0;
                CambiarEstados(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "" && txtTipoTarjeta.Text != "")
                {
                    tarjeta.Tipo = txtTipoTarjeta.Text;
                    tarjeta.Descripcion = txtDescripcion.Text;
                    tarjeta.Coduser = frmLogin.iCodUser;
                    tarjeta.CodAlmacen = frmLogin.iCodAlmacen;

                    if (Proceso == 1)
                    {
                        if (admTar.Insert(tarjeta))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion CtaCte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (admTar.Update(tarjeta))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
                }
            }
        }

        private void dgvTarjetas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvTarjetas.Rows.Count >= 1 && e.Row.Selected)
            {
                tarjeta.CodTarjeta = Convert.ToInt32(e.Row.Cells[codTarjeta.Name].Value);
                tarjeta.Tipo = e.Row.Cells[tipo.Name].Value.ToString();
                tarjeta.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                tarjeta.PorcComision = Convert.ToDouble(e.Row.Cells[porComision.Name].Value);
                tarjeta.AlquilerEquipo = Convert.ToDouble(e.Row.Cells[alquiler.Name].Value);
                tarjeta.Estado = Convert.ToBoolean(e.Row.Cells[estado.Name].Value);
                tarjeta.Coduser = Convert.ToInt32(e.Row.Cells[codUser.Name].Value);
                tarjeta.Fecharegistro = Convert.ToDateTime(e.Row.Cells[fecharegistro.Name].Value);
                tarjeta.CodAlmacen = Convert.ToInt32(e.Row.Cells[codAlmacen.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvTarjetas.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dgvTarjetas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label4.Text = dgvTarjetas.Columns[e.ColumnIndex].HeaderText;
            label5.Text = dgvTarjetas.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTarjetas.CurrentRow.Index != -1 && tarjeta.CodTarjeta != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "CtaCte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admTar.Delete(tarjeta.CodTarjeta, frmLogin.iCodAlmacen))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "CtaCte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
        }

        private void txtTipoTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.letras(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.letras(e);
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 15;
            frm.ShowDialog();
        }

        
    }
}
