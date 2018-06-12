using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsDosis
    {
        # region propiedades

        private Int32 iCodDosisNuevo; 
        private Int32 iCodDosis;
        private Int32 iCodProducto;
        private String sCultivo;
        private String sAplicacion;
        private String sDosis;
        private String sLmrppm;
        private String sPc;

        public Int32 CodDosisNuevo
        {
            get { return iCodDosisNuevo; }
            set { iCodDosisNuevo = value; }
        }

        public Int32 CodDosis
        {
            get { return iCodDosis; }
            set { iCodDosis = value; }
        }

        public Int32 CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }

        public String Cultivo
        {
            get { return sCultivo; }
            set { sCultivo = value; }
        }

        public String Aplicacion
        {
            get { return sAplicacion; }
            set { sAplicacion = value; }
        }

        public String Dosis
        {
            get { return sDosis; }
            set { sDosis = value; }
        }

        public String Lmrppm
        {
            get { return sLmrppm; }
            set { sLmrppm = value; }
        }

        public String Pc
        {
            get { return sPc; }
            set { sPc = value; }
        }

        # endregion propiedades
    }
}
