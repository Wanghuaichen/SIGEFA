using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using SIGEFA.Formularios;

namespace SIGEFA.Formularios
{
    public partial class frmCambioProveedor : Form
    {
        clsProveedor prov = new clsProveedor();
        clsAdmProveedor admProv = new clsAdmProveedor();
        //clsValidar ok = new clsValidar();

        public Int32 Procede = 0; //(1) Gestion Producto
        public Int32 Proceso = 0; //(2)Editar (3)Consultas
        public Int32 CodProveedor, CodProducto;
        public Int32 CodProv;
        public Boolean estado;

        public frmCambioProveedor()
        {
            InitializeComponent();
        }
        
        private void CargaProveedor(Int32 codprov, Int32 caso)
        {
            try
            {
                prov = admProv.MuestraProveedor(codprov);

                if (prov != null)
                {
                    if (caso == 1)
                    {
                        txtCodProv1.Text = CodProveedor.ToString();
                        txtCodigoProv1.Text = prov.Ruc;
                        txtProveedor1.Text = prov.RazonSocial;
                        txtDireccionProv1.Text = prov.Direccion;
                    }
                    else
                    {
                        txtCodProv2.Text = CodProv.ToString();
                        txtCodigoProv2.Text = prov.Ruc;
                        txtProveedor2.Text = prov.RazonSocial;
                        txtDireccionProv2.Text = prov.Direccion;
                    }
                }
                else
                {
                    if (caso == 1)
                    {
                        txtCodProv1.Text = "";
                        txtCodigoProv1.Text = "";
                        txtProveedor1.Text = "";
                        txtDireccionProv1.Text = "";
                    }
                    else
                    {
                        txtCodProv2.Text = "";
                        txtCodigoProv2.Text = "";
                        txtProveedor2.Text = "";
                        txtDireccionProv2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void frmCambioProveedor_Load(object sender, EventArgs e)
        {
            CargaProveedor(CodProveedor,1);
        }

        private void BorrarProveedor()
        {
            prov = admProv.MuestraProveedor(CodProveedor);
            txtCodProv1.Text = "";
            txtCodigoProv1.Text = "";
            txtProveedor1.Text = "";
            txtDireccionProv1.Text = "";
        }
        
        private void txtCodigoProv2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmProveedoresLista"] != null)
                {
                    Application.OpenForms["frmProveedoresLista"].Activate();
                }
                else
                {
                    frmProveedoresLista form = new frmProveedoresLista();
                    form.Proceso = 3;
                    form.Procede = 9;
                    form.codProv = CodProveedor;
                    form.ShowDialog();
                    if (CodProv != 0) { CargaProveedor(CodProv,2); ProcessTabKey(true); }
                    else BorrarProveedor();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Proceso != 0)
            {
                if (Proceso == 2)
                {
                    estado = admProv.CambiaProveedor(CodProducto, CodProveedor, CodProv);
                    if (estado)
                    {
                        MessageBox.Show("Los datos se Actualizaron Correctamente", "Cambio de Proveedor",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmGestionProducto frm = (frmGestionProducto)Application.OpenForms["frmGestionProducto"];
                        frm.CargaProductosProveedor();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error : Los datos no se Actualizaron", "Cambio de Proveedor",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        

       

    }
}
