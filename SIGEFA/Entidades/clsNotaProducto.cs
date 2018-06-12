using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsNotaProducto
    {
        #region propiedades

        private Int32 iCodNotaProducto;
        private Int32 iCodNotaProductoNuevo;
        private Int32 iCodProducto;        
        private String sNota;
        private Boolean bEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodNotaProducto
        {
            get { return iCodNotaProducto; }
            set { iCodNotaProducto = value; }
        }
        public Int32 CodNotaProductoNuevo
        {
            get { return iCodNotaProductoNuevo; }
            set { iCodNotaProductoNuevo = value; }
        }
        public Int32 CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }        
        public String Nota
        {
            get { return sNota; }
            set { sNota = value; }
        }
        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
        }
        public Int32 CodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }
        public DateTime FechaRegistro
        {
            get { return dtFechaRegistro; }
            set { dtFechaRegistro = value; }
        }

        #endregion propiedades
    }
}
