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
    public partial class frmCompQuimicaDosis : DevComponents.DotNetBar.Office2007Form
    {
        clsComposicionQuimica compQuim = new clsComposicionQuimica();
        clsDosis dosi = new clsDosis();
        clsAdmComposicionQuimica admCompQuim = new clsAdmComposicionQuimica();
        clsAdmDosis admDos = new clsAdmDosis();
        public static BindingSource dataComp = new BindingSource();
        public static BindingSource dataDisis = new BindingSource();
        public Int32 codPro=0;

        public frmCompQuimicaDosis()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CargaLista()
        {
            dgvComponente.DataSource = dataComp;
            dataComp.DataSource = admCompQuim.ListaComposicion(codPro);
            dgvComponente.ClearSelection();

        }

        private void CargaListaDosis()
        {
            dgvDosis.DataSource = dataDisis;
            dataDisis.DataSource = admDos.ListaDosis(codPro);
            dgvDosis.ClearSelection();

        }


        private void frmCompQuimicaDosis_Load(object sender, EventArgs e)
        {
            CargaLista();
            CargaListaDosis();
        }

        private void dgvComponente_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvComponente.Rows.Count >= 1 && e.Row.Selected)
            {
                compQuim.CodComposion = Convert.ToInt32(e.Row.Cells[codComposicion.Name].Value);
                btnEliminar.Enabled = true;
            }
            else if (dgvComponente.SelectedRows.Count == 0)
            {
                btnEliminar.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "" && txtContenido.Text != "")
            {
                compQuim.CodProducto = codPro;
                compQuim.Componente = txtDescripcion.Text;
                compQuim.Cantidad = txtContenido.Text;
                if (admCompQuim.insert(compQuim))
                {
                    //MessageBox.Show("Los datos se guardaron correctamente", "Composición Química", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescripcion.Text = "";
                    txtContenido.Text = "";
                    CargaLista();
                }
            }
            else
            {
                MessageBox.Show("Verifique que el componente y el contenido no esten vacios", "Composición Química", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComponente.SelectedRows.Count == 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Composición Química", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admCompQuim.delete(compQuim.CodComposion))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Composición Química", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una Composición", "Composición Química", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtContenido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btmAgrDosis_Click(object sender, EventArgs e)
        {
            if (txtCultivo.Text != "" && txtAplicacion.Text != "" && txtDosis.Text!="")
            {
                dosi.CodProducto= codPro;
                dosi.Cultivo = txtCultivo.Text;
                dosi.Aplicacion = txtAplicacion.Text;
                dosi.Dosis = txtDosis.Text;
                dosi.Lmrppm = txtLmr.Text;
                dosi.Pc = txtPc.Text;
                if (admDos.insert(dosi))
                {
                    txtCultivo.Text = "";
                    txtAplicacion.Text = "";
                    txtDosis.Text = "";
                    txtLmr.Text = "";
                    txtPc.Text = "";
                    CargaListaDosis();
                }
            }
            else
            {
                MessageBox.Show("Verifique que al menos el Cultivo-Forma de Aplicacion y Dosis no esten vacios", "Dosis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
            }
        }

        private void btnEliDosis_Click(object sender, EventArgs e)
        {
            if (dgvDosis.SelectedRows.Count == 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Dosis", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {

                    if (admDos.delete(dosi.CodDosis))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Dosis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaListaDosis();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una Dosis", "Dosis", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDosis_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDosis.Rows.Count >= 1 && e.Row.Selected)
            {
                dosi.CodDosis = Convert.ToInt32(e.Row.Cells[codDosis.Name].Value);
                btnEliDosis.Enabled = true;
            }
            else if (dgvDosis.SelectedRows.Count == 0)
            {
                btnEliDosis.Enabled = false;
            }
        }
    }
}
