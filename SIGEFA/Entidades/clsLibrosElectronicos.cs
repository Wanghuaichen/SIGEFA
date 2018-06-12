using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsLibrosElectronicos
    {
        #region propiedades

        private Int32 codlibro;
        private String codsunat;
        private String descripcion;
        private Int32 aplicaanio;
        private Int32 aplicames;
        private Int32 aplicadia;
        private Int32 aplicaoportunidad;
        private Int32 estado;
        private Int32 coduser;
        private DateTime fecharegistro;
        private Int32 codnuevolibro;

        public Int32 Codnuevolibro
        {
            get { return codnuevolibro; }
            set { codnuevolibro = value; }
        }

        public DateTime Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }        
        public Int32 Coduser
        {
            get { return coduser; }
            set { coduser = value; }
        }
        
        public Int32 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
       
        public Int32 Aplicaoportunidad
        {
            get { return aplicaoportunidad; }
            set { aplicaoportunidad = value; }
        }
        
        public Int32 Aplicadia
        {
            get { return aplicadia; }
            set { aplicadia = value; }
        }
        
        public Int32 Aplicames
        {
            get { return aplicames; }
            set { aplicames = value; }
        }
        
        public Int32 Aplicaanio
        {
            get { return aplicaanio; }
            set { aplicaanio = value; }
        }
        
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        
        public String Codsunat
        {
            get { return codsunat; }
            set { codsunat = value; }
        }        

        public Int32 Codlibro
        {
            get { return codlibro; }
            set { codlibro = value; }
        }
        
        #endregion propiedades
    }
}
