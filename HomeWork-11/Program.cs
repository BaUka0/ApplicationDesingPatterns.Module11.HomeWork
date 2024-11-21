using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Task1
            Librarian librarian = new Librarian("Сергей Алексеев");
            Library library = new Library();
            librarian.AddBook(library, new Book("Война и мир", "Л. Толстой", "978-5-17-091281-7"));
            librarian.AddBook(library, new Book("Мертвые души", "Н. Гоголь", "978-5-17-091282-4"));
            librarian.AddBook(library, new Book("Преступление и наказание", "Ф. Достоевский", "978-5-17-091283-1"));

            Reader reader1 = new Reader("Иван Иванов");

            library.BorrowBook(reader1, library.Books[0]);
            library.BorrowBook(reader1, library.Books[1]);

            Console.WriteLine("\nДоступные книги:");
            foreach (var book in library.GetAvailableBooks())
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("\nВсе книги:");
            foreach (var book in library.GetAllBooks())
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\nПоиск по автору 'Толстой':");
            foreach (var book in library.SearchBooks("Толстой"))
            {
                Console.WriteLine(book);
            }

            library.ReturnBook(reader1, library.Books[0]);

            Console.WriteLine("\nВсе книги после возврата:");
            foreach (var book in library.GetAllBooks())
            {
                Console.WriteLine(book);
            }

            //Task2
            var hotelService = new HotelService();
            var bookingService = new BookingService();
            var paymentService = new PaymentService();
            var notificationService = new NotificationService();
            var userManagementService = new UserManagementService();

            var ui = new UI(hotelService, bookingService, paymentService, notificationService, userManagementService);
            ui.Run();
        }
    }
}
