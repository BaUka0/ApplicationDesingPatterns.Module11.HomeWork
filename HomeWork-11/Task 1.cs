using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Status { get; set; } = "В наличии";
        public Book() { }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, ISBN: {ISBN}, Статус: {Status}";
        }
    }
    public class Reader
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public Reader() { }
        public Reader(string name)
        {
            Name = name;
        }
    }
    public class Librarian
    {
        public string Name { get; set; }
        public Librarian() { }
        public Librarian(string name)
        {
            Name = name;
        }
        public void AddBook(Library library, Book book)
        {
            library.Books.Add(book);
            Console.WriteLine($"{Name} добавил книгу \"{book.Title}\" в библиотеку.");
        }

        public void RemoveBook(Library library, Book book)
        {
            library.Books.Remove(book);
            Console.WriteLine($"{Name} удалил книгу \"{book.Title}\" из библиотеки.");
        }
    }
    public class Library
    {
        public List<Book> Books { get; set; }
        public int maxBook = 3;
        public Library()
        {
            Books = new List<Book>();
        }

        public List<Book> GetAvailableBooks()
        {
            return Books.Where(b => b.Status == "В наличии").ToList();
        }
        public List<Book> GetAllBooks()
        {
            return Books;
        }
        public void BorrowBook(Reader reader, Book book)
        {
            if (reader.BorrowedBooks.Count >= maxBook)
            {
                Console.WriteLine($"{reader.Name} достиг максимального количества арендованных книг ({maxBook}).");
                return;
            }
            if (book.Status == "В наличии")
            {
                book.Status = "Арендована";
                reader.BorrowedBooks.Add(book);
                Console.WriteLine($"{reader.Name} взял книгу {book.Title}");
            }
            else
            {
                Console.WriteLine($"Книга {book.Title} уже арендована.");
            }
        }
        public void ReturnBook(Reader reader, Book book)
        {
            if (reader.BorrowedBooks.Contains(book))
            {
                book.Status = "В наличии";
                reader.BorrowedBooks.Remove(book);
                Console.WriteLine($"{reader.Name} вернул книгу {book.Title}");
            }
            else
            {
                Console.WriteLine($"{reader.Name} не брал книгу {book.Title}");
            }
        }
        public List<Book> SearchBooks(string query)
        {
            return Books.Where(b => b.Title.ToLower().Contains(query.ToLower()) || b.Author.ToLower().Contains(query.ToLower())).ToList();
        }
        public void SetMaxBook(int maxBooks)
        {
            maxBook = maxBooks;
        }

    }
    internal class Task_1
    {
    }
}
