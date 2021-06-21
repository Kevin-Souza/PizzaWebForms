<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RemoverPro.aspx.cs" Inherits="LoginWebForms.RemoverPro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-warning">
        <h2>Remover Pizza</h2>
    </div>

    <div class="row" style="margin-top: 15px">
        <div class="col-md-12">
            <label>Sabor:</label>
            <asp:RequiredFieldValidator ID="rfvSabor" ControlToValidate="txtSabor"
                ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtSabor" runat="server" MaxLength="50" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>

    <div class="row" style="margin-top: 15px">
        <div class="col-md-7">
            <label>Bordas:</label>
            <asp:RequiredFieldValidator ID="rfvBordas" ControlToValidate="txtBordas"
                ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtBordas" runat="server" MaxLength="10" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>

        <div class="col-md-3">
            <label>Tamanho:</label>
            <asp:RequiredFieldValidator ID="rfvTamanho" ControlToValidate="ddlTamanho"
                ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlTamanho" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Selected="True" Value=""></asp:ListItem>
                <asp:ListItem Value="P">Pequena</asp:ListItem>
                <asp:ListItem Value="M">Média</asp:ListItem>
                <asp:ListItem Value="G">Grande</asp:ListItem>
                <asp:ListItem Value="F">Família</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnVoltar" CssClass="btn btn-warning" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            <asp:Button ID="btnRemover" CssClass="btn btn-danger" runat="server" Text="Remover" OnClick="btnRemover_Click" />
        </div>
    </div>

    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Label ID="lblResultado" CssClass="text-danger" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
