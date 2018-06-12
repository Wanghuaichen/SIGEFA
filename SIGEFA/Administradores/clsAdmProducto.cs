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
    class clsAdmProducto
    {
        IProducto Mpro = new MysqlProducto();

        public Boolean insert(clsProducto pro)
        {
            try
            {
                return Mpro.Insert(pro);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                else
                    DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertproductoalmacen(clsProducto pro)
        {
            try
            {
                return Mpro.InsertProductoAlmacen(pro);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertcaracteristica(clsCaracteristicaProducto carpro)
        {
            try
            {
                return Mpro.InsertCaracteristica(carpro);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertnota(clsNotaProducto notapro)
        {
            try
            {
                return Mpro.InsertNota(notapro);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertunidadequivalente(clsUnidadEquivalente unidadequi)
        {
            try
            {
                return Mpro.InsertUnidad(unidadequi);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsProducto pro)
        {
            try
            {
                return Mpro.Update(pro);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updateproductoalmacen(clsProducto pro)
        {
            try
            {
                return Mpro.UpdateProductoAlmacen(pro);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updateunidadequivalente(clsUnidadEquivalente unidadequi)
        {
            try
            {
                return Mpro.UpdateUnidad(unidadequi);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 Codpro)
        {
            try
            {
                return Mpro.Delete(Codpro);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deleteproductoalmacen(Int32 Codpro)
        {
            try
            {
                return Mpro.DeleteProductoAlmacen(Codpro);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletecaracteristica(Int32 Codcarpro)
        {
            try
            {
                return Mpro.DeleteCaracteristica(Codcarpro);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletenota(Int32 Codnota)
        {
            try
            {
                return Mpro.DeleteNota(Codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deleteunidadequivalente(Int32 Coduniequi)
        {
            try
            {
                return Mpro.DeleteUnidad(Coduniequi);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraProductos(Int32 Nivel, Int32 Codigo, Int32 CodAlmacen)
        {
            try
            {
                return Mpro.ListaProductos(Nivel, Codigo, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CatalogoProductos()
        {
            try
            {
                return Mpro.CatalogoProductos();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaProductosReporte(Int32 CodAlmacen, Int32 Tipo, Int32 Inicio)
        {
            try
            {
                return Mpro.ListaProductosReporte(CodAlmacen,Tipo, Inicio);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable StockProductoAlmacenes(Int32 CodEmpresa, Int32 CodProducto)
        {
            try
            {
                return Mpro.StockProductoAlmacenes(CodEmpresa, CodProducto);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable RelacionIngreso(Int32 Tipo, Int32 codalma)
        {
            try
            {
                return Mpro.RelacionProductosIngreso(Tipo, codalma);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable RelacionIngresoPorProveedor(Int32 Tipo, Int32 codalma, Int32 codproveedor)
        {
            try
            {
                return Mpro.RelacionIngresoPorProveedor(Tipo, codalma, codproveedor);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable RelacionSalida(Int32 Tipo, Int32 CodAlmacen, Int32 CodLista)
        {
            try
            {
                return Mpro.RelacionProductosSalida(Tipo,CodAlmacen,CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraCaracteristicas(Int32 CodigoProducto)
        {
            try
            {
                return Mpro.ListaCaracteristicas(CodigoProducto);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraProductosProveedor(Int32 CodigoProducto, Int32 CodigoAlmacen)
        {
            try
            {
                return Mpro.MuestraProductosProveedor(CodigoProducto, CodigoAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraNotas(Int32 CodigoProducto)
        {
            try
            {
                return Mpro.ListaNotas(CodigoProducto);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

              

        public clsProducto CargaProducto(Int32 CodProducto, Int32 CodAlmacen)
        {
            try
            {
                return Mpro.CargaProducto(CodProducto,CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsProducto CargaProductoDetalle(Int32 CodProducto, Int32 CodAlmacen, Int32 Caso, Int32 CodLista)
        {
            try
            {
                return Mpro.CargaProductoDetalle(CodProducto, CodAlmacen, Caso, CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsProducto CargaProductoDetalleCodBarras(String CodProducto, Int32 CodAlmacen, Int32 Caso, Int32 CodLista)
        {
            try
            {
                return Mpro.CargaProductoDetalleCodBarras(CodProducto, CodAlmacen, Caso, CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsProducto CargaProductoDetalle1(Int32 CodProducto, Int32 CodAlmacen, Int32 Caso, Int32 CodLista)
        {
            try
            {
                return Mpro.CargaProductoDetalle1(CodProducto, CodAlmacen, Caso, CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsProducto CargaDatosProductoOrden(Int32 CodProducto, Int32 CodAlmacen,Int32 codusu, Decimal cant)
        {
            try
            {
                return Mpro.CargaDatosProductoOrden(CodProducto, CodAlmacen, codusu, cant);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsProducto CargaProductoDetalleR(String Referencia, Int32 CodAlmacen, Int32 Caso, Int32 CodLista)
        {
            try
            {
                return Mpro.CargaProductoDetalleR(Referencia, CodAlmacen, Caso, CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }        

        public DataTable ArbolProductos()
        {
            try
            {
                return Mpro.ArbolProductos();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsProducto MuestraProductosTransferencia(Int32 codProducto, Int32 codAlmacen)
        {
            try
            {
                return Mpro.MuestraProductosTransferencia(codProducto,codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsProducto MuestraProductosTransferencia_nuevo(Int32 codProducto, Int32 codAlmacen)
        {
            try
            {
                return Mpro.MuestraProductosTransferencia_nuevo(codProducto, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable RelacionCotizacion(Int32 Tipo, Int32 CodAlmacen, Int32 CodLista)
        {
            try
            {
                return Mpro.RelacionProductosCotizacion(Tipo, CodAlmacen, CodLista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Decimal CargaPrecioProducto(Int32 CodProducto, Int32 CodAlmacen, Int32 codmon)
        {
            try
            {
                return Mpro.CargaPrecioProducto(CodProducto, CodAlmacen, codmon);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public DataTable MuestraStockAlmacenes()
        {
            try
            {
                return Mpro.MuestraStockAlmacenes();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable BuscarProducto(Int32 codProducto)
        {
            try
            {
                return Mpro.BuscarProducto(codProducto);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable RelacionProductos(Int32 codalma)
        {
            try
            {
                return Mpro.RelacionProductos(codalma);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable RelacionVendedor(Int32 CodTipArt, Int32 CodAlmacen, Int32 CodLista, Int32 CodVendedor)
        {
            try
            {
                return Mpro.RelacionVendedor(CodTipArt, CodAlmacen, CodLista, CodVendedor);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public List<clsProducto> ListaProdConsultor(Int32 CodVendedor)
        {
            try
            {
                return Mpro.ListaProdConsultor(CodVendedor);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public List<clsProducto> VentasProductosCount(Int32 CodFac)
        {

            try
            {
                return Mpro.VentasProductosCount(CodFac);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

        }


        public DataTable MuestraUnidadesEquivalentesCompra(Int32 CodigoProducto, Int32 codAlmacen)
        {
            try
            {
                return Mpro.ListaUnidadesEquivalentesCompra(CodigoProducto, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraUnidadesEquivalentesVenta(Int32 CodigoProducto, Int32 codAlmacen)
        {
            try
            {
                return Mpro.ListaUnidadesEquivalentesVenta(CodigoProducto, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraUnidadesEquivalentesVenta1(Int32 CodigoProducto, Int32 codAlmacen)
        {
            try
            {
                return Mpro.ListaUnidadesEquivalentesVenta1(CodigoProducto, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraUnidadesEquivalentes(Int32 CodigoProducto, Int32 codAlmacen)
        {
            try
            {
                return Mpro.ListaUnidadesEquivalentes(CodigoProducto, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaUnidadesEquivalentes(Int32 CodigoProducto)
        {
            try
            {
                return Mpro.CargaUnidadesEquivalentes(CodigoProducto);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsUnidadEquivalente CargaUnidadEquivalente(Int32 CodigoUnidad, Int32 CodigoProducto)
        {
            try
            {
                return Mpro.CargaUnidadEquivalente(CodigoUnidad, CodigoProducto);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Int32 getUnidadCompra(Int32 codProd)
        {
            try
            {
                return Mpro.getUnidadCompra(codProd);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Boolean updateunidadequivalente(Int32 cod, Decimal precio)
        {
            try
            {
                return Mpro.UpdateUnidadEquivalente(cod, precio);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Int32 UnidadBase(Int32 codPro, Int32 codalma)
        {
            try
            {
                return Mpro.UnidadBase(codPro, codalma);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
        public Decimal FactorProducto(Int32 codPro, Int32 undBase, Int32 undEqui, Int32 tipo)
        {
            try
            {
                return Mpro.FactorProducto(codPro, undBase, undEqui, tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
        public String SiglaUnidadBase(Int32 codUnd)
        {
            try
            {
                return Mpro.SiglaUnidadBase(codUnd);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }

        public clsUnidadEquivalente PrecioVenta(Int32 coduni, Int32 codalmacen)
        {
            try
            {
                return Mpro.PrecioVenta( coduni, codalmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsUnidadEquivalente Factor(Int32 codProducto, Int32 codUnidadMedida, Int32 codUnidaEqui)
        {
            return Mpro.Factor(codProducto, codUnidadMedida, codUnidaEqui);
        }

        public clsProducto PrecioPromedio(Int32 codProducto, Int32 codalm)
        {
            try
            {
                return Mpro.PrecioPromedio(codProducto, codalm);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Int32 GetCodProducto_xDescripcion(String descripcion)
        {
            try
            {
                return Mpro.GetCodProducto_xDescripcion(descripcion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 ValidaCodigoUE(Int32 codigo)
        {
            try
            {
                return Mpro.ValidaCodigoUE(codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 ValidaCodigoUE(String unidad)
        {
            try
            {
                return Mpro.ValidaCodigoUE(unidad);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 ValidaCodigoProducto(Int32 codigo)
        {
            try
            {
                return Mpro.ValidaCodigoProducto(codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 ValidaCodigoMoneda(Int32 codigo)
        {
            try
            {
                return Mpro.ValidaCodigoMoneda(codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 ValidaCodigoMoneda(String moneda)
        {
            try
            {
                return Mpro.ValidaCodigoMoneda(moneda);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 ValidaTipoPrecio(String tipoPrecio)
        {
            try
            {
                return Mpro.ValidaTipoPrecio(tipoPrecio);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 ValidaTipoPrecio(Int32 codigo)
        {
            try
            {
                return Mpro.ValidaTipoPrecio(codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 GetCodUnidad(String descripcion)
        {
            try
            {
                return Mpro.GetCodUnidad(descripcion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 GetCodTipoPrecio(String descripcion)
        {
            try
            {
                return Mpro.GetCodTipoPrecio(descripcion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 GetCodMoneda(String descripcion)
        {
            try
            {
                return Mpro.GetCodMoneda(descripcion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Int32 ValidaUnidadEquivalente(Int32 codigo)
        {
            try
            {
                return Mpro.ValidaUnidadEquivalente(codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public DataTable MuestratipoNC()
        {
            try
            {
                return Mpro.MuestratipoNC();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
