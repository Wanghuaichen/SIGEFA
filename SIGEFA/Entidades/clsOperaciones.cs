using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsOperaciones
    {
        #region propiedades

        private Int32 codoperacion;

        public Int32 Codoperacion
        {
            get { return codoperacion; }
            set { codoperacion = value; }
        }
        private String codigo;

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private Int32 estado;

        public Int32 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private Int32 coduser;

        public Int32 Coduser
        {
            get { return coduser; }
            set { coduser = value; }
        }
        private DateTime fecharegistro;

        public DateTime Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }


        #endregion propiedades
    }
}
