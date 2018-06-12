using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Conexion;

namespace SIGEFA.Formularios
{
    public partial class frmSeleccionarAlmacen : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAlmacen admalm = new clsAdmAlmacen();
        clsAdmSucursal AdmSuc = new clsAdmSucursal();
        clsSucursal SucurLogin = new clsSucursal();
        public Int32 tipo = 1;
                
        Int32 almacenanterior;


        public frmSeleccionarAlmacen()
        {
            InitializeComponent();
        }

        private void frmSeleccionarAlmacen_Load(object sender, EventArgs e)
        {
            if (frmLogin.iCodAlmacen == 0)
            {
                if (dgvAlmacenes.Rows.Count > 0)
                {
                    btnCancelar.Enabled = false;
                    this.ControlBox = false;
                }
                else
                {
                    btnCancelar.Enabled = true;
                }
            }

            if (frmLogin.iNivelUser == 1)
            {
                CargaSucursales();
                CargaAlmacenes();
            }
            else
            {
                if (tipo == 2)
                {
                    CargaSucursales();
                    CargaAlmacenes();
                }
                else
                {
                    CargaSucursalesXusuario();
                    CargaAlmacenes();
                }
            }
            
            almacenanterior = frmLogin.iCodAlmacen;
        }

        private void CargaSucursales()
        {
            cmbSucursal.DataSource = AdmSuc.CargaSucursales(frmLogin.iCodEmpresa);
            cmbSucursal.DisplayMember = "nombre";
            cmbSucursal.ValueMember = "codSucursal";
            //cmbSucursal.SelectedIndex = -1;
        }

