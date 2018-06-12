using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.SunatFacElec
{
    public class Comprobante
    {

        #region Declaracion de Variables

        String URI_SAT = "http://www.sat.gob.mx/cfd/2";

        // Esta variable de nivel de modulo nos facilita las operaciones en las demas subrutinas
        private System.Xml.XmlDocument m_xmlDOM; 
        private System.Xml.XmlNode Nodo; 
        private String DIR_SAT;
        private String DIR_PKI;


        //---------Variables Publicas
        private String Archivo_XSLT;
        private String Archivo_CERT;
        private String Archivo_KEY;
        private String Archivo_XML;
       
        public String Archivo_XSLT1
        {
            get { return Archivo_XSLT; }
            set { Archivo_XSLT = value; }
        }
        public String Archivo_CERT1
        {
            get { return Archivo_CERT; }
            set { Archivo_CERT = value; }
        }
        public String Archivo_KEY1
        {
            get { return Archivo_KEY; }
            set { Archivo_KEY = value; }
        }
        public String Archivo_XML1
        {
            get { return Archivo_XML; }
            set { Archivo_XML = value; }
        }


        //---------Variable Rutas de Guardado
        private String Directorio_Guardado;
        private String Carpeta_xml;
        private String Rutafactura;        

        public String Directorio_Guardado1
        {
            get { return Directorio_Guardado; }
            set { Directorio_Guardado = value; }
        }
        public String Carpeta_xml1
        {
            get { return Carpeta_xml; }
            set { Carpeta_xml = value; }
        }
        public String Rutafactura1
        {
            get { return Rutafactura; }
            set { Rutafactura = value; }
        }

         //public Enum TipoComprobante {
         //   int Egreso = 0;
         //   int Ingreso = 1;
         //   int Traslado = 2;
         //}

        private String vSerie;        
        private String vFolio;       
        private DateTime vFecha;

        public String VSerie
        {
            get { return vSerie; }
            set { vSerie = value; }
        }
        public String VFolio
        {
            get { return vFolio; }
            set { vFolio = value; }
        }
        public DateTime VFecha
        {
            get { return vFecha; }
            set { vFecha = value; }
        }

        private String vNoAprobacion;       
        private Int32 vAnoAprobacion;        
        private String vFormaDePago;
        private String vMetodoDePago;
        private String vSubTotal;

        public String VNoAprobacion
        {
            get { return vNoAprobacion; }
            set { vNoAprobacion = value; }
        }
        public Int32 VAnoAprobacion
        {
            get { return vAnoAprobacion; }
            set { vAnoAprobacion = value; }
        }
        public String VFormaDePago
        {
            get { return vFormaDePago; }
            set { vFormaDePago = value; }
        }
       
        public String VMetodoDePago
        {
            get { return vMetodoDePago; }
            set { vMetodoDePago = value; }
        }
        public String VSubTotal
        {
            get { return vSubTotal; }
            set { vSubTotal = value; }
        }
        
        private Decimal vDescuento;
        private String vMotivoDescuento;
        private Int32 vTipoComprobante;

        private Decimal vTotal;
        private String vDomicilioReceptor;
        private String vDomicilioExpedicion;
        private String vDomicilioFiscalEmisor;
        private Decimal vIVA;
        private Decimal vIVARetenido;
        private Decimal vIEPS;
        private Decimal vISRRetenido;
        #endregion
    }
}
