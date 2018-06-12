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
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;
using SIGEFA.Conexion;


namespace SIGEFA.Formularios
{
    public partial class frmArqueos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmArqueo admarq = new clsAdmArqueo();
        clsArqueo arq = new clsArqueo();
        clsDetalleArqueo detarque = new clsDetalleArqueo();
        public static BindingSource data = new BindingSource();
        public static BindingSource data2 = new BindingSource();

        public frmArqueos()
        {
            InitializeComponent();
        }
        String encargao;
        private void frmArqueos_LoadExtracted()
        {
            arq.ICodUsuario = frmLogin.iCodUser;
            arq.ICodAlma = frmLogin.iCodAlmacen;
            encargao = frmLogin.sNombreUser.ToString() + " " + frmLogin.sApellidoUSer.ToString();
        }
        private void frmArqueos_Load(object sender, EventArgs e)
        {
            cTodosEs.Checked = true;
            cTodos.Checked = true;
            if (cTodosEs.Checked == true)
            {
                rGenerado.Checked = false;
                rCargado.Checked = false;
                rAprobado.Checked = false;
            }
            if (cTodos.Checked == true)
            {
                chkMes.Checked = false;
                cMes.Enabled = false;
                cAño.Enabled = false;
            }
            else
            {
                chkMes.Checked = true;
                cMes.Enabled = true;
                cAño.Enabled = true;
            }
            frmArqueos_LoadExtracted();
            CargaArqueos(1,3,1,1, frmLogin.iCodAlmacen);
        }

        private void CargaArqueos(int opcion1, int opcion2, int mes1, int anio1, int codAlman)
        {
            dgArqueos.DataSource = data;
            data.DataSource = admarq.MuestraArqueos(opcion1, opcion2, mes1, anio1, codAlman);
            dgArqueos.ClearSelection();
        }

        private void rGenerado_CheckedChanged(object sender, EventArgs e)
        {
            if (rGenerado.Checked == true)
            {
                cTodosEs.Checked = false;
                if (cTodos.Checked == true) //GENERADO TODOS LOS MESES
                {
                    CargaArqueos(1, 1, 1, 1, frmLogin.iCodAlmacen);
                }
                else //GENERADO POR MES Y AÑO
                {
                    mes = cMes.SelectedIndex + 1;
                    if (cAño.SelectedItem == null)
                    {
                        //NADA SOLO VERIFICO QUE NO SEA NULO
                    }
                    else  //EN MESES SELECCIONADO EL AÑO
                    {
                        anio = Int32.Parse(cAño.SelectedItem.ToString());
                        if (mes != 0)
                        {
                            CargaArqueos(2, 1, mes, anio, frmLogin.iCodAlmacen);
                        }
                    }
                }
                //CargaArqueos();
            }
            else
            {
                if (rCargado.Checked == false && rAprobado.Checked == false)
                {
                    cTodosEs.Checked = true;
                }
            }
        }
        int mes; int anio; int op1;
        private void cTodosEs_CheckedChanged(object sender, EventArgs e)
        {
            if (cTodosEs.Checked == true)
            {
                rGenerado.Checked = false;
                rCargado.Checked = false;
                rAprobado.Checked = false;
                if (cTodos.Checked == true)
                {
                    CargaArqueos(1, 3, 1, 1, frmLogin.iCodAlmacen);
                }
                else
                {
                    mes = cMes.SelectedIndex +1;
                    if (cAño.SelectedItem == null)
                    {
                        //NADA SOLO VERIFICO QUE NO SEA NULO
                    }
                    else  //EN MESES SELECCIONADO EL AÑO
                    {
                        anio = Int32.Parse(cAño.SelectedItem.ToString());
                        if (mes != 0)
                        {
                            CargaArqueos(2, 3, mes, anio, frmLogin.iCodAlmacen);
                        }
                    }
                }
            }
            
        }

        private void rCargado_CheckedChanged(object sender, EventArgs e)
        {
            if (rCargado.Checked == true)
            {
                cTodosEs.Checked = false;
                if (cTodos.Checked == true) //CARGADO TODOS LOS MESES
                {
                    CargaArqueos(1, 2, 1, 1, frmLogin.iCodAlmacen);
                }
                else //CARGADO POR MES Y AÑO
                {
                    mes = cMes.SelectedIndex + 1;
                    if (cAño.SelectedItem == null)
                    {
                        //NADA SOLO VERIFICO QUE NO SEA NULO
                    }
                    else  //EN MESES SELECCIONADO EL AÑO
                    {
                        anio = Int32.Parse(cAño.SelectedItem.ToString());
                        if (mes != 0)
                        {
                            CargaArqueos(2, 2, mes, anio, frmLogin.iCodAlmacen);
                        }
                    }
                }
            }
            else
            {
                if (rGenerado.Checked == false && rAprobado.Checked == false)
                {
                    cTodosEs.Checked = true;
                }
            }
        }

