using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using System.Windows.Forms;

namespace SIGEFA.Formularios
{
    public partial class frmTipoPrecios : DevComponents.DotNetBar.Office2007Form
    {
        public frmTipoPrecios()
        {
            InitializeComponent();
        }
        Int32 proceso;
        clsTipoPrecios tp = new clsTipoPrecios();
        clsAdmTipoPrecio admp = new clsAdmTipoPrecio();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            proceso = 1;
            btEditar.Enabled = false;
            btEliminar.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (proceso != 0 && txtdescripcion.Text != "")
            {
                tp.Sigla = txtsigla.Text;
                tp.Descripcion = txtdescripcion.Text;
                tp.CodAlmacen = Convert.ToInt32(frmLogin.iCodAlmacen);
                tp.User1 = Convert.ToInt32(frmLogin.iCodUser);
                if (proceso == 1)
                {
                    if (admp.insert((tp)))
                    {

                        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargalista();
                        groupBox1.Visible = true;
                        groupBox2.Visible = false;
                        btEditar.Enabled = true;
                        btEliminar.Enabled = true;
                    }

                }
                else if (proceso == 2)
                {
                    tp.CodTipoPrecio = Convert.ToInt32(txtcodigo.Text);
                    if (admp.update(tp))
                    {

                        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargalista();
                        groupBox1.Visible = true;
                        groupBox2.Visible = false;
                        btNuevo.Enabled = true;
                        btEliminar.Enabled = true;

                    }
                }


            }
            else
            {
                MessageBox.Show("INGRESE DATOS", "datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cargalista()
        {

            dataGridView1.DataSource = data;
            data.DataSource = admp.listaPrecios();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dataGridView1.ClearSelection();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int codTipo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[codT.Name].Value);
            if (codTipo != 0)
            {


                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Bancos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admp.eliminar(codTipo))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargalista();
                        groupBox1.Visible = true;
                        groupBox2.Visible = false;

                    }
                }
            }
        }

        private void frmTipoPrecios_Load(object sender, EventArgs e)
        {
            cargalista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            proceso = 2;
            txtcodigo.Text = dataGridView1.CurrentRow.Cells[codT.Name].Value.ToString();
            txtsigla.Text = dataGridView1.CurrentRow.Cells[sigla.Name].Value.ToString();
            txtdescripcion.Text = dataGridView1.CurrentRow.Cells[Descripcion.Name].Value.ToString();
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            btNuevo.Enabled = false;
            btEliminar.Enabled = false;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

    }
}
