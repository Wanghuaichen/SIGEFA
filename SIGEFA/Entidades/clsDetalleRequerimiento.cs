using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleRequerimiento
    {
        #region Propiedades
        public Int32 CodDetalleRequerimiento
        {
            get;
            set;
        }
        public Int32 CodProducto
        {
            get;
            set;
        }
        public Int32 CodRequerimiento
        {
            get;
            set;
        }
       
        public Int32 Unidad
        {
            get;
            set;
        }
       
        public Double Cantidad
        {
            get;
            set;
        }
       
        public DateTime FechaRegistro
        {
            get;
            set;
        }
       
        public Int32 CodUser
        {
            get;
            set;
        }

        public Int32 Estado
        { get; set; }
        public Int32 Anulado
        { get; set; }


        private String scomentario;

        public String Comentario
        {
            get { return scomentario; }
            set { scomentario = value; }
        }


        private Int32 iEstadoVigente;

        public Int32 EstadoVigente
        {
            get { return iEstadoVigente; }
            set { iEstadoVigente = value; }
        }


        #endregion Propiedades


        #region IEquatable<clsDetalleRequerimiento> Members



        public bool CodProEquals(Int32 codigo)
        {
            if (this.CodProducto == codigo)
                return true;
            return false;
        }

        #endregion
    }
}
