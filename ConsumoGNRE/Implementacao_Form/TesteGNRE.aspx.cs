using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml;
using Mafsoft;
using System.Xml.Serialization;
using System.Linq;
using System.Reflection;
using System.ComponentModel.Design;
using System.Globalization;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.IO;

public partial class prj_TesteGNRE :  System.Web.UI.Page
{
    protected clsGeral cls = new clsGeral();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        String RazaosocialEmitente = razaosocialEmitente.Text;
        String UFFavorecida = ufFornecida.SelectedValue;
        String Receita = receita.SelectedValue;
        String DocOrigem = docOrigem.SelectedValue;
        String RefPeriodo = periodo.Text;
        String RefMes = mes.Text;
        String RefAno = ano.Text;
        String ValorPrincipal = valorPrincipal.Text;
        String DataVenc = dataVencimento.Text;
        String Convenio = convenio.Text;
        String TipoDocOrigem = tipoDocOrigem.Text;
        String DataPgto = dataVencimento.Text;
        String ChaveNFE = chaveNFE.Text;

        TLote_GNRE lote = new TLote_GNRE();
        lote.versao = "1.00";

        List<TLote_GNRETDadosGNRE> guias = new List<TLote_GNRETDadosGNRE>();

        TLote_GNRETDadosGNRE nt = new TLote_GNRETDadosGNRE();

        // Valores Não Enumerados
        nt.c02_receita = Receita;
        nt.c04_docOrigem = null;
        nt.c05_referencia = null;
        nt.c06_valorPrincipal = null;
        nt.c10_valorTotal = ValorPrincipal;
        nt.c14_dataVencimento = DataVenc;
        nt.c15_convenio = Convenio;
        nt.c25_detalhamentoReceita = null;
        nt.c26_produto = null;
        nt.c28_tipoDocOrigem = null;
        nt.c33_dataPagamento = null;
        nt.c39_camposExtras = null;
        nt.c42_identificadorGuia = null;

        //Emitente
        nt.c16_razaoSocialEmitente = RazaosocialEmitente;
        nt.c17_inscricaoEstadualEmitente = null;
            nt.c18_enderecoEmitente = null;
            nt.c19_municipioEmitente = null;
            nt.c21_cepEmitente = null;
            nt.c22_telefoneEmitente = null;

        //Destinatario
        nt.c37_razaoSocialDestinatario = null;
        nt.c36_inscricaoEstadualDestinatario = null;
            nt.c38_municipioDestinatario = null;


        //Valores com enum
        nt.c01_UfFavorecida = TUf.AC;

        nt.c35_idContribuinteDestinatario.ItemElementName = ItemChoiceType1.CNPJ;
        nt.c35_idContribuinteDestinatario.Item = null;

        nt.c03_idContribuinteEmitente.ItemElementName = ItemChoiceType.CNPJ;
        nt.c03_idContribuinteEmitente.Item = null;

        nt.c20_ufEnderecoEmitente = TUf.AC;
        nt.c20_ufEnderecoEmitenteSpecified = true;

        nt.c27_tipoIdentificacaoEmitente = TIdentificacao.Item1;
        nt.c27_tipoIdentificacaoEmitenteSpecified = false;

        nt.c34_tipoIdentificacaoDestinatario = TIdentificacao.Item1;
        nt.c34_tipoIdentificacaoDestinatarioSpecified = false;


        guias.Add(nt);

        lote.guias = guias.ToArray();

        XmlSerializer x = new XmlSerializer(typeof(TLote_GNRE));
        XmlWriter xWriter = XmlWriter.Create(@"C:\A_xml_GNRE\Nha.xml");
        x.Serialize(xWriter, lote);
        xWriter.Close();

        XDocument xmlLote = XDocument.Load(@"C:\A_xml_GNRE\Nha.xml");

        XDocument retorno = processaLote(xmlLote);

        Literal1.Text = DateTime.Now.ToString("h:mm:ss") + "           ::           " + retorno.ToString();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //XDocument retorno = processaLote();

