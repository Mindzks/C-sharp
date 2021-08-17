using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteVisits
{
    public partial class MainPage : System.Web.UI.Page
    {
        const string clientDir = @"D:\OP\LD_5\WebsiteVisits\WebsiteVisits\DayData";
        const string serverDir = @"D:\OP\LD_5\WebsiteVisits\WebsiteVisits\ServerData";


        protected void Page_Load(object sender, EventArgs e)
        {
            Label6.Text = "";
            Label7.Text = "";
            Label8.Text = "";
            Label9.Text = "";
            Label10.Text = "";
            Label11.Text = "";

        }

        protected void UploadFiles_Click(object sender, EventArgs e)
        {
            InfoList<Client> AllClients = new InfoList<Client>();
            InfoList<Server> AllServers = new InfoList<Server>();

            try
            {
                InOut.ReadClientsData(AllClients, clientDir, Label6);
                InOut.ReadServerData(AllServers, serverDir, Label7);

                Session["AllClients"] = AllClients;
                Session["AllServers"] = AllServers;
            }
            catch (Exception ex)
            {
                Label6.Text = ex.Message;
            }
            

        }

        protected void ShowAllServersData_Click(object sender, EventArgs e)
        {
            try
            {
                AddServersDataToTable((InfoList<Server>)Session["AllServers"]);
            }
            catch (Exception ex)
            {
                Label8.Text = ex.Message;
            }
            
        }

        protected void ShowAllClientsData_Click(object sender, EventArgs e)
        {
            try
            {
                AddClientsDataToTable((InfoList<Client>)Session["AllClients"]);

            }
            catch (Exception ex)
            {
                Label9.Text = ex.Message;
            }
        }
        

        protected void AddToElemToDDList_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList1.Items.Count == 0)
                {
                    DropDownList1.Items.Add("-");

                    foreach (var item in (InfoList<Server>)Session["AllServers"])
                    {
                        DropDownList1.Items.Add(item.Domain);
                    }
                }
            }
            catch (Exception ex)
            {
                Label10.Text = ex.Message;
            }
        }

        protected void ShowFiltered_Click(object sender, EventArgs e)
        {
            try
            {
                var value = DropDownList1.Text;

                InfoList<Server> myList = (InfoList<Server>)Session["AllServers"];

                InfoList<Client> AllClients = (InfoList<Client>)Session["AllClients"];

                List<Client> filtered = TaskUtils.Filter(myList, AllClients, value);

                AddClientsDataToTable2(filtered);
            }
            catch (Exception ex)
            {
                Label11.Text = ex.Message;
            }
        }

        
        private void AddClientsDataToTable2(List<Client> clients)
        {
            TableRow Clients = new TableRow();

            TableCell Hours = new TableCell();
            TableCell Minutes = new TableCell();
            TableCell Seconds = new TableCell();
            TableCell IP = new TableCell();
            TableCell FullPath = new TableCell();

            Hours.Text = "Valandos";
            Minutes.Text = "Minutės";
            Seconds.Text = "Sekundės";
            IP.Text = "Kompiuterio IP";
            FullPath.Text = "Puslapis";

            Hours.Style.Add("border", "1px solid black");
            Minutes.Style.Add("border", "1px solid black");
            Seconds.Style.Add("border", "1px solid black");
            IP.Style.Add("border", "1px solid black");
            FullPath.Style.Add("border", "1px solid black");

            Clients.Cells.Add(Hours);
            Clients.Cells.Add(Minutes);
            Clients.Cells.Add(Seconds);
            Clients.Cells.Add(IP);
            Clients.Cells.Add(FullPath);

            Table1.Rows.Add(Clients);

            foreach (var item in clients)
            {
                TableRow Clients2 = new TableRow();

                TableCell Hours2 = new TableCell();
                TableCell Minutes2 = new TableCell();
                TableCell Seconds2 = new TableCell();
                TableCell IP2 = new TableCell();
                TableCell FullPath2 = new TableCell();

                Hours2.Text = item.Hours.ToString();
                Minutes2.Text = item.Minutes.ToString();
                Seconds2.Text = item.Seconds.ToString();
                IP2.Text = item.PcIP.ToString();
                FullPath2.Text = item.FullWebPath.ToString();

                Hours2.Style.Add("border", "1px solid black");
                Minutes2.Style.Add("border", "1px solid black");
                Seconds2.Style.Add("border", "1px solid black");
                IP2.Style.Add("border", "1px solid black");
                FullPath2.Style.Add("border", "1px solid black");

                Clients2.Cells.Add(Hours2);
                Clients2.Cells.Add(Minutes2);
                Clients2.Cells.Add(Seconds2);
                Clients2.Cells.Add(IP2);
                Clients2.Cells.Add(FullPath2);

                Table1.Rows.Add(Clients2);

            }
        }
        
        private void AddClientsDataToTable(InfoList<Client> clients)
        {
            TableRow Clients = new TableRow();

            TableCell Hours = new TableCell();
            TableCell Minutes = new TableCell();
            TableCell Seconds = new TableCell();
            TableCell IP = new TableCell();
            TableCell FullPath = new TableCell();

            Hours.Text = "Valandos";
            Minutes.Text = "Minutės";
            Seconds.Text = "Sekundės";
            IP.Text = "Kompiuterio IP";
            FullPath.Text = "Puslapis";

            Hours.Style.Add("border", "1px solid black");
            Minutes.Style.Add("border", "1px solid black");
            Seconds.Style.Add("border", "1px solid black");
            IP.Style.Add("border", "1px solid black");
            FullPath.Style.Add("border", "1px solid black");

            Clients.Cells.Add(Hours);
            Clients.Cells.Add(Minutes);
            Clients.Cells.Add(Seconds);
            Clients.Cells.Add(IP);
            Clients.Cells.Add(FullPath);

            Table1.Rows.Add(Clients);

            foreach (var item in clients)
            {
                TableRow Clients2 = new TableRow();

                TableCell Hours2 = new TableCell();
                TableCell Minutes2 = new TableCell();
                TableCell Seconds2 = new TableCell();
                TableCell IP2 = new TableCell();
                TableCell FullPath2 = new TableCell();

                Hours2.Text = item.Hours.ToString();
                Minutes2.Text = item.Minutes.ToString();
                Seconds2.Text = item.Seconds.ToString();
                IP2.Text = item.PcIP.ToString();
                FullPath2.Text = item.FullWebPath.ToString();

                Hours2.Style.Add("border", "1px solid black");
                Minutes2.Style.Add("border", "1px solid black");
                Seconds2.Style.Add("border", "1px solid black");
                IP2.Style.Add("border", "1px solid black");
                FullPath2.Style.Add("border", "1px solid black");

                Clients2.Cells.Add(Hours2);
                Clients2.Cells.Add(Minutes2);
                Clients2.Cells.Add(Seconds2);
                Clients2.Cells.Add(IP2);
                Clients2.Cells.Add(FullPath2);

                Table1.Rows.Add(Clients2);

            }
        }

        private void AddServersDataToTable(InfoList<Server> servers)
        {
            TableRow Server1 = new TableRow();

            TableCell IP = new TableCell();
            TableCell Domain = new TableCell();

            IP.Text = "Serverio IP";
            Domain.Text = "Domenas";

            IP.Style.Add("border", "1px solid black");
            Domain.Style.Add("border", "1px solid black");

            Server1.Cells.Add(IP);
            Server1.Cells.Add(Domain);

            Table1.Rows.Add(Server1);

            foreach (var item in servers)
            {
                TableRow Server2 = new TableRow();

                TableCell IP2 = new TableCell();
                TableCell Domain2 = new TableCell();

                IP2.Text = item.IP;
                Domain2.Text = item.Domain;

                IP2.Style.Add("border", "1px solid black");
                Domain2.Style.Add("border", "1px solid black");

                Server2.Cells.Add(IP2);
                Server2.Cells.Add(Domain2);

                Table1.Rows.Add(Server2);
            }
        }
    }
}