using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsParametros
    {
        #region propiedades

        private Int32 iCodConfiguracion;
        private Double dIGV;       
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private Int32 idiasVigencia;
        private Boolean bFacturasVencidas;

        private Boolean autoguardado;

        public Boolean Autoguardado
        {
            get { return autoguardado; }
            set { autoguardado = value; }
        }

        public Int32 CodConfiguracion
        {
            get { return iCodConfiguracion; }
            set { iCodConfiguracion = value; }
        }

        public Double IGV
        {
            get { return dIGV; }
            set { dIGV = value; }
        }        
        public Boolean Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
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

        public int DiasVigencia
        {
            get { return idiasVigencia; }
            set { idiasVigencia = value; }
        }

        public bool FacturasVencidas
        {
            get { return bFacturasVencidas; }
            set { bFacturasVencidas = value; }
        }

        #endregion propiedades
    }
}
