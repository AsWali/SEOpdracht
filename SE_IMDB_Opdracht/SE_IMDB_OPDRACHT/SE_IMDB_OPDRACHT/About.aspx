<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SE_IMDB_OPDRACHT.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Search Results :</h2>
    <h3>
        <asp:ListBox ID="ListBox1" runat="server" Height="189px" Width="577px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
    </h3>
    </asp:Content>
