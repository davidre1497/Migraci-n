<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Migración.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registro de usuario</h1>
    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox>
    <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido"></asp:TextBox>
    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
    <asp:Button ID="btnRegistro" runat="server" Text="Registro" OnClick="btnRegistro_Click" />
</asp:Content>