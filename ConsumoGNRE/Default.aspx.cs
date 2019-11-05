using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using ConsumoGNRE.Proxy;



namespace ConsumoGNRE
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Literal1.Text = enviarRequisicao();

            //Instanciando web service
            //ServiceReference3.GnreConfigUFSoapClient ws = new ServiceReference3.GnreConfigUFSoapClient();
            Proxy.Proxy.GnreConfigUF ws = new Proxy.Proxy.GnreConfigUF();

            X509Certificate2 cert = new X509Certificate2(@"e:\certificados\95386827000191_20191009091349.pfx", "1234");
            //ws.ClientCredentials.ClientCertificate.Certificate = cert;
            ws.ClientCertificates.Add(cert);

            // HEAD //
            //ServiceReference3.gnreCabecMsg head = new ServiceReference3.gnreCabecMsg();
            Proxy.Proxy.gnreCabecMsg head = new Proxy.Proxy.gnreCabecMsg();
            head.versaoDados = "1.00";
            ws.gnreCabecMsgValue = head;
            // HEAD //


            // BODY //
            XDocument xmlDados = XDocument.Parse(@"<TConsultaConfigUf xmlns=""http://www.gnre.pe.gov.br""><ambiente>2</ambiente><uf>AC</uf><receita courier=""N"">100048</receita></TConsultaConfigUf>");

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlDados.CreateReader());

            XmlNode dados = xDoc;
            // BODY 

            // Fazendo a chamada
            //XmlNode result = ws.consultar(head, dados);
            XmlNode result = ws.consultar(dados);

            XDocument resultXDoc = XDocument.Parse(result.OuterXml);
            
            Literal1.Text = DateTime.Now.ToString("h:mm:ss") + "           ::           " + resultXDoc.ToString();

            Console.WriteLine("Fim");

        }

        private static string enviarRequisicao()
        {
            try
            {
                
                X509Certificate2 cert = new X509Certificate2(@"C:\Certs\certBase251.pfx", "1234");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                HttpWebRequest request = CreateWebRequest();

                XDocument xmlDados = XDocument.Parse(@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:gnr=""http://www.gnre.pe.gov.br/webservice/GnreConfigUF""><soap:Header><gnr:gnreCabecMsg><gnr:versaoDados>2.00</gnr:versaoDados></gnr:gnreCabecMsg></soap:Header><soap:Body><gnr:gnreDadosMsg><TConsultaConfigUf xmlns=""http://www.gnre.pe.gov.br""><ambiente>2</ambiente><uf>AC</uf><receita courier=""N"">100048</receita></TConsultaConfigUf></gnr:gnreDadosMsg></soap:Body></soap:Envelope>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlDados.CreateReader());

                InsertSoapEnvelopeIntoWebRequest(xmlDoc, request);
                request.ClientCertificates.Add(cert);

                using (HttpWebResponse resposta = request.GetResponse() as HttpWebResponse)
                {
                    using (var stream = resposta.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();
                            return result;
                        }
                    }
                }
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }
        public static HttpWebRequest CreateWebRequest()
        {
            String url = @"http://www.testegnre.pe.gov.br/gnreWS/services/GnreConfigUF";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add(@"SOAPAction", @"http://www.testegnre.pe.gov.br/gnreWS/services/GnreConfigUF/consultar");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}