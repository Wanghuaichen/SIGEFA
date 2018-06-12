using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsFormulario
    {
        #region propiedades
               
        private Int32 iCodFormulario;
        private String sDescripcion;
        private Int32 iNivel;
        private Int32 iPadre;

               
        public Int32 CodFormulario
        {
            get { return iCodFormulario; }
            set { iCodFormulario = value; }
        }        
        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }
        public Int32 Nivel
        {
            get { return iNivel; }
            set { iNivel = value; }
        }
        public Int32 Padre
        {
            get { return iPadre; }
            set { iPadre = value; }
        }

        #endregion propiedades

       
    }
}
