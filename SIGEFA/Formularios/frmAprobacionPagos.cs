using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmAprobacionPagos : DevComponents.DotNetBar.Office2007Form
    {

        clsAdmPago Admpag = new clsAdmPago();
        private Int32 Cod = 0, aprob=0;
        private int cbestado;
        public frmAprobacionPagos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cargaLista()
        {
            dgvDetalle.DataSource = Admpag.MuestraPagosPorAprobar(cmbEstado.SelectedIndex, dtpFecha1.Value, dtpFecha2.Value);
        }

       
      
        private void biAprobar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null && dgvDetalle.Rows.Count >= 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea Aprobar el Pago", "Aprobación de Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    Admpag.AprobarPago(Cod,2);//aprobar
                    MessageBox.Show("El Pago se Aprobado Satisfactoriamente", "Aprobación de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //cargaLista();
                }
            }
        }

        private void biDesaprobar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null && dgvDetalle.Rows.Count >= 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea Aprobar el Pago", "Aprobación de Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    Admpag.AprobarPago(Cod, 3);//desaprobar
                    MessageBox.Show("El Pago se Aprobado Satisfactoriamente", "Aprobación de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //cargaLista();
                }
            }
        }

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (dgvDetalle.Rows.Count >= 1 && e.Row.Selected)
                {
                    aprob = Convert.ToInt32(e.Row.Cells[Aprobado1.Name].Value);
                    Cod = Convert.ToInt32(e.Row.Cells[codPago.Name].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dgvDetalle_RowStateChanged");

            }
            

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            //cargaLista();
            arrancaBack();
        }

        private void frmAprobacionPagos_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 1;
            EventArgs evar = new EventArgs();
            cmbEstado_SelectionChangeCommitted(cmbEstado, evar);
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (aprob == 1)
            {//por aprobar
                biAprobar.Enabled = true;
                biDesaprobar.Enabled = true;
            }
            else
            {
                biAprobar.Enabled = false;
                biDesaprobar.Enabled = false;
            }
        }

        DataTable mySource;
        private void arrancaBack()
        {
            if (backAprobacion.IsBusy)
            {
            }
            else
            {
                backAprobacion.RunWorkerAsync();
            }
        }

        private void backAprobacion_DoWork(object sender, DoWorkEventArgs e)
        {
            backAprobacionProcessLogicMethod();
        }

        private void backAprobacion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DataTable mydatOld = null;
            DataTable mydataResult = null;
            if (dgvDetalle.DataSource != null)
            {
                mydatOld = new DataTable();
                //mydatOld = (DataTable) dataGpedidos.DataSource;
                mydatOld = (DataTable)dgvDetalle.DataSource;
                // COMPARAR
                mydataResult = new DataTable();
                mydataResult = getDifferentRecords(mydatOld, mySource);
                // COMPARAR
                if (mydataResult != null)
                {
                    if (mydataResult.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        dgvDetalle.AutoGenerateColumns = false;
                        //filtro
                        dgvDetalle.DataSource = mySource;
                        //filtro
                        dgvDetalle.ClearSelection();

                    }
                }

            }
            else
            {
                dgvDetalle.AutoGenerateColumns = false;
                //filtro
                dgvDetalle.DataSource = mySource;
                //filtro
                dgvDetalle.ClearSelection();

            }
        }

        private DataTable getDifferentRecords(DataTable mydatOld, DataTable mySource)
        {
            //Create Empty Table     
            DataTable ResultDataTable = new DataTable("ResultDataTable");
            try
            {
                //use a Dataset to make use of a DataRelation object     
                using (DataSet ds = new DataSet())
                {
                    //Add tables     
                    ds.Tables.AddRange(new DataTable[] { mydatOld.Copy(), mySource.Copy() });

                    //Get Columns for DataRelation     
                    DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                    for (int i = 0; i < firstColumns.Length; i++)
                    {
                        firstColumns[i] = ds.Tables[0].Columns[i];
                    }

                    DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                    for (int i = 0; i < secondColumns.Length; i++)
                    {
                        secondColumns[i] = ds.Tables[1].Columns[i];
                    }

                    //Create DataRelation     
                    DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                    ds.Relations.Add(r1);

                    DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                    ds.Relations.Add(r2);

                    //Create columns for return table     
                    for (int i = 0; i < mydatOld.Columns.Count; i++)
                    {
                        ResultDataTable.Columns.Add(mydatOld.Columns[i].ColumnName, mydatOld.Columns[i].DataType);
                    }

                    //If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable.     
                    ResultDataTable.BeginLoadData();
                    foreach (DataRow parentrow in ds.Tables[0].Rows)
                    {
                        DataRow[] childrows = parentrow.GetChildRows(r1);
                        if (childrows == null || childrows.Length == 0)
                            ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                    }

                    //If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable.     
                    foreach (DataRow parentrow in ds.Tables[1].Rows)
                    {
                        DataRow[] childrows = parentrow.GetChildRows(r2);
                        if (childrows == null || childrows.Length == 0)
                            ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                    }
                    ResultDataTable.EndLoadData();
                }

                return ResultDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ResultDataTable = null;
                return ResultDataTable;
            }
        }

        private void backAprobacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backAprobacion.RunWorkerAsync();
        }

        private void backAprobacionProcessLogicMethod()
        {
            Thread.Sleep(2000);
            try
            {
                if (mySource!=null)
                {
                    mySource = null;
                }
                else
                {
                    mySource = Admpag.MuestraPagosPorAprobar(cbestado, dtpFecha1.Value, dtpFecha2.Value);
                    if (mySource.Rows.Count ==0)
                    {
                       // mySource = null;
                        backAprobacion.ReportProgress(0);
                    }
                    else
                    {
                        foreach (DataRow row in mySource.Rows)
                        {
                            backAprobacion.ReportProgress(mySource.Rows.IndexOf(row));
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cmbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbestado = cmbEstado.SelectedIndex;
        }

      
    }
}
