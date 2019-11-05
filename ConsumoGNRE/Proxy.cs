﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;


namespace ConsumoGNRE.Proxy
{
    public class Proxy
    {

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Web.Services.WebServiceBindingAttribute(Name = "GnreConfigUF", Namespace = "http://www.gnre.pe.gov.br/webservice/GnreConfigUF")]
        public partial class GnreConfigUF : System.Web.Services.Protocols.SoapHttpClientProtocol
        {

            private gnreCabecMsg gnreCabecMsgValueField;

            private System.Threading.SendOrPostCallback consultarOperationCompleted;

            /// <remarks/>
            public GnreConfigUF()
            {
                this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                this.Url = "https://www.testegnre.pe.gov.br/gnreWS/services/GnreConfigUF";
            }

            public gnreCabecMsg gnreCabecMsgValue
            {
                get
                {
                    return this.gnreCabecMsgValueField;
                }
                set
                {
                    this.gnreCabecMsgValueField = value;
                }
            }

            /// <remarks/>
            public event consultarCompletedEventHandler consultarCompleted;

            /// <remarks/>
            [System.Web.Services.Protocols.SoapHeaderAttribute("gnreCabecMsgValue")]
            [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.gnre.pe.gov.br/webservice/GnreConfigUF/consultar", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
            [return: System.Xml.Serialization.XmlElementAttribute("gnreRespostaMsg", Namespace = "http://www.gnre.pe.gov.br/webservice/GnreConfigUF")]
            public System.Xml.XmlNode consultar([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.gnre.pe.gov.br/webservice/GnreConfigUF")] System.Xml.XmlNode gnreDadosMsg)
            {
                try
                {
                    object[] results = this.Invoke("consultar", new object[] {
                    gnreDadosMsg});
                    return ((System.Xml.XmlNode)(results[0]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                    System.Xml.XmlNode rootNode = xDoc.CreateElement("Error");
                    rootNode.InnerText = e.ToString();
                    xDoc.AppendChild(rootNode);

                    System.Xml.XmlNode xNode = xDoc;
                    return xNode;
                }
            }

            /// <remarks/>
            public System.IAsyncResult Beginconsultar(System.Xml.XmlNode gnreDadosMsg, System.AsyncCallback callback, object asyncState)
            {
                return this.BeginInvoke("consultar", new object[] {
                    gnreDadosMsg}, callback, asyncState);
            }

            /// <remarks/>
            public System.Xml.XmlNode Endconsultar(System.IAsyncResult asyncResult)
            {
                object[] results = this.EndInvoke(asyncResult);
                return ((System.Xml.XmlNode)(results[0]));
            }

            /// <remarks/>
            public void consultarAsync(System.Xml.XmlNode gnreDadosMsg)
            {
                this.consultarAsync(gnreDadosMsg, null);
            }

            /// <remarks/>
            public void consultarAsync(System.Xml.XmlNode gnreDadosMsg, object userState)
            {
                if ((this.consultarOperationCompleted == null))
                {
                    this.consultarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnconsultarOperationCompleted);
                }
                this.InvokeAsync("consultar", new object[] {
                    gnreDadosMsg}, this.consultarOperationCompleted, userState);
            }

            private void OnconsultarOperationCompleted(object arg)
            {
                if ((this.consultarCompleted != null))
                {
                    System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                    this.consultarCompleted(this, new consultarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
                }
            }

            /// <remarks/>
            public new void CancelAsync(object userState)
            {
                base.CancelAsync(userState);
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br/webservice/GnreConfigUF")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.gnre.pe.gov.br/webservice/GnreConfigUF", IsNullable = false)]
        public partial class gnreCabecMsg : System.Web.Services.Protocols.SoapHeader
        {

            private string versaoDadosField;

            /// <remarks/>
            public string versaoDados
            {
                get
                {
                    return this.versaoDadosField;
                }
                set
                {
                    this.versaoDadosField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
        public delegate void consultarCompletedEventHandler(object sender, consultarCompletedEventArgs e);

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class consultarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal consultarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public System.Xml.XmlNode Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((System.Xml.XmlNode)(this.results[0]));
                }
            }
        }
    }
}