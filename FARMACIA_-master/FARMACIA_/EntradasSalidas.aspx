<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="EntradasSalidas.aspx.cs" Inherits="Migración.EntradasSalidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Entradas y Salidas</h1>
    <asp:GridView ID="gvEntradasSalidas" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Persona" HeaderText="Persona" />
            <asp:BoundField DataField="FechaEntrada" HeaderText="Fecha Entrada" />
            <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblPersona" runat="server" Text="Persona:"></asp:Label>
    <asp:TextBox ID="txtPersona" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblFechaEntrada" runat="server" Text="Fecha Entrada:"></asp:Label>
    <asp:TextBox ID="txtFechaEntrada" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblFechaSalida" runat="server" Text="Fecha Salida:"></asp:Label>
    <asp:TextBox ID="txtFechaSalida" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>