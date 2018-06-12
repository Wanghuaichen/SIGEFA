using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsArqueo
    {
        #region propiedades
        private Int32 iCodArqueo;
        private Int32 iCodArqueoNuevo;
        private Int32 iCodUsuario;
        private DateTime dFecha;
        private Int32 iEstado;
        private String sObservacion;
        private DateTime dFechaRegistro;
        private Int32 iCodAlma;
        private Int32 iCodUsuarioApro;

        public Int32 ICodUsuarioApro
        {
            get { return iCodUsuarioApro; }
            set { iCodUsuarioApro = value; }
        }

        public Int32 ICodAlma
        {
            get { return iCodAlma; }
            set { iCodAlma = value; }
        }

        public Int32 ICodArqueo
        {
            get { return iCodArqueo; }
            set { iCodArqueo = value; }
        }

        public Int32 ICodArqueoNuevo
        {
            get { return iCodArqueoNuevo; }
            set { iCodArqueoNuevo = value; }
        }

        public Int32 ICodUsuario
        {
            get { return iCodUsuario; }
            set { iCodUsuario = value; }
        }
               
        public DateTime DFecha
        {
            get { return dFecha; }
            set { dFecha = value; }
        }
        
        public Int32 IEstado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }

        public String SObservacion
        {
            get { return sObservacion; }
            set { sObservacion = value; }
        }

        public DateTime DFechaRegistro
        {
            get { return dFechaRegistro; }
            set { dFechaRegistro = value; }
        }
        #endregion
    }
}
