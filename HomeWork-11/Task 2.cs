using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    public interface IHotelSearch
    {
        List<Hotel> SearchHotels(string location, string classType, decimal? maxPrice);
    }
    public interface IBooking
    {
        bool CreateBooking(int hotelId, DateTime arrivalDate, DateTime departureDate, int userId);
        bool IsAvailable(int hotelId, DateTime arrivalDate, DateTime departureDate);
    }
    public interface IPayment
    {
        bool ProcessPayment(decimal amount);
    }
    public interface INotification
    {
        void SendConfirmation(int bookingId);
    }
    public interface IUserManagement
    {
        int RegisterUser(string username, string password);
        int Login(string username, string password);
    }
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ClassType { get; set; }
        public decimal Price { get; set; }
    }

    public class Booking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class HotelService : IHotelSearch
    {
        public List<Hotel> SearchHotels(string location, string classType, decimal? maxPrice)
        {
            Console.WriteLine($"Поиска отелей в {location}, класс: {classType}, цена до {maxPrice:C}");
            return new List<Hotel>() {
            new Hotel { Id = 1, Name = "Отель \"Уют\"", Location = location, ClassType = classType, Price = 1000 }
        };
        }
    }

    public class BookingService : IBooking
    {
        private int nextBookingId = 1;
        public bool CreateBooking(int hotelId, DateTime arrivalDate, DateTime departureDate, int userId)
        {
            Console.WriteLine($"Бронирования номера в отеле {hotelId} с {arrivalDate:d} по {departureDate:d} для пользователя {userId}");
            Console.WriteLine($"Номер бронирования: {nextBookingId++}");
            return true;
        }

        public bool IsAvailable(int hotelId, DateTime arrivalDate, DateTime departureDate)
        {
            Console.WriteLine("Проверка доступности - свободно!");
            return true;
        }
    }
    public class PaymentService : IPayment
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Оплата {amount:C}");
            return true;
        }
    }
    public class NotificationService : INotification
    {
        public void SendConfirmation(int bookingId)
        {
            Console.WriteLine($"Отправка подтверждения бронирования №{bookingId}");
        }
    }
    public class UserManagementService : IUserManagement
    {
        private int nextUserId = 1;
        public int RegisterUser(string username, string password)
        {
            Console.WriteLine($"Регистрация пользователя {username}");
            return nextUserId++;
        }
        public int Login(string username, string password)
        {
            Console.WriteLine($"Вход пользователя {username}");
            return 1;
        }
    }
    public class UI
    {
        private readonly IHotelSearch _hotelService;
        private readonly IBooking _bookingService;
        private readonly IPayment _paymentService;
        private readonly INotification _notificationService;
        private readonly IUserManagement _userManagementService;

        public UI(IHotelSearch hotelService, IBooking bookingService, IPayment paymentService,
                  INotification notificationService, IUserManagement userManagementService)
        {
            _hotelService = hotelService;
            _bookingService = bookingService;
            _paymentService = paymentService;
            _notificationService = notificationService;
            _userManagementService = userManagementService;
        }

        public void Run()
        {
            Console.WriteLine("Добро пожаловать в систему бронирования отелей!");
            var hotels = _hotelService.SearchHotels("Москва", "Люкс", 5000);
            if (hotels.Count > 0)
            {
                Console.WriteLine($"Найден отель: {hotels[0].Name}");
                if (_bookingService.CreateBooking(hotels[0].Id, DateTime.Now, DateTime.Now.AddDays(3), 1))
                {
                    Console.WriteLine("Бронирование успешно создано!");
                }
            }
            else
            {
                Console.WriteLine("Отели не найдены.");
            }
        }
    }
    internal class Task_2
    {
    }
}
