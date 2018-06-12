using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Interfaces;
using SIGEFA.Conexion;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Entidades;

namespace SIGEFA.InterMySql
{
    class MysqlNotaCreditoCompra : INotaCreditoCompra
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public Boolean insert(clsNotaSalida nota)
        {            
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaNotaCreditoCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codSu", nota.CodSucursal);
                oParam = cmd.Parameters.AddWithValue("codalma", nota.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codtran", nota.CodTipoTransaccion);
                oParam = cmd.Parameters.AddWithValue("codtipo", nota.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("codserie", nota.CodSerie);
                oParam = cmd.Parameters.AddWithValue("serie", nota.Serie);
                oParam = cmd.Parameters.AddWithValue("numdoc", nota.NumDoc);
                oParam = cmd.Parameters.AddWithValue("tipocliente", nota.TipoCliente);
                if (nota.CodCliente != 0) { oParam = cmd.Parameters.AddWithValue("codcli", nota.CodCliente); } else { oParam = cmd.Parameters.AddWithValue("codcli", null); }
                oParam = cmd.Parameters.AddWithValue("moneda", nota.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio", nota.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("fechasalida", nota.FechaSalida);
                oParam = cmd.Parameters.AddWithValue("comentario", nota.Comentario);
                oParam = cmd.Parameters.AddWithValue("bruto", nota.MontoBruto);
                oParam = cmd.Parameters.AddWithValue("montodscto", nota.MontoDscto);
                oParam = cmd.Parameters.AddWithValue("igv", nota.Igv);
                oParam = cmd.Parameters.AddWithValue("total", nota.Total);
                oParam = cmd.Parameters.AddWithValue("pendiente", nota.Total);
                oParam = cmd.Parameters.AddWithValue("estado", nota.Estado);              
                oParam = cmd.Parameters.AddWithValue("codven", nota.CodVendedor);
                oParam = cmd.Parameters.AddWithValue("codusu", nota.CodUser);
                oParam = cmd.Parameters.AddWithValue("documentorefe", nota.DocumentoReferencia);               
                oParam = cmd.Parameters.AddWithValue("aplicad", nota.Aplicada);
                if (nota.Aplicada != 0) { oParam = cmd.Parameters.AddWithValue("codaplicad", nota.CodAplicada); } else { oParam = cmd.Parameters.AddWithValue("codaplicad", null); }
                if (nota.Motivo != "") { cmd.Parameters.AddWithValue("motiv", nota.Motivo); } else { cmd.Parameters.AddWithValue("motiv", null); }
                if (nota.CodProveedor != 0) { cmd.Parameters.AddWithValue("codprov", nota.CodProveedor); } else { cmd.Parameters.AddWithValue("CodProv", null); }
               
                //oParam = cmd.Parameters.AddWithValue("newid", 0);
                //oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                //nota.CodNotaSalida = Convert.ToString(cmd.Parameters["newid"].Value);
                //tran = nota.CodTipoTransaccion;
                if (x != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
