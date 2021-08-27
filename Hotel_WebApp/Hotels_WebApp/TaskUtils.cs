using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_3_Hotels_WebApp
{
    class TaskUtils
    {
        /// <summary>
        /// The method BookedHotels uses two object lists to find hotels, which were booked by customers.
        /// </summary>
        /// <param name="Allpersons">The list of people. Data is from the txt file.</param>
        /// <param name="Allhotels">The list of hotels. Data is from the txt file.</param>
        /// <returns>Filtered list of Hotels, which were booked</returns>
        public static BookingList<Hotel> BookedHotels(BookingList<Person> Allpersons, BookingList<Hotel> Allhotels)
        {
            BookingList<Hotel> temp = new BookingList<Hotel>();
            foreach (var hotel in Allhotels)
            {
                foreach (var person in Allpersons)
                {
                    if (hotel.Equals(person))
                    {
                        temp.Add(hotel);
                        break;
                    }
                }
            }
            return temp;
        }
        /// <summary>
        /// The method NotBookedHotels uses two object lists to find hotels, which weren't booked by customers.
        /// </summary>
        /// <param name="Allpersons">The list of people. Data is from the txt file.</param>
        /// <param name="Allhotels">The list of hotels. Data is from the txt file.</param>
        /// <returns>>Filtered list of Hotels, which were not booked</returns>
        public static BookingList<Hotel> notBookedHotels(BookingList<Person> Allpersons, BookingList<Hotel> Allhotels)
        {
            BookingList<Hotel> temp = new BookingList<Hotel>();
            bool check = false;
            foreach (var hotel in Allhotels)
            {
                foreach (var person in Allpersons)
                {
                    if (hotel.Equals(person))
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        check = true;
                    }
                }
                if (check)
                {
                    temp.Add(hotel);
                }
            }
            return temp;
        }
        /// <summary>
        /// The method SpentMostNights uses one object list to find people, who spent most number of nights in hotel. It can be one person or several persons
        /// with the highest number of spent nights
        /// </summary>
        /// <param name="Allpersons">The list of people. Data is from the txt file.</param>
        /// <returns>Returns the filetered list of the people, who spent most nights </returns>
        public static BookingList<Person> SpentMostNights(BookingList<Person> Allpersons)
        {
            BookingList<Person> temp = new BookingList<Person>();
            int mostNightsNumber = 0;


            foreach (Person item in Allpersons)
            {
                if (item.Nights > mostNightsNumber)
                {
                    mostNightsNumber = item.Nights;
                }
            }

            foreach (Person item in Allpersons)
            {
                if (mostNightsNumber == item.Nights)
                {
                    temp.Add(item);
                }
            }
            temp.Sort();
            return temp;
        }
        /// <summary>
        /// The method FilteredBySpentMoney uses one object list to find people, who spent most number money for booking hotel. It can be one person or several persons
        /// with the highest amount of money paid.
        /// </summary>
        /// <param name="Allpersons">The list of people. Data is from the txt file.</param>
        /// <param name="Allhotels">The list of hotels. Data is from the txt file.</param>
        /// <param name="money">The number of money which was given by the user on the web form</param>
        /// <returns>>Returns the filetered list of the people, who spent most money</returns>
        public static BookingList<Person> FilteredBySpentMoney(BookingList<Person> Allpersons, BookingList<Hotel> Allhotels, int money)
        {
            BookingList<Person> temp = new BookingList<Person>();

            foreach (var person in Allpersons)
            {
                foreach (var hotel in Allhotels)
                {
                    //Uses equals method in Hotel class. Equals is with Person class and compares only hotel names.
                    if (hotel.Equals(person))
                    {
                        person.CalculateSpentMoney(hotel.Price);
                        break;
                    }
                }
                if (person.MoneySpent <= money)
                {
                    temp.Add(person);
                }
            }
            temp.Sort();
            return temp;
        }
    }
}