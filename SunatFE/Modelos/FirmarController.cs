using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunatFE
{
    public class FirmarController
    {

        public FirmadoResponse FirmadoResponse(FirmadoRequest request,Int32 TipoDocumento)
        {
            var response = new FirmadoResponse();

            try
            {
                var serializador = new Serializador
                {
                    RutaCertificadoDigital = request.CertificadoDigital,
                    PasswordCertificado = request.PasswordCertificado,
                    TipoDocumento = request.UnSoloNodoExtension ? 0 : 1
                };

                response.TramaXmlFirmado = serializador.FirmarXml(request.TramaXmlSinFirma,TipoDocumento);
                response.ResumenFirma = serializador.DigestValue;
                response.ValorFirma = serializador.ValorFirma;
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return response;
        }

    }
}
