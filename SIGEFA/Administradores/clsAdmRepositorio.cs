using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;

namespace SIGEFA.Administradores
{
    class clsAdmRepositorio
    {
        IRepositorio irepo = new MysqlRepositorio();

        public bool registra_repositorio(Entidades.clsRepositorio repo)
        {
            return irepo.registra_repositorio(repo);            
        }

        public List<Entidades.clsRepositorio> buscar_repositorio(Entidades.clsRepositorio repo) {

            return irepo.buscar_repositorio(repo);        
        }

        public List<Entidades.clsRepositorio> listar_repositorio(String estado, Int32 codsucu, Int32 codalma) {

            return irepo.listar_repositorio(estado, codsucu, codalma);
        }

        public bool actualiza_repositorio(Entidades.clsRepositorio repo) {

            return irepo.actualiza_repositorio(repo);
        }

        public bool ActualizaCorrelativoDocResp(Int32 codtipodoc, Int32 codalma)
        {
            return irepo.ActualizaCorrelativoDocResp(codtipodoc, codalma);
        }
    }
}
