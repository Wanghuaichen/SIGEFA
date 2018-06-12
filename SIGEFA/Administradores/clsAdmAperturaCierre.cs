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
    class clsAdmAperturaCierre : IAperturaCierre
    {
        IAperturaCierre Maper = new MysqlAperturaCierreCaja();

        public Boolean Insert(clsCaja aper)
        {
            try
            {
                return Maper.Insert(aper);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean UpdateApertura(clsCaja aper)
        {
            try
            {
                return Maper.UpdateApertura(aper);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean UpdateCierre(clsCaja aper)
        {
            try
            {
                return Maper.UpdateCierre(aper);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean AnularCierre(Int32 codAlmacen)
        {
            try
            {
                return Maper.AnularCierre(codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsCaja CargaAperturaCaja(Int32 codAlmacen)
        {
            try
            {
                return Maper.CargaAperturaCaja(codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCaja CargaCierreCaja(Int32 codAlmacen)
        {
            try
            {
                return Maper.CargaCierreCaja(codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCaja GetUltimaCajaVentas(Int32 codsucursal, Int32 tipocaja, Int32 codalma)
        {
            try
            {
                return Maper.GetUltimaCajaVentas(codsucursal, tipocaja, codalma);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        //Implementado

        public Decimal traersaldo()
        {
            try
            {
                return Maper.traersaldo();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }


        }

        public Boolean InsertAperturaCaja(clsCaja caja)
        {
            try
            {
                return Maper.InsertAperturaCaja(caja);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsCaja CargaCierreAnterior(Int32 iCodSucursal, Int32 tipocaja)
        {
            try
            {
                return Maper.CargaCierreAnterior(iCodSucursal, tipocaja);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaCierresDiarios(Int32 codSucursal, DateTime desde, DateTime hasta)
        {
            try
            {
                return Maper.ListaCierresDiarios(codSucursal, desde, hasta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        //Fin Implementado

        
        #region matenimiento Caja Ventas y Caja Chica

        //public clsCaja ValidarAperturaDia(Int32 codSucursal, DateTime fecha1, Int32 tipocaja, Int32 codalma)
        //{
        //    try
        //    {
        //        return Maper.ValidarAperturaDia(codSucursal, fecha1, tipocaja, codalma);
        //    }
        //    catch (Exception ex)
        //    {
        //        DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return null;
        //    }
        //}
        public Decimal SumaVentaEfectivoCaja(Int32 codSuc, DateTime fech1, Int32 codigocaja)
        {
            try
            {
                return Maper.SumaVentaEfectivoCaja(codSuc, fech1, codigocaja);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public DataTable ListaCajaDiaria(Int32 codSucursal, DateTime fecha1, Int32 codigocaja, Int32 codalma)
        {
            try
            {
                return Maper.ListaCajaDiaria(codSucursal, fecha1, codigocaja, codalma);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean CerrarCajaVentas(Int32 codSucursal, DateTime fecha1, Int32 codcaja, Int32 codalma)
        {
            try
            {
                return Maper.CerrarCajaVentas(codSucursal, fecha1, codcaja, codalma);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean InsertMovCajaChica(clsCajaChicaMov movchi)
        {
            try
            {
                return Maper.InsertMovCajaChica(movchi);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaCajaChica(Int32 codSucursal, DateTime fecha1, Int32 codigocaja, Int32 codalma)
        {
            return Maper.ListaCajaChica(codSucursal, fecha1, codigocaja, codalma);
        }
        #endregion matenimiento Caja Ventas y Caja Chica

        public DataTable ConsultaCajas(Int32 almacen, DateTime fecha1, DateTime fecha2)
        {
            return Maper.ConsultaCajas(almacen, fecha1, fecha2);

        }

        public clsCaja ValidarAperturaDia(Int32 codSucursal, DateTime fecha1, Int32 tipocaja, Int32 codalma, Int32 CodUser)
        {
            try
            {
                return Maper.ValidarAperturaDia(codSucursal, fecha1, tipocaja, codalma, CodUser);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}