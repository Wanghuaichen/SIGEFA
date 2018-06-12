using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IRepositorio
    {
        Boolean registra_repositorio(clsRepositorio repo);
        List<clsRepositorio> buscar_repositorio(clsRepositorio repo);
        List<clsRepositorio> listar_repositorio(String estado, Int32 codsuc, Int32 codalma);
        Boolean actualiza_repositorio(clsRepositorio repo);

        Boolean ActualizaCorrelativoDocResp(Int32 codtipodoc, Int32 codalma);
    }
}
