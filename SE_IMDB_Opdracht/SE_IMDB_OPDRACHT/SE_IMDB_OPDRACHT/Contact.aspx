<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SE_IMDB_OPDRACHT.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
  
        
            <div class="PageInfo">
                <asp:Image ID="Image1" runat="server" Height="164px" />
            </div>

            <div class="PageInfo2">
                <p class="lead2">eyeyey</p>
            </div>

                <div class="PageInfo3">
               
                    <h3>Cast</h3>

                    <asp:label id="Message"
                         forecolor="Red"
                        runat="server"/>

                    <br/>    

                    <asp:gridview id="AuthorsGridView" 
                          autogeneratecolumns="true" 
                      runat="server" Height="259px" Width="355px">
                     </asp:gridview>

               
            </div>
        
        
    

    </asp:Content>
