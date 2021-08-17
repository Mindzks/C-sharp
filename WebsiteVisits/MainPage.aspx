<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebsiteVisits.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Serverių užklausos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous">
    <link href="style/app.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <section class="card container text-center mt-3 mb-4">
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Pirma turite įkelti failus, paspauskite žemiau esantį mygtuką"></asp:Label>
                <br />
                <asp:Button class="btn btn-warning" ID="UploadFiles" runat="server" Text="Įkelti failus" OnClick="UploadFiles_Click" />
            &nbsp;&nbsp;
                <br />
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            </div>

            <div>
                <asp:Label ID="Label2" runat="server" Text="Rodyti visų serverių informaciją"></asp:Label>
                <br />
                <asp:Button class="btn btn-warning" ID="ShowAllServersData" runat="server" Text="Rodyti serverius" OnClick="ShowAllServersData_Click" />
            &nbsp;
                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                <br />
            </div>

            <div>
                <asp:Label ID="Label3" runat="server" Text="Rodyti visų klientų informaciją"></asp:Label>
                <br />
                <asp:Button class="btn btn-warning" ID="ShowAllClientsData" runat="server" Text="Rodyti klientus" OnClick="ShowAllClientsData_Click" />
            &nbsp;
                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                <br />
                </div>

                <div>
                <asp:Label ID="Label4" runat="server" Text="Pridėti elementus į dropdownList"></asp:Label>
                <br />  
                <asp:Button class="btn btn-warning mb-2" ID="AddToElemToDDList" runat="server" Text="Pridėti elementus" OnClick="AddToElemToDDList_Click" />
                &nbsp;
                <br />
                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Rodyti pagal serverio simbolinį pavadinimą atrinktas svetaines"></asp:Label>
                <br />
                <asp:Button class="btn btn-warning" ID="ShowFiltered" runat="server" Text="Filtruoti" OnClick="ShowFiltered_Click" />
            &nbsp;
                <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                </div>
            

        </form>
    <div class="card text-center d-grid gap-2 col-8 mx-auto mt-2">   
        <asp:Table ID="Table1" runat="server"></asp:Table>
        <br />
    </div>


    </section>

    
        
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>
</body>
</html>
