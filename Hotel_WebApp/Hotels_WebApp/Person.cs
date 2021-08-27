using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_3_Hotels_WebApp
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        //The name of the Person
        public string Name { get; private set; }
        //The surname of the Person
        public string Surname { get; private set; }
        //The name of hotel in which person stayed
        public string Hotel { get; private set; }
        //The type of the room, of the hotel where person stayed
        public string RoomType { get; private set; }
        //The number of nights the person spent on the hotel
        public int Nights { get; private set; }
        //The amount of money person spent in the particular hotel
        public int MoneySpent { get; private set; }

        public Person(string surname, string name, string hotel, string roomtype, int nights)
        {
            Name = name;
            Surname = surname;
            Hotel = hotel;
            RoomType = roomtype;
            Nights = nights;
        }

        /// <summary>
        /// Forms the line for printing to txt file. Data in line represents: surname, name, room type, hotel name, nights number.
        /// </summary>
        /// <returns>String line</returns>
        public override string ToString()
        {
            return string.Format("|{0, -12}|{1, -12}|{2, -12}|{3, -12}|{4, -12}|", Surname, Name,RoomType,Hotel,Nights);
        }
        /// <summary>
        /// This method calculates the money, person spent in particular hotel
        /// </summary>
        /// <param name="price">The price of the one night in the hotel, where person stayed</param>
        public void CalculateSpentMoney(int price)
        {
            int allAmount = price * Nights;
            MoneySpent = allAmount;
        }

        /// <summary>
        /// Compare surname. If surnames match then method compare name. Method used in sort
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Person other)
        {
            if (Surname.CompareTo(other.Surname) != 0)
            {
                return Surname.CompareTo(other.Surname);
            }
            else
            {
                return Name.CompareTo(other.Name);
            }
        }

        public bool Equals(Person other)
        {
            if (other == null)
            {
                return false;
            }
            if (Surname.CompareTo(other.Surname) == 1)
            {
                if (Name.CompareTo(other.Name) == 1)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}