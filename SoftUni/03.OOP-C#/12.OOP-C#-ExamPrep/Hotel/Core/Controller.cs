using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly HotelRepository hotelRepository;
        private int totalBookingsCount;
        public Controller()
        {
            this.hotelRepository = new HotelRepository();
            this.TotalBookingsCount = 0;
        }

        public int TotalBookingsCount 
        { 
            get => this.totalBookingsCount;
            set => this.totalBookingsCount = value;
        }
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotelToCheck = hotelRepository.Select(hotelName);

            if (hotelToCheck != default)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }
            else
            {
                hotelRepository.AddNew(new Hotel(hotelName, category));
                return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            Room bestFitRoom = default;
            int people = adults + children;

            if (!this.hotelRepository.All().Any(x => x.Category == category))
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            foreach (IHotel hotel in this.hotelRepository.All().Where(x => x.Category == category).OrderBy(x => x.FullName))
            {

                foreach (Room room in hotel.Rooms.All().Where(x => x.PricePerNight > 0).OrderBy(x => x.BedCapacity))
                {

                    if (room.BedCapacity >= people && bestFitRoom == default)
                    {
                        bestFitRoom = room;
                    }
                    if (bestFitRoom != default)
                    {
                        TotalBookingsCount++;
                        IBooking booking = new Booking(bestFitRoom, duration, adults, children, this.TotalBookingsCount);
                        hotel.Bookings.AddNew(booking);
                        return String.Format(OutputMessages.BookingSuccessful, (this.TotalBookingsCount).ToString(), hotel.FullName);
                    }
                }

            }

            return String.Format(OutputMessages.RoomNotAppropriate);

        }

        public string HotelReport(string hotelName)
        {
            StringBuilder sb = new StringBuilder();

            if (!hotelRepository.All().Any(x => x.FullName == hotelName))
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = hotelRepository.All().FirstOrDefault(x => x.FullName == hotelName);

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (!hotel.Bookings.All().Any())
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (Booking booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {

            IHotel hotelToCheck = hotelRepository.Select(hotelName);

            if (!hotelRepository.All().Any(x => x.FullName == hotelName))
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            else
            {
                if (roomTypeName != "Apartment" &&
                    roomTypeName != "DoubleBed" &&
                    roomTypeName != "Studio")
                {
                    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
                }
                else if (!hotelToCheck.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
                {
                    return string.Format(OutputMessages.RoomTypeNotCreated);
                }
                else if (hotelToCheck.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName).PricePerNight != 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
                }
                else
                {
                    Type roomType = Type.GetType(roomTypeName);
                    hotelToCheck.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName).SetPrice(price);
                    return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
                }
            }


        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotelToCheck = hotelRepository.Select(hotelName);

            if (hotelToCheck == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            else
            {
                if (roomTypeName != "Apartment" &&
                    roomTypeName != "DoubleBed" &&
                    roomTypeName != "Studio")
                {
                    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
                }
                else if (hotelToCheck.Rooms.Select(roomTypeName) != null)
                {
                    return string.Format(OutputMessages.RoomTypeAlreadyCreated);
                }
                else
                {
                    string roomFullName = string.Format("{0}.{1}", typeof(Room).Namespace, roomTypeName);
                    Type roomType = Type.GetType(roomFullName);
                    IRoom room = (IRoom)Activator.CreateInstance(roomType);
                    hotelToCheck.Rooms.AddNew(room);
                    return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
                }
            }
        }
    }
}
