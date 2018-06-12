using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Reportes;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;



namespace SIGEFA.Formularios
{
    public partial class frmClientesRP : DevComponents.DotNetBar.Office2007Form
    {

        public DataTable DTable;
        public Int32 Tipo;

        public frmClientesRP()
        {
            InitializeComponent();
        }

        private void frmClientesRP_Load(object sender, EventArgs e)
        { 
            if (Tipo == 1)//frmClientesCompletos
            {
                CRClientesCompletos CRep = new CRClientesCompletos();
                CRep.Load("CRClientesCompletos.rpt");
                CRep.SetDataSource(DTable);
                cRVClientesRP.ReportSource = CRep;                
            }
            if (Tipo == 2)//frmClientesCorporativos
            {
                CRClientesCorporativos CRep = new CRClientesCorporativos();
                CRep.Load("CRClientesCorporativos.rpt");
                CRep.SetDataSource(DTable);
                cRVClientesRP.ReportSource = CRep;
            }
            if (Tipo == 3)//frmClientesSimples
            {
                CRClientesSimple CRep = new CRClientesSimple();
                CRep.Load("CRClientesSimple.rpt");
                CRep.SetDataSource(DTable);
                cRVClientesRP.ReportSource = CRep;
            }            
        }

        private void biExportExcel_Click(object sender, EventArgs e)
        {
            


            
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            CRClientesCompletos rptExcel = new CRClientesCompletos();
            rptExcel.Load("CRClientesCompletos.rpt");
            rptExcel.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            rptExcel.ExportOptions.ExportFormatType = ExportFormatType.Excel;
            
            ExcelFormatOptions objExcelOptions = new ExcelFormatOptions();
            objExcelOptions.ExcelUseConstantColumnWidth = false;
            
            rptExcel.ExportOptions.ExportFormatOptions = objExcelOptions;
            

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            saveFileDialog.Filter = "Document (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DiskFileDestinationOptions objOptions = new DiskFileDestinationOptions();
                objOptions.DiskFileName = saveFileDialog.FileName;
                rptExcel.ExportOptions.ExportDestinationOptions = objOptions;
                rptExcel.Export();
                objOptions = null;
            }
            rptExcel = null;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            CRClientesCompletos rptExcel = new CRClientesCompletos();
            rptExcel.Load("CRClientesCompletos.rpt");
            rptExcel.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            rptExcel.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

            


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            saveFileDialog.Filter = "Document (*.pdf)|*.pdf";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DiskFileDestinationOptions objOptions = new DiskFileDestinationOptions();
                objOptions.DiskFileName = saveFileDialog.FileName;
                rptExcel.ExportOptions.ExportDestinationOptions = objOptions;
                rptExcel.Export();
                objOptions = null;

            }
            rptExcel = null;
        }
    }
}
