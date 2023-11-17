<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userpurchase.aspx.cs" Inherits="ArtGallery.userpurchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <center>
    
    <div style="padding-left:20%;">
         <div class="col-md-7">
            <h3><strong>User Purchase Sheet</strong></h3>

         </div>

        <div runat="server" id="user" visible="false">
             <div class="form-group last mb-3">
                <label for="username">User ID</label>
                <asp:TextBox CssClass="form-control" ID="username" runat="server" Enabled="false"></asp:TextBox>
              

              </div>
             <div class="form-group last mb-3">
              
            <asp:Button CssClass="btn btn-block btn-primary" Text="Fetch" runat="server" onclick="Fetch"/>
                 </div>
        </div>
        <div runat="server" id="Recordsdiv" visible="false">
             <h3><strong>No records found</strong></h3>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPaging" PageSize="10" style="width:100%;">
            <HeaderStyle Forecolor="White" Font-Bold="true" BackColor="#F7D358" CssClass="GridHeaderInner"/>
    <Columns>
          <asp:BoundField DataField="USERID" HeaderText="USERID"/>
        <asp:BoundField DataField="AVAILABLEBALANCE" HeaderText="AVAILABLEBALANCE"/>
        <asp:BoundField  DataField="WITHDRAWNAMOUNT" HeaderText="WITHDRAWNAMOUNT" />
        <asp:BoundField  DataField="TOTAL" HeaderText="TOTAL" />
        <asp:BoundField  DataField="MODIFIEDON" HeaderText="MODIFIEDON" />
             </Columns>
</asp:GridView>

    </div>

</center>
</asp:Content>
