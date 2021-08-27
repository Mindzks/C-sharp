using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace LD_3_Hotels_WebApp
{
    class InOut
    {
        /// <summary>
        /// This method is used to read persons data from the txt file
        /// </summary>
        /// <param name="fileName">The name of the file, where data about persons is given</param>
        /// <param name="Server">The HttpServerUtility used to find the direction for the file</param>
        /// <returns>Returns the list of Persons</returns>
        public static BookingList<Person> ReadPersons(string fileName, HttpServerUtility Server)
        {
            BookingList<Person> list = new BookingList<Person>();
            string[] lines = File.ReadAllLines(Server.MapPath(fileName), Encoding.UTF8);
            if (lines.Count() != 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string surname = parts[0];
                    string name = parts[1];
                    string hotel = parts[2];
                    string roomType = parts[3];
                    int nights = int.Parse(parts[4]);

                    Person temp = new Person(surname, name, hotel, roomType, nights);
                    list.Add(temp);
                }
            }
            return list;
        }
        /// <summary>
        /// This method is used to read hotels data from the txt file
        /// </summary>
        /// <param name="fileName">The name of the file, where data about hotels is given</param>
        /// <param name="Server">The HttpServerUtility used to find the direction for the file</param>
        /// <returns>Returns the list of hotels</returns>
        public static BookingList<Hotel> ReadHotels(string fileName, HttpServerUtility Server)
        {
            BookingList<Hotel> AllHotels = new BookingList<Hotel>();
            string[] lines = File.ReadAllLines(Server.MapPath(fileName), Encoding.UTF8);
            if (lines.Count() != 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string name = parts[0];
                    string type = parts[1];
                    int price = int.Parse(parts[2]);

                    Hotel temp = new Hotel(name, type, price);
                    AllHotels.Add(temp);
                }
                return AllHotels;
            }
            else
            {
                return AllHotels;
            }
        }
        /// <summary>
        /// This method is generic. It is used to print information about hotels or persons to the txt file.
        /// This method overwrites same file every time it is called with the same property: filename.
        /// </summary>
        /// <typeparam name="T">The type of the list object which is given to the method</typeparam>
        /// <param name="data">The name of the list object</param>
        /// <param name="filename">The name of the file, where information about the object will be printed</param>
        /// <param name="header">The header of the table in the file, where information about the object will be printed</param>
        /// <param name="Server">The HttpServerUtility used to find the direction for the file</param>
        public static void PrintTxt<T>(BookingList<T> data, string filename, string header, HttpServerUtility Server) where T: class, IComparable<T>, IEquatable<T>
        {
            using (StreamWriter sw = File.AppendText(Server.MapPath(filename)))
            {
                sw.WriteLine(header);
                if (data == null)
                {
                    sw.WriteLine("Sąrašas tuščias");
                }
                else
                {
                    sw.WriteLine(new string('-', 40));
                    foreach (var item in data)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine(new string('-', 40));
                }
            }
        }
    }
}

//public static BookingList<T> Read<T>(string fileName, HttpServerUtility Server) where T : class, IComparable<T>, IEquatable<T>
//{
//    string[] lines = File.ReadAllLines(Server.MapPath(fileName), Encoding.UTF8);

//    BookingList<T> data = new BookingList<T>();
//    if (lines.Count() != 0)
//    {
//        if (typeof(T) == typeof(Hotel))
//        {
//            for (int i = 0; i < lines.Length; i++)
//            {
//                string[] parts = lines[i].Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
//                string name = parts[0];
//                string type = parts[1];
//                int price = int.Parse(parts[2]);

//                Hotel temp = new Hotel(name, type, price);
//                data.Add(temp);
//            }
//            return data;

//        }
//    }
//}