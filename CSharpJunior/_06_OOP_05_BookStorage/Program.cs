using System;
using System.Collections.Generic;

namespace _06_OOP_05_BookStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStorage boxOfBooks = new BookStorage();

            Console.WriteLine("Вы делаете курсовую работу и уже подходите к завершению, " +
                              "по заданию надо было написать интернет магазин по продаже книг.\n" +
                              "Осталось только протестировать весь функционал. Чем собственно вы и занимаетесь.\n" +
                              "Так, что же там по пунктам:\n\n" +
                              "1. Отобразить весь список книг:");
            boxOfBooks.ShowBooks();

            Console.Write("\nСупер, это работает, теперь необходимо удалить книгу.\n" +
                          "Введите номер книги чтобы её удалить: ");
            int bookId = Convert.ToInt32(Console.ReadLine());
            boxOfBooks.Remove(bookId);

            Console.WriteLine("\nАга, поведение корректное, так, что теперь там хранится:");
            boxOfBooks.ShowBooks();

            Console.WriteLine("\nТеперь необходимо проверить добавление книги:");
            Console.Write("Введите название: ");
            string bookName = Console.ReadLine();
            Console.Write("Введите автора: ");
            string bookAuthor = Console.ReadLine();
            Console.Write("Введите год: ");
            int bookYearOfPublication = Convert.ToInt32(Console.ReadLine());

            boxOfBooks.Add(new Book(bookName, bookAuthor, bookYearOfPublication));

            Console.WriteLine("\nПроверим что у нас получилось:");
            boxOfBooks.ShowBooks();

            Console.WriteLine("\nТеперь проверим поиск:");
            Console.Write("\nВведите название: ");
            boxOfBooks.ShowBooksByName(Console.ReadLine());
            Console.Write("\nВведите автора: ");
            boxOfBooks.ShowBooksByAuthor(Console.ReadLine());
            Console.Write("\nВведите год: ");
            boxOfBooks.ShowBooksByYearOfPublication(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("\nСупер, теперь все готово!");
        }
    }

    class Book
    {
        public Book(string name, string author, int yearOfPublication)
        {
            Name = name;
            Author = author;
            YearOfPublication = yearOfPublication;
        }

        public string Name { get; private set; }

        public string Author { get; private set; }

        public int YearOfPublication { get; private set; }

        public string Info
        {
            get { return $"{Author} «{Name}», {YearOfPublication}."; }
        }
    }

    class BookStorage
    {
        private List<Book> _books;

        public BookStorage()
        {
            _books = new List<Book>()
            {
                new Book("Война и мир", "Лев Толстой", 1867),
                new Book("Анна Каренина", "Лев Толстой", 1878),
                new Book("1984", "Джордж Оруэлл", 1949),
                new Book("Скотный двор", "Джордж Оруэлл", 1945)
            };
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public void Remove(int bookId)
        {
            if (bookId < 0 || bookId > _books.Count - 1)
            {
                Console.WriteLine($"Книги с идетификатором {bookId} не существует");
            }
            else
            {
                _books.RemoveAt(bookId);
            }
        }

        public void ShowBooks()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"{i} - {_books[i].Info}");
            }
        }

        public void ShowBooksByName(string name)
        {
            foreach (Book book in _books)
            {
                if (book.Name.ToLower() == name.ToLower())
                {
                    Console.WriteLine(book.Info);
                }
            }
        }

        public void ShowBooksByAuthor(string author)
        {
            foreach (Book book in _books)
            {
                if (book.Author.ToLower() == author.ToLower())
                {
                    Console.WriteLine(book.Info);
                }
            }
        }

        public void ShowBooksByYearOfPublication(int yearOfPublication)
        {
            foreach (Book book in _books)
            {
                if (book.YearOfPublication == yearOfPublication)
                {
                    Console.WriteLine(book.Info);
                }
            }
        }
    }
}