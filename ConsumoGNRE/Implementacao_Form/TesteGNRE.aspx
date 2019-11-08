<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TesteGNRE.aspx.cs" Inherits="prj_TesteGNRE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teste GNRE</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Teste" OnClick="Button2_Click" />

        <asp:Table ID="Table1" runat="server" Height="474px">
          <asp:TableRow runat="server">
              <asp:TableCell HorizontalAlign="Left" Width="600">
                <asp:TableRow runat="server">
                      <asp:TableCell>
                          <h1>Geração de GNRE</h1>
                      </asp:TableCell>
                  </asp:TableRow>  

                    <asp:TableRow runat="server">
                        <asp:TableCell>
                            <div>
                                <label>Razão Social Emitente:</label>
                                <asp:TextBox ID="razaosocialEmitente" runat="server"></asp:TextBox><br/><br/>

                                <label>UF Favorecida:</label>
                                <asp:DropDownList ID="ufFornecida" runat="server">
                                    <asp:ListItem>AC</asp:ListItem>
                                    <asp:ListItem>AL</asp:ListItem>
                                    <asp:ListItem>AM</asp:ListItem>
                                    <asp:ListItem>AP</asp:ListItem>
                                    <asp:ListItem>BA</asp:ListItem>
                                    <asp:ListItem>CE</asp:ListItem>
                                    <asp:ListItem>DF</asp:ListItem>
                                    <asp:ListItem>ES</asp:ListItem>
                                    <asp:ListItem>GO</asp:ListItem>
                                    <asp:ListItem>MA</asp:ListItem>
                                    <asp:ListItem>MG</asp:ListItem>
                                    <asp:ListItem>MS</asp:ListItem>
                                    <asp:ListItem>MT</asp:ListItem>
                                    <asp:ListItem>PA</asp:ListItem>
                                    <asp:ListItem>PB</asp:ListItem>
                                    <asp:ListItem>PE</asp:ListItem>
                                    <asp:ListItem>PI</asp:ListItem>
                                    <asp:ListItem>PR</asp:ListItem>
                                    <asp:ListItem>RJ</asp:ListItem>
                                    <asp:ListItem>RN</asp:ListItem>
                                    <asp:ListItem>RO</asp:ListItem>
                                    <asp:ListItem>RR</asp:ListItem>
                                    <asp:ListItem>RS</asp:ListItem>
                                    <asp:ListItem>SC</asp:ListItem>
                                    <asp:ListItem>SE</asp:ListItem>
                                    <asp:ListItem>SP</asp:ListItem>
                                    <asp:ListItem>TO</asp:ListItem>
                                </asp:DropDownList>
                                <br/><br/>

                                <label>Receita:</label>
                                <asp:DropDownList ID="receita" runat="server">
                                    <asp:ListItem>100102</asp:ListItem>
                                    <asp:ListItem>100129</asp:ListItem>
                                </asp:DropDownList>
                                <br/><br/>

                                <label>Doc. Origem:</label>
                                <asp:DropDownList ID="docOrigem" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                </asp:DropDownList>
                                <br/><br/>

                                <label>Ref. Período:</label>
                                <asp:TextBox ID="periodo" runat="server"></asp:TextBox><br/><br/>

                                <label>Ref. Mês:</label>
                                <asp:TextBox ID="mes" runat="server"></asp:TextBox><br/><br/>

                                <label>Ref. Ano:</label>
                                <asp:TextBox ID="ano" runat="server"></asp:TextBox><br/><br/>

                                <label>Valor Principal:</label>
                                <asp:TextBox ID="valorPrincipal" runat="server"></asp:TextBox><br/><br/>

                                <label>Data do Vencimento:</label>
                                <asp:TextBox ID="dataVencimento" runat="server"></asp:TextBox><br/><br/>
            
                                <label>Convênio:</label>
                                <asp:TextBox ID="convenio" runat="server"></asp:TextBox><br/><br/>
            
                                <label>Tipo Doc. Origem:</label>
                                <asp:TextBox ID="tipoDocOrigem" runat="server"></asp:TextBox><br/><br/>

                                <label>Data do Pagamento:</label>
                                <asp:TextBox ID="dataPagamento" runat="server"></asp:TextBox><br/><br/>

                                <label>Chave NFE:</label>
                                <asp:TextBox ID="chaveNFE" runat="server"></asp:TextBox><br/><br/>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server">
                        <asp:TableCell>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Gerar XML de Lote" />
                        </asp:TableCell>
                    </asp:TableRow>   
              </asp:TableCell>

              <asp:TableCell runat="server" HorizontalAlign="Right" Width="300">
                  <asp:Xml ID="Xml1" runat="server"></asp:Xml>
                  <asp:Literal ID="lit" runat="server"></asp:Literal>
              </asp:TableCell>
          </asp:TableRow>
        </asp:Table>
        
    </form>
</body>
</html>
