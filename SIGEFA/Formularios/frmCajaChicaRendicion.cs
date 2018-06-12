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
    public partial class frmCajaChicaRendicion : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmSucursal AdmSuc = new clsAdmSucursal();        
        public List<Int32> seleccion = new List<Int32>();      

        public static BindingSource data = new BindingSource();
        public static BindingSource data1 = new BindingSource();
        String filtro = String.Empty;
        String filtro1 = String.Empty;

        int FilasChequeadas = 0;
        Decimal Total = 0;
        Int32 NumFila = 0;
        Int32 Tipo = 0;

        Int32 CodRendicion = 0;
        public Int32 tipocaja = 0;


        public frmCajaChicaRendicion()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCajaChicaRendicion_Load(object sender, EventArgs e)
        {
            CargaSucursales();
        }

        private void CargaSucursales()
        {
            cboSucursal.DataSource = AdmSuc.CargaSucursales(frmLogin.iCodEmpresa);
            cboSucursal.DisplayMember = "nombre";
            cboSucursal.ValueMember = "codSucursal";
            cboSucursal.SelectedIndex = 0;
        }

        private void ListaRendicionesXSucursal()
        {
            //try
            //{
            //    dgvRendiciones.DataSource = data;
            //    data.DataSource = AdmCaja.ListaRendicionesXSucursal(Convert.ToInt32(cboSucursal.SelectedValue), tipocaja);
            //    data.Filter = String.Empty;
            //    filtro = String.Empty;
            //}
            //catch (Exception ex)
            //{ throw ex; }
        }

        private void ListaDetalleRendiciones()
        {
            //try
            //{                
            //    dgvDetalleRendiciones.DataSource = data1;
            //    data1.DataSource = AdmCaja.ListaDetalleRendiciones(CodRendicion, tipocaja);
            //    data1.Filter = String.Empty;
            //    filtro1 = String.Empty;              
            //}
            //catch (Exception ex)
            //{ throw ex; }
        }

        private void cboSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ListaRendicionesXSucursal();
            }
            catch (Exception ex)
            { return; }
        }

        private void dgvRendiciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetalleRendiciones.IsCurrentCellDirty)
            {
                dgvDetalleRendiciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvRendiciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvDetalleRendiciones.Columns[e.ColumnIndex].Name == Item.Name)
                {
                    DataGridViewRow row = dgvDetalleRendiciones.Rows[e.RowIndex];

                    DataGridViewCheckBoxCell cellSelecion = row.Cells[Item.Name] as DataGridViewCheckBoxCell;
                    //clsCajaChica CajaChica = new clsCajaChica();

                    //CajaChica.CodDetalleRendicion = Convert.ToInt32(row.Cells[codigo.Name].Value);
                    //CajaChica.Glosario = txtComentario.Text.Trim();

                    if (Convert.ToBoolean(cellSelecion.Value))
                    {
                        FilasChequeadas = FilasChequeadas + 1;
                        //***************************************
                        //Caja.CodCajaChica = Convert.ToInt32(row.Cells[codigo.Name].Value);
                        //Caja.Glosario = txtComentario.Text.Trim();
                        seleccion.Add(Convert.ToInt32(row.Cells[codigo.Name].Value));
                        //seleccion2.Add(CajaChica);
                    }
                    else
                    {
                        FilasChequeadas = FilasChequeadas - 1;
                        seleccion.Remove(Convert.ToInt32(row.Cells[codigo.Name].Value));
                        //Int32 Indice = seleccion2.IndexOf(CajaChica, 3);
                        //seleccion2.Remove(CajaChica);
                    }

                    //****************************************
                    if (FilasChequeadas >= 1)
                    {
                        biAprobar.Enabled = true;
                        biDesaprobar.Enabled = true;
                    }
                    else
                    {
                        biAprobar.Enabled = false;
                        biDesaprobar.Enabled = false;
                    }
                    //****************************************                    
                }
            }
        }

        private void CalcularRendicion()
        {
            try
            {
                Total = 0;

                foreach (DataGridViewRow row in dgvDetalleRendiciones.Rows)
                {
                    Total = Total + (Convert.ToDecimal(row.Cells[monto.Name].Value));
                }

                lblTotal.Text = Total.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void txtComentario_KeyUp(object sender, KeyEventArgs e)
        {
            dgvDetalleRendiciones.Rows[NumFila].Cells[comentario.Name].Value = txtComentario.Text.Trim();
        }

        private void dgvDetalleRendiciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDetalleRendiciones.Rows.Count >= 1 && e.Row.Selected)
            {
                txtComentario.Text = e.Row.Cells[comentario.Name].Value.ToString();
                NumFila = dgvDetalleRendiciones.SelectedRows[0].Index;
            }
        }

        private void dgvRendiciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvRendiciones.RowCount > 0)
            {
                CodRendicion = Convert.ToInt32(e.Row.Cells[codigoRendicion.Name].Value);
                if (Convert.ToDecimal(e.Row.Cells[totalRendiciones.Name].Value) > 0)
                {
                    if (Convert.ToDecimal(e.Row.Cells[aprobadas.Name].Value) > 0)
                    {
                        if (Convert.ToDecimal(e.Row.Cells[totalRendiciones.Name].Value) == (Convert.ToDecimal(e.Row.Cells[aprobadas.Name].Value) + Convert.ToDecimal(e.Row.Cells[desaprobadas.Name].Value)))
                        {
                            if((Convert.ToDecimal(e.Row.Cells[aprobadas.Name].Value)>0))
                            {
                               biAceptar.Enabled = true;
                               biRechazar.Enabled = true;
                            }
                            else
                            {
                               biAceptar.Enabled = false;
                               biRechazar.Enabled = true;
                            }
                        }
                        else
                        {
                            biAceptar.Enabled = false;
                            biRechazar.Enabled = false;
                        }
                    }
                    else
                    {
                        biAceptar.Enabled = false;
                        biRechazar.Enabled = true;
                    }
                }
                else
                {
                    biAceptar.Enabled = false;
                    biRechazar.Enabled = false;
                }
            }
            else
            {
                CodRendicion = 0;
                biAceptar.Enabled = false;
                biRechazar.Enabled = false;
            }

            ListaDetalleRendiciones();
            seleccion.Clear();
            FilasChequeadas = 0;
            biAprobar.Enabled = false;
            biDesaprobar.Enabled = false;
        }

        private void GestionaRendicion()
        {
            //try
            //{
            //    foreach (Int32 Cod in seleccion)
            //    {
            //        AdmCaja.GestionaRendicion(Cod);
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void biAprobar_Click(object sender, EventArgs e)
        {
            //if (dgvDetalleRendiciones.RowCount > 0)
            //{
            //    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea Aprobar Las Rendiciones Seleccionadas", "Gestion de Rendiciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dlgResult == DialogResult.No)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        foreach (Int32 Cod in seleccion)
            //        {
            //            AdmCaja.ApruebaRendicion(Cod, txtComentario.Text);
            //        }
            //        MessageBox.Show("Las Rendiciones Fueron Aprobadas Satisfactoriamente", "Gestion de Rendiciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ListaRendicionesXSucursal();
            //        ListaDetalleRendiciones();
            //    }
            //}
        }

        private void biDesaprobar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleRendiciones.RowCount > 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea Rechazar Las Rendiciones Seleccionadas", "Gestion de Rendiciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    foreach (Int32 Cod in seleccion)
                    {
                        //AdmCaja.DesapruebaRendicion(Cod, txtComentario.Text);
                    }
                    MessageBox.Show("Tarea Realizada Satisfactoriamente", "Gestion de Rendiciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListaRendicionesXSucursal();
                    ListaDetalleRendiciones();
                }
            }
        }

        private void GestionaRendicion(Int32 Codigo, String Observacion, Int32 Tipo)
        {
            DialogResult dlgResult = MessageBox.Show("Esta seguro que desea enviar a Tesoreria la Rendicion", "Gestion de Rendiciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.No)
            {
                return;
            }
            else
            {
                //if (AdmCaja.GestionaRendicion(Codigo, Observacion, Tipo))
                //{
                //    MessageBox.Show("El dato ha sido Gestionado correctamente", "Gestion de Rendiciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    ListaRendicionesXSucursal();
                //    ListaDetalleRendiciones();
                //}
            }
        }

        private void biAceptar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleRendiciones.RowCount > 0)
            {
                Int32 Codigo_ = Convert.ToInt32(dgvRendiciones.SelectedRows[0].Cells[codigoRendicion.Name].Value.ToString());
                String Observacion_ = dgvRendiciones.SelectedRows[0].Cells[observacion.Name].Value.ToString();

                GestionaRendicion(Codigo_, Observacion_, 1);
            }
        }
        
        private void biRechazar_Click(object sender, EventArgs e)
        {
            Int32 Codigo_ = Convert.ToInt32(dgvRendiciones.SelectedRows[0].Cells[codigoRendicion.Name].Value.ToString());
            String Observacion_ = dgvRendiciones.SelectedRows[0].Cells[observacion.Name].Value.ToString();

            GestionaRendicion(Codigo_, Observacion_, 2);
        }
    }
}
