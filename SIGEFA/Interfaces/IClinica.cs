using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using System.Data;

namespace SIGEFA.Interfaces
{
    public interface IClinica
    {
        #region CRUD_PACIENTE
        Boolean InsertPaciente(clsPaciente Paciente);
        Boolean UpdatePaciente(clsPaciente Paciente);
        Boolean DeletePaciente(Int32 Codigo);

        clsPaciente CargaPaciente(Int32 Codigo);
        DataTable ListaPacientes();
        #endregion

        #region CRUD_HISTORIA
        Boolean InsertHistoriaCabecera(clsHistoria Historia);

        Boolean InsertHistoriaDetalle(clsDetalleHistoria Detalle);

        Boolean UpdateHistoriaCabecera(clsHistoria Historia);

        Boolean UpdateHistoriaDetalle(clsDetalleHistoria Detalle);

        Boolean DeleteHistoria(Int32 Codigo);

        clsHistoria CargaHistoriaCabecera(string Numero);

        clsDetalleHistoria CargaHistoriaDetalle(Int32 Codigo);

        DataTable ListaDetalleHistorial(Int32 CodigoCab);
        #endregion
    }
}
