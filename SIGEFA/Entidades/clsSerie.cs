using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsSerie
    {
        #region propiedades

        private Int32 iCodSerie;        
        private Int32 iCodDocumento;
        private Int32 iCodEmpresa;
        private Int32 iCodAlmacen;
        private String sDescripcion;
        private String sSerie;
        private Int32 iInicio;
        private Int32 iFin;
        private Int32 iNumeracion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private String sNombreImpresora;
        private String sPaperSize;
        private String sSerieImpresora;
        private Boolean bPreImpreso;
                
        public Int32 CodSerie
        {
            get { return iCodSerie; }
            set { iCodSerie = value; }
        }
        public Int32 CodDocumento
        {
            get { return iCodDocumento; }
            set { iCodDocumento = value; }
        }
        public Int32 CodEmpresa
        {
            get { return iCodEmpresa; }
            set { iCodEmpresa = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }
        public String Serie
        {
            get { return sSerie; }
            set { sSerie = value; }
        }
        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }
        public String NombreImpresora
        {
            get { return sNombreImpresora; }
            set { sNombreImpresora = value; }
        }
        public String PaperSize
        {
            get { return sPaperSize; }
            set { sPaperSize = value; }
        }
        public Int32 Inicio
        {
            get { return iInicio; }
            set { iInicio = value; }
        }
        public Int32 Fin
        {
            get { return iFin; }
            set { iFin = value; }
        }
        public Int32 Numeracion
        {
            get { return iNumeracion; }
            set { iNumeracion = value; }
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

        public string SerieImpresora
        {
            get { return sSerieImpresora; }
            set { sSerieImpresora = value; }
        }
        public Boolean PreImpreso
        {
            get { return bPreImpreso; }
            set { bPreImpreso = value; }
        }

        #endregion propiedades
    }
}
