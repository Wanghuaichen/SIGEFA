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
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class frmCajaChicaDocumentos : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Tipo = 0;


        public frmCajaChicaDocumentos()
        {
            InitializeComponent();
        }
    }
}