        private void CargaSucursalesXusuario()
        {
            cmbSucursal.DataSource = AdmSuc.CargaSucursalesXusuario(frmLogin.iCodEmpresa, frmLogin.iCodUser);
            cmbSucursal.DisplayMember = "nombre";
            cmbSucursal.ValueMember = "codSucursal";
            //cmbSucursal.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaAlmacenes()
        {
            //dgvAlmacenes.DataSource = admalm.MuestraAlmacenesDisponibles(frmLogin.iNivelUser, frmLogin.iCodEmpresa, frmLogin.iCodUser, Convert.ToInt32(cmbSucursal.SelectedValue));
            dgvAlmacenes.DataSource = admalm.MuestraAlmacenesDisponibles(Convert.ToInt32(cmbSucursal.SelectedValue));
            //dgvAlmacenes.ClearSelection();
        }
       

        private void dgvAlmacenes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvAlmacenes.Rows.Count >= 1)
            {
                btnAceptar.Enabled = true;
            } 
        }

        private void frmSeleccionarAlmacen_Shown(object sender, EventArgs e)
        {
            CargaAlmacenes();
            dgvAlmacenes.Focus();
        }       

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                if (dgvAlmacenes.CurrentRow.Index != -1 &&
                    almacenanterior != Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value))
                {
                    frmLogin.iCodAlmacen = Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
                    frmLogin.AlmacenLogin = admalm.CargaAlmacen(frmLogin.iCodAlmacen);
                    frmLogin.sAlmacen = frmLogin.AlmacenLogin.Nombre;
                    frmLogin.iCodSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
                    mdi_Menu.Cambio = true;
                }
            }
            else if(tipo==2)
            {
                if (dgvAlmacenes.CurrentRow.Index != -1)
                {
                    frmRequerimientosVigentes form = (frmRequerimientosVigentes)Application.OpenForms["frmRequerimientosVigentes"];
                    form.almadest=Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
                }
            }
            this.Close();
            
        }            

        private void dgvAlmacenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAlmacenes.Rows.Count >= 1 && e.RowIndex != -1)
                {
                    btnAceptar.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }      
        }

        private void dgvAlmacenes_KeyPress(object sender, KeyPressEventArgs e)
        {
           //if (e.KeyChar == (char)Keys.Enter)
           //{
           // //    if (dgvAlmacenes.CurrentRow.Index != -1 && almacenanterior != Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value))
           // //    {
           // //        frmLogin.iCodAlmacen = Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
           // //        frmLogin.AlmacenLogin = admalm.CargaAlmacen(frmLogin.iCodAlmacen);
           // //        frmLogin.sAlmacen = frmLogin.AlmacenLogin.Nombre;
           // //        mdi_Menu.Cambio = true;
           // //    }
           // //    this.Close();
           //if (tipo == 1)
           // {
           //     if (dgvAlmacenes.CurrentRow.Index != -1 &&
           //         almacenanterior != Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value))
           //     {
           //         frmLogin.iCodAlmacen = Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
           //         frmLogin.AlmacenLogin = admalm.CargaAlmacen(frmLogin.iCodAlmacen);
           //         frmLogin.sAlmacen = frmLogin.AlmacenLogin.Nombre;
           //         frmLogin.iCodSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
           //         mdi_Menu.Cambio = true;
           //     }
           // }
           // else if(tipo==2)
           // {
           //     if (dgvAlmacenes.CurrentRow.Index != -1)
           //     {
           //         frmRequerimientosVigentes form = (frmRequerimientosVigentes)Application.OpenForms["frmRequerimientosVigentes"];
           //         form.almadest=Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
           //     }
           // }
           // this.Close();
           //}
            
        }

        private void dgvAlmacenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAlmacenes.SelectedRows.Count > 0 && dgvAlmacenes.CanFocus)
            {
                btnAceptar.Enabled = true;
            }
        }

        private void dgvAlmacenes_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (dgvAlmacenes.SelectedRows.Count != 0)
                {
                    if (almacenanterior != Convert.ToInt32(dgvAlmacenes.SelectedRows[0].Cells[codalmacen.Name].Value))
                    {
                        frmLogin.iCodAlmacen = Convert.ToInt32(dgvAlmacenes.SelectedRows[0].Cells[codalmacen.Name].Value);
                        frmLogin.AlmacenLogin = admalm.CargaAlmacen(frmLogin.iCodAlmacen);
                        frmLogin.sAlmacen = frmLogin.AlmacenLogin.Nombre;
                        mdi_Menu.Cambio = true;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seleccione uno de los Almacenes disponibles", "SIGEFA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
        }

        private void dgvAlmacenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tipo == 1)
                {
                    if (dgvAlmacenes.CurrentRow.Index != -1 && almacenanterior != Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value))
                    {
                        frmLogin.iCodAlmacen = Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
                        frmLogin.AlmacenLogin = admalm.CargaAlmacen(frmLogin.iCodAlmacen);
                        frmLogin.sAlmacen = frmLogin.AlmacenLogin.Nombre;
                        frmLogin.iCodSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
                        mdi_Menu.Cambio = true;
                    }
                }
                else if (tipo == 2)
                {
                    if (dgvAlmacenes.CurrentRow.Index != -1)
                    {
                        frmRequerimientosVigentes form = (frmRequerimientosVigentes)Application.OpenForms["frmRequerimientosVigentes"];
                        form.almadest = Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
                    }
                }
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void cmbSucursal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaAlmacenes();
        }

        private void dgvAlmacenes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tipo == 1)
                {
                    if (dgvAlmacenes.CurrentRow.Index != -1 &&
                        almacenanterior != Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value))
                    {
                        frmLogin.iCodAlmacen = Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
                        frmLogin.AlmacenLogin = admalm.CargaAlmacen(frmLogin.iCodAlmacen);
                        frmLogin.sAlmacen = frmLogin.AlmacenLogin.Nombre;
                        frmLogin.iCodSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
                        mdi_Menu.Cambio = true;
                    }
                }
                else if (tipo == 2)
                {
                    if (dgvAlmacenes.CurrentRow.Index != -1)
                    {
                        frmRequerimientosVigentes form = (frmRequerimientosVigentes)Application.OpenForms["frmRequerimientosVigentes"];
                        form.almadest = Convert.ToInt32(dgvAlmacenes.CurrentRow.Cells[codalmacen.Name].Value);
                    }
                }
                this.Close();
            }
        }
    }
}
