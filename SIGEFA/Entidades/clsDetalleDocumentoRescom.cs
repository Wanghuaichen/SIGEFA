using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleDocumentoRescom
    {
        #region propiedades        
        
        private Int32 coddetallerescom;
        private Int32 coddocumentorescom;
        private Int32 codFacturaV;
        private Int32 codTipoDocumento;
        private String numDocumento;
        private Int32 codAlmacen;
        private Int32 codCliente;
        private Int32 codSerie;
        private String serie;
        private Decimal bruto;
        private Decimal montodscto;
        private Decimal valorventa;
        private Decimal igv;
        private Decimal total;
        private Boolean estado;
        private Int32 codUsuario;
        private DateTime fecharegistro;
        private Int32 coddetallerescomNuevo;

        public Int32 CoddetallerescomNuevo
        {
            get { return coddetallerescomNuevo; }
            set { coddetallerescomNuevo = value; }
        }

        public Int32 Coddetallerescom
        {
            get { return coddetallerescom; }
            set { coddetallerescom = value; }
        }

        public Int32 Coddocumentorescom
        {
            get { return coddocumentorescom; }
            set { coddocumentorescom = value; }
        }
        

        public Int32 CodFacturaV
        {
            get { return codFacturaV; }
            set { codFacturaV = value; }
        }        

        public Int32 CodTipoDocumento
        {
            get { return codTipoDocumento; }
            set { codTipoDocumento = value; }
        }        

        public String NumDocumento
        {
            get { return numDocumento; }
            set { numDocumento = value; }
        }       

        public Int32 CodAlmacen
        {
            get { return codAlmacen; }
            set { codAlmacen = value; }
        }
        public Int32 CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; }
        }
        public Int32 CodSerie
        {
            get { return codSerie; }
            set { codSerie = value; }
        }
        public String Serie
        {
            get { return serie; }
            set { serie = value; }
        }
        public Decimal Bruto
        {
            get { return bruto; }
            set { bruto = value; }
        }
        public Decimal Montodscto
        {
            get { return montodscto; }
            set { montodscto = value; }
        } 
        public Decimal Valorventa
        {
            get { return valorventa; }
            set { valorventa = value; }
        }     

        public Decimal Igv
        {
            get { return igv; }
            set { igv = value; }
        }        

        public Decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Int32 CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; }
        }

        public DateTime Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }


        #endregion propiedades
    }
}
