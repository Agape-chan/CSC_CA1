<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="task5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
<asp:FileUpload ID="FileUpload1" runat="server" accept=".png,.jpg,.jpeg,.gif" />
<asp:Button ID="btnUpload" runat="server" Text="Upload Image"
    onclick="btnUpload_Click" />
<hr />
<asp:Image ID="Image1" Visible = "false" runat="server" Height = "100" Width = "100"/>

    <asp:TextBox ID="objectLink" Visible="false" runat="server" />

</asp:Content>
