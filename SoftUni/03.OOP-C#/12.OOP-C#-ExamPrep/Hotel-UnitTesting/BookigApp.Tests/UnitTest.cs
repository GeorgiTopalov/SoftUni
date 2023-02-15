using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_PropertyGettersOfBooking_Should_Return_Proper_Values()
        {
            Room room = new Room(4, 50);
            int residenceDuration = 3;
            int bookingNumber = 2;

            Booking booking = new Booking(bookingNumber, room, residenceDuration);

            Assert.AreEqual(bookingNumber, booking.BookingNumber);
            Assert.AreEqual(residenceDuration, booking.ResidenceDuration);
            Assert.AreEqual(room, booking.Room);
        }

        [Test]
        public void Test_PropertyGettersOfRoom_Should_Return_Proper_Values()
        {
            int bedCapacity = 4;
            double pricePerNight = 70;

            Room room = new Room(bedCapacity, pricePerNight);

            Assert.AreEqual(bedCapacity, room.BedCapacity);
            Assert.AreEqual(pricePerNight, room.PricePerNight);
        }

        [TestCase(0, 50)]
        [TestCase(4, 0)]
        [TestCase(-2, 50)]
        [TestCase(3, -2)]

        public void Test_PropertySettersOfRoom_Should_ThrowException_IfIncorrect(int bedCapacity, double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(bedCapacity, pricePerNight);
            });
        }

        [Test]
        public void Test_PropertyGettersOfHotel_Should_Return_Proper_Values()
        {
            Hotel hotel = new Hotel("Luxor", 5);

            Assert.AreEqual("Luxor", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);
            Assert.AreEqual(0, hotel.Rooms.Count);
            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [TestCase("Luxor", 0)]
        [TestCase("Luxor", 6)]
        
        public void Test_CategoryPropertySettersOfHotel_Should_ThrowException_IfIncorrect(string hotelName, int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel(hotelName, category);
            });
        }
        [TestCase("", 3)]
        [TestCase(null, 3)]
        [TestCase("  ", 3)]
        public void Test_FullNamePropertySettersOfHotel_Should_ThrowException_IfIncorrect(string hotelName, int category)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(hotelName, category);
            });
        }

        [Test]

        public void Test_AddRoom_ShouldAddRoom_ToRooms()
        {
            Room room = new Room(4, 60);
            Hotel hotel = new Hotel("Luxor", 5);

            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
            Assert.AreEqual(room, hotel.Rooms.FirstOrDefault());
        }

        [TestCase(0 , 1, 2, 100)]
        [TestCase(-2 , 1, 2, 100)]
        [TestCase(2 , -1, 2, 100)]
        [TestCase(2 , 1, 0, 100)]
        [TestCase(2 , 1, -5, 100)]

        public void Test_BookingRoom_ShouldThrowException_WhenDataIsInvalid(int adults, int children, int duration, double budget)
        {
            Hotel hotel = new Hotel("Luxor", 5);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, children, duration, budget); 
            });
        }

        [Test]
        public void Test_BookingRoomMethod_ShouldAddBookingAndChangeTurnover()
        {
            Hotel hotel = new Hotel("Luxor", 5);
            Room room = new Room(4, 50);

            hotel.AddRoom(room);

            hotel.BookRoom(2, 2, 2, 200);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(1, hotel.Bookings.First().BookingNumber);
            Assert.AreEqual(room, hotel.Bookings.First().Room);
            Assert.AreEqual(100, hotel.Turnover);
        }

    }
}