<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingSite.aspx.cs" Inherits="LD_3_Hotels_WebApp.BookingSite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Viešbučiai</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous">
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <section class="container mt-3 mb-4">
    <form id="form1" runat="server">
         <div class="card text-center d-grid gap-2 col-8 mx-auto">
                 <div class="card-header">
                     Failų įkėlimas
                 </div>
                 <div class="card-body">
                 <asp:FileUpload ID="FileUpload" runat="server" Height="28px" Width="322px"/>
                    <p class="card-text">Kai surasite kompiuteryje viešbučių ar žmonių duomenų failą, paspauskite atitinkamą mygtuką, kuris leis įkelti failą į serverį ir atlikti veiksmus su tais failais</p>
                 
                 <asp:Button class="btn btn-primary" ID="UploadPersonsFile" runat="server" Text="Įkelti asmenų failą" OnClick="UploadPersonsFile_Click" />
                 <asp:Button class="btn btn-primary" ID="UploadHotelsFile" runat="server" Text="Įkelti viešbučių failą" OnClick="UploadHotelsFile_Click" />
                 <br />
                 <asp:Label ID="UploadStatusLabel" runat="server"></asp:Label>
                 <br />
                 </div>
         </div>   
         <div class="text-center mt-3">
             <div class="card d-inline-block" style="width: 18rem;">
             <img src="https://images.unsplash.com/photo-1556741533-6e6a62bd8b49?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80" class="card-img-top" alt="...">
             <div class="card-body">
                <h5 class="card-title">Rodyti visus žmones</h5>
                <asp:Button ID="ShowAllPeople" runat="server" Text="Rodyti" OnClick="ShowAllPeople_Click" />
            &nbsp;&nbsp;&nbsp;
                 <br />
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            <br />
             </div>
         </div>
        <div class="card d-inline-block" style="width: 18rem;">
             <img src="https://images.unsplash.com/photo-1598598795009-f80c5072e665?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=967&q=80" class="card-img-top" alt="...">
             <div class="card-body">
                <h5 class="card-title">Rodyti visus viešbučius</h5>
                 <asp:Button ID="ShowAllHotels" runat="server" Text="Rodyti" OnClick="ShowAllHotels_Click" />
                &nbsp;&nbsp;
                <br />
                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
             </div>
         </div>
        <div class="card d-inline-block" style="width: 18rem;">
             <img src="https://images.unsplash.com/photo-1533040144848-c9b885ea47de?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1024&q=80" class="card-img-top" alt="...">
             <div class="card-body">
                <h5 class="card-title">Užsakyti viešbučiai</h5>
                <asp:Button ID="BookedHotels" runat="server" Text="Rodyti" OnClick="BookedHotels_Click1" />
                &nbsp;&nbsp;&nbsp;
                 <br />
                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
             </div>
         </div>
        <div class="card d-inline-block" style="width: 18rem;">
             <img src="https://images.unsplash.com/photo-1486304873000-235643847519?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1489&q=80" class="card-img-top" alt="...">
             <div class="card-body">
                <h5 class="card-title">Neužsakyti viešbučiai</h5>
                <asp:Button ID="NotBookedHotels" runat="server" Text="Rodyti" OnClick="NotBookedHotels_Click" />
                &nbsp;&nbsp;
                 <br />
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            <br />
             </div>
         </div>
         </div>
        <div class="card text-center d-grid gap-2 col-6 mx-auto mt-3 mb-3 " >
            <asp:Label class="h3" ID="Label4" runat="server" Text="Keliautojai, kurie nakvojo daugiausiai naktų:"></asp:Label>
            <asp:Button ID="SpentMostNights" runat="server" Text="Rodyti" OnClick="SpentMostNights_Click" />
            &nbsp;&nbsp;
            <br />
            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label class="h3" ID="Label7" runat="server" Text="Keliautojai, kurie sumokėjo ne didesnę sumą nei (nurodyti sumą):"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" class="text-center" runat="server" value="1"></asp:TextBox>
            <asp:Button ID="FilterByMoney" runat="server" Text="Rodyti" OnClick="FilterByMoney_Click" />
            &nbsp;
            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            <asp:Button class="btn btn-warning" ID="PrintResFile" runat="server" Text="Rezultatai txt" OnClick="PrintResFile_Click" />
            <asp:Button class="btn btn-warning" ID="PrintData" runat="server" Text="Duomenys txt" OnClick="PrintData_Click" />
        </div>
        
        <div class="card text-center d-grid gap-2 col-6 mx-auto">
           <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2" GridLines="Both" ForeColor="Black"></asp:Table>
        </div>
    </form>
    </section>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js" integrity="sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0" crossorigin="anonymous"></script>
</body>
</html>
