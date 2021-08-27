using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_3_Hotels_WebApp
{
    public class Hotel : IComparable<Hotel>, IEquatable<Hotel>
    {
        //The name of the hotel
        public string HotelName { get; private set; }
        //The type of the room in the hotel
        public string RoomType { get; private set; }
        //The price of the one night in that hotel for particular room
        public int Price { get; private set; }

        public Hotel(string hotelName, string roomType, int price)
        {
            HotelName = hotelName;
            RoomType = roomType;
            Price = price;
        }

        /// <summary>
        /// Forms the line for printing to txt file. Data in line represents: surname, name, room type, hotel name, nights number.
        /// </summary>
        /// <returns>String line</returns>
        public override string ToString()
        {
            return string.Format("|{0, -15}|{1, -15}|{2, 6}|", HotelName, RoomType, Price);
        }

        public int CompareTo(Hotel other)
        {
            if (HotelName.CompareTo(other.HotelName) != 0)
            {
                return HotelName.CompareTo(other.HotelName);
            }
            else
            {
                return RoomType.CompareTo(other.RoomType);
            }
        }

        public bool Equals(Hotel other)
        {
            if (other.HotelName.CompareTo(HotelName) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Equals(Person person)
        {
            if (HotelName.CompareTo(person.Hotel) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}