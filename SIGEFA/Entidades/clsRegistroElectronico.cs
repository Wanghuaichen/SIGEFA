using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsRegistroElectronico
    {
        #region propiedades

        private Int32 codlibroregistronuevo;

        public Int32 Codlibroregistronuevo
        {
            get { return codlibroregistronuevo; }
            set { codlibroregistronuevo = value; }
        }
        private Int32 codlibroregistro;

        public Int32 Codlibroregistro
        {
            get { return codlibroregistro; }
            set { codlibroregistro = value; }
        }
        private Int32 codlibros;

        public Int32 Codlibros
        {
            get { return codlibros; }
            set { codlibros = value; }
        }
        private String codsunat;

        public String Codsunat
        {
            get { return codsunat; }
            set { codsunat = value; }
        }
        private String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private String codigo;

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
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
