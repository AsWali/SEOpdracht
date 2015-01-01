﻿<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SE_IMDB_OPDRACHT.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>
        <br />&nbsp;<asp:Label ID="lbusername" runat="server" Text=":username:" Font-Size="Large"></asp:Label>
        <br />&nbsp;<asp:Label ID="lbjoindate" runat="server" Text=":joindate:" Font-Size="Medium"></asp:Label>
    </h2>
    <p>&nbsp;</p>
    <p>&nbsp;</p>

    <div>

        Your Rating list<br />
        <asp:Image ID="Image1" runat="server" Height="136px" Width="103px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image2" runat="server" Height="136px" Width="103px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image3" runat="server" Height="136px" Width="103px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image4" runat="server" Height="136px" Width="103px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image5" runat="server" Height="136px" Width="103px" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Click to see all Ratings" />
        <br />
        <br />
        <br />

    <div>

        Your Viewing History :<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="176px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="239px"></asp:ListBox>
        <br />
        <br />

    </div>

    </div>

    <div class="row">
        <div class="col-md-12">

            <section id="externalLoginsForm">

            </section>

        </div>
    </div>

</asp:Content>
