using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> bookingRepository;

        public BookingRepository()
        {
            this.bookingRepository = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            this.bookingRepository.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return this.bookingRepository;
        }

        public IBooking Select(string criteria)
        => bookingRepository.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);  
    }
}
