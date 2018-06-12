using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using SIGEFA.ServicioEnvio;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
//using System.ServiceModel;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using SIGEFA.Formularios;
using System.Windows.Forms;
using Ionic.Zip;
using System.Reflection;
using System.Xml.Xsl;
using System.Xml.XPath;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using SunatFE;
using SunatFE.Sunat;

namespace SIGEFA.SunatFacElec
{
    public class Conexion
    {
        
        //ServicioEnvio.billServiceClient Wservices = new ServicioEnvio.billServiceClient("BillServicePort");
        private bool Retencion { get; set; }
        public DocumentoElectronico documento;
        public ComunicacionBaja baja;
        public ResumenDiario resumen;
        public DocumentoBaja mel;
        GrupoResumen mel2 = new GrupoResumen();
        Serializador ser = new Serializador();
        String TramaXmlSinFirma { get; set; }
        public String RutaArchivo { get; set; }
        public String RutaCertificado { get; set; }
        public String nombreArchivo { get; set; }
        MySqlDataAdapter adap = new MySqlDataAdapter();

        public Byte[] LogoEmp { get; set; }
        String datosAdicionales_CDB = "";
        String CodigoCertificado = "";
        String firmadig = ""; String resumenfirmadig = "";
        public Int32 CodigoErrorEnvio = 0;// 1) Error en el xml  2) Error de envio a sunat - falla de servidor
        public Int32 enviado = 0;
        public Boolean VerificaChek = false;
        public String RptaDocumentos; //Respuesta para comunicacion de baja y Resumen diario
        public clsEmpresa empresa = new clsEmpresa();
        clsAdmEmpresa admemp = new clsAdmEmpresa();
        clsAdmMoneda admmod = new clsAdmMoneda();
        DetalleDocumento det;
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmTipoDocumento admdoc = new clsAdmTipoDocumento();
        Conversion conv = new Conversion();
        clsTransaccion transas = new clsTransaccion();
        clsAdmTransaccion admtransas = new clsAdmTransaccion();
        clsProducto prod = new clsProducto();
        clsAdmProducto admprod = new clsAdmProducto();
        FirmadoRequest requet = new FirmadoRequest();
        clsReporteFactura ds = new clsReporteFactura();
        clsAdmFacturaVenta admfac = new clsAdmFacturaVenta();
        clsNotasCreditoDebitoVenta ds1 = new clsNotasCreditoDebitoVenta();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsFacturaVenta venta = new clsFacturaVenta();      
        public Tuple<string, bool> respuestaserver;
        EnviarDocumentoResponse respuesta_aux=null;
        clsAdmRepositorio clsadmrepo = new clsAdmRepositorio();
        clsRepositorio repo = new clsRepositorio();

        public void Datos_Documento(DocumentoElectronico documento, clsCliente client, clsFacturaVenta venta)
        {
            //Datos del Emisor
            documento.FechaEmision = DateTime.Today.ToShortDateString();
            documento.Emisor.NombreLegal = empresa.RazonSocial;
            documento.Emisor.Ubigeo = "200101";
            documento.Emisor.Direccion = empresa.Direccion;
            documento.Emisor.Urbanizacion = "PIURA";
            documento.Emisor.Departamento = "PIURA";
            documento.Emisor.Provincia = "PIURA";
            documento.Emisor.Distrito = "PIURA";
            documento.Emisor.NroDocumento = empresa.Ruc;
            documento.Emisor.TipoDocumento = "6";
            
            documento.Receptor.NombreComercial = client.RazonSocial;
            documento.Receptor.NombreLegal = client.RazonSocial;
            documento.Receptor.Urbanizacion = "PIURA";
            documento.Receptor.Departamento = client.Departamento;
            documento.Receptor.Provincia = client.Provincia;
            documento.Receptor.Distrito = client.Distrito;

            //Montos
            documento.TotalVenta = Convert.ToDecimal(venta.Total);
            if (venta.Moneda == 1)
            {
                documento.MontoEnLetras = conv.enletras(venta.Total.ToString());
                documento.Gratuitas = Convert.ToDecimal(venta.Gratuitas);
                documento.Gravadas = Convert.ToDecimal(venta.Gravadas);
                documento.Exoneradas = Convert.ToDecimal(venta.Exoneradas);
                documento.Inafectas = Convert.ToDecimal(venta.Inafectas);
                documento.TotalIgv = Convert.ToDecimal(venta.Igv);
                documento.DescuentoGlobal = Convert.ToDecimal(venta.MontoDscto);
            }
            else
            {
                documento.MontoEnLetras = conv.enletras((venta.Total.ToString()));
                documento.Gratuitas = Convert.ToDecimal(venta.Gratuitas) / Convert.ToDecimal(venta.TipoCambio);
                documento.Gravadas = Convert.ToDecimal(venta.Gravadas) / Convert.ToDecimal(venta.TipoCambio);
                documento.Exoneradas = Convert.ToDecimal(venta.Exoneradas) / Convert.ToDecimal(venta.TipoCambio);
                documento.Inafectas = Convert.ToDecimal(venta.Inafectas) / Convert.ToDecimal(venta.TipoCambio);
                documento.TotalIgv = Convert.ToDecimal(venta.Igv);
                documento.DescuentoGlobal = Convert.ToDecimal(venta.MontoDscto) / Convert.ToDecimal(venta.TipoCambio);
            }

            //VENTA INTERNA - ANTICIPOS
            if (documento.TipoOperacion == "04") 
            {
                documento.TipoDocAnticipo = venta.TipoDocumentoAnticipo;
                documento.DocAnticipo = venta.DocumentoReferenciaAnticipo;
                documento.MonedaAnticipo = "PEN";
                documento.MontoAnticipo = venta.MontoAnticipo;
            }
        }

