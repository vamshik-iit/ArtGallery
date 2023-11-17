<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="ArtGallery.update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <center>


         <div style="padding-left:20%">
            
  <div class="d-lg-flex half">
    <div class="bg order-1 order-md-2" style="background-image: url('images/bg2.jpg');"></div>
    <div class="contents order-2 order-md-1">

      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col-md-7">
            <h3><strong>Update/Delete existing items on Art Gallery</strong></h3>
         
               <div class="form-group last mb-3">
                <label for="username">Item ID</label>
                <asp:TextBox CssClass="form-control" ID="itemid" runat="server" ></asp:TextBox>
                     
      
              </div>

           <asp:Button CssClass="btn btn-block btn-primary" Text="Fetch" runat="server" OnClick="Fetch"/>
                
               <div class="form-group last mb-3">
                <label >Quantity</label>
                <asp:TextBox ID="Quantity" CssClass="form-control" runat="server"></asp:TextBox>  
              </div>
             <div class="form-group last mb-3">
                <label>Cost</label>
                <asp:TextBox ID="Cost" CssClass="form-control" runat="server"></asp:TextBox>  
              </div>

          
                
               <asp:Button CssClass="btn btn-block btn-primary" Text="Update" runat="server" onclick="Update"/>
            <asp:Button CssClass="btn btn-block btn-primary" Text="Delete" runat="server" Onclick="Delete"/>
      
          </div>
        </div>
      </div>
    </div>

    
  </div>
    
    </div>


    </center>


</asp:Content>
