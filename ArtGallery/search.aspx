<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="ArtGallery._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  
<center>
    
    <div style="padding-left:20%;">
         <div class="col-md-7">
            <h3><strong>Available Arts and Sculpures</strong></h3>

         </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPaging" PageSize="10" style="width:100%;">
            <HeaderStyle Forecolor="White" Font-Bold="true" BackColor="#F7D358" CssClass="GridHeaderInner"/>
    <Columns>
        <asp:BoundField DataField="ITEMID" HeaderText="ITEMID"/>
        <asp:BoundField  DataField="TYPE" HeaderText="TYPE" />
        <asp:BoundField  DataField="NAME" HeaderText="NAME" />
        <asp:BoundField  DataField="DATEADDED" HeaderText="DATEADDED" />
         <asp:BoundField  DataField="CATEGEORY" HeaderText="CATEGEORY" />
         <asp:BoundField  DataField="QUANTITY" HeaderText="QUANTITY" />
         <asp:BoundField  DataField="COST" HeaderText="COST" />

    </Columns>
</asp:GridView>

    </div>

</center>

</asp:Content>
