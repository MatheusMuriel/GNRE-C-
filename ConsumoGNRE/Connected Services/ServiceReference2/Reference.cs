﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumoGNRE.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.gnre.pe.gov.br/webservice/GnreConfigUF", ConfigurationName="ServiceReference2.GnreConfigUFSoap")]
    public interface GnreConfigUFSoap {
        
        // CODEGEN: Generating message contract since the operation consultar is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.gnre.pe.gov.br/webservice/GnreConfigUF/consultar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ConsumoGNRE.ServiceReference2.consultarResponse consultar(ConsumoGNRE.ServiceReference2.consultarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.gnre.pe.gov.br/webservice/GnreConfigUF/consultar", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsumoGNRE.ServiceReference2.consultarResponse> consultarAsync(ConsumoGNRE.ServiceReference2.consultarRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.gnre.pe.gov.br/webservice/GnreConfigUF")]
    public partial class gnreCabecMsg : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string versaoDadosField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string versaoDados {
            get {
                return this.versaoDadosField;
            }
            set {
                this.versaoDadosField = value;
                this.RaisePropertyChanged("versaoDados");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class consultarRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.gnre.pe.gov.br/webservice/GnreConfigUF")]
        public ConsumoGNRE.ServiceReference2.gnreCabecMsg gnreCabecMsg;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.gnre.pe.gov.br/webservice/GnreConfigUF", Order=0)]
        public System.Xml.XmlNode gnreDadosMsg;
        
        public consultarRequest() {
        }
        
        public consultarRequest(ConsumoGNRE.ServiceReference2.gnreCabecMsg gnreCabecMsg, System.Xml.XmlNode gnreDadosMsg) {
            this.gnreCabecMsg = gnreCabecMsg;
            this.gnreDadosMsg = gnreDadosMsg;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class consultarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.gnre.pe.gov.br/webservice/GnreConfigUF", Order=0)]
        public System.Xml.XmlNode gnreRespostaMsg;
        
        public consultarResponse() {
        }
        
        public consultarResponse(System.Xml.XmlNode gnreRespostaMsg) {
            this.gnreRespostaMsg = gnreRespostaMsg;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GnreConfigUFSoapChannel : ConsumoGNRE.ServiceReference2.GnreConfigUFSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GnreConfigUFSoapClient : System.ServiceModel.ClientBase<ConsumoGNRE.ServiceReference2.GnreConfigUFSoap>, ConsumoGNRE.ServiceReference2.GnreConfigUFSoap {
        
        public GnreConfigUFSoapClient() {
        }
        
        public GnreConfigUFSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GnreConfigUFSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GnreConfigUFSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GnreConfigUFSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsumoGNRE.ServiceReference2.consultarResponse ConsumoGNRE.ServiceReference2.GnreConfigUFSoap.consultar(ConsumoGNRE.ServiceReference2.consultarRequest request) {
            return base.Channel.consultar(request);
        }
        
        public System.Xml.XmlNode consultar(ConsumoGNRE.ServiceReference2.gnreCabecMsg gnreCabecMsg, System.Xml.XmlNode gnreDadosMsg) {
            ConsumoGNRE.ServiceReference2.consultarRequest inValue = new ConsumoGNRE.ServiceReference2.consultarRequest();
            inValue.gnreCabecMsg = gnreCabecMsg;
            inValue.gnreDadosMsg = gnreDadosMsg;
            ConsumoGNRE.ServiceReference2.consultarResponse retVal = ((ConsumoGNRE.ServiceReference2.GnreConfigUFSoap)(this)).consultar(inValue);
            return retVal.gnreRespostaMsg;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsumoGNRE.ServiceReference2.consultarResponse> ConsumoGNRE.ServiceReference2.GnreConfigUFSoap.consultarAsync(ConsumoGNRE.ServiceReference2.consultarRequest request) {
            return base.Channel.consultarAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsumoGNRE.ServiceReference2.consultarResponse> consultarAsync(ConsumoGNRE.ServiceReference2.gnreCabecMsg gnreCabecMsg, System.Xml.XmlNode gnreDadosMsg) {
            ConsumoGNRE.ServiceReference2.consultarRequest inValue = new ConsumoGNRE.ServiceReference2.consultarRequest();
            inValue.gnreCabecMsg = gnreCabecMsg;
            inValue.gnreDadosMsg = gnreDadosMsg;
            return ((ConsumoGNRE.ServiceReference2.GnreConfigUFSoap)(this)).consultarAsync(inValue);
        }
    }
}
