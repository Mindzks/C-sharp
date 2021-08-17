using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteVisits
{
    class Client
    {
        //Date of the time when website was visited
        public DateTime Data { get; private set; }
        //The server IP, which was visited
        public string ServerIP { get; private set; }
        //Hours when website was visited
        public int Hours { get; private set; }
        //Minutes when website was visited
        public int Minutes { get; private set; }
        //Seconds when website was visited
        public int Seconds { get; private set; }
        //Computer IP address 
        public string PcIP { get; private set; }
        //Full website path wich current computer visited
        public string FullWebPath { get; private set; }

        public Client(DateTime data, string serverIP, int hours, int minutes, int seconds, string pcip, string fullWebPath)
        {
            this.Data = data;
            this.ServerIP = serverIP;
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.PcIP = pcip;
            this.FullWebPath = fullWebPath;
        }
    }
}