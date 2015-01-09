<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SE_IMDB_OPDRACHT.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2></h2>
        <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
  
        
            <div class="PageInfo">
                <asp:Image ID="Image1" runat="server" Height="229px" Width="176px" />
                


            </div>

                <div class="PageInfo4">
                    <asp:Label ID="Lblrating" runat="server" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="tbrating" runat="server" UseSubmitBehavior="False" Width="97px" ></asp:TextBox>
                <asp:Button ID="btnrate" runat="server" OnClick="btnrate_Click" Text="Rate" Width="62px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" UseSubmitBehavior="False" ControlToValidate="tbrating" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>

            </div>


            <div class="PageInfo2">
                    <p class="lead">
                     <asp:Literal runat="server" ID="DescriptionMessage" />
                    </p>
            </div>

                <div class="PageInfo3">
               
                    <h3>Cast</h3>

                    <asp:label id="Message"
                         forecolor="Red"
                        runat="server"/>

                    <br/>    

                    <asp:gridview id="AuthorsGridView" 
                          autogeneratecolumns="true" 
                      runat="server" Height="259px" Width="355px" OnSelectedIndexChanged="AuthorsGridView_SelectedIndexChanged">
                     </asp:gridview>

               
            </div>
        
        
    

    </asp:Content>
