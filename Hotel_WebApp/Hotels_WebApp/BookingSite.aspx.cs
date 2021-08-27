using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD_3_Hotels_WebApp
{
    public partial class BookingSite : System.Web.UI.Page
    {
        const string Results = "App_Data/Rezultatai.txt";
        const string Data = "App_Data/Duomenys.txt";
        private int Money;


        protected void Page_Load(object sender, EventArgs e)
        {
            Label8.Text = "";
            Label9.Text = "";
            Label10.Text = "";
            Label11.Text = "";
            Label12.Text = "";
            Label13.Text = "";
            UploadStatusLabel.Text = "";
        }

        protected void UploadPersonsFile_Click(object sender, EventArgs e)
        {
            string SavePath;
            string appPath;
            string saveDir = @"\Uploads\";

            //Gets the path where application is store (director of application)
            appPath = Request.PhysicalApplicationPath;

            // Checks if there is a file chosen in the fileupload interface. If there is a file, then this file is uploaded on server
            // and data is converted to the BookingList object
            if (FileUpload.HasFile)
            {
                SavePath = appPath + saveDir + Server.HtmlEncode(FileUpload.FileName);
                FileUpload.SaveAs(SavePath);
                UploadStatusLabel.Text = "Failas įkeltas sėkmingas";
                UploadStatusLabel.Style.Add("Color", "Red");

                BookingList<Person> AllPersons = InOut.ReadPersons(saveDir + Server.HtmlEncode(FileUpload.FileName), Server);

                Session["AllPersons"] = AllPersons;
                
            }
            //If there is no file in the UploadFile interface, the warning message is printed on the web app
            else
            {
                UploadStatusLabel.Text = "nepasirinktas joks failas";
                UploadStatusLabel.Style.Add("Color", "Red");
            }
        }

        protected void ShowAllPeople_Click(object sender, EventArgs e)
        {
            BookingList<Person> AllPersons = (BookingList<Person>)Session["AllPersons"];
            
            if (AllPersons != null)
            {
                AddPersonsToTable(AllPersons);
                Label8.Text = "";
            }
            else
            {
                Label8.Text = "Įkelkite žmonių duomenų failą";
                Label8.Style.Add("Color", "Red");
            }
            
            
        }
  
        protected void UploadHotelsFile_Click(object sender, EventArgs e)
        {
            string SavePath;
            string appPath;
            string saveDir = @"\Uploads\";

            appPath = Request.PhysicalApplicationPath;

            if (FileUpload.HasFile)
            {
                SavePath = appPath + saveDir + Server.HtmlEncode(FileUpload.FileName);
                FileUpload.SaveAs(SavePath);
                UploadStatusLabel.Text = "Failas įkeltas sėkmingas";
                UploadStatusLabel.Style.Add("Color", "Red");

                BookingList<Hotel> AllHotels = InOut.ReadHotels(saveDir + Server.HtmlEncode(FileUpload.FileName), Server);

                Session["AllHotels"] = AllHotels;

            }
            else
            {
                UploadStatusLabel.Text = "nepasirinktas joks failas";
                UploadStatusLabel.Style.Add("Color", "Red");
            }
        }

        protected void ShowAllHotels_Click(object sender, EventArgs e)
        {
            BookingList<Hotel> AllHotels = (BookingList<Hotel>)Session["AllHotels"];
            if (AllHotels != null)
            {
                AddHotelsToTable(AllHotels);
                Label9.Text = "";
            }
            else
            {
                Label9.Text = "Įkelkite viešbučių duomenų failą";
                Label9.Style.Add("Color", "Red");
            }
        }

        

        protected void BookedHotels_Click1(object sender, EventArgs e)
        {
            if ((BookingList<Person>) Session["AllPersons"] != null)
            {
                if ((BookingList<Hotel>)Session["AllHotels"] != null)
                {
                    AddHotelsToTable(TaskUtils.BookedHotels((BookingList<Person>)Session["AllPersons"], (BookingList<Hotel>)Session["AllHotels"]));
                    Session["BookedHotels"] = TaskUtils.BookedHotels((BookingList<Person>)Session["AllPersons"],(BookingList<Hotel>)Session["AllHotels"]);
                    Label10.Text = "";
                }
                else
                {
                    Label10.Text = "Įkelkite žmonių ir viešbučių duomenų failus";
                    Label10.Style.Add("Color", "Red");
                }

            }
            else
            {
                Label10.Text = "Įkelkite žmonių ir viešbučių duomenų failus";
                Label10.Style.Add("Color", "Red");
            }
            
        }

        protected void NotBookedHotels_Click(object sender, EventArgs e)
        {
            if ((BookingList<Person>)Session["AllPersons"] != null)
            {
                if ((BookingList<Hotel>)Session["AllHotels"] != null)
                {
                    AddHotelsToTable(TaskUtils.notBookedHotels((BookingList<Person>)Session["AllPersons"], (BookingList<Hotel>)Session["AllHotels"]));
                    Session["NotBookedHotels"] = TaskUtils.BookedHotels((BookingList<Person>)Session["AllPersons"], (BookingList<Hotel>)Session["AllHotels"]);
                    Label11.Text = "";
                }
                else
                {
                    Label11.Text = "Įkelkite žmonių ir viešbučių duomenų failus";
                    Label11.Style.Add("Color", "Red");
                }

            }
            else
            {
                Label11.Text = "Įkelkite žmonių ir viešbučių duomenų failus";
                Label11.Style.Add("Color", "Red");
            }
        }

        protected void SpentMostNights_Click(object sender, EventArgs e)
        {
            if ((BookingList<Person>)Session["AllPersons"] != null)
            {
                AddPersonsToTable(TaskUtils.SpentMostNights((BookingList<Person>)Session["AllPersons"]));
                Session["SpentMostNights"] = TaskUtils.SpentMostNights((BookingList<Person>)Session["AllPersons"]);
                Label12.Text = "";
            }
            else
            {
                Label12.Text = "Įkelkite žmonių duomenų failą";
                Label12.Style.Add("Color", "Red");
            }
            
        }

        protected void FilterByMoney_Click(object sender, EventArgs e)
        {
            if ((BookingList<Person>)Session["AllPersons"] != null)
            {
                if ((BookingList<Hotel>)Session["AllHotels"] != null)
                {
                    Money = int.Parse(TextBox1.Text);
                    AddPersonsToTable(TaskUtils.FilteredBySpentMoney((BookingList<Person>)Session["AllPersons"], (BookingList<Hotel>)Session["AllHotels"], Money));
                    Session["Filtered"] = TaskUtils.FilteredBySpentMoney((BookingList<Person>)Session["AllPersons"], (BookingList<Hotel>)Session["AllHotels"], Money);
                    Label13.Text = "";
                }
                else
                {
                    Label13.Text = "Įkelkite žmonių ir viešbučių duomenų failus";
                    Label13.Style.Add("Color", "Red");
                }

            }
            else
            {
                Label13.Text = "Įkelkite žmonių ir viešbučių duomenų failus";
                Label13.Style.Add("Color", "Red");
            }
        }

        protected void PrintResFile_Click(object sender, EventArgs e)
        {
            InOut.PrintTxt<Hotel>((BookingList<Hotel>)Session["BookedHotels"], Results, "Užsakyti viešbučiai", Server);
            InOut.PrintTxt<Hotel>((BookingList<Hotel>)Session["NotBookedHotels"], Results, "Neužsakyti viešbučiai", Server);
            InOut.PrintTxt<Person>((BookingList<Person>)Session["SpentMostNights"], Results, "Žmonės praleidę daugiausiai naktų", Server);
            Money = int.Parse(TextBox1.Text);
            InOut.PrintTxt<Person>((BookingList<Person>)Session["Filtered"], Results, "Žmonės sumokėję mažiau nei " + Money + " eur", Server);
        }
        
        protected void PrintData_Click(object sender, EventArgs e)
        {
            InOut.PrintTxt<Person>((BookingList<Person>)Session["AllPersons"], Data, "Pradiniai žmonių duomenys", Server);
            InOut.PrintTxt<Hotel>((BookingList<Hotel>)Session["AllHotels"], Data, "Pradiniai viešbučių duomenys", Server);
        }

        private void AddPersonsToTable(BookingList<Person> Persons)
        {
            TableRow header = new TableRow();
            TableCell surname = new TableCell();
            TableCell name = new TableCell();
            TableCell roomType = new TableCell();
            TableCell hotelName = new TableCell();
            TableCell nights = new TableCell();
            
            surname.Text = "Pavardė";
            name.Text = "Vardas";
            roomType.Text = "Kambario tipas";
            hotelName.Text = "Viešbutis";
            nights.Text = "Nakvynės";

            surname.Style.Add("border", "1px solid black");
            name.Style.Add("border", "1px solid black");
            roomType.Style.Add("border", "1px solid black");
            hotelName.Style.Add("border", "1px solid black");
            nights.Style.Add("border", "1px solid black");

            header.Cells.Add(surname);
            header.Cells.Add(name);
            header.Cells.Add(roomType);
            header.Cells.Add(hotelName);
            header.Cells.Add(nights);
            Table1.Rows.Add(header);
            foreach (var Person in Persons)
            {
                TableRow person = new TableRow();

                TableCell surnameTemp = new TableCell();
                TableCell nameTemp = new TableCell();
                TableCell hotelTemp = new TableCell();
                TableCell roomTypeTemp = new TableCell();
                TableCell nightsTemp = new TableCell();

                surnameTemp.Text = Person.Surname;
                nameTemp.Text = Person.Name;
                hotelTemp.Text = Person.Hotel;
                roomTypeTemp.Text = Person.RoomType;
                nightsTemp.Text = Person.Nights.ToString();

                surnameTemp.Style.Add("border", "1px solid black");
                nameTemp.Style.Add("border", "1px solid black");
                hotelTemp.Style.Add("border", "1px solid black");
                roomTypeTemp.Style.Add("border", "1px solid black");
                nightsTemp.Style.Add("border", "1px solid black");

                person.Cells.Add(surnameTemp);
                person.Cells.Add(nameTemp);
                person.Cells.Add(roomTypeTemp);
                person.Cells.Add(hotelTemp);
                person.Cells.Add(nightsTemp);

                Table1.Rows.Add(person);
            }
        }

        private void AddHotelsToTable(BookingList<Hotel> AllHotels)
        {
            TableRow header = new TableRow();

            TableCell hotel = new TableCell();
            TableCell type = new TableCell();
            TableCell price = new TableCell();

            hotel.Text = "Viešbutis";
            type.Text = "Tipas";
            price.Text = "Kaina";

            hotel.Style.Add("border", "1px solid black");
            type.Style.Add("border", "1px solid black");
            price.Style.Add("border", "1px solid black");

            header.Cells.Add(hotel);
            header.Cells.Add(type);
            header.Cells.Add(price);
            Table1.Rows.Add(header);

            foreach (var Hotel in AllHotels)
            {
                TableRow person = new TableRow();

                TableCell hotelTemp = new TableCell();
                TableCell typeTemp = new TableCell();
                TableCell priceTemp = new TableCell();

                hotelTemp.Text = Hotel.HotelName;
                typeTemp.Text = Hotel.RoomType;
                priceTemp.Text = Hotel.Price.ToString();

                hotelTemp.Style.Add("border", "1px solid black");
                typeTemp.Style.Add("border", "1px solid black");
                priceTemp.Style.Add("border", "1px solid black");

                person.Cells.Add(hotelTemp);
                person.Cells.Add(typeTemp);
                person.Cells.Add(priceTemp);

                Table1.Rows.Add(person);
            }
        }
    }
}