        public void Valida_Datos(clsTipoDocumento doc, DocumentoElectronico documento, clsFacturaVenta venta)
        {
            try
            {
                if (doc.Tipodoccodsunat == "03")
                {
                    documento.IdDocumento = "B" +venta.Serie + "-" + venta.NumDoc.PadLeft(8, '0');  //  bv0001
                    documento.TipoDocumento = doc.Tipodoccodsunat;
                    documento.TipoOperacion = transas.Codsunat;                  
                }
                else if (doc.Tipodoccodsunat == "01")
                {
                    documento.IdDocumento = "F" + venta.Serie + "-" + venta.NumDoc.PadLeft(8, '0');  //  bv0001
                    documento.TipoDocumento = doc.Tipodoccodsunat;
                    documento.TipoOperacion = transas.Codsunat;                   
                }

                if (venta.Moneda == 1)
                {
                    documento.Moneda = "PEN";
                }
                else
                {
                    documento.Moneda = "USD";
                }

                if (doc.Tipodoccodsunat == "03" || doc.Tipodoccodsunat == "01")
                {
                    var invoice = GeneradorXML.GenerarInvoice(documento);
                    var serializador3 = new Serializador();
                    TramaXmlSinFirma = serializador3.GenerarXml(invoice);
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        public void GeneraDiscrepancia_DocumentoRelacionado_NC_ND(clsFacturaVenta venta, DocumentoElectronico documento, clsNotaCredito nc, clsNotaDebito nd)
        {
            if (nc != null)
            {
                Discrepancia disk = new Discrepancia();

                disk.Descripcion = nc.Comentario;
                if (venta.CodTipoDocumento == 2)
                {
                    disk.NroReferencia = "F" +  venta.Serie + "-" + venta.NumDoc.PadLeft(8, '0');
                }
                else if (venta.CodTipoDocumento == 1)
                {
                   disk.NroReferencia = "B" + venta.Serie +"-" + venta.NumDoc.PadLeft(8, '0');
                }

                disk.Tipo = nc.Motivo;
                documento.Discrepancias.Add(disk);

                // revisar datos de DocumentoRelacionado
                DocumentoRelacionado dr = new DocumentoRelacionado();
                if (venta.CodTipoDocumento == 2)
                {
                    dr.NroDocumento = "F" + venta.Serie + "-" + venta.NumDoc.PadLeft(8, '0');
                }
                else if (venta.CodTipoDocumento == 1)
                {
                    dr.NroDocumento = "B" +  venta.Serie +"-" + venta.NumDoc.PadLeft(8, '0');
                }

                dr.TipoDocumento = admdoc.CargaTipoDocumento(venta.CodTipoDocumento).Tipodoccodsunat.ToString();// venta.CodTipoDocumento.ToString();
                documento.Relacionados.Add(dr);

            }
            if (nd != null)
            {
                Discrepancia disk = new Discrepancia();

                disk.Descripcion = nd.Comentario;
                if (venta.CodTipoDocumento == 2)
                {
                    disk.NroReferencia = "F" +  venta.Serie + "-" + venta.NumDoc.PadLeft(8, '0');
                }
                else if (venta.CodTipoDocumento == 1)
                {
                    disk.NroReferencia = "B" + venta.Serie +"-" + venta.NumDoc.PadLeft(8, '0');
                }
                disk.Tipo = nd.Motivo;
                documento.Discrepancias.Add(disk);

                // revisar datos de DocumentoRelacionado
                DocumentoRelacionado dr = new DocumentoRelacionado();
                if (venta.CodTipoDocumento == 2)
                {
                    dr.NroDocumento = "F" +  venta.Serie +"-" + venta.NumDoc.PadLeft(8, '0');
                }
                else if (venta.CodTipoDocumento == 1)
                {
                    dr.NroDocumento = "B" +  venta.Serie + "-" + venta.NumDoc.PadLeft(8, '0');
                }
                dr.TipoDocumento = admdoc.CargaTipoDocumento(venta.CodTipoDocumento).Tipodoccodsunat.ToString();
                documento.Relacionados.Add(dr);
            }
        }

        public void Valida_Datos_NC_ND(clsFacturaVenta venta, clsTipoDocumento doc, DocumentoElectronico documento, clsNotaCredito nc, clsNotaDebito nd)
        {
            if (doc.Tipodoccodsunat == "07")
            {
                if (venta.CodTipoDocumento == 2)
                {
                    documento.IdDocumento = "F" + nc.Serie + "-" + nc.NumFac.PadLeft(8, '0');//nc.DocumentoNotaCredito.PadLeft(8, '0'); //Verificar el tipo de documento
                    documento.TipoDocumento = doc.Tipodoccodsunat;
                    documento.TipoOperacion = transas.Codsunat;
                }
                else if (venta.CodTipoDocumento == 1)
                {
                    documento.IdDocumento = "B" + nc.Serie + "-" + nc.NumFac.PadLeft(8, '0');// nc.DocumentoNotaCredito.PadLeft(8, '0'); //Verificar el tipo de documento
                    documento.TipoDocumento = doc.Tipodoccodsunat;
                    documento.TipoOperacion = transas.Codsunat;
                }
            }
            else if (doc.Tipodoccodsunat == "08")
            {
                if (venta.CodTipoDocumento == 2)
                {
                    documento.IdDocumento = "F" + nd.Serie + "-" + nd.NumFac.PadLeft(8, '0');// nd.DocumentoNotaDebito.PadLeft(8, '0');
                    documento.TipoDocumento = doc.Tipodoccodsunat;
                    documento.TipoOperacion = transas.Codsunat;
                }
                else if (venta.CodTipoDocumento == 1)
                {
                   documento.IdDocumento = "B" + nd.Serie + "-" + nd.NumFac;//nd.DocumentoNotaDebito.PadLeft(8, '0'); //Verificar el tipo de documento
                   documento.TipoDocumento = doc.Tipodoccodsunat;
                   documento.TipoOperacion = transas.Codsunat;
                }
            }

            if (venta.Moneda == 1)
            {
                documento.Moneda = "PEN";
            }
            else
            {
                documento.Moneda = "USD";
            }

            switch (documento.TipoDocumento)
            {
                case "07":
                    //NotaCredito
                    var notaCredito = GeneradorXML.GenerarCreditNote(documento);
                    var serializador1 = new Serializador();
                    TramaXmlSinFirma = serializador1.GenerarXml(notaCredito);
                    break;
                case "08":
                    //GenerarNotaDebito
                    var notaDebito = GeneradorXML.GenerarDebitNote(documento);
                    var serializador2 = new Serializador();
                    TramaXmlSinFirma = serializador2.GenerarXml(notaDebito);
                    break;
            }
        }

        public void GeneraXML(clsCliente client, clsFacturaVenta venta, List<clsDetalleFacturaVenta> detalleventa)
        {
            try
            {               
                empresa = admemp.CargaEmpresa3(venta.CodEmpresa);
                documento = new DocumentoElectronico();                
                doc = admdoc.CargaTipoDocumento(venta.CodTipoDocumento);
                transas = admtransas.MuestraTransaccion(venta.CodTipoTransaccion);
                documento.TipoOperacion = transas.Codsunat;
                if (client.Ruc.Length == 11) { documento.Receptor.TipoDocumento = "6"; documento.Receptor.NroDocumento = client.RucDni; }
                else if (client.Dni.Length == 8) { documento.Receptor.TipoDocumento = "1"; documento.Receptor.NroDocumento = client.RucDni; }
                //else if (client.Carnetext.Length == 12) { documento.Receptor.TipoDocumento = "4"; documento.Receptor.NroDocumento = client.RucDni; }

                this.Datos_Documento(documento, client, venta);
                Int32 contador = 1;

                

                foreach (clsDetalleFacturaVenta lista in detalleventa)
                {
                    det = new DetalleDocumento();

                    det.Id = contador;//lista.CodProducto;
                    det.Cantidad = Convert.ToDecimal(lista.Cantidad);
                    det.Descripcion = lista.Descripcion;
                    det.CodigoItem = contador.ToString();
                    det.PrecioUnitario = Convert.ToDecimal(lista.PrecioUnitario);
                    det.PrecioReferencial = (Convert.ToDecimal(lista.PrecioUnitario) / (1 + (Convert.ToDecimal(frmLogin.Configuracion.IGV) / 100)));
                    det.Impuesto = Convert.ToDecimal(lista.Igv);
                    det.TotalVenta = Convert.ToDecimal(lista.Subtotal) - Convert.ToDecimal(lista.Igv);
                    det.TipoImpuesto = lista.Tipoimpuesto;
                    prod = admprod.CargaProducto(lista.CodProducto, frmLogin.iCodAlmacen);

                    if (prod.CodTipoArticulo == 2)
                    { //2 Servicios
                        documento.MontoDetraccion = Convert.ToDecimal(Convert.ToDouble(documento.Gravadas) * 0.04);
                    }
                    if (lista.Tipoimpuesto == "21")// 4 venta gratuita
                    {
                        det.TotalVenta = det.PrecioUnitario * det.Cantidad;
                    }

                    documento.Items.Add(det);
                    contador++;
                }
                this.Valida_Datos(doc, documento, venta);

                RutaArchivo = Path.Combine(@"C:\DOCUMENTOS-" + empresa.Ruc, documento.IdDocumento + ".xml");
                File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(TramaXmlSinFirma));

                RutaCertificado = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\"+ empresa.Certificado;

                Nomenclatrura_firma(RutaArchivo, RutaCertificado,Convert.ToInt32(documento.TipoDocumento));                
                GeneraPDF(Convert.ToInt32(venta.CodFacturaVenta));

                /*Set's para el repositorio de documentos*/
                string mirutadearchivo = "";
                repo.Tipodoc = venta.CodTipoDocumento;
                repo.Nombredoc = nombreArchivo;
                repo.Fechaemision = venta.FechaPago;
                repo.Serie = venta.Serie;
                repo.Correlativo = venta.NumDoc;
                repo.Monto = Convert.ToDecimal(venta.Total);
                //respuesta_aux = new EnviarDocumentoResponse();
                repo.CodEmpresa = frmLogin.iCodEmpresa;
                repo.CodSucursal = frmLogin.iCodSucursal;
                repo.CodAlmacen = frmLogin.iCodAlmacen;
                repo.CodFacturaVenta = Convert.ToInt32(venta.CodFacturaVenta);
                //if (respuesta_aux == null) { MessageBox.Show("No se registraron datos en Repositorio"); return; }
                if (respuesta_aux.CodigoRespuesta == null) { repo.Estadosunat = "-1"; } else { repo.Estadosunat = respuesta_aux.CodigoRespuesta; }
                if (respuesta_aux.MensajeRespuesta == null) { repo.Mensajesunat = "No enviada"; } else { repo.Mensajesunat = respuesta_aux.MensajeRespuesta; }

                if (repo.Tipodoc == 2)//1 es boleta,2 es factura
                {
                    mirutadearchivo = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\FACTURAS\\" + nombreArchivo + ".xml";
                }
                else
                {
                    mirutadearchivo = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\BOLETAS\\" + nombreArchivo + ".xml";
                }
                repo.Xml = File.ReadAllBytes(mirutadearchivo);   
                repo.Pdf = File.ReadAllBytes(mirutadearchivo.Replace(".xml", ".pdf"));                
                repo.Usuario = frmLogin.iCodUser;

                if (!clsadmrepo.registra_repositorio(repo))
                {
                    MessageBox.Show("Documento no se pudo enviar al repositorio");
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        public void GeneraXML_NC(clsCliente client, clsNotaCredito nc, List<clsDetalleNotaCredito> detalle_nc)
        {
            empresa = admemp.CargaEmpresa3(frmLogin.iCodEmpresa);
            documento = new DocumentoElectronico();
            doc = admdoc.CargaTipoDocumento(nc.CodTipoDocumento);
            transas = admtransas.MuestraTransaccion(nc.CodTipoTransaccion);

            clsFacturaVenta venta = new clsFacturaVenta();
            venta = admfac.CargaFacturaVenta(nc.CodReferencia);

            if (client.RucDni.Length == 11) { documento.Receptor.TipoDocumento = "6"; documento.Receptor.NroDocumento = client.RucDni; }
            else if (client.RucDni.Length == 8) { documento.Receptor.TipoDocumento = "1"; documento.Receptor.NroDocumento = client.RucDni; }
            //else if (client.Carnetext.Length == 12) { documento.Receptor.TipoDocumento = "4"; documento.Receptor.NroDocumento = client.RucDni; }
            this.Datos_Documento(documento, client, venta);

            this.GeneraDiscrepancia_DocumentoRelacionado_NC_ND(venta, documento, nc, null);

            Int32 contador = 1;
            foreach (clsDetalleNotaCredito lista in detalle_nc)
            {
                det = new DetalleDocumento();

                det.Id = contador;//lista.CodProducto;
                det.Cantidad = Convert.ToDecimal(lista.Cantidad);
                det.Descripcion = lista.DescripcionNC;
                det.SubTotalVenta = Convert.ToDecimal(lista.Subtotal);
                det.CodigoItem = contador.ToString();
                det.PrecioUnitario = Convert.ToDecimal(lista.PrecioUnitario);
                det.PrecioReferencial = Convert.ToDecimal(lista.PrecioUnitario);
                det.Impuesto = Convert.ToDecimal(lista.Igv);
                det.TotalVenta = Convert.ToDecimal(lista.Subtotal) - Convert.ToDecimal(lista.Igv);
                det.TipoImpuesto = lista.TipoImpuesto;
                prod = admprod.CargaProducto(lista.CodProducto, frmLogin.iCodAlmacen);

                if (prod.CodTipoArticulo == 2)
                { //2 Servicios
                    documento.MontoDetraccion = Convert.ToDecimal(Convert.ToDouble(documento.Gravadas) * 0.04);
                }

                documento.Items.Add(det);
                //lista.Add(det);
                contador++;
            }
            this.Valida_Datos_NC_ND(venta, doc, documento, nc, null);

            RutaArchivo = Path.Combine(@"C:\DOCUMENTOS-" + empresa.Ruc, documento.IdDocumento + ".xml");
            File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(TramaXmlSinFirma));
            RutaCertificado = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\"+ empresa.Certificado;

            Nomenclatrura_firma(RutaArchivo, RutaCertificado,nc.CodTipoDocumento);
            GeneraPDF_NC(Convert.ToInt32(nc.CodNotaCreditoNueva));

            string mirutadearchivo = "";
            repo.Tipodoc = nc.CodTipoDocumento;
            repo.Nombredoc = nombreArchivo;
            repo.Fechaemision =nc.FechaPago;
            repo.Serie = nc.Serie;
            repo.Correlativo = nc.NumFac;
            repo.Monto = Convert.ToDecimal(nc.Total);
            if (respuesta_aux.CodigoRespuesta == null) { repo.Estadosunat = "-1"; } else { repo.Estadosunat = respuesta_aux.CodigoRespuesta; }
            if (respuesta_aux.MensajeRespuesta == null) { repo.Mensajesunat = "No enviada"; } else { repo.Mensajesunat = respuesta_aux.MensajeRespuesta; }
            mirutadearchivo = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\NOTAS CREDITO\\" + nombreArchivo + ".xml";        
            repo.Xml = File.ReadAllBytes(mirutadearchivo);
            repo.Pdf = File.ReadAllBytes(mirutadearchivo.Replace(".xml", ".pdf"));
            repo.Usuario = frmLogin.iCodUser;

            if (!clsadmrepo.registra_repositorio(repo))
            {
                MessageBox.Show("Documento no se pudo enviar al repositorio");
            }
        }

        public void GeneraXML_ND(clsCliente cli, clsNotaDebito nd, List<clsDetalleNotaDebito> detalle_nd)
        {
            empresa = admemp.CargaEmpresa3(frmLogin.iCodEmpresa);
            documento = new DocumentoElectronico();

            doc = admdoc.CargaTipoDocumento(nd.CodTipoDocumento);
            transas = admtransas.MuestraTransaccion(nd.CodTipoTransaccion);

            clsFacturaVenta venta = new clsFacturaVenta();
            venta = admfac.CargaFacturaVenta(nd.CodReferencia);

            if (cli.RucDni.Length == 11) { documento.Receptor.TipoDocumento = "6"; documento.Receptor.NroDocumento = cli.RucDni;}
            else if (cli.RucDni.Length == 8) { documento.Receptor.TipoDocumento = "1"; documento.Receptor.NroDocumento = cli.RucDni; }
            //else if (cli.Carnetext.Length == 12) { documento.Receptor.TipoDocumento = "4"; documento.Receptor.NroDocumento = cli.RucDni; }

            this.Datos_Documento(documento, cli, venta);

            this.GeneraDiscrepancia_DocumentoRelacionado_NC_ND(venta, documento, null, nd);

            Int32 contador = 1;
            foreach (clsDetalleNotaDebito lista in detalle_nd)
            {
                det = new DetalleDocumento();

                det.Id = contador;//lista.CodProducto;
                det.Cantidad = Convert.ToDecimal(lista.Cantidad);
                det.Descripcion = lista.DescripcionND;
                det.CodigoItem = contador.ToString();
                det.PrecioUnitario = Convert.ToDecimal(lista.PrecioUnitario);
                det.PrecioReferencial = Convert.ToDecimal(lista.PrecioUnitario);
                det.Impuesto = Convert.ToDecimal(lista.Igv);
                det.TotalVenta = Convert.ToDecimal(lista.Subtotal) - Convert.ToDecimal(lista.Igv);
                det.TipoImpuesto = lista.Tipoimpuesto;
                if (lista.CodProducto > 0)
                {
                    prod = admprod.CargaProducto(lista.CodProducto, frmLogin.iCodAlmacen);
                }
                if (prod.CodTipoArticulo == 2)
                {
                    documento.MontoDetraccion = Convert.ToDecimal(Convert.ToDouble(documento.Gravadas) * 0.04);
                }

                documento.Items.Add(det);
                contador++;
            }

            this.Valida_Datos_NC_ND(venta, doc, documento, null, nd);

            RutaArchivo = Path.Combine(@"C:\DOCUMENTOS-" + empresa.Ruc, documento.IdDocumento + ".xml");
            File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(TramaXmlSinFirma));

            RutaCertificado = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\"+ empresa.Certificado;

            Nomenclatrura_firma(RutaArchivo, RutaCertificado,nd.CodTipoDocumento);
            GeneraPDF_ND(Convert.ToInt32(nd.CodNotaDebitoNueva));

            string mirutadearchivo = "";
            repo.Tipodoc = nd.CodTipoDocumento;
            repo.Nombredoc = nombreArchivo;
            repo.Fechaemision = nd.FechaRegistro;
            repo.Serie = nd.Serie;
            repo.Correlativo = nd.NumFac;
            repo.Monto = Convert.ToDecimal(nd.Total);
            if (respuesta_aux.CodigoRespuesta == null) { repo.Estadosunat = "-1"; } else { repo.Estadosunat = respuesta_aux.CodigoRespuesta; }
            if (respuesta_aux.MensajeRespuesta == null) { repo.Mensajesunat = "No enviada"; } else { repo.Mensajesunat = respuesta_aux.MensajeRespuesta; }
            mirutadearchivo = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\NOTAS DEBITO\\" + nombreArchivo + ".xml";
            repo.Xml = File.ReadAllBytes(mirutadearchivo);
            repo.Pdf = File.ReadAllBytes(mirutadearchivo.Replace(".xml", ".pdf"));
            repo.Usuario = frmLogin.iCodUser;

            if (!clsadmrepo.registra_repositorio(repo))
            {
                MessageBox.Show("Documento no se pudo enviar al repositorio");
            }
        }

        public void GeneraXML_RA(List<clsFacturaVenta> listaFacturas)
        {
            empresa = admemp.CargaEmpresa(frmLogin.iCodEmpresa);
            baja = new ComunicacionBaja();
            doc = admdoc.CargaTipoDocumento(27);

            //Datos del Emisor
            baja.FechaEmision = DateTime.Today.ToShortDateString();
            baja.Emisor.NombreLegal = empresa.RazonSocial; //"SGE SYSTEM SAC";
            baja.Emisor.Ubigeo = "200601";//No sé que va aquí :v
            baja.Emisor.Direccion = empresa.Direccion;
            baja.Emisor.Urbanizacion = "PIURA";
            baja.Emisor.Departamento = "PIURA";
            baja.Emisor.Provincia = "PIURA";
            baja.Emisor.Distrito = "SULLANA";
            baja.Emisor.NroDocumento = empresa.Ruc;
            baja.Emisor.TipoDocumento = "6";//verificar los tipos de documentos RUC-DNI

            Int32 contador = 1;
            foreach (clsFacturaVenta lista in listaFacturas)
            {
                mel = new DocumentoBaja();
                mel.Correlativo = lista.NumDoc;
                mel.MotivoBaja = "Anulacion por error del Sistema";//lista.Motivo;
                mel.Id = contador;
                var doc1 = admdoc.CargaTipoDocumento(lista.CodTipoDocumento);

                if (doc1.Tipodoccodsunat == "01")
                {
                    mel.Serie = "F" + lista.Serie;                    
                }
                else if (doc1.Tipodoccodsunat == "03")
                {
                    mel.Serie = "B" + lista.Serie;
                }
                mel.TipoDocumento = doc1.Tipodoccodsunat;
                contador++;
                baja.Bajas.Add(mel);
            }

            if (doc.Tipodoccodsunat == "RA")
            {
                baja.IdDocumento = doc.Tipodoccodsunat + "-" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "-0001";//.PadLeft(8, '0'); //Verificar el tipo de documento
                baja.FechaReferencia = DateTime.Today.ToShortDateString();
                var voidedDocument = GeneradorXML.GenerarVoidedDocuments(baja);
                ser = new Serializador();
                TramaXmlSinFirma = ser.GenerarXml(voidedDocument);

                RutaArchivo = Path.Combine(@"C:\DOCUMENTOS-" + empresa.Ruc, baja.IdDocumento + ".xml");

                File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(TramaXmlSinFirma));

                RutaCertificado = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\"+ empresa.Certificado;

                Nomenclatrura_firma(RutaArchivo, RutaCertificado,doc.CodTipoDocumento);
            }
        }

        public void GeneraXML_RC(List<clsFacturaVenta> lta, DateTime fechaBoleta)
        {
            empresa = admemp.CargaEmpresa3(frmLogin.iCodEmpresa);
            resumen = new ResumenDiario();

            doc = admdoc.CargaTipoDocumento(26);

            //Datos del Emisor
            resumen.FechaEmision = DateTime.Today.ToShortDateString();
            resumen.FechaReferencia = DateTime.Today.ToShortDateString();
            resumen.Emisor.NombreLegal = empresa.RazonSocial; //"SGE SYSTEM SAC";
            resumen.Emisor.Ubigeo = "200601";//No sé que va aquí :v
            resumen.Emisor.Direccion = empresa.Direccion;
            resumen.Emisor.Urbanizacion = "PIURA";
            resumen.Emisor.Departamento = "PIURA";
            resumen.Emisor.Provincia = "PIURA";
            resumen.Emisor.Distrito = "SULLANA";
            resumen.Emisor.NroDocumento = empresa.Ruc;
            resumen.Emisor.TipoDocumento = "6";//verificar los tipos de documentos RUC-DNI


            Int32 contador = 1;
            mel2.Id = contador;
            foreach (clsFacturaVenta lista in lta)
            {
                Int32 cantidad = lta.Count;

                var doc1 = admdoc.CargaTipoDocumento(lista.CodTipoDocumento);
                mel2.TipoDocumento = doc1.Tipodoccodsunat;
                if (doc1.Tipodoccodsunat == "03")
                {
                    mel2.Serie = "B" + lista.Serie;                    
                }
                else if (doc1.Tipodoccodsunat == "01")
                {
                    mel2.Serie = "F" + lista.Serie;
                }
                if (contador == 1)
                {
                    mel2.CorrelativoInicio = Convert.ToInt32(lista.NumDoc);
                }
                if (cantidad == contador)
                {
                    mel2.CorrelativoFin = Convert.ToInt32(lista.NumDoc);
                }
                if (lista.Moneda == 1) { mel2.Moneda = "PEN"; } else { mel2.Moneda = "USD"; }
                mel2.TotalVenta = mel2.TotalVenta + Convert.ToDecimal(lista.Total);
                mel2.TotalDescuentos = mel2.TotalDescuentos + Convert.ToDecimal(lista.MontoDscto);
                mel2.TotalIgv = mel2.TotalIgv + Convert.ToDecimal(lista.Igv);
                mel2.TotalIsc = 0;
                mel2.TotalOtrosImpuestos = 0;
                mel2.Gravadas = mel2.Gravadas + lista.Gravadas;
                mel2.Exoneradas = mel2.Exoneradas + lista.Exoneradas;
                mel2.Inafectas = mel2.Inafectas + lista.Inafectas;
                mel2.Exportacion = 0;
                mel2.Gratuitas = mel2.Gratuitas + lista.Gratuitas;

                contador++;
            }

            resumen.FechaReferencia = fechaBoleta.ToString();
            resumen.Resumenes.Add(mel2);
            resumen.IdDocumento = "RC-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "-1";

            var voidedDocument = GeneradorXML.GenerarSummaryDocuments(resumen);
            var serializador = new Serializador();
            TramaXmlSinFirma = serializador.GenerarXml(voidedDocument);

            RutaArchivo = Path.Combine(@"C:\DOCUMENTOS-" + empresa.Ruc, resumen.IdDocumento + ".xml");

            File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(TramaXmlSinFirma));

            RutaCertificado = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\"+ empresa.Certificado;

            Nomenclatrura_firma(RutaArchivo, RutaCertificado, doc.CodTipoDocumento);
        }

        public void Nomenclatrura_firma(String ruta, String rutacertifik, Int32 TipoDocumento)
        {
            try
            {

                //Una sola ruta para el certificado 
                if (empresa == null)
                {
                    empresa = admemp.CargaEmpresa3(frmLogin.iCodEmpresa);
                }
                rutacertifik = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\" + empresa.Certificado;
                if (VerificaChek)
                {
                    //nombreArchivo = resumen.Emisor.NroDocumento + "-" + resumen.IdDocumento;
                }
                else if (VerificaChek == false)
                {
                    nombreArchivo = documento.Emisor.NroDocumento + "-" + documento.TipoDocumento + "-" + documento.IdDocumento;
                }                


                var tramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(ruta));

                var firmadoRequest = new FirmadoRequest
                {
                    TramaXmlSinFirma = tramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(rutacertifik)),
                    PasswordCertificado = empresa.Contrasena,
                    UnSoloNodoExtension = true //rbRetenciones.Checked || rbResumen.Checked 

                };


                FirmarController enviar = new FirmarController();
                var respuestaFirmado = enviar.FirmadoResponse(firmadoRequest, TipoDocumento);
                if (!respuestaFirmado.Exito)
                    throw new ApplicationException(respuestaFirmado.MensajeError);

                resumenfirmadig = respuestaFirmado.ResumenFirma;
                firmadig = respuestaFirmado.ValorFirma;

                var enviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = empresa.Ruc,
                    UsuarioSol = empresa.UsuarioSunat, 
                    ClaveSol = empresa.ClaveSunat,
                    //EndPointUrl = "https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService",      
                    EndPointUrl = empresa.url, //"https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService",
                    IdDocumento = documento.IdDocumento,
                    TipoDocumento = documento.TipoDocumento,
                    TramaXmlFirmado = respuestaFirmado.TramaXmlFirmado
                };

