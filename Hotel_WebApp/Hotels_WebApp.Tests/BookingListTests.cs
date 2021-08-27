using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LD_3_Hotels_WebApp;
using Xunit;

namespace LD_3_Hotels_WebApp.Tests
{
    public class BookingListTests
    {
        [Fact]
        public void Constructor_CreatingEmptyObjectWithPerson()
        {
            //arange
            BookingList<Person> Persons = new BookingList<Person>();

            Assert.Empty(Persons);
        }
        [Fact]
        public void Add_PersonDataWillBeAdded_NotEmptyObject()
        {
            //arange
            BookingList<Person> Persons = new BookingList<Person>();

            Person first = new Person("Petrauskas", "Marius", "Pakalnė", "Šeimyninis", 7);
            
            //Action

            Persons.Add(first);

            //assert

            Assert.NotEmpty(Persons);
           
        }
        [Fact]
        public void Constructor_CreatingEmptyObjectWithHotel()
        {
            //arange
            BookingList<Hotel> Hotels = new BookingList<Hotel>();

            Assert.Empty(Hotels);
        }
        [Fact]
        public void Add_HotelDataWillBeAdded_NotEmptyObject()
        {
            //arange
            BookingList<Hotel> Hotels = new BookingList<Hotel>();

            Hotel first = new Hotel("Žuvėdra", "Dvivietis", 15);

            //Action

            Hotels.Add(first);
            
            Assert.NotEmpty(Hotels);
        }
        [Fact]
        public void Sort_AddPersonsWithDifferentSurnames_SortedInAlphabethicOrder()
        {
            BookingList<Person> Persons = new BookingList<Person>();

            Person first = new Person("Petrauskas", "Marius", "Pakalnė", "Šeimyninis", 7);
            Person second = new Person("Markaitis", "Lukas", "Pakalnė", "Šeimyninis", 7);
            Person third = new Person("Antanaitis", "Darius", "Pakalnė", "Šeimyninis", 7);

            //Action

            Persons.Add(first);
            Persons.Add(second);
            Persons.Add(third);

            Persons.Sort();
            
            Assert.NotEmpty(Persons);
            
        }
    }
}
