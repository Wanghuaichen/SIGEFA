using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.SunatFacElec
{
    public class clsEntArchivos
    {
        private Int32 codarchivo;
        private Int32 codrelacion;
        private Int32 codrequisito;
        private String nombre;
        private String numerodoc;               
        private String tipodoc;
        private String tipoarchivo;
        private String pcruta;
        private Int32 coduser;
        private Int32 estado;
        private DateTime fecharegistro;
        private Int32 nuevocodarchivo;
        private Byte[] imagen;


        public Int32 Codrequisito
        {
            get { return codrequisito; }
            set { codrequisito = value; }
        }
        public Byte[] Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public Int32 Nuevocodarchivo
        {
            get { return nuevocodarchivo; }
            set { nuevocodarchivo = value; }
        }

        public DateTime Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }

        public Int32 Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Int32 Coduser
        {
            get { return coduser; }
            set { coduser = value; }
        }

        public String Pcruta
        {
            get { return pcruta; }
            set { pcruta = value; }
        }

        public String Tipoarchivo
        {
            get { return tipoarchivo; }
            set { tipoarchivo = value; }
        }

        public String Tipodoc
        {
            get { return tipodoc; }
            set { tipodoc = value; }
        }

        public String Numerodoc
        {
            get { return numerodoc; }
            set { numerodoc = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Int32 Codrelacion
        {
            get { return codrelacion; }
            set { codrelacion = value; }
        }

        public Int32 Codarchivo
        {
            get { return codarchivo; }
            set { codarchivo = value; }
        }
    }
}
