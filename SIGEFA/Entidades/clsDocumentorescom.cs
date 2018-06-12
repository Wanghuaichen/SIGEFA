using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDocumentorescom
    {
         #region propiedades        

         private Int32 codigo;
         private Int32 codSerie;
         private String numeracion;
         private String tipodocumento;
         private Boolean estado;
         private Int32 codUser;
         private DateTime fecharegistro;
         private Int32 codigonuevo;
         private Int32 codtipodocumento;

         public Int32 Codtipodocumento
         {
             get { return codtipodocumento; }
             set { codtipodocumento = value; }
         }

         public Int32 Codigonuevo
         {
             get { return codigonuevo; }
             set { codigonuevo = value; }
         }

         public Int32 Codigo
         {
             get { return codigo; }
             set { codigo = value; }
         }

         public Int32 CodSerie
         {
             get { return codSerie; }
             set { codSerie = value; }
         }

         public String Numeracion
         {
             get { return numeracion; }
             set { numeracion = value; }
         }

         public String Tipodocumento
         {
             get { return tipodocumento; }
             set { tipodocumento = value; }
         }

         public Boolean Estado
         {
             get { return estado; }
             set { estado = value; }
         }

         public Int32 CodUser
         {
             get { return codUser; }
             set { codUser = value; }
         }

         public DateTime Fecharegistro
         {
             get { return fecharegistro; }
             set { fecharegistro = value; }
         }

         #endregion propiedades
    }
}