        //Literal1.Text = DateTime.Now.ToString("h:mm:ss") + "           ::           " + retorno.ToString();
    }



    protected XDocument processaLote(XDocument xmlDados)
    {
        //Instanciando web service
        GNRERecepcaoLote.GnreLoteRecepcao ws = new GNRERecepcaoLote.GnreLoteRecepcao();

        X509Certificate2 cert = new X509Certificate2(@"e:\certificados\95386827000191_20191009091349.pfx", "1234");
        ws.ClientCertificates.Add(cert);

        // HEAD //
        GNRERecepcaoLote.gnreCabecMsg head = new GNRERecepcaoLote.gnreCabecMsg();
        head.versaoDados = "1.00";
        ws.gnreCabecMsgValue = head;
        // HEAD //


        // BODY //
        //XDocument xmlDados = XDocument.Parse(@"<TLote_GNRE xmlns=""http://www.gnre.pe.gov.br""><guias><TDadosGNRE><c01_UfFavorecida>26</c01_UfFavorecida><c02_receita>1000099</c02_receita><c25_detalhamentoReceita>10101010</c25_detalhamentoReceita><c26_produto>TESTE DE PROD</c26_produto><c27_tipoIdentificacaoEmitente>1</c27_tipoIdentificacaoEmitente><c03_idContribuinteEmitente><CNPJ>41819055000105</CNPJ></c03_idContribuinteEmitente><c28_tipoDocOrigem>10</c28_tipoDocOrigem><c04_docOrigem>5656</c04_docOrigem><c06_valorPrincipal>10.99</c06_valorPrincipal><c10_valorTotal>12.52</c10_valorTotal><c14_dataVencimento>2015-05-01</c14_dataVencimento><c15_convenio>546456</c15_convenio><c16_razaoSocialEmitente>GNRE PHP EMITENTE</c16_razaoSocialEmitente><c17_inscricaoEstadualEmitente>56756</c17_inscricaoEstadualEmitente><c18_enderecoEmitente>Queens St</c18_enderecoEmitente><c19_municipioEmitente>5300108</c19_municipioEmitente><c20_ufEnderecoEmitente>DF</c20_ufEnderecoEmitente><c21_cepEmitente>08215917</c21_cepEmitente><c22_telefoneEmitente>1199999999</c22_telefoneEmitente><c34_tipoIdentificacaoDestinatario>1</c34_tipoIdentificacaoDestinatario><c35_idContribuinteDestinatario><CNPJ>86268158000162</CNPJ></c35_idContribuinteDestinatario><c36_inscricaoEstadualDestinatario>10809181</c36_inscricaoEstadualDestinatario><c37_razaoSocialDestinatario>RAZAO SOCIAL GNRE PHP DESTINATARIO</c37_razaoSocialDestinatario><c38_municipioDestinatario>2702306</c38_municipioDestinatario><c33_dataPagamento>2015-11-30</c33_dataPagamento><c05_referencia><periodo>2014</periodo><mes>05</mes><ano>2015</ano><parcela>2</parcela></c05_referencia><c39_camposExtras><campoExtra><codigo>16</codigo><tipo>T</tipo><valor>1200012</valor></campoExtra><campoExtra><codigo>15</codigo><tipo>D</tipo><valor>2015-03-02</valor></campoExtra><campoExtra><codigo>10</codigo><tipo>T</tipo><valor>17.21</valor></campoExtra></c39_camposExtras></TDadosGNRE></guias></TLote_GNRE>");

        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(xmlDados.CreateReader());

        XmlNode dados = xDoc;
        // BODY 

        // Fazendo a chamada
        XmlNode result = ws.processar(dados);

        XDocument resultXDoc = XDocument.Parse(result.OuterXml);

        return resultXDoc;
    }




    private static XDocument gerarXML(Nota nota)
    {
        XNamespace aw = "http://www.gnre.pe.gov.br";

        Type objType = nota.GetType();
        PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        ArrayList elements = new ArrayList();
        foreach (PropertyInfo property in properties)
        {
            String nomeP = property.Name;
            var valor = property.GetValue(nota, null);

            if (valor != null)
            {
                elements.Add(new XElement(aw + nomeP, valor));
            }
        }


        XElement TDadosGNRE = new XElement(aw + "TDadosGNRE", elements);

        XElement guias = new XElement(aw + "guias", TDadosGNRE);

        XElement TLote_GNRE = new XElement(aw + "TLote_GNRE", guias);

        XDeclaration dec = new XDeclaration("1.0", "utf-8", "yes");

        XDocument doc = new XDocument(dec, TLote_GNRE);

        return (doc);
    }

}

