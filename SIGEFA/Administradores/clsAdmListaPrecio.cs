
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
    class clsAdmListaPrecio
    {
        IListaPrecio Mlista = new MysqlListaPrecio();

        public Boolean insert(clsListaPrecio lista)
        {
            try
            {
                return Mlista.Insert(lista);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }        
        
        public Boolean update(clsListaPrecio lista)
        {
            try
            {
                return Mlista.Update(lista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetalleListaPrecio detalle)
        {
            try
            {
                return Mlista.Updatedetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean updatedetallePorFiltro(clsDetalleListaPrecio detalle)
        {
            try
            {
                return Mlista.updatedetallePorFiltro(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        
        public Boolean delete(Int32 CodLista)
        {
            try
            {
                return Mlista.Delete(CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean anular(Int32 codSucursal, Int32 CodLista)
        {
            try
            {
                return Mlista.Anular(codSucursal, CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean activar(Int32 codSucursal, Int32 CodLista)
        {
            try
            {
                return Mlista.Activar(codSucursal, CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsListaPrecio CargaListaPrecio(Int32 CodListaPrecio)
        {
            try
            {
                return Mlista.CargaListaPrecio(CodListaPrecio);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListas(Int32 codSucursal)
        {
            try
            {
                return Mlista.MuestraListas(codSucursal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable PreciosProducto(Int32 codProducto, Int32 codSucursal ,Int32 codalma)
        {
            try
            {
                return Mlista.MuestraPreciosProducto(codProducto, codSucursal, codalma);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaListaPrecios(Int32 CodLista)
        {
            try
            {
                return Mlista.CargaListaPrecios(CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean GeneraLista(Int32 lista, Int32 codalma, Int32 decimales)
        {
            try
            {
                return Mlista.GeneraPreciosLista(lista, codalma, decimales);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean GeneraListaProveedor(Int32 lista, Int32 codSucursal, Int32 decimales, Int32 codProveedor)
        {
            try
            {
                return Mlista.GeneraPreciosListaProveedor(lista, codSucursal, decimales, codProveedor);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public List<Int32> MuestraListasProveedor(Int32 codSucursal)
        {
            try
            {
                return Mlista.MuestraListasProveedor(codSucursal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorFiltro(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListasPorFiltro(codSucursal, rango1, rango2, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorProveedor(Int32 codSucursal, Int32 codProv, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorProveedor(codSucursal, codProv, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorFamilia(Int32 codSucursal, Int32 codFam, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorFamilia(codSucursal, codFam, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorLinea(Int32 codSucursal, Int32 codFam, Int32 codLin, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorLinea(codSucursal, codFam, codLin, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorRangoProv(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codProv, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorRangoProv(codSucursal, rango1, rango2, codProv, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorRangoFam(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codFam, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorRangoFam(codSucursal, rango1, rango2, codFam, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorProveedorFam(Int32 codSucursal, Int32 codProv, Int32 codFam, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorProveedorFam(codSucursal, codProv, codFam, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorRangoFamLin(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codFam, Int32 codLin, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorRangoFamLin(codSucursal, rango1, rango2, codFam, codLin, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorProveedorFamLin(Int32 codSucursal, Int32 codProv, Int32 codFam, Int32 codLin, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorProveedorFamLin(codSucursal, codProv, codFam, codLin, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasParcial(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codProv, Int32 codFam, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaParcial(codSucursal, rango1, rango2, codProv, codFam, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListasPorTodos(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codProv, Int32 codFam, Int32 codLin, Int32 listaorigen, Int32 decimales)
        {
            try
            {
                return Mlista.MuestraListaPorTodos(codSucursal, rango1, rango2, codProv, codFam, codLin, listaorigen, decimales);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraListaPrecioxFormaPago(Int32 codSucursal, Int32 codForma)
        {
            try
            {
                return Mlista.MuestraListaPrecioxFormaPago(codSucursal, codForma);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        
    }
}
