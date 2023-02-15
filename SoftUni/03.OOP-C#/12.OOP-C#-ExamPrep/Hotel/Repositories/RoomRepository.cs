using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Repositories
{
    public  class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> roomRepository;

        public RoomRepository()
        {
            this.roomRepository = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            this.roomRepository.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return this.roomRepository;
        }

        public IRoom Select(string criteria)
        =>roomRepository.FirstOrDefault(x => x.GetType().Name == criteria);
        
    }
}