                //Esto se puede mejorar            
                var respuestaEnvio = new EnviarDocumentoResponse();

                if (VerificaChek == false)
                {

                    EnviarDocumentoController enviarDoc = new EnviarDocumentoController();
                    respuestaEnvio = enviarDoc.EnviarDocumentoResponse(enviarDocumentoRequest);

                    var rpta = (EnviarDocumentoResponse)respuestaEnvio;
                    respuesta_aux = (EnviarDocumentoResponse)respuestaEnvio;

                    MessageBox.Show("Mensaje: " + rpta.MensajeRespuesta + " Siendo las " + DateTime.Now);
                    try
                    {
                        File.WriteAllBytes(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\" + nombreArchivo + ".xml",
                               Convert.FromBase64String(respuestaFirmado.TramaXmlFirmado));

                        if (rpta.Exito && rpta.TramaZipCdr != null)
                        {
                           
                            File.WriteAllBytes(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\CDR\\" + "R-" + nombreArchivo + ".zip",
                                Convert.FromBase64String(rpta.TramaZipCdr));
                            VerificaChek = false;
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else {
                    try { 
                         
                        EnviarResumenController enviaResumen = new EnviarResumenController();
                        respuestaEnvio = enviaResumen.EnviarResumenResponse(enviarDocumentoRequest);
                                      
                        var rpta = (EnviarDocumentoResponse)respuestaEnvio;
                        MessageBox.Show("Guardar N° Ticket a Consultar: " + rpta.NroTicket);                       
                        RptaDocumentos = rpta.NroTicket;
                       
                        var valido=(RespuestaComun)respuestaEnvio;
                        if (valido.Exito) //Comunicación de baja
                        {
                            if (baja != null)
                            {
                                if (baja.Bajas.Count > 0)
                                {

                                    foreach (var cadena in baja.Bajas)
                                    {
                                        Boolean actualiza = AdmVenta.anular(Convert.ToInt32(cadena.IDFactura));
                                        if (!actualiza)
                                        {
                                            MessageBox.Show("Ocurió un error al actualizar estado de factura", "Facturación Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                }
                            }
                        }
                        if (valido.Exito) { //Resumen de Boletas
                            if (resumen != null)
                            {
                                if (resumen.Resumenes.Count > 0)
                                {
                                    foreach (var cadena in resumen.Resumenes)
                                    {
                                        Boolean actualiza = AdmVenta.ActualizaBoletaSunat(Convert.ToInt32(cadena.IDFactura));
                                        if (!actualiza)
                                        {
                                            MessageBox.Show("Ocurió un error al actualizar estado de documento", "Facturación Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception a) { MessageBox.Show(a.Message); }
                
                }
                                

                String firmaxml = respuestaFirmado.TramaXmlFirmado;
                firmadig = respuestaFirmado.ValorFirma;

                if (baja != null)
                {
                    File.WriteAllBytes(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\" + nombreArchivo + ".xml", Convert.FromBase64String(firmaxml));
                }
                else if (resumen != null)
                {
                    File.WriteAllBytes(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\" + nombreArchivo + ".xml", Convert.FromBase64String(firmaxml));
                }
                else
                {
                    switch (documento.TipoDocumento)
                    {
                        case "01": //facturas
                            File.WriteAllBytes(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\FACTURAS\\" + nombreArchivo + ".xml", Convert.FromBase64String(firmaxml));
                            break;

                        case "03": //boletas
                            File.WriteAllBytes(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\BOLETAS\\" + nombreArchivo + ".xml", Convert.FromBase64String(firmaxml));
                            break;

                        case "07": //notas de credito               
                            File.WriteAllBytes(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\NOTAS CREDITO\\" + nombreArchivo + ".xml", Convert.FromBase64String(firmaxml));
                            break;

                        case "08": //notas de debito
                            File.WriteAllBytes(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\NOTAS DEBITO\\" + nombreArchivo + ".xml", Convert.FromBase64String(firmaxml));
                            break;
                    }
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
      
        }

        public FirmadoResponse TraerFirma(FirmadoRequest request)
        {
            var response = new FirmadoResponse();
            try
            {
                ser = new Serializador();

                ser.RutaCertificadoDigital = request.CertificadoDigital;
                ser.PasswordCertificado = request.PasswordCertificado;
                //ser.TipoDocumento = request.UnSoloNodoExtension ? 0 : 1;

                response.TramaXmlFirmado = ser.FirmarXml(request.TramaXmlSinFirma,Convert.ToInt32(documento.TipoDocumento)); //, doc.Tipodoccodsunat
                response.ResumenFirma = ser.DigestValue;
                response.ValorFirma = ser.ValorFirma;
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

        public EnviarDocumentoResponse EscribirFirmaXml(Tuple<String, Boolean> resultado)
        {
            var response = new EnviarDocumentoResponse();
            if (resultado.Item2)
            {
                var returnByte = Convert.FromBase64String(resultado.Item1);
                using (var memRespuesta = new MemoryStream(returnByte))
                {
                    using (var zipFile = ZipFile.Read(memRespuesta))
                    {
                        foreach (var entry in zipFile.Entries)
                        {
                            if (!entry.FileName.EndsWith(".xml")) continue;
                            using (var ms = new MemoryStream())
                            {
                                entry.Extract(ms);
                                ms.Position = 0;
                                var responseReader = new StreamReader(ms);
                                var responseString = responseReader.ReadToEnd();
                                try
                                {
                                    var xmlDoc = new XmlDocument();
                                    xmlDoc.LoadXml(responseString);

                                    var xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);

                                    xmlnsManager.AddNamespace("ar", EspacioNombres.ar);
                                    xmlnsManager.AddNamespace("cac", EspacioNombres.cac);
                                    xmlnsManager.AddNamespace("cbc", EspacioNombres.cbc);

                                    response.CodigoRespuesta = xmlDoc.SelectSingleNode(EspacioNombres.nodoResponseCode, xmlnsManager).InnerText;

                                    response.MensajeRespuesta = xmlDoc.SelectSingleNode(EspacioNombres.nodoDescription, xmlnsManager).InnerText;
                                    response.TramaZipCdr = resultado.Item1;
                                    response.Exito = true;

                                }
                                catch (Exception ex)
                                {
                                    response.MensajeError = ex.Message;
                                    response.Pila = ex.StackTrace;
                                    response.Exito = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                response.Exito = true;
                response.MensajeRespuesta = resultado.Item1;
            }
            return response;
        }

        public void  GeneraPDF(Int32 codigo)
        {
            DataSet jes = new DataSet();
            DataSet abi = new DataSet();
            String RutaArch = "";
            if (documento.TipoDocumento == "01")
            {
                RutaArch = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\FACTURAS\\" + nombreArchivo + ".xml";
            }
            else
            {
                RutaArch = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\BOLETAS\\" + nombreArchivo + ".xml";
            }

            String[] cad = documento.IdDocumento.Split('-');
            String[] fecha = documento.FechaEmision.Split('/');

            datosAdicionales_CDB = documento.Emisor.NroDocumento + "|" + documento.TipoDocumento + "|" + cad[0].ToString() + "|" + cad[1].ToString() + "|"
                                   + documento.TotalIgv + "|" + documento.TotalVenta + "|" + fecha[2] + "-" + fecha[1] + "-" + fecha[0] + "|"
                                   + documento.Receptor.TipoDocumento + "|" + documento.Receptor.NroDocumento;

            CodigoCertificado = datosAdicionales_CDB + "|" + resumenfirmadig + "|" + firmadig;

            BarcodePDF417 codigobarras = new BarcodePDF417();
            codigobarras.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO;
            codigobarras.ErrorLevel = 5;
            codigobarras.YHeight = 6f;
            codigobarras.SetText(CodigoCertificado);
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(codigobarras.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            bm.Save(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\QR\\" + nombreArchivo + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            LogoEmp = CargarImagen(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\QR\\" + nombreArchivo + ".jpeg");

            frmRptFactura form = new frmRptFactura();
            CRReporteFactura rpt = new CRReporteFactura();
            rpt.Load("CRReporteFactura.rpt");

            jes = ds.ReporteFactura2(Convert.ToInt32(codigo));

            foreach (DataTable mel in jes.Tables)
            {
                foreach (DataRow changesRow in mel.Rows)
                {
                    changesRow["firma"] = LogoEmp;
                }
                if (mel.HasErrors)
                {
                    foreach (DataRow changesRow in mel.Rows)
                    {
                        if ((int)changesRow["Item", DataRowVersion.Current] > 100)
                        {
                            changesRow.RejectChanges();
                            changesRow.ClearErrors();
                        }
                    }
                }
            }
            rpt.SetDataSource(jes);
            form.crvReporteFactura.ReportSource = rpt;
            form.ShowDialog();
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, RutaArch.Replace(".xml", ".pdf"));

            rpt.Close();
            rpt.Dispose();
        }

        public void GeneraPDF_NC(Int32 codigo)
        {
            DataSet jes = new DataSet();
            DataSet abi = new DataSet();
            String RutaArch = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\NOTAS CREDITO\\" + nombreArchivo + ".xml";

            String[] cad = documento.IdDocumento.Split('-');
            String[] fecha = documento.FechaEmision.Split('/');

            datosAdicionales_CDB = documento.Emisor.NroDocumento + "|" + documento.TipoDocumento + "|" + cad[0].ToString() + "|" + cad[1].ToString() + "|"
                                   + documento.TotalIgv + "|" + documento.TotalVenta + "|" + fecha[2] + "-" + fecha[1] + "-" + fecha[0] + "|"
                                   + documento.Receptor.TipoDocumento + "|" + documento.Receptor.NroDocumento;

            CodigoCertificado = datosAdicionales_CDB + "|" + resumenfirmadig + "|" + firmadig;
            
            BarcodePDF417 codigobarras = new BarcodePDF417();
            codigobarras.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO;
            codigobarras.ErrorLevel = 5;
            codigobarras.YHeight = 6f;
            codigobarras.SetText(CodigoCertificado);
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(codigobarras.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            bm.Save(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\QR\\" + nombreArchivo + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            LogoEmp = CargarImagen(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\QR\\" + nombreArchivo + ".jpeg");

            frmRptNotaCredito form = new frmRptNotaCredito();
            CRNotaCreditoVenta rpt = new CRNotaCreditoVenta();
            rpt.Load("CRNotaCreditoVenta.rpt");

            jes = ds1.ReportNotaCreditoVenta(Convert.ToInt32(codigo), frmLogin.iCodAlmacen);

            foreach (DataTable mel in jes.Tables)
            {
                foreach (DataRow changesRow in mel.Rows)
                {
                    changesRow["firma"] = LogoEmp;
                }
                if (mel.HasErrors)
                {
                    foreach (DataRow changesRow in mel.Rows)
                    {
                        if ((int)changesRow["Item", DataRowVersion.Current] > 100)
                        {
                            changesRow.RejectChanges();
                            changesRow.ClearErrors();
                        }
                    }
                }
            }
            rpt.SetDataSource(jes);
            form.crvNotaCredito.ReportSource = rpt;
            form.ShowDialog();
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, RutaArch.Replace(".xml", ".pdf"));

            rpt.Close();
            rpt.Dispose();
        }

        private void GeneraPDF_ND(Int32 codigo)
        {
            DataSet jes = new DataSet();
            DataSet abi = new DataSet();
            String RutaArch = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\DOCUMENTOS ENVIAR\\NOTAS DEBITO\\" + nombreArchivo + ".xml";

            String[] cad = documento.IdDocumento.Split('-');
            String[] fecha = documento.FechaEmision.Split('/');

            datosAdicionales_CDB = documento.Emisor.NroDocumento + "|" + documento.TipoDocumento + "|" + cad[0].ToString() + "|" + cad[1].ToString() + "|"
                                   + documento.TotalIgv + "|" + documento.TotalVenta + "|" + fecha[2] + "-" + fecha[1] + "-" + fecha[0] + "|"
                                   + documento.Receptor.TipoDocumento + "|" + documento.Receptor.NroDocumento;

            CodigoCertificado = datosAdicionales_CDB + "|" + resumenfirmadig + "|" + firmadig;

            BarcodePDF417 codigobarras = new BarcodePDF417();
            codigobarras.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO;
            codigobarras.ErrorLevel = 5;
            codigobarras.YHeight = 6f;
            codigobarras.SetText(CodigoCertificado);
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(codigobarras.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            bm.Save(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\QR\\" + nombreArchivo + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            LogoEmp = CargarImagen(@"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\QR\\" + nombreArchivo + ".jpeg");

            frmRptNotaDebito form = new frmRptNotaDebito();
            CRNotaDebitoVenta rpt = new CRNotaDebitoVenta();
            rpt.Load("CRNotaDebitoVenta.rpt");

            jes = ds1.ReportNotaDebitoVenta(Convert.ToInt32(codigo), frmLogin.iCodAlmacen);

            foreach (DataTable mel in jes.Tables)
            {
                foreach (DataRow changesRow in mel.Rows)
                {
                    changesRow["firma"] = LogoEmp;
                }

                if (mel.HasErrors)
                {
                    foreach (DataRow changesRow in mel.Rows)
                    {
                        if ((int)changesRow["Item", DataRowVersion.Current] > 100)
                        {
                            changesRow.RejectChanges();
                            changesRow.ClearErrors();
                        }
                    }
                }
            }
            rpt.SetDataSource(jes);
            form.crvNotaDebito.ReportSource = rpt;
            form.ShowDialog();
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, RutaArch.Replace(".xml", ".pdf"));

            rpt.Close();
            rpt.Dispose();
        }

        public static Byte[] CargarImagen(string rutaArchivo)
        {
            if (rutaArchivo != "")
            {
                try
                {
                    FileStream Archivo = new FileStream(rutaArchivo, FileMode.Open);//Creo el archivo
                    BinaryReader binRead = new BinaryReader(Archivo);//Cargo el Archivo en modo binario
                    Byte[] imagenEnBytes = new Byte[(Int64)Archivo.Length]; //Creo un Array de Bytes donde guardare la imagen
                    binRead.Read(imagenEnBytes, 0, (int)Archivo.Length);//Cargo la imagen en el array de Bytes
                    binRead.Close();
                    Archivo.Close();
                    return imagenEnBytes;//Devuelvo la imagen convertida en un array de bytes
                }
                catch
                {
                    return new Byte[0];
                }
            }
            return new byte[0];
        }



    }
}