        private void rAprobado_CheckedChanged(object sender, EventArgs e)
        {
            if (rAprobado.Checked == true)
            {
                cTodosEs.Checked = false;
                if (cTodos.Checked == true) //APROBADO TODOS LOS MESES
                {
                    CargaArqueos(1, 0, 1, 1, frmLogin.iCodAlmacen);
                }
                else //APROBADO POR MES Y AÑO
                {
                    mes = cMes.SelectedIndex + 1;
                    if (cAño.SelectedItem == null)
                    {
                        //NADA SOLO VERIFICO QUE NO SEA NULO
                    }
                    else  //EN MESES SELECCIONADO EL AÑO
                    {
                        anio = Int32.Parse(cAño.SelectedItem.ToString());
                        if (mes != 0)
                        {
                            CargaArqueos(2, 0, mes, anio, frmLogin.iCodAlmacen);
                        }
                    }
                }
            }
            else
            {
                if (rGenerado.Checked == false && rCargado.Checked == false)
                {
                    cTodosEs.Checked = true;
                }
            }
        }

        private void chkMes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMes.Checked == true)
            {
                cMes.Enabled = true;
                cAño.Enabled = true;
                cTodos.Checked = false;
            }
            else
            {
                cMes.Enabled = false;
                cAño.Enabled = false;
            }
        }

        private void cTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cTodos.Checked == true)
            {
                chkMes.Checked = false;
                if (cTodosEs.Checked == true) // TODOS
                {
                    CargaArqueos(1, 3, 1, 1, frmLogin.iCodAlmacen);
                }
                else
                {
                    op1 = chek_radio();
                    CargaArqueos(1, op1, 1, 1, frmLogin.iCodAlmacen); //TODOS LOS MESES Y AÑOS POR TIPO DE ESTADO 
                }
            }
            else //SELECCIONAR MES Y AÑO
            {
                chkMes.Checked = true;
                if (cTodosEs.Checked == true) // MES Y AÑO TODOS LOS ESTADOS
                {
                    mes = cMes.SelectedIndex + 1;
                    if (cAño.SelectedItem == null)
                    {
                        //NADA SOLO VERIFICO QUE NO SEA NULO
                    }
                    else  //EN MESES SELECCIONADO EL AÑO
                    {
                        anio = Int32.Parse(cAño.SelectedItem.ToString());
                        if (mes != 0)
                        {
                            CargaArqueos(2, 3, mes, anio, frmLogin.iCodAlmacen);
                        }
                    }
                }
                else  //MES Y AÑO SELECCIONO ESTADO
                {
                    mes = cMes.SelectedIndex + 1;
                    if (cAño.SelectedItem == null)
                    {
                        //NADA SOLO VERIFICO QUE NO SEA NULO
                    }
                    else  //EN MESES SELECCIONADO EL AÑO
                    {
                        anio = Int32.Parse(cAño.SelectedItem.ToString());
                        if (mes != 0)
                        {
                            op1 = chek_radio();
                            CargaArqueos(2, op1, mes, anio, frmLogin.iCodAlmacen);
                        }
                    }
                }
            }
        }

        private int chek_radio()
        {
            int op = 0;
            if (rGenerado.Checked == true)
            {
                op = 1;
            }
            if (rCargado.Checked == true)
            {
                op = 2;
            }
            if (rAprobado.Checked == true)
            {
                op = 0;
            }
            return op;
        }
        int codArqueos; string estaArqueo;
        private void dgArqueos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgArqueos.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    estaArqueo = dgArqueos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    switch (estaArqueo)
                    {
                        case "Sin Generar": btImprim.Enabled = false; btnGuardar.Enabled = true; btChekear.Enabled = false; btAprobar.Enabled = false; break;
                        case "Generado": btImprim.Enabled = false; btnGuardar.Enabled = false; btChekear.Enabled = true; btAprobar.Enabled = false; break;
                        case "Cargado": btImprim.Enabled = true; btnGuardar.Enabled = false; btChekear.Enabled = false; btAprobar.Enabled = true; break;
                        case "Aprobado": btImprim.Enabled = true; btnGuardar.Enabled = false; btChekear.Enabled = false; btAprobar.Enabled = false; break;
                    }
                    codArqueos = Int32.Parse(dgArqueos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    textBox1.Text = codArqueos.ToString();
                    textBox2.Text = dgArqueos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox3.Text = dgArqueos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    CargaDetalleArqueos(codArqueos);
                }
            }
        }

        private void CargaDetalleArqueos(int codArqueos)
        {
            dgvProductos.DataSource = data2;
            data2.DataSource = admarq.MuestraDetalleArqueos(codArqueos);
            //dgvProductos.ClearSelection();
            dgvProductos.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void dgvProductos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            /* dgvProductos.Rows[e.RowIndex].Cells[1].ReadOnly = false;
            dgvProductos.CurrentCell = dgvProductos[1, e.RowIndex];
            dgvProductos.BeginEdit(true);*/
        }
        int nuevocodarqueo;
        private void biNuevo_Click(object sender, EventArgs e)
        {
            textBox2.Text = encargao.ToString();
            textBox3.Focus();
            arq.DFecha = dtpFecha.Value;
            arq.SObservacion = textBox3.Text;
            admarq.insert(arq);
            nuevocodarqueo = arq.ICodArqueoNuevo;
            textBox1.Text = nuevocodarqueo.ToString();
            CargaArqueos(1, 3, 1, 1, frmLogin.iCodAlmacen);
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                detarque.ICodArqueo = Convert.ToInt32(textBox1.Text);
                detarque.ICodUsuario = frmLogin.iCodUser;
                detarque.SObservacion = "Nada";
                detarque.ICodAlma = frmLogin.iCodAlmacen;
                admarq.insertDetalle(detarque);
                MessageBox.Show("Generacion Correcta");
                CargaArqueos(1, 3, 1, 1, frmLogin.iCodAlmacen);
                btnGuardar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        clsReporteArqueo ds = new clsReporteArqueo();
        clsReporteArqueoCargado dsC = new clsReporteArqueoCargado();
        private void biImprimeLista_Click(object sender, EventArgs e)
        {
            CRArqueo rpt = new CRArqueo();
            frmRptArqueo frm = new frmRptArqueo();
            rpt.SetDataSource(ds.Arqueo(codArqueos).Tables[0]);
            frm.crvArqueo.ReportSource = rpt;
            frm.Show();
        }

        private void dgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                double dif = Convert.ToDouble(dgvProductos.Rows[e.RowIndex].Cells[9].Value) - Convert.ToDouble(dgvProductos.Rows[e.RowIndex].Cells[8].Value);
                dgvProductos.Rows[e.RowIndex].Cells[10].Value = dif;
                if(dif<0)
                {
                    dgvProductos.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.Salmon;
                }
                else if (dif == 0)
                {
                    dgvProductos.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.Silver;
                }
                else
                {
                    dgvProductos.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.Aquamarine;
                }
            }
        }

        private void btActualizaDiferencias_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor vuelva a seleccion el arqueo a APROBAR.");
                dgArqueos.Focus();
            }
            else
            {
                arq.ICodArqueo = Convert.ToInt32(textBox1.Text);
                arq.ICodUsuarioApro = frmLogin.iCodUser;
                arq.SObservacion = textBox3.Text;
                try
                {
                    if (admarq.update(arq))
                    {
                        MessageBox.Show("Aprobacion Correcta.");
                        CargaArqueos(1, 3, 1, 1, frmLogin.iCodAlmacen); 
                    }
                    else
                    {
                        MessageBox.Show("Error en los Datos. No se APROBÓ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        private void btChekear_Click(object sender, EventArgs e)
        {
            int conta; int codArq = Convert.ToInt32(textBox1.Text);
            if (dgvProductos.Rows.Count > 0)
            {
                int sumo = 0;
                for (conta = 0; conta <= dgvProductos.Rows.Count-1; conta++)
                {
                    detarque.ICodDetalle = Convert.ToInt32(dgvProductos.Rows[conta].Cells[0].Value);
                    detarque.DStockF = Convert.ToDecimal(dgvProductos.Rows[conta].Cells[7].Value);
                    detarque.DDiferencia = Convert.ToDecimal(dgvProductos.Rows[conta].Cells[8].Value);
                    detarque.SObservacion = dgvProductos.Rows[conta].Cells[10].Value.ToString();
                    try
                    {
                        if (admarq.insertChekeoDetalle(detarque, codArq))
                        {
                            sumo = sumo+1;
                        }
                        else
                        {
                            MessageBox.Show("Error en Procedure");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    
                }
                if (sumo == dgvProductos.Rows.Count)
                {
                    MessageBox.Show("Chekeo Correcto");
                    CargaArqueos(1, 3, 1, 1, frmLogin.iCodAlmacen); 
                }
                
                
            }
        }

        private void btImprim_Click(object sender, EventArgs e)
        {
            if(estaArqueo != null){
                switch (estaArqueo)
                {
                    case "Cargado": imprimeCargados(codArqueos,1); break;
                    case "Aprobado": imprimeCargados(codArqueos, 1); break;
                }
            }
        }

       

        private void imprimeCargados(int codArqueos, int estaArq)
        {
            CRArqueoCargado rpt = new CRArqueoCargado();
            frmRptArqueoCargado frm = new frmRptArqueoCargado();
            rpt.SetDataSource(dsC.Arqueo(codArqueos, estaArq).Tables[0]);
            frm.crvArqueoCargado.ReportSource = rpt;
            frm.Show();
        }

        private void biImprimeArqueo_Click(object sender, EventArgs e)
        {

        }
    }
}
