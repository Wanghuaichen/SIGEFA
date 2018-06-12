using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;


namespace SIGEFA.Interfaces
{
    interface IUsuario
    {
        Boolean Insert(clsUsuario UsuarioNuevo);
        Boolean Update(clsUsuario UsuarioNuevo);
        Boolean Delete(Int32 Codigo);

        Boolean Login(clsUsuario Usuario);
                
        clsUsuario CargaUsuario(Int32 Codigo);
        clsUsuario CargaUsuarioNivel();
        DataTable ListaUsuarios();
        DataTable BuscaUsuarios(Int32 Criterio, String Filtro);
        DataTable ListaCorreosUsuarios();

        DataTable correoTesoreria();
        DataTable ListaNiveles();

        DataTable ListaUsuarios_Empresa(Int32 Codigo);
    }
}