public class GNRERecepcaoLote
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "GnreLoteRecepcao", Namespace = "http://www.gnre.pe.gov.br/webservice/GnreLoteRecepcao")]
    public partial class GnreLoteRecepcao : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        private gnreCabecMsg gnreCabecMsgValueField;
        private System.Threading.SendOrPostCallback processarOperationCompleted;

        public GnreLoteRecepcao()
        {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = "https://www.testegnre.pe.gov.br/gnreWS/services/GnreLoteRecepcao";
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

        public event processarCompletedEventHandler processarCompleted;

        [System.Web.Services.Protocols.SoapHeaderAttribute("gnreCabecMsgValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.gnre.pe.gov.br/webservice/GnreLoteRecepcao/processar", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("processarResponse", Namespace = "http://www.gnre.pe.gov.br/webservice/GnreLoteRecepcao")]
        public System.Xml.XmlNode processar([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.gnre.pe.gov.br/webservice/GnreLoteRecepcao")] System.Xml.XmlNode gnreDadosMsg)
        {
            object[] results = this.Invoke("processar", new object[] {
                    gnreDadosMsg});
            return ((System.Xml.XmlNode)(results[0]));
        }

        public System.IAsyncResult Beginprocessar(System.Xml.XmlNode gnreDadosMsg, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("processar", new object[] {
                    gnreDadosMsg}, callback, asyncState);
        }

        public System.Xml.XmlNode Endprocessar(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }

        public void processarAsync(System.Xml.XmlNode gnreDadosMsg)
        {
            this.processarAsync(gnreDadosMsg, null);
        }

        public void processarAsync(System.Xml.XmlNode gnreDadosMsg, object userState)
        {
            if ((this.processarOperationCompleted == null))
            {
                this.processarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnprocessarOperationCompleted);
            }
            this.InvokeAsync("processar", new object[] {
                    gnreDadosMsg}, this.processarOperationCompleted, userState);
        }

        private void OnprocessarOperationCompleted(object arg)
        {
            if ((this.processarCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.processarCompleted(this, new processarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br/webservice/GnreLoteRecepcao")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.gnre.pe.gov.br/webservice/GnreLoteRecepcao", IsNullable = false)]
    public partial class gnreCabecMsg : System.Web.Services.Protocols.SoapHeader
    {

        private string versaoDadosField;

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

    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void processarCompletedEventHandler(object sender, processarCompletedEventArgs e);

    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class processarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal processarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

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


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.gnre.pe.gov.br", IsNullable = false)]
public partial class TLote_GNRE
{

    private TLote_GNRETDadosGNRE[] guiasField;
    private string versaoField;

    public TLote_GNRE()
    {
        this.versaoField = "1.00";
    }


    [System.Xml.Serialization.XmlArrayItemAttribute("TDadosGNRE", IsNullable = false)]
    public TLote_GNRETDadosGNRE[] guias
    {
        get
        {
            return this.guiasField;
        }
        set
        {
            this.guiasField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute("1.00")]
    public string versao
    {
        get
        {
            return this.versaoField;
        }
        set
        {
            this.versaoField = value;
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
public partial class TLote_GNRETDadosGNRE
{
    private TUf c01_UfFavorecidaField;
    private string c02_receitaField;

    private string c25_detalhamentoReceitaField;

    private string c26_produtoField;

    private TIdentificacao c27_tipoIdentificacaoEmitenteField;

    private bool c27_tipoIdentificacaoEmitenteFieldSpecified;

    private TLote_GNRETDadosGNREC03_idContribuinteEmitente c03_idContribuinteEmitenteField;

    private string c28_tipoDocOrigemField;

    private string c04_docOrigemField;

    private string c06_valorPrincipalField;

    private string c10_valorTotalField;

    private string c14_dataVencimentoField;

    private string c15_convenioField;

    private string c16_razaoSocialEmitenteField;

    private string c17_inscricaoEstadualEmitenteField;

    private string c18_enderecoEmitenteField;

    private string c19_municipioEmitenteField;

    private TUf c20_ufEnderecoEmitenteField;

    private bool c20_ufEnderecoEmitenteFieldSpecified;

    private string c21_cepEmitenteField;

    private string c22_telefoneEmitenteField;

    private TIdentificacao c34_tipoIdentificacaoDestinatarioField;

    private bool c34_tipoIdentificacaoDestinatarioFieldSpecified;

    private TLote_GNRETDadosGNREC35_idContribuinteDestinatario c35_idContribuinteDestinatarioField;

    private string c36_inscricaoEstadualDestinatarioField;

    private string c37_razaoSocialDestinatarioField;

    private string c38_municipioDestinatarioField;

    private string c33_dataPagamentoField;

    private TLote_GNRETDadosGNREC05_referencia c05_referenciaField;

    private TLote_GNRETDadosGNRECampoExtra[] c39_camposExtrasField;

    private string c42_identificadorGuiaField;


    public TUf c01_UfFavorecida
    {
        get
        {
            return this.c01_UfFavorecidaField;
        }
        set
        {
            this.c01_UfFavorecidaField = value;
        }
    }


    public string c02_receita
    {
        get
        {
            return this.c02_receitaField;
        }
        set
        {
            this.c02_receitaField = value;
        }
    }


    public string c25_detalhamentoReceita
    {
        get
        {
            return this.c25_detalhamentoReceitaField;
        }
        set
        {
            this.c25_detalhamentoReceitaField = value;
        }
    }


    public string c26_produto
    {
        get
        {
            return this.c26_produtoField;
        }
        set
        {
            this.c26_produtoField = value;
        }
    }


    public TIdentificacao c27_tipoIdentificacaoEmitente
    {
        get
        {
            return this.c27_tipoIdentificacaoEmitenteField;
        }
        set
        {
            this.c27_tipoIdentificacaoEmitenteField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool c27_tipoIdentificacaoEmitenteSpecified
    {
        get
        {
            return this.c27_tipoIdentificacaoEmitenteFieldSpecified;
        }
        set
        {
            this.c27_tipoIdentificacaoEmitenteFieldSpecified = value;
        }
    }


    public TLote_GNRETDadosGNREC03_idContribuinteEmitente c03_idContribuinteEmitente
    {
        get
        {
            return this.c03_idContribuinteEmitenteField;
        }
        set
        {
            this.c03_idContribuinteEmitenteField = value;
        }
    }


    public string c28_tipoDocOrigem
    {
        get
        {
            return this.c28_tipoDocOrigemField;
        }
        set
        {
            this.c28_tipoDocOrigemField = value;
        }
    }


    public string c04_docOrigem
    {
        get
        {
            return this.c04_docOrigemField;
        }
        set
        {
            this.c04_docOrigemField = value;
        }
    }


    public string c06_valorPrincipal
    {
        get
        {
            return this.c06_valorPrincipalField;
        }
        set
        {
            this.c06_valorPrincipalField = value;
        }
    }


    public string c10_valorTotal
    {
        get
        {
            return this.c10_valorTotalField;
        }
        set
        {
            this.c10_valorTotalField = value;
        }
    }


    public string c14_dataVencimento
    {
        get
        {
            return this.c14_dataVencimentoField;
        }
        set
        {
            this.c14_dataVencimentoField = value;
        }
    }


    public string c15_convenio
    {
        get
        {
            return this.c15_convenioField;
        }
        set
        {
            this.c15_convenioField = value;
        }
    }


    public string c16_razaoSocialEmitente
    {
        get
        {
            return this.c16_razaoSocialEmitenteField;
        }
        set
        {
            this.c16_razaoSocialEmitenteField = value;
        }
    }


    public string c17_inscricaoEstadualEmitente
    {
        get
        {
            return this.c17_inscricaoEstadualEmitenteField;
        }
        set
        {
            this.c17_inscricaoEstadualEmitenteField = value;
        }
    }


    public string c18_enderecoEmitente
    {
        get
        {
            return this.c18_enderecoEmitenteField;
        }
        set
        {
            this.c18_enderecoEmitenteField = value;
        }
    }


    public string c19_municipioEmitente
    {
        get
        {
            return this.c19_municipioEmitenteField;
        }
        set
        {
            this.c19_municipioEmitenteField = value;
        }
    }


    public TUf c20_ufEnderecoEmitente
    {
        get
        {
            return this.c20_ufEnderecoEmitenteField;
        }
        set
        {
            this.c20_ufEnderecoEmitenteField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool c20_ufEnderecoEmitenteSpecified
    {
        get
        {
            return this.c20_ufEnderecoEmitenteFieldSpecified;
        }
        set
        {
            this.c20_ufEnderecoEmitenteFieldSpecified = value;
        }
    }


    public string c21_cepEmitente
    {
        get
        {
            return this.c21_cepEmitenteField;
        }
        set
        {
            this.c21_cepEmitenteField = value;
        }
    }


    public string c22_telefoneEmitente
    {
        get
        {
            return this.c22_telefoneEmitenteField;
        }
        set
        {
            this.c22_telefoneEmitenteField = value;
        }
    }


    public TIdentificacao c34_tipoIdentificacaoDestinatario
    {
        get
        {
            return this.c34_tipoIdentificacaoDestinatarioField;
        }
        set
        {
            this.c34_tipoIdentificacaoDestinatarioField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool c34_tipoIdentificacaoDestinatarioSpecified
    {
        get
        {
            return this.c34_tipoIdentificacaoDestinatarioFieldSpecified;
        }
        set
        {
            this.c34_tipoIdentificacaoDestinatarioFieldSpecified = value;
        }
    }


    public TLote_GNRETDadosGNREC35_idContribuinteDestinatario c35_idContribuinteDestinatario
    {
        get
        {
            return this.c35_idContribuinteDestinatarioField;
        }
        set
        {
            this.c35_idContribuinteDestinatarioField = value;
        }
    }


    public string c36_inscricaoEstadualDestinatario
    {
        get
        {
            return this.c36_inscricaoEstadualDestinatarioField;
        }
        set
        {
            this.c36_inscricaoEstadualDestinatarioField = value;
        }
    }


    public string c37_razaoSocialDestinatario
    {
        get
        {
            return this.c37_razaoSocialDestinatarioField;
        }
        set
        {
            this.c37_razaoSocialDestinatarioField = value;
        }
    }


    public string c38_municipioDestinatario
    {
        get
        {
            return this.c38_municipioDestinatarioField;
        }
        set
        {
            this.c38_municipioDestinatarioField = value;
        }
    }


    public string c33_dataPagamento
    {
        get
        {
            return this.c33_dataPagamentoField;
        }
        set
        {
            this.c33_dataPagamentoField = value;
        }
    }


    public TLote_GNRETDadosGNREC05_referencia c05_referencia
    {
        get
        {
            return this.c05_referenciaField;
        }
        set
        {
            this.c05_referenciaField = value;
        }
    }


    [System.Xml.Serialization.XmlArrayItemAttribute("campoExtra", IsNullable = false)]
    public TLote_GNRETDadosGNRECampoExtra[] c39_camposExtras
    {
        get
        {
            return this.c39_camposExtrasField;
        }
        set
        {
            this.c39_camposExtrasField = value;
        }
    }


    public string c42_identificadorGuia
    {
        get
        {
            return this.c42_identificadorGuiaField;
        }
        set
        {
            this.c42_identificadorGuiaField = value;
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gnre.pe.gov.br")]
public enum TUf
{


    AC,


    AL,


    AM,


    AP,


    BA,


    CE,


    DF,


    ES,


    GO,


    MA,


    MG,


    MS,


    MT,


    PA,


    PB,


    PE,


    PI,


    PR,


    RJ,


    RN,


    RO,


    RR,


    RS,


    SC,


    SE,


    SP,


    TO,
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gnre.pe.gov.br")]
public enum TIdentificacao
{


    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,


    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
public partial class TLote_GNRETDadosGNREC03_idContribuinteEmitente
{

    private string itemField;

    private ItemChoiceType itemElementNameField;


    [System.Xml.Serialization.XmlElementAttribute("CNPJ", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("CPF", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
    public string Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType ItemElementName
    {
        get
        {
            return this.itemElementNameField;
        }
        set
        {
            this.itemElementNameField = value;
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gnre.pe.gov.br", IncludeInSchema = false)]
public enum ItemChoiceType
{


    CNPJ,


    CPF,
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
public partial class TLote_GNRETDadosGNREC35_idContribuinteDestinatario
{

    private string itemField;

    private ItemChoiceType1 itemElementNameField;


    [System.Xml.Serialization.XmlElementAttribute("CNPJ", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("CPF", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
    public string Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType1 ItemElementName
    {
        get
        {
            return this.itemElementNameField;
        }
        set
        {
            this.itemElementNameField = value;
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gnre.pe.gov.br", IncludeInSchema = false)]
public enum ItemChoiceType1
{


    CNPJ,


    CPF,
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
public partial class TLote_GNRETDadosGNREC05_referencia
{

    private TLote_GNRETDadosGNREC05_referenciaPeriodo periodoField;

    private bool periodoFieldSpecified;

    private TMes mesField;

    private bool mesFieldSpecified;

    private string anoField;

    private string parcelaField;


    public TLote_GNRETDadosGNREC05_referenciaPeriodo periodo
    {
        get
        {
            return this.periodoField;
        }
        set
        {
            this.periodoField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool periodoSpecified
    {
        get
        {
            return this.periodoFieldSpecified;
        }
        set
        {
            this.periodoFieldSpecified = value;
        }
    }


    public TMes mes
    {
        get
        {
            return this.mesField;
        }
        set
        {
            this.mesField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool mesSpecified
    {
        get
        {
            return this.mesFieldSpecified;
        }
        set
        {
            this.mesFieldSpecified = value;
        }
    }


    public string ano
    {
        get
        {
            return this.anoField;
        }
        set
        {
            this.anoField = value;
        }
    }


    public string parcela
    {
        get
        {
            return this.parcelaField;
        }
        set
        {
            this.parcelaField = value;
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
public enum TLote_GNRETDadosGNREC05_referenciaPeriodo
{


    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,


    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,


    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,


    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,


    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,


    [System.Xml.Serialization.XmlEnumAttribute("5")]
    Item5,
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gnre.pe.gov.br")]
public enum TMes
{


    [System.Xml.Serialization.XmlEnumAttribute("01")]
    Item01,


    [System.Xml.Serialization.XmlEnumAttribute("02")]
    Item02,


    [System.Xml.Serialization.XmlEnumAttribute("03")]
    Item03,


    [System.Xml.Serialization.XmlEnumAttribute("04")]
    Item04,


    [System.Xml.Serialization.XmlEnumAttribute("05")]
    Item05,


    [System.Xml.Serialization.XmlEnumAttribute("06")]
    Item06,


    [System.Xml.Serialization.XmlEnumAttribute("07")]
    Item07,


    [System.Xml.Serialization.XmlEnumAttribute("08")]
    Item08,


    [System.Xml.Serialization.XmlEnumAttribute("09")]
    Item09,


    [System.Xml.Serialization.XmlEnumAttribute("10")]
    Item10,


    [System.Xml.Serialization.XmlEnumAttribute("11")]
    Item11,


    [System.Xml.Serialization.XmlEnumAttribute("12")]
    Item12,
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gnre.pe.gov.br")]
public partial class TLote_GNRETDadosGNRECampoExtra
{

    private int codigoField;

    private TTipoCampoExtra tipoField;

    private string valorField;


    public int codigo
    {
        get
        {
            return this.codigoField;
        }
        set
        {
            this.codigoField = value;
        }
    }


    public TTipoCampoExtra tipo
    {
        get
        {
            return this.tipoField;
        }
        set
        {
            this.tipoField = value;
        }
    }


    public string valor
    {
        get
        {
            return this.valorField;
        }
        set
        {
            this.valorField = value;
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gnre.pe.gov.br")]
public enum TTipoCampoExtra
{


    T,


    N,


    D,
}



public class Nota
{

    public String c01_UfFavorecida { get; set; }
    public String c02_receita { get; set; }
    public String c03_idContribuinteEmitente { get; set; }
    public String c04_docOrigem { get; set; }
    public String c05_referencia { get; set; }
    public String c06_valorPrincipal { get; set; }
    public String c10_valorTotal { get; set; }
    public String c14_dataVencimento { get; set; }
    public String c15_convenio { get; set; }
    public String c16_razaoSocialEmitente { get; set; }
    public String c17_inscricaoEstadualEmitente { get; set; }
    public String c18_enderecoEmitente { get; set; }
    public String c19_municipioEmitente { get; set; }
    public String c20_ufEnderecoEmitente { get; set; }
    public String c21_cepEmitente { get; set; }
    public String c22_telefoneEmitente { get; set; }
    public String c25_detalhamentoReceita { get; set; }
    public String c26_produto { get; set; }
    public String c27_tipoIdentificacaoEmitente { get; set; }
    public String c28_tipoDocOrigem { get; set; }
    public String c33_dataPagamento { get; set; }
    public String c34_tipoIdentificacaoDestinatario { get; set; }
    public String c35_idContribuinteDestinatario { get; set; }
    public String c36_inscricaoEstadualDestinatario { get; set; }
    public String c37_razaoSocialDestinatario { get; set; }
    public String c38_municipioDestinatario { get; set; }
    public String c39_camposExtras { get; set; }
    public String c42_identificadorGuia { get; set; }
    public String contribuinteEmitente { get; set; }
    public String dataPagamento { get; set; }
    public String identificadorGuia { get; set; }
    public String itensGNRE { get; set; }
    public String tipoGnre { get; set; }
    public String ufFavorecida { get; set; }
    public String valorGNRE { get; set; }

}
