<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ArtGallery.Register" %>

<!DOCTYPE html>

<html>
<head runat="server">
     <title>Art Gallery</title>
        <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="fonts/icomoon/style.css">

    <link rel="stylesheet" href="css/owl.carousel.min.css">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    
    <!-- Style -->
    <link rel="stylesheet" href="css/style.css">

      <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
  <div class="d-lg-flex half">
    <div class="bg order-1 order-md-2" style="background-image: url('images/bg.jpg');"></div>
    <div class="contents order-2 order-md-1">

      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col-md-7">
            <h3>Register to Art Gallery</h3>
         
               <div class="form-group last mb-3">
                <label for="username">Email</label>
                <asp:TextBox CssClass="form-control" ID="username" runat="server"></asp:TextBox>
              </div>
              <div class="form-group last mb-3">
                <label for="password">Password</label>
                <asp:TextBox ID="password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>  
              </div>
                 <div class="form-group last mb-3">
                <label for="password">Name</label>
                <asp:TextBox ID="UName" CssClass="form-control" runat="server"></asp:TextBox>  
              </div>
               <div class="form-group last mb-3">
                <label for="password">Contact Number</label>
                <asp:TextBox ID="Contact" CssClass="form-control" runat="server"></asp:TextBox>  
              </div>
            

          
                
               <asp:Button CssClass="btn btn-block btn-primary" Text="Register" runat="server" OnClick="RegisterArt"/>
          
          </div>
        </div>
      </div>
    </div>

    
  </div>
    
    </div>
    </form>

    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
        
</body>
</html>
