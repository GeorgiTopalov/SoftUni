using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> hotelRepository;

        public HotelRepository()
        {
            this.hotelRepository = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            this.hotelRepository.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return this.hotelRepository;
        }

        public IHotel Select(string criteria)
        => hotelRepository.FirstOrDefault(x => x.FullName == criteria);
        
    }
}
