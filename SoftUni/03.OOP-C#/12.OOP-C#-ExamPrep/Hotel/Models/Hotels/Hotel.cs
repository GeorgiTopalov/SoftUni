namespace BookingApp.Models.Hotels.Contacts
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Utilities.Messages;
    using System.Linq;
    using System;
    using BookingApp.Repositories;
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                this.fullName = value;
            }
        }

        public int Category
        {
            get { return this.category; }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCategory);
                }
                this.category = value;
            }
        }
        public double Turnover
        => Math.Round(Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight), 2);

        public IRepository<IRoom> Rooms { get; }

        public IRepository<IBooking> Bookings { get; }
    }
}
