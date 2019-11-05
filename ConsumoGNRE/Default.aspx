<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="ConsumoGNRE._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <h1>...</h1>
        <asp:Button ID="Button1" class="btn btn-primary btn-lg" runat="server" Text="Teste" OnClick="Button1_Click" />
    </div>

</asp:Content>
