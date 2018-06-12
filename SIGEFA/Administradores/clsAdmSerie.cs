using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIGEFA.Administradores
{
    class clsAdmSerie
    {
        ISerie Mser = new MysqlSerie();

        public Boolean insert(clsSerie ser)
        {
            try
            {
                return Mser.Insert(ser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsSerie ser)
        {
            try
            {
                return Mser.Update(ser);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 Codser)
        {
            try
            {
                return Mser.Delete(Codser);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraSeries(Int32 codDoc, Int32 codAlmacen)
        {
            try
            {
                return Mser.ListaSeries(codDoc, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsSerie BuscaSerie(String Serie, Int32 Documento, Int32 Almacen)
        {
            try
            {
                return Mser.BuscaSerie(Serie,Documento,Almacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsSerie BuscaSeriexDocumento(Int32 Documento, Int32 Almacen)
        {
            try
            {
                return Mser.BuscaSeriexDocumento(Documento, Almacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsSerie MuestraSerie(Int32 CodSerie, Int32 CodAlmacen)
        {
            try
            {
                return Mser.CargaSerie(CodSerie, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Int32 ExisteSeries(Int32 CodDocumento, Int32 CodAlmacen)
        {
            try
            {
                return Mser.ExistenSeries(CodDocumento, CodAlmacen);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }

        public Int32 GetCodigoSerie(Int32 CodDocumento, Int32 CodAlmacen)
        {
            try
            {
                return Mser.GetCodigoSerie(CodDocumento, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }

        //MODIFICACION ALEX TRAE SERIE
        public Int32 traeNumeracion(Int32 codal, Int32 coddoc)
        {
            try
            {
                return Mser.traeNumeracion(codal, coddoc);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
        //MODIFICACION ALEX TRAE SERIE
        public Int32 traeCodSerie(Int32 codal, Int32 coddoc)
        {
            try
            {
                return Mser.traeCodSerie(codal, coddoc);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public clsSerie CargaSerieEmpresa(Int32 CodigoE, Int32 codigoDoc)
        {
            try
            {
                return Mser.CargaSerieEmpresa(CodigoE, codigoDoc);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
