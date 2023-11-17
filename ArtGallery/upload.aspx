<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="ArtGallery.upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <center>


         <div style="padding-left:20%">
            
  <div class="d-lg-flex half">
    <div class="bg order-1 order-md-2" style="background-image: url('images/bg2.jpg');"></div>
    <div class="contents order-2 order-md-1">

      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col-md-7">
            <h3><strong>Upload to Art Gallery</strong></h3>
         
               <div class="form-group last mb-3">
                <label for="username">User ID</label>
                <asp:TextBox CssClass="form-control" ID="username" runat="server" Enabled="false"></asp:TextBox>
              </div>
              <div class="form-group last mb-3">
                <label >Type</label>
               <asp:DropDownList ID="Type" runat="server" CssClass="from-control custom-select-sm"></asp:DropDownList>
                 
              </div>
                 <div class="form-group last mb-3">
                <label >Categeory</label>
               <asp:DropDownList ID="Cat" runat="server" CssClass="from-control custom-select-sm"></asp:DropDownList>
             
              </div>
               <div class="form-group last mb-3">
                <label >Quantity</label>
                <asp:TextBox ID="Quantity" CssClass="form-control" runat="server"></asp:TextBox>  
              </div>
             <div class="form-group last mb-3">
                <label>Cost</label>
                <asp:TextBox ID="Cost" CssClass="form-control" runat="server"></asp:TextBox>  
              </div>

          
                
               <asp:Button CssClass="btn btn-block btn-primary" Text="Upload" runat="server" onclick="Upload"/>
          
          </div>
        </div>
      </div>
    </div>

    
  </div>
    
    </div>


    </center>


</asp:Content>
