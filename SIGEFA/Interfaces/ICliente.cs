using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ICliente
    {
        Boolean Insert(clsCliente ClienteNuevo);
        Boolean Update(clsCliente Cliente);
        Boolean Delete(Int32 CodigoCli);
        Boolean CambioHabilitado(Int32 CodCliente, Boolean Estado);


        clsCliente CargaCliente(Int32 CodigoCli);
        DataTable CargaClientes();//para cargar los combos
        DataTable ListaClientes();
        clsCliente MuestraClienteNota(Int32 CodigoCli);
        clsCliente BuscaCliente(String Codigo, Int32 Tipo);
        DataTable BuscaClientes(Int32 Criterio, String Filtro);
        DataTable RelacionClientes();
        String CodigoPersonalizado(); //ultimo codigo personalizado
        clsCliente CargaDeuda(clsCliente Cliente);
        clsCliente CargaFacturasVencidas(clsCliente cliente);

        DataTable ListaClientesConsultor(Int32 CodEntConsExt);
        clsCliente ConsultaCliente(String DNIRUC);
        Boolean InsertConCli(Int32 codEntConsExt, Int32 CodCliente);
        Boolean DeleteConCli(Int32 codEntConsExt, Int32 CodCliente);
    }
}
