using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsRequerimiento
    {
        public Int32 CodRequerimientoNuevo
        { get; set; }
        public Int32 CodRequerimiento
        {
            get;
            set;
        }
        public Int32 CodAlmacen
        {
            get;
            set;
        }
        public String Comentario
        {
            get;
            set;
        }
         public Int32 Tipo
        {
            get;
            set;
        }
         public Int32 CodTipoDocumento
         {
             get;
             set;
         }
         public String SiglaDocumento
         {
             get;
             set;
         }
         public String DescripcionDocumento
         { get; set; }

         public Int32 CodSerie
         {
             get;
             set;
         }
         public String Serie
         {
             get;
             set;
         }
         public String NumDoc
         {
             get;
             set;
         }

         public DateTime FechaOrden
         {
             get;
             set;
         }
         public Int32 CodUser
         {
             get;
             set;
         }
         public DateTime FechaRegistro
         {
             get;
             set;
         }

        
        public Int32 Estado
        {
            get;
            set;
        }
        public Int32 Anulado
        {
            get;
            set;
        }
        public Int32 Atendido
        {
            get;
            set;
        }

        public Int32 codAlmaDestino
        {
            get; set;
        }

        public String comentarioRechazado
        {
             get; set;
        }
        public List<clsDetalleRequerimiento> Detalle
        {
            get;
            set;
        }
    }
}
