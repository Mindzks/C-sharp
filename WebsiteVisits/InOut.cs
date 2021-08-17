using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

namespace WebsiteVisits
{
    class InOut
    {
        /// <summary>
        /// This method reads the data about servers from given catalog. You should provide empty list and if the file isn't broken,
        /// data will be added to the list.
        /// </summary>
        /// <param name="ServerData">Empty servers list</param>
        /// <param name="dir">Full path where servers data is placed</param>
        /// <param name="message">This element is required to print exception message if it occurs</param>
        public static void ReadServerData(InfoList<Server> ServerData, string dir, Label message)
        {
            string[] files = Directory.GetFiles(dir);
            foreach (var file in files)
            {
                string[] lines = File.ReadAllLines(file);
                try
                {
                    foreach (var item in lines)
                    {
                        string[] parts = item.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        string IP = parts[0];
                        string Domain = parts[1];

                        Server temp = new Server(IP, Domain);
                        ServerData.Add(temp);
                    }
                }
                catch
                {
                    message.Text = string.Format("Nepilnas duomenų failas {0}", file);
                }
            }
        }
        /// <summary>
        /// This method reads the data about clients from given catalog. You should provide empty list and if the file isn't broken,
        /// data will be added to the list.
        /// </summary>
        /// <param name="ClientsData">Empty clients list</param>
        /// <param name="dir">Full path where clients data is placed</param>
        /// <param name="message">This element is required to print exception message if it occurs</param>
        public static void ReadClientsData(InfoList<Client> ClientsData, string dir, Label message)
        {
            string[] files = Directory.GetFiles(dir);
            foreach (var file in files)
            {
                string[] lines = File.ReadAllLines(file);
                try
                {
                    string[] FirstLineData = lines[0].Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    DateTime Data = DateTime.Parse(FirstLineData[0]);
                    string ServerIp = FirstLineData[1];

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        int hours = int.Parse(parts[0]);
                        int minutes = int.Parse(parts[1]);
                        int secods = int.Parse(parts[2]);
                        string IP = parts[3];
                        string FullPath = parts[4];

                        Client temp = new Client(Data, ServerIp, hours, minutes, secods, IP, FullPath);

                        ClientsData.Add(temp);
                    }
                }
                catch
                {
                    message.Text = string.Format("Nepilnas duomenų failas {0}", file);
                }
            }
        }
    }
}