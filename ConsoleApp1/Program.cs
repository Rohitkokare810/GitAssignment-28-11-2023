using System;
using System.Collections.Generic;

class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
}

class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added successfully.");
    }

    public void ViewAllBooks()
    {
        Console.WriteLine("All Books in the Library:");
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Available: {book.IsAvailable}");
        }
    }

    public void SearchBookByld(int bookId)
    {
        Book foundBook = books.Find(book => book.BookId == bookId);

        if (foundBook != null)
        {
            Console.WriteLine($"Book found - ID: {foundBook.BookId}, Title: {foundBook.Title}, Author: {foundBook.Author}, Genre: {foundBook.Genre}, Available: {foundBook.IsAvailable}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void SearchBookByTitle(string title)
    {
        Book foundBook = books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (foundBook != null)
        {
            Console.WriteLine($"Book found - ID: {foundBook.BookId}, Title: {foundBook.Title}, Author: {foundBook.Author}, Genre: {foundBook.Genre}, Available: {foundBook.IsAvailable}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Search by ID");
            Console.WriteLine("4. Search by Title");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Book ID: ");
                        int bookId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter Genre: ");
                        string genre = Console.ReadLine();
                        Book newBook = new Book { BookId = bookId, Title = title, Author = author, Genre = genre, IsAvailable = true };
                        library.AddBook(newBook);
                        break;

                    case 2:
                        library.ViewAllBooks();
                        break;

                    case 3:
                        Console.Write("Enter Book ID to search: ");
                        int searchById = int.Parse(Console.ReadLine());
                        library.SearchBookByld(searchById);
                        break;

                    case 4:
                        Console.Write("Enter Title to search: ");
                        string searchByTitle = Console.ReadLine();
                        library.SearchBookByTitle(searchByTitle);
                        break;

                    case 5:
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        Console.ReadKey();
    }
}